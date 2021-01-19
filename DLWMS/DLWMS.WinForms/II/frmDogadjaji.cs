using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.II
{
    public partial class frmDogadjaji : Form
    {
        delegate void Notifikacije(string poruka);
        event Notifikacije SMS;

        public frmDogadjaji()
        {
            InitializeComponent();
        }

        private void frmDogadjaji_Load(object sender, EventArgs e)
        {

        }

        private void BHTelecom(string poruka)
        {
            MessageBox.Show($"BHTelecom -> {poruka}");
        }
        private void HTEronet(string poruka)
        {
            MessageBox.Show($"HTEronet -> {poruka}");
        }
        private void MTel(string poruka)
        {
            MessageBox.Show($"MTel -> {poruka}");
        }

        private void cbBHTelecom_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBHTelecom.Checked)
                SMS += BHTelecom;
            else
                SMS -= BHTelecom;
        }

        private void cbHTEronet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHTEronet.Checked)
                SMS += HTEronet;
            else
                SMS -= HTEronet;
        }

        private void cbMTel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMTel.Checked)
                SMS += MTel;
            else
                SMS -= MTel;
        }

        private void btnPosalji_Click(object sender, EventArgs e)
        {
            SMS?.Invoke(txtPoruka.Text);
        }

        public class Student
        {
            public List<int> Ocjene { get; set; } = new List<int>() { 6, 8, 6 };

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < Ocjene.Count; i++)
                    yield return Ocjene[i];
            }

        }

        private void btnYield_Click(object sender, EventArgs e)
        {
            var student = new Student();
            foreach (var ocjene in student)
                MessageBox.Show($"Ocjena -> {ocjene}");
            
        }
    }
}
