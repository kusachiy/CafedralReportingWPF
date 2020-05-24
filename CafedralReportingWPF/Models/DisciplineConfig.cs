using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    [Table("DisciplineConfig")]
    public class DisciplineConfig: BaseModel
    {
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int DisciplineId { get; set; }
        [ForeignKey("DisciplineId")]
        public Discipline Discipline { get; set; }

        public int? Agreement { get; set; }
    }
}
