using ItlaTv.Domain.Result;

namespace ItlaTv.Domain.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<OperationResult> Add(TEntity entity);
        Task<OperationResult> Update(TEntity entity);
        Task<OperationResult> Delete(TEntity entity);
        Task<OperationResult> GetAll();
        Task<OperationResult> GetById(int id);

    }
}
