/*------------------------------------------------------------
* CLR版本：4.0.30319.42000
* 类 名 称：Input
* 机器名称：HLZN
* 命名空间：Hi.RL.UC
* 文 件 名：Input
* 创建时间：2022/5/19 17:55:27
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
*------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Hi.Ltd;
using Hi.Ltd.Enumerations;
namespace VisionPlatform.多线插.PLC交互窗口
{
    public partial class Input : Form
    {
        public bool IsCommit { get; set; }
        public string Content { get; set; }

        private readonly double maximum;

        private readonly double minimum;

        private readonly DataType dataType;

        private readonly int point;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int ReleaseCapture();
        public Input(double _maximum = 99999, double _minimum = 0, DataType _dataType = DataType.Int32, int _point = 0)
        {
            InitializeComponent();
            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Click += Button_Click;
                }
            }
            txt_Value.TextChanged += Txt_Value_TextChanged;
            txt_Value.KeyDown += Txt_Value_KeyDown;
            maximum = _maximum;
            minimum = _minimum;
            dataType = _dataType;
            point = _point;
            Load += Input_Load;
            MouseDown += Input_MouseDown;
        }

        private void Input_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 2, 0);
        }

        private void Input_Load(object sender, EventArgs e)
        {
            txt_Value.Text = string.Empty;
            lbl_Maximum.Text = maximum.ToString();
            lbl_Minimum.Text = minimum.ToString();
            lbl_Point.Text = point.ToString();
            switch (dataType)
            {
                case DataType.Bit:
                    btn_One.Enabled = true;
                    btn_Zero.Enabled = true;
                    break;
                case DataType.UInt16:
                case DataType.UInt32:
                    btn_Zero.Enabled = true;
                    btn_One.Enabled = true;
                    btn_Two.Enabled = true;
                    btn_Three.Enabled = true;
                    btn_Four.Enabled = true;
                    btn_Five.Enabled = true;
                    btn_Six.Enabled = true;
                    btn_Seven.Enabled = true;
                    btn_Eight.Enabled = true;
                    if (point > 0)
                    {
                        btn_Point.Enabled = true;
                    }
                    btn_Nine.Enabled = true;
                    break;
                case DataType.Int16:
                case DataType.Int32:
                    btn_Zero.Enabled = true;
                    btn_One.Enabled = true;
                    btn_Two.Enabled = true;
                    btn_Three.Enabled = true;
                    btn_Four.Enabled = true;
                    btn_Five.Enabled = true;
                    btn_Six.Enabled = true;
                    btn_Seven.Enabled = true;
                    btn_Eight.Enabled = true;
                    btn_Nine.Enabled = true;
                    btn_Minus.Enabled = true;
                    if (point>0)
                    {
                        btn_Point.Enabled = true;
                    }
                    break;
                case DataType.Single:
                case DataType.Double:
                    btn_Zero.Enabled = true;
                    btn_One.Enabled = true;
                    btn_Two.Enabled = true;
                    btn_Three.Enabled = true;
                    btn_Four.Enabled = true;
                    btn_Five.Enabled = true;
                    btn_Six.Enabled = true;
                    btn_Seven.Enabled = true;
                    btn_Eight.Enabled = true;
                    btn_Nine.Enabled = true;
                    btn_Minus.Enabled = true;
                    btn_Point.Enabled = true;
                    break;
            }

        }

        private void Txt_Value_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_Value.Text.Trim() != string.Empty)
                {
                    DialogResult = DialogResult.OK;
                    IsCommit = true;
                }
                else
                {
                    MessageBox.Show("当前数值不能为空！", "输入提示");
                }
            }
        }

        private void Txt_Value_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Value.Text))
            {
                if (dataType == DataType.Bit)
                {
                    txt_Value.Text = txt_Value.Text.Trim().Last().ToString();
                    Content = txt_Value.Text.Trim();
                    return;
                }
                if (txt_Value.Text.Length == 1)
                {
                    if (txt_Value.Text.Contains("."))
                    {
                        txt_Value.Text = "0.";
                        txt_Value.Select(txt_Value.Text.Length, 0);
                    }
                    else if (txt_Value.Text.Contains("-"))
                    {
                        txt_Value.Text = string.Empty;
                    }
                    else
                    {
                        var content = ToContent(txt_Value.Text.Trim(),maximum, minimum, dataType, point);
                        if (!string.IsNullOrEmpty(content))
                        {
                            Content = content;
                        }
                        else
                        {
                            txt_Value.Text = Content;
                            txt_Value.Select(txt_Value.Text.Length, 0);
                        }

                    }
                }
                else
                {
                    if (txt_Value.Text.Substring(0, 1) == "0" && !txt_Value.Text.Contains("."))
                    {
                        txt_Value.Text = txt_Value.Text.Substring(1);
                    }
                    var content = ToContent(txt_Value.Text.Trim(),maximum, minimum, dataType, point);

                    if (!string.IsNullOrEmpty(content))
                    {
                        Content = content;
                    }
                    else
                    {
                        txt_Value.Text = Content;
                        txt_Value.Select(txt_Value.Text.Length, 0);
                    }
                }

            }
        }
        private  string ToContent(string value, double maximum = 99999, double minimum = 0, DataType dataType = DataType.Int32, int point = 0)
        {
            var result = string.Empty;
            if (string.IsNullOrEmpty(value)) return result;
            switch (dataType)
            {
                case DataType.Bit:
                    if (value.ToBoolean())
                    {
                        return value;
                    }
                    MessageBox.Show("当前数据类型为布尔型，输入数据有误！（提示：请输入0或1）", "数据格式错误提示");
                    break;
                case DataType.UInt16:
                    if (point == 0)
                    {
                        if (ushort.TryParse(value, out var ust))
                        {
                            if (ust <= maximum && ust >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为16位无符号整数型，输入数据超出限制！", "数据格式错误提示");
                    }
                    else
                    {
                        if (ushort.TryParse(value, out var ust))
                        {
                            if (ust <= maximum && ust >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");
                    }
                    break;
                case DataType.Int16:
                    if (point == 0)
                    {
                        if (short.TryParse(value, out var st))
                        {
                            if (st <= maximum && st >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为16位整数型，输入数据超出限制！", "数据格式错误提示");
                    }
                    else
                    {
                        if (float.TryParse(value, out var st))
                        {
                            if (st <= maximum && st >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");

                    }
                    break;
                case DataType.UInt32:
                    if (point == 0)
                    {
                        if (uint.TryParse(value, out var ut))
                        {
                            if (ut <= maximum && ut >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为无符号32位整数型，输入数据超出限制！", "数据格式错误提示");
                    }
                    else
                    {
                        if (float.TryParse(value, out var ut))
                        {
                            if (ut <= maximum && ut >= minimum && ut >= 0.00f)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");
                    }
                    break;
                case DataType.Int32:
                    if (point == 0)
                    {
                        if (int.TryParse(value, out var it))
                        {
                            if (it <= maximum && it >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为有符号32位整数型，输入数据超出限制！", "数据格式错误提示");
                    }
                    else
                    {
                        if (float.TryParse(value, out var it))
                        {
                            if (it <= maximum && it >= minimum)
                            {
                                return value;
                            }
                        }
                        MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");
                    }
                    break;
                case DataType.Single:
                    if (float.TryParse(value, out var ft))
                    {
                        if (ft <= maximum && ft >= minimum)
                        {
                            return ft.ToString($"f{point}");
                        }
                    }
                    MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");
                    break;
                case DataType.Double:
                    if (double.TryParse(value, out var de))
                    {
                        if (de <= maximum && de >= minimum)
                        {
                            return de.ToString($"f{point}");
                        }
                    }
                    MessageBox.Show("当前数据类型为单精度浮点型，输入数据超出限制！", "数据格式错误提示");
                    break;
            }
            return result;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (Enum.TryParse(button.Name, out ButtonIndex ButtonIndex))
                {
                    switch (ButtonIndex)
                    {
                        case ButtonIndex.btn_Backspace:
                            if (txt_Value.Text.Trim() != string.Empty)
                            {
                                txt_Value.Text = txt_Value.Text.Substring(0, txt_Value.Text.Length - 1);
                            }
                            break;

                        case ButtonIndex.btn_Cancel:
                            txt_Value.Text = "0";
                            DialogResult = DialogResult.Cancel;
                            break;
                        case ButtonIndex.btn_Clear:
                            txt_Value.Text = string.Empty;
                            break;

                        case ButtonIndex.btn_Minus:
                            if ((txt_Value.Text.Contains('0') && txt_Value.Text.Length == 1) || txt_Value.Text.Trim() == string.Empty)
                            {
                                return;
                            }
                            else if (txt_Value.Text.Contains('-'))
                            {
                                txt_Value.Text = txt_Value.Text.Substring(1);
                            }
                            else
                            {
                                txt_Value.Text = txt_Value.Text.Insert(0, "-");
                            }
                            break;

                        case ButtonIndex.btn_Point:
                            if (!txt_Value.Text.Contains('.'))
                            {
                                txt_Value.Text += ".";
                            }
                            else if (txt_Value.Text.Trim() == string.Empty)
                            {
                                txt_Value.Text += "0.";
                            }
                            break;

                        case ButtonIndex.btn_OK:
                            if (txt_Value.Text.Trim() != string.Empty)
                            {
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("当前数值不能为空！", "输入提示");
                            }
                            break;

                        case ButtonIndex.btn_Zero:
                            if (txt_Value.Text.Contains('0') && txt_Value.Text.Length == 1)
                            {
                                return;
                            }
                            else
                            {
                                txt_Value.Text += 0;
                            }
                            break;
                        case ButtonIndex.btn_One:
                            txt_Value.Text += 1;
                            break;
                        case ButtonIndex.btn_Two:
                            txt_Value.Text += 2;
                            break;
                        case ButtonIndex.btn_Three:
                            txt_Value.Text += 3;
                            break;
                        case ButtonIndex.btn_Four:
                            txt_Value.Text += 4;
                            break;
                        case ButtonIndex.btn_Five:
                            txt_Value.Text += 5;
                            break;
                        case ButtonIndex.btn_Six:
                            txt_Value.Text += 6;
                            break;
                        case ButtonIndex.btn_Seven:
                            txt_Value.Text += 7;
                            break;
                        case ButtonIndex.btn_Eight:
                            txt_Value.Text += 8;
                            break;
                        case ButtonIndex.btn_Nine:
                            txt_Value.Text += 9;
                            break;

                    }
                    if (!txt_Value.Focused)
                    {
                        txt_Value.Focus();
                        txt_Value.Select(txt_Value.Text.Length, 0);
                    }
                }
            }
        }

        /// <summary>
        /// 按钮
        /// </summary>
        public enum ButtonIndex
        {
            btn_One,
            btn_Two,
            btn_Three,
            btn_Backspace,
            btn_Four,
            btn_Five,
            btn_Six,
            btn_Clear,
            btn_Seven,
            btn_Eight,
            btn_Nine,
            btn_Cancel,
            btn_Zero,
            btn_Point,
            btn_Minus,
            btn_OK
        }
    }

}
