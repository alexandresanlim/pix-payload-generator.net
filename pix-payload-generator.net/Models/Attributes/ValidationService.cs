using pix_payload_generator.net.Models.Attributes.Base;
using pix_payload_generator.net.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pix_payload_generator.net.Models.Attributes
{
    public static class ValidationService
    {
        public static bool IsValid<T>(this T obj)
        {
            var properties = typeof(T).GetProperties();

            var dic = new Dictionary<string, string>
            {
                { Const.IS_VALID_KEY, Boolean.TrueString }
            };

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes(false).OfType<ValidationAttribute>().ToList();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(prop.GetValue(obj)))
                        return false;
                }
            }

            return true;
        }

        public static IDictionary<string, string> IsValidString<T>(this T obj)
        {
            var properties = typeof(T).GetProperties();

            var dic = new Dictionary<string, string>
            {
                { Const.IS_VALID_KEY, Boolean.TrueString }
            };

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes(false).OfType<ValidationAttribute>().ToList();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(prop.GetValue(obj)))
                        dic.Add($"{prop.Name}", $"Erro: {attribute.FailureMessage}");
                }
            }

            if (dic.Count > 1)
            {
                dic[Const.IS_VALID_KEY] = Boolean.FalseString;
            }

            return dic;
        }
    }
}
