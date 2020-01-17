namespace FFinder.Models
{
    public abstract class HttpResponseModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}