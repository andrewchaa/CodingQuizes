using System.Linq;
using AddressProcessing.Address;
using AddressProcessing.Contracts;
using AddressProcessing.CSV;
using Moq;
using NUnit.Framework;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class CsvReaderTests
    {
        private IReadCsv _csvReader;
        private Mock<IReadStream> _streamReader;

        [SetUp]
        public void SetUp()
        {
            _streamReader = new Mock<IReadStream>();
            _csvReader = new CsvReader(_streamReader.Object, new ContactParser());
        }

        [Test]
        public void Opening_csv_file_should_be_done_by_Stream_Reader()
        {
            //arrange
            const string fileName = "fileName";

            //act
            _csvReader.Open(fileName);

            //assert
            _streamReader.Verify(s => s.Open(fileName));
        }

        [Test]
        public void Read_successfully_split_tab_separated_line_into_two_columns()
        {
            //arrange
            const string column1 = "column1";
            const string column2 = "column2";
            _streamReader.Setup(s => s.ReadLine()).Returns(column1 + "\t" + column2);

            // act
            var contact = _csvReader.Read();

            // assert
            Assert.That(contact.Name, Is.EqualTo(column1));
            Assert.That(contact.Address, Is.EqualTo(column2));
        }

        [Test]
        public void Read_returns_empty_collection_given_null()
        {
            //arrange
            _streamReader.Setup(s => s.ReadLine()).Returns(null as string);

            // act
            var contact = _csvReader.Read();

            // assert
            Assert.That(contact, Is.AssignableTo<NullContact>());
        }

        [Test]
        public void Read_returns_empty_collection_given_empty_string()
        {
            //arrange
            _streamReader.Setup(s => s.ReadLine()).Returns(string.Empty);

            // act
            var contact = _csvReader.Read();

            // assert
            Assert.That(contact, Is.AssignableTo<NullContact>());
        }

        [Test]
        public void Close_closes_the_stream()
        {
            //arrange
            //act
            _csvReader.Close();

            //assert
            _streamReader.Verify(s => s.Close());
        }

        [Test]
        public void Test_string_split()
        {
            // arrange
            // act
            // assert
            Assert.That("aa".Split('\t').Length, Is.EqualTo(1));
            Assert.That("  ".Split('\t').Length, Is.EqualTo(1));
            Assert.That("".Split('\t').Length, Is.EqualTo(1));
        }
    }
}
