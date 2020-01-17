namespace FFinder.Models
{
    public class HttpResponseModelData<T>:HttpResponseModelSimple
    where T:class,new()
    {
        public T Data { get; set; }
    }
}