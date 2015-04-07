using AddressProcessing.Address.v1;

namespace AddressProcessing.Tests.TestDoubles
{
    internal class FakeMailShotService : IMailShot
    {
        internal int Counter { get; private set; }

        public void SendMailShot(string name, string address, string phone, string email)
        {
            Counter++;
        }
    }
}