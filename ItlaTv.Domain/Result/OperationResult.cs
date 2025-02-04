namespace ItlaTv.Domain.Result
{
    public class OperationResult <TEntity>
    {
        public OperationResult()
        {
            IsSucess = true;
        }

        public bool IsSucess { get; set; }
        public string? Message { get; set; }

        public IQueryable<TEntity>? Data { get; set; }
    }
}
