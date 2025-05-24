using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Vektorel.Muzayede.Admin.Helpers;

public class MuzayedeApiClient
{
    private readonly HttpClient client;
    private readonly UserAgentInfo userAgentInfo;

    public MuzayedeApiClient(HttpClient client, UserAgentInfo userAgentInfo)
    {
        this.client = client;
        this.userAgentInfo = userAgentInfo;
        this.client.DefaultRequestHeaders.Add("ApiKey", "123");
        this.client.BaseAddress = new Uri("https://localhost:7088");
    }

    public async Task<R> Post<T, R>(string url, T model, CancellationToken cancellationToken)
    {
        var body = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        AddTokenIfExist(client, userAgentInfo);
        var response = await client.PostAsync(url, body, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return default(R);
        }
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<R>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<T> Get<T>(string url, CancellationToken cancellationToken)
    {
        AddTokenIfExist(client, userAgentInfo);
        var response = await client.GetAsync(url, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return default(T);
        }
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    private static void AddTokenIfExist(HttpClient client, UserAgentInfo userAgentInfo)
    {
        if (string.IsNullOrEmpty(userAgentInfo.Token))
        {
            return;
        }

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userAgentInfo.Token);
    }
}
