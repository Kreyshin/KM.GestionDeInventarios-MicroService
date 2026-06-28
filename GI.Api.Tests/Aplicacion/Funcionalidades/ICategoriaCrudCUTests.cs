using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Request;
using GI.Aplicacion.Funcionalidades.Categoria.Dtos.Response;
using GI.Aplicacion.Funcionalidades.Categoria.Interfacess;
using GI.Dominio.Comunes;
using Moq;

namespace GI.Api.Tests.Aplicacion.Funcionalidades
{
    public class ICategoriaCrudCUTests
    {
        private readonly Mock<ICategoriaCrudCU> _mockCrudCU = new();

        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            var request = new CategoriaCrearRQ { nombre = "Categoria A" };
            var response = new SingleResponse<CategoriaCrearRE>
            {
                StatusCode = 200,
                Data = new CategoriaCrearRE { id = 1, nombre = "Categoria A", activo = true, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Crear(request)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Crear(request);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal(1, result.Data.id);
        }

        [Fact]
        public async Task Actualizar_ShouldReturnSuccess_WhenValidRequest()
        {
            var request = new CategoriaActualizarRQ { nombre = "Categoria B", activo = true };
            var response = new SingleResponse<CategoriaActualizarRE>
            {
                StatusCode = 200,
                Data = new CategoriaActualizarRE { nombre = "Categoria B", activo = true, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Actualizar(1, request)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Actualizar(1, request);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal("Categoria B", result.Data.nombre);
        }

        [Fact]
        public async Task Eliminar_ShouldReturnSuccess_WhenValidId()
        {
            var response = new SingleResponse<bool>
            {
                StatusCode = 200,
                Data = true,
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Eliminar(1)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Eliminar(1);

            Assert.Equal(200, result.StatusCode);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task BuscarPorID_ShouldReturnSuccess_WhenEntityExists()
        {
            var response = new SingleResponse<CategoriaBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new CategoriaBuscarPorIDRE { id = 1, nombre = "Categoria A", activo = true, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.BuscarPorID(1)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.BuscarPorID(1);

            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Equal("Categoria A", result.Data.nombre);
        }

        [Fact]
        public async Task Consultar_ShouldReturnSuccess_WhenDataExists()
        {
            var request = new CategoriaConsultarRQ { nombre = "Categoria A" };
            var response = new ListResponse<CategoriaConsultarRE>
            {
                StatusCode = 200,
                Data = new List<CategoriaConsultarRE>
                {
                    new CategoriaConsultarRE { id = 1, nombre = "Categoria A", activo = true, estado = "Activo" }
                },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Consultar(request)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Consultar(request);

            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Single(result.Data);
            Assert.Equal("Categoria A", ((List<CategoriaConsultarRE>)result.Data)[0].nombre);
        }
    }
}
