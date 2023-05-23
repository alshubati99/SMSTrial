using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace SMSTrial.EntityModel
{
    [Table("student_tbl")]
    public partial class student_tbl
    {
        [Key]
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }     
        public string department { get; set; }

        
    }
}
