using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using projectQuotes.Infrastructure.LinkFactories;
using projectQuotesWebApi.Shared;
using projectQuotesWebApi.Application.Services.Users;
using projectQuotes.Infrastructure.JwtTokenFactories;
using projectQuotes.Infrastructure.EmailServer;
using projectQuotes.Dtos.Dto.Users;
using projectQuotes.Dtos.ResponseDto;
using projectQuotes.Constants.Controller;
using projectQuotes.Constants.Models;
using projectQuotes.Dtos.Shared;

namespace projectQuotesWebApi.Controllers;

[Authorize(ControllerStringConstants.CanAccessOnlyAdmin)]
public class UserController(
    IUserService userService,
    IEmailService emailService,
    IJwtTokenFactory jwtTokenFactory,
    IConfiguration configuration,
    ILinkFactory linkFactory,
    RoleManager<IdentityRole<Guid>> roleManager,
    IHttpContextAccessor httpContextAccessor
)
    : MyBaseController(httpContextAccessor),
        ICrudController<UpdateUserDto, UserRegistrationDto>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IJwtTokenFactory _jwtTokenFactory = jwtTokenFactory;
    private readonly IUserService _userService = userService;
    private readonly IEmailService _emailService = emailService;
    private readonly ILinkFactory _linkFactory = linkFactory;



    [AllowAnonymous]
    [HttpPost("RegistrationWithEmail")]
    [SwaggerResponse(StatusCodes.Status200OK, "User registered", typeof(RegistratedResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
       typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> CreateWithEmail([FromBody] UserRegistrationDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());



        var role = await roleManager.FindByNameAsync(model.Role);


        var token = await _userService.RegisterUserWithCodeAsync(model, cancellationToken);

        var link = _linkFactory.GetConfirmingLink(Request, model.Email, token!);



        await _emailService.SendConfirmingEmail(model.Email, model.UserName, link);

        if (token == null) return NotFound(UserConstants.MessageUserIsntRegistrated);


        return Ok();
    }


    [AllowAnonymous]
    [HttpGet("Confirm")]
    [SwaggerResponse(StatusCodes.Status200OK, "Email confirmed")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Email wasn't confirmed")]
    public async Task<IActionResult> Confirm([FromQuery] string email, [FromQuery] string code, CancellationToken cancellationToken)
    {
        var result = await _userService.ConfirmEmailAsync(email, code, cancellationToken);

        if (!result) return NotFound("Email wasn't confirmed");

        return Ok("Email confirmed");
    }

    [AllowAnonymous]
    [HttpPost("Registration")]
    [SwaggerResponse(StatusCodes.Status200OK, "User registered", typeof(RegistratedResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Create([FromBody] UserRegistrationDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var role = await roleManager.FindByNameAsync(model.Role);


        var id = await _userService.RegisterUserAsync(model, cancellationToken);

        if (id == null) return NotFound(UserConstants.MessageUserIsntRegistrated);

        var user = await _userService.GetRawAsync((Guid)id, cancellationToken);


        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new RegistratedResponseUserDto
        {
            Message = UserConstants.MessageUserRegistrated,
            JwtToken = tokenString!,
            Id = (Guid)id
        }
        );
    }


    [HttpPost("GetAll")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return all users")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> GetAll([FromBody] FilterPaginationDto paginationDto,
        CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var returnPageDto = await _userService.GetAllAsync(paginationDto, cancellationToken);



        return Ok(
            returnPageDto
        );
    }


    [AllowAnonymous]
    [HttpGet("{id:Guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Return user by id", typeof(GetUserDto))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        var user = await _userService.GetAsync(id, cancellationToken);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPut("")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User updated")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(string))]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Put([FromBody] UpdateUserDto dto, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(
            new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();


        var getUser = await _userService.GetAsync(dto.Id, cancellationToken);
        if (getUser == null) return NotFound($"user with {dto.Id} doesn't exist");



        await _userService.UpdateAsync(dto, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User deleted")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var errorEndPoint = ValidateRequest(new ThingsToValidateBase());
        if (errorEndPoint.IsError) return errorEndPoint.GetError();

        await _userService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }


    [AllowAnonymous]
    [HttpPost("Login")]
    [SwaggerResponse(StatusCodes.Status200OK, "User logged in", typeof(LoginResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> Login([FromBody] UserLoginDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var user = await _userService.AuthenticateUserAsync(model.Email, model.Password, cancellationToken);
        if (user == null || user.EmailConfirmed == false) return Unauthorized();

        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new LoginResponseUserDto { Token = tokenString! });
    }

    [AllowAnonymous]
    [HttpPost("LoginAdmin")]
    [SwaggerResponse(StatusCodes.Status200OK, "User logged in", typeof(LoginResponseUserDto))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Model Validation Error",
        typeof(IDictionary<string, IEnumerable<string>>))]
    public async Task<IActionResult> LoginAdmin([FromBody] UserLoginDto model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(GetAllErrorsDuringValidation());

        var user = await _userService.AuthenticateUserWithAdminRoleAsync(model.Email, model.Password, cancellationToken);

        if (user == null || user.EmailConfirmed == false) return Unauthorized();

        var tokenString = await _jwtTokenFactory.GetJwtTokenAsync(user, _configuration);

        return Ok(new LoginResponseUserDto { Token = tokenString! });
    }

}