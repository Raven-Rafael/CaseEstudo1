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
            CreateMap<Pizza, PizzaResponseDTO>();
        }
    }
}
