namespace pix_payload_generator.net.Models.PayloadModels
{
    public class Merchant
    {
        public Merchant(string _name, string _city)
        {
            Name = _name;

            //Pode ter no maximo o tamanho de 15.
            City = _city.Length >= 15 ? _city.Substring(0, 15) : _city;
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
