using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesTrabajo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-AR");


            //LogHandler.Init(typeof(Program).Namespace, LoggingConfiguration.Local);
            //cdo el logging este hecho habría que loguear en la carpeta de logs del usr la hs a la que inició la app
            //(en un base tb!)
            //limpiar la carpeta de logs con los .txt que tengan más de tanto meses de antiguedad.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            using (Login login = new Login())
            {
                if (login.ShowDialog() == DialogResult.OK)
                    Application.Run(new Contenedor());
                else
                    Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception as Exception;
            string hostName = Dns.GetHostName();
            string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
            MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                Exception ex = e.ExceptionObject as Exception;
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            //cdo el logging este hecho habría que loguear en la carpeta de logs del usr la hs a la que cerró la app
        }
    }
}
