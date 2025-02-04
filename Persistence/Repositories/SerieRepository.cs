using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Base;
using ItlaTv.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using Persistence.Context;

namespace ItlaTv.Persistence.Repositories
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        private ILogger _logger;

        public SerieRepository(ApplicationContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }


        public async override Task<OperationResult<Serie>> Add(Serie entity)
        {
            OperationResult<Serie> result = new();

            try
            {
                result = await base.Add(entity);
                result.Message = "Se agregó la serie exitosamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error agregando la serie: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult<Serie>> Delete(Serie entity)
        {
            OperationResult<Serie> result = new();

            try
            {
                result = await base.Delete(entity);
                result.Message = "Se la serie exitolsamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error eliminando la serie: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult<Serie>> Update(Serie entity)
        {
            OperationResult<Serie> result = new();

            try
            {
                result = await base.Update(entity);
                result.Message = "Se actualizó la serie exitosamente";

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error actualizando la serie: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult<Serie>> GetAll()
        {
            OperationResult<Serie> result = new();

            try
            {
                result = await base.GetAll();
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error obteniendo los géneros: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult<Serie>> GetById(int id)
        {
            OperationResult<Serie> result = new();

            try
            {
                result = await base.GetById(id);
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error obteniendo el género: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }
    }
}
