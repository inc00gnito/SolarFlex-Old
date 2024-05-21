using ApiFetchers.Models;
using Microsoft.Extensions.Logging;

namespace ApiFetchers.Services
{
    internal class SolarPowerService : ISolarPowerService
    {
        // readonly 
        private static string _requestPath = "estimate/watthours/day/";
        private readonly HttpClient _httpClient;
        private readonly ILogger<SolarPowerService> _logger;

        public SolarPowerService(HttpClient httpClient, ILogger<SolarPowerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<string> GetDataAsync(SolarPowerRequest parameters,  CancellationToken ct)
        {
            // fix this
            _requestPath += $"{parameters.Localization.Longitude}/{parameters.Localization.Lattitude}/{parameters.Declination}/{parameters.Azimuth}/{parameters.ModulesPower}";
            _logger.LogDebug($"Fetching data from API: {_requestPath} {_httpClient.BaseAddress}");

            HttpResponseMessage result = await _httpClient.GetAsync(_requestPath, ct);

            string resultContent = await result.Content.ReadAsStringAsync(ct);

            if (!result.IsSuccessStatusCode)
            {
                _logger.LogError($"Error fetching data. Got {result.StatusCode}. Reason: {result.ReasonPhrase}\nDetails: {resultContent}" ?? "Unknown reason.");

            }

            return resultContent;
        }
    }
}
