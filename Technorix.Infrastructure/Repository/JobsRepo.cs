using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Technorix.Infrastructure.Repository
{
    public class JobsRepo : IJobsRepo
    {
        private readonly IConfiguration _configuration;

        public JobsRepo(IConfiguration configuration)
        {
            _configuration = configuration;

        }
      
        public JobDetails GetJobDetailsById(int JobId)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");
            var data = new JobDetails();

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_GetJobById";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@id", JobId);

                using (var multi = connection.QueryMultiple(sqlQuery, para, commandType: CommandType.StoredProcedure))
                {
                    data = multi.Read<JobDetails>().ToList().FirstOrDefault();
                }

                return data;
            }
        }

        public IEnumerable<JobDetails> GetJobDetailsByFilter(string JobTitle)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");
            IEnumerable<JobDetails> FilteredJobs;

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_GetJobByFilter";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@title", JobTitle);

                using (var multi = connection.QueryMultiple(sqlQuery, para, commandType: CommandType.StoredProcedure))
                {
                    var data = multi.Read<JobDetails>().ToList();
                    FilteredJobs = data;

                }

                return FilteredJobs;
            }
        }


        public IEnumerable<JobDetails> GetAllJobs()
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            IEnumerable<JobDetails> AllJobs;

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_GetJobs";

                connection.Open();
                var para = new DynamicParameters();
               
                using (var multi = connection.QueryMultiple(sqlQuery, para, commandType: CommandType.StoredProcedure))
                {
                    var data = multi.Read<JobDetails>().ToList();
                    AllJobs = data;
                }

                return AllJobs;
            }
        }
        public OutputDto AddJob(JobsModel jobDetails)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_CreateJob";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@title", jobDetails.title);
                para.Add("@description", jobDetails.description);
                para.Add("@locationId", jobDetails.locationId);
                para.Add("@departmentId", jobDetails.departmentId);
                para.Add("@cloasingDate", jobDetails.closingDate);
                para.Add("@createdBy", jobDetails.CreatedBy);
                var Result = connection.Query<OutputDto>(sqlQuery, para, commandType: CommandType.StoredProcedure);

                return Result.First();
            }
        }

        public OutputDto UpdateJobDetails(JobsModel jobDetails)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_CreateJob";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@id", jobDetails.Id);
                para.Add("@title", jobDetails.title);
                para.Add("@description", jobDetails.description);
                para.Add("@locationId", jobDetails.locationId);
                para.Add("@departmentId", jobDetails.departmentId);
                para.Add("@cloasingDate", jobDetails.closingDate);
                para.Add("@updatedBy", jobDetails.ModifiedBy);
                var Result = connection.Query<OutputDto>(sqlQuery, para, commandType: CommandType.StoredProcedure);

                return Result.First();
            }
        }
    }
}
