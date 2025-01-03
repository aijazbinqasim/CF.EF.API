using AutoMapper;
using CF.EF.API.Contracts;
using CF.EF.API.Models;

namespace CF.EF.API.Configs
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<AuthorModel, GetAuthorDto>()
                 .ReverseMap();

            CreateMap<PostAuthorDto, AuthorModel>()
                .ReverseMap();

            CreateMap<PutAuthorDto, AuthorModel>()
                .ReverseMap();
        }
    }
}
