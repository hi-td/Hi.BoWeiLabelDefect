using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlOK_NG : UserControl
    {
        //一个产品多相机检测时，统计最终的OK/NG结果
        public CtrlOK_NG()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Visible = true;
            this.Margin = new Padding(0);
        }
        public void ShowRes(bool bResult)
        {
            try
            {
                //MessageFun.ShowMessage("进入计数");
                int nTotalOK = int.Parse(this.label_OK.Text);
                int nTotalNG = int.Parse(this.label_NG.Text);
                if (bResult)
                {
                    nTotalOK += 1;
                }
                else
                {
                    nTotalNG += 1;
                }
                int nTotal = nTotalOK + nTotalNG;
                BeginInvoke(new Action(() =>
                {
                    label.Text = bResult ? "OK" : "NG";
                    label.BackColor = bResult ? Color.Green : Color.Red;
                    this.label_OK.Text = nTotalOK.ToString();
                    this.label_NG.Text = nTotalNG.ToString();
                    label_Total.Text = nTotal.ToString();
                    label_Yield.Text = (nTotalOK * 1.0 / nTotal).ToString("P"); //良率
                }));
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
        }

        private void 清除数据_Click(object sender, EventArgs e)
        {
            this.label_OK.Text = "0";
            this.label_NG.Text = "0";
            label_Total.Text = "0";
            label_Yield.Text = "0";
        }

        private void Text_OK_DoubleClick(object sender, EventArgs e)
        {
            this.label_OK.Text = "0";
        }

        private void Text_NG_DoubleClick(object sender, EventArgs e)
        {
            this.label_NG.Text = "0";
        }

        private void Text_Total_DoubleClick(object sender, EventArgs e)
        {
            label_Total.Text = "0";
        }

        public void Save()
        {
            try
            {
                for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
                {
                    //if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                    //    && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                    //{
                    //    InspectData.Count count = new()
                    //    {
                    //        camInspect = new CamInspectItem()
                    //    };
                    //    count.camInspect.cam = m_cam;
                    //    count.camInspect.item = m_CheckItem;
                    //    count.nTotalOK = 0;
                    //    count.nTotalNG = DataSerializer._ShowCount.Count[i].nTotalNG;
                    //    count.nTotal = DataSerializer._ShowCount.Count[i].nTotal;
                    //    DataSerializer._ShowCount.Count[i] = count;
                    //}
                }
                //C#对象转Json
                var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
                System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
