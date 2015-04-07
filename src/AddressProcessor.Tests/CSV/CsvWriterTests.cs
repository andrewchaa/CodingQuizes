using AddressProcessing.Contracts;
using AddressProcessing.CSV;
using Moq;
using NUnit.Framework;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class CsvWriterTests
    {
        private IWriteCsv _csvWriter;
        private Mock<IWriteStream> _streamWriter;

        [SetUp]
        public void SetUp()
        {
            _streamWriter = new Mock<IWriteStream>();
            _csvWriter = new CsvWriter(_streamWriter.Object);
        }

        [Test]
        public void Opening_csv_file_should_be_done_by_Stream_Writer()
        {
            //arrange
            const string fileName = "fileName";

            //act
            _csvWriter.Open(fileName);

            //assert
            _streamWriter.Verify(s => s.Open(fileName));
        }

        [Test]
        public void Write_writes_columns_as_tab_separated_line()
        {
            //arrange
            const string column1 = "column1";
            const string column2 = "column2";

            // act
            _csvWriter.Write(column1, column2);

            _streamWriter.Verify(s => s.WriteLine(column1 + '\t' + column2));
        }

        [Test]
        public void Close_closes_the_stream()
        {
            //arrange
            //act
            _csvWriter.Close();

            _streamWriter.Verify(s => s.Close());
        }

    }
}
