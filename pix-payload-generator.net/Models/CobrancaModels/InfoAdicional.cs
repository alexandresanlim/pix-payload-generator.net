using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pix_payload_generator.net.Models.CobrancaModels
{
    public class InfoAdicional
    {
        /// <summary>
        /// maxLength: 50
        /// Nome do campo.
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// maxLength: 200
        /// Dados do campo.
        /// </summary>
        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
