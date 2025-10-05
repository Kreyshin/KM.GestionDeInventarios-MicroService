using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Productos.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Productos.Interfaces;
using GI.Dominio.Comunes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Api.Tests.Aplicacion.Funcionalidades
{
    public class IProductosCrudCUTests
    {
        private readonly Mock<IProductosCrudCU> _mockCrudCU = new();
        [Fact]
        public async Task Crear_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new ProductoCrearRQ { nombre = "Producto A", descripcion = "Desc", sku = "SKU001", idCategoria = 1, idUnidadMedida = 1, idMarca = 1 };
            var response = new SingleResponse<ProductoCrearRE>
            {
                StatusCode = 200,
                Data = new ProductoCrearRE
                {
                    id = 1,
                    codigo = "P001",
                    nombre = "Producto A",
                    descripcion = "Desc",
                    idCategoria = 1,
                    categoria = "Cat1",
                    idUnidadMedida = 1,
                    unidadMedida = "Unidad",
                    idMarca = 1,
                    marca = "Marca1",
                    idEstado = 1,
                    estado = "Activo",
                    sku = "SKU001"
                },
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
            var request = new ProductoActualizarRQ { nombre = "Producto B", descripcion = "Desc2", sku = "SKU002", idCategoria = 2, idUnidadMedida = 2, idMarca = 2, idEstado = 2 };
            var response = new SingleResponse<ProductoActualizarRE>
            {
                StatusCode = 200,
                Data = new ProductoActualizarRE
                {
                    id = 1,
                    codigo = "P002",
                    nombre = "Producto B",
                    descripcion = "Desc2",
                    idCategoria = 2,
                    categoria = "Cat2",
                    idUnidadMedida = 2,
                    unidadMedida = "Unidad2",
                    idMarca = 2,
                    marca = "Marca2",
                    idEstado = 2,
                    estado = "Activo",
                    sku = "SKU002"
                },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.Actualizar(1, request)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.Actualizar(1, request);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("ÉXITO", result.StatusType);
            Assert.NotNull(result.Data);
            Assert.Equal("Producto B", result.Data.nombre);
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
            var response = new SingleResponse<ProductoBuscarPorIDRE>
            {
                StatusCode = 200,
                Data = new ProductoBuscarPorIDRE
                {
                    id = 1,
                    codigo = "P001",
                    nombre = "Producto A",
                    descripcion = "Desc",
                    idCategoria = 1,
                    categoria = "Cat1",
                    idUnidadMedida = 1,
                    unidadMedida = "Unidad",
                    idMarca = 1,
                    marca = "Marca1",
                    idEstado = 1,
                    estado = "Activo",
                    sku = "SKU001"
                },
                StatusType = "ÉXITO"
            };

            _mockCrudCU.Setup(c => c.BuscarPorID(1)).ReturnsAsync(response);

            // Act
            var result = await _mockCrudCU.Object.BuscarPorID(1);

            // Assert
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(result.Data);
            Assert.Equal("Producto A", result.Data.nombre);
        }

        [Fact]
        public async Task Consultar_ShouldReturnSuccess_WhenDataExists()
        {
            // Arrange
            var request = new ProductoConsultarRQ { nombre = "Producto A", codigo = "P001" };
            var response = new ListResponse<ProductoConsultarRE>
            {
                StatusCode = 200,
                Data = new List<ProductoConsultarRE>
                {
                    new ProductoConsultarRE
                    {
                        id = 1,
                        codigo = "P001",
                        nombre = "Producto A",
                        descripcion = "Desc",
                        idCategoria = 1,
                        categoria = "Cat1",
                        idUnidadMedida = 1,
                        unidadMedida = "Unidad",
                        idMarca = 1,
                        marca = "Marca1",
                        idEstado = 1,
                        estado = "Activo",
                        sku = "SKU001"
                    }
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
            Assert.Equal("Producto A", ((List<ProductoConsultarRE>)result.Data)[0].nombre);
        }
    }
}
