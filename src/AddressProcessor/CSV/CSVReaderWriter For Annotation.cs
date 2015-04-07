using System;
using System.IO;

namespace AddressProcessing.CSV
{
    public class CSVReaderWriterForAnnotation // Needs to implement an interface. Program to interface (abstraction)
    {
        // StreamReader and StreamWriter are dependencies. Do not instantiate them directly. 
        // Inject dependencies, so that you program to abstraction. Dipendency Inversion
        private StreamReader _readerStream = null; // no need to assign null. Member variables have null as default value
        private StreamWriter _writerCsvStream = null; // _streamReader, _streamWriter read better

        [Flags] // nice to have flats attribute
        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                _readerStream = File.OpenText(fileName);
                // adding return here would make this more readable.
                // avoid if, else if as much as possible
            }
            else if (mode == Mode.Write)
            {
                FileInfo fileInfo = new FileInfo(fileName); // use var, as you know the type already from "new FileInfo"
                _writerCsvStream = fileInfo.CreateText();
            }
            else
            {
                // as we use enum Mode, this will never happen.
                throw new Exception("Unknown file mode for " + fileName);
            }
        }

        public void Write(params string[] columns)
        {
            string outPut = "";

            for (int i = 0; i < columns.Length; i++) // use foreach for clarity
            {
                outPut += columns[i];
                if ((columns.Length - 1) != i)  // introduce a variable that reveals your intention. 
                {                               // ex) bool isLastColumn = i == columns.Length - 1 
                    outPut += "\t";             //     if (!isLastColumn)
                }
            }

            WriteLine(outPut);
        }

        public bool Read(string column1, string column2) // string column1 and column2 are never used.
        {                                                // This method doesn't do anything and can't be used. Remove this
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            string line; // use the declaration and assignment at the same place
            string[] columns; // use the declaration and assignment at the same place

            char[] separator = { '\t' };

            line = ReadLine();
            columns = line.Split(separator);

            if (columns.Length == 0)
            {
                column1 = null;
                column2 = null;

                return false;
            }
            else // no need of else, as the previous if rturns false
            {
                column1 = columns[FIRST_COLUMN];    // column1 and column2 would lose the assigned value once the method call finishes.
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        // This method only read the first two columns. 
        // As the example file has 4 columns, this looks like a bug.
        public bool Read(out string column1, out string column2)
        {
            const int FIRST_COLUMN = 0;
            const int SECOND_COLUMN = 1;

            // use the declaration and assignment at the same place
            string line;
            string[] columns;

            char[] separator = { '\t' };

            line = ReadLine();

            if (line == null)
            {
                column1 = null; 
                column2 = null; 

                return false;
            }

            columns = line.Split(separator);

            if (columns.Length == 0) // this actually doesn't happen even for empty string
            {
                column1 = null; // no need
                column2 = null;

                return false;
            } 
            else    // no need 
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        private void WriteLine(string line) // no need to have a method. just use _writerStream.WriteLine
        {
            _writerCsvStream.WriteLine(line);
        }

        private string ReadLine()  // no need to have a method. just use _readStream.ReadLine();
        {
            return _readerStream.ReadLine();
        }

        public void Close()
        {
            if (_writerCsvStream != null)
            {
                _writerCsvStream.Close();
            }

            if (_readerStream != null)
            {
                _readerStream.Close();
            }
        }
    }
}
