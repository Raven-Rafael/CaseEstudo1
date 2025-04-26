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

            CreateMap<PedidoDTO, Pedido>();
            CreateMap<PedidoItemDTO, PedidoItem>();

            CreateMap<Pedido, PedidoResponseDTO>();
            CreateMap<PedidoItem, PedidoItemResponseDTO>()
                .ForMember(dest => dest.NomePizza, opt => opt.MapFrom(src => src.Pizza != null ? src.Pizza.Nome : null))
                .ForMember(dest => dest.NomeBebida, opt => opt.MapFrom(src => src.Bebida != null ? src.Bebida.Nome : null))
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario))
                .ForMember(dest => dest.PrecoTotal, opt => opt.MapFrom(src => src.PrecoUnitario * src.Quantidade));

        }
    }
}
