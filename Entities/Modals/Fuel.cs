using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Modals
{
    public class Fuel
    {

        [JsonPropertyName("gas(euro/MWh)")]
        [JsonProperty("gas(euro/MWh)")]
        public double GasEuroPerMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        [JsonProperty("kerosine(euro/MWh)")]
        public double KerosineEuroPerMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        [JsonProperty("co2(euro/ton)")]
        public double CO2EuroPerTon { get; set; }

        [JsonPropertyName("wind(%)")]
        [JsonProperty("wind(%)")]
        public double WindPercentage { get; set; }
    }
}
