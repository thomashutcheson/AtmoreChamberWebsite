using System.ComponentModel;

namespace AtmoreChamber.Models
{
    public class Address
    {
        [DisplayName("Address Line")]
        public string AddressLine1 { get; set; }

        [DisplayName("City")]
        public string Locality { get; set; }

        [DisplayName("State")]
        public string AdministrativeDistrictLevel1 { get; set; }

        [DisplayName("Zip code")]
        public int PostalCode { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }
    }
}