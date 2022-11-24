using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technorix.Application.Interfaces
{
    public interface IUnitOfWork
    {

        ITokenService TokenService { get; }
        IJobsService JobsService { get; }
        IDepartmentsService DepartmentsService { get; }
    }
}
