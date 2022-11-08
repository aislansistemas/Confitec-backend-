
namespace Confitec.Core.Helpers
{
    public class ResponseResult<T> where T : class
    {
        public ResponseResult(string message, bool isSucceeded, T data = null)
        {
            Menssage = message;
            IsSucceeded = isSucceeded;
            Data = data;
        }
              
        public string Menssage { get; set; }
        public bool IsSucceeded { get; set; }
        public T Data { get; set; }

    }
}
