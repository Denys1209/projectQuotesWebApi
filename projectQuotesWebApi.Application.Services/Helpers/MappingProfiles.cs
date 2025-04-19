using AutoMapper;
using projectQuotes.Application.Repositories.Shared;
using projectQuotes.Domain.ForFilter;
using projectQuotes.Domain.ForSort;
using projectQuotes.Domain.Models;
using projectQuotes.Domain.Models.Enteties;
using projectQuotes.Dtos.Dto.Models.Acts;
using projectQuotes.Dtos.Dto.Models.Authors;
using projectQuotes.Dtos.Dto.Models.Texts;
using projectQuotes.Dtos.Dto.Users;
using projectQuotes.Dtos.Shared;

namespace projectQuotesWebApi.Application.Services.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Shared
        CreateMap<FilterPaginationDto, FilterPagination>().ForMember(
            c => c.Filters,
            op => op.MapFrom(v => v.Filters)).ForMember(
            c => c.Sorts,
            op => op.MapFrom(v => v.Sorts));

        CreateMap<FilterDto, Filter>();

        CreateMap<SortDto, Sort>();

        CreateMap(typeof(PaginatedCollection<>), typeof(ReturnPageDto<>));

        //User
        CreateMap<User, GetUserDto>();


        CreateMap<User, UpdateUserDto>();

        CreateMap<UpdateUserDto, User>();

        CreateMap<UserRegistrationDto, User>()
            .ForMember(e => e.PasswordHash, op => op.MapFrom(e => e.Password));

        CreateMap<GetUserDto, User>();


        //Author
        CreateMap<Author, GetAuthorDto>();

        CreateMap< UpdateAuthorDto, Author>();

        CreateMap<CreateAuthorDto, Author>();

        //Text
        CreateMap<Text, GetTextDto>();

        CreateMap< UpdateTextDto, Text>();

        CreateMap<CreateTextDto, Text>();

        //Act
        CreateMap<Act, GetActDto>();

        CreateMap<UpdateActDto, Act>();

        CreateMap<CreateActDto, Act>();


    }
}
