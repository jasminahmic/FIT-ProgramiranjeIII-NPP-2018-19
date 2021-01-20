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
    public partial class frmPrijava : Form
    {
        public frmPrijava()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                foreach (var korisnik in InMemoryDB.Korisnici)      
                {
                    if (korisnik.KorisnickoIme == txtKorisnickoIme.Text &&
                        korisnik.Lozinka == txtLozinka.Text)
                    {
                        if (korisnik.Aktivan)                              
                            MessageBox.Show($"{Poruke.DobroDosli} {korisnik}");
                        else
                            MessageBox.Show(Poruke.KorisnickiNalogNijeAktivan);
                        return;
                    }
                }
                MessageBox.Show($"{Poruke.KorisnikNePostoji}");
            }
        }

        private bool ValidirajUnos()
        {
            return Validator.ValidirajKontrolu(txtKorisnickoIme, err, Poruke.ObaveznaVrijednost) && 
                   Validator.ValidirajKontrolu(txtLozinka, err, Poruke.ObaveznaVrijednost);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LinkLabelRegistracija_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistracija registracija = new frmRegistracija();
            registracija.Show();
        }
    }
    public class Poruke
    {
        public const string DobroDosli = "Dobro došli ";
        public const string ObaveznaVrijednost = "Obavezna vrijednost!";
        public const string KorisnikNePostoji = "Ne postoji korisnik!";
        public const string KorisnikUspjesnoDodan = "Korisnik uspješno dodan!";
        public const string KorisnickiNalogNijeAktivan = "Korisnički nalog nije aktivan!";
        public const string StudentUspjesnoDodan = "Student uspješno dodan!";
        public const string StudentPodaciUspjesnoModifikovani = "Podaci studenta uspješno modifikovani!";
    }

    public class Validator
    {
        public static bool ValidirajKontrolu(Control kontrola, ErrorProvider err, string poruka)
        {
            bool _setError = false;
            if (kontrola is TextBox && string.IsNullOrEmpty(kontrola.Text))
                _setError = true;
            else if (kontrola is ComboBox && (string.IsNullOrEmpty((kontrola as ComboBox).Text) || (kontrola as ComboBox).SelectedIndex < 0))
                _setError = true;
            else if (kontrola is PictureBox && (kontrola as PictureBox).Image == null)
                _setError = true;
            if (_setError)
            {
                err.SetError(kontrola, poruka);
                return false;
            }
            err.Clear();
            return true;
        }
    }
}
