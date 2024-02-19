using AutoMapper;
using Quinielas.Application.DTO;
using Quinielas.Domain.Entities;

namespace Quinielas.Application.UseCases.Common.Mapping
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<IndiceCatalogo, IndiceCatalogoDTO>().ReverseMap();
            CreateMap<ContenidoCatalogo, ContenidoCatalogoDTO>().ReverseMap();
        }
    }
}
