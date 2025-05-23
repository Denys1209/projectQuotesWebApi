﻿using AutoMapper;
using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Domain.ForFilter;
using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.Shared;
using System.Runtime.InteropServices;

namespace projectQuotesWebApi.Application.Services.Shared;

public abstract class CrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto, TIRepository>
    : ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto>
    where TModel : class, IModel
    where TIRepository : ICrudRepository<TModel>
    where TGetDto : ModelDto
    where TUpdateDto : ModelDto
{
    protected readonly TIRepository Repository;
    protected readonly IMapper Mapper;

    public CrudService(TIRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public virtual async Task<Guid> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken)
    {

        var model = Mapper.Map<TModel>(createDto);

        return await Repository.AddAsync(model, cancellationToken);
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await Repository.DeleteAsync(id, cancellationToken);
    }

    public virtual async Task<ReturnPageDto<TGetLightDto>> GetAllAsync(FilterPaginationDto dto,
        CancellationToken cancellationToken)
    {
        var filterModel = Mapper.Map<FilterPagination>(dto);

        var page = await Repository.GetAllAsync(filterModel, cancellationToken);
        return Mapper.Map<ReturnPageDto<TGetLightDto>>(page);
    }

    public virtual async Task<TGetDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<TGetDto>(await Repository.GetAsync(id, cancellationToken));

        return model;
    }

    public virtual async Task<ICollection<TGetDto?>> GetAllModelsByIdsAsync(List<Guid> ids,
        CancellationToken cancellationToken)
    {
        var models = Mapper.Map<ICollection<TGetDto?>>(await Repository.GetAllModelsByIdsAsync(ids, cancellationToken));

        return models;
    }


    public virtual async Task UpdateAsync(TUpdateDto dto, CancellationToken cancellationToken)
    {
        var model = Mapper.Map<TModel>(dto);

        await Repository.UpdateAsync(model, cancellationToken);
    }

    public TGetDto? Get(Guid id)
    {
        var model = Mapper.Map<TGetDto>(Repository.Get(id));
        return model;
    }

    public ICollection<TGetDto?> GetAllModelsByIds(List<Guid> ids)
    {
        var models = Mapper.Map<ICollection<TGetDto?>>(Repository.GetAllModelsByIds(ids));

        return models;
    }

    public async Task<TModel?> GetRawAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Repository.GetAsync(id, cancellationToken);
    }

    public TModel? GetRaw(Guid id)
    {
        return Repository.Get(id);
    }

    public async Task<ICollection<TModel?>> GetAllRawModelsByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
    {
        return await Repository.GetAllModelsByIdsAsync(ids, cancellationToken);
    }

    public ICollection<TModel?> GetAllRawModelsByIds(List<Guid> ids)
    {
        return Repository.GetAllModelsByIds(ids);
    }
}