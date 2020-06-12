using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    public class Semester: BaseModel, IComparable
    {
        public int SemesterNumber { get; set; }
        public int CountOfWeeks { get; set; }
        public int Course { get; set; }
        public bool IsAutumn { get; set; }

        public int CompareTo(object obj)
        {
            var s = obj as Semester;
            if (s != null)
                return SemesterNumber.CompareTo(s.SemesterNumber);
            throw new Exception("Невозможно сравнить два объекта");
        }

        public override string ToString()
        {
            return SemesterNumber.ToString();
        }
    }
}
