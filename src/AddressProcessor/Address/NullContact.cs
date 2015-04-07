namespace AddressProcessing.Address
{
    public class NullContact : Contact
    {
        public string Name { get; private set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public NullContact() : base(string.Empty, string.Empty, string.Empty, string.Empty) {}
    }
}