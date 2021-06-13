namespace MasAPI.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int StreetNumber { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}