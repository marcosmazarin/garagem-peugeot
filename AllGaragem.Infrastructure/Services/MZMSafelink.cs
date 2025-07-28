using AllGaragem.Domain.Interfaces.Services;
using System.Net.Http.Json;

namespace AllGaragem.Infrastructure.Services
{
    public class MZMSafelink : IMZMSafeLink
    {
        public Task<string> GenerateSafeLink(string url)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.PostAsJsonAsync(
                Environment.GetEnvironmentVariable("MZM_SAFELINK_URL"), 
                url).Result;

            if (!response.IsSuccessStatusCode)
                return Task.FromResult(url);

            return Task.FromResult(response.Content.ReadAsStringAsync().Result);
        }
    }
}
