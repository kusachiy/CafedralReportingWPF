using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Helpers
{   
    class FileLoader
    {
        public List<ImportWorkflowModel> ImportWorkflow()
        {
            List<ImportWorkflowModel> records;
            using (var reader = new StreamReader(".\\Data\\Input\\input.csv", Encoding.GetEncoding(1251), true))
            using (var csv = new CsvReader(reader, CultureInfo.GetCultureInfo("ru")))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var import = csv.GetRecords<ImportWorkflowModel>();
                var list = import.ToList();
                records = list;
            }
            return records;
        }  
    }
}
