using CafedralReportingWPF.Models.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace CafedralReportingWPF.Models
{
    [Table("ComplexType")]
    public class ComplexType : BaseModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
       
        public override string ToString()
        {
            return Name;
        }
    }    
}
