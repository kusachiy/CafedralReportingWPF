using CafedralReportingWPF.Models;
using System.Collections.Generic;
using System.Linq;
using static CafedralReportingWPF.Reports.Datasets.Contract;
using static CafedralReportingWPF.Reports.Datasets.IndPlan;

using static CafedralReportingWPF.Reports.Datasets.SemesterDataset;
using static CafedralReportingWPF.Reports.Datasets.WorkloadDataset;
using static CafedralReportingWPF.Reports.Datasets.WorkloadDatasetEmployee;

namespace CafedralReportingWPF.Helpers
{
    public static class DatatableDataImporter
    {
        public static void FillSemesterDataset(DataTable1DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics)
        {
            foreach (var w in workflows)
            {
                if (w.Discipline.DisciplineName == "Web-программирование") { }

                datatable.AddDataTable1Row(w.Group.FullName, w.Discipline.DisciplineName,w.Semester.CountOfWeeks
                    ,w.Agreement?.Description,w.Semester.SemesterNumber,w.WorkflowYear.FullYearName,
                    WorkflowCalculator.CalculateSimpleWorkflow(w)
                    , w.Group.EntryYear
                    , w.Lectures
                    ,w.Group.CountOfStudents
                    ,w.Discipline.DisciplineName.Contains("аспирант")?"асп":w.Semester.Course>4? "маг": "бак");

            }
            foreach (var w in statics)
            {
                    datatable.AddDataTable1Row(w.Group.FullName, w.DisciplineName,w.Semester.CountOfWeeks,
                    w.Agreement?.Description, w.Semester.SemesterNumber, w.AcademicYear.FullYearName
                    ,WorkflowCalculator.CalculateStaticWorkflowTotal(w)
                    , w.Group.EntryYear
                    ,0
                    , w.Group.CountOfStudents
                    , w.DisciplineName.Contains("аспирант") ? "асп" : w.Semester.Course > 4 ? "маг" : "бак"
                    );
            }
        }
        public static void FillWorkloadDataset(DataTable2DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable2Row("",w.Discipline.DisciplineName,"ПИН","ФИТ",w.Semester.SemesterNumber,w.Group.CountOfStudents,w.Semester.CountOfWeeks,1,w.Group.CountOfSubgroups,w.Lectures,w.Practices,w.Labs
                    ,GetInt(w.Examen),GetInt(w.Zachet),0,GetInt(w.KR),0,0,w.PracticeWeeks,0,0,0,0,0,w.Employee.FullName,w.WorkflowYear.FullYearName,0,0,0,0,0,0,0,0,0,0,0,0,false,0,0,0,w.Agreement.Description);
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
                    s.Value5,
                    s.Agreement.Description
                    );
            }
        }
        public static void FillWorkloadEmployee(DataTable3DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable3Row("", w.Discipline.DisciplineName, "ПИН", "ФИТ", w.Semester.SemesterNumber, w.Group.CountOfStudents, w.Semester.CountOfWeeks, 1, w.Group.CountOfSubgroups, w.Lectures, w.Practices, w.Labs
                    , GetInt(w.Examen), GetInt(w.Zachet), 0, GetInt(w.KR), 0, 0, w.PracticeWeeks, 0, 0, 0, 0, 0, w.Employee.FullName, w.WorkflowYear.FullYearName, 0, 0, 0, 0, w.Agreement.Description,0,false);
            }
            foreach (var s in statics)
            {
                foreach (var d in s.Dictionary)
                {
                    var lowerD = s.DisciplineName.ToLower();
                    datatable.AddDataTable3Row("", s.DisciplineName, "ПИН", "ФИТ", s.Semester.SemesterNumber, s.Group.CountOfStudents,
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
                        d.Key,
                        s.AcademicYear.FullYearName,
                        (lowerD == "руководство кафедрой" ? 1 : 0),
                        s.Value1,
                        s.Value2,
                        (lowerD == "руководство аспирантами" || lowerD == "прием экзаменов кандидат. и аспирант." ? 1 : 0),
                        s.Agreement.Description,
                        d.Value,
                        s.Employee2 != null
                        );
                }
            }
        }
        public static void FillContactDataset(DataTable4DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics, Employee employee)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable4Row(w.Employee.FullName,w.Semester.CountOfWeeks * w.Lectures,w.Semester.CountOfWeeks*w.Practices,w.Semester.CountOfWeeks*2*w.Group.CountOfSubgroups,
                    GetInt(w.KR)*w.Group.CountOfStudents*2, GetInt(w.KP) * w.Group.CountOfStudents * 3,0,0,
                    0.05 * w.Lectures * w.Semester.CountOfWeeks + 2 * 1 * GetInt(w.Examen),GetInt(w.Zachet)*w.Group.CountOfStudents*0.25,
                    GetInt(w.Examen)*0.33*w.Group.CountOfStudents,0,0,0,w.Discipline.DisciplineName,w.Group?.Name??"-",0);
            }
            foreach (var w in statics)
            {
                var lowerD = w.DisciplineName.ToLower();

                datatable.AddDataTable4Row(employee.FullName, 0, 0, 0,
                    0, 0,


                    (lowerD == "научно-исследовательская работа в семестре" || lowerD == "преддипломная практика" || lowerD == "производственная практика (научно-исследовательская работа)"
                    ? w.Value1 * w.Group.CountOfStudents:0)
                    ,(lowerD.EndsWith(" практика") || lowerD == "руководство аспирантами"? w.Value1 * w.Value2:0),

                0, 0, 0,
                    (lowerD == "диссертация бакалавры" ? w.Value1 : 0),             
                    (lowerD == "государственный экзамен бакалавров" ? w.GetValueByEmployeeId(employee.Id) : 0),
                    (lowerD == "работа гак" ? w.GetValueByEmployeeId(employee.Id) : 0),
                    w.DisciplineName, "-", 
                    (lowerD == "диссертация бакалавры" || lowerD == "государственный экзамен бакалавров" || lowerD == "работа гак"
                    || lowerD == "научно-исследовательская работа в семестре" || lowerD == "преддипломная практика" || lowerD == "производственная практика (научно-исследовательская работа)"
                    || lowerD.EndsWith(" практика") || lowerD == "руководство аспирантами"
                    ? 0: w.Value1)
                    
                    ) ;
            }
        }

        public static void FillIndPlanDataset(DataTable5DataTable datatable, List<Workflow> workflows, List<ExtendedStaticWorkflow> statics, Employee employee)
        {
            foreach (var w in workflows)
            {
                datatable.AddDataTable5Row(w.Employee.FullName, w.Semester.CountOfWeeks * w.Lectures, w.Semester.CountOfWeeks * w.Practices, w.Semester.CountOfWeeks * w.Labs * w.Group.CountOfSubgroups,
                    GetInt(w.KR) * w.Group.CountOfStudents * 2, GetInt(w.KP) * w.Group.CountOfStudents * 3, 0, 0,
                    0.05 * w.Lectures * w.Semester.CountOfWeeks + 2 * 1 * GetInt(w.Examen), GetInt(w.Zachet) * w.Group.CountOfStudents * 0.25,
                    GetInt(w.Examen) * 0.33 * w.Group.CountOfStudents,  0, 0, w.Discipline.DisciplineName, w.Group?.FullName ?? "-", w.WorkflowYear?.FullYearName,0,0,0,0,0,0,w.Group?.CountOfStudents??0,
                    WorkflowCalculator.CalculateSimpleWorkflow(w),
                    GetInt(w.Semester.IsAutumn)
                    );
            }
            foreach (var w in statics)
            {
                var lowerD = w.DisciplineName.ToLower();

                datatable.AddDataTable5Row(employee.FullName, 0, 0,
                    0, 0, 0, 0, 0, 0,0,0,
                    (lowerD == "государственный экзамен бакалавров" ? w.GetValueByEmployeeId(employee.Id) : 0),
                    (lowerD == "работа гак" ? w.GetValueByEmployeeId(employee.Id) : 0),
                    w.DisciplineName,w.Group?.FullName,  w.AcademicYear?.FullYearName,
                    (lowerD == "диссертация бакалавры" || lowerD == "государственный экзамен бакалавров" || lowerD == "работа гак" ? 0 : w.Value1)
                    ,0
                    ,0
                    ,0, 0,(lowerD == "диссертация бакалавры" ? w.Value1 : 0),w.Group?.CountOfStudents??0
                    ,(lowerD == "государственный экзамен бакалавров" ? w.GetValueByEmployeeId(employee.Id) : 0) 
                    + (lowerD == "работа гак" ? w.GetValueByEmployeeId(employee.Id) : 0)
                    + (/*lowerD == "диссертация бакалавры" ||*/ lowerD == "государственный экзамен бакалавров" || lowerD == "работа гак" ? 0 : w.Value1)
                    ,GetInt(w.Semester.IsAutumn)
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
