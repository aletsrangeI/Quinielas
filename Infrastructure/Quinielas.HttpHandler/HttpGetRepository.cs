namespace Quinielas.HttpHandler;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class HttpGetRepository : IHttpGetRepository
{
    private readonly HttpClient _httpClient;
    private readonly IRequestConfigurationStrategy _requestConfigurationStrategy;

    public HttpGetRepository(HttpClient httpClient, IRequestConfigurationStrategy requestConfigurationStrategy)
    {
        _httpClient = httpClient;
        _requestConfigurationStrategy = requestConfigurationStrategy;
    }

    public async Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null, object? authorization = null)
    {
        _requestConfigurationStrategy.ApplyConfiguration(_httpClient, headers, authorization);

        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedObject = JsonConvert.DeserializeObject<T>(responseContent);
        return deserializedObject ?? throw new Exception("Deserialized object is null.");
    }
}