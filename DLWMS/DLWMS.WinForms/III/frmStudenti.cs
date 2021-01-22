using DLWMS.WinForms.I;
using DLWMS.WinForms.IV;
using DLWMS.WinForms.V;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.III
{
    public partial class frmStudenti : Form
    {
        KonekcijaNaBazu _db = new KonekcijaNaBazu();
        public frmStudenti()
        {
            InitializeComponent();
            dgvStudenti.AutoGenerateColumns = false;
        }

        private void frmStudenti_Load(object sender, EventArgs e)
        {
            UcitajPodatkeOStudentima();
        }

        private void btnNoviStudent_Click(object sender, EventArgs e)
        {
            frmNoviStudent noviStudent = new frmNoviStudent();
            noviStudent.ShowDialog();
            UcitajPodatkeOStudentima();
        }

        private void UcitajPodatkeOStudentima(List<Student> studenti = null)
        {
            dgvStudenti.DataSource = null;
            dgvStudenti.DataSource = studenti ?? _db.Studenti.ToList(); //InMemoryDB.Studenti;
        }

        private void txtPretragaStudenta_TextChanged(object sender, EventArgs e)
        {
            string filter = txtPretragaStudenta.Text;
            var rezultatiPretrage = _db.Studenti.Where(s => s.Ime.ToLower().Contains(filter) ||
                                                              s.Prezime.ToLower().Contains(filter)).ToList();
            UcitajPodatkeOStudentima(rezultatiPretrage);
        }

        private void dgvStudenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabraniStudent = dgvStudenti.SelectedRows[0].DataBoundItem as Student;
            Form forma = null;
            if (odabraniStudent != null)
            {
                if (e.ColumnIndex == 5)
                    forma = new frmPolozeniPredmeti(odabraniStudent);
                else
                    forma = new frmNoviStudent(odabraniStudent);
                forma.ShowDialog();
                UcitajPodatkeOStudentima();
            }
        }
    }
}
