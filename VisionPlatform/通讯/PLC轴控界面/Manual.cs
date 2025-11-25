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
using Hi.Ltd;
using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using Hi.Ltd.Windows;
using Hi.Ltd.Windows.Components;
using Hi.Ltd.Windows.Forms;
using Hi.Ltd.Windows.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VisionPlatform.Auxiliary;
namespace VisionPlatform.多线插.PLC交互窗口
{
    public partial class Manual : UserControl
    {
        private IPlc plc;
        private SynchronizationContext context;
        private System.Timers.Timer timer;
        private bool isAction = false;
        private List<Address> addresses;
        //存储Led亮灭的状态图片
        private Image GenImage = Properties.Resources.red_button_on16_16;

        private Color[] GenColors = [SystemColors.Control, Color.Lime];

        private bool LimitStatus = false;
        public Manual(IPlc plc)
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            this.plc = plc;
            timer = new System.Timers.Timer(100);
            addresses = new List<Address>();
            foreach (var ctrl in Controls)
            {
                if (ctrl is GroupBox group)
                {
                    foreach (var item in group.Controls)
                    {
                        if (item is HButton subbutton)
                        {
                            subbutton.MouseDown += Button_MouseDown;
                            subbutton.MouseUp += Button_MouseUp;
                            if (subbutton.Tag != null)
                            {
                                var index = Convert.ToUInt16(subbutton.Tag);
                                var addr = new Address(SoftType.M, index, DataType.Bit);
                                addresses.Add(addr);
                            }
                        }

                        if (item is TextBox textBox)
                        {
                            if (textBox.Tag != null)
                            {
                                ushort index = 0;
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
                                var addr = new Address(SoftType.D, index, DataType.Single, 3);
                                addresses.Add(addr);
                                textBox.Click += TextBox_Click;
                            }
                        }

                        if (item is PictureBox pictureBox)
                        {
                            if (pictureBox.Tag != null)
                            {
                                var index = Convert.ToUInt16(pictureBox.Tag);
                                var addr = new Address(SoftType.M, index, DataType.Bit);
                                addresses.Add(addr);
                                ushort next = (ushort)(index + 1);
                                addr = new Address(SoftType.M, next, DataType.Bit);
                                addresses.Add(addr);
                            }

                        }
                    }
                }
            }
            //对地址进行排序
            addresses = addresses.DistinctAndSort();

        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is HButton button)
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
            if (sender is HButton button)
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
                            int hashcode = 0;
                            Address addr;
                            foreach (var ctrl in Controls)
                            {
                                if (ctrl is GroupBox group)
                                {
                                    foreach (var item in group.Controls)
                                    {
                                        if (item is HButton button && button.Tag != null)
                                        {
                                            ushort index = Convert.ToUInt16(button.Tag);
                                            var buttonAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                            if (buttonAddr != null)
                                            {
                                                hashcode = buttonAddr.GetHashCode();
                                                if (value.TryGetValue(hashcode, out addr))
                                                {
                                                    if (button.Appearances?.Count == 2)
                                                    {
                                                        foreach (ButtonAppearance app in button.Appearances)
                                                        {
                                                            if (app.State == addr.Value.ToInt32())
                                                            {
                                                                button.BackgroundImage = app.BackgroundImage;
                                                                button.BackColor = app.BackColor;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {

                                            }

                                        }

                                        if (item is TextBox textBox && textBox.Tag != null)
                                        {
                                            ushort index = 0;
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
                                            else
                                            {

                                            }
                                        }

                                        if (item is PictureBox pictureBox && pictureBox.Tag != null)
                                        {
                                            var index = Convert.ToUInt16(pictureBox.Tag);
                                            var pictureBoxAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                            if (pictureBoxAddr != null)
                                            {
                                                hashcode = pictureBoxAddr.GetHashCode();
                                                bool result = false;
                                                if (value.TryGetValue(hashcode, out addr))
                                                {
                                                    result = Convert.ToBoolean(addr.Value);
                                                }
                                                if (value.TryGetValue(hashcode + 1, out addr))
                                                {
                                                    result |= Convert.ToBoolean(addr.Value);
                                                }
                                                pictureBox.Image = result ? GenImage : null;
                                            }
                                            else
                                            {

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
                if (timer == null)
                {
                    timer = new System.Timers.Timer(100);
                }
                timer.Elapsed += Timer_Elapsed;
                isAction = true;
                timer.Start();
            }
            else
            {
                timer.Elapsed -= Timer_Elapsed;
                isAction = false;
                timer.Stop();
                timer = null;
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
