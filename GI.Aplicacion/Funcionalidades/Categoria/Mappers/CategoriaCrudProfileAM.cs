using AutoMapper;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Response;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.Mappers
{
    public class CategoriaCrudProfileAM : Profile
    {
        public CategoriaCrudProfileAM() {

            CreateMap<CategoriaActualizarRQ, CategoriaEN>()
                    .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                    .ForMember(dest => dest.B_Activo, opt => opt.MapFrom(src => src.activo));

            CreateMap<CategoriaCrearRQ, CategoriaEN>()
             .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre));

           
            CreateMap<CategoriaEN, CategoriaCrearRE>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
             .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
             .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado));


            CreateMap<CategoriaEN, CategoriaActualizarRE>()
              .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
              .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
              .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
              ;



            CreateMap<CategoriaConsultarRQ, CategoriaEN>()
               .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
               .ForMember(dest => dest.C_Estado, opt => opt.MapFrom(src => src.estado));

            CreateMap<CategoriaEN, CategoriaBuscarPorIDRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;
        

            CreateMap<CategoriaEN, CategoriaConsultarRE>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
               .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
               .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
               ;

            
        }
    }
}
