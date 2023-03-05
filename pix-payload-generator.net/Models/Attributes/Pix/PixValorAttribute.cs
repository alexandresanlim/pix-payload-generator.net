using pix_payload_generator.net.Models.Attributes.Base;
using pix_payload_generator.net.Models.CobrancaModels;
using System;
using System.Text.RegularExpressions;

namespace pix_payload_generator.net.Models.Attributes.Pix
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PixValorAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if(obj is Valor pixValor && !string.IsNullOrWhiteSpace(pixValor?.Original))
            {
                var rx = new Regex(@"\d{1,10}\.\d{2}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return rx.IsMatch(pixValor.Original);
            }

            return true;
        }
    }
}
