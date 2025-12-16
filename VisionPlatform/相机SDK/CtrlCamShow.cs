using BaseData;
using CamSDK;
using EnumData;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class CtrlCamShow : UserControl
    {
        public int camID;                                      //相机ID号
        public string strCamSer;                               //相机序列号
        public List<Mirror> myListMirror = new List<Mirror>(); //图像镜像
        public InspectFunction Fun;                            //检测函数
        private readonly SynchronizationContext context;       //文字显示
        FormCamParamSet formCamParamSet;                       //相机参数及光源参数调节
        private Point m_pMuoseDown;                            //用来记录按下鼠标时的坐标位置
        private bool m_bMoving = false;                        //是否处于移动状态，初始值为关闭
        private bool bDrawing = false;                         //是否处于绘制状态
        public CtrlCamShow()
        {
            InitializeComponent();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(1);
            context = SynchronizationContext.Current;
            panel2.BackColor = Color.FromArgb(255, 0, green: 0, 0);
            myListWndCtrl = new List<HalconDotNet.HWindowControl>() { hWndCtrl1, hWndCtrl2, hWndCtrl3, hWndCtrl4 };
            ts_Label_state.Dock = DockStyle.Right;

        }
        public void UpdateFun(int camID, CamShowItem camShowItem)
        {
            Fun = new InspectFunction(this.hWndCtrl);
            this.camID = camID;
            this.strCamSer = camShowItem.strCamSer;
            this.myListMirror = camShowItem.listMirror;
            //相机ID
            string camName = GlobalData.Config._language == EnumData.Language.english ? "Camera" : "相机";
            this.label_Cam.Text = $"{camName}{camID.ToString()[0]}-{camID.ToString()[1]}";
            //相机序列号
            string camSer = GlobalData.Config._language == EnumData.Language.english ? "Camera SN:" : "相机序号：";
            ts_Label_CamSer.Text = camSer + strCamSer?.ToString();
            InitCamSer();
            if (strCamSer != "" && strCamSer != "空")
            {
                CamCommon.OpenCam(strCamSer, Fun);
                CamCommon.Live(strCamSer);
                CamCommon.GrabImage(strCamSer);
            }
        }
        private void InitCamSer()
        {
            try
            {
                ToolStripDropDownItem ts1 = new ToolStripMenuItem("子画面");
                if (0 != CamSDK.CamCommon.m_listCamSer.Count)
                {
                    foreach (string strCamID in CamSDK.CamCommon.m_listCamSer.Keys)
                    {
                        ToolStripItem ts = new ToolStripMenuItem(strCamID);
                        if (camID.ToString()[1] == '0')
                        {
                            ((ToolStripDropDownItem)contextMenuStrip1.Items[0]).DropDownItems.Add(ts);
                        }
                        ts1.DropDownItems.Add(strCamID);
                    }
                }
                if (!(camID.ToString()[1] == '0'))
                {
                    ts1.DropDownItemClicked += 关联相机_DropDownItemClicked;
                    ((ToolStripDropDownItem)contextMenuStrip1.Items[0]).DropDownItems.Add(ts1);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
                return;
            }
        }

        public void SaveCamConfig()
        {
            try
            {
                CamShowItem myCamShowItem = new CamShowItem(strCamSer, myListMirror);
                if (GlobalData.Config._CamConfig.camConfig.ContainsKey(camID))
                {
                    GlobalData.Config._CamConfig.camConfig[camID] = myCamShowItem;
                }
                else
                {
                    GlobalData.Config._CamConfig.camConfig.Add(camID, myCamShowItem);
                }
                //保存到配置文件
                var json = JsonConvert.SerializeObject(GlobalData.Config._CamConfig);
                System.IO.File.WriteAllText(GlobalPath.SavePath.CamConfigPath, json);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        #region 工具栏
        private void but_Live_Click(object sender, EventArgs e)
        {
            CamCommon.OpenCam(strCamSer, Fun);
            Fun.ClearObjShow();
            CamCommon.Live(strCamSer);
            ts_Label_state.Text = (GlobalData.Config._language == EnumData.Language.english) ? "Current status: Live" : "当前状态：实时显示中";
        }
        private void but_GrabImage_Click(object sender, EventArgs e)
        {
            try
            {
                CamCommon.OpenCam(strCamSer, Fun);
                Fun.ClearObjShow();
                if (tLPanel_Photometrics.Visible == false)
                {
                    CamCommon.GrabImage(strCamSer);
                    ts_Label_state.Text = "当前状态：拍照";
                }
                else
                {
                    myListImages = this.Fun.PhotometricGrabImages(camID, strCamSer, myListWndCtrl);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        private void but_SaveImg_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.InitialDirectory = "e:/";
                saveFileDialog.Filter = "BMP图片|*.bmp|JPG图片|*.jpg|Gif图片|*.gif";
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string strImageFile = saveFileDialog.FileName;
                    Fun.SaveImage(strImageFile, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void but_RecoverImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fun != null && Fun.m_hImage != null)
                {
                    Fun.dReslutRow0 = 0;
                    Fun.dReslutCol0 = 0;
                    Fun.dReslutRow1 = 0;
                    Fun.dReslutCol1 = 0;
                    Fun.FitImageToWindow(ref Fun.dReslutRow0, ref Fun.dReslutCol0, ref Fun.dReslutRow1, ref Fun.dReslutCol1);
                    ts_Label_state.Text = "当前状态：原比例显示";
                }

            }
            catch (Exception)
            {
            }
        }
        private void but_LoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                Stream inputStream = null;
                openFileDialog.InitialDirectory = "e:/";
                openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif|PNG图片|*.png";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((inputStream = openFileDialog.OpenFile()) != null)
                    {
                        using (inputStream)
                        {
                            string strImageFile = openFileDialog.FileName;
                            if (!Fun.LoadImageFromFile(strImageFile))
                            {
                                MessageBox.Show("图片读取错误！");
                                return;
                            }
                        }
                    }
                    m_pMuoseDown = new Point(0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void but_ImageList_Click(object sender, EventArgs e)
        {
            groupBox_ImageList.Visible = true;
            LoadImageSet("NG");
        }
        private void label_Edit_Click(object sender, EventArgs e)
        {
            if (!FormMainUI.bRun)
            {
                StaticFun.UIConfig.CreateFormTeachMaster(camID);
            }
            else
            {
                MessageBox.Show("当前程序正在运行中，请停止检测按钮<运行中>后，再进行其它操作，谢谢配合。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        //缩小界面功能
        private void label_x_Click(object sender, EventArgs e)
        {
            //if (FormMainUI.bCamShowFlag)
            //{
            //    FormMainUI.m_Show4.panel_CamShow.Clear();
            //    FormMainUI.m_Show4.panel_CamShow.Controls.Add(FormMainUI.m_Show4.tLPanel_CamShow);
            //    UIConfig.RefeshCamShow(FormMainUI.m_Show4.tLPanel_CamShow, FormMainUI.m_dicFormCamShows);
            //    FormMainUI.bCamShowFlag = false;
            //}
        }
        IntPtr handle;
        //放大功能
        private void label_d_Click(object sender, EventArgs e)
        {
            //if (!FormMainUI.bCamShowFlag)
            //{
            //    FormMainUI.m_Show4.panel_CamShow.Clear();
            //    FormMainUI.m_Show4.panel_CamShow.Controls.Add(FormMainUI.m_dicFormCamShows[m_ncam][sub_cam].form);
            //    FormMainUI.bCamShowFlag = true;
            //}
        }
        #endregion

        #region 图像缩放
        private void hWndCtrl_HMouseDown(object sender, HalconDotNet.HMouseEventArgs e)
        {
            if (Fun == null && Fun.m_hImage == null) return;
            if (e.Button == MouseButtons.Left && !bDrawing)
            {
                m_pMuoseDown.X = (int)e.X;
                m_pMuoseDown.Y = (int)e.Y;
                m_bMoving = true;
                //ts_Label_state.Text = "当前状态：图像平移中";
            }
            else if (e.Button == MouseButtons.Right)
            {
                m_bMoving = false;
                bDrawing = false;
            }
        }

        private void hWndCtrl_HMouseMove(object sender, HalconDotNet.HMouseEventArgs e)
        {
            HTuple hv_Row = new HTuple(), hv_Col = new HTuple();
            try
            {
                if (Fun == null || Fun.m_hImage == null) return;
                if (!bDrawing)
                {
                    if (e.Button == MouseButtons.Left && m_bMoving)
                    {
                        System.Drawing.Point pt = new System.Drawing.Point();
                        pt.X = (int)e.X;
                        pt.Y = (int)e.Y;
                        Fun.MoveImage(m_pMuoseDown, pt);
                        ts_Label_state.Text = "当前状态：图像平移中";
                    }
                }
                HOperatorSet.GetMposition(this.hWndCtrl.HalconWindow, out hv_Row, out hv_Col, out HTuple hv_Button);
                if (hv_Row?.TupleLength() != 0 && hv_Col?.TupleLength() != 0)
                {
                    this.toolStripLabel_pos.Text = $"{hv_Col[0].I.ToString()},{hv_Row[0].I.ToString()}";
                    HOperatorSet.GetGrayval(Fun.m_GrayImage, hv_Row, hv_Col, out var grayval);
                    toolStripLabel_gray.Text = grayval[0].D.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                toolStripLabel_gray.Text = "*";
            }
            //this.Fun.DispRegion(Fun.m_hImage);
        }

        private void hWndCtrl_HMouseWheel(object sender, HalconDotNet.HMouseEventArgs e)
        {
            try
            {
                if (Fun.m_hImage == null) return;
                double scale;
                if (e.Delta >= 0) //鼠标滚轮向上滑动
                {
                    scale = 0.9;
                }
                else
                {
                    scale = 1 / 0.9;
                }
                Fun.ZoomImage(e.X, e.Y, scale);
                ts_Label_state.Text = "当前状态：图像缩放中";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        #endregion

        #region 图像集测试
        List<string> imagePathList = new List<string>();
        int index = 0;
        private void RefreshListViewImages(string strFolderPath)
        {
            try
            {
                this.imageList1.Images.Clear();
                this.listView_ImgList.Controls.Clear();
                imageList1.ImageSize = new Size((int)(listView_ImgList.Width / 2), (int)(listView_ImgList.Width / 2));
                Function.list_image_files(strFolderPath, "default", out imagePathList);
                foreach (string path in imagePathList)
                {
                    this.imageList1.Images.Add(Image.FromFile(path));
                }
                this.listView_ImgList.Items.Clear();
                this.listView_ImgList.LargeImageList = this.imageList1;
                this.listView_ImgList.View = View.LargeIcon;

                this.listView_ImgList.BeginUpdate();
                for (int i = 0; i < imageList1.Images.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.ImageIndex = i;
                    lvi.Text = i.ToString();
                    this.listView_ImgList.Items.Add(lvi);
                }
                this.listView_ImgList.EndUpdate();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void LoadImageSet(string strNG_OK)
        {
            string strImgFilePath = "";
            try
            {
                //switch (m_ncam)
                //{
                //    case 1:
                //        if (strNG_OK == "OK")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam1_OrgImagePath_OK;
                //        }
                //        if (strNG_OK == "NG")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam1_OrgImagePath_NG;
                //        }
                //        break;
                //    case 2:
                //        if (strNG_OK == "OK")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam2_OrgImagePath_OK;
                //        }
                //        if (strNG_OK == "NG")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam2_OrgImagePath_NG;
                //        }
                //        break;
                //    case 3:
                //        if (strNG_OK == "OK")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam3_OrgImagePath_OK;
                //        }
                //        if (strNG_OK == "NG")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam3_OrgImagePath_NG;
                //        }
                //        break;
                //    case 4:
                //        if (strNG_OK == "OK")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam4_OrgImagePath_OK;
                //        }
                //        if (strNG_OK == "NG")
                //        {
                //            strImgFilePath = GlobalPath.SavePath.cam4_OrgImagePath_NG;
                //        }
                //        break;

                //}
                if ("" != strImgFilePath)
                {
                    RefreshListViewImages(strImgFilePath);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        private void ts_But_ImageList_Click(object sender, EventArgs e)
        {
            groupBox_ImageList.Visible = true;
            LoadImageSet("NG");
        }
        private void ts_But_ImageListClose_Click(object sender, EventArgs e)
        {
            groupBox_ImageList.Visible = false;
        }
        private void but_PreImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (index > 0)
                {
                    index--;
                }
                else if (index == 0)
                {
                    index = imagePathList.Count;
                    index--;
                }
                foreach (ListViewItem lv in this.listView_ImgList.Items)
                {
                    lv.Selected = false;
                }
                this.listView_ImgList.Items[index].Selected = true;
                this.listView_ImgList.Items[index].EnsureVisible();
                Fun.LoadImageFromFile(imagePathList[index]);
                Insert();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void but_NextImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (index == imagePathList.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                foreach (ListViewItem lv in this.listView_ImgList.Items)
                {
                    lv.Selected = false;
                }
                this.listView_ImgList.Items[index].Selected = true;
                this.listView_ImgList.Items[index].EnsureVisible();
                Fun.LoadImageFromFile(imagePathList[index]);
                Insert();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void Insert()
        {

        }
        private void listView_ImgList_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView_ImgList.SelectedItems.Count == 0)
                {
                    return;
                }
                index = this.listView_ImgList.SelectedItems[0].Index;
                Fun.LoadImageFromFile(imagePathList[index]);
                Insert();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void tsBut_LoadOK_Click(object sender, EventArgs e)
        {
            LoadImageSet("OK");
        }
        private void tsBut_LoadNG_Click(object sender, EventArgs e)
        {
            LoadImageSet("NG");
        }
        private void tsBut_LoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择文件路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string foldPath = dialog.SelectedPath;
                    RefreshListViewImages(foldPath);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        #endregion

        #region contextmenustrip
        private void 关联相机_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string str = e.ClickedItem.Text;
                if (str == "子画面") return;
                CamCommon.Live(str);
                strCamSer = str;
                //相机序列号
                string camSer = GlobalData.Config._language == EnumData.Language.english ? "Camera SN:" : "相机序号：";
                ts_Label_CamSer.Text = camSer + strCamSer.ToString();
                //图像镜像
                if (null != Fun && GlobalData.Config._CamConfig.camConfig.ContainsKey(camID) &&
                    null != GlobalData.Config._CamConfig.camConfig[camID].listMirror)
                {
                    myListMirror = GlobalData.Config._CamConfig.camConfig[camID].listMirror;
                    Fun.m_ListImgMirror = myListMirror;
                    if (myListMirror.Contains(EnumData.Mirror.Left_Right))
                    {
                        LoR.Checked = true;
                        LoR.BackColor = Color.Green;
                    }
                    if (myListMirror.Contains(EnumData.Mirror.Up_Down))
                    {
                        UoD.Checked = true;
                        UoD.BackColor = Color.Green;
                    }
                }
                if ("" != strCamSer)  //相机关联
                {
                    CamCommon.OpenCam(strCamSer, Fun);
                    CamCommon.Live(strCamSer);
                    CamCommon.GrabImage(strCamSer);
                    ts_Label_state.Text = (GlobalData.Config._language == EnumData.Language.english) ? "Current status: Grab" : "当前状态：拍照";
                }
                SaveCamConfig();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        private void 画质调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (null == formCamParamSet || formCamParamSet.IsDisposed)
                {
                    formCamParamSet = new FormCamParamSet(camID, strCamSer);
                    formCamParamSet.StartPosition = FormStartPosition.CenterScreen;
                    formCamParamSet.Show();
                }
                else
                {
                    formCamParamSet.Activate(); //使子窗体获得焦点
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void 矩形1_Click(object sender, EventArgs e)
        {
            try
            {
                bDrawing = true;
                hWndCtrl.ContextMenuStrip = null;
                Fun.ClearObjShow();
                Rect1 rect1 = Fun.DrawRect1();
                Fun.m_rect1 = rect1;
                hWndCtrl.ContextMenuStrip = contextMenuStrip1;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void 任意形状_Click(object sender, EventArgs e)
        {
            try
            {
                bDrawing = true;
                hWndCtrl.ContextMenuStrip = null;
                Arbitrary m_arbitrary = Fun.DrawArbitrary();
                Fun.m_arbitrary = m_arbitrary;
                hWndCtrl.ContextMenuStrip = contextMenuStrip1;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void 矩形2带方向_Click(object sender, EventArgs e)
        {
            try
            {
                bDrawing = true;
                hWndCtrl.ContextMenuStrip = null;
                Fun.ClearObjShow();
                Rect2 m_Rect2 = Fun.DrawRect2();
                Fun.m_rect2 = m_Rect2;
                hWndCtrl.ContextMenuStrip = contextMenuStrip1;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void 直线_Click(object sender, EventArgs e)
        {
            try
            {
                bDrawing = true;
                hWndCtrl.ContextMenuStrip = null;
                Fun.m_line = Fun.DrawLine();
                hWndCtrl.ContextMenuStrip = contextMenuStrip1;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void 圆_Click(object sender, EventArgs e)
        {
            try
            {
                bDrawing = true;
                hWndCtrl.ContextMenuStrip = null;
                Fun.ClearObjShow();
                BaseData.Circle m_Circle = Fun.DrawCircle();
                Fun.m_circle = m_Circle;
                hWndCtrl.ContextMenuStrip = contextMenuStrip1;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        private void LeftRightImage_Click(object sender, EventArgs e)
        {
            MirrorChange(EnumData.Mirror.Left_Right, this.LoR);
        }

        private void UpDownImage_Click(object sender, EventArgs e)
        {
            MirrorChange(EnumData.Mirror.Up_Down, this.UoD);
        }
        private void MirrorChange(EnumData.Mirror mirrorType, ToolStripMenuItem item)
        {
            try
            {
                if (myListMirror.Contains(mirrorType))
                {
                    myListMirror.Remove(mirrorType);
                    item.Checked = false;
                    item.BackColor = Color.Transparent;
                }
                else
                {
                    myListMirror.Add(mirrorType);
                    item.Checked = true;
                    item.BackColor = Color.Green;
                }
                Fun.m_ListImgMirror = myListMirror;
                SaveCamConfig();
                Fun.MirrorImage(ref Fun.m_hImage);
                Fun.FitImageToWindow(ref Fun.dReslutRow0, ref Fun.dReslutCol0, ref Fun.dReslutRow1, ref Fun.dReslutCol1);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"镜像图像错误：{ex}");
            }
        }

        private void 清除_Click(object sender, EventArgs e)
        {
            Fun.ClearObjShow();
        }
        #endregion

        private void checkBox_CenterCross_CheckedChanged(object sender, EventArgs e)
        {
            Function.m_bShowCross = checkBox_CenterCross.Checked;
            if (checkBox_CenterCross.Checked)
            {
                Fun.ShowCenterCross();
            }
            else
            {
                Fun.ClearObjShow();
            }
        }

        private void CtrlCamShow_Load(object sender, EventArgs e)
        {
        }

        private void hWndCtrl_Resize(object sender, EventArgs e)
        {
            if (null != Fun)
            {
                Fun.dReslutRow0 = 0;
                Fun.dReslutCol0 = 0;
                Fun.dReslutRow1 = 0;
                Fun.dReslutCol1 = 0;
                Fun.FitImageToWindow(ref Fun.dReslutRow0, ref Fun.dReslutCol0, ref Fun.dReslutRow1, ref Fun.dReslutCol1);
            }
        }
        #region 光度立体法
        List<HalconDotNet.HWindowControl> myListWndCtrl = new List<HalconDotNet.HWindowControl>();
        public List<HalconDotNet.HObject> myListImages = new List<HalconDotNet.HObject>();
        //public FormPhotometricStereo formPhotometricStereo;
        public PhotometricStereoImage photometricStereoImage = new PhotometricStereoImage();
        private void but_PhotometricsStereo_Click(object sender, EventArgs e)
        {
            tLPanel_Photometrics.Visible = true;
            toolStrip_photometrics.Visible = true;
            //try
            //{
            //    if (FormMainUI.bRun) return;
            //    if (null == formPhotometricStereo || formPhotometricStereo.IsDisposed)
            //    {
            //        formPhotometricStereo = new FormPhotometricStereo(this);
            //        formPhotometricStereo.Show();
            //    }
            //    else
            //    {
            //        formPhotometricStereo.Activate(); //使子窗体获得焦点
            //    }
            //}
            //catch (Exception ex)
            //{
            //    StaticFun.MessageFun.ShowMessage(ex, true);
            //}
        }

        private void toolStripBtn_ClosePhotometrics_Click(object sender, EventArgs e)
        {
            tLPanel_Photometrics.Visible = false;
            toolStrip_photometrics.Visible = false;
        }

        private void tSBut_Load_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.Description = "请选择一个文件夹";
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog2.SelectedPath;
                string[] files = Directory.GetFiles(folderPath);
                if (files.Length >= 4)
                {
                    this.Fun.ReadImageToHWnd(files[0], hWndCtrl1);
                    this.Fun.ReadImageToHWnd(files[1], hWndCtrl2);
                    this.Fun.ReadImageToHWnd(files[2], hWndCtrl3);
                    this.Fun.ReadImageToHWnd(files[3], hWndCtrl4);
                }
                myListImages = new List<HalconDotNet.HObject>();
                for (int i = 0; i < 4; i++)
                {
                    this.Fun.ReadImage(files[i]);
                    myListImages.Add(this.Fun.HImage);
                }
            }

        }

        private void tSBut_Fusion_Click(object sender, System.EventArgs e)
        {
            if (myListImages.Count < 4) return;
            photometricStereoImage = this.Fun.PhotometricStereo(myListImages);
            MessageBox.Show("图像融合完成！");
        }

        private void Lbl_NormalField_Click(object sender, System.EventArgs e)
        {
            ToolStripLabel lblNormal = new ToolStripLabel();
            try
            {
                ToolStripLabel lbl = sender as ToolStripLabel;
                if (null == lbl) return;
                HOperatorSet.GenEmptyObj(out HObject ho_Image);
                switch (lbl.Text)
                {
                    case "法向量图":
                        ho_Image = photometricStereoImage.NormalField.Clone();
                        break;
                    case "反照率图":
                        ho_Image = photometricStereoImage.Albedo.Clone();
                        break;
                    case "梯度图":
                        ho_Image = photometricStereoImage.Gradient.Clone();
                        break;
                    case "曲率图":
                        ho_Image = photometricStereoImage.Curvature.Clone();
                        break;
                    case "高度信息图":
                        ho_Image = photometricStereoImage.HeightField.Clone();
                        break;
                    default:
                        break;
                }
                Function.ho_ShowImage = ho_Image;
                this.Fun.DispRegion(ho_Image);
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void hWndCtrl1_Resize(object sender, EventArgs e)
        {
            try
            {
                HWindowControl hCtrl = sender as HWindowControl;
                if (null == hCtrl) return;
                int id = -1;
                switch (hCtrl.Name)
                {
                    case "hWndCtrl1":
                        id = 0;
                        break;
                    case "hWndCtrl2":
                        id = 1;
                        break;
                    case "hWndCtrl3":
                        id = 2;
                        break;
                    case "hWndCtrl4":
                        id = 3;
                        break;
                    default:
                        break;
                }
                if (id >= 0 && id <= 3 && myListImages.Count >= 4)
                {
                    this.Fun.ShowImageToHWnd(myListImages[id], hCtrl);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }

        private void hWndCtrl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    HWindowControl hCtrl = sender as HWindowControl;
                    if (null == hCtrl) return;
                    int id = -1;
                    switch (hCtrl.Name)
                    {
                        case "hWndCtrl1":
                            id = 0;
                            break;
                        case "hWndCtrl2":
                            id = 1;
                            break;
                        case "hWndCtrl3":
                            id = 2;
                            break;
                        case "hWndCtrl4":
                            id = 3;
                            break;
                        default:
                            break;
                    }
                    if (id >= 0 && id <= 3)
                    {
                        this.Fun.DispRegion(myListImages[id]);
                        Function.ho_ShowImage = myListImages[id].Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        #endregion
    }
}
