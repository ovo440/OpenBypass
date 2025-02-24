using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenBypass
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag = false;
            Mutex mutex = new Mutex(false, "OpenBypass.exe", out flag);
            try
            {
                if (flag)
                {
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Home());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message, "ERROR Message", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                else
                {
                    MessageBox.Show("An application instance is already running", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            finally
            {
                if (mutex != null)
                {
                    mutex.Close();
                    mutex = null;
                }
            }
        }
    }
}
