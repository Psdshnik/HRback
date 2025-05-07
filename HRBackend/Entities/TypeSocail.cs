using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class TypeSocail
    {
        public int Id { get; set; }
        public string Name { get; set; } // Instargam, FaceBoock, VK, Telegram, Viber, Однакласники
    }
}
