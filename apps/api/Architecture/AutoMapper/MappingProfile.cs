using AutoMapper;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;

namespace CaseEstudo1.Architecture.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sabor, SaborDTO>();
            CreateMap<CreatePizzaDTO, Pizza>();
            CreateMap<UpdatePizzaDTO, Pizza>();
            CreateMap<Pizza, PizzaResponseDTO>();

            CreateMap<CreateBebidaDTO, Bebida>();
            CreateMap<UpdateBebidaDTO, Bebida>();
            CreateMap<Bebida, BebidaDTO>();
            CreateMap<Bebida, BebidaComPrecosDTO>()
                .ForMember(dest => dest.Precos, opt => opt.MapFrom(src => src.Precos));

            CreateMap<CreatePrecoBebidaDTO, PrecoBebida>();
            CreateMap<PrecoBebida, PrecoBebidaDTO>();
        }
    }
}
