using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class StaticWorkflow: BaseModel
    {
        public bool IsEnabled { get; set; }

        public string Description { get; set; }

        public string DisciplineName { get; set; }

        public int? SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public float Value4 { get; set; }
        public float Value5 { get; set; }

        public bool Zachet { get; set; }
        public bool NIR { get; set; }


        public int? EmployeeId { get; set; }
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

        public int? AgreementId { get; set; }
        [ForeignKey("AgreementId")]
        public Agreement Agreement { get; set; }

        public bool ContainsEmployeeById(int id)
        {
            return EmployeeId == id || Employee2Id == id || Employee3Id == id || Employee4Id == id || Employee5Id == id;
        }
    }
}
