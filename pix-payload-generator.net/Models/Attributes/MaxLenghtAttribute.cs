using pix_payload_generator.net.Models.Attributes.Base;
using System;

namespace pix_payload_generator.net.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxLenghtAttribute : ValidationAttribute
    {
        public int MaxLenght { get; }

        public MaxLenghtAttribute(int maxLenght)
        {
            MaxLenght = maxLenght;
        }

        public override bool IsValid(object value)
        {
            if (value is string valueString)
                return valueString.Length <= MaxLenght;

            if (value is int valueInt)
                return valueInt <= MaxLenght;

            return true;
        }
    }
}
