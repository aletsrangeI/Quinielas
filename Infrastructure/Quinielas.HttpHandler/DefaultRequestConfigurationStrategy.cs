namespace Quinielas.HttpHandler;

public class DefaultRequestConfigurationStrategy : IRequestConfigurationStrategy
{
    public void ApplyConfiguration(HttpClient httpClient, Dictionary<string, string>? headers = null, object? authorization = null)
    {
        // Configuración predeterminada, no se agregan headers ni autorización
    }
}