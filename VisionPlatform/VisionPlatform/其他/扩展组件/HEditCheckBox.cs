/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：HEditCheckBox
* 机器名称：DELL-CHUSTANGE
* 命名空间：Hi.Ltd.Windows.Forms
* 文 件 名：HEditCheckBox
* 创建时间：2025/4/21 15:52:34
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2025 保留所有权利.
***********************************************************/
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VisionPlatform
{
    /// <summary>
    /// 表示 Hi.Ltd 的可编辑的复选框控件。
    /// </summary>
    public class HEditCheckBox : CheckBox
    {
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll")]
        private static extern bool ImmSetConversionStatus(IntPtr hIMC, int conversion, int sentence);
        [DllImport("imm32.dll")]
        private static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);
        // 半角英文模式（IME_CMODE_NATIVE: 中文；IME_CMODE_FULLSHAPE: 全角）
        private const int IME_CMODE_ALPHANUMERIC = 0x0000;
        private const int IME_CMODE_NATIVE = 0x0001;
        private const int IME_CMODE_FULLSHAPE = 0x0008;
        private readonly TextBox textBox;
        /// <summary>
        /// 
        /// </summary>
        public HEditCheckBox()
        {
            textBox = new TextBox();
            textBox.Visible = false;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Leave += TextBox_Leave;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.GotFocus += (s, e) => ForceHalfWidthMode(textBox);
            this.Controls.Add(textBox);
        }
        private void ForceHalfWidthMode(TextBox tb)
        {
            var hIMC = ImmGetContext(tb.Handle);
            if (hIMC != IntPtr.Zero)
            {
                // 设置为：中文模式 + 半角（或英文+半角）
                ImmSetConversionStatus(hIMC, IME_CMODE_NATIVE, 0); // 或 IME_CMODE_ALPHANUMERIC
                ImmReleaseContext(tb.Handle, hIMC);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Right && e.X > 18)
            {
                // 右键点击时，显示文本框进行编辑
                StartEditing();
            }
        }

        private void StartEditing()
        {
            // 获取文字部分的位置（大致偏移量为18px）
            int offsetX = TextRenderer.MeasureText(" ", this.Font).Width + 2;
            var textSize = TextRenderer.MeasureText(this.Text, this.Font);
            textBox.Text = this.Text;
            textBox.ImeMode = ImeMode.On;
            textBox.Location = new Point(offsetX, 0);
            textBox.Size = new Size(Math.Max(50, textSize.Width + 20), this.Height - 2);
            textBox.Visible = true;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void EndEditing()
        {
            this.Text = textBox.Text;
            textBox.Visible = false;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            EndEditing();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EndEditing();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textBox.Visible = false;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

    }

}
