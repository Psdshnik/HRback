using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class Candidates
    {
        public int Id { get; set; }
        public DateTime DateUp { get; set; }
        public DictStatusCandidata StatusCandidataId { get; set; }
        public WorkSchedule WorkSchedule { get; set; }
        public WorkingGroup WorkingGroup { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Users User { get; set; }
    }
}
