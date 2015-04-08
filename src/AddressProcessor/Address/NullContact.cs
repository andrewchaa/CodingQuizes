namespace AddressProcessing.Address
{
    public class NullContact : Contact
    {
        public string Name { get; private set; }
        public AddressRecord Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public NullContact() : base(string.Empty, 
            new AddressRecord(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty), string.Empty, string.Empty) {}
    }
}