using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApplicationForVehicles.Validators
{
    public static class IValidatorExtensions
    {
        /// <summary>
        /// Performs validation asynchronously and then throws an exception if validation fails.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator">The validator this method is extending.</param>
        /// <param name="model">The instance of the type we are validating.</param>
        /// <param name="ruleSet">Optional: a ruleset when need to validate against.</param>        
        public static async Task ValidateModelAndThrowAsync<T>(this IValidator<T> validator, T model, string ruleSet = null)
        {
            // Ensure model is not null.
            if (model == null)
            {
                throw new Exception("The request object is null.");
            }

            await validator.ValidateAsync(model, options => options.IncludeAllRuleSets().ThrowOnFailures());
        }
    }
}
