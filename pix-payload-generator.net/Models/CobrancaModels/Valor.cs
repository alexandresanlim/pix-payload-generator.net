using Newtonsoft.Json;

namespace pix_payload_generator.net.Models.CobrancaModels
{
    public class Valor
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonIgnore]
        public decimal ToDecimal => decimal.Parse(Original);

        [JsonIgnore]
        public string Display => ToDecimal.ToString("C");
    }
}
