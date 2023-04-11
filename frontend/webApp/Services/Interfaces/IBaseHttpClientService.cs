namespace webApp.Services.Interfaces;

public interface IBaseHttpClientService<T> where T : class
{
    Task<T> SendGet<T>(string url);

    Task<IEnumerable<T>> SendGetAll<T>(string url);

    Task<T> SendPost<T>(string url, T? content);

    Task<IEnumerable<T>> SendPostAll<T>(string url, T? content);

    Task<T> SendPut<T>(string url, T? content);

    Task<IEnumerable<T>> SendPutAll<T>(string url, T? content);

    Task<T> SendDelete<T>(string url, T? content);

    Task<IEnumerable<T>> SendDeleteAll<T>(string url, T? content);

    Task<T> SendPatch<T>(string url, T? content);

    Task<IEnumerable<T>> SendPatchAll<T>(string url, T? content);
}