using FluentScheduler;
using Lips.Service.Import;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Lips.Api.ScheduledJobs
{
    public class ImportTask : IJob
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Execute()
        {
            try
            {               
                IImportService ImportService = new ImportService(
                   ConfigurationManager.ConnectionStrings["BaseContext"].ConnectionString,
                    ConfigurationManager.AppSettings["ftpAddress"],
                    ConfigurationManager.AppSettings["login"],
                    ConfigurationManager.AppSettings["password"],
                    ConfigurationManager.AppSettings["downloadPath"],
                    ConfigurationManager.AppSettings["csvSeparator"]
                 );

                ImportService.ImportFiles();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            

        }
    }
}