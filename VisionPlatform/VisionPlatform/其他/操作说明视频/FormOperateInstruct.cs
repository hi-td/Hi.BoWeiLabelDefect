using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace VisionPlatform
{
    public partial class FormOperateInstruct : Form
    {
        VlcPlayerBase VlcPlayer;
        public FormOperateInstruct()
        {
            InitializeComponent();
            try
            {
                VlcPlayer = new VlcPlayerBase("");
                IntPtr render_wnd = vlcControl.Handle;
                VlcPlayer.SetRenderWindow((int)render_wnd);
                VlcPlayer.LoadFile(GlobalPath.SavePath.VideoPath);
                int hour = (int)VlcPlayer.Duration / 3600;    //分
                int minute = (int)VlcPlayer.Duration / 60;    //分
                int second = (int)VlcPlayer.Duration % 60;    //秒
                label_totalTime.Text = hour.ToString()+ ":" + minute.ToString() + ":" + second.ToString();
                trackBar.Maximum = (int)VlcPlayer.Duration;
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            timer1.Start();
        }

        private void vlcControl_VlcLibDirectoryNeeded(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            try
            {
                var currentAssembly = Assembly.GetEntryAssembly();
                var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
                if (currentDirectory == null)
                {
                    return;
                }
                if (IntPtr.Size == 4)
                {
                    e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x86"));
                }
                else
                {
                    e.VlcLibDirectory = new DirectoryInfo(Path.GetFullPath(@".\libvlc\win-x64"));
                }
                if (!e.VlcLibDirectory.Exists)
                {
                    var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                    folderBrowserDialog.Description = "Select Vlc libraries folder.";
                    folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                    folderBrowserDialog.ShowNewFolderButton = true;
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }


        private void but_Play_Click(object sender, EventArgs e)
        {
            VlcPlayer.Play();
        }

        private void but_Pause_Click(object sender, EventArgs e)
        {
            VlcPlayer.Pause();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int hour = (int)VlcPlayer.GetPlayTime() / 3600;    //分
            int minute = (int)VlcPlayer.GetPlayTime() / 60;    //分
            int second = (int)VlcPlayer.GetPlayTime() % 60;    //秒
            label_nowTime.Text = hour.ToString() + ":" + minute.ToString() + ":" + second.ToString();
            trackBar.Value = (int)VlcPlayer.GetPlayTime();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            VlcPlayer.Pause();
            int value = trackBar.Value;
            VlcPlayer.SetPlayTime(value);
            VlcPlayer.Play();
        }
    }
}
