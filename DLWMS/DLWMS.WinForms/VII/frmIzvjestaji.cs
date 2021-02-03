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
        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Indeks", "IB200002"));
            rpc.Add(new ReportParameter("ImePrezime", "Denis Music"));

            dsDLWMS.PolozeniDataTable tblPolozeni = new dsDLWMS.PolozeniDataTable();
            for (int i = 0; i < 5; i++)
            {
                dsDLWMS.PolozeniRow red = tblPolozeni.NewPolozeniRow();
                red.Id = i + 1;
                red.Naziv = $"Predmet {i + 1}";
                red.Ocjena = 6;
                red.Datum = DateTime.Now.ToString();
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
