using AllGaragem.Domain.Entities.Services.MZMSafeLink;
using AllGaragem.Domain.Interfaces.Services;
using System.Net.Http.Json;

namespace AllGaragem.Infrastructure.Services
{
    public class MZMSafelink : IMZMSafeLink
    {
        public Task<GenerateSafeLinkResponseDTO> GenerateSafeLink(string url)
        {
            HttpClient client = new();

            HttpResponseMessage response = client.PostAsJsonAsync(
                Environment.GetEnvironmentVariable("MZM_SAFELINK_URL"), new { url }).Result;

            GenerateSafeLinkResponseDTO responseDTO = new()
            {
                ShortenUrl = response.IsSuccessStatusCode ? response.Content.ReadFromJsonAsync<GenerateSafeLinkResponseDTO>().Result!.ShortenUrl : url
            };
            
            return Task.FromResult(responseDTO);
        }
    }
}
