using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Base;
using ItlaTv.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Context;

namespace ItlaTv.Persistence.Repositories
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        private ILogger _logger;
        private ApplicationContext _context;

        public SerieRepository(ApplicationContext context, ILogger<SerieRepository> logger) : base(context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
        }


        public async override Task<OperationResult> Add(Serie entity)
        {
            OperationResult result = new();

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

        public async override Task<OperationResult> Delete(Serie entity)
        {
            OperationResult result = new();

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

        public async override Task<OperationResult> Update(Serie entity)
        {
            OperationResult result = new();

            try
            {
                // Cargar la entidad actual desde la base de datos con las relaciones
                var existingSerie = await _context.Set<Serie>()
                    .Include(s => s.Genres)
                    .FirstOrDefaultAsync(s => s.ID == entity.ID);

                if (existingSerie == null)
                {
                    result.IsSucess = false;
                    result.Message = "La serie no existe.";
                    return result;
                }

                // Actualizar las propiedades de la serie
                existingSerie.Name = entity.Name;
                existingSerie.StudioID = entity.StudioID;
                existingSerie.Description = entity.Description;
                existingSerie.ImagePath = entity.ImagePath;
                existingSerie.VideoPath = entity.VideoPath;

                // Eliminar las relaciones actuales (si es necesario)
                existingSerie.Genres.Clear(); // Remover todos los géneros

                // Añadir las nuevas relaciones de géneros
                foreach (var genre in entity.Genres)
                {
                    if (!existingSerie.Genres.Any(g => g.ID == genre.ID))
                    {
                        existingSerie.Genres.Add(genre);
                    }
                }

                // Guardar los cambios
                await _context.SaveChangesAsync();

                result.IsSucess = true;
                result.Message = "Se actualizó la serie exitosamente";
            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error actualizando la serie: {ex.Message}";
                _logger.LogError(result.Message);
            }

            return result;
        }


        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new();

            try
            {
                var data = await _context.Set<Serie>().Include(s => s.Studio).Include(s => s.Genres).ToListAsync();

                result.Data = data;

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
                var data = await _context.Set<Serie>().Include(s => s.Studio).Include(s => s.Genres).FirstOrDefaultAsync(s => s.ID == id);
                result.Data = data;
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
