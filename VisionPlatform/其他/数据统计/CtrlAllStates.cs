using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlAllStates : UserControl
    {
        int Row = 1;
        int Col = 1;
        public CtrlAllStates()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
        }

        public void SetRowCol(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public void RefreshDatas()
        {
            try
            {
                if (null != DataSerializer._globalData.dicInspectList && DataSerializer._globalData.dicInspectList.Count > 0)
                {
                    this.Controls.Clear();
                    TableLayoutPanel tLPanel = new TableLayoutPanel();
                    tLPanel.Visible = true;
                    tLPanel.Dock = DockStyle.Fill;
                    tLPanel.RowCount = Row;
                    tLPanel.ColumnCount = Col;
                    this.Controls.Add(tLPanel);
                    List<CtrlStates> listCtrls = new List<CtrlStates>();
                    foreach (int camID in DataSerializer._globalData.dicInspectList.Keys)
                    {
                        foreach (InspectData.InspectItem item in DataSerializer._globalData.dicInspectList[camID])
                        {
                            string strItem = InspectFunction.GetStrCheckItem(item);
                            InspectData.CamInspectItem camItem = new InspectData.CamInspectItem(camID, item);
                            if (null != InspectFunction.m_ListFormSTATS && InspectFunction.m_ListFormSTATS.ContainsKey(camItem))
                            {
                                InspectFunction.m_ListFormSTATS[camItem].Visible = true;
                                listCtrls.Add(InspectFunction.m_ListFormSTATS[camItem]);
                            }
                            else
                            {
                                CtrlStates ctrl = new CtrlStates();
                                ctrl.SetName(camID, strItem);
                                listCtrls.Add(ctrl);
                                InspectFunction.m_ListFormSTATS.Add(new InspectData.CamInspectItem(camID, item), ctrl);
                            }
                        }
                    }
                    int n = 0;
                    for (int r = 0; r < Row; r++)
                    {
                        tLPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F/Row));
                        for (int c = 0; c < Col; c++)
                        {
                            tLPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / Col));
                            if (listCtrls.Count > n)
                            {
                                tLPanel.Controls.Add(listCtrls[n], c, r);
                                n++;
                            }
                        }
                    }
                    tLPanel.Refresh();
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
            this.Refresh();
        }
    }
}
