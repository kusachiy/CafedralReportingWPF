using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.DataSource
{
    public class Context: DbContext
    {
        public Context() : base("MainConnection")
        {
        }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Workflow> Workflows { get; set; }   
        public DbSet<StaticWorkflow> StaticWorkflows { get; set; }
        public DbSet<DisciplineConfig> DisciplineConfig { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
    }
}
