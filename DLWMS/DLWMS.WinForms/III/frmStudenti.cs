using DLWMS.WinForms.I;
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

        private void UcitajPodatkeOStudentima()
        {
            dgvStudenti.DataSource = null;
            dgvStudenti.DataSource = InMemoryDB.Studenti;
        }
    }
}
