using ApiFetchers.Models;

namespace ApiFetchers.Services
{
    public interface ISolarPowerService
    {
        Task<string> GetDataAsync(SolarPowerRequest parameters, CancellationToken ct);

    }
}
