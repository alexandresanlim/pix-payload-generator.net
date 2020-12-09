using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public class PayloadId
    {
        public static string PayloadFormatIndicator => "00";

        public static string MerchantAccountInfomation => "26";

        public static string MerchantAccountInfomationGui => "00";

        public static string MerchantAccountInfomationKey => "01";

        public static string MerchantAccountInformationDescription => "02";

        public static string MerchantCategoryCode => "52";

        public static string TransactionCurrency => "53";

        public static string TransactionAmount => "54";

        public static string CountryCode => "58";

        public static string MerchantName => "59";

        public static string MerchantCity => "60";

        public static string AdditionalFieldTemplate => "62";

        public static string AdditionalFieldTemplateTxId => "05";

        public static string CRC16 => "63";
    }
}
