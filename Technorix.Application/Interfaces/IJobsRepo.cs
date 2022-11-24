using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Models.Models;

namespace Technorix.Application.Interfaces
{
    public interface IJobsRepo
    {
        IEnumerable<JobDetails> GetAllJobs();
        OutputDto AddJob(JobsModel jobDetails);
        OutputDto UpdateJobDetails(JobsModel jobDetails);
        JobDetails GetJobDetailsById(int JobId);
        IEnumerable<JobDetails> GetJobDetailsByFilter(string JobTitle);

    }
}
