using ApiFetchers.Models.DTOs;
using System.Text.Json.Serialization;

namespace ApiFetchers.Models
{
    public class SolarPower
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public float Longitude { get; set; }
        public float Lattitude { get; set; }
        public DateTime Date{ get; set; }
        public string SolarPowerValue { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }

    public class SolarPowerResult
    {
        [JsonPropertyName("result")]
        public required Dictionary<DateTime, string> Result { get; set; }
    }

    public class SolarPowerRequest
    {
        public required LocalizationDTO Localization { get; set; }
        public required float Declination { get; set; }
        public required float Azimuth { get; set; }
        public required float ModulesPower { get; set; }
    }

}
