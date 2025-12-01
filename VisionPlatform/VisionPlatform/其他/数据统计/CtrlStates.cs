using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlStates : UserControl
    {
        public int m_cam;
        public InspectItem m_CheckItem;
        List<Count> count = new();
        public CtrlStates()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
        }
        public void SetName(int camID, string strName)
        {
            label_Name.Text = $"相机{camID.ToString()[0]}-{camID.ToString()[1]}:{strName}";
        }
        public void Init()
        {
            if (!File.Exists(GlobalPath.SavePath.Count))
            {
                File.WriteAllText(GlobalPath.SavePath.Count, "");
            }
            //将json返回dynamic对象
            string strData = System.IO.File.ReadAllText(GlobalPath.SavePath.Count);
            if (strData != "")
            {
                var DynamicObject = JsonConvert.DeserializeObject<List<Count>>(strData);
                DataSerializer._ShowCount.Count = (List<Count>)DynamicObject;
                bool bset = false;
                foreach (var item in DataSerializer._ShowCount.Count)
                {
                    if (item.camInspect.cam == m_cam && item.camInspect.item == m_CheckItem)
                    {
                        bset = true;
                    }
                }
                if (!bset)
                {
                    InspectData.Count count = new()
                    {
                        camInspect = new CamInspectItem()
                    };
                    count.camInspect.cam = m_cam;
                    count.camInspect.item = m_CheckItem;
                    count.nTotalOK = 0;
                    count.nTotalNG = 0;
                    count.nTotal = 0;
                    DataSerializer._ShowCount.Count.Add(count);
                }
            }
            else
            {
                InspectData.Count count = new()
                {
                    camInspect = new CamInspectItem()
                };
                count.camInspect.cam = m_cam;
                count.camInspect.item = m_CheckItem;
                count.nTotalOK = 0;
                count.nTotalNG = 0;
                count.nTotal = 0;
                DataSerializer._ShowCount.Count.Add(count);
            }

            foreach (var count in DataSerializer._ShowCount.Count)
            {
                if (count.camInspect.cam == m_cam && count.camInspect.item == m_CheckItem)
                {
                    this.label_OK.Text = count.nTotalOK.ToString();
                    this.label_NG.Text = count.nTotalNG.ToString();
                    this.label_Total.Text = count.nTotal.ToString();
                    this.label_Yield.Text = (count.nTotalOK * 1.0 / (count.nTotalOK + count.nTotalNG)).ToString("P"); //良率
                }
            }
            //C#对象转Json
            var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
            System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
        }
        /// <summary>
        /// 数据统计
        /// </summary>
        /// <param name="ok"></param> 增加的OK数
        /// <param name="ng"></param>增加的NG数
        /// <param name="time"></param> 检测用时
        public void Add(bool bResult, int ok, int ng, double time)
        {
            try
            {
                int nTotalOK = int.Parse(this.label_OK.Text) + ok;
                int nTotalNG = int.Parse(this.label_NG.Text) + ng;
                int nTotal = int.Parse(this.label_Total.Text) + ok + ng;
                BeginInvoke(new Action(() =>
                {
                    label_Result.Text = bResult ? "OK" : "NG";
                    label_Result.BackColor = bResult ? Color.Green : Color.Red;
                    label_TimeSpan.Text = time.ToString() + "ms";
                    this.label_OK.Text = nTotalOK.ToString();
                    this.label_NG.Text = nTotalNG.ToString();
                    label_Total.Text = nTotal.ToString();
                    label_Yield.Text = (nTotalOK * 1.0 / (nTotalOK + nTotalNG)).ToString("P"); //良率
                }));

                InspectData.Count count = new()
                {
                    camInspect = new CamInspectItem()
                    {
                        cam = m_cam,
                        item = m_CheckItem
                    },
                    nTotal = nTotalOK,
                    nTotalNG = nTotalNG,
                    nTotalOK = nTotalOK
                };
                for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
                {
                    if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                        && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                    {
                        DataSerializer._ShowCount.Count[i] = count;
                    }
                }
                //C#对象转Json
                var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
                System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
        }

        private void 清除数据_Click(object sender, EventArgs e)
        {
            this.label_Result.Text =  "--";
            this.label_Result.BackColor = Color.Transparent;
            this.label_OK.Text = "0";
            this.label_NG.Text = "0";
            label_Total.Text = "0";
            label_Yield.Text = "0";
            label_TimeSpan.Text = "00ms";
            for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
            {
                if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                    && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                {
                    InspectData.Count count = new()
                    {
                        camInspect = new CamInspectItem()
                    };
                    count.camInspect.cam = m_cam;
                    count.camInspect.item = m_CheckItem;
                    count.nTotalOK = 0;
                    count.nTotalNG = 0;
                    count.nTotal = 0;
                    DataSerializer._ShowCount.Count[i] = count;
                }
            }
            //C#对象转Json
            var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
            System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
        }

        private void Text_OK_DoubleClick(object sender, EventArgs e)
        {
            this.label_OK.Text = "0";
            for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
            {
                if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                    && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                {
                    InspectData.Count count = new()
                    {
                        camInspect = new CamInspectItem()
                    };
                    count.camInspect.cam = m_cam;
                    count.camInspect.item = m_CheckItem;
                    count.nTotalOK = 0;
                    count.nTotalNG = DataSerializer._ShowCount.Count[i].nTotalNG;
                    count.nTotal = DataSerializer._ShowCount.Count[i].nTotal;
                    DataSerializer._ShowCount.Count[i] = count;
                }
            }
            //C#对象转Json
            var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
            System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
        }

        private void Text_NG_DoubleClick(object sender, EventArgs e)
        {
            this.label_NG.Text = "0";
            for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
            {
                if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                    && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                {
                    InspectData.Count count = new()
                    {
                        camInspect = new CamInspectItem()
                    };
                    count.camInspect.cam = m_cam;
                    count.camInspect.item = m_CheckItem;
                    count.nTotalOK = DataSerializer._ShowCount.Count[i].nTotalOK;
                    count.nTotalNG = 0;
                    count.nTotal = DataSerializer._ShowCount.Count[i].nTotal;
                    DataSerializer._ShowCount.Count[i] = count;
                }
            }
            //C#对象转Json
            var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
            System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
        }

        private void Text_Total_DoubleClick(object sender, EventArgs e)
        {
            label_Total.Text = "0";
            for (int i = 0; i < DataSerializer._ShowCount.Count.Count; i++)
            {
                if (DataSerializer._ShowCount.Count[i].camInspect.cam == m_cam
                    && DataSerializer._ShowCount.Count[i].camInspect.item == m_CheckItem)
                {
                    InspectData.Count count = new()
                    {
                        camInspect = new CamInspectItem()
                    };
                    count.camInspect.cam = m_cam;
                    count.camInspect.item = m_CheckItem;
                    count.nTotalOK = DataSerializer._ShowCount.Count[i].nTotalOK;
                    count.nTotalNG = DataSerializer._ShowCount.Count[i].nTotalNG;
                    count.nTotal = 0;
                    DataSerializer._ShowCount.Count[i] = count;
                }
            }
            //C#对象转Json
            var json = JsonConvert.SerializeObject(DataSerializer._ShowCount.Count);
            System.IO.File.WriteAllText(GlobalPath.SavePath.Count, json);
        }
    }
}
