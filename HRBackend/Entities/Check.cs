using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class Check
    {
        public int Id { get; set; }
        public DateTime DateCheck { get; set; }
        public User User { get; set; }
        public string Event { get; set; }
    }
}
