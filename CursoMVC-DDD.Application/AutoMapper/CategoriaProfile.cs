using AutoMapper;
using CursoMVC_DDD.Application.ViewModels;
using CursoMVC_DDD.Domain.Entities;

namespace CursoMVC_DDD.Application.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>()
                .ForMember (destination => destination.Descricao,
                opt => opt.MapFrom(src => src.Descricao.ToString()));

            CreateMap<CategoriaViewModel, Categoria>()
                .ForMember(destination => destination.Descricao,
                opt => opt.MapFrom(src => src.Descricao));
        }
    }
}
