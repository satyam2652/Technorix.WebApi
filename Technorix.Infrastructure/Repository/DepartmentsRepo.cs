using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.Infrastructure.Repository
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        private readonly IConfiguration _configuration;

        public DepartmentsRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OutputDto CreateDepartment(DepartmentsMst NewDepartment)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_CreateDepartment";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@title", NewDepartment.Title);
                para.Add("@createdBy", NewDepartment.CreatedBy);
                var Result = connection.Query<OutputDto>(sqlQuery, para, commandType: CommandType.StoredProcedure);

                return Result.First();
            }
        }

        public IEnumerable<DepartmentsMst> GetAllDepartments()
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            IEnumerable<DepartmentsMst> AllDepartments;

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_GetDepartments";

                connection.Open();
                var para = new DynamicParameters();

                using (var multi = connection.QueryMultiple(sqlQuery, para, commandType: CommandType.StoredProcedure))
                {
                    var data = multi.Read<DepartmentsMst>().ToList();
                    AllDepartments = data;
                }

                return AllDepartments;
            }
        }

        public DepartmentsMst GetDepartmentById(int DepartmentId)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            var data = new DepartmentsMst();

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_GetDepartmentById";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@id", DepartmentId);

                using (var multi = connection.QueryMultiple(sqlQuery, para, commandType: CommandType.StoredProcedure))
                {
                    data = multi.Read<DepartmentsMst>().ToList().FirstOrDefault();
                }

                return data;
            }
        }

        public OutputDto UpdateDepartment(DepartmentsMst Department)
        {
            var conn = _configuration.GetSection("ConnectionStrings:DevelopmentConnection");

            using (var connection = new SqlConnection(conn.Value))
            {
                var sqlQuery = string.Empty;
                sqlQuery = $@"Usp_UpdateDepartment";

                connection.Open();
                var para = new DynamicParameters();
                para.Add("@id", Department.Id);
                para.Add("@title", Department.Title);
                para.Add("@updatedBy", Department.ModifiedBy);
                var Result = connection.Query<OutputDto>(sqlQuery, para, commandType: CommandType.StoredProcedure);

                return Result.First();
            }
        }
    }
}
