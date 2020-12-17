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
        public decimal ToDecimal => Convert.ToDecimal(Original, new System.Globalization.CultureInfo("en-US"));
    }
}
