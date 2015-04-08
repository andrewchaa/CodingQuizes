namespace AddressProcessing.Address
{
    // Ap #827-9064 Sapien. Rd.|Palo Alto|Fl.|HM0G 0YR|Cameroon
    public class AddressRecord
    {
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        public AddressRecord(string address, string city, string province, string postCode, string country, string name, string phone, string email)
        {
            Address = address;
            City = city;
            Province = province;
            PostCode = postCode;
            Country = country;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
