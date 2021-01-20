using DLWMS.WinForms.I;
using DLWMS.WinForms.IV;
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
    public partial class frmNoviStudent : Form
    {
        private Student _student;
        private bool _promjena;
        public frmNoviStudent()
        {
            InitializeComponent();
            UcitajPodatke();
        }

        public frmNoviStudent(Student student) : this()
        {
            this._student = student;
            UcitajPodatkeOStudentu();
            _promjena = true;
        }

        private void UcitajPodatke()
        {
            GenerisiBrojIndeksa();
            UcitajSpolove();
        }

        private void UcitajSpolove()
        {
            cmbSpol.DataSource = InMemoryDB.Spolovi;
            cmbSpol.DisplayMember = "Naziv";
            cmbSpol.ValueMember = "Id";
        }

        private void UcitajPodatkeOStudentu()
        {
            if (_student != null)
            {
                txtIme.Text = _student.Ime;
                txtPrezime.Text = _student.Prezime;
                dtpDatumRodjenja.Value = _student.DatumRodjenja;
                txtEmail.Text = _student.Email;
                txtIndeks.Text = _student.Indeks;
                cbGodinaStudija.SelectedIndex = cbGodinaStudija.Items.IndexOf(_student.GodinaStudija.ToString());
                cbAktivan.Checked = _student.Aktivan;
                cmbSpol.SelectedValue = _student.Spol.Id;
                pictureBox2.Image = _student.Slika;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (ofdOdabirSlike.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofdOdabirSlike.FileName);
            }
        }

        private void frmNoviStudent_Load(object sender, EventArgs e)
        {
        }

        private void GenerisiBrojIndeksa()
        {
            txtIndeks.Text = $"IB{((DateTime.Now.Year - 2000) * 10000) + InMemoryDB.Studenti.Count}";
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            GenerisiEmail();
        }

        private void GenerisiEmail()
        {   //zamjena email-a ukoliko postoji isti email
            foreach (var studenti in InMemoryDB.Studenti)
            {
                if (studenti.Email == $"{txtIme.Text.ToLower()}.{txtPrezime.Text.ToLower()}@edu.fit.ba")
                    txtEmail.Text = $"{txtPrezime.Text.ToLower()}.{txtIme.Text.ToLower()}@edu.fit.ba";
                else
                    txtEmail.Text = $"{txtIme.Text.ToLower()}.{txtPrezime.Text.ToLower()}@edu.fit.ba";
            }
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            GenerisiEmail();
        }

        private void btnSačuvaj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                if (!_promjena)
                {
                    _student = new Student();
                    _student.Id = InMemoryDB.Studenti.Count + 1;
                }
                _student.Ime = txtIme.Text;
                _student.Prezime = txtPrezime.Text;
                _student.DatumRodjenja = dtpDatumRodjenja.Value;
                _student.Email = txtEmail.Text;
                _student.Indeks = txtIndeks.Text;
                _student.GodinaStudija = int.Parse(cbGodinaStudija.Text);
                _student.Aktivan = cbAktivan.Checked;
                _student.Spol = cmbSpol.SelectedItem as Spol;
                _student.Slika = pictureBox2.Image;
                if (_promjena)
                {
                    MessageBox.Show(Poruke.StudentPodaciUspjesnoModifikovani);
                }
                else
                {
                    InMemoryDB.Studenti.Add(_student);
                    MessageBox.Show(Poruke.StudentUspjesnoDodan);
                }
                Close();
            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ValidirajKontrolu(txtIme, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtPrezime, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtEmail, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(cmbSpol, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtIndeks, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(pictureBox2, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(cbGodinaStudija, err, Poruke.ObaveznaVrijednost);
        }
    }
}
