using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_payload_generator.net;

namespace pix_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatePayload()
        {
            var payload = new Payload("41703107802", "Pagamento do pedido 123456", "William Costa", "SAO PAULO", 00.50m, "WDEV1234");

            var pgenerator = 
                payload.GetIndicator() + 
                payload.GetMerchantAccountInformation() +
                payload.GetMerchantCategoryCode() +
                payload.GetTransationCurrency() +
                payload.GetTransationAmount() +
                payload.GetCountryCode() +
                payload.GetMerchantName() +
                payload.GetMerchantCity() +
                payload.GetAdditionalDataFieldTemplate()
                ;


            var ab = payload.GetCrc16(pgenerator);
        }
    }
}
