using ApiFetchers.Models.DTOs;

namespace ApiFetchers.Models
{
    public class Wind
    {
        public int Id{ get; set; }
        public LocalizationDTO Localization { get; set; }

        public DateTime Date { get; set; }
        public float WindSpeed { get; set; }


    }
}
