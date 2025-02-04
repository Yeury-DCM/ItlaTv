using ItlaTv.Domain.Repositories;
using ItlaTv.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace ItlaTv.Persistence.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual async Task<OperationResult> Add(TEntity entity)
        {
            OperationResult result = new();

            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
                result.Data = entity;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSucess = false;
            }

            return result;
        }

        public virtual async Task<OperationResult> Delete(TEntity entity)
        {
            OperationResult result = new();

            try
            {
                result.Data = (IQueryable<TEntity>) entity;
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                result.IsSucess = false;
                result.Message = ex.Message;
            }

            return result;

        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new();

            try
            {
                var data = await _entities.ToListAsync();
                result.Data = data;
            }
            catch(Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error: {ex}";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new();

            try
            {
                var data = await _entities.FindAsync(id);
                result.Data = data;

                if(data != null)
                {
                    result.IsSucess = false;
                    result.Message = "No se encontró la entidad";   
                }

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ($"Ocurrió un error: {ex}");
            }

            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new();

            try
            {
                _entities.Update(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                result.IsSucess = false;
                result.Message = ($"Ocurrió un error: {ex}");
            }

            return result;
        }
    }
}
