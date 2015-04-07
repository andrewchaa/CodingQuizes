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

        private const string TestInputFile = @"test_data\contacts.csv";

        [SetUp]
        public void SetUp()
        {
            _fakeMailShotService = new FakeMailShotService();
            _csvReader = new CsvReader(new CsvStreamReader());
        }

        [Test]
        public void Should_send_mail_using_mailshot_service()
        {
            var processor = new AddressFileProcessor(_fakeMailShotService, _csvReader);
            processor.Process(TestInputFile);

            const int recordCount = 229;
            Assert.That(_fakeMailShotService.Counter, Is.EqualTo(recordCount));
        }
    }
}