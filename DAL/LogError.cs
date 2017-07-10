using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Clase para loguear errores.
    /// </summary>
    public class LogError
    {
        #region Propiedades

        public Int32 Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string User { get; set; }
        public string UserLog { get; set; }
        public string MachineName { get; set; }
        public string IpAddress { get; set; }
        public string MethodName { get; set; }
        public string TypeError { get; set; }
        public string Error { get; set; }
        public Exception Exception { get; set; }

        #endregion Propiedades

        #region Constructor

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public LogError()
        {
        }

        #endregion Constructor

        #region Métodos Públicos, Internos y Privados

        /// <summary>
        /// Método que crea un archivo .txt y un registro en la base con datos del error.
        /// </summary>
        /// <param name="ex">La excepción que está arrojando el error.</param>
        /// <param name="methodName">El nombre del método en el que ocurrió el error.</param>
        /// <param name="userLog">El usuario logueado en a aplicación.</param>
        /// <param name="ipAddress">El número de ip.</param>
        public static void CreateLog(Exception ex, string methodName, string userLog, string ipAddress)
        {
            LogError logError = CreateLogError(ex, methodName, userLog, ipAddress);
            
            CreateTxtLogFile(logError);

            CreateDbLog(logError);
        }

        private static LogError CreateLogError(Exception ex, string methodName, string userLog, string ipAddress)
        {
            LogError logError = new LogError();
            logError.Fecha = DateTime.Now;
            logError.User = Environment.UserName;
            logError.UserLog = userLog;
            logError.MachineName = Environment.MachineName;
            logError.IpAddress = ipAddress;
            logError.MethodName = methodName;
            logError.TypeError = ex.GetType().ToString();
            logError.Error = ex.Message;
            logError.Exception = ex;

            return logError;
        }

        private static void CreateTxtLogFile(LogError logError)
        {
            try
            {
                string currentPath = AppDomain.CurrentDomain.BaseDirectory;
                string logPath = currentPath.Replace(@"bin\Debug\", string.Empty);
                //cuando logging de usr este hecho, tendría que haber una carpeta por usr
                logPath += @"Logs\";
                string error = "";
                if (!Directory.Exists(logPath))
                    Directory.CreateDirectory(logPath);

                string date = logError.Fecha.Year + "_" + logError.Fecha.ToString("MM") + "_" + logError.Fecha.ToString("dd");
                string fileName = logPath + @"LogError_" + date;

                StreamWriter sw = new StreamWriter(fileName + ".txt", true);
                error += "------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                error += Environment.NewLine;
                error += "Fecha: " + logError.Fecha.ToString("dd/MM/yyyy") + " " + logError.Fecha.ToString("HH") + ":" + logError.Fecha.ToString("mm") + ":" + logError.Fecha.ToString("sss");
                error += Environment.NewLine;
                error += "User: " + logError.User + "\t\t\t";
                error += "Machine Name: " + logError.MachineName + "\t\t\t";
                error += "Ip Address: " + logError.IpAddress;
                error += Environment.NewLine;
                error += "Método: " + logError.MethodName + "\t\t\t";
                error += "UserLog en App: " + logError.UserLog + "\t\t\t";
                error += "Tipo de Error: " + logError.TypeError;
                error += Environment.NewLine;
                error += "Mensaje Excepción: " + Environment.NewLine + logError.Error;
                error += Environment.NewLine;
                error += "Excepción: " + Environment.NewLine + logError.Exception;
                error += Environment.NewLine;
                error += "------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                error += Environment.NewLine;
                error += Environment.NewLine;
                error += Environment.NewLine;
                sw.Write(error);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private static void CreateDbLog(LogError logError)
        {
            try
            {
                //TODO: Acá habría que llamar al método que graba los logs en la bd tb!!
            }
            catch (Exception ex)
            {
            }
        }

        private void SpGestionLog(LogError log)
        {

        }

        #endregion Métodos Públicos, Internos y Privados
    }
}
