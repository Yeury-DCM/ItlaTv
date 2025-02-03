using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Domain.Result
{
    public class OperationResult <TEntity> where TEntity : class
    {
        public OperationResult()
        {
            IsSucess = true;
        }

        public bool IsSucess { get; set; }
        public string? Message { get; set; }

        public TEntity? Data { get; set; }
    }
}
