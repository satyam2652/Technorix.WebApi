using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.Infrastructure.Service
{
    public class JobsService : IJobsService
    {
        private readonly IJobsRepo _jobsRepo;
        public JobsService(IJobsRepo jobsRepo)
        {
            _jobsRepo = jobsRepo;
        }
        public OutputDto AddJobDetails(JobsModel jobDetails)
        {
            var data = _jobsRepo.AddJob(jobDetails);
            return data;
        }

        public IEnumerable<JobsDto> GetAllJobs()
        {
            var JobsList = new List<JobsDto>();

            foreach (var job in _jobsRepo.GetAllJobs())
            {
                JobsDto jobsDto = new JobsDto();
                jobsDto.Id = job.JobId;
                jobsDto.Code = job.code;
                jobsDto.title = job.title;
                jobsDto.description = job.description;
                jobsDto.postedDate = job.postedDate;
                jobsDto.closingDate = job.closingDate;

                LocationsMst locationsMst = new LocationsMst();
                locationsMst.Id = job.LocationId;
                locationsMst.Title = job.LocationTitle;
                locationsMst.City = job.city;
                locationsMst.State = job.state;
                locationsMst.Country = job.Country;
                locationsMst.Zip = job.Country;
                jobsDto.location = locationsMst;
                
                DepartmentsMst departmentsMst = new DepartmentsMst();
                departmentsMst.Id = job.DepartmentId;
                departmentsMst.Title = job.DepartmentTitle;
                jobsDto.department = departmentsMst;
                
                JobsList.Add(jobsDto);
            }

            return JobsList;
        }

        public JobsDto GetJobDetailsById(int JobId)
        {
            var job = _jobsRepo.GetJobDetailsById(JobId);

            JobsDto jobsDto = new JobsDto();
            jobsDto.Id = job.JobId;
            jobsDto.Code = job.code;
            jobsDto.title = job.title;
            jobsDto.description = job.description;
            jobsDto.postedDate = job.postedDate;
            jobsDto.closingDate = job.closingDate;

            LocationsMst locationsMst = new LocationsMst();
            locationsMst.Id = job.LocationId;
            locationsMst.Title = job.LocationTitle;
            locationsMst.City = job.city;
            locationsMst.State = job.state;
            locationsMst.Country = job.Country;
            locationsMst.Zip = job.Country;
            jobsDto.location = locationsMst;

            DepartmentsMst departmentsMst = new DepartmentsMst();
            departmentsMst.Id = job.DepartmentId;
            departmentsMst.Title = job.DepartmentTitle;
            jobsDto.department = departmentsMst;

            return jobsDto;
        }
        public IEnumerable<JobsDto> GetJobDetailsByFilter(string JobTitle)
        {
            var JobsList = new List<JobsDto>();

            foreach (var job in _jobsRepo.GetJobDetailsByFilter(JobTitle))
            {
                JobsDto jobsDto = new JobsDto();
                jobsDto.Id = job.JobId;
                jobsDto.Code = job.code;
                jobsDto.title = job.title;
                jobsDto.description = job.description;
                jobsDto.postedDate = job.postedDate;
                jobsDto.closingDate = job.closingDate;

                LocationsMst locationsMst = new LocationsMst();
                locationsMst.Id = job.LocationId;
                locationsMst.Title = job.LocationTitle;
                locationsMst.City = job.city;
                locationsMst.State = job.state;
                locationsMst.Country = job.Country;
                locationsMst.Zip = job.Country;
                jobsDto.location = locationsMst;

                DepartmentsMst departmentsMst = new DepartmentsMst();
                departmentsMst.Id = job.DepartmentId;
                departmentsMst.Title = job.DepartmentTitle;
                jobsDto.department = departmentsMst;

                JobsList.Add(jobsDto);
            }

            return JobsList;
        }

        public OutputDto UpdateJobDetails(JobsModel jobDetails)
        {
            var data = _jobsRepo.UpdateJobDetails(jobDetails);
            return data;
        }
    }
}
