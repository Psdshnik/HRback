using HRBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateAdd { get; set; }
        public int CountryId { get; set; }
        public DictCountry Country { get; set; }
        public NameSocailEnum NameSocail { get; set; }
    }
}
