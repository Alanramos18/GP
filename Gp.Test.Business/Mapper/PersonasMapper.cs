using AutoMapper;
using Gp.Test.Api.DTO;
using Gp.Test.Entity;

namespace Gp.Test.Business.Mapper
{
    internal class PersonasMapper : Profile
    {
        public PersonasMapper() 
        {
            CreateMap<PersonasDTORequest, Personas>()
                .ForMember(
                    dest => dest.NombreCompleto,
                    opt => opt.MapFrom(src => $"{src.NombreCompleto}")
                )
                .ForMember(
                    dest => dest.Edad,
                    opt => opt.MapFrom(src => $"{src.Edad}")
                )
                .ForMember(
                    dest => dest.Domicilio,
                    opt => opt.MapFrom(src => $"{src.Domicilio}")
                )
                .ForMember(
                    dest => dest.Telefono,
                    opt => opt.MapFrom(src => $"{src.Telefono}")
                )
                .ForMember(
                    dest => dest.Profesion,
                    opt => opt.MapFrom(src => $"{src.Profesion}")
                )
                .ForMember(
                    dest => dest.Dni,
                    opt => opt.MapFrom(src => $"{src.Dni}")
                );

            CreateMap<Personas, PersonasDTOResponse>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.NombreCompleto,
                    opt => opt.MapFrom(src => $"{src.NombreCompleto}")
                )
                .ForMember(
                    dest => dest.Edad,
                    opt => opt.MapFrom(src => $"{src.Edad}")
                )
                .ForMember(
                    dest => dest.Domicilio,
                    opt => opt.MapFrom(src => $"{src.Domicilio}")
                )
                .ForMember(
                    dest => dest.Telefono,
                    opt => opt.MapFrom(src => $"{src.Telefono}")
                )
                .ForMember(
                    dest => dest.Profesion,
                    opt => opt.MapFrom(src => $"{src.Profesion}")
                )
                .ForMember(
                    dest => dest.Dni,
                    opt => opt.MapFrom(src => $"{src.Dni}")
                );
        }
    }
}
