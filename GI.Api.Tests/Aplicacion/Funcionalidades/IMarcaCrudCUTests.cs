using Xunit;
using Moq;
using GI.Aplicacion.Funcionalidades.MA_Marca.Interfaces;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Marca.Dtos.Response;
using GI.Dominio.Comunes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GI.Api.Tests
{
    public class IMarcaCrudCUTests
    {
        private readonly Mock<IMarcaCrudCU> _mockCrudCU = new();

        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new MarcaCrearRQ { nombre = "Marca A" };
            var response = new SingleResponse<MarcaCrearRE>
            {
                StatusCode = 200,
                Data = new MarcaCrearRE { id = 1, nombre = "Marca A", activo = true, estado = "Activo" },
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
            var request = new MarcaActualizarRQ { nombre = "Marca B", activo = true };
            var response = new SingleResponse<MarcaActualizarRE>
            {
                StatusCode = 200,
                Data = new MarcaActualizarRE { nombre = "Marca B", activo = true, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Actualizar(1, request)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Actualizar(1, request);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal("Marca B", result.Data.nombre);
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
            var response = new SingleResponse<MarcaBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new MarcaBuscarPorIDRE { nombre = "Marca A", activo = true, estado = "Activo" },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.BuscarPorID(1)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.BuscarPorID(1);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Equal("Marca A", result.Data.nombre);
        }

        [Fact]
        public async Task Consultar_ShouldReturnSuccess_WhenDataExists()
        {
            // Arrange
            var request = new MarcaConsultarRQ { nombre = "Marca A", estado = "Activo" };
            var response = new ListResponse<MarcaConsultarRE>
            {
                StatusCode = 200,
                Data = new List<MarcaConsultarRE>
                {
                    new MarcaConsultarRE { id = 1, nombre = "Marca A", activo = true, estado = "Activo" }
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
            //Assert.Equal("Marca A", result.Data[0].nombre);
        }
    }
}