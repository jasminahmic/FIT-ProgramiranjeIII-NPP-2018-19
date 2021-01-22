using DLWMS.WinForms.III;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.V
{
    public class KonekcijaNaBazu : DbContext
    {
        public KonekcijaNaBazu() : base("PutanjaDoBaze")
        {

        }

        public DbSet<Prisustva> Prisustva { get; set; }
        public DbSet<Student> Studenti { get; set; }
    }

    [Table("Prisustva")]
    public class Prisustva
    {
        public int Id { get; set; }
        public string BrojIndeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }

}
