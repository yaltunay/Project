namespace Project.Web.Core.Application.Services;

public interface IHttpService
{
    Task<T> GetAsync<T>(string url, string endpoint);
    Task<T> PostAsync<T>(string url, string endpoint, object data);
}
