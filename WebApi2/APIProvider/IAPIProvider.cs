namespace WebApi2.APIProvider
{
    public interface IAPIProvider
    {
        T Get<T>(string resource);
    }
}
