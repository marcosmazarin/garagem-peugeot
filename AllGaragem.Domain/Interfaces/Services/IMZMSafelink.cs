namespace AllGaragem.Domain.Interfaces.Services
{
    public interface IMZMSafeLink
    {
        Task<string> GenerateSafeLink(string url);
    }
}
