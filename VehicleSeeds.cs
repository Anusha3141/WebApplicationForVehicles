using System;

namespace WebApplicationForVehicles.Data
{
    public class VehicleSeeds
    {
        public static IEnumerable<Vehicle> Vehicles => new List<Vehicle>
        {
            new Vehicle
            {
                Id = 1,
                Year = 2010,
                Make= "Honda",
                Model="Odyssey"
            },

            new Vehicle
            {
                Id = 2,
                Year = 2020,
                Make= "Tesla",
                Model="Model Y"
            }
        };

    }
}
