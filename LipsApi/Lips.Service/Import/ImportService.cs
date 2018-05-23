using Lips.Repository.Import;
using Lips.Tool.Import;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lips.Service.Import
{
    public class ImportService : IImportService
    {
        private ImportRepository ImportRepository;
        private string FtpAddress;
        private string Login;
        private string Password;
        private string DownloadPath;
        private string CsvSeparator;


        public ImportService(string connectionString, string ftpAddress, string login, string password, string downloadPath, string csvSeparator)
        {
            ImportRepository = new ImportRepository(connectionString);
            FtpAddress = ftpAddress;
            Login = login;
            Password = password;
            DownloadPath = downloadPath;
            CsvSeparator = csvSeparator;
        }

        public void ImportFiles()
        {
            var results = GetLatestFiles();
            foreach (var fileName in results)
            {
                Download(fileName);
            }

            DBImport(results);
            Delete(results);
        }


        private void Delete(List<string> files)
        {
            foreach (var file in files)
            {
                File.Delete(Path.Combine(DownloadPath, file));
            }
        }

        private void DBImport(List<string> files)
        {
            CSVParser parser = new CSVParser();
            foreach (var file in files)
            {

                var headers = parser.GetHeaders(Path.Combine(DownloadPath, file), CsvSeparator);
                var data = parser.GetData(Path.Combine(DownloadPath, file), CsvSeparator);

                string datePattern = "20[0-9]*.CSV";
                var datePart = Regex.Match(file, datePattern).Value;
                var tableName = file.Replace(datePart, string.Empty);
                ImportRepository.CleanTable(tableName);
                ImportRepository.SaveData(headers, data, tableName);
            }
            ImportRepository.MergeData();

         /*   foreach (var file in files)
            {
                string datePattern = "20[0-9]*.CSV";
                var datePart = Regex.Match(file, datePattern).Value;
                var tableName = file.Replace(datePart, string.Empty);
                ImportRepository.CleanTable(tableName);
            }*/
        }


        #region FTP DOWNLOAD
        public byte[] GetInvoice(long Id)
        {
            string ftphost = FtpAddress;
            string ftpfullpath = "ftp://" + ftphost + "/Invoice_" + Id + ".pdf";
            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(Login, Password);
                byte[] fileData = request.DownloadData(ftpfullpath);
                return fileData;

            }
        }
        private void Download(string fileName)
        {

            string savePath = Path.Combine(DownloadPath, fileName);
            string ftphost = FtpAddress;
            string ftpfilepath = fileName;

            string ftpfullpath = "ftp://" + ftphost + "/" + ftpfilepath;

            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential(Login, Password);
                byte[] fileData = request.DownloadData(ftpfullpath);

                using (FileStream file = File.Create(savePath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
               
            }
        }

        private List<string> GetLatestFiles()
        {
            List<string> results = new List<string>();
            var allFiles = GetAllFiles();

            results.Add(GetLatestFile("CLIENTS", allFiles));
            results.Add(GetLatestFile("UNIQUEIDS", allFiles));
            results.Add(GetLatestFile("CLIENTDELNOTE", allFiles));
            results.Add(GetLatestFile("CLIENTINVOICE", allFiles));
            results.Add(GetLatestFile("CUSTOMER", allFiles));
            results.Add(GetLatestFile("CLIENTDELNOTEIDS", allFiles));

            return results;
        }

        private string GetLatestFile(string prefix, string[] allFiles)
        {
            string regexPattern = "V_SIENN_[0-9]_" + prefix + "[0-9]*.CSV";
            string datePattern = "20[0-9]*.CSV";
            Dictionary<string, DateTime> matchedList = new Dictionary<string, DateTime>();

            foreach (var input in allFiles)
            {
                if (Regex.IsMatch(input, regexPattern))
                {
                    var dateString = Regex.Match(input, datePattern).Value.Replace(".CSV", string.Empty);
                    DateTime date = DateTime.ParseExact(dateString, "yyyyMMddHHmm", System.Globalization.CultureInfo.InvariantCulture);
                    matchedList.Add(input, date);
                }
            }

            var latest = matchedList.OrderByDescending(p => p.Value).First();
            return latest.Key;          
        }      

        private string[] GetAllFiles()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FtpAddress + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(Login, Password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {              
                downloadFiles = null;
                return downloadFiles;
            }
        }

        #endregion  

    }

}
