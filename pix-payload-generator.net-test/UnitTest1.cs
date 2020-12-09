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
            var payload = new Payload("41703107802", 05.00m, "Um-Id-Qualquer", new Merchant { Name = "Alexandre Lima", City = "Presidente Prudente" });

            var stringToQrCode = payload.Generate();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }
    }
}
