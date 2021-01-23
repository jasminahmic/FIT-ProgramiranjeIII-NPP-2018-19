using DLWMS.WinForms.III;
using DLWMS.WinForms.IV;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.VI
{
    [Table("StudentiPredmeti")]
    public class StudentiPredmeti
    {
        public int Id { get; set; }
        public Predmet Predmeti { get; set; }
        public Student Studenti { get; set; }
        public int Ocjena { get; set; }
        public DateTime Datum { get; set; }
    }
}
