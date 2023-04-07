using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_payload_generator.net.Models.Attributes;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.Constants;
using pix_payload_generator.net.Models.PayloadModels;

namespace pix_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateStaticPayload()
        {
            var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");

            var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            var isValidBoolean = cobranca.IsValid();
            var isValidString = cobranca.IsValidString();

            isValidString.TryGetValue(Const.IS_VALID_KEY, out string isValidStringResult);

            Assert.IsTrue(isValidBoolean);
            Assert.AreEqual(bool.TrueString, isValidStringResult);
            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        [TestMethod]
        public void CreateDynamicPayload()
        {
            var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");

            var payload = cobranca.ToDynamicPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"), "qrcodes-pix.gerencianet.com.br/v2/b0e555d114fc48b9b37c1f6baa360adb");

            var stringToQrCode = payload.GenerateStringToQrCode();

            var isValidBoolean = cobranca.IsValid();
            var isValidString = cobranca.IsValidString();

            isValidString.TryGetValue(Const.IS_VALID_KEY, out string isValidStringResult);

            Assert.IsTrue(isValidBoolean);
            Assert.AreEqual(bool.TrueString, isValidStringResult);
            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        [TestMethod]
        public void CreateStaticPayloadWithOptinalInfo()
        {
            Cobranca cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1")
            {
                SolicitacaoPagador = "Informar cartão fidelidade",
                Valor = new Valor
                {
                    Original = "1.00"
                }
            };

            var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            var isValidBoolean = cobranca.IsValid();
            var isValidString = cobranca.IsValidString();

            isValidString.TryGetValue(Const.IS_VALID_KEY, out string isValidStringResult);

            Assert.IsTrue(isValidBoolean);
            Assert.AreEqual(bool.TrueString, isValidStringResult);
            Assert.IsFalse(string.IsNullOrWhiteSpace(stringToQrCode));
        }
    }
}
