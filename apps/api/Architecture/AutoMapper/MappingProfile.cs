using AutoMapper;
using CaseEstudo1.Domain;
using CaseEstudo1.DTOs;

namespace CaseEstudo1.Architecture.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePizzaDTO, Pizza>();
            CreateMap<UpdatePizzaDTO, Pizza>();
            CreateMap<Pizza, PizzaResponseDTO>()
                .ForMember(dest => dest.NomeBorda, opt => opt.MapFrom(src => src.Borda != null ? src.Borda.Nome : null));

            CreateMap<Sabor, SaborDTO>();

            CreateMap<PedidoDTO, Pedido>();
            CreateMap<Pedido, PedidoResponseDTO>()
                .ForMember(dest => dest.NomePizza, opt => opt.MapFrom(src => src.Pizza.Nome))
                .ForMember(dest => dest.PrecoPizza, opt => opt.MapFrom(src => src.Pizza.Preco))
                .ForMember(dest => dest.NomeBebida, opt => opt.MapFrom(src => src.NomeBebida))
                .ForMember(dest => dest.PrecoBebida, opt => opt.MapFrom(src => src.PrecoBebida))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.PrecoTotal));

            CreateMap<Usuario, UsuarioResponseDTO>();
        }
    }
}