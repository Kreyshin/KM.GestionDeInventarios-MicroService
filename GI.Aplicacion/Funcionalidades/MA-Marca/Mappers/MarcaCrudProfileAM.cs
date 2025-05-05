using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Response;
using GI.Dominio.Entidades;

namespace GI.Aplicacion.Funcionalidades.MA_Marca.Mappers
{
    public class MarcaCrudProfileAM : Profile
    {
        public MarcaCrudProfileAM()
        {
            CreateMap<MarcaCrearRQ, MarcaEN>()
           .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre));

            CreateMap<MarcaActualizarRQ, MarcaEN>()
                         .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))                         
                         .ForMember(dest => dest.B_Activo, opt => opt.MapFrom(src => src.activo));

          
            CreateMap<MarcaEN, MarcaCrearRE>()
             .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
             .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))

             .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
             .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado));


            CreateMap<MarcaEN, MarcaActualizarRE>()
              .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))

              .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
              .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
              ;



            CreateMap<MarcaConsultarRQ, MarcaEN>()
               .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))

               .ForMember(dest => dest.C_Estado, opt => opt.MapFrom(src => src.estado));

            CreateMap<MarcaEN, MarcaBuscarPorIDRE>()
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))

                .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;


            CreateMap<MarcaEN, MarcaConsultarRE>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
               .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))

               .ForMember(dest => dest.activo, opt => opt.MapFrom(src => src.B_Activo))
               .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
               ;
        }
    }
}
