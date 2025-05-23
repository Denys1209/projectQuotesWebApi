﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using projectQuotes.Domain.Models.Shared;
using projectQuotes.Dtos.ResponseDto;
using projectQuotes.Dtos.Shared;
using projectQuotes.SharedModels.Shared;
using projectQuotesWebApi.Application.Services.Shared;
using projectQuotesWebApi.Shared;
using Xunit;

namespace Anytour.IntegrationTests.shared;


public abstract class BaseCrudControllerTest<
    TGetDto,
    TUpdateDto,
    TCreateDto,
    TIService,
    TModel,
    TGetLightDto,
    TReturnPageDto,
    TController,
    TSharedModel
    >(IntegrationTestWebAppFactory factory) : BaseControllerTest(factory)
    where TModel : class, IModel
    where TUpdateDto : ModelDto
    where TGetDto : ModelDto
    where TReturnPageDto : ReturnPageDto<TGetLightDto>
    where TIService : ICrudService<TGetDto, TCreateDto, TUpdateDto, TModel, TGetLightDto>
    where TController : ICrudController<TUpdateDto, TCreateDto>
    where TSharedModel : SharedModelsBase, IShareModels<TCreateDto,TUpdateDto,TModel>

{

    protected abstract Task<TController> GetController(
       IServiceProvider alternativeServices);

    protected abstract IServiceCollection GetAllServices(IServiceCollection alternativeServices);

    protected virtual  TCreateDto GetCreateDtoSample() 
    {
        return TSharedModel.GetSampleCreateDto();
    }

    protected virtual TUpdateDto GetUpdateDtoSample() 
    {
        return TSharedModel.GetSampleUpdateDto();
    }

    protected virtual TModel GetModelSample()
    {
        return TSharedModel.GetSample(); 
    }

    protected virtual ICollection<TModel> GetCollectionOfModels(int howMany)
    {
        ICollection<TModel> models = new List<TModel>();
        for (var i = 0; i < howMany; ++i) models.Add(GetModelSample());
        return models;
    }

    protected virtual async Task MutationBeforeDtoCreation(TCreateDto createDto,
      IServiceProvider alternativeServices)
    {
    }

    protected virtual async Task MutationBeforeDtoUpdate(TUpdateDto updateDto,
         IServiceProvider alternativeServices)
    {
    }


    [Fact]
    public virtual async Task CrudController_Get_ReturnsNotFound()
    {


        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var controller = await GetController(serviceProvider);

        //Act

        var result = await controller.Get(new Guid(), CancellationToken);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<NotFoundResult>();
    }


    [Fact]
    public virtual async Task CrudController_GetAll_ReturnsReturnPageDto()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var controller = await GetController(serviceProvider);
        foreach (var _ in GetCollectionOfModels(10))
        {
            var modelDto = GetCreateDtoSample();
            await MutationBeforeDtoCreation(modelDto, serviceProvider);
            await controller.Create(modelDto, CancellationToken);
        }

        //Act

        var result = await controller.GetAll(FilterPaginationDto, CancellationToken) as OkObjectResult;


        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();

        var returnPageDto = result?.Value as TReturnPageDto;

        returnPageDto.Should().BeOfType<TReturnPageDto>();
    }


    [Fact]
    public virtual async Task CrudController_Create_ReturnsCreateResponseDto()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var controller = await GetController(serviceProvider);

        //Act
        var dtoSample = GetCreateDtoSample();
        await MutationBeforeDtoCreation(dtoSample, serviceProvider);
        var result = await controller.Create(dtoSample, CancellationToken) as OkObjectResult;

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        var createResponseDto = result?.Value as CreateResponseDto;
        createResponseDto.Should().BeOfType<CreateResponseDto>();
    }


    [Fact]
    public virtual async Task CrudController_Delete_ReturnsNoContent()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dto = GetCreateDtoSample();
        await MutationBeforeDtoCreation(dto, serviceProvider);
        var id = await serviceProvider.GetRequiredService<TIService>().CreateAsync(dto, CancellationToken);
        var controller = await GetController(serviceProvider);

        //Act
        var result = await controller.Delete(id, CancellationToken) as NoContentResult;

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<NoContentResult>();
    }


    [Fact]
    public virtual async Task CrudController_Get_ReturnsOkObjectResult()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var controller = await GetController(serviceProvider);

        var model = GetCreateDtoSample();
        await MutationBeforeDtoCreation(model, serviceProvider);
        var id = await serviceProvider.GetRequiredService<TIService>().CreateAsync(model, CancellationToken);

        //Act

        var result = await controller.Get(id, CancellationToken);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }


    [Fact]
    public virtual async Task CrudController_Put_ReturnsNoContent()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var controller = await GetController(serviceProvider);


        //Act

        var createDto = GetCreateDtoSample();
        await MutationBeforeDtoCreation(createDto, serviceProvider);
        var create =
            (await controller.Create(createDto, CancellationToken) as OkObjectResult)?.Value as CreateResponseDto;
        var updateDto = GetUpdateDtoSample();
        updateDto.Id = create?.Id ?? updateDto.Id;
        await MutationBeforeDtoUpdate(updateDto, serviceProvider);
        var result = await controller.Put(updateDto, CancellationToken);


        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<NoContentResult>();
    }


    [Fact]
    public virtual async Task CrudController_Put_ReturnBadRequest()
    {
        //Arrange
        var serviceCollection = new ServiceCollection();
        var services = GetAllServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var controller = await GetController(serviceProvider);


        //Act

        var createDto = GetCreateDtoSample();
        await MutationBeforeDtoCreation(createDto, serviceProvider);

        var updateDto = GetUpdateDtoSample();
        await MutationBeforeDtoUpdate(updateDto, serviceProvider);
        var result = await controller.Put(updateDto, CancellationToken);


        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<BadRequestObjectResult>();
    }
}
