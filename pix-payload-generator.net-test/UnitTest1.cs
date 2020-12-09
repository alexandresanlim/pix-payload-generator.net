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
            var payload = new Payload("bee05743-4291-4f3c-9259-595df1307ba1", 10.00m, "Um-Id-Qualquer", new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.Generate();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }
    }
}
