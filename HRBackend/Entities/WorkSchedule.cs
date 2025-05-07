using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Domain.Entities
{
    public class WorkSchedule // #вопрос ОТСАВЛЯТЬ КАК СПРАВОЧНИК ИЛИ ДЕЛАТЬ ENUM?????????????????
    {
        public int Id { get; set; }
        public string Name { get; set; } // Офис, Гибрид, Удаленка
    }
}
