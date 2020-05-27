using CafedralReportingWPF.Helpers;
using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.DataSource.DbWorkers
{
    public static class WorkflowStaticWorker
    {
        public static void ImportWorkflow(Context context, List<ImportWorkflowModel> models)
        {
            var years = context.AcademicYears.ToList();
            var groups = context.StudyGroups.ToList();
            var disciplines = context.Disciplines.ToList();
            var semesters = context.Semesters.ToList();
            var etds = context.DisciplineConfig.ToList();
            var agreements = context.Agreements.ToList();
            var workflows = context.Workflows;
            foreach (var model in models)
            {
                var year = years.FirstOrDefault(y => y.FullYearName == model.Year);
                var discipline = disciplines.FirstOrDefault(d => d.DisciplineName == model.DisciplineName);
                var semester = semesters.FirstOrDefault(s => s.SemesterNumber == model.Semester);
                if (discipline is null)
                {

                }
                var etd = etds.FirstOrDefault(e => e.DisciplineId == discipline.Id);
                var group = groups.FirstOrDefault(g => g.EntryYear == year.StartYear-semester.Course+1);
                var newWorkflow = new Workflow
                {
                    Description = "",
                    DisciplineId = discipline.Id,
                    SemesterId = semester.Id,
                    GroupId = group.Id,
                    WorkflowYearId = year.Id,
                    /*IsElective = model.IsElective,
                    IsDS = model.IsDS,*/
                    IsElective = false,
                    IsDS = false,
                    //----
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
                    EmployeeId = etd?.EmployeeId,
                    AgreementId = etd?.AgreementId,
                    Employee2Id = etd?.Employee2Id,
                    Employee3Id = etd?.Employee3Id,
                    Employee4Id = etd?.Employee4Id,
                    Employee5Id = etd?.Employee5Id
                };
                workflows.Add(newWorkflow);
            }
            context.SaveChanges();
        }

        public static List<Workflow> GetAllWorkflows(Context context)
        {
            context.Workflows.Include(w => w.Employee).Include(w => w.Discipline).Include(w => w.Semester).Include(w => w.WorkflowYear).Include(w => w.Group).Load();
            return context.Workflows.ToList();
        }

        public static List<Workflow> GetAllWorkflowBySemesterAndYear(Context context,bool isatumn, int yearID)
        {
            context.Workflows.Include(w => w.Employee).Include(w => w.Employee2).Include(w => w.Employee3).Include(w => w.Employee4).Include(w => w.Employee5)
                .Include(w => w.Discipline).Include(w => w.Semester).Include(w => w.WorkflowYear).Include(w => w.Group).Load();
            return context.Workflows.Where(w=>w.Semester.IsAutumn == isatumn && w.WorkflowYearId == yearID).ToList();
        }
    }
}
