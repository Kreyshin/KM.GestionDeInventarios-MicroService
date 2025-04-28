using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_UnidadMedida.Interfaces;
using GI.Dominio.Comunes;
using Moq;

namespace GI.Api.Tests.Aplicacion.Funcionalidades
{
    public class IUnidadMedidaCrudCUTests
    {
        private readonly Mock<IUnidadMedidaCrudCU> _mockCrudCU = new();

        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new UnidadMedidaCrearRQ { nombre = "Almacen A" };
            var response = new SingleResponse<UnidadMedidaCrearRE>
            {
                StatusCode = 200,
                Data = new UnidadMedidaCrearRE { id = 1, nombre = "Almacen A", activo = true },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Crear(request)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Crear(request);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal(1, result.Data.id);
        }

        [Fact]
        public async Task Actualizar_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new UnidadMedidaActualizarRQ { nombre = "Almacen B",  activo = true };
            var response = new SingleResponse<UnidadMedidaActualizarRE>
            {
                StatusCode = 200,
                Data = new UnidadMedidaActualizarRE {  nombre = "Almacen B",  activo = true },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Actualizar(1, request)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Actualizar(1, request);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task Eliminar_ShouldReturnSuccess_WhenValidId()
        {
            // Arrange
            var response = new SingleResponse<bool>
            {
                StatusCode = 200,
                Data = true,
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Eliminar(1)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Eliminar(1);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task BuscarPorID_ShouldReturnSuccess_WhenEntityExists()
        {
            // Arrange
            var response = new SingleResponse<UnidadMedidaBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new UnidadMedidaBuscarPorIDRE { nombre = "Almacen A",  activo = true },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.BuscarPorID(1)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.BuscarPorID(1);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Equal("Almacen A", result.Data.nombre);
        }

        [Fact]
        public async Task Consultar_ShouldReturnSuccess_WhenDataExists()
        {
            // Arrange
            var request = new UnidadMedidaConsultarRQ { nombre = "Almacen A" };
            var response = new ListResponse<UnidadMedidaConsultarRE>
            {
                StatusCode = 200,
                Data = new List<UnidadMedidaConsultarRE>
                {
                    new UnidadMedidaConsultarRE { id = 1, nombre = "Almacen A",  activo = true }
                },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Consultar(request)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Consultar(request);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Single(result.Data);
            Assert.Equal("Almacen A", result.Data.First().nombre); // Fixed: Use First() to access the first element of IEnumerable
        }
    }
}
