using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities.Checks
{
    //ивент проверки(мвд, кандидаты и тд)
    public class CheckEvent
    {
        public int Id { get; set; }
        /* public CheckEventType Type { get; set; }*///енам типов проверок
        //public CheckEventStatus Status { get; set; } енам статуса проверки
        public int CheckId { get; set; }
        public Check Check { get; set; } = null!;

    }
}
