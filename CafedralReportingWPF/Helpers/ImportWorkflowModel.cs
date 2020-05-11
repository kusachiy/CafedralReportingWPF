using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Helpers
{
    public class ImportWorkflowModel
    {
        public string Year { get; set; }
        public int Semester { get; set; }
        public string DisciplineName { get; set; }
       /* public bool IsElective { get; set; }
        public bool IsDS { get; set; }*/
        public int Lectures { get; set; }
        public int Practices { get; set; }
        public int Labs { get; set; }
        public bool KR { get; set; }
        public bool KP { get; set; }
        public bool Examen  { get; set; }
        public bool Zachet { get; set; }
        public bool Controlnaya { get; set; }
        public bool Consultation { get; set; }
        public bool PracticeWeeks { get; set; }
        public bool Other { get; set; }
    }
}
