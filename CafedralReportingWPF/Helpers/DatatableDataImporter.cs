using CafedralReportingWPF.Models;
using System.Collections.Generic;
using static CafedralReportingWPF.Reports.Datasets.SemesterDataset;
using static CafedralReportingWPF.Reports.Datasets.WorkloadDataset;

namespace CafedralReportingWPF.Helpers
{
    public static class DatatableDataImporter
    {
        public static void FillSemesterDataset(DataTable1DataTable datatable, List<Workflow> workflows)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable1Row(w.Group.FullName, w.Discipline.DisciplineName, w.Lectures,w.Practices,w.Labs,w.Group.CountOfStudents,GetInt(w.KR),GetInt(w.KP),GetInt(w.Examen),GetInt(w.Zachet)
                    ,ConcatanateEmployees(w)
                    ,w.Semester.CountOfWeeks,w.Agreement?.Description,w.Semester.SemesterNumber.ToString(),w.WorkflowYear.FullYearName,w.Group.CountOfSubgroups);

            }
        }
        public static void FillWorkloadDataset(DataTable2DataTable datatable, List<Workflow> workflows)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable2Row("",w.Discipline.DisciplineName,"ПИН","ФИТ",w.Semester.SemesterNumber,w.Group.CountOfStudents,w.Semester.CountOfWeeks,1,w.Group.CountOfSubgroups,w.Lectures,w.Practices,w.Labs
                    ,GetInt(w.Examen),GetInt(w.Zachet),0,GetInt(w.KR),0,0,w.PracticeWeeks,0,0,0,0,0,w.Employee.FullName,w.WorkflowYear.FullYearName);

            }
        }
        private static int GetInt(bool p)
        {
            return p ? 1 : 0;
        }
        private static string ConcatanateEmployees(Workflow w)
        {
            string str = w.Employee?.FullName ?? "";
            if (w.Employee2 != null)
                str += ", " + w.Employee2.FullName;
            if (w.Employee3 != null)
                str += ", " + w.Employee3.FullName;
            if (w.Employee4 != null)
                str += ", " + w.Employee4.FullName;
            if (w.Employee5 != null)
                str += ", " + w.Employee5.FullName;
            return str;
        }
        
    }

  

}
