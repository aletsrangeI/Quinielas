namespace Quinielas.HttpHandler;
public interface IRequestConfigurationStrategy
{
    void ApplyConfiguration(HttpClient httpClient, Dictionary<string, string>? headers = null, object? authorization = null);
}