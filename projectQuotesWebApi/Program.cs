using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using projectQuotes.EfPersistence.Data;
using projectQuotes.Infrastructure.EmailServer.Settings;
using projectQuotesWebApi.Conventions;
using projectQuotesWebApi.Extensions;
using projectQuotesWebApi.SwaggerFilters;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

//builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers()
    .AddMvcOptions(o => o.Conventions.Add(new RelationControllerModelConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    //c.OperationFilter<RelationCrudControllerResponseTypesOperationFilter>();
    //c.OperationFilter<CrudControllerResponseTypesOperationFilter>();
    //c.OperationFilter<ColumnSelectorOperationFilter>();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Quote Craft",
        Version = "v1"
    });
    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Please insert JWT token into field",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "Bearer"
    //});
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    [new OpenApiSecurityScheme
    //    {
    //        Reference = new OpenApiReference
    //        {
    //            Type = ReferenceType.SecurityScheme,
    //            Id = "Bearer"
    //        },
    //        Scheme = "oauth2",
    //        Name = "Bearer",
    //        In = ParameterLocation.Header
    //    }] = []
    //});
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddLoggingMiddleware();
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));


builder.Services.AddEmailService(builder.Configuration);
builder.Services.AddIdentity();
builder.Services.AddJwtAuthentication(builder.Configuration);


builder.Services.AddPolicies();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

// In middleware pipeline
app.UseCors();

//app.MapDefaultEndpoints();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

app.UseLoggingMiddleware();
app.MapControllers();

app.Run();

//!!!!!!!!!!!!!! DON'T DELETE IT, IT'S NEEDED FOR INTEGRATION TESTS !!!!!!!!!!!!!!!!!!!!!!!!!!!!
public partial class Program { }