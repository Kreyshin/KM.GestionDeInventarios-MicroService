using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_TipoAlmacen.Interfaces;
using GI.Dominio.Comunes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Api.Tests.Aplicacion.Funcionalidades
{
    public class ITipoAlmacenCrudCUTests
    {
        private readonly Mock<ITipoAlmacenCrudCU> _mockCrudCU = new();

        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new TipoAlmacenCrearRQ { nombre = "Almacen A", descripcion = "Descripcion A" };
            var response = new SingleResponse<TipoAlmacenCrearRE>
            {
                StatusCode = 200,
                Data = new TipoAlmacenCrearRE { id = 1, nombre = "Almacen A", descripcion = "Descripcion A", activo = true },
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
            var request = new TipoAlmacenActualizarRQ { nombre = "Almacen B", descripcion = "Descripcion B", activo = true };
            var response = new SingleResponse<TipoAlmacenActualizarRE>
            {
                StatusCode = 200,
                Data = new TipoAlmacenActualizarRE {  nombre = "Almacen B", descripcion = "Descripcion B", activo = true },
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
            var response = new SingleResponse<TipoAlmacenBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new TipoAlmacenBuscarPorIDRE { nombre = "Almacen A", descripcion = "Descripcion A", activo = true },
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
            var request = new TipoAlmacenConsultarRQ { nombre = "Almacen A" };
            var response = new ListResponse<TipoAlmacenConsultarRE>
            {
                StatusCode = 200,
                Data = new List<TipoAlmacenConsultarRE>
                {
                    new TipoAlmacenConsultarRE { id = 1, nombre = "Almacen A", descripcion = "Descripcion A", activo = true }
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
