using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetchers.Models.DTOs
{
    [Keyless]
    public class LocalizationDTO
    {
        public float Longitude { get; set; }
        public float Lattitude { get; set; }
    }
}
