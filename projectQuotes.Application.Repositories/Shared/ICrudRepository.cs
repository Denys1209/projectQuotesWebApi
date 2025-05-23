﻿
using projectQuotes.Domain.ForFilter;
using projectQuotes.Domain.Models.Shared;

namespace projectQuotes.Application.Repositories.Shared;

public interface ICrudRepository<TModel>
    where TModel : class, IModel
{
    Task<Guid> AddAsync(TModel model, CancellationToken cancellationToken);
    Guid Add(TModel model);
    Task UpdateAsync(TModel model, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken);
    TModel? Get(Guid id);
    Task<PaginatedCollection<TModel>> GetAllAsync(FilterPagination dto, CancellationToken cancellationToken);
    Task<ICollection<TModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<ICollection<TModel?>> GetAllModelsByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
    ICollection<TModel?> GetAllModelsByIds(List<Guid> ids);

}