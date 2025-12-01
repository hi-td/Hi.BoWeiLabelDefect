using StaticFun;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class CtrlHome : UserControl
    {
        public InspectFunction Fun;                         //检测函数
        private string str_CamSer;                          //对应的相机序列号
        public int camID;
        public CamInspectItem myCamItem;                    //相机ID
        bool bLoad = false;
        #region 检测项
        CtrlQRCode ctrlQRCode;                              //二维码识别
        CtrlPNCode ctrlPNCode;                              //周期码识别
        CtrlLabelMove ctrlLabelMove;                        //标签偏移
        CtrlDefect ctrlDefect;                              //缺陷检测
        #endregion
        List<TabPage> listTabPages = new List<TabPage>();
        public CtrlHome(int camID, InspectItem inspectItem)
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.camID = camID;
            this.myCamItem = new CamInspectItem(camID, inspectItem);
            Fun = UIConfig.RefreshFun(camID, out str_CamSer);
            InitUI();
            //给checkBox_Item_CheckedChanged用
            listTabPages = new List<TabPage> { tabPage_BarCode, tabPage_PNCode, tabPage_Fold, tabPage_LabelMove };
            LoadParam();
        }

        /// <summary>
        /// 解决窗体加载慢、卡顿问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;              //用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        private void InitUI()
        {
            try
            {
                //二维码识别
                ctrlQRCode = new CtrlQRCode(this);
                tabPage_BarCode.Controls.Clear();
                tabPage_BarCode.Controls.Add(ctrlQRCode);
                //周期码识别
                ctrlPNCode = new CtrlPNCode(this);
                tabPage_PNCode.Controls.Clear();
                tabPage_PNCode.Controls.Add(ctrlPNCode);
                //标签偏移
                ctrlLabelMove = new CtrlLabelMove(this);
                tabPage_LabelMove.Controls.Clear();
                tabPage_LabelMove.Controls.Add(ctrlLabelMove);
                //褶皱气泡
                ctrlDefect = new CtrlDefect(this);
                tabPage_Fold.Controls.Clear();
                tabPage_Fold.Controls.Add(ctrlDefect);

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void Inspect(object sender, EventArgs e)
        {
            bool bResult = true;
            try
            {
                if (bLoad) return;
                InspectData.FrontParam param = InitParam();
                Fun.ClearObjShow();
                Fun.DispRegion(Fun.HImage);
                TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                if (!Fun.myFrontFun.FrontInspect(param, myCamItem.item, true, out FrontResult outRes))
                {
                    bResult = false;
                }
                TimeSpan ts_check = new TimeSpan(DateTime.Now.Ticks);
                Fun.myFrontFun.FrontResultShow(myCamItem, param, ref outRes);
                TimeSpan ts_show = new TimeSpan(DateTime.Now.Ticks);
                string span1 = ((ts_check.Subtract(ts).Duration().TotalSeconds) * 1000).ToString("F0");
                StaticFun.MessageFun.ShowMessage("算法检测用时：" + span1);
                string span2 = ((ts_show.Subtract(ts_check).Duration().TotalSeconds) * 1000).ToString("F0");
                StaticFun.MessageFun.ShowMessage("显示用时：" + span2);

            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
        }

        public InspectData.FrontParam InitParam()
        {
            InspectData.FrontParam param = new InspectData.FrontParam();
            try
            {
                //二维码
                param.bQRCode = checkBox_BarCode.Checked;
                param.QRCode = ctrlQRCode.InitParam();
                //周期码
                param.bPNCode = checkBox_PNCode.Checked;
                param.PNCode = ctrlPNCode.InitParam();
                //褶皱鼓包检测
                param.Defect = ctrlDefect.InitParam();
                param.LabelMove = ctrlLabelMove.InitParam();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            return param;
        }

        private void LoadParam()
        {
            try
            {

                bLoad = true;
                if (null != DataSerializer._globalData.dic_FrontParam && DataSerializer._globalData.dic_FrontParam.ContainsKey(camID))
                {
                    InspectData.FrontParam param = DataSerializer._globalData.dic_FrontParam[camID];
                    //m_ModelID = param.modelID;
                    //locateParam = param.locateInParams;
                    //myModelPoint = param.modelPoint;
                    //二维码
                    checkBox_BarCode.Checked = param.bQRCode;
                    ctrlQRCode?.LoadParam(param.QRCode);
                    tabPage_BarCode.Parent = param.bQRCode ? tabCtrl : null;
                    //周期码
                    checkBox_PNCode.Checked = param.bPNCode;
                    ctrlPNCode?.LoadParam(param.PNCode);
                    tabPage_PNCode.Parent = param.bPNCode ? tabCtrl : null;
                    //褶皱鼓包
                    checkBox_Fold.Checked = true;
                    ctrlDefect?.LoadParam(param.Defect);
                    tabPage_Fold.Parent = tabCtrl;
                    //标签偏移
                    checkBox_LabelMove.Checked = true;
                    ctrlLabelMove.LoadParam(param.LabelMove);
                    tabPage_LabelMove.Parent = tabCtrl;
                    checkBox_Item_CheckedChanged(checkBox_LabelMove, null);
                }
                else
                {
                    tabPage_BarCode.Parent = null;
                    tabPage_PNCode.Parent = null;
                    checkBox_Fold.Checked = true;
                    checkBox_LabelMove.Checked = true;
                    tabPage_Fold.Parent = tabCtrl;
                    tabPage_LabelMove.Parent = tabCtrl;
                }
            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            bLoad = false;
        }

        private void but_SaveParam_Click(object sender, EventArgs e)
        {
            try
            {
                if (null != DataSerializer._globalData.dic_FrontParam &&
                    DataSerializer._globalData.dic_FrontParam.ContainsKey(camID))
                {
                    DialogResult dr = MessageBox.Show($"相机{myCamItem.cam.ToString()[0]}-{myCamItem.cam.ToString()[1]}正面检测参数已存在，是否覆盖？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr != DialogResult.OK)
                    {
                        return;
                    }
                    DataSerializer._globalData.dic_FrontParam[camID] = InitParam();
                }
                else
                {
                    DataSerializer._globalData.dic_FrontParam.Add(camID, InitParam());
                }
                MessageBox.Show($"相机{camID.ToString()[0]}-{camID.ToString()[1]}正面检测参数保存完成！");

            }
            catch (SystemException error)
            {
                StaticFun.MessageFun.ShowMessage("参数保存出错！" + error.ToString());
                return;
            }
        }
        private void checkBox_Item_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (null == cb || bLoad) return;
                foreach (TabPage tabPage in listTabPages)
                {
                    if (cb.Text == tabPage.Text)
                    {
                        tabPage.Parent = cb.Checked ? tabCtrl : null;
                        if (cb.Checked)
                        {
                            tabCtrl.SelectedTab = tabPage;
                        }
                    }
                }
                tabCtrl.Refresh();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }


    }
}
