using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technorix.Models.Models
{
 
    public class JobsModel
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public int departmentId { get; set; }
        public DateTime closingDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

    }
    public class JobDetails
    {
        public int JobId { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int LocationId { get; set; }
        public string LocationTitle { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string zip { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentTitle { get; set; }
        public DateTime? postedDate { get; set; }
        public DateTime? closingDate { get; set; }
    }
    public class JobsDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public LocationsMst location { get; set; }
        public DepartmentsMst department { get; set; }
        public DateTime? closingDate { get; set; }
        public DateTime? postedDate { get; set; }
    }

 

}
