using webApp.Services.Interfaces;
using webApp.Helpers;
using Newtonsoft.Json;
using System.Text;

namespace webApp.Services;

public abstract class BaseRestService : IBaseRestService
{
    protected readonly HttpClient _client;
    public BaseRestService(HttpClient client)
    {        
        _client = client;
    }
}