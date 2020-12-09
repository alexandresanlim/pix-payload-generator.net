using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public class Payload
    {
        public Payload(string _pixKey, string _description, string _merchantName, string _merchantCity, decimal _amount, string _txId)
        {
            PixKey = _pixKey;
            Description = _description;
            MerchantName = _merchantName;
            MerchantCity = _merchantCity;
            TxId = _txId;
            Amount = _amount;
        }

        public PayloadIdInformation Id => new PayloadIdInformation();

        /// <summary>
        /// Chave pix, se telefone colocar +55
        /// </summary>
        public string PixKey { get; set; }

        /// <summary>
        /// Descrição que aparece no momento do pagamento
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nome do titular da conta
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// Cidade do titular da conta
        /// </summary>
        public string MerchantCity { get; set; }

        /// <summary>
        /// Id da transação
        /// </summary>
        public string TxId { get; set; }

        /// <summary>
        /// Valor da transação, duas casas decimais, separadas por ponto e não tenha separação de milhar
        /// </summary>
        public decimal Amount { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>id, size, value</returns>
        public static string GetValue(string id, string value)
        {
            var length = value.Length < 10 ? ("0" + value.Length.ToString()) : value.Length.ToString();

            var r = id + length + value;

            return r;
        }

        public string GetCrc16(string fullPaylod)
        {
            var i = fullPaylod + Id.CRC16 + "04";

            //check sum e98f

            var r = Crc16.ComputeCRC(i);

            return fullPaylod + GetValue(Id.CRC16, r);
        }
    }

    public static class PayloadExtention
    {

        public static string GetIndicator(this Payload payload)
        {
            return Payload.GetValue(payload.Id.PayloadFormatIndicator, "01");
        }


        public static string GetMerchantAccountInformation(this Payload payload)
        {
            var a = Payload.GetValue(payload.Id.MerchantAccountInfomationGui, "br.gov.bcb.pix");

            var k = Payload.GetValue(payload.Id.MerchantAccountInfomationKey, payload.PixKey);

            var d = !string.IsNullOrEmpty(payload?.Description) ? Payload.GetValue(payload.Id.MerchantAccountInformationDescription, payload.Description) : "";

            return Payload.GetValue(payload.Id.MerchantAccountInfomation, a + k + d);
        }

        public static string GetMerchantCategoryCode(this Payload payload)
        {
            return Payload.GetValue(payload.Id.MerchantCategoryCode, "0000");
        }

        public static string GetTransationCurrency(this Payload payload)
        {
            return Payload.GetValue(payload.Id.TransactionCurrency, "986");
        }

        public static string GetTransationAmount(this Payload payload)
        {
            return Payload.GetValue(payload.Id.TransactionAmount, payload.Amount.ToString("G", System.Globalization.CultureInfo.InvariantCulture));
        }

        public static string GetCountryCode(this Payload payload)
        {
            return Payload.GetValue(payload.Id.CountryCode, "BR");
        }

        public static string GetMerchantName(this Payload payload)
        {
            return Payload.GetValue(payload.Id.MerchantName, payload.MerchantName);
        }

        public static string GetMerchantCity(this Payload payload)
        {
            return Payload.GetValue(payload.Id.MerchantCity, payload.MerchantCity);
        }

        public static string GetAdditionalDataFieldTemplate(this Payload payload)
        {
            var txid = Payload.GetValue(payload.Id.AdditionalFieldTemplateTxId, payload.TxId);

            return Payload.GetValue(payload.Id.AdditionalFieldTemplate, txid);
        }

        public static string GetCr16(string payload)
        {
            return "";


        }
    }

    public class PayloadIdInformation
    {
        public string PayloadFormatIndicator => "00";

        public string MerchantAccountInfomation => "26";

        public string MerchantAccountInfomationGui => "00";

        public string MerchantAccountInfomationKey => "01";

        public string MerchantAccountInformationDescription => "02";

        public string MerchantCategoryCode => "52";

        public string TransactionCurrency => "53";

        public string TransactionAmount => "54";

        public string CountryCode => "58";

        public string MerchantName => "59";

        public string MerchantCity => "60";

        public string AdditionalFieldTemplate => "62";

        public string AdditionalFieldTemplateTxId => "05";

        public string CRC16 => "63";
    }
}
