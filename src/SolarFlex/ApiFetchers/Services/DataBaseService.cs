using ApiFetchers.Data;
using ApiFetchers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetchers.Services
{
    public class DataBaseService : IDataBaseService
    {
        private readonly DataContext _dbContext;

        public DataBaseService(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public async Task Create(SolarPowerRequest request, SolarPowerResult result)
        {
            foreach(var entry in result.Result)
            {
                var entity = new SolarPower
                {
                    Longitude = request.Localization.Longitude,
                    Lattitude = request.Localization.Lattitude,
                    Date = entry.Key,
                    SolarPowerValue = entry.Value
                };

                _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
