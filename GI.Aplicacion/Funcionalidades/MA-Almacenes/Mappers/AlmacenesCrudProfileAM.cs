using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Dominio.Entidades;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.Mappers
{
    public class AlmacenesCrudProfileAM : Profile
    {
        public AlmacenesCrudProfileAM()
        {
            CreateMap<AlmacenCrearRQ, AlmacenEN>()
                .ForMember(dest => dest.C_Codigo, opt => opt.MapFrom(src => src.codigo))
                .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.C_Direccion, opt => opt.MapFrom(src => src.direccion))
                .ForMember(dest => dest.ID_TipoAlmacen, opt => opt.MapFrom(src => src.idTipoAlmacen))
                .ForMember(dest => dest.C_Ubigeo, opt => opt.MapFrom(src => src.ubigeo))
                .ForMember(dest => dest.C_Telefono, opt => opt.MapFrom(src => src.telefono))
                .ForMember(dest => dest.C_Latitud, opt => opt.MapFrom(src => src.latitud))
                .ForMember(dest => dest.C_Longitud, opt => opt.MapFrom(src => src.longitud));


            CreateMap<AlmacenActualizarRQ, AlmacenEN>()
                         .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                         .ForMember(dest => dest.C_Direccion, opt => opt.MapFrom(src => src.direccion))
                         .ForMember(dest => dest.ID_TipoAlmacen, opt => opt.MapFrom(src => src.idTipoAlmacen))
                         .ForMember(dest => dest.C_Ubigeo, opt => opt.MapFrom(src => src.ubigeo))
                         .ForMember(dest => dest.C_Telefono, opt => opt.MapFrom(src => src.telefono))
                         .ForMember(dest => dest.C_Latitud, opt => opt.MapFrom(src => src.latitud))
                         .ForMember(dest => dest.C_Longitud, opt => opt.MapFrom(src => src.longitud))
                         .ForMember(dest => dest.ID_Estado, opt => opt.MapFrom(src => src.idEstado));

            CreateMap<AlmacenEN, AlmacenCrearRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.direccion, opt => opt.MapFrom(src => src.C_Direccion))
                .ForMember(dest => dest.idTipoAlmacen, opt => opt.MapFrom(src => src.ID_TipoAlmacen))
                .ForMember(dest => dest.tipoAlmacen, opt => opt.MapFrom(src => src.C_TipoAlmacen))
                .ForMember(dest => dest.ubigeo, opt => opt.MapFrom(src => src.C_Ubigeo))
                .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.C_Telefono))
                .ForMember(dest => dest.latitud, opt => opt.MapFrom(src => src.C_Latitud))
                .ForMember(dest => dest.longitud, opt => opt.MapFrom(src => src.C_Longitud))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;

            CreateMap<AlmacenEN, AlmacenActualizarRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.direccion, opt => opt.MapFrom(src => src.C_Direccion))
                .ForMember(dest => dest.idTipoAlmacen, opt => opt.MapFrom(src => src.ID_TipoAlmacen))
                .ForMember(dest => dest.tipoAlmacen, opt => opt.MapFrom(src => src.C_TipoAlmacen))
                .ForMember(dest => dest.ubigeo, opt => opt.MapFrom(src => src.C_Ubigeo))
                .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.C_Telefono))
                .ForMember(dest => dest.latitud, opt => opt.MapFrom(src => src.C_Latitud))
                .ForMember(dest => dest.longitud, opt => opt.MapFrom(src => src.C_Longitud))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;

            CreateMap<AlmacenConsultarRQ, AlmacenEN>()
                .ForMember(dest => dest.C_Codigo, opt => opt.MapFrom(src => src.codigo))
                .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.C_Direccion, opt => opt.MapFrom(src => src.direccion))
                .ForMember(dest => dest.ID_TipoAlmacen, opt => opt.MapFrom(src => src.idTipoAlmacen))
                .ForMember(dest => dest.C_Ubigeo, opt => opt.MapFrom(src => src.ubigeo))
                .ForMember(dest => dest.ID_Estado, opt => opt.MapFrom(src => src.idEstado));

            CreateMap<AlmacenEN, AlmacenBuscarPorIDRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.direccion, opt => opt.MapFrom(src => src.C_Direccion))
                .ForMember(dest => dest.idTipoAlmacen, opt => opt.MapFrom(src => src.ID_TipoAlmacen))
                .ForMember(dest => dest.tipoAlmacen, opt => opt.MapFrom(src => src.C_TipoAlmacen))
                .ForMember(dest => dest.ubigeo, opt => opt.MapFrom(src => src.C_Ubigeo))
                .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.C_Telefono))
                .ForMember(dest => dest.latitud, opt => opt.MapFrom(src => src.C_Latitud))
                .ForMember(dest => dest.longitud, opt => opt.MapFrom(src => src.C_Longitud))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado));


            CreateMap<AlmacenEN, AlmacenConsultarRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.direccion, opt => opt.MapFrom(src => src.C_Direccion))
                .ForMember(dest => dest.tipoAlmacen, opt => opt.MapFrom(src => src.C_TipoAlmacen))
                .ForMember(dest => dest.ubigeo, opt => opt.MapFrom(src => src.C_Ubigeo))
                .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.C_Telefono))
                .ForMember(dest => dest.latitud, opt => opt.MapFrom(src => src.C_Latitud))
                .ForMember(dest => dest.longitud, opt => opt.MapFrom(src => src.C_Longitud))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                ;

        }
    }
}
