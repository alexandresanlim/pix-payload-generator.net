using pix_payload_generator.net.Models.PayloadModels;

namespace pix_payload_generator.net.Models.CobrancaModels
{
    public static class CobrancaExtention
    {
        public static Payload ToPayload(this Cobranca cobranca, string txId, Merchant merchant)
        {
            return new StaticPayload(cobranca.Chave, txId, merchant, cobranca?.Valor?.Original, cobranca?.SolicitacaoPagador);
        }

        public static Payload ToDynamicPayload(this Cobranca cobranca, string txId, Merchant merchant, string url, bool uniquePayment = true)
        {
            return new DynamicPayload(txId, merchant, url, uniquePayment, cobranca?.Valor?.Original, cobranca?.SolicitacaoPagador);
        }
    }
}
