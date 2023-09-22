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
        /// <summary>
        /// Gets or sets the price of gas per MWh.
        /// </summary>
        [JsonPropertyName("gas(euro/MWh)")]
        public double GasEuroPerMWh { get; set; }
        /// <summary>
        /// Gets or sets the price of kerosine per MWh.
        /// </summary>
        [JsonPropertyName("kerosine(euro/MWh)")]
        public double KerosineEuroPerMWh { get; set; }
        /// <summary>
        /// Gets or sets the price of CO2 emissions allowances per ton.
        /// </summary>
        [JsonPropertyName("co2(euro/ton)")]
        public double CO2EuroPerTon { get; set; }
        /// <summary>
        /// Gets or sets the percentage of wind.
        /// </summary>
        [JsonPropertyName("wind(%)")]
        public double WindPercentage { get; set; }
    }
}
