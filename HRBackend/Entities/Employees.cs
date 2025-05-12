using HRBackend.Domain.Enums;
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
        public int PersonalInfoId { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public NameWorkScheduleEnum NameWorkSchedule { get; set; }
    }
}
