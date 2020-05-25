using CafedralReportingWPF.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafedralReportingWPF.Models
{
    [Table("Agreements")]
    public class Agreement: BaseModel
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
