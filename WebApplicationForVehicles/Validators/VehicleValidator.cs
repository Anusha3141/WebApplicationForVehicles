using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApplicationForVehicles.Models;

namespace WebApplicationForVehicles.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(message => message.Make).NotEmpty();
            RuleFor(message => message.Model).NotEmpty();
            RuleFor(message => message.Make).NotNull();
            RuleFor(message => message.Model).NotNull();
            RuleFor(message => message.Year).NotEmpty();
            RuleFor(message => message.Year).InclusiveBetween(1950, 2050);
        }
    }
}
