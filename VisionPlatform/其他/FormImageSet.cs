using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public partial class FormImageSet : Form
    {
        public string m_strImgFilePath = "";
        public List<string> m_listImagePath = new List<string>();
        public static bool b_stop = false;
        TMData.DataAll global { get; set; }
        TMData.SelectedCam camc;
        public FormImageSet(TMData.SelectedCam cam, TMData.DataAll m_global)
        {
            InitializeComponent();

            //显示名称
            int n = (int)cam;
            string strCam = "";
            switch (n)
            {
                case 0:
                    strCam = "null";
                    break;
                case 1:
                    strCam = "相机1";
                    break;
                case 2:
                    strCam = "相机2";
                    break;
                case 3:
                    strCam = "相机3";
                    break;
                case 4:
                    strCam = "相机4";
                    break;
                default:
                    break;

            }
            this.Text = "批量图像测试：" + strCam;
            global = m_global;
            camc = cam;
        }

        private void FormImageSet_Load(object sender, EventArgs e)
        {

        }

        public void UIShow(string strImageFilePath, List<string> listImagePath)
        {
            listView_ImagePath.Items.Clear();
            this.textBox_ImagePath.Text = strImageFilePath.ToString();
            int n = listImagePath.Count;
            this.label_ImagesNum.Text = n.ToString();

            for (int i = 0; i < n; i++)
            {
                listView_ImagePath.Items.Add(i.ToString());
                listView_ImagePath.Items[i].SubItems.Add(listImagePath[i]);
            }
            m_listImagePath = new List<string>(listImagePath);

        }

        private void listBox_ImagePath_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Function my_Fun= Function.my_fun[0];
            //int n = listBox_ImagePath.SelectedIndex;
            //string strPath = m_listImagePath[n];
            //my_Fun.ReadImage(strPath);
        }

        private void but_ImageSetPath_Click(object sender, EventArgs e)
        {
            try
            {
                Function fun = TMFunction.GetCurFun(TMFunction.m_cam, out int camID);
                if (fun != null)
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    dialog.Description = "请选择文件夹路径";
                    List<string> listImagePath = new List<string>();
                    string strImgFilePath = "";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        strImgFilePath = dialog.SelectedPath;
                        Function.list_image_files(strImgFilePath, "default", out listImagePath);
                        if (!this.Focused)
                        {
                            //this.new FormImageSet();
                        }
                        this.TopMost = true;
                        this.Show();
                        this.UIShow(strImgFilePath, listImagePath);
                    }
                }
                else
                {
                    Function.ShowMessage("请先选择相机！");
                }


            }
            catch (SystemException ex)
            {
                Function.ShowMessage(ex.ToString());
                return;
            }
        }

        private void but_Run_Click(object sender, EventArgs e)
        {
            b_stop = false;
            try
            {
                //if ("线芯数量" == TMData_Serializer._CamConfig.dic_CamFun[camc])
                //{
                //    Function fun = TMFunction.GetCurFun(TMFunction.m_cam, out int camID);
                //    int n = (int)camc;
                //    for (int i = 0; i < m_listImagePath.Count; i++)
                //    {
                //        fun.ReadImage(m_listImagePath[i]);
                //        TMFunction.my_TMFun[n - 1].CountCoreNumNEW(TMData_Serializer._globalData.coreNumParam[n - 1], out int nCoreNum);
                //        listView_ImagePath.Items[i].SubItems.Add(nCoreNum.ToString());
                //        if (b_stop)
                //        {
                //            return;
                //        }
                //        Application.DoEvents();
                //        Thread.Sleep(20);
                //    }
                //}
                //else if ("端子检测" == TMData_Serializer._CamConfig.dic_CamFun[camc])
                //{

                //    Dictionary<TMData.SelectedCam, List<string>> dicCheckList = new Dictionary<TMData.SelectedCam, List<string>>();
                //    if (0 == global.m_dicCheckList.Count)
                //    {
                //        return;
                //    }
                //    dicCheckList = global.m_dicCheckList;
                //    TMData.ProPrecessParam[] proPrecessParam = new TMData.ProPrecessParam[dicCheckList.Keys.Count];
                //    proPrecessParam = global.proPrecessParams;
                //    Function fun = TMFunction.GetCurFun(TMFunction.m_cam, out int camID);
                //    for (int i = 0; i < m_listImagePath.Count; i++)
                //    {
                //        fun.ReadImage(m_listImagePath[i]);
                //       // Inspect(dicCheckList, proPrecessParam, fun, out string a);
                //        //listView_ImagePath.Items[i].SubItems.Add(a);
                //        if (b_stop)
                //        {
                //            return;
                //        }
                //        Application.DoEvents();
                //        Thread.Sleep(20);
                //    }
                //}
            }
            catch (Exception)
            {
            }
        }

        //private bool Inspect(Dictionary<TMData.SelectedCam, List<string>> dicCheckList, TMData.ProPrecessParam[] proPrecessParam, Function funs, out string a)
        //{
        //    a = "NG";
        //    bool bResult = true;
        //    try
        //    {
        //        if (0 == dicCheckList.Count || null == proPrecessParam)
        //        {
        //            MessageBox.Show("无检测项！");
        //            return false;
        //        }
        //        //压端子检测
        //        if (0 != dicCheckList.Count)
        //        {
        //            bool[] bFlags = new bool[dicCheckList[global.Camera].Count];
        //            int i = 0;
        //            int n = (int)global.Camera - 1;
        //            Rect2 skinWeldROISDSs = new Rect2();
        //            Rect2 skinWeldROISDS = new Rect2();
        //            if (!TMFunction.my_TMFun[n].FindNccModelYXSS(global.Camera, TMData_Serializer._globalData.proPrecessParam[n], out skinWeldROISDSs))
        //            {
        //                MessageBox.Show("未匹配到模板。");
        //                a = "NG";
        //                return false;
        //            }
        //            TMFunction.my_TMFun[n].PreProcessSD();
        //            if (dicCheckList[global.Camera].Count == 0)
        //            {
        //                MessageBox.Show("无压端子检测子项。");
        //                a = "NG";
        //                return false;
        //            }
        //            TMFunction.my_TMFun[n].SelectRegion(skinWeldROISDSs, false, TMData.SelRegion.max, out skinWeldROISDS);
        //            foreach (string strCheck in dicCheckList[global.Camera])
        //            {

        //                if (strCheck == "绝缘皮压脚")
        //                {
        //                    TMData.SkinWeldInspectResult result = new TMData.SkinWeldInspectResult();
        //                    if (TMFunction.my_TMFun[n].SkinWeldInspect(proPrecessParam[n], skinWeldROISDS, out result))
        //                    {
        //                        bFlags[i] = result.bFlag;
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        // "绝缘皮压脚检测出错。".ToLog();
        //                        bResult = false;
        //                        return false;
        //                    }
        //                }
        //                if (strCheck == "绝缘皮位置")
        //                {
        //                    TMData.SkinPosInspectResult result = new TMData.SkinPosInspectResult();
        //                    if (TMFunction.my_TMFun[n].SkinPosInspect(proPrecessParam[n], skinWeldROISDS, out result))
        //                    {
        //                        bFlags[i] = result.bFlag;
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        // "绝缘皮位置检测出错。".ToLog();
        //                        bResult = false;
        //                        return false;
        //                    }
        //                }
        //                if (strCheck == "线芯压脚")
        //                {
        //                    TMData.LineCoreWeldResult result = new TMData.LineCoreWeldResult();
        //                    if (TMFunction.my_TMFun[n].LineCoreWeldInspect(proPrecessParam[n], skinWeldROISDS, out result))
        //                    {
        //                        bFlags[i] = result.bFlag;
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        // "线芯压脚检测出错。".ToLog();
        //                        bResult = false;
        //                        return false;
        //                    }
        //                }
        //                if (strCheck == "线芯位置")
        //                {
        //                    TMData.LineCorePosInspectResult result = new TMData.LineCorePosInspectResult();
        //                    if (TMFunction.my_TMFun[n].LineCorePosInspect(proPrecessParam[n], skinWeldROISDS, out result))
        //                    {
        //                        bFlags[i] = result.bFlag;
        //                        i++;

        //                    }
        //                    else
        //                    {
        //                        //  "线芯位置检测出错。".ToLog();
        //                        bResult = false;
        //                        return false;
        //                    }
        //                }
        //                if (strCheck == "线芯飞边")
        //                {
        //                    TMData.LineCoreSideInspectResult result = new TMData.LineCoreSideInspectResult();
        //                    if (TMFunction.my_TMFun[n].LineCoreSideInspect(proPrecessParam[n], skinWeldROISDS, out result))
        //                    {
        //                        bFlags[i] = result.bFlag;
        //                        i++;
        //                    }
        //                    else
        //                    {
        //                        //  "线芯位置检测出错。".ToLog();
        //                        bResult = false;
        //                        return false;
        //                    }
        //                }
        //            }
        //            foreach (bool flag in bFlags)
        //            {
        //                if (!flag)
        //                {
        //                    bResult = false;
        //                    funs.WriteStringtoImage(30, 12, 12, "NG");
        //                    a = "NG";
        //                    break;
        //                }
        //            }
        //            if (bResult)
        //            {
        //                funs.WriteStringtoImage(30, 12, 12, "OK");
        //                a = "OK";
        //            }

        //        }
        //        return true;
        //    }
        //    catch (SystemException ex)
        //    {
        //        Function.ShowMessage(ex.ToString());
        //        return false;
        //    }
        //}

        private void listView_ImagePath_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string type;
                if (listView_ImagePath.SelectedItems.Count == 0) return;
                else
                {
                    //string site = listView_ImagePath.SelectedItems[0].Text;
                    type = listView_ImagePath.SelectedItems[0].SubItems[1].Text;
                }
                //if ("线芯数量" == TMData_Serializer._CamConfig.dic_CamFun[camc])
                //{
                //    Function fun = TMFunction.GetCurFun(TMFunction.m_cam, out int camID);
                //    int n = (int)camc;
                //    fun.ReadImage(type);
                //    TMFunction.my_TMFun[n - 1].CountCoreNumNEW(TMData_Serializer._globalData.coreNumParam[n - 1], out int nCoreNum);

                //}
                //else if ("端子检测" == TMData_Serializer._CamConfig.dic_CamFun[camc])
                //{
                //    Dictionary<TMData.SelectedCam, List<string>> dicCheckList = new Dictionary<TMData.SelectedCam, List<string>>();
                //    if (null == global.m_dicCheckList)
                //    {
                //        return;
                //    }
                //    dicCheckList = global.m_dicCheckList;
                //    TMData.ProPrecessParam[] proPrecessParam = new TMData.ProPrecessParam[dicCheckList.Keys.Count];
                //    proPrecessParam = global.proPrecessParams;
                //    Function fun = TMFunction.GetCurFun(TMFunction.m_cam, out int camID);
                //    fun.ReadImage(type);
                //    //Inspect(dicCheckList, proPrecessParam, fun, out string a);
                //}
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b_stop = true;
        }
    }
}
