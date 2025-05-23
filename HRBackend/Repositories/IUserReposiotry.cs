using HRBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Repositories
{
    public interface IUserReposiotry
    {
        Task<User?> GetById(int id);
        Task<User?> GetByAd(string ad);
        Task<IEnumerable<User>?> GetAll();
        Task<User?> GetByAdPass(string ad, string password);
    }
}
