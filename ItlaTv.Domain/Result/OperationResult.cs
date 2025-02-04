namespace ItlaTv.Domain.Result
{
    public class OperationResult 
    {
        public OperationResult()
        {
            IsSucess = true;
        }

        public bool IsSucess { get; set; }
        public string? Message { get; set; }

        public dynamic? Data { get; set; }
    }
}
