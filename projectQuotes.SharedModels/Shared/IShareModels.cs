using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace projectQuotes.SharedModels.Shared;

public interface IShareModels<TCreateDto, TUpdateDto,TModel>
    where TModel : class, IModel
    where TUpdateDto : ModelDto
{
    public abstract static TModel GetSample();

    public abstract static TModel GetSampleForUpdate();

    public abstract static TCreateDto GetSampleCreateDto();

    public abstract static TUpdateDto GetSampleUpdateDto();

    public abstract static Task<Guid> CreateModelWithAllDependenciesAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);

    public abstract static void AddAllDependencies(IServiceCollection services);

}
