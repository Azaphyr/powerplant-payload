using Entities.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class Payload
    {
        [Required]
        public double load { get; set; }
        [Required]
        public Fuel Fuels { get; set; }
        [Required]
        public List<PowerPlant> PowerPlants { get; set; }

    }
}
