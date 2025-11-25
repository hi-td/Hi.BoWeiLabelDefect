using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CamSDK;
using GxIAPINET;
using GxMultiCam;

namespace VisionPlatform
{
    class DaHengCam
    {
        public static Dictionary<string, int> m_listCamSer = new Dictionary<string, int>();    //保存相机序列号
        public static List<CCamerInfo> m_listCCamerInfo = new List<CCamerInfo>();           ///<相机参数状态列表
        public static IGXFactory m_objIGXFactory = null;                             ///<Factory对像
        public static List<IGXDeviceInfo> m_listIGXDeviceInfo = new List<IGXDeviceInfo>();        ///<设备信息列表
        public static int m_nCamNum = 0;                                 ///<初始化相机数目
        // int m_nOperateID = -1;                               ///<操作相机编号       


        // CFps m_objCFps = new CFps();          ///<统计帧率的对象
        // IGXDevice m_objIGXDevice = null;                ///<设备对像
        // IGXStream m_objIGXStream = null;                ///<流对像
        //  IGXFeatureControl m_objIGXFeatureControl = null;                ///<远端设备属性控制器对像                            ///<图像显示类对象
        //   IGXFeatureControl m_objIGXStreamFeatureControl = null;                ///<流层属性控制器对象
        //   string m_strSN = "";                  ///<序列号
        //  bool m_bIsColor = false;               ///<是否支持彩色相机
        //  byte[] m_byMonoBuffer = null;                ///<黑白相机buffer
        //  byte[] m_byColorBuffer = null;                ///<彩色相机buffer       
        //  int m_nWidth = 0;                   ///<图像宽度
        //  int m_nHeigh = 0;                   ///<图像高度
        //  Bitmap m_bitmap = null;                ///<bitmap对象
        const uint PIXEL_FORMATE_BIT = 0x00FF0000;          ///<用于与当前的数据格式进行与运算得到当前的数据位数
        const uint GX_PIXEL_8BIT = 0x00080000;          ///<8位数据图像格式
        const int CP_NOCLOSE_BUTTON = 0x200;               ///<用于禁用窗体的关闭按钮
        //  int m_nOperateID = 0;                   ///<选择的相机号
        //  GxBitmap m_objGxBitmap = null;                ///<图像显示类对象

        /// <summary>
        /// 设备打开后初始化界面
        /// </summary>
        private static void __InitUI(int nCamID)
        {
            GetShutter(nCamID);                                                                                                   //曝光初始化
            GetGain(nCamID);                                                                                                      //增益的初始化
            __InitAcquisitionSpeedLevelUI(nCamID);                                                                                     //采集速度级别的初始化
            //__InitEnumComBoxUI(m_cb_AutoWhite, "BalanceWhiteAuto"
            //                , m_listCCamerInfo[m_nOperateID].m_objIGXFeatureControl
            //                , ref m_listCCamerInfo[m_nOperateID].m_bWhiteAuto);                                                 //自动白平衡的初始化
            //获取白平衡当前的值
            bool bIsImplemented = false;             //是否支持
            bool bIsReadable = false;                //是否可读
            // 获取是否支持
            if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
            {
                bIsImplemented = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.IsImplemented("BalanceWhiteAuto");
                bIsReadable = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.IsReadable("BalanceWhiteAuto");
                if (bIsImplemented)
                {
                    if (bIsReadable)
                    {
                        //获取当前功能值
                        m_listCCamerInfo[nCamID].m_strBalanceWhiteAutoValue = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetEnumFeature("BalanceWhiteAuto").GetValue();
                    }
                }
            }
        }

        //获取曝光值
        public static double GetShutter(int nCamID)
        {
            double dCurShuter = 0.0;                 //当前曝光值
            double dMin = 0.0;                       //最小值
            double dMax = 0.0;                       //最大值
            string strUnit = "";                     //单位
            string strText = "";                     //显示内容

            //获取当前相机的曝光值、最小值、最大值和单位
            if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
            {
                dCurShuter = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetValue();
                dMin = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMin();
                dMax = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMax();
                strUnit = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetUnit();
            }

            //刷新曝光范围及单位到界面上
            strText = string.Format("曝光时间({0}~{1}){2}", dMin.ToString("0.00"), dMax.ToString("0.00"), strUnit);
            // m_lbl_Shutter.Text = strText;

            //当前的曝光值刷新到曝光的编辑框
            //  m_txt_Shutter.Text = dCurShuter.ToString("0.00");

            return Math.Round(dCurShuter, 2);
        }
        //设置曝光值
        public static void SetShutter(int nCamID, double dShutter)
        {
            // double dShutterValue = 0.0;              //曝光值
            double dMin = 0.0;                       //最小值
            double dMax = 0.0;                       //最大值
            string strValue = "";                     //曝光改变前的值
            try
            {
                if (!m_listCCamerInfo[nCamID].m_bIsOpen || m_listCCamerInfo.Count == 0)
                {
                    return;
                }

                strValue = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetValue().ToString();

                //获取当前相机的曝光值、最小值、最大值和单位
                if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
                {
                    dMin = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMin();
                    dMax = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").GetMax();
                    //判断输入值是否在曝光时间的范围内
                    //若大于最大值则将曝光值设为最大值
                    if (dShutter > dMax)
                    {
                        dShutter = dMax;
                    }
                    //若小于最小值将曝光值设为最小值
                    if (dShutter < dMin)
                    {
                        dShutter = dMin;
                    }

                    // m_txt_Shutter.Text = dShutterValue.ToString("F2");
                    m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(dShutter);
                }
            }
            catch (CGalaxyException ex)
            {
                string strErrorInfo = "错误码为：" + ex.GetErrorCode().ToString() + "错误描述信息为：" + ex.Message;
                MessageBox.Show(strErrorInfo);
            }
        }

        // 获取增益值
        public static double GetGain(int nCamID)
        {
            double dCurGain = 0;             //当前增益值
            double dMin = 0.0;               //最小值
            double dMax = 0.0;               //最大值
            string strUnit = "";             //单位
            string strText = "";             //显示内容

            //获取当前相机的增益值、最小值、最大值和单位
            if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
            {
                dCurGain = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetValue();
                dMin = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMin();
                dMax = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMax();
                strUnit = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetUnit();
            }

            //更新增益值范围到界面
            strText = string.Format("增益({0}~{1}){2}", dMin.ToString("0.00"), dMax.ToString("0.00"), strUnit);
            // m_lbl_Gain.Text = strText;

            //当前的增益值刷新到增益的编辑框
            string strCurGain = dCurGain.ToString("0.00");
            //  m_txt_Gain.Text = strCurGain;
            return Math.Round(dCurGain, 2);
        }
        //设置增益值
        public static void SetGain(int nCamID, double dGain)
        {
            //  double dGain = 0;            //增益值
            double dMin = 0.0;           //最小值
            double dMax = 0.0;           //最大值
            string strValue = "";                     //改变前的增益值
            try
            {
                if (!m_listCCamerInfo[nCamID].m_bIsOpen)
                {
                    return;
                }
                strValue = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetValue().ToString();
                //try
                //{
                //    dGain = Convert.ToDouble(m_txt_Gain.Text);
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("请输入正确的增益值");
                //    m_txt_Gain.Text = strValue;
                //    return;
                //}

                //当前相机的增益值、最小值、最大值
                if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
                {
                    dMin = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMin();
                    dMax = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").GetMax();

                    //判断输入值是否在增益值的范围内
                    //若输入的值大于最大值则将增益值设置成最大值
                    if (dGain > dMax)
                    {
                        dGain = dMax;
                    }

                    //若输入的值小于最小值则将增益的值设置成最小值
                    if (dGain < dMin)
                    {
                        dGain = dMin;
                    }

                    //m_txt_Gain.Text = dGain.ToString("F2");
                    m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetFloatFeature("Gain").SetValue(dGain);
                }
            }
            catch (CGalaxyException ex)
            {
                string strErrorInfo = "错误码为：" + ex.GetErrorCode().ToString() + "错误描述信息为：" + ex.Message;
                MessageBox.Show(strErrorInfo);
            }
        }

        //获取帧率
        public static double GetFPS(int nCamID)
        {
            double dFPS = 0;
            if (null != m_listCCamerInfo[nCamID].m_CamOperate)
            {
                dFPS = m_listCCamerInfo[nCamID].m_CamOperate.UpdateFPS();
            }
            return Math.Round(dFPS, 2);
        }

        /// <summary>
        /// 采集速度级别界面初始化
        /// </summary>
        private static void __InitAcquisitionSpeedLevelUI(int nCamID)
        {
            Int64 nCurAcquisitionSpeedLevel = 0;             //当前采集速度级别
            Int64 nMin = 0;           //最小值
            Int64 nMax = 0;           //最大值
            string strText = "";      //显示内容

            //获取当前相机的采集速度级别、最小值、最大值
            if (null != m_listCCamerInfo[nCamID].m_objIGXFeatureControl)
            {
                if (!(m_listCCamerInfo[nCamID].m_objIGXFeatureControl.IsImplemented("AcquisitionSpeedLevel")))
                {
                    m_listCCamerInfo[nCamID].m_bAcqSpeedLevel = false;

                    //更新采集速度级别值范围到界面
                    //  m_lbl_AcqSpeedLevel.Text = "采集速度级别";
                    //m_txt_AcqSpeedLevel.Text = "";
                    return;
                }

                m_listCCamerInfo[nCamID].m_bAcqSpeedLevel = true;
                nCurAcquisitionSpeedLevel = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetIntFeature("AcquisitionSpeedLevel").GetValue();
                nMin = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetIntFeature("AcquisitionSpeedLevel").GetMin();
                nMax = m_listCCamerInfo[nCamID].m_objIGXFeatureControl.GetIntFeature("AcquisitionSpeedLevel").GetMax();
            }

            //更新采集速度级别值范围到界面
            strText = string.Format("采集速度级别({0}~{1})", nMin.ToString(), nMax.ToString());
            //  m_lbl_AcqSpeedLevel.Text = strText;

            //当前的采集速度级别值刷新到增益的编辑框
            string strCurAcquisitionSpeedLevel = nCurAcquisitionSpeedLevel.ToString();
            // m_txt_AcqSpeedLevel.Text = strCurAcquisitionSpeedLevel;
        }

        /// <summary>
        /// 枚举型功能ComBox界面初始化
        /// </summary>
        /// <param name="cbEnum">ComboBox控件名称</param>
        /// <param name="strFeatureName">枚举型功能名称</param>
        /// <param name="objIGXFeatureControl">属性控制器对像</param>
        /// <param name="bIsImplemented">是否支持</param>
        private static void __InitEnumComBoxUI(ComboBox cbEnum, string strFeatureName, IGXFeatureControl objIGXFeatureControl, ref bool bIsImplemented)
        {
            string strTriggerValue = "";                   //当前选择项
            List<string> list = new List<string>();        //Combox将要填入的列表
            bool bIsReadable = false;                      //是否可读
            // 获取是否支持
            if (null != objIGXFeatureControl)
            {

                bIsImplemented = objIGXFeatureControl.IsImplemented(strFeatureName);
                // 如果不支持则直接返回
                if (!bIsImplemented)
                {
                    return;
                }

                bIsReadable = objIGXFeatureControl.IsReadable(strFeatureName);

                if (bIsReadable)
                {
                    list.AddRange(objIGXFeatureControl.GetEnumFeature(strFeatureName).GetEnumEntryList());
                    //获取当前功能值
                    strTriggerValue = objIGXFeatureControl.GetEnumFeature(strFeatureName).GetValue();
                }

            }

            //清空组合框并更新数据到窗体
            cbEnum.Items.Clear();
            foreach (string str in list)
            {
                cbEnum.Items.Add(str);
            }

            //获得相机值和枚举到值进行比较，刷新对话框
            for (int i = 0; i < cbEnum.Items.Count; i++)
            {
                string strTemp = cbEnum.Items[i].ToString();
                if (strTemp == strTriggerValue)
                {
                    cbEnum.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// 枚举设备
        /// </summary>
        /// 
        public static bool __EnumDevice()
        {
            m_listCamSer.Clear();
            m_listIGXDeviceInfo.Clear();
            m_listCCamerInfo.Clear();
            m_objIGXFactory = IGXFactory.GetInstance();
            m_objIGXFactory.Init();
            if (null != m_objIGXFactory)
            {
                m_objIGXFactory.UpdateDeviceList(200, m_listIGXDeviceInfo);
            }
            // 判断当前连接设备个数
            if (m_listIGXDeviceInfo.Count <= 0)
            {
                MessageBox.Show("未检测到设备,请确保设备正常连接然后重启程序!");
                return false;
            }
           // m_nCamNum = __GetMin(m_listIGXDeviceInfo.Count);
            for (int i = 0; i < m_listIGXDeviceInfo.Count; i++)
            {
                m_listCamSer.Add(m_listIGXDeviceInfo[i].GetSN(),i);
                CCamerInfo objCCamerInfo = new CCamerInfo();
                objCCamerInfo.m_strDisplayName = m_listIGXDeviceInfo[i].GetDisplayName();
                objCCamerInfo.m_strSN = m_listIGXDeviceInfo[i].GetSN();
                objCCamerInfo.m_emDeviceType = m_listIGXDeviceInfo[i].GetDeviceClass();
                m_listCCamerInfo.Add(objCCamerInfo);
            }
            CamSDK.CamCommon.m_listCamSer = m_listCamSer;
            return true;
        }

        public static void OpenDevice(int nCamID, Function fun)
        {
            string strSN = ""; //打开设备用的序列号
            try
            {
                if (-1 == nCamID)
                    return;
                // 判断当前连接设备个数
                if (m_listIGXDeviceInfo.Count <= 0)
{
                    StaticFun.MessageFun.ShowMessage("未发现设备!");
                    return;
                }
                try
                {
                    //停止流通道、注销采集回调和关闭流
                    if (null != m_listCCamerInfo[nCamID].m_objIGXStream)
                    {
                        m_listCCamerInfo[nCamID].m_objIGXStream.Close();
                        m_listCCamerInfo[nCamID].m_objIGXStream = null;
                    }
                }
                catch (Exception)
                {
                }
                // 如果设备已经打开则关闭，保证相机在初始化出错情况下能再次打开
                if (null != m_listCCamerInfo[nCamID].m_objIGXDevice)
                {
                    m_listCCamerInfo[nCamID].m_objIGXDevice.Close();
                    m_listCCamerInfo[nCamID].m_objIGXDevice = null;
                }

                strSN = m_listIGXDeviceInfo[nCamID].GetSN();
                IGXDevice objIGXDevice = m_objIGXFactory.OpenDeviceBySN(strSN, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                //打开列表选中的设备
                m_listCCamerInfo[nCamID].m_objIGXDevice = objIGXDevice;
                m_listCCamerInfo[nCamID].m_objIGXFeatureControl = m_listCCamerInfo[nCamID].m_objIGXDevice.GetRemoteFeatureControl();

                // __InitParam();

                // 获取相机参数,初始化界面控件
                // __InitUI();

                Operate objImageShowFrom = new Operate(objIGXDevice, fun);
                objImageShowFrom.OpenDevice();
                objImageShowFrom.StartDevice();
                m_listCCamerInfo[nCamID].m_CamOperate = objImageShowFrom;

                // 更新设备打开标识
                m_listCCamerInfo[nCamID].m_bIsOpen = true;

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// 当枚举的相机个数超过4个，按4个显示，小于等于4个按实际值显示
        /// 当枚举的相机个数小于0按0返回
        /// </summary>
        /// <param name="nDeviceCount">实际枚举到的个数</param>
        /// <returns>显示的最小个数</returns>
        private static int __GetMin(int nDeviceCount)
        {
            if (nDeviceCount < 0)
            {
                return 0;
            }

            if (nDeviceCount > 4)
            {
                return 4;
            }

            return nDeviceCount;
        }
        //实时显示
        public static void Live(int camID)
        {
            try
            {
                if (m_listCCamerInfo.Count == 0 || null == m_listCCamerInfo[camID].m_CamOperate)
                    return;
                if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                {
                    //设置触发模式为关
                    m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
                    //设置采集模式连续采集
                    m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                    m_listCCamerInfo[camID].m_bIsSnap = true;
                }

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }
        public static void StartDevice(int camID)
        {
            try
            {
                if (m_listCCamerInfo.Count == 0 || null == m_listCCamerInfo[camID].m_CamOperate)
                    return;
                //for (int i = 0; i < DaHengCam.m_listCCamerInfo.Count; i++)
                //{
                //    if (DaHengCam.m_listCCamerInfo[i].m_bIsSnap)
                //    {
                //        DaHengCam.StopLive(i);
                //    }
                //}

                if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                {
                    //设置触发模式为关
                    m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
                    //设置采集模式连续采集
                    m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                    m_listCCamerInfo[camID].m_bIsSnap = true;
                }

            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.Message);
            }
        }
        public static void StartDeviceAll(int camID)
        {
            try
            {
                if (null == m_listCCamerInfo[camID].m_CamOperate)
                    return;
                for (int i = 0; i < DaHengCam.m_listCCamerInfo.Count; i++)
                {
                    if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                    {
                        //设置触发模式为关
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
                        //设置采集模式连续采集
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");
                        m_listCCamerInfo[camID].m_bIsSnap = true;
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }
        public static void _StartAllDevice()
        {
            try
            {
                for (int i = 0; i < m_listCCamerInfo.Count; i++)
                {
                    if (null == m_listCCamerInfo[i].m_CamOperate)
                    {
                        return;
                    }
                    StartDeviceAll(i);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }

        public static void StopDevice(int camID)
        {
            try
            {
                if (null != m_listCCamerInfo[camID].m_CamOperate)
                {
                    m_listCCamerInfo[camID].m_CamOperate.StopDevice();
                    m_listCCamerInfo[camID].m_bIsSnap = false;
                }
                else
                {
                    // StaticFun.MessageFun.ShowMessage("相机对象为空。");
                    return;
                }
                // 更新界面UI
                //__UpdateUI();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }

        public static void StopLiveAll()
        {
            try
            {
                for (int camID = 0; camID < m_listCCamerInfo.Count; camID++)
                {
                    if (null != m_listCCamerInfo[camID].m_CamOperate)
                    {
                        if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                        {
                            //设置当前功能值
                            m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                            //切换"触发极性"
                            m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerActivation").SetValue("RisingEdge");
                            //设置当前功能值
                            m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
                        }
                        m_listCCamerInfo[camID].m_bIsSnap = false;
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }
        //相机设置为硬触发(Line0)
        public static void IntSignal()
        {
            try
            {
                for (int i = 0; i < m_listCCamerInfo.Count; i++)
                {
                    if (null != m_listCCamerInfo[i].m_CamOperate)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
        }
        //设置相机IO输出(Line2或Line3)
        public static void OutSignal(int camID, string a, bool b)
        {
            //a为引脚：Line2和Line3;b为电平是否反转，引脚为输出后，Line2或Line3端有3.3V电压，电平反转后为0V
            try
            {
                if (null != m_listCCamerInfo[camID].m_CamOperate)
                {
                    if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                    {
                        //设置IO引脚
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("LineSelector").SetValue(a);
                        //设置为输出IO
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("LineMode").SetValue("Output");
                        //设置引脚电平
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetBoolFeature("LineInverter").SetValue(b);
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
        }
        public static void GrabImage(int camID)
        {
            try
            {
                if (null != m_listCCamerInfo[camID].m_CamOperate)
                {
                    if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                    {
                        //设置当前功能值
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                        //切换"触发极性"
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerActivation").SetValue("RisingEdge");
                        //设置当前功能值
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
                    }
                    m_listCCamerInfo[camID].m_CamOperate.GrabImage();
                    m_listCCamerInfo[camID].m_bIsSnap = false;
                }

                // 更新界面UI
                //__UpdateUI();
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
                //MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 关闭所有的设备和流
        /// </summary>
        public static void __CloseAll()
        {
            for (int i = 0; i < m_listCCamerInfo.Count; i++)
            {
                if (null != m_listCCamerInfo[i].m_CamOperate)
                {
                    m_listCCamerInfo[i].m_CamOperate.CloseDevice();
                    m_listCCamerInfo[i].m_bIsSnap = false;
                    m_listCCamerInfo[i].m_bIsOpen = false;
                }
            }
            m_listCCamerInfo.Clear();
            m_objIGXFactory.Uninit();
        }

        public static CamCommon.CamParam GetCamParam(int camID)
        {
            CamCommon.CamParam camParam = new CamCommon.CamParam();
            try
            {
                //帧率
                camParam.frame = (float)(Math.Round(DaHengCam.GetFPS(camID), 2));
                //增益
                camParam.gain = (float)(DaHengCam.GetGain(camID));
                //曝光
                camParam.exposure = (float)(DaHengCam.GetShutter(camID));

            }
            catch (SystemException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            return camParam;
        }


        public static void TouchImage(int camID)
        {
            try
            {

                if (null != m_listCCamerInfo[camID].m_CamOperate)
                {
                    if (null != m_listCCamerInfo[camID].m_objIGXFeatureControl)
                    {
                        //设置为触发模式
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                        //设置"触发极性"（FallingEdge：下降沿   RisingEdge：上升沿）
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerActivation").SetValue("FallingEdge");
                        //设置触发源
                        m_listCCamerInfo[camID].m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line2");

                    }
                }
                //每次发送触发命令之前清空采集输出队列
                //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
                if (null != m_listCCamerInfo[camID].m_CamOperate.m_objIGXStream)
                {
                    m_listCCamerInfo[camID].m_CamOperate.m_objIGXStream.FlushQueue();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
