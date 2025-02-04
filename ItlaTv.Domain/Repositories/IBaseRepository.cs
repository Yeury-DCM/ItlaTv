using ItlaTv.Domain.Result;

namespace ItlaTv.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<OperationResult<TEntity>> Add(TEntity entity);
        Task<OperationResult<TEntity>> Update(TEntity entity);
        Task<OperationResult<TEntity>> Delete(TEntity entity);
        Task<OperationResult<TEntity>> GetAll();
        Task<OperationResult<TEntity>> GetByID(int id);  

    }
}
