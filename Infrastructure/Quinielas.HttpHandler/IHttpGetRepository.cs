namespace Quinielas.HttpHandler;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
public interface IHttpGetRepository
{
    Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null, object? authorization = null);
}
