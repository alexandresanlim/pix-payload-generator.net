using Newtonsoft.Json;
using pix_payload_generator.net.Models.Attributes;
using pix_payload_generator.net.Models.Attributes.Pix;
using pix_payload_generator.net.Models.Constants;
using System.Collections.Generic;

namespace pix_payload_generator.net.Models.CobrancaModels
{
    public class Cobranca
    {
        public Cobranca(string _chave)
        {
            Chave = _chave;
        }

        /// <summary>
        /// O campo chave, obrigatório, determina a chave Pix registrada no DICT que será utilizada para a cobrança. Essa chave será lida pelo aplicativo do PSP do pagador para consulta ao DICT, que retornará a informação que identificará o recebedor da cobrança.
        /// Os tipos de chave podem ser: telefone, e-mail, cpf/cnpj ou EVP.
        /// O formato das chaves pode ser encontrado na seção "Formatação das chaves do DICT no BR Code" do Manual de Padrões para iniciação do Pix: https://www.bcb.gov.br/estabilidadefinanceira/pix.
        /// /// </summary>
        [JsonProperty("chave"), MaxLenght(77, FailureMessage = Const.MAX_LENGHT_TITLE + "77")]
        public string Chave { get; set; }

        /// <summary>
        /// O campo solicitacaoPagador, opcional, determina um texto a ser apresentado ao pagador para que ele possa digitar uma informação correlata, em formato livre, a ser enviada ao recebedor. 
        /// Esse texto será preenchido, na pacs.008, pelo PSP do pagador, no campo RemittanceInformation . 
        /// O tamanho do campo na pacs.008 está limitado a 140 caracteres.
        /// </summary>
        [JsonProperty("solicitacaoPagador"), MaxLenght(140, FailureMessage = Const.MAX_LENGHT_TITLE + "140")]
        public string SolicitacaoPagador { get; set; }

        /// <summary>
        /// maximum: 50
        /// Cada respectiva informação adicional contida na lista(nome e valor) deve ser apresentada ao pagador.
        /// </summary>
        [JsonProperty("infoAdicionais")]
        public List<InfoAdicional> InfoAdicionais { get; set; }


        /// <summary>
        /// valores monetários referentes à cobrança.
        /// </summary>
        [JsonProperty("valor"), PixValor]
        public Valor Valor { get; set; }
    }
}
