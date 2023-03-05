using System;

namespace pix_payload_generator.net.Models.Attributes.Base
{
    public abstract class ValidationAttribute : Attribute
    {
        public string FailureMessage { get; set; }
        protected ValidationAttribute() : this("Propriedade não é válida.")
        {
        }
        protected ValidationAttribute(string failureMessage)
        {
            FailureMessage = failureMessage;
        }

        public abstract bool IsValid(object obj);
    }
}
