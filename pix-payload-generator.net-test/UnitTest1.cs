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
            var payload = new Payload("41703107802", 00.50m, "Um-Id-Qualquer", new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.Generate();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }
    }
}
