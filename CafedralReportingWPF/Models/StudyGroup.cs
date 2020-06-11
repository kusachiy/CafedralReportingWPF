using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class StudyGroup: BaseModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int CountOfStudents { get; set; }
        public int CountOfSubgroups { get; set; }
        public int EntryYear { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
