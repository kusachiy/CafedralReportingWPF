using CafedralReportingWPF.Models.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CafedralReportingWPF.Models
{
    public class Discipline : BaseModel
    {
        public string DisciplineName { get; set; }
        public int ReadInSemesterId { get; set; }
        [ForeignKey("ReadInSemesterId")]
        public Semester ReadInSemester { get; set; }

        //не используется. сликом сложно. оставил возможность назначать 5 преподавателей на каждую дисциплину.
        public bool IsMultiEmployee { get; set; }

        public override string ToString()
        {
            return DisciplineName;
        }
    }    
}
