using webApp.Services.Interfaces;
using webApp.Helpers;
using webApp.Configurations;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;

namespace webApp.Services;

public class BaseHttpClientService<T> : BaseRestService, IBaseHttpClientService<T>  where T : class
{

    private readonly HttpClient _client;

    private readonly IConfiguration _configuration;

    private readonly ApiConfig _api;
    public BaseHttpClientService(HttpClient client, IConfiguration configuration): base(client)
    {        
        _configuration = configuration;
        client.BaseAddress = new Uri(_configuration.GetValue<string>("Api:Url"));
        _client = client;       
    }

    public async Task<T> SendGet<T>(string url)
    {
        var response = await _client.GetAsync(url);

        return await response.ReadContentAsync<T>();    
    }

    public async Task<IEnumerable<T>> SendGetAll<T>(string url)
    {
        var response = await _client.GetAsync(url);

        return await response.ReadContentAsync<IEnumerable<T>>();  
    }

    public async Task<T> SendPost<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Post,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Post,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<T>();
    }

    public async Task<IEnumerable<T>> SendPostAll<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Post,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Post,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<IEnumerable<T>>();
    }

    public async Task<T> SendPut<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Put,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Put,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<T>();
    }

    public async Task<IEnumerable<T>> SendPutAll<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Put,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Put,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<IEnumerable<T>>();
    }

    public async Task<T> SendDelete<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<T>();
    }

    public async Task<T> SendDelete<T>(string url)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                                   url) ;

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<T>();
    }

    public async Task<IEnumerable<T>> SendDeleteAll<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Delete,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<IEnumerable<T>>();
    }

    public async Task<T> SendPatch<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Patch,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Patch,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<T>();
    }

    public async Task<IEnumerable<T>> SendPatchAll<T>(string url, T? content)
    {
        HttpRequestMessage requestMessage = null;

        requestMessage = new HttpRequestMessage(HttpMethod.Patch,
                                   url) ;

        if(content != null){
            requestMessage = new HttpRequestMessage(HttpMethod.Patch,
                                   url) 
                                   { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
        }

        var response = await _client.SendAsync(
            requestMessage    
        );

        return await response.ReadContentAsync<IEnumerable<T>>();
    }
}