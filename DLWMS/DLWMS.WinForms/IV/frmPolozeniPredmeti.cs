using DLWMS.WinForms.I;
using DLWMS.WinForms.III;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IV
{
    public partial class frmPolozeniPredmeti : Form
    {
        Student _student;
        public frmPolozeniPredmeti(Student student)
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
            this._student = student;
        }

        private void frmPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            try
            {
                UcitajPredmete();
                UcitajPolozenePredmete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UcitajPolozenePredmete()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = new BindingSource()
            {
                DataSource = _student.PolozeniPredmeti
            };
        }

        private void UcitajPredmete()
        {
            cmbPredmet.DataSource = InMemoryDB.NPP;
            cmbPredmet.DisplayMember = "Naziv";
            cmbPredmet.ValueMember = "Id";
        }

        private void btnDodajPolozeniPredmet_Click(object sender, EventArgs e)
        {
            if (ValidanUnos())
            {
                _student.PolozeniPredmeti.Add(new PolozeniPredmet()
                {
                    Id = _student.PolozeniPredmeti.Count + 1,
                    DatumPolaganja = dtpDatumPolaganja.Value,
                    Ocjena = int.Parse(cmbOcjena.Text),
                    Predmet = cmbPredmet.SelectedItem as Predmet
                });
                UcitajPolozenePredmete();
                OnemoguciDodavanje();
                UcitajStatistiku();
            }
        }

        private void UcitajStatistiku()
        {
            var brojZapisa = _student.PolozeniPredmeti.Count();
            lblBrojZapisa.Text = $"Broj zapisa {brojZapisa}";
            if (brojZapisa > 0)
            {
                lblProsjek.Text = $"Prosjecna ocjena {_student.PolozeniPredmeti.Average(x => x.Ocjena)}";
            }
        }

        private bool ValidanUnos()
        {
            return Validator.ValidirajKontrolu(cmbPredmet, err, Poruke.ObaveznaVrijednost) &&
               Validator.ValidirajKontrolu(cmbOcjena, err, Poruke.ObaveznaVrijednost);
        }

        private void cmbPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnemoguciDodavanje();
        }

        private void OnemoguciDodavanje()
        {
            var odabraniPredmet = cmbPredmet.SelectedItem as Predmet;
            var postoji = _student.PolozeniPredmeti.Where(polozeni => polozeni.Predmet.Id == odabraniPredmet.Id).Count() > 0;
            btnDodajPolozeniPredmet.Enabled = !postoji;
        }
    }
}

