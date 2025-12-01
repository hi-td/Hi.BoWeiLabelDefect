/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：$safeprojectname$
* 机器名称：DELL-CHUSTANGE
* 命名空间：VisionPlatform.多线插.plc交互窗口
* 文 件 名：Axises
* 创建时间：2025/2/6 14:28:22
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2025  保留所有权利.
***********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hi.Ltd;
using Hi.Ltd.Windows.Forms;
using Hi.Ltd.Windows.Interfaces;

namespace VisionPlatform.多线插.PLC交互窗口
{
    public partial class Axises : UserControl
    {
        private int CurrentUCIndex = -1;
        private IPlc plc;
        private AxisZ axisZ;
        //private AxisY axisY;
        //private AxisZ1 axisZ1;
        //private AxisY1 axisY1;
        //private AxisR axisR;
        private AxisT axisT;
        public Axises(IPlc plc)
        {
            InitializeComponent();
            Load += Axises_Load;
            this.plc = plc;
        }
        private void Axises_Load(object sender, EventArgs e)
        {
            if (null == axisZ || axisZ.IsDisposed)
            {
                axisZ = new AxisZ(plc);
                axisZ.Dock = DockStyle.Fill;
            }
            tp_Z.Controls.Clear();
            tp_Z.Controls.Add(axisZ);
            axisZ.BringToFront();
            //this.tp_Y1.Parent = null;
            //this.tp_R.Parent = null;
            //this .tp_Y.Parent = null;
            //this .tp_Z .Parent = null;

        }


        //protected override void OnParentChanged(EventArgs e)
        //{
        //    base.OnParentChanged(e);
        //    if (this.Parent != null)
        //    {
        //        htc_Axis.SelectedTab = tp_Z1;
        //    }
        //}
        private void InitPage()
        {
            foreach (TabPage page in htc_Axis.TabPages)
            {
                page.Controls.Clear();
            }
        }
        private void Htc_Axis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is HTabControl control && CurrentUCIndex != control.SelectedIndex)
            {
                InitPage();
                CurrentUCIndex = control.SelectedIndex;
                if (control.SelectedTab == tp_Z)
                {
                    if (null == axisZ || axisZ.IsDisposed)
                    {
                        axisZ = new AxisZ(plc);
                        axisZ.Dock = DockStyle.Fill;
                    }
                    tp_Z.Controls.Add(axisZ);
                    axisZ.BringToFront();
                }
                //else if (control.SelectedTab == tp_Y)
                //{
                //    if (null == axisY || axisY.IsDisposed)
                //    {
                //        axisY = new AxisY(plc);
                //        axisY.Dock = DockStyle.Fill;
                //    }
                //    tp_Y.Controls.Add(axisY);
                //    axisY.BringToFront();
                //}
                //if (control.SelectedTab == tp_Z1)
                //{
                //    if (null == axisZ1 || axisZ1.IsDisposed)
                //    {
                //        axisZ1 = new AxisZ1(plc);
                //        axisZ1.Dock = DockStyle.Fill;
                //    }
                //    tp_Z1.Controls.Add(axisZ1);
                //    axisZ1.BringToFront();
                //}
                //else if (control.SelectedTab == tp_Y1)
                //{
                //    if (null == axisY1 || axisY1.IsDisposed)
                //    {
                //        axisY1 = new AxisY1(plc);
                //        axisY1.Dock = DockStyle.Fill;
                //    }
                //    tp_Y1.Controls.Add(axisY1);
                //    axisY1.BringToFront();
                //}
                //else if (control.SelectedTab == tp_R)
                //{
                //    if (null == axisR || axisR.IsDisposed)
                //    {
                //        axisR = new AxisR(plc);
                //        axisR.Dock = DockStyle.Fill;
                //    }
                //    tp_R.Controls.Add(axisR);
                //    axisR.BringToFront();
                //}
                else if (control.SelectedTab == tp_T)
                {
                    if (null == axisT || axisT.IsDisposed)
                    {
                        axisT = new AxisT(plc);
                        axisT.Dock = DockStyle.Fill;
                    }
                    tp_T.Controls.Add(axisT);
                    axisT.BringToFront();
                }
            }
        }
    }
}
