using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Base;
using ItlaTv.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using Persistence.Context;

namespace ItlaTv.Persistence.Repositories
{
    public class StudioRepository : BaseRepository<Studio>, IStudioRepository
    {
        private ILogger _logger;

        public StudioRepository(ApplicationContext context, ILogger<SerieRepository> logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async override Task<OperationResult> Add(Studio entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Add(entity);
                result.Message = "Se agregó la productora exitosamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error agregando la serie: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult> Delete(Studio entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Delete(entity);
                result.Message = "Se eliminó la productora exitolsamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error eliminando la productora: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult> Update(Studio entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Update(entity);
                result.Message = "Se actualizó la productora exitosamente";

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error actualizando la productora: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new();

            try
            {
                result = await base.GetAll();
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error obteniendo las productoras: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult> GetById(int id)
        {
            OperationResult result = new();

            try
            {
                result = await base.GetById(id);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error obteniendo la productora: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }
    }
}
