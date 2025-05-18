using System.Text;
using System.Text.Json;

namespace Vektorel.Muzayede.Admin.Helpers;

public class MuzayedeApiClient
{
    private readonly HttpClient client;

    public MuzayedeApiClient(HttpClient client)
    {
        this.client = client;
        this.client.DefaultRequestHeaders.Add("ApiKey", "123");
        this.client.BaseAddress = new Uri("https://localhost:7088");
    }

    public async Task<R> Post<T, R>(string url, T model, CancellationToken cancellationToken)
    {
        var body = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, body, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return default(R);
        }
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<R>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
    }
}
