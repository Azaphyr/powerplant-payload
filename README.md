# Economic Dispatch Algorithm

This repository contains a simple implementation of an economic dispatch algorithm used in the energy sector. The economic dispatch problem involves optimizing the generation of power from various sources to meet the demand while minimizing costs.

## Problem Description

The economic dispatch problem can be summarized as follows:

- A power network consists of various types of power plants.
- Each power plant has specific characteristics, including efficiency, minimum and maximum power output, and fuel cost.
- The goal is to determine how much power each power plant should generate to meet the demand while minimizing the total cost.

## Features

- Calculation of economic dispatch based on fuel costs and efficiency of power plants.
- Consideration of wind energy availability when dispatching wind turbines.
- Incorporation of CO2 emissions cost 
- JSON input format for specifying load, fuel prices, power plant details, and wind percentage.

## Usage

To calculate the economic dispatch for a given scenario, you can provide input in JSON format. Here's an example of the input format:

```json
{
  "load": 480,
  "fuels": {
    "gas(euro/MWh)": 13.4,
    "kerosine(euro/MWh)": 50.8,
    "co2(euro/ton)": 20,
    "wind(%)": 60
  },
  "powerplants": [
    {
      "name": "gasfiredbig1",
      "type": "gasfired",
      "efficiency": 0.53,
      "pmin": 100,
      "pmax": 460
    },
    // ... (other power plant configurations)
  ]
}
```
API

POST /Productionplan: Calculate the economic dispatch based on the provided input.

Installation

To run this project locally, follow these steps:

   - Clone the repository
   - Have docker installed the project is to docker linux
   - Navigate to the project directory
   - Install dependencies: dotnet restore
   - Build the project: dotnet build
   - Run the project: dotnet run

Make sure you have .NET Core SDK installed on your system.****
