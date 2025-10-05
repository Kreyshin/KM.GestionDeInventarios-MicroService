using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Response;
using GI.Dominio.Entidades;

namespace GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Mappers
{
    public class UnidadMedidaCrudProfileAM : Profile
    {
        public UnidadMedidaCrudProfileAM()
        {
            CreateMap<UnidadMedidaCrearRQ, UnidadMedidaEN>()
           .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
           .ForMember(dest => dest.C_Codigo, opt => opt.MapFrom(src => src.codigo));

            CreateMap<UnidadMedidaActualizarRQ, UnidadMedidaEN>()
                         .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))                        
                         .ForMember(dest => dest.B_Activo, opt => opt.MapFrom(src => src.activo));

          
            CreateMap<UnidadMedidaEN, UnidadMedidaCrearRE>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))             
             .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
             .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado));


            CreateMap<UnidadMedidaEN, UnidadMedidaActualizarRE>()
              .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))              
              .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
              .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
              ;



            CreateMap<UnidadMedidaConsultarRQ, UnidadMedidaEN>()
               .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))               
               .ForMember(dest => dest.C_Estado, opt => opt.MapFrom(src => src.estado));

            CreateMap<UnidadMedidaEN, UnidadMedidaBuscarPorIDRE>()
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))                
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;


            CreateMap<UnidadMedidaEN, UnidadMedidaConsultarRE>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))               
               .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
               .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
               ;
        }
    }
}
