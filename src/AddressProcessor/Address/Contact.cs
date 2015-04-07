namespace AddressProcessing.Address
{
    public class Contact
    {
        public string Name { get; private set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Contact(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}