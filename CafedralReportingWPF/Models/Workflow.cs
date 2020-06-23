using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class Workflow: BaseModel
    {
        public string Description { get; set; }

        public int DisciplineId { get; set; }
        [ForeignKey("DisciplineId")]
        public Discipline Discipline { get; set; }

        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public StudyGroup Group { get; set; }

        public int WorkflowYearId { get; set; }
        [ForeignKey("WorkflowYearId")]
        public AcademicYear WorkflowYear { get; set; }

        public bool IsElective { get; set; }
        public bool IsDS { get; set; }

        public int Lectures { get; set; }
        public int Practices { get; set; }
        public int Labs { get; set; }

        public bool KR { get; set; }
        public bool KP { get; set; }
        public bool Examen { get; set; }
        public bool Zachet { get; set; }
        public bool Controlnaya { get; set; }
        public bool Consultation { get; set; }
        public int PracticeWeeks { get; set; }
        public bool Other { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int? AgreementId { get; set; }
        [ForeignKey("AgreementId")]
        public Agreement Agreement { get; set; }

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
    }
}
