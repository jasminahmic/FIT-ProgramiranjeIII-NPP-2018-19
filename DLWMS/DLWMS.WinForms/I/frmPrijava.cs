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
    }

    public class Validator
    {
        public static bool ValidirajKontrolu(Control kontrola, ErrorProvider err, string poruka)
        {
            if (kontrola is TextBox)
            {
                if (string.IsNullOrEmpty(kontrola.Text))
                {
                    err.SetError(kontrola, poruka);
                    return false;
                }
            }
            else if (kontrola is ComboBox)
            {
                var cb = kontrola as ComboBox;
                if (string.IsNullOrEmpty(cb.Text))
                {
                    err.SetError(kontrola, poruka);
                    return false;
                }
            }
            else if (kontrola is PictureBox)
            {
                var pb = kontrola as PictureBox;
                if (pb.Image == null)
                {
                    err.SetError(kontrola, poruka);
                    return false;
                }
            }
            err.Clear();
            return true;
        }
    }
}
