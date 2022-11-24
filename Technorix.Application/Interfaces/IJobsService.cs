using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Models.Models;

namespace Technorix.Application.Interfaces
{
    public interface IJobsService
    {
        IEnumerable<JobsDto> GetAllJobs();
        OutputDto AddJobDetails(JobsModel jobDetails);
        OutputDto UpdateJobDetails(JobsModel jobDetails);
        IEnumerable<JobsDto> GetJobDetailsByFilter(string JobTitle);
        JobsDto GetJobDetailsById(int JobId);

    }
}
