using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Interfaces;
using GI.Dominio.Comunes;
using Moq;

namespace GI.Api.Tests.Aplicacion.Funcionalidades
{
    public class IAlmacenCrudCUTests
    {
        private readonly Mock<IAlmacenesCrudCU> _mockCrudCU = new();

        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            var request = new AlmacenCrearRQ { codigo = "ALM001", nombre = "Almacen A", direccion = "Av. Lima 123", idTipoAlmacen = 1, ubigeo = "150101" };
            var response = new SingleResponse<AlmacenCrearRE>
            {
                StatusCode = 200,
                Data = new AlmacenCrearRE { id = 1, codigo = "ALM001", nombre = "Almacen A", idEstado = 1, estado = "Activo" },
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
            var request = new AlmacenActualizarRQ { nombre = "Almacen B", direccion = "Av. Arequipa 456" };
            var response = new SingleResponse<AlmacenActualizarRE>
            {
                StatusCode = 200,
                Data = new AlmacenActualizarRE { id = 1, nombre = "Almacen B", idEstado = 1, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Actualizar(1, request)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Actualizar(1, request);

            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal("Almacen B", result.Data.nombre);
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
            var response = new SingleResponse<AlmacenBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new AlmacenBuscarPorIDRE { id = 1, codigo = "ALM001", nombre = "Almacen A", estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.BuscarPorID(1)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.BuscarPorID(1);

            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Equal("Almacen A", result.Data.nombre);
        }

        [Fact]
        public async Task Consultar_ShouldReturnSuccess_WhenDataExists()
        {
            var request = new AlmacenConsultarRQ { nombre = "Almacen A" };
            var response = new ListResponse<AlmacenConsultarRE>
            {
                StatusCode = 200,
                Data = new List<AlmacenConsultarRE>
                {
                    new AlmacenConsultarRE { id = 1, codigo = "ALM001", nombre = "Almacen A", estado = "Activo" }
                },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Consultar(request)).ReturnsAsync(response);

            var result = await _mockCrudCU.Object.Consultar(request);

            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Single(result.Data);
            Assert.Equal("Almacen A", ((List<AlmacenConsultarRE>)result.Data)[0].nombre);
        }
    }
}
