using CafedralReportingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Helpers
{
    public class ExtendedStaticWorkflow
    {
        public int Id { get; set; }

        public bool IsEnabled { get; set; }

        public string Description { get; set; }

        public string DisciplineName { get; set; }

        public Semester Semester { get; set; }

        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Value3 { get; set; }
        public float Value4 { get; set; }
        public float Value5 { get; set; }

        public bool Zachet { get; set; }

        public Employee Employee { get; set; }
        public Employee Employee2 { get; set; }
        public Employee Employee3 { get; set; }
        public Employee Employee4 { get; set; }
        public Employee Employee5 { get; set; }

        public Agreement Agreement { get; set; }

        public StudyGroup Group { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public Dictionary<string, double> Dictionary { get; set; }

        public ExtendedStaticWorkflow()
        {
            Dictionary = new Dictionary<string, double>();
            if(Employee!=null)
                Dictionary.Add(Employee?.FullName, Value1);
            if(Employee2!=null)
                Dictionary.Add(Employee2?.FullName, Value2);
            if (Employee3 != null)
                Dictionary.Add(Employee3?.FullName, Value3);
            if (Employee4 != null)
                Dictionary.Add(Employee4?.FullName, Value4);
            if (Employee5 != null)
                Dictionary.Add(Employee5?.FullName, Value5);
        }
        public ExtendedStaticWorkflow(StaticWorkflow workflow, AcademicYear currentYear)
        {
            this.Id = workflow.Id;
            IsEnabled = workflow.IsEnabled;
            Description = workflow.Description;
            DisciplineName = workflow.DisciplineName;
            Semester = workflow.Semester;
            Value1 = workflow.Value1;
            Value2 = workflow.Value2;
            Value3 = workflow.Value3;
            Value4 = workflow.Value4;
            Value5 = workflow.Value5;
            Zachet = workflow.Zachet;
            Employee = workflow.Employee;
            Employee2 = workflow.Employee2;
            Employee3 = workflow.Employee3;
            Employee4 = workflow.Employee4;
            Employee5 = workflow.Employee5;
            Agreement = workflow.Agreement;

            Group = GetActualGroup(workflow.Semester, currentYear);
            AcademicYear = currentYear;

            Dictionary = new Dictionary<string, double>();
            if (Employee != null)
                Dictionary.Add(Employee?.FullName, Value1);
            if (Employee2 != null)
                Dictionary.Add(Employee2?.FullName, Value2);
            if (Employee3 != null)
                Dictionary.Add(Employee3?.FullName, Value3);
            if (Employee4 != null)
                Dictionary.Add(Employee4?.FullName, Value4);
            if (Employee5 != null)
                Dictionary.Add(Employee5?.FullName, Value5);
        }

        private static StudyGroup GetActualGroup(Semester semester, AcademicYear year)
        {
            var context = DbContextSingleton.GetContext();
            var course = (semester.SemesterNumber+1) / 2 ;
            var group = context.StudyGroups.FirstOrDefault(s => s.EntryYear == year.StartYear - course+1);
            return group;
        }

        public double GetValueByEmployeeId(int id)
        {
            if (Employee.Id == id)
                return Value1;
            if (Employee2.Id == id)
                return Value2;
            if (Employee3.Id == id)
                return Value3;
            if (Employee4.Id == id)
                return Value4;
            if (Employee5.Id == id)
                return Value5;
            return 0.0;
        }
    }
}
