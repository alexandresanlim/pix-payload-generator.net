using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public static class PayloadExtention
    {
        public static string GetIndicator()
        {
            return GetValue(PayloadId.PayloadFormatIndicator, "01");
        }

        public static string GetMerchantAccountInformation(this PayloadBase payload)
        {
            var gui = GetValue(PayloadId.MerchantAccountInfomationGui, "br.gov.bcb.pix");

            var key = !string.IsNullOrEmpty(payload?.PixKey) ? GetValue(PayloadId.MerchantAccountInfomationKey, payload.PixKey) : "";

            var description = !string.IsNullOrEmpty(payload?.Description) ? GetValue(PayloadId.MerchantAccountInformationDescription, payload.Description) : "";

            //url do qrcode dinâmico
            var url = !string.IsNullOrEmpty(payload?.Url) ? GetValue(PayloadId.MerchantAccountInformationUrl, payload.Url) : "";

            return GetValue(PayloadId.MerchantAccountInfomation, gui + key + description + url);
        }

        public static string GetMerchantCategoryCode()
        {
            return GetValue(PayloadId.MerchantCategoryCode, "0000");
        }

        public static string GetTransationCurrency()
        {
            return GetValue(PayloadId.TransactionCurrency, "986");
        }

        public static string GetTransationAmount(this PayloadBase payload)
        {
            if (!payload.Amount.HasValue || !(payload.Amount.Value > 0))
                return "";

            return GetValue(PayloadId.TransactionAmount, payload.Amount.Value.ToString("G", System.Globalization.CultureInfo.InvariantCulture));
        }

        public static string GetCountryCode()
        {
            return GetValue(PayloadId.CountryCode, "BR");
        }

        public static string GetMerchantName(this PayloadBase payload)
        {
            return GetValue(PayloadId.MerchantName, payload.Merchant.Name);
        }

        public static string GetMerchantCity(this PayloadBase payload)
        {
            return GetValue(PayloadId.MerchantCity, payload.Merchant.City);
        }

        public static string GetAdditionalDataFieldTemplate(this PayloadBase payload)
        {
            var txidInfo = payload.TxId.Length > 25 ? payload.TxId.Substring(0, 25) : payload.TxId;

            var txid = GetValue(PayloadId.AdditionalFieldTemplateTxId, txidInfo);

            return GetValue(PayloadId.AdditionalFieldTemplate, txid);
        }

        public static string GetCrc16(string fullPaylod)
        {
            var paylodToCrc16 = fullPaylod + PayloadId.CRC16 + "04";

            var calc = Crc16.ComputeCRC(paylodToCrc16);

            return fullPaylod + GetValue(PayloadId.CRC16, calc);
        }

        public static string GetUniquePayment(this PayloadBase payload)
        {
            return payload.UniquePayment ? GetValue(PayloadId.PointOfInitiationMethod, "12") : "";
        }

        /// <summary>
        /// Adiciona o valor TAM do payload
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>id, tam, value</returns>
        public static string GetValue(string id, string value)
        {
            var length = value.Length < 10 ? ("0" + value.Length.ToString()) : value.Length.ToString();

            var r = id + length + value;

            return r;
        }

        public static string GenerateStringToQrCode(this PayloadBase payload)
        {
            var pgenerator =
               GetIndicator() +
               payload.GetUniquePayment() +
               payload.GetMerchantAccountInformation() +
               GetMerchantCategoryCode() +
               GetTransationCurrency() +
               payload.GetTransationAmount() +
               GetCountryCode() +
               payload.GetMerchantName() +
               payload.GetMerchantCity() +
               payload.GetAdditionalDataFieldTemplate()
               ;

            return GetCrc16(pgenerator);
        }
    }
}
