using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JooBoxWorld.Models.Validations
{
    public class RSAIDNumber : ValidationAttribute, IClientValidatable
    {

        public RSAIDNumber() : base("This {0} is not a valid South African ID Number")
        {

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-rsaid", "Invalid RSA ID Number");
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "rsaid"
            };
            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Enter ID Number");
            }

            IdentityInfo idInfo = new IdentityInfo(value.ToString());

            if (!idInfo.IsValid)
            {
                return new ValidationResult("Invalid ID Number");
            }

            return ValidationResult.Success;
        }
    }
}
