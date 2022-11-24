using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;

namespace Technorix.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        public ITokenService TokenService { get; }
        public IJobsService JobsService {get; }
        public IDepartmentsService DepartmentsService { get; }

        public UnitOfWork(ITokenService _TokenService, IJobsService jobsService, IDepartmentsService departmentsService )
        {

            this.TokenService = _TokenService;
            this.JobsService = jobsService;  
            this.DepartmentsService = departmentsService;
        }

    }
}
