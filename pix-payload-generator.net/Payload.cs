using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public class Payload
    {
        /// <summary>
        /// Retorna um objeto pronto para ser gerado um payload para um QRCode ESTATICO
        /// </summary>
        /// <param name="_pixKey">Chave pix do recebedor</param>
        /// <param name="_amount">Valor total do pix</param>
        /// <param name="_txId">Identificado do pagamento</param>
        /// <param name="_merchant">Informações do titular da conta</param>
        /// <param name="_description">Uma descrição que aparecerá no momento do pagamento</param>
        public Payload(string _pixKey, string _txId, Merchant _merchant, decimal? _amount = null, string _description = "")
        {
            PixKey = _pixKey;
            Description = _description;
            Merchant = _merchant;
            TxId = _txId;
            Amount = _amount;
        }

        /// <summary>
        /// Retorna um objeto pronto para ser gerado um payload para um QRCode DINÂMICO
        /// </summary>
        /// <param name="_txId"></param>
        /// <param name="_merchant"></param>
        /// <param name="_amount"></param>
        /// <param name="_description"></param>
        public Payload(string _txId, Merchant _merchant, string _url, bool _uniquePayment, decimal? _amount = null, string _description = "")
        {
            Description = _description;
            Merchant = _merchant;
            TxId = _txId;
            Amount = _amount;
            Url = _url;
            UniquePayment = _uniquePayment;
        }

        /// <summary>
        /// Informações do comerciante
        /// </summary>
        public Merchant Merchant { get; private set; }

        /// <summary>
        /// Chave pix, se telefone colocar +55
        /// </summary>
        public string PixKey { get; private set; }

        /// <summary>
        /// Descrição que aparece no momento do pagamento
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id da transação
        /// </summary>
        public string TxId { get; private set; }

        /// <summary>
        /// Valor da transação, duas casas decimais, separadas por ponto e não tenha separação de milhar
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Url do payload dinâmico
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Define se o pagamento pode ser feito apenas uma vez
        /// </summary>
        public bool UniquePayment { get; private set; } = false;

        
    }
}
