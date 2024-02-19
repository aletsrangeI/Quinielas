using System.Net.Http.Headers;


namespace Quinielas.HttpHandler;
public class ApiSportConfiguration : IRequestConfigurationStrategy
{
    public void ApplyConfiguration(HttpClient httpClient, Dictionary<string, string>? headers = null, object? authorization = null)
    {
        if (headers != null)
        {
            foreach (var (key, value) in headers)
            {
                httpClient.DefaultRequestHeaders.Add(key, value);
            }
        }

        if (authorization == null)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-rapidapi-key", "905f4ab25b35bc38e997c54069b6b2f3");
        }
    }
}