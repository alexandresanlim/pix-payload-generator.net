using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
