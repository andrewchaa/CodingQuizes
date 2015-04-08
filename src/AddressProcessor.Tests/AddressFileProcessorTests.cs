using AddressProcessing.Address;
using AddressProcessing.CSV;
using AddressProcessing.Tests.TestDoubles;
using NUnit.Framework;

namespace AddressProcessing.Tests
{
    [TestFixture]
    public class AddressFileProcessorTests
    {
        private FakeMailShotService _fakeMailShotService;
        private CsvReader _csvReader;
        private AddressParser _addressParser;
        const int RecordCount = 229;

        private const string TestInputFile = @"test_data\contacts.csv";

        [SetUp]
        public void SetUp()
        {
            _fakeMailShotService = new FakeMailShotService();
            _csvReader = new CsvReader(new CsvStreamReader());
            _addressParser = new AddressParser();
        }

        [Test]
        public void Should_send_postal_email_and_sms_mails_using_mailshot_service()
        {
            var processor = new AddressFileProcessor(_fakeMailShotService, _csvReader, _addressParser);
            processor.Process(TestInputFile);

            Assert.That(_fakeMailShotService.PostalMailShotCounter, Is.EqualTo(RecordCount));
            Assert.That(_fakeMailShotService.EmailMailShotCounter, Is.EqualTo(RecordCount));
            Assert.That(_fakeMailShotService.SmsMailShotCounter, Is.EqualTo(RecordCount));
        }

    }
}