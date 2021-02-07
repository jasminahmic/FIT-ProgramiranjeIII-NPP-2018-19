using DLWMS.WinForms.I;
using DLWMS.WinForms.II;
using DLWMS.WinForms.III;
using DLWMS.WinForms.V;
using DLWMS.WinForms.VII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmGlavna());
        }
    }
}
