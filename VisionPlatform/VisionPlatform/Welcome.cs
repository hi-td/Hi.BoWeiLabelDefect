/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Welcome
* 机器名称：HLZN
* 命名空间：VisionPlatform
* 文 件 名：Welcome
* 创建时间：2022/12/5 18:50:56
* 作    者：Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2022  保留所有权利.
***********************************************************/

using System.ComponentModel;
using System.Threading;
using System;
using System.Windows.Forms;
using Hi.Ltd.Threading;
using Hi.Ltd.Win32;
namespace VisionPlatform
{
    /// <summary>
    ///
    /// </summary>
    public partial class Welcome : Form
    {
        private readonly System.Timers.Timer ti_Date = new System.Timers.Timer(10);
        private readonly SynchronizationContext context;
        private readonly FormMainUI mainForm;
        public Welcome(FormMainUI _mainForm)
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
           // pb_Logo.Image = dgrl;
            mainForm = _mainForm;
            pgb_Welcome.Maximum = 100;
            pgb_Welcome.Minimum = 0;
            ti_Date.Elapsed += Ti_Date_Elapsed;
            MouseDown += Welcome_MouseDown;
            ti_Date.Start();
        }
        public Welcome(BackgroundWorker worker, FormMainUI _mainForm) : this(_mainForm)
        {
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void Welcome_MouseDown(object sender, MouseEventArgs e)
        {
            User32.ReleaseCapture();
            User32.SendMessage(Handle, 0xA1, (IntPtr)2, (IntPtr)0);
        }

        private void Ti_Date_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (IsHandleCreated)
            {
                pgb_Welcome.Value(mainForm.progress, context);
                lbl_Content.Text(mainForm.progressTips, context);
                lbl_Progress.Text($"{pgb_Welcome.Value:0.00}%", context);
            }
        }
    }
    






     
}
