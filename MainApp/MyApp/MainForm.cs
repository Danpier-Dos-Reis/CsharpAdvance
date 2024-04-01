using NLog;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace MyApp
{
    public partial class MainForm : Form
    {
        private NLog.Logger _logger;
        public MainForm()
        {
            InitializeComponent();
            ConfigNLogManager();
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            int cero = 0;

            try
            {
                _logger.Info("Start error");
                int hi = 55 / cero;
            }
            catch (Exception ex) { _logger.Error(ex, "Este error es porque no se puede dividir entre cero"); }
            finally
            {
                _logger.Info("Error error");
                NLog.LogManager.Shutdown(); //Apagamos el loggin para que nos permita leerlo
                CopyLoggerFile();
                ConfigNLogManager(); //Volvemos a configurar el logger
            }
        }

        private void btnOpenDebugReader_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = "C:\\Programming Practices\\Csharp Basic Logger\\BuildDirectory\\DebugViewerApp\\Debug\\net8.0-windows",
                Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Task task = new Task(() =>
                {
                    OpenDebugReader(ofd.FileName);
                });
                task.Start();
            }
        }


        #region Methods

        private void CopyLoggerFile()
        {
            FileInfo fiCopy = new FileInfo("C:\\Users\\Public\\Downloads\\CopyDebugViewTest.log");

            if (!fiCopy.Exists)
            {
                FileStream fs = fiCopy.Create();

                Byte[] info = new UTF8Encoding(true).GetBytes(File.ReadAllText("C:\\Users\\Public\\Downloads\\DebugViewTest.log"));

                fs.Write(info, 0, info.Length);

                fs.Close();

            }
            else
            {
                FileStream fs = fiCopy.Open(FileMode.Open, FileAccess.Write);

                Byte[] info = new UTF8Encoding(true).GetBytes(File.ReadAllText("C:\\Users\\Public\\Downloads\\DebugViewTest.log"));

                fs.Write(info, 0, info.Length);

                fs.Close();
            }
        }

        private void OpenDebugReader(string AppName)
        {
            try
            {
                _logger.Info("Open Debug Reader");
                Process.Start(AppName);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { _logger.Info("Close Debug Reader"); }
        }

        private void ConfigNLogManager()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "C:\\Users\\Public\\Downloads\\DebugViewTest.log" };

            // Rules for mapping loggers to targets
            config.AddRule(LogLevel.Debug, LogLevel.Error, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        #endregion

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            FileInfo fiCopy = new FileInfo("C:\\Users\\Public\\Downloads\\CopyDebugViewTest.log");
            FileInfo fiDebug = new FileInfo("C:\\Users\\Public\\Downloads\\DebugViewTest.log");

            if (fiCopy.Exists) { fiCopy.Delete(); }
            if (fiDebug.Exists)
            {
                FileStream fs = fiDebug.Open(FileMode.OpenOrCreate,FileAccess.Write);
                fs.SetLength(0); //Así quitamos todo el contenido dentro del archivo
                fs.Close();
            }
            
        }
    }
}
