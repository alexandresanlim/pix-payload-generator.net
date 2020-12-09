using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public class Payload
    {
        public Payload(string _pixKey, decimal _amount, string _txId, Merchant _merchant, string _description = "")
        {
            PixKey = _pixKey;
            Description = _description;
            Merchant = _merchant;
            TxId = _txId;
            Amount = _amount;
        }

        /// <summary>
        /// Informações do comerciante
        /// </summary>
        public Merchant Merchant { get; set; }

        /// <summary>
        /// Chave pix, se telefone colocar +55
        /// </summary>
        public string PixKey { get; set; }

        /// <summary>
        /// Descrição que aparece no momento do pagamento
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id da transação
        /// </summary>
        public string TxId { get; set; }

        /// <summary>
        /// Valor da transação, duas casas decimais, separadas por ponto e não tenha separação de milhar
        /// </summary>
        public decimal Amount { get; set; }
    }
}
