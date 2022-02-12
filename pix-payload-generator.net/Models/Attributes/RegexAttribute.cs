using pix_payload_generator.net.Models.Attributes.Base;
using System;
using System.Text.RegularExpressions;

namespace pix_payload_generator.net.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RegexAttribute : ValidationAttribute
    {
        public string Regex { get; }

        public RegexAttribute(string regex)
        {
            Regex = regex;
        }

        public override bool IsValid(object obj)
        {
            if(obj is string valueString)
            {
                var rx = new Regex(Regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return rx.IsMatch(valueString);
            }

            return true;
        }
    }
}
