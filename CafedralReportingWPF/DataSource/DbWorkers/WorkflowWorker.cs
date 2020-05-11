using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.DataSource.DbWorkers
{
    public static class WorkflowWorker
    {
        public static void ImportWorkflow(Context context, List<ImportWorkflowModel> models)
        {
            var years = context.AcademicYears.ToList();
            var disciplines = context.Disciplines.ToList();
            var semesters = context.Semesters.ToList();
            var etds = context.EmployeeToDiscipline.ToList();
            var workflows = context.Workflows;
            foreach (var model in models)
            {
                var year = years.FirstOrDefault(y => y.FullYearName == model.Year);
                var discipline = disciplines.FirstOrDefault(d => d.DisciplineName == model.DisciplineName);
                var semester = semesters.FirstOrDefault(s => s.SemesterNumber == model.Semester);
                var etd = etds.FirstOrDefault(e => e.DisciplineId == discipline.Id);
                var newWorkflow = new Workflow
                {
                    Description = "",
                    DisciplineId = discipline.Id,
                    SemesterId = semester.Id,
                    GroupId = 1,
                    WorkflowYearId = year.Id,
                    IsElective = model.IsElective,
                    IsDS = model.IsDS,
                    Lectures = model.Lectures,
                    Practices = model.Practices,
                    Labs = model.Labs,
                    KR = model.KR,
                    KP = model.KP,
                    Examen = model.Examen,
                    Zachet = model.Zachet,
                    Consultation = model.Consultation,
                    Controlnaya = model.Controlnaya,
                    PracticeWeeks = model.PracticeWeeks,
                    Other = model.Other,
                    EmployeeId = etd?.EmployeeId
                };
                workflows.Add(newWorkflow);
            }
            context.SaveChanges();
        }
    }
}
