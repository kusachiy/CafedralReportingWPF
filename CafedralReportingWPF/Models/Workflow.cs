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
        public Semester Discipline { get; set; }

        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        public int GroupId { get; set; }

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
        public bool PracticeWeeks { get; set; }
        public bool Other { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }


    }
}
