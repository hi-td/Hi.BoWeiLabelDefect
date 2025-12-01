/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Home
* 机器名称：HLZN
* 命名空间：VisionPlatform.多线插.PLC交互窗口
* 文 件 名：Home
* 创建时间：2024/11/8 15:57:18
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
using Newtonsoft.Json.Linq;

using VisionPlatform.Auxiliary;


namespace VisionPlatform.多线插.PLC交互窗口
{
    public partial class Home : Form
    {
        private Index CurrentUCIndex = Index.btn_Home;
        private IPlc plc;
        private SynchronizationContext context;
        private Manual manual;
        private Axises axises;
        private System.Timers.Timer timer;
        private bool isAction = false;
        private List<Address> addresses;
        private Color[] handleColor = [SystemColors.Control, Color.Lime];
        private string[] stopStatus = ["停止中", "停止"];
        private string[] dadianStatus = ["打点功能开启", "打点功能关闭"];
       
        private Color[] initColor = [
            SystemColors.Control,Color.Lime];
        private bool[] switchStatus = [false, false, false, false, false, false];
        private bool[] switchStatus1 = [false];
        //存储Led亮灭的状态图片
        private Image GenImage = Properties.Resources.io_led_on16_16;
        public Home(IPlc plc)
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            this.plc = plc;
            timer = new System.Timers.Timer(200);
            timer.Elapsed += Timer_Elapsed;
            addresses = new List<Address>();
            foreach (var item in Controls)
            {
                if (item is Button button)
                {
                    if (button.Tag == null)
                    {
                        button.Click += Button_Click;
                    }
                    else
                    {
                        var index = Convert.ToUInt16(button.Tag);
                        if (button.Name.Contains("M"))
                        {
                            button.MouseDown += Button_MouseDown;
                            button.MouseUp += Button_MouseUp;
                        }
                        else
                        {
                            button.Click += Button_Click;
                            var addr = new Address(SoftType.M, index, DataType.Bit);
                            addresses.Add(addr);
                        }
                    }
                }

                if (item is TextBox textBox)
                {
                    if (textBox.Tag != null)
                    {
                        var index = Convert.ToUInt16(textBox.Tag);
                        textBox.Click += TextBox_Click;
                        Address addr;
                        if (textBox.Name.Contains("D"))
                        {
                            index = Convert.ToUInt16(textBox.Tag);
                            addr = new Address(SoftType.D, index, DataType.Int32);
                        }
                        else if (textBox.Name.Contains("F"))
                        {
                            index = Convert.ToUInt16(textBox.Tag);
                            addr = new Address(SoftType.D, index, DataType.Int32, 3);
                        }
                        else
                        {
                            index = Convert.ToUInt16(textBox.Tag);
                            addr = new Address(SoftType.D, index, DataType.Single, decimalPlace: 3);
                        }
                        addresses.Add(addr);
                    }
                }

                if (item is Label label)
                {
                    if (label.Tag != null)
                    {
                        var index = Convert.ToUInt16(label.Tag);
                        Address addr;
                        index = Convert.ToUInt16(label.Tag);
                        addr = new Address(SoftType.D, index, DataType.Int16);
                        addresses.Add(addr);
                    }
                }

                if (item is PictureBox pictureBox)
                {
                    if (pictureBox.Tag != null)
                    {
                        var index = Convert.ToUInt16(pictureBox.Tag);
                        var addr = new Address(SoftType.M, index, DataType.Bit);
                        addresses.Add(addr);
                    }
                }
            }
            addresses = addresses.DistinctAndSort();
            Load += Home_Load;
            FormClosed += Home_FormClosed;
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var content = string.Empty;
                if (textBox.Name.Contains("D"))
                {
                    //弹出输入候选框
                    content = sender.Input(_point: 0);
                }
                else
                {
                    //弹出输入候选框
                    content = sender.Input(_point: 3);
                }
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
                            if (textBox.Name.Contains("D"))
                            {
                                index = Convert.ToUInt16(textBox.Tag);
                                addr = new Address(SoftType.D, index, DataType.Int32);
                                addr.Value = value;
                            }
                            else if (textBox.Name.Contains("F"))
                            {
                                index = Convert.ToUInt16(textBox.Tag);
                                addr = new Address(SoftType.D, index, DataType.Int32, 3);
                                addr.Value = value;
                            }
                            else
                            {
                                index = Convert.ToUInt16(textBox.Tag);
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

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            isAction = false;
            timer.Stop();
            //FormMainUI.M31.Value = 0;
            //plc.WriteDevice(FormMainUI.M31);
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

        private void Home_Load(object sender, EventArgs e)
        {
            if (null == manual || manual.IsDisposed)
            {
                manual = new Manual(plc);
                manual.Dock = DockStyle.Fill;
            }
            isAction = true;
            timer.Start();
            CurrentUCIndex = Index.btn_Home;
            InitBackColor();
            pnl_Load.Controls.Clear();
            btn_Home.BackColor = Color.Yellow;
            pnl_Load.Controls.Add(manual);
            manual.BringToFront();
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
                            ////自动
                            //var hashcode = addresses[(int)AddrIndex.M0].GetHashCode();
                            //switchStatus[(int)AddrIndex.M0] = Convert.ToBoolean(value[hashcode].Value);
                            ////暂停
                            //hashcode = addresses[(int)AddrIndex.M2].GetHashCode();
                            //switchStatus[(int)AddrIndex.M2] = Convert.ToBoolean(value[hashcode].Value);
                            //停止
                            var hashcode = addresses[(int)AddrIndex.M4].GetHashCode();
                            switchStatus[(int)AddrIndex.M4] = Convert.ToBoolean(value[hashcode].Value);
                            //button5.BackColor = switchStatus[(int)AddrIndex.M4] ? handleColor[1] : initColor[0];
                            //button5.Text = switchStatus[(int)AddrIndex.M4] ? stopStatus[0] : stopStatus[1];
                            Address addr1;
                            //上电回原关闭
                            var index1 = Convert.ToUInt16(Sbutton9.Tag);
                            var buttonAddr1 = addresses.FirstOrDefault(x => x.Index == index1 && x.SoftType == SoftType.M);
                            if (buttonAddr1 != null)
                            {
                                hashcode = buttonAddr1.GetHashCode();
                                if (value.TryGetValue(hashcode, out addr1))
                                {
                                    Sbutton9.BackColor = Convert.ToBoolean(addr1.Value) ? handleColor[1] : handleColor[0];
                                }
                                var LimitStatus1 = Convert.ToBoolean(addr1.Value);
                                Sbutton9.Text = LimitStatus1 ? "上电回原开启" : "上电回原关闭";
                                switchStatus1[0] = Convert.ToBoolean(addr1.Value);
                            }
                            
                            //hashcode = addresses[(int)AddrIndex.M1050].GetHashCode();
                            //switchStatus[(int)AddrIndex.M1050] = Convert.ToBoolean(value[hashcode].Value);
                            //Sbutton9.BackColor = switchStatus[(int)AddrIndex.M1050] ? handleColor[1] : handleColor[0];
                            //Sbutton9.Text = switchStatus[(int)AddrIndex.M1050] ? "上电回原开启" : "上电回原关闭";
                            ////上电回原关闭
                            //hashcode = addresses[(int)AddrIndex.M32].GetHashCode();
                            //switchStatus[(int)AddrIndex.M32] = Convert.ToBoolean(value[hashcode].Value);
                            //button1.BackColor = switchStatus[(int)AddrIndex.M32] ? handleColor[1] : handleColor[0];
                            //button1.Text = switchStatus[(int)AddrIndex.M32] ? dadianStatus[1] : dadianStatus[0];
                            //状态
                            //hashcode = addresses[(int)AddrIndex.D10].GetHashCode();
                            foreach (var ctrl in Controls)
                            {

                                if (ctrl is Button button && button.Tag != null && button.Name.Contains("M"))
                                {
                                    ushort index = Convert.ToUInt16(button.Tag);
                                    var buttonAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                    if (buttonAddr != null)
                                    {
                                        hashcode = buttonAddr.GetHashCode();
                                        if (value.TryGetValue(hashcode, out var addr))
                                        {
                                            button.BackColor = Convert.ToBoolean(addr.Value) ? handleColor[1] : handleColor[0];
                                        }
                                    }
                                }

                                if (ctrl is TextBox textBox && textBox.Tag != null)
                                {
                                    ushort index = Convert.ToUInt16(textBox.Tag);

                                    var textBoxAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.D);
                                   
                                    if (textBoxAddr != null)
                                    {
                                        hashcode = textBoxAddr.GetHashCode();
                                        if (value.TryGetValue(hashcode, out var addr))
                                        {
                                            textBox.Text = addr.Value.ToString();
                                        }
                                    }
                                }

                                if (ctrl is PictureBox pictureBox && pictureBox.Tag != null)
                                {
                                    var index = Convert.ToUInt16(pictureBox.Tag);
                                    var pictureBoxAddr = addresses.FirstOrDefault(x => x.Index == index && x.SoftType == SoftType.M);
                                    if (pictureBoxAddr != null)
                                    {
                                        hashcode = pictureBoxAddr.GetHashCode();
                                        bool result = false;
                                        if (value.TryGetValue(hashcode, out var addr))
                                        {
                                            result = Convert.ToBoolean(addr.Value);
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
                    catch (Exception ex)
                    {
                        ex.Error();
                    }
                }
                Post(Anonymous, this);
                Application.DoEvents();
            }
        }

        public enum AddrIndex
        {
            M4 = 0,
            M1050 = 3,
            //M32 = 2,
            //D10 = 5
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag != null)
                {
                    var index = Convert.ToUInt16(button.Tag);
                    var address = new Address(SoftType.M, index, DataType.Bit);
                    var valueIndex = (int)($"M{index}".ToEnum<AddrIndex>());
                    if (index == 4)
                    {
                        address.Value = 1;
                    }
                    else
                    {
                        if (index == 1050 )
                        {
                            address.Value = !switchStatus1[0];
                        }
                        else
                        {
                            address.Value = !switchStatus[valueIndex];

                        }
                    }
                    plc.WriteDevice(address);
                }
                else if (Enum.TryParse(button.Name, out Index index))
                {
                    InitBackColor();
                    UCLoad(index);
                    button.BackColor = Color.Yellow;
                }
            }
        }

        private void UCLoad(Index index)
        {
            void Anonymous(object state)
            {
                try
                {
                    if (state is Index index && index != CurrentUCIndex)
                    {
                        CurrentUCIndex = index;

                        pnl_Load.Controls.Clear();
                        switch (index)
                        {
                            case Index.btn_Home:
                                if (null == manual || manual.IsDisposed)
                                {
                                    manual = new Manual(plc);
                                    manual.Dock = DockStyle.Fill;
                                }
                                pnl_Load.Controls.Add(manual);
                                manual.BringToFront();
                                break;
                            case Index.btn_Axis:
                                if (null == axises || axises.IsDisposed)
                                {
                                    axises = new Axises(plc);
                                    axises.Dock = DockStyle.Fill;
                                }
                                pnl_Load.Controls.Add(axises);
                                axises.BringToFront();
                                break;
                            default:
                                if (null == manual || manual.IsDisposed)
                                {
                                    manual = new Manual(plc);
                                    manual.Dock = DockStyle.Fill;
                                }
                                pnl_Load.Controls.Add(manual);
                                manual.BringToFront();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Error();
                }
            }
            Post(Anonymous, index);
        }


        private void InitBackColor()
        {
            foreach (var item in Controls)
            {
                if (item is Button button)
                {
                    if (button.Name.Contains("_"))
                    {
                        button.BackColor = Color.Aqua;
                    }
                }
            }
        }
        private enum Index
        {
            btn_Home,
            btn_Axis,
        }

        public virtual Result Post(SendOrPostCallback d, object state)
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
