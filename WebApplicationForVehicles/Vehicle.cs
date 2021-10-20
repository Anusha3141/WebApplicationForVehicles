using System;
using System.Collections.Generic;
using static WebApplicationForVehicles.Controllers.SampleDataController;

namespace WebApplicationForVehicles.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
