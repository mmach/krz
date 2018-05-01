using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Tool.Import
{
    public class CSVParser
    {

        public List<string> GetHeaders(string filePath, string separator)
        {
            
            List<string> headers = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                var count = 0; 
                while (!reader.EndOfStream)
                {
                    if (count == 0)
                    {
                        var line = reader.ReadLine();
                        line = line.Remove(line.LastIndexOf(separator));
                        headers.AddRange(line.Split(new string[] { separator }, StringSplitOptions.None));
                    }
                    break;
                }
                reader.Close();
                
            }
            return headers;
        }



        public DataTable GetData(string filePath, string separator)
        {
            DataTable table = new DataTable();
            var headers = GetHeaders(filePath, separator);

            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            using (var reader = new StreamReader(filePath))
            {
                var count = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (count > 0)
                    {
                        line = line.Remove(line.LastIndexOf(separator));
                        var values = line.Split(new string[] { separator }, StringSplitOptions.None);
                        DataRow row = table.NewRow();

                        for (int i = 0; i < values.Count(); i++)
                        {
                            row[i] = values[i];
                        }
                        table.Rows.Add(row);
                    }
                    count++;
                }
            }
            return table;
        }


    }
}
