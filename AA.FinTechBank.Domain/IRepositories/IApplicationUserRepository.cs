using AA.FinTechBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.FinTechBank.Domain.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task CreateApplicationUserAsync(EApplicationUser applicationUser);
        Task<EApplicationUser> SearchByUsernameAsync(string username);

    }
}
