using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform.软件主体.检测功能配置
{
    public partial class LockScreenForm : Form
    {
        public LockScreenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var addr = new Address(SoftType.M , 807, DataType.Bit );
            addr.Value = 0;
            FormMainUI._plc.WriteDevice(addr);
            this.Close();
        }
    }
}
