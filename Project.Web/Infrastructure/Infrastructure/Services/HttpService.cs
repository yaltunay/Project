using Newtonsoft.Json;
using Project.Web.Core.Application.Services;
using RestSharp;

namespace Project.Web.Infrastructure.Infrastructure.Services;

public class HttpService : IHttpService
{
    public async Task<T> GetAsync<T>(string url, string endpoint)
    {
        var client = new RestClient(url);

        var request = new RestRequest($"/{endpoint}", Method.Get);

        // İsteği gönder ve cevabı al
        var response = client.Execute(request);


        if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = JsonConvert.DeserializeObject<T>(response.Content);
            return content;
        } 

        return default;
    }

    public async Task<T> PostAsync<T>(string url, string endpoint, object data)
    {
        var client = new RestClient(url);

        var request = new RestRequest($"/{endpoint}", Method.Post);
        request.AddJsonBody(data);

        // İsteği gönder ve cevabı al
        var response = client.Execute(request);
        if (response.IsSuccessful && response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var content = JsonConvert.DeserializeObject<T>(response.Content);
            return content;
        }

        return default;
    }
}
