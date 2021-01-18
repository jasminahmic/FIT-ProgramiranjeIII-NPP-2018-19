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
    }
}
