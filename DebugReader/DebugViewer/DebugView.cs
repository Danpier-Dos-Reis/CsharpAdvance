using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugViewer
{
    public partial class DebugView : Form
    {
        public DebugView()
        {
            InitializeComponent();
        }

        private void listenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listenFileToolStripMenuItem.BackColor != Color.Transparent)
            {
                listenFileToolStripMenuItem.BackColor = Color.Transparent;
                listenFileToolStripMenuItem.ForeColor = Color.White;
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    InitialDirectory = "C:\\Users\\Public\\Downloads",
                    Filter = "Log File (*.log)|*.log|All files (*.*)|*.*"
                };

                if (!File.Exists("C:\\Users\\Public\\Downloads\\CopyDebugViewTest.log"))
                {
                    File.Create("C:\\Users\\Public\\Downloads\\CopyDebugViewTest.log");
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    listenFileToolStripMenuItem.BackColor = Color.LightGreen;
                    listenFileToolStripMenuItem.ForeColor = Color.DarkGreen;

                    rtxtboxMain.Text = $"Seleccionamos: {ofd.FileName}" + Environment.NewLine;
                    FileListener(ofd);
                }
            }
        }

        private void FileListener(OpenFileDialog ofd)
        {
            FileSystemWatcher watcher = CreateFileWatcher(ofd);

            //Add event handlers//
            /*The FileSystemWatcher object in C# has several events that you can subscribe
             * to to handle different types of file system changes. Here are the most common
             * events:

            Changed: Triggered when a file or directory in the watched directory has changed.
            This could be due to changes in the file content, renaming of the file or directory,
            etc.
            
            Created: Triggered when a file or directory is created in the watched directory.
            
            Deleted: Triggered when a file or directory is deleted from the watched directory.
            
            Renamed: Triggered when a file or directory is renamed in the monitored directory.
            
            Error: Triggered when an error occurs during the watchdog operation. This could be
            useful for handling unexpected situations.
            
            You can subscribe to these events to take specific actions in response to changes to
            the file system you are monitoring. Here is an example of how to subscribe to these
            events:
             */

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            //watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);


            // Begin watching.
            /*That line of code triggers event monitoring on the FileSystemWatcher
             * object called watcher. When you set EnableRaisingEvents to true, you
             * are telling the watcher to start watching the specified directory and
             * file for events you have configured for it, such as changes, deletions,
             * renames, etc.*/
            watcher.EnableRaisingEvents = true;


        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                //When file changes I get its content
                string readContent = File.ReadAllText(e.FullPath);


                /*ERROR: Cross-thread operation not valid
                 * The "Cross-thread operation not valid" error means that you are trying
                 * to access a UI (interfaz de usuario) control (in this case, rtxtboxMain)
                 * from a thread other than the thread in which it was created. In Windows
                 * Forms applications, UI controls should be accessed only from the thread in
                 * which they were created, generally known as the "UI thread" or "main thread.
                 * 
                 * To resolve this issue, you must ensure that the UI control update is done in
                 * the main thread. You can achieve this by using the control's Invoke or
                 * BeginInvoke method, which executes an action on the main thread.
                 */

                //Porque OnChange se ejecutará en otro hilo y no en el principal debo
                //usar invoke() para modificar textBox en el thread principal.
                Invoke(new Action(() => { rtxtboxMain.Text = readContent; }));
            }
        }

        private FileSystemWatcher CreateFileWatcher(OpenFileDialog ofd)
        {
            return new FileSystemWatcher()
            {
                Path = Path.GetDirectoryName(ofd.FileName),
                Filter = Path.GetFileName(ofd.FileName)

            };
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtboxMain.Text = "";
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Text File|*.txt",
                Title = "Save log content",
                FileName = "DebugLog.txt",
                InitialDirectory = "C:\\Users\\Public\\Downloads"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try {
                    if(File.Exists(sfd.FileName)) { File.Delete(sfd.FileName); }
                    File.WriteAllText(sfd.FileName, rtxtboxMain.Text);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
