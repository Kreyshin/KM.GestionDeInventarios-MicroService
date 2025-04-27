using AutoMapper;
using GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.TipoAlmacen.Dtos.Response;
using GI.Dominio.Entidades;

namespace GI.Aplicacion.Funcionalidades.TipoAlmacen.Mappers
{
    public class TipoAlmacenCrudProfileAM : Profile
    {
        public TipoAlmacenCrudProfileAM()
        {
            CreateMap<TipoAlmacenCrearRQ, TipoAlmacenEN>()
           .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
           .ForMember(dest => dest.C_Descripcion, opt => opt.MapFrom(src => src.descripcion));

            CreateMap<TipoAlmacenActualizarRQ, TipoAlmacenEN>()
                         .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                         .ForMember(dest => dest.C_Descripcion, opt => opt.MapFrom(src => src.descripcion))
                         .ForMember(dest => dest.B_Activo, opt => opt.MapFrom(src => src.activo));

          
            CreateMap<TipoAlmacenEN, TipoAlmacenCrearRE>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
             .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
             .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
             .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado));


            CreateMap<TipoAlmacenEN, TipoAlmacenActualizarRE>()
              .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
              .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
              .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
              .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
              ;



            CreateMap<TipoAlmacenConsultarRQ, TipoAlmacenEN>()
               .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
               .ForMember(dest => dest.C_Descripcion, opt => opt.MapFrom(src => src.descripcion))
               .ForMember(dest => dest.C_Estado, opt => opt.MapFrom(src => src.estado));

            CreateMap<TipoAlmacenEN, TipoAlmacenBuscarPorIDRE>()
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;


            CreateMap<TipoAlmacenEN, TipoAlmacenConsultarRE>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
               .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
               .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
               .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
               ;
        }
    }
}
