using ApiFetchers.Models;
using ApiFetchers.Models.DTOs;
using ApiFetchers.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiFetchers.Functions
{
    public class SolarPowerFetcher
    {
        private readonly ILogger _logger;
        private readonly ISolarPowerService _solarPowerService;
        private readonly IDataBaseService _dbService;

        public SolarPowerFetcher(ILoggerFactory loggerFactory, ISolarPowerService solarPowerService, IDataBaseService dbService)
        {
            _logger = loggerFactory.CreateLogger<SolarPowerFetcher>();
            _solarPowerService = solarPowerService;
            _dbService = dbService;
        }

        [Function("SolarPowerFetcher")]
        public async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, CancellationToken ct)
        {
            _logger.LogInformation($"SolarPowerForecast function executed at: {DateTime.Now}");

            try
            {
                // dummy data
                SolarPowerRequest solarPowerParameters = new SolarPowerRequest
                {
                    Localization = new LocalizationDTO
                    {
                        Lattitude = 52,
                        Longitude = 12
                    },
                    Declination = 37,
                    Azimuth = 0,
                    ModulesPower = 5.67F
                };
                
                // Fetch Data
                var response = await _solarPowerService.GetDataAsync(solarPowerParameters, ct);
                var solarPowerResult = JsonConvert.DeserializeObject<SolarPowerResult>(response);
                // SaveData to db
                await Console.Out.WriteLineAsync("TEST");
                await _dbService.Create(solarPowerParameters, solarPowerResult);

            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error while executinng SolarPowerForecast function: {ex.Message}");
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"SolarPowerForecast function ended at: {DateTime.Now}");
                _logger.LogInformation($"Next function execution at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
