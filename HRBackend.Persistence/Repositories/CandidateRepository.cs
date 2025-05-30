using HRBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRBackend.Persistence.Repositories
{
    public class CandidateRepository(AppDbContext dbContext) : ICandidateRepository
    {
        public async Task<Candidate> Add(Candidate candidate)
        {
            await dbContext.Candidates.AddAsync(candidate);
            return candidate;
        }

        public async Task<Candidate> Update(Candidate candidate)
        {
            //var candidate = (await GetById(updateCandidate.Id));
            //candidate = updateCandidate;

            //dbContext.Candidates.Update(candidate);
            try
            {

                var res = await dbContext.Candidates.SingleOrDefaultAsync(c => c.Id == candidate.Id);

                res = candidate;
            }
            catch (Exception ex)
            {

            }
            return candidate;
        }

        public async Task<Candidate?> GetById(int id) => await dbContext.Candidates
            .Include(x => x.PersonalInfo)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
