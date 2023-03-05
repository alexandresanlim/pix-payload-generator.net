using Newtonsoft.Json;
using System.Globalization;

namespace pix_payload_generator.net.Models.CobrancaModels
{
    public class Valor
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonIgnore]
        public decimal ToDecimal => decimal.Parse(Original, new CultureInfo("en-US"));

        [JsonIgnore]
        public string Display => ToDecimal.ToString("C");
    }
}
