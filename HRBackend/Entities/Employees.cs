using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public WorkSchedule WorkSchedule { get; set; }
    }
}
