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

        public virtual async Task<OperationResult<TEntity>> Add(TEntity entity)
        {
            OperationResult<TEntity> result = new();

            try
            {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
                result.Data = (IQueryable<TEntity>)entity;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsSucess = false;
            }

            return result;
        }

        public virtual async Task<OperationResult<TEntity>> Delete(TEntity entity)
        {
            OperationResult<TEntity> result = new();

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

        public virtual async Task<OperationResult<TEntity>> GetAll()
        {
            OperationResult<TEntity> result = new();

            try
            {
                var data = await _entities.ToListAsync();
                result.Data = (IQueryable<TEntity>)data!;
            }
            catch(Exception ex)
            {
                result.IsSucess = false;
                result.Message = $"Ocurrió un error: {ex}";
            }

            return result;
        }

        public virtual async Task<OperationResult<TEntity>> GetById(int id)
        {
            OperationResult<TEntity> result = new();

            try
            {
                var data = await _entities.FindAsync(id);
                result.Data = (IQueryable<TEntity>)data!;

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

        public virtual async Task<OperationResult<TEntity>> Update(TEntity entity)
        {
            OperationResult<TEntity> result = new();

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
