using CafedralReportingWPF.Models.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CafedralReportingWPF.Models
{
    public class Discipline : BaseModel
    {
        private string _fullName;

       // public int Id { get; set; }
        public string DisciplineName {
            get {
                return _fullName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged("DisciplineName");
            }
         }
        public int ReadInSemesterId { get; set; }
        [ForeignKey("ReadInSemesterId")]
        public Semester ReadInSemester { get; set; }

        public override string ToString()
        {
            return _fullName;
        }
    }    
}
