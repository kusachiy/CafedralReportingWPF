﻿using CafedralReportingWPF.Models;
using System.Collections.Generic;
using static CafedralReportingWPF.Reports.Datasets.SemesterDataset;
using static CafedralReportingWPF.Reports.Datasets.WorkloadDataset;

namespace CafedralReportingWPF.Helpers
{
    public static class DatatableDataImporter
    {
        public static void FillSemesterDataset(DataTable1DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable1Row(w.Group.FullName, w.Discipline.DisciplineName, w.Lectures,w.Practices,w.Labs,w.Group.CountOfStudents,GetInt(w.KR),GetInt(w.KP),GetInt(w.Examen),GetInt(w.Zachet)
                    ,ConcatanateEmployees(w)
                    ,w.Semester.CountOfWeeks,w.Agreement?.Description,w.Semester.SemesterNumber.ToString(),w.WorkflowYear.FullYearName,w.Group.CountOfSubgroups);

            }
            foreach (var s in statics)
            {
                datatable.AddDataTable1Row(s.Group.FullName, s.DisciplineName, 0, (s.DisciplineName.Contains("практика") ? (int)s.Value1 : 0),
                    0, s.Group.CountOfStudents,0, 0, 0, GetInt(s.Zachet)
                    , ConcatanateEmployees(s)
                    , s.Semester.CountOfWeeks, s.Agreement?.Description, s.Semester.SemesterNumber.ToString(), s.AcademicYear.FullYearName, 1);
            }
        }
        public static void FillWorkloadDataset(DataTable2DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable2Row("",w.Discipline.DisciplineName,"ПИН","ФИТ",w.Semester.SemesterNumber,w.Group.CountOfStudents,w.Semester.CountOfWeeks,1,w.Group.CountOfSubgroups,w.Lectures,w.Practices,w.Labs
                    ,GetInt(w.Examen),GetInt(w.Zachet),0,GetInt(w.KR),0,0,w.PracticeWeeks,0,0,0,0,0,w.Employee.FullName,w.WorkflowYear.FullYearName,0,0,0,0,0,0,0,0,0,0,0,0,false,0,0,0);
            }
            foreach (var s in statics)
            {
                var lowerD = s.DisciplineName.ToLower();

                datatable.AddDataTable2Row("", s.DisciplineName, "ПИН", "ФИТ", s.Semester.SemesterNumber, s.Group.CountOfStudents,
                    (lowerD.Contains("практика") ? (int)s.Value1 : 0)
                    , 1, 1, 0, 0, 0
                    , 0, GetInt(s.Zachet), 0, 0, 0,
                    (lowerD == "учебная практика" ? 1 : 0),
                    (lowerD.Contains("производственная практика") ? 1 : 0),
                    (lowerD.Contains("преддипломная практика") ? 1 : 0),
                    (lowerD == "государственный экзамен бакалавров" ? 1 : 0),
                    (lowerD == "работа гак" ? 1 : 0),
                    (lowerD == "председатель гак" ? 1 : 0),
                    (lowerD == "диссертация бакалавры" ? 1 : 0),
                    s.Employee.FullName, s.AcademicYear.FullYearName,
                    (lowerD == "руководство кафедрой" ? 1 : 0),
                    s.Value1,
                    s.Value2,
                    (lowerD == "руководство аспирантами" || lowerD == "прием экзаменов кандидат. и аспирант." ? 1 : 0),
                    (s.Dictionary.ContainsKey("Калабин А.Л.") ? s.Dictionary["Калабин А.Л."] : 0),
                    (s.Dictionary.ContainsKey("Биллиг В.А.") ? s.Dictionary["Биллиг В.А."] : 0),
                    (s.Dictionary.ContainsKey("Мальков А.А.") ? s.Dictionary["Мальков А.А."] : 0),
                    (s.Dictionary.ContainsKey("Артемов И.Ю.") ? s.Dictionary["Артемов И.Ю."] : 0),
                    (s.Dictionary.ContainsKey("Котлинский С.В.") ? s.Dictionary["Котлинский С.В."] : 0),
                    (s.Dictionary.ContainsKey("Прохныч А.Н.") ? s.Dictionary["Прохныч А.Н."] : 0),
                    (s.Dictionary.ContainsKey("Югов И.В.") ? s.Dictionary["Югов И.В."] : 0),
                    (s.Dictionary.ContainsKey("Вакансия") ? s.Dictionary["Вакансия"] : 0),
                    s.Employee2 != null,
                    s.Value3,
                    s.Value4,
                    s.Value5
                    );
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
        private static string ConcatanateEmployees(ExtendedStaticWorkflow w)
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
