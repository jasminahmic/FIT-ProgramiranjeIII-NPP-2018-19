using DLWMS.WinForms.I;
using DLWMS.WinForms.III;
using DLWMS.WinForms.V;
using DLWMS.WinForms.VI;
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
        KonekcijaNaBazu _db = DLWMSdb.Baza;
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
                UcitajUloge();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UcitajUloge()
        {
            dgvUloge.DataSource = null;
            dgvUloge.DataSource = _student.Uloge.ToList();
            //dgvUloge.DataSource = _db.StudentiUloge.Where(x => x.Student.Id == _student.Id).ToList();
        }

        private void UcitajPolozenePredmete()
        {
            dgvPolozeniPredmeti.DataSource = null;
            dgvPolozeniPredmeti.DataSource = _db.StudentiPredmeti.Where(x => x.Studenti.Id == _student.Id).ToList();
        }

        private void UcitajPredmete()
        {
            cmbPredmet.DataSource = _db.Predmeti.ToList();
            cmbPredmet.DisplayMember = "Naziv";
            cmbPredmet.ValueMember = "Id";
        }

        private void btnDodajPolozeniPredmet_Click(object sender, EventArgs e)
        {
            if (ValidanUnos())
            {
                _db.StudentiPredmeti.Add(new StudentiPredmeti()
                {
                    Datum = dtpDatumPolaganja.Value,
                    Ocjena = int.Parse(cmbOcjena.Text),
                    Predmeti = cmbPredmet.SelectedItem as Predmet,
                    Studenti = _student
                });
                _db.SaveChanges();
                //_student.PolozeniPredmeti.Add(new PolozeniPredmet()
                //{
                //    Id = _student.PolozeniPredmeti.Count + 1,
                //    DatumPolaganja = dtpDatumPolaganja.Value,
                //    Ocjena = int.Parse(cmbOcjena.Text),
                //    Predmet = cmbPredmet.SelectedItem as Predmet
                //});
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

        private void dgvPolozeniPredmeti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _student.Uloge.Add(_db.Uloge.Find(1));
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUloge_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

