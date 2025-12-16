using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlTcpAdress : UserControl
    {
        public int myCamID;
        public InspectData.InspectItem myItem;
        public CtrlTcpAdress(int camID, InspectData.InspectItem item)
        {
            InitializeComponent();
            this.myCamID = camID;
            this.myItem = item;
            this.Dock = DockStyle.Top;
            this.Visible = true;
            this.Padding = new Padding(1);
            label_camID.Text = camID.ToString();
            label_Item.Text = InspectFunction.GetStrCheckItem(item);
        }
        public ItemAddress InitParam()
        {
            ItemAddress param = new ItemAddress();
            try
            {
                param.camItem = new CamInspectItem(myCamID, myItem);
                param.readKey = $"M{textBox_Read.Text}";
                param.bSend = checkBox_bSend.Checked;
                param.sendKey = $"{comboBox_MD.Text}{textBox_Send.Text}";
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }
        public void LoadParam(ItemAddress param)
        {
            try
            {
                label_camID.Text = param.camItem.cam.ToString();
                label_Item.Text = InspectFunction.GetStrCheckItem(param.camItem.item);
                textBox_Read.Text = param.readKey.Substring(1, param.readKey.Length - 1);
                checkBox_bSend.Checked = param.bSend;
                comboBox_MD.Text = param.sendKey[0].ToString();
                textBox_Send.Text = param.sendKey.Substring(1, param.sendKey.Length - 1);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void checkBox_bSend_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_MD.Enabled = checkBox_bSend.Checked;
            textBox_Send.Enabled = checkBox_bSend.Checked;
        }
    }
}
