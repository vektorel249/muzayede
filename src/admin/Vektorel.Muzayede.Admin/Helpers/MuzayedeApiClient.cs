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

    public async Task<bool> Post<T>(string url, T model, CancellationToken cancellationToken)
    {
        var body = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, body, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        var content = response.Content.ReadAsStringAsync(cancellationToken);
        return true;
    }
}
