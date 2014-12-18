using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CloudNotes.ViewModels
{
    /// <summary>
    /// Represents the validation on string values.
    /// </summary>
    public class StringValuesAttribute : ValidationAttribute
    {
        private readonly string[] values;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValuesAttribute"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public StringValuesAttribute(params string[] values)
        {
            this.values = values;
        }

        /// <summary>
        /// Gets the valid values for the string representation.
        /// </summary>
        /// <value>
        /// The valid values.
        /// </value>
        public string[] Values
        {
            get { return values; }
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || values.Contains(value.ToString()))
                return ValidationResult.Success;
            return new ValidationResult("The provided value is invalid.");
        }
    }
}
