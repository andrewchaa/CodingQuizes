namespace AddressProcessing.Address
{
    public class Contact
    {
        public string Name { get; private set; }
        public AddressRecord Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, AddressRecord address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}