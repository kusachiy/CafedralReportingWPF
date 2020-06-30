using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Helpers
{
    public static class WorkflowCalculator
    {
        public static double CalculateSimpleWorkflow(Workflow w)
        {
            return w.Semester.CountOfWeeks * w.Lectures + 
                w.Semester.CountOfWeeks * w.Practices +
                w.Semester.CountOfWeeks * w.Labs * w.Group.CountOfSubgroups +
                GetInt(w.KR) * w.Group.CountOfStudents * 2 + 
                GetInt(w.KP) * w.Group.CountOfStudents * 3 +
                0.33 * GetInt(w.Examen) * w.Group.CountOfStudents +
                GetInt(w.Zachet) * w.Group.CountOfStudents * 0.25 +
                0.05 * w.Lectures * w.Semester.CountOfWeeks + 2 * 1 * GetInt(w.Examen);
        }
        public static double CalculateStaticWorkflowTotal(ExtendedStaticWorkflow w)
        {
            var lowerD = w.DisciplineName.Trim().ToLower();
            if (lowerD == "научно-исследовательская работа в семестре" || lowerD == "преддипломная практика" || lowerD == "производственная практика (научно-исследовательская работа)")
                return w.Value1 * w.Group.CountOfStudents;
                if (lowerD == "государственный экзамен бакалавров" || lowerD == "работа гак" || lowerD == "гэк магистров" || lowerD == "диссертация магистров" || lowerD == "гак магистров")
                return w.SumValues;
            if (lowerD.EndsWith(" практика") || lowerD == "руководство аспирантами")
                return w.Value1 * w.Value2;            
            return w.Value1;
        }
        public static double CalculateStaticWorkflowByEmployee(ExtendedStaticWorkflow w, Employee employee)
        {
            var lowerD = w.DisciplineName.Trim().ToLower();
            if (lowerD == "научно-исследовательская работа в семестре" || lowerD == "преддипломная практика" || lowerD == "производственная практика (научно-исследовательская работа)")
                return w.Value1 * w.Group.CountOfStudents;
            if (lowerD == "государственный экзамен бакалавров" || lowerD == "работа гак" || lowerD == "гэк магистров" || lowerD == "диссертация магистров" || lowerD == "гак магистров")
                return w.GetValueByEmployeeId(employee.Id);
            if (lowerD.EndsWith(" практика") || lowerD == "руководство аспирантами")
                return w.Value1 * w.Value2;
            return w.Value1;
        }

        private static int GetInt(bool p)
        {
            return p ? 1 : 0;
        }
    }
}
