using AutoMapper;
using FluentValidation;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Request;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Dtos.Response;
using GI.Aplicacion.Funcionalidades.MA_Almacenes.Interfaces;
using GI.Dominio.Comunes;
using GI.Dominio.Interfaces.Commands;
using GI.Dominio.Interfaces.Querys;
using GS.Aplicacion.Comunes.AuditoriaHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.Aplicacion.Funcionalidades.MA_Almacenes.CasosUso
{
    public class AlmacenCrudCU(
        IAlmacenesRepositorioQ almacenesRepositorioQ,
        IAlmacenesRepositorioC almacenesRepositorioC,
        IMapper mapper,
        ILogger<AlmacenCrudCU> logger,
        IAuditoriaHelp audiHelp,
        IValidator<AlmacenCrearRQ> validatorCrear
        ) : IAlmacenesCrudCU
    {

        private readonly IAlmacenesRepositorioQ _almacenesRepositorioQ = almacenesRepositorioQ;
        private readonly IAlmacenesRepositorioC _almacenesRepositorioC = almacenesRepositorioC;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<AlmacenCrudCU> _logger = logger;
        private readonly IAuditoriaHelp _audiHelp = audiHelp;
        private readonly IValidator<AlmacenCrearRQ> _validatorCrear = validatorCrear;

        public Task<SingleResponse<AlmacenActualizarRE>> Actualizar(AlmacenActualizarRQ rq)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<AlmacenBuscarPorIDRE>> BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<AlmacenConsultarRE>> Consultar(AlmacenConsultarRQ filtros)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<AlmacenCrearRE>> Crear(AlmacenCrearRQ almacen)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResponse<bool>> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
