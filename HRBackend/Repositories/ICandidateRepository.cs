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
        void Add(Candidate candidate);
    }
}
