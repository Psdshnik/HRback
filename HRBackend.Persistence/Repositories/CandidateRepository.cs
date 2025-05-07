using HRBackend.Domain.Entities;
using HRBackend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Persistence.Repositories
{
    public class CandidateRepository(AppDbContext dbContext) : ICandidateRepository
    {
        public void Add(Candidate candidate)
        {
            dbContext.Candidates.Add(candidate);
        }
    }
}
