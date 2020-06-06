using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class AcademicYear: BaseModel
    {
        public int StartYear { get; set; }
        public string FullYearName { get; set; }

        public override string ToString()
        {
            return FullYearName;
        }
    }
}
