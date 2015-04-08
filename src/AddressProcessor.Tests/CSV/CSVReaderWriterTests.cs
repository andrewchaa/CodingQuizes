using AddressProcessing.Address;
using AddressProcessing.Contracts;
using AddressProcessing.CSV;
using Moq;
using NUnit.Framework;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class CSVReaderWriterTests
    {
        private IReadCsv _csvReader;
        private Mock<IWriteCsv> _csvWriter;
        private CSVReaderWriter _csvReaderWriter;
        private Mock<IReadStream> _csvStreamReader;
        const string FileName = "fileName";

        [SetUp]
        public void SetUp()
        {
            _csvStreamReader = new Mock<IReadStream>();
            _csvReader = new CsvReader(_csvStreamReader.Object);
            _csvWriter = new Mock<IWriteCsv>();
            _csvReaderWriter = new CSVReaderWriter(_csvReader, _csvWriter.Object);
        }

        [Test]
        public void Opening_csv_file_for_read_should_be_done_by_reader()
        {
            //arrange

            //act
            _csvReaderWriter.Open(FileName, Mode.Read);

            //assert
            _csvStreamReader.Verify(s => s.Open(FileName));
        }

        [Test]
        public void Opening_csv_file_for_write_should_be_done_by_writer()
        {
            //arrange

            //act
            _csvReaderWriter.Open(FileName, Mode.Write);

            //assert
            _csvWriter.Verify(s => s.Open(FileName));
        }

        [Test]
        public void Read_should_call_Readers_read()
        {
            //arrange
            string col1;
            string col2;

            // act
            _csvReaderWriter.Read(out col1, out col2);

            // assert
            _csvStreamReader.Verify(c => c.ReadLine());
        }

        [Test]
        public void Write_should_call_Writers_write()
        {
            //arrange
            string col1 = "column 1";
            string col2 = "column 2";

            // act
            _csvReaderWriter.Write(col1, col2);

            // assert
            _csvWriter.Verify(c => c.Write(col1, col2));
        }

        [Test]
        public void Close_with_Mode_Read_closes_CsvReader()
        {
            //arrange
            _csvReaderWriter.Open(FileName, Mode.Read);

            //act
            _csvReaderWriter.Close();

            //assert
            _csvStreamReader.Verify(c => c.Close());
        }

        [Test]
        public void Close_with_Mode_Write_closes_CsvWriter()
        {
            //arrange
            _csvReaderWriter.Open(FileName, Mode.Write);

            //act
            _csvReaderWriter.Close();

            //assert
            _csvWriter.Verify(c => c.Close());
        }

    }
}
