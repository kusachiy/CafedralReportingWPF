using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class Semester: BaseModel
    {
        public int SemesterNumber { get; set; }
        public int CountOfWeeks { get; set; }
        public int Course { get; set; }
        public bool IsAutumn { get; set; }
    }
}
