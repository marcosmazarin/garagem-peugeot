using AllGaragem.Domain.Entities.Services.MZMSafeLink;

namespace AllGaragem.Domain.Interfaces.Services
{
    public interface IMZMSafeLink
    {
        Task<GenerateSafeLinkResponseDTO> GenerateSafeLink(string url);
    }
}
