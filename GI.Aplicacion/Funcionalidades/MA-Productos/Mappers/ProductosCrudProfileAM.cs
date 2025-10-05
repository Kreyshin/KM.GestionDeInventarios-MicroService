using AutoMapper;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Response;
using GI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Productos.Mappers
{
    public class ProductosCrudProfileAM : Profile
    {
        public ProductosCrudProfileAM() {

            CreateMap<ProductoCrearRQ, ProductoEN>()
                .ForMember(dest => dest.C_Codigo, opt => opt.MapFrom(src => src.codigo))
                .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.C_Descripcion, opt => opt.MapFrom(src => src.descripcion))
                .ForMember(dest => dest.ID_Categoria, opt => opt.MapFrom(src => src.idCategoria))
                .ForMember(dest => dest.ID_UnidadMedida, opt => opt.MapFrom(src => src.idUnidadMedida))
                .ForMember(dest => dest.ID_Marca, opt => opt.MapFrom(src => src.idMarca))
                .ForMember(dest => dest.C_SKU, opt => opt.MapFrom(src => src.sku));


            CreateMap<ProductoActualizarRQ, ProductoEN>()
                         .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                         .ForMember(dest => dest.C_Descripcion, opt => opt.MapFrom(src => src.descripcion))
                         .ForMember(dest => dest.C_SKU, opt => opt.MapFrom(src => src.sku))
                         .ForMember(dest => dest.ID_Categoria, opt => opt.MapFrom(src => src.idCategoria))
                         .ForMember(dest => dest.ID_UnidadMedida, opt => opt.MapFrom(src => src.idUnidadMedida))
                         .ForMember(dest => dest.ID_Marca, opt => opt.MapFrom(src => src.idMarca))
                         .ForMember(dest => dest.ID_Estado, opt => opt.MapFrom(src => src.idEstado));

            CreateMap<ProductoEN, ProductoCrearRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
                .ForMember(dest => dest.idCategoria, opt => opt.MapFrom(src => src.ID_Categoria))
                .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.C_Categoria))
                .ForMember(dest => dest.idUnidadMedida, opt => opt.MapFrom(src => src.ID_UnidadMedida))
                .ForMember(dest => dest.unidadMedida, opt => opt.MapFrom(src => src.C_UnidadMedida))
                .ForMember(dest => dest.idMarca, opt => opt.MapFrom(src => src.ID_Marca))
                .ForMember(dest => dest.marca, opt => opt.MapFrom(src => src.C_Marca))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.C_SKU))
                ;

            CreateMap<ProductoEN, ProductoActualizarRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
                .ForMember(dest => dest.idCategoria, opt => opt.MapFrom(src => src.ID_Categoria))
                .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.C_Categoria))
                .ForMember(dest => dest.idUnidadMedida, opt => opt.MapFrom(src => src.ID_UnidadMedida))
                .ForMember(dest => dest.unidadMedida, opt => opt.MapFrom(src => src.C_UnidadMedida))
                .ForMember(dest => dest.idMarca, opt => opt.MapFrom(src => src.ID_Marca))
                .ForMember(dest => dest.marca, opt => opt.MapFrom(src => src.C_Marca))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.C_SKU))
                ;

            CreateMap<ProductoConsultarRQ, ProductoEN>()
                .ForMember(dest => dest.C_Codigo, opt => opt.MapFrom(src => src.codigo))
                .ForMember(dest => dest.C_Nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.ID_Categoria, opt => opt.MapFrom(src => src.idCategoria))
                .ForMember(dest => dest.ID_UnidadMedida, opt => opt.MapFrom(src => src.idUnidadMedida))
                .ForMember(dest => dest.ID_Marca, opt => opt.MapFrom(src => src.idMarca))
                .ForMember(dest => dest.ID_Estado, opt => opt.MapFrom(src => src.idEstado))
                .ForMember(dest => dest.C_SKU, opt => opt.MapFrom(src => src.sku));

            CreateMap<ProductoEN, ProductoBuscarPorIDRE>()
                 .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
                .ForMember(dest => dest.idCategoria, opt => opt.MapFrom(src => src.ID_Categoria))
                .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.C_Categoria))
                .ForMember(dest => dest.idUnidadMedida, opt => opt.MapFrom(src => src.ID_UnidadMedida))
                .ForMember(dest => dest.unidadMedida, opt => opt.MapFrom(src => src.C_UnidadMedida))
                .ForMember(dest => dest.idMarca, opt => opt.MapFrom(src => src.ID_Marca))
                .ForMember(dest => dest.marca, opt => opt.MapFrom(src => src.C_Marca))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.C_SKU));


            CreateMap<ProductoEN, ProductoConsultarRE>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.codigo, opt => opt.MapFrom(src => src.C_Codigo))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.C_Nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.C_Descripcion))
                .ForMember(dest => dest.idCategoria, opt => opt.MapFrom(src => src.ID_Categoria))
                .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.C_Categoria))
                .ForMember(dest => dest.idUnidadMedida, opt => opt.MapFrom(src => src.ID_UnidadMedida))
                .ForMember(dest => dest.unidadMedida, opt => opt.MapFrom(src => src.C_UnidadMedida))
                .ForMember(dest => dest.idMarca, opt => opt.MapFrom(src => src.ID_Marca))
                .ForMember(dest => dest.marca, opt => opt.MapFrom(src => src.C_Marca))
                .ForMember(dest => dest.idEstado, opt => opt.MapFrom(src => src.ID_Estado))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.C_Estado))
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.C_SKU));
            ;

        }

    }
}
