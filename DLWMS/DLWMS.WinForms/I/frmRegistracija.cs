using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.I
{
    public partial class frmRegistracija : Form
    {
        public frmRegistracija()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSačuvaj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                InMemoryDB.Korisnici.Add(new Korisnik()
                {
                    Id = InMemoryDB.Korisnici.Count + 1,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    DatumRodjenja = dtpDatumRodjenja.Value,
                    KorisnickoIme = txtKorisnickoIme.Text,
                    Lozinka = txtLozinka.Text,
                    Aktivan = cbAktivan.Checked
                });
                MessageBox.Show(Poruke.KorisnikUspjesnoDodan);
                OcistiFormu();
            }
        }

        private void OcistiFormu()
        {
            txtIme.Text = txtKorisnickoIme.Text = txtLozinka.Text = txtPrezime.Text = "";
            cbAktivan.Checked = false;
        }

        private bool ValidirajUnos()
        {
            return Validator.ValidirajKontrolu(txtIme, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtPrezime, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtKorisnickoIme, err, Poruke.ObaveznaVrijednost) &&
                Validator.ValidirajKontrolu(txtLozinka, err, Poruke.ObaveznaVrijednost);
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            txtKorisnickoIme.Text = $"{txtIme.Text}.{txtPrezime.Text}".ToLower();
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            txtKorisnickoIme.Text = $"{txtIme.Text}.{txtPrezime.Text}".ToLower();
        }

        private string GenerisiLozinku(int brojZnakova = 15)
        {
            string novaLozinka = "";
            string dozvoljeniZnakovi = "vgyaopjgaqgfj912571085!?-._djiwmfcko";
            Random random = new Random();
            for (int i = 0; i < brojZnakova; i++)
                novaLozinka += dozvoljeniZnakovi[random.Next(0, dozvoljeniZnakovi.Length)];
            return novaLozinka;
        }

        private void frmRegistracija_Load(object sender, EventArgs e)
        {
            txtLozinka.Text = GenerisiLozinku();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbAktivan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpDatumRodjenja_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLozinka_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKorisnickoIme_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
