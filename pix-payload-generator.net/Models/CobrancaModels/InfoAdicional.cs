using Newtonsoft.Json;
using pix_payload_generator.net.Models.Attributes;
using pix_payload_generator.net.Models.Constants;
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
        [JsonProperty("nome"), MaxLenght(50, FailureMessage = Const.MAX_LENGHT_TITLE + "50")]
        public string Nome { get; set; }

        /// <summary>
        /// maxLength: 200
        /// Dados do campo.
        /// </summary>
        [JsonProperty("valor"), MaxLenght(200, FailureMessage = Const.MAX_LENGHT_TITLE + "200")]
        public string Valor { get; set; }
    }
}
