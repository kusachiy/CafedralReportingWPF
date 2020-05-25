using CafedralReportingWPF.Models;
using System.Collections.Generic;
using static CafedralReportingWPF.Reports.Datasets.SemesterDataset;

namespace CafedralReportingWPF.Helpers
{
    public static class DatatableDataImporter
    {
        public static void FillSemesterDataset(DataTable1DataTable datatable, List<Workflow> workflows)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable1Row(w.Group.FullName, w.Discipline.DisciplineName, w.Lectures,w.Practices,w.Labs,w.Group.CountOfStudents,GetInt(w.KR),GetInt(w.KP),GetInt(w.Examen),GetInt(w.Zachet),w.Employee?.FullName??"",w.Semester.CountOfWeeks,w.Agreement?.Description);

            }
        }
        private static int GetInt(bool p)
        {
            return p ? 1 : 0;
        }
    }

  

}
