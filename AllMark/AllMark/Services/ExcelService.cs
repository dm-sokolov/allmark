using System.Collections.Generic;
using System.IO;
using System.Text;
using AllMark.Services.Interfaces;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;

namespace AllMark.Services
{
    public class ExcelService : IExcelService
    {
        private readonly ExcelReaderConfiguration _excelConfig;

        public ExcelService()
        {
            _excelConfig = new ExcelReaderConfiguration
            {
                // Gets or sets the encoding to use when the input XLS lacks a CodePage
                // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
                // Default: cp1252 (XLS BIFF2-5 and CSV only)
                FallbackEncoding = Encoding.GetEncoding(1252),

                // Gets or sets an array of CSV separator candidates. The reader 
                // autodetects which best fits the input data. Default: , ; TAB | # 
                // (CSV only)
                AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' },

                // Gets or sets a value indicating whether to leave the stream open after
                // the IExcelDataReader object is disposed. Default: false
                LeaveOpen = false,

                // Gets or sets a value indicating the number of rows to analyze for
                // encoding, separator and field count in a CSV. When set, this option
                // causes the IExcelDataReader.RowCount property to throw an exception.
                // Default: 0 - analyzes the entire file (CSV only, has no effect on other
                // formats)
                AnalyzeInitialCsvRows = 0,
            };
        }

        public void ReadFile(Stream stream)
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream, _excelConfig))
            {
                var count = reader.FieldCount;
                var dataSet = reader.AsDataSet();
                if (dataSet.Tables.Count > 0)
                {
                    var table = dataSet.Tables[0];
                    var columns = table.Columns;
                    var rows = table.Rows;
                }
            }

        }

        public void ReadFiles(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var stream = file.OpenReadStream())
                {
                    ReadFile(stream);
                }
            }
        }
    }
}
