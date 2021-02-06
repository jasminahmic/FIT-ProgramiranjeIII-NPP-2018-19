using DLWMS.WinForms.III;
using DLWMS.WinForms.IV;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.VII
{
    public partial class frmIzvjestaji : Form
    {
        private dtoStudentPrint student;

        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        public frmIzvjestaji(dtoStudentPrint student) : this()
        {
            this.student = student;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Indeks", student?.Indeks));
            rpc.Add(new ReportParameter("ImePrezime", student?.ImePrezime));

            dsDLWMS.PolozeniDataTable tblPolozeni = new dsDLWMS.PolozeniDataTable();
            //foreach (var studenti in student.Polozeni)
            //{
            //    var red = tblPolozeni.NewPolozeniRow();
            //    red.Id = studenti.Id;
            //    red.Naziv = studenti.Predmeti.Naziv;
            //    red.Ocjena = studenti.Ocjena;
            //    red.Datum = studenti.Datum.ToString();
            //    tblPolozeni.Rows.Add(red);
            //}

            for (int i = 0; i < student.Polozeni.Count; i++)
            {
                var red = tblPolozeni.NewPolozeniRow();
                var studenti = student.Polozeni[i];
                red.Id = studenti.Id;
                red.Naziv = studenti.Predmeti.Naziv;
                red.Ocjena = studenti.Ocjena;
                red.Datum = studenti.Datum.ToString();
                tblPolozeni.Rows.Add(red);
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsPolozeni";
            rds.Value = tblPolozeni;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
