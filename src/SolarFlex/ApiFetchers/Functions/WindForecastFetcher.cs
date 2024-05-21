//using System;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Extensions.Logging;
//using SolarFlex.Models;
//using SolarFlex.Services;

//namespace ApiFetchers.Functions
//{
//    public class WindForecastFetcher
//    {
//        private readonly ILogger _logger;
//        private readonly IDataFetcher _dataFetcher;

//        public WindForecastFetcher(ILoggerFactory loggerFactory, IDataFetcher dataFetcher)
//        {
//            _logger = loggerFactory.CreateLogger<SolarPowerFetcher>();
//            _dataFetcher = dataFetcher;
//        }

//        //[Function("WindForecastFetcher")]
//        public async Task Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, CancellationToken ct)
//        {
//            _logger.LogInformation($"WindForecastFetcher function executed at: {DateTime.Now}");

//            try
//            {
//                // Get localization
//                var localization = new LocalizationDTO();
//                // Fetch Data
//                var result = await _dataFetcher.FetchDataAsync(localization, "WindForecastFetcher", ct);
//                _logger.LogInformation(result);
//                // Save to db

//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"There was an error while executinng WindForecastFetcher function: {ex.Message}");
//            }

//            if (myTimer.ScheduleStatus is not null)
//            {
//                _logger.LogInformation($"WindForecastFetcher function ended at: {DateTime.Now}");
//                _logger.LogInformation($"Next function execution at: {myTimer.ScheduleStatus.Next}");
//            }
//        }
//    }
//}
