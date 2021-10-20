using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForVehicles.Data;
using WebApplicationForVehicles.Models;

namespace WebApplicationForVehicles.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IValidator<Vehicle> vehicleValidator;

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        // GET api/SampleData/Vehicles?startDateIndex=
        [HttpGet("[action]")]
        public IEnumerable<Vehicle> Vehicles(int startDateIndex)
        {
            return VehicleSeeds.Vehicles;
        }

        // GET api/SampleData/Vehicles/id
        [HttpGet("{id}")]
        public IEnumerable<Vehicle> Get(int id)
        {
            return VehicleSeeds.Vehicles.Where(v => v.Id == id);
        }

        // POST api/vehicles
        [HttpPost]
        public async Task<ActionResult<VehicleSubmissionResponse>> PostAsync([FromBody] Vehicle vehicle)
        {
            try
            {
                await vehicleValidator.ValidateAsync(vehicle);
            }
            catch (ValidationException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            VehicleSubmissionResponse vsr = new VehicleSubmissionResponse();
            // Implementation for post goes here
            return vsr;
        }

        // PUT api/vehicles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string vehicle)
        {
            throw new NotImplementedException();
        }

        // DELETE api/vehicles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
