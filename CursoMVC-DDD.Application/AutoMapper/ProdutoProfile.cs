using AutoMapper;
using CursoMVC_DDD.Application.ViewModels;
using CursoMVC_DDD.Domain.Entities;

namespace CursoMVC_DDD.Application.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        private readonly IMapper _mapper;

        public ProdutoProfile(IMapper mapper)
        {
            _mapper = mapper;            
        }

        public ProdutoProfile()
        {            
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(destination => destination.Descricao,
                opt => opt.MapFrom(src => src.Descricao.ToString()));

            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(destination => destination.Descricao,
                opt => opt.MapFrom(src => src.Descricao));                
        }        
    }
}
