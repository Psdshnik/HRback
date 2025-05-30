using HRBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> Add(Candidate candidate);
        Task<Candidate> Update(Candidate candidate);
        Task<Candidate> GetById(int id);
    }
}
