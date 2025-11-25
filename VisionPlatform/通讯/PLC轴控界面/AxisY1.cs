/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：MainStatus
* 机器名称：HLZN
* 命名空间：VisionPlatform.多线插.PLC交互窗口
* 文 件 名：MainStatus
* 创建时间：2024/11/8 16:04:17
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2024 保留所有权利.
***********************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Hi.Ltd;
using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using Hi.Ltd.Windows;
using Hi.Ltd.Windows.Interfaces;
using VisionPlatform.Auxiliary;
namespace VisionPlatform.多线插.PLC交互窗口
{
    public partial class AxisY1 : UserControl
    {
        private IPlc plc;
        private SynchronizationContext context;
        private System.Timers.Timer timer;
        private bool isAction = false;
        private List<Address> addresses;
        //存储Led亮灭的状态图片
        private Image[] GenImages = [Properties.Resources.io_led_off16_16, Properties.Resources.io_led_on16_16];

        private Color[] GenColors = [SystemColors.Control, Color.Lime];

        private bool LimitStatus = false;
        public AxisY1(IPlc plc)
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            this.plc = plc;
            timer = new System.Timers.Timer(100);
            addresses = new List<Address>();
            foreach (var ctrl in Controls)
            {
                ushort index = 0;
                if (ctrl is GroupBox group)
                {
                    foreach (var item in group.Controls)
                    {
                        if (item is Button subbutton)
                        {
                            if (subbutton.Name.Contains("S"))
                            {
                                subbutton.Click += Button_Click;
                            }
                            else
                            {
                                subbutton.MouseDown += Button_MouseDown;
                                subbutton.MouseUp += Button_MouseUp;
                            }
                            if (subbutton.Tag != null)
                            {
                                index = Convert.ToUInt16(subbutton.Tag);
                                var addr = new Address(SoftType.M, index, DataType.Bit);
                                addresses.Add(addr);
                            }
                        }

                        if (item is PictureBox subpicturebox)
                        {
                            if (subpicturebox.Tag != null)
                            {
                                index = Convert.ToUInt16(subpicturebox.Tag);
                                var addr = new Address(SoftType.M, index, DataType.Bit);
                                addresses.Add(addr);
                            }
                        }

                        if (item is TextBox textBox)
                        {
                            if (textBox.Tag != null)
                            {
                                if (textBox.Tag.ToString().Contains("D"))
                                {
                                    index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                }
                                else if (textBox.Tag.ToString().Contains("F"))
                                {
                                    index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                }
                                var addr = new Address(SoftType.D, index, DataType.Single, 3);
                                addresses.Add(addr);
                                textBox.Click += TextBox_Click;
                            }
                        }
                    }
                }
            }
            //对地址进行排序
            addresses = addresses.DistinctAndSort();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag != null)
                {
                    var index = Convert.ToUInt16(button.Tag);
                    var address = new Address(SoftType.M, index, DataType.Bit);
                    address.Value = !LimitStatus;
                    plc.WriteDevice(address);

                }
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag != null)
                {
                    var index = Convert.ToUInt16(button.Tag);
                    var address = new Address(SoftType.M, index, DataType.Bit);
                    address.Value = 0;
                    plc.WriteDevice(address);

                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag != null)
                {
                    var index = Convert.ToUInt16(button.Tag);
                    var address = new Address(SoftType.M, index, DataType.Bit);
                    address.Value = 1;
                    plc.WriteDevice(address);
                }
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //用于保证在关闭定时器时，能正常关闭，不会重复触发
            if (isAction)
            {
                void Anonymous(object state)
                {
                    try
                    {
                        var res = plc.ReadDeviceRandom(addresses, out var value);

                        if (res == 0)
                        {
                            ushort index = 0;
                            int hashcode = 0;
                            Address addr;
                            ////夹紧气缸
                            //hashcode = M6005.GetHashCode();
                            //if (value.TryGetValue(hashcode, out addr))
                            //{
                            //    button2.BackColor = Convert.ToBoolean(addr.Value) ? GenColors[1] : GenColors[0];
                            //}
                            ////插接气缸
                            //hashcode = M6015.GetHashCode();
                            //if (value.TryGetValue(hashcode, out addr))
                            //{
                            //    button3.BackColor = Convert.ToBoolean(addr.Value) ? GenColors[1] : GenColors[0];
                            //}

                            ////触发拍照
                            //var M100 = addresses.FirstOrDefaultOrDefault(x => x.Index == 100 && x.SoftType == SoftType.M);

                            //if (M100 != null)
                            //{
                            //    hashcode = M100.GetHashCode();
                            //    if (value.TryGetValue(hashcode, out addr))
                            //    {
                            //        button4.BackColor = Convert.ToBoolean(addr.Value) ? GenColors[1] : GenColors[0];
                            //    }
                            //}

                            foreach (var ctrl in Controls)
                            {
                                if (ctrl is GroupBox group)
                                {
                                    foreach (var item in group.Controls)
                                    {
                                        if (item is Button button && button.Tag != null)
                                        {
                                            index = Convert.ToUInt16(button.Tag);
                                            var buttonAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                            if (buttonAddr != null)
                                            {
                                                hashcode = buttonAddr.GetHashCode();
                                                if (value.TryGetValue(hashcode, out addr))
                                                {
                                                    button.BackColor = Convert.ToBoolean(addr.Value) ? GenColors[1] : GenColors[0];
                                                }

                                                if (button.Name.Contains("S"))
                                                {
                                                    LimitStatus = Convert.ToBoolean(addr.Value);
                                                    button.Text = LimitStatus ? "软限位开启" : "软限位关闭";
                                                }
                                            }
                                        }
                                        if (item is PictureBox subpicturebox && subpicturebox.Tag != null)
                                        {
                                            index = Convert.ToUInt16(subpicturebox.Tag);
                                            var subpictureboxAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                            if (subpictureboxAddr != null)
                                            {
                                                hashcode = subpictureboxAddr.GetHashCode();
                                                if (value.TryGetValue(hashcode, out addr))
                                                {
                                                    subpicturebox.Image = Convert.ToBoolean(addr.Value) ? GenImages[1] : GenImages[0];
                                                }
                                            }
                                        }

                                        if (item is TextBox textBox && textBox.Tag != null)
                                        {
                                            if (textBox.Tag.ToString().Contains("D"))
                                            {
                                                index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                            }
                                            else if (textBox.Tag.ToString().Contains("F"))
                                            {
                                                index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                            }
                                            else
                                            {
                                                index = Convert.ToUInt16(textBox.Tag);
                                            }

                                            var textBoxAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.D);
                                            if (textBoxAddr != null)
                                            {
                                                hashcode = textBoxAddr.GetHashCode();
                                                if (value.TryGetValue(hashcode, out addr))
                                                {
                                                    textBox.Text = addr.Value.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Error();
                    }
                }
                Post(Anonymous, this);
                Application.DoEvents();
            }
        }
        private void TextBox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !textBox.ReadOnly)
            {
                //弹出输入候选框
                var content = sender.Input(_point: 3);
                //如果当前未输入任何内容，则取消此次操作
                if (string.IsNullOrEmpty(content)) return;
                if (double.TryParse(content, out var value))
                {
                    try
                    {
                        if (textBox.Tag != null)
                        {
                            ushort index = 0;
                            Address addr;
                            if (textBox.Tag.ToString().Contains("D"))
                            {
                                index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                addr = new Address(SoftType.D, index, DataType.Int32);
                                addr.Value = value;
                            }
                            else
                            {
                                index = Convert.ToUInt16(textBox.Tag.ToString().Substring(1));
                                addr = new Address(SoftType.D, index, DataType.Single, decimalPlace: 3);
                                if (index == 2200)
                                {
                                    if (value > 500)
                                    {
                                        MessageBox.Show("JOG速度超限(设置值不可大于500或小于0)请重新设置！！！！");
                                        return;
                                    }
                                }
                                else if (index == 2274)
                                {
                                    if (value > 500)
                                    {
                                        MessageBox.Show("定位速度速度超限(设置值不可大于500或小于0)请重新设置！！！！");
                                        return;
                                    }
                                }
                                else if (index == 2220)
                                {
                                    if (value > 15000)
                                    {
                                        MessageBox.Show("加减速速度超限(设置值不可大于5000或小于0)请重新设置！！！！");
                                        return;
                                    }
                                }
                                addr.Value = value;
                            }
                            plc.WriteDevice(addr);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Error();
                    }
                }
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
            {
                timer.Elapsed += Timer_Elapsed;
                isAction = true;
                timer.Start();
            }
            else
            {
                timer.Elapsed -= Timer_Elapsed;
                isAction = false;
                timer.Stop();
            }
        }


        protected virtual Result Post(SendOrPostCallback d, object state)
        {
            try
            {
                if (context != null)
                {
                    context.Post(d, state);
                }
                else
                {
                    if (InvokeRequired)
                    {
                        BeginInvoke(d, state);
                    }
                    else
                    {
                        d(state);
                    }
                }
                return Result.Success;
            }
            catch (Exception e)
            {
                return Error.Result(e);
            }
        }
    }
}
