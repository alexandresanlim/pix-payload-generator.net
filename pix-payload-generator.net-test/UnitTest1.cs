using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_payload_generator.net;

namespace pix_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateStaticPayload()
        {
            var payload = new Payload(
                "bee05743-4291-4f3c-9259-595df1307ba1",
                "Um-Id-Qualquer",
                new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        [TestMethod]
        public void CreateStaticPayloadWithOptinalInfo()
        {
            var payload = new Payload(
                "bee05743-4291-4f3c-9259-595df1307ba1",
                "Um-Id-Qualquer",
                new Merchant("Alexandre Lima", "Presidente Prudente"))
            {
                Amount = 15.00m,
                Description = "Pagamento do pedido X"
            };

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }
    }
}
