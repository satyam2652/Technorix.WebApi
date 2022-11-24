using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.Infrastructure.Service
{
    public class DepartmentService : IDepartmentsService
    {
        private readonly IDepartmentsRepo _departmentsRepo;
        public DepartmentService(IDepartmentsRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }

        public OutputDto CreateDepartment(DepartmentsMst NewDepartment)
        {
            var data = _departmentsRepo.CreateDepartment(NewDepartment);

            return data;
        }

        public IEnumerable<DepartmentsMst> GetAllDepartments()
        {
            var data = _departmentsRepo.GetAllDepartments();
            return data;
        }

        public DepartmentsMst GetDepartmentById(int DepartmentId)
        {
            var data = _departmentsRepo.GetDepartmentById(DepartmentId);
            return data;
        }

        public OutputDto UpdateDepartment(DepartmentsMst NewDepartment)
        {
            var data = _departmentsRepo.UpdateDepartment(NewDepartment);
            return data;
        }
    }
}
