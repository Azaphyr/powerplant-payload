using Entities.DTO;
using Entities.Modals;

namespace powerplant_payload.Calculation
{
    public static class Dispatch
    {
        public static List<GenerationPlan> EconomicDispatch(Payload payload, List<PowerPlant> meritOrder, double windEnergyAvailable) 
        {
            var load = payload.load;
            var generationPlan = new List<GenerationPlan>();

            if (windEnergyAvailable > 0)
            {
                foreach (var plant in meritOrder)
                {
                    if (plant.Type == "windturbine" && windEnergyAvailable > 0)
                    {
                        var windGeneration = Math.Min(windEnergyAvailable, plant.Pmax);

                        generationPlan.Add(new GenerationPlan 
                        { 
                            Name = plant.Name, 
                            Power = windGeneration
                        });

                        windEnergyAvailable -= windGeneration;
                        load -= windGeneration;
                    }
                }
            }

            // Dispatch other power plants to meet the remaining load
            foreach (var plant in meritOrder)
            {
                if (plant.Type != "windturbine")
                {
                    var maxGeneration = Math.Min(plant.Pmax, load);
                    var cost = GetFuelCost(payload.Fuels, plant) * maxGeneration; // Use the GetFuelCost method
                    generationPlan.Add(new GenerationPlan {
                        Name = plant.Name, 
                        Power = maxGeneration 
                    });
                    load -= maxGeneration;
                }
            }
            
            return generationPlan;
        }

        public static double GetTotalWindCapacity(List<PowerPlant> powerPlants)
        {
            // Calculate the total wind capacity from wind turbines
            return powerPlants
                .Where(plant => plant.Type == "windturbine")
                .Sum(plant => plant.Pmax);
        }


        public static double GetFuelCost(Fuel fuels, PowerPlant plant)
        {
            switch (plant.Type)
            {
                case "gasfired":
                    var fuelCost = fuels.GasEuroPerMWh / plant.Efficiency;
                    // Calculate CO2 cost based on emissions
                    var co2Cost = fuels.CO2EuroPerTon * (fuelCost / fuels.GasEuroPerMWh);
                    return fuelCost + co2Cost;
                case "turbojet":
                    var kerosineCost = fuels.KerosineEuroPerMWh / plant.Efficiency;
                    // Calculate CO2 cost based on emissions
                    var co2KerosineCost = fuels.CO2EuroPerTon * (kerosineCost / fuels.KerosineEuroPerMWh);
                    return kerosineCost + co2KerosineCost;
                default:
                    return 0; // Wind turbines have zero fuel cost
            }
        }
    }
}
