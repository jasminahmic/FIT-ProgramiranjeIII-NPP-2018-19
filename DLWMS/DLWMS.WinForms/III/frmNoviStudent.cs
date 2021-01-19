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
    public partial class frmNoviStudent : Form
    {
        public frmNoviStudent()
        {
            InitializeComponent();
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
            GenerisiBrojIndeksa();
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
                InMemoryDB.Studenti.Add(new Student()
                {
                    Id = InMemoryDB.Studenti.Count + 1,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    DatumRodjenja = dtpDatumRodjenja.Value,
                    Email = txtEmail.Text,
                    Indeks = txtIndeks.Text,
                    GodinaStudija = int.Parse(cbGodinaStudija.Text),
                    Aktivan = cbAktivan.Checked,
                    Slika = pictureBox2.Image
                });
                MessageBox.Show(Poruke.StudentUspjesnoDodan);
                Close();
            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ValidirajKontrolu(txtIme, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtPrezime, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtEmail, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtIndeks, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(pictureBox2, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(cbGodinaStudija, err, Poruke.ObaveznaVrijednost);
        }
    }
}
