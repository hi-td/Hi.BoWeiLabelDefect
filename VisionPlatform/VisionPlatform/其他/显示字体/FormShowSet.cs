using Newtonsoft.Json;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public partial class FormShowSet : Form
    {
        InspectFunction InspectFun;                                     //函数
        int m_cam;                                                      //两位数字
        InspectItem mItem;                                              //检测项
        InspectData.FontShowParam m_tmShowSet = new InspectData.FontShowParam();  //当前字体显示参数
        bool bLoadParam = false;                                        //控件值的改变是否是因为界面初始化加载参数
        /// <summary>
        ///相机及其对应的检测项的字体显示设置
        /// </summary>
        /// <param name="ncam"></param> 主相机
        /// <param name="sub_cam"></param> 子画面
        /// <param name="item"></param> 检测项
        public FormShowSet(int camID, InspectItem item)
        {
            InitializeComponent();
            this.m_cam = camID;
            this.mItem = item;
            InspectFun = UIConfig.RefreshFun(camID, out string strCamSer);
        }

        private void RefreshData(object sender, EventArgs e)
        {
            try
            {
                if (bLoadParam) return;
                m_tmShowSet.nOKSize = (int)numUpD_OKSize.Value;
                m_tmShowSet.nOKRow = (int)numUpD_OKRow.Value;
                trackBar_OKRow.Value = m_tmShowSet.nOKRow;
                m_tmShowSet.nOKCol= (int)numUpD_OKCol.Value;
                trackBar_OKCol.Value = m_tmShowSet.nOKCol;
                m_tmShowSet.nFrontSize = (int)numUpD_FrontSize.Value;
                m_tmShowSet.nRowStartPos = (int)numUpD_RowStart.Value;
                trackBar_RowStart.Value = m_tmShowSet.nRowStartPos;
                m_tmShowSet.nColStartPos = (int)numUpD_ColStart.Value;
                trackBar_ColStart.Value = m_tmShowSet.nColStartPos;
                m_tmShowSet.nRowGap = (int)numUpD_RowGap.Value;
                trackBar_RowGap.Value = m_tmShowSet.nRowGap;
                m_tmShowSet.nColGap = (int)numUpD_ColGap.Value;
                trackBar_ColGap.Value = m_tmShowSet.nColGap;
                Save();
            }
            catch (Exception ex)
            {

            }
        }
        private void Save()
        {
            try
            {
                //序列号字体设置
                if (null != DataSerializer._globalData.dicFontShowSet && DataSerializer._globalData.dicFontShowSet.ContainsKey(m_cam))
                {
                    Dictionary<InspectItem, FontShowParam> dicFont = DataSerializer._globalData.dicFontShowSet[m_cam];
                    if (dicFont.ContainsKey(mItem))
                    {
                        dicFont[mItem] = m_tmShowSet;
                    }
                    else
                    {
                        dicFont.Add(mItem, m_tmShowSet);
                    }
                    DataSerializer._globalData.dicFontShowSet[m_cam] = dicFont;
                }
                else
                {
                    Dictionary<InspectItem, FontShowParam> dicFont = new Dictionary<InspectItem, FontShowParam>();
                    dicFont.Add(mItem, m_tmShowSet);
                    DataSerializer._globalData.dicFontShowSet.Add(m_cam, dicFont);
                }
                var json = JsonConvert.SerializeObject(DataSerializer._globalData.dicFontShowSet);
                System.IO.File.WriteAllText(GlobalPath.SavePath.FontShowSetPath, json);
                ////图像窗体刷新显示
                //TMFun.HWnd.ClearWindow();
                //TMFun.HWnd.DispObj(TMFun.m_hImage);
                //if (mItem == InspectItem.TM)
                //{
                //    //端子检测
                //    InspectData.MultiTMParam multiTMParam = DataSerializer._globalData.dic_MultiTMParam[m_cam];
                //    TMCheckItem tmCheckList = DataSerializer._globalData.dic_TMCheckList[m_cam];
                //    if (TMFun.MultiTMInspect(multiTMParam, tmCheckList, false, out InspectData.MultiResult result))
                //    {
                //        TMFun.MultiTMShowResult(m_cam, multiTMParam, result, tmCheckList, out int DzNumOK, out int DzNumNG);
                //    }
                //}
                //else if (mItem == InspectItem.Rubber)
                //{
                //    //插壳检测
                //    InspectData.RubberParam rubberParam = DataSerializer._globalData.dic_RubberParam[m_cam];
                //    //rubberParam.lineColor.listColorID = TMData_Serializer._globalData.listColorID;
                //    if (TMFun.RubberInsert(rubberParam, false, out RubberResult Result,out _))
                //    {
                //        TMFun.MultiCKShowResult(m_cam, rubberParam, Result);
                //    }
                //}
                //else if (mItem == InspectItem.StripLen)
                //{
                //    InspectData.StripLenParam stripLenParam = DataSerializer._globalData.dic_StripLenParam[m_cam];
                //    //stripLenParam.lineColor.listColorID = TMData_Serializer._globalData.listColorID;
                //    if (TMFun.StrippingInspect(stripLenParam, true, out StripLenResult stripLenResult, out _))
                //    {
                //        TMFun.MultiSLShowResult(m_cam, stripLenParam, stripLenResult);
                //    }
                //}
                //else if (mItem == InspectItem.RubberSide)
                //{
                //    //插壳检测-侧面
                //    InspectData.SideRubberParam sideRubberParam = DataSerializer._globalData.dic_SideRubberParam[m_cam];
                //    TMFun.SideRubberInsert(sideRubberParam, false, out SideRubberResult outData);
                    
                //    TMFun.SideRubberResultShow(m_cam, sideRubberParam, outData);
                //}
                //else if (mItem == InspectItem.LineColor)
                //{
                //    InspectData.LineColorParam LineColorParam = DataSerializer._globalData.dic_LineColor[m_cam];
                //    TMFun.LineColor_MLP(LineColorParam, null, false,false, out LineColorResult outData);

                //    TMFun.MultiLCShowResult(m_cam, LineColorParam, outData);
                //}
            }

            catch (Exception ex)
            {
               MessageFun.ShowMessage ("字体设置出错：" + ex.ToString(), strEnglish: "Font setting error:" + ex.ToString());
                return;
            }
        }

        private void FormShowSet_Load(object sender, EventArgs e)
        {
            try
            {
                bLoadParam = true;
                if (null != DataSerializer._globalData.dicFontShowSet && DataSerializer._globalData.dicFontShowSet.ContainsKey(m_cam) && DataSerializer._globalData.dicFontShowSet[m_cam].ContainsKey(mItem))
                {
                    InspectData.FontShowParam tmShowSet = DataSerializer._globalData.dicFontShowSet[m_cam][mItem];
                    numUpD_OKSize.Value = tmShowSet.nOKSize;
                    numUpD_OKRow.Value = tmShowSet.nOKRow;
                    trackBar_OKRow.Value = tmShowSet.nOKRow;
                    numUpD_OKCol.Value = tmShowSet.nOKCol;
                    trackBar_OKCol.Value = tmShowSet.nOKCol;
                    numUpD_FrontSize.Value = tmShowSet.nFrontSize;
                    numUpD_RowStart.Value = tmShowSet.nRowStartPos;
                    trackBar_RowStart.Value = tmShowSet.nRowStartPos;
                    numUpD_ColStart.Value = tmShowSet.nColStartPos;
                    trackBar_ColStart.Value = tmShowSet.nColStartPos;
                    numUpD_RowGap.Value = tmShowSet.nRowGap;
                    trackBar_RowGap.Value = tmShowSet.nRowGap;
                    numUpD_ColGap.Value = tmShowSet.nColGap;
                    trackBar_ColGap.Value = tmShowSet.nColGap;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage("FormShowSet_Load:" + ex.ToString());
            }
            bLoadParam = false;
        }
       
        private void trackBar_RowGap_Scroll(object sender, EventArgs e)
        {
            numUpD_RowGap.Value = trackBar_RowGap.Value;
        }

        private void trackBar_ColGap_Scroll(object sender, EventArgs e)
        {
            numUpD_ColGap.Value = trackBar_ColGap.Value;
        }
        private void trackBar_ColStart_Scroll(object sender, EventArgs e)
        {
            numUpD_ColStart.Value = trackBar_ColStart.Value;
        }

        private void trackBar_RowStart_Scroll(object sender, EventArgs e)
        {
            numUpD_RowStart.Value = trackBar_RowStart.Value;
        }

        private void trackBar_OKRow_Scroll(object sender, EventArgs e)
        {
            numUpD_OKRow.Value = trackBar_OKRow.Value;
        }

        private void trackBar_OKCol_Scroll(object sender, EventArgs e)
        {
            numUpD_OKCol.Value = trackBar_OKCol.Value;
        }
    }
}
