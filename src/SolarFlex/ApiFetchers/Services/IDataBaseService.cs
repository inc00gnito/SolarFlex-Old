using ApiFetchers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetchers.Services
{
    public interface IDataBaseService
    {
        Task Create(SolarPowerRequest request, SolarPowerResult result);
    }
}
