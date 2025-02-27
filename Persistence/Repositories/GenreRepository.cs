﻿using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Base;
using ItlaTv.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Persistence.Context;

namespace ItlaTv.Persistence.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        ILogger _logger;

        public GenreRepository(ApplicationContext context, ILogger<SerieRepository> logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async override Task<OperationResult> Add(Genre entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Add(entity);
                result.Message = "Se agregó el género exitosamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error agregando el género: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task<OperationResult> Delete(Genre entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Delete(entity);
                result.Message = "Se eliminó el género exitosamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error eliminando el género: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

        public async override Task< OperationResult> Update(Genre entity)
        {
            OperationResult result = new();

            try
            {
                result = await base.Update(entity);
                result.Message = "Se actualizó el género exitosamente";

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error actualizando el género: {ex}";
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
                result.Message = $"Ocurrió un error obteniendo los géneros: {ex}";
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
                result.Message = $"Ocurrió un error obteniendo el género: {ex}";
                _logger.LogError(result.Message);
            }

            return result;
        }

    }
}
