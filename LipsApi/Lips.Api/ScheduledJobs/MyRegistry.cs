using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Lips.Api.ScheduledJobs
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {

            int intervalValue = int.Parse(ConfigurationManager.AppSettings["import_intevalValue"].ToString());
            string intervalUnit = ConfigurationManager.AppSettings["import_intervalUnit"].ToString();

            if (string.Equals(intervalUnit, "Hours", StringComparison.InvariantCultureIgnoreCase))
            {
                Schedule<ImportTask>().ToRunEvery(intervalValue).Hours();
            }
            else if (string.Equals(intervalUnit, "Minutes", StringComparison.InvariantCultureIgnoreCase))
            {
                Schedule<ImportTask>().ToRunEvery(intervalValue).Minutes(); 
            }
            else if (string.Equals(intervalUnit, "Days", StringComparison.InvariantCultureIgnoreCase))
            {
                Schedule<ImportTask>().ToRunEvery(intervalValue).Days();
            }

          
        }
    }
}