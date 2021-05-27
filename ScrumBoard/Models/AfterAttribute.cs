using System;
using System.ComponentModel.DataAnnotations;

namespace ScrumBoard.Models {
    public class AfterAttribute : ValidationAttribute {
        public string OtherPropertyName { get; private set; }
        public AfterAttribute(string otherPropertyName) {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var other = validationContext.ObjectType.GetProperty(OtherPropertyName).GetValue(validationContext.ObjectInstance);

            if (value is DateTime dateTime && other is DateTime otherDateTime) {
                if (dateTime >= otherDateTime)
                    return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
