using System;
using System.Collections.Generic;
using System.Text;

namespace pix_payload_generator.net
{
    public class Merchant
    {
        public Merchant(string _name, string _city)
        {
            Name = _name;
            City = _city;
        }

        /// <summary>
        /// Nome do titular da conta
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Cidade do titular da conta
        /// </summary>
        public string City { get; private set; }
    }
}
