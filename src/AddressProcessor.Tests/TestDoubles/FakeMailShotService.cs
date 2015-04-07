using AddressProcessing.Address.v2;

namespace AddressProcessing.Tests.TestDoubles
{
    internal class FakeMailShotService : IMailShot
    {
        internal int PostalMailShotCounter { get; private set; }
        internal int EmailMailShotCounter { get; private set; }
        internal int SmsMailShotCounter { get; private set; }

        public void SendPostalMailShot(string name, string address1, string town, string county, string country, string postCode)
        {
            PostalMailShotCounter++;
        }

        public void SendEmailMailShot(string name, string email)
        {
            EmailMailShotCounter++;
        }

        public void SendSmsMailShot(string name, string number)
        {
            SmsMailShotCounter++;
        }
    }
}