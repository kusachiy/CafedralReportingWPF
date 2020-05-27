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

        public int? Employee2Id { get; set; }
        [ForeignKey("Employee2Id")]
        public Employee Employee2 { get; set; }
        public int? Employee3Id { get; set; }
        [ForeignKey("Employee3Id")]
        public Employee Employee3 { get; set; }
        public int? Employee4Id { get; set; }
        [ForeignKey("Employee4Id")]
        public Employee Employee4 { get; set; }
        public int? Employee5Id { get; set; }
        [ForeignKey("Employee5Id")]
        public Employee Employee5 { get; set; }


        public int DisciplineId { get; set; }
        [ForeignKey("DisciplineId")]
        public Discipline Discipline { get; set; }

        public int? AgreementId { get; set; }
        [ForeignKey("AgreementId")]
        public Agreement Agreement { get; set; }

        public Semester Semester => Discipline.ReadInSemester;
        public bool IsMultiEmployee => Discipline.IsMultiEmployee;
        public bool IsSingleEmployee => !Discipline.IsMultiEmployee;

    }
}
