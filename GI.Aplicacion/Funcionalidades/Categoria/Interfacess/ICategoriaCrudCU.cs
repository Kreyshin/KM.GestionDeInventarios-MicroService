using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Response;
using GI.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.Categoria.Interfacess
{
    public interface ICategoriaCrudCU
    {
        public Task<SingleResponse<CategoriaCrearRE>> Crear(CategoriaCrearRQ oRegistro);
        public Task<SingleResponse<CategoriaActualizarRE>> Actualizar(int id, CategoriaActualizarRQ oRegistro);
        public Task<SingleResponse<bool>> Eliminar(int id);
        public Task<ListResponse<CategoriaConsultarRE>> Consultar(CategoriaConsultarRQ oFiltro);
        public Task<SingleResponse<CategoriaBuscarPorIDRE>> BuscarPorID(int id);
    }
}
