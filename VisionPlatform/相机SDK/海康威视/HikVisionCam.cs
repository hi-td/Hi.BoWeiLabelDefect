using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using VisionPlatform;
using EnumData;
using MvCamCtrl.NET;
using System.Linq;
using Hi.Ltd;

namespace CamSDK
{
    public class HikVisionCam
    {
        private static MyCamera.MV_CC_DEVICE_INFO_LIST m_pDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        private static List<MyCamera> m_listMyCam = new List<MyCamera>();
        private static List<string> m_listCamSer = new List<string>();                                        //相机名称列表，添加到comboBox控件
        private static List<bool> m_bDevOpen = new List<bool>();                                              //在OpenListDevice()变为true
        private static List<bool> m_bLive = new List<bool>();
        private static List<bool> m_TriggerMode = new List<bool>();                                           //相机的触发模式：软触发或外触发

        public static bool DeviceListAcq()
        {
            CamCommon.m_listCamSer = new Dictionary<string,int>();
            int nRet;
            try
            {
                // ch:创建设备列表 || en: Create device list
                System.GC.Collect();
                nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_pDeviceList);
                if (MyCamera.MV_OK != nRet)
                {
                    MessageBox.Show("Enum Devices Fail");
                    return false;
                }

                // ch:在窗体列表中显示设备名 || Display the device'name on window's list
                for (int i = 0; i < m_pDeviceList.nDeviceNum; i++)
                {
                    MyCamera.MV_CC_DEVICE_INFO device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        if (gigeInfo.chUserDefinedName != "")
                        {
                            CamCommon.m_listCamSer.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")",i);
                            m_listCamSer.Add("GigE: " + gigeInfo.chUserDefinedName + " (" + gigeInfo.chSerialNumber + ")");
                        }
                        else
                        {
                            CamCommon.m_listCamSer.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")",i);
                            m_listCamSer.Add("GigE: " + gigeInfo.chManufacturerName + " " + gigeInfo.chModelName + " (" + gigeInfo.chSerialNumber + ")");
                        }
                    }
                    else if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                        MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                        if (usbInfo.chUserDefinedName != "")
                        {
                            CamCommon.m_listCamSer.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")",i);
                            m_listCamSer.Add("USB: " + usbInfo.chUserDefinedName + " (" + usbInfo.chSerialNumber + ")");
                        }
                        else
                        {
                            CamCommon.m_listCamSer.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")",i);
                            m_listCamSer.Add("USB: " + usbInfo.chManufacturerName + " " + usbInfo.chModelName + " (" + usbInfo.chSerialNumber + ")");
                        }
                    }
                }
                //防止当相机处于开启或实时状态时（Open和Live处理true），操作了相机初始化
                //CamCommon.m_bOpen.Clear();
                //CamCommon.m_bLive.Clear();
                for (int i = 0; i < m_listCamSer.Count; i++)
                {
                    //CamCommon.m_bOpen.Add(false);
                    m_bDevOpen.Add(false);
                   // CamCommon.m_bLive.Add(false);
                    m_bLive.Add(false);
                    m_TriggerMode.Add(false);      //默认相机触发模式为软触发
                }
                return true;
            }
            catch (SystemException error)
            {
                error.Message.Log();
                return false;
            }
        }

        public static bool OpenListDevice()
        {
            try
            {
                if (m_pDeviceList.nDeviceNum == 0 || m_listCamSer.Count == 0)
                {
                    ("打开相机时：无相机").Log();
                    return false;
                }
                int nRet = -1;

                for (Int32 i = 0; i < m_pDeviceList.nDeviceNum; i++)
                {
                    // ch:打印设备信息 en:Print device info
                    MyCamera.MV_CC_DEVICE_INFO stDevInfo;
                    stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_pDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                    if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                    {
                        MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        uint nIp1 = ((stGigEDeviceInfo.nCurrentIp & 0xff000000) >> 24);
                        uint nIp2 = ((stGigEDeviceInfo.nCurrentIp & 0x00ff0000) >> 16);
                        uint nIp3 = ((stGigEDeviceInfo.nCurrentIp & 0x0000ff00) >> 8);
                        uint nIp4 = (stGigEDeviceInfo.nCurrentIp & 0x000000ff);
                        StaticFun.MessageFun.ShowMessage("[device " + i.ToString() + "]:");
                        StaticFun.MessageFun.ShowMessage("DevIP:" + nIp1 + "." + nIp2 + "." + nIp3 + "." + nIp4);
                        StaticFun.MessageFun.ShowMessage("UserDefineName:" + stGigEDeviceInfo.chUserDefinedName + "\n");
                    }
                    else if (MyCamera.MV_USB_DEVICE == stDevInfo.nTLayerType)
                    {
                        MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                        StaticFun.MessageFun.ShowMessage("[device " + i.ToString() + "]:");
                        StaticFun.MessageFun.ShowMessage("SerialNumber:" + stUsb3DeviceInfo.chSerialNumber);
                        StaticFun.MessageFun.ShowMessage("UserDefineName:" + stUsb3DeviceInfo.chUserDefinedName + "\n");
                    }
                    //创建设备
                    MyCamera myCamera = new MyCamera();
                    nRet = myCamera.MV_CC_CreateDevice_NET(ref stDevInfo);
                    m_listMyCam.Add(myCamera);
                    if (MyCamera.MV_OK != nRet)
                    {
                        return false;
                    }

                    // ch:打开设备 | en:Open device
                    nRet = myCamera.MV_CC_OpenDevice_NET();
                    if (MyCamera.MV_OK != nRet)
                    {
                        StaticFun.MessageFun.ShowMessage("打开相机" + i.ToString() + "失败！");
                        m_bDevOpen[i] = false;
                        return false;
                    }

                    // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                    if (stDevInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        int nPacketSize = myCamera.MV_CC_GetOptimalPacketSize_NET();
                        if (nPacketSize > 0)
                        {
                            nRet = myCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                            if (nRet != MyCamera.MV_OK)
                            {
                                StaticFun.MessageFun.ShowMessage("Warning: Set Packet Size failed {0:x8}");
                            }
                        }
                        else
                        {
                            StaticFun.MessageFun.ShowMessage("Warning: Get Packet Size failed {0:x8}");
                        }
                    }
                    m_bDevOpen[i] = true;
                }
                return true;
            }
            catch (SystemException error)
            {
                error.Message.Log();
                return false;
            }
        }

        public static void Live(int i)
        {
            try
            {
                if (!m_bDevOpen[i])
                {
                    StaticFun.MessageFun.ShowMessage("相机未打开！");
                    return;
                }
                MyCamera myCamera = new MyCamera();
                myCamera = m_listMyCam[i];
                //设置触发模式为0连续触发
                int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", 0);
                myCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);
                m_TriggerMode[i] = false;

            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        public static bool SetTriggerMode(int nCam, bool bTriggerMode)
        {
            //bTriggerMode = true 软触发，bTriggerMode = false 外触发
            try
            {
                if (nCam >= m_listMyCam.Count)
                    return false;
                MyCamera myCamera = m_listMyCam[nCam];
                int nRet = MyCamera.MV_OK;
                nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                if (nRet != MyCamera.MV_OK)
                {
                    MessageBox.Show("Set TriggerMode Fail");
                    return false;
                }
                // ch:触发源选择:0 - Line0; | en:Trigger source select:0 - Line0;
                //           1 - Line1;
                //           2 - Line2;
                //           3 - Line3;
                //           4 - Counter;
                //           7 - Software;
                if (bTriggerMode)
                {
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", 7); // 软触发
                    if (nRet != MyCamera.MV_OK)
                    {
                        return false;
                    }
                    nRet = myCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
                    if (MyCamera.MV_OK != nRet)
                    {
                        StaticFun.MessageFun.ShowMessage("设置海康相机<软触发>模式失败。");
                        return false;
                    }
                }
                else
                {
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", 0);
                    if (nRet != MyCamera.MV_OK)
                    {
                        StaticFun.MessageFun.ShowMessage("设置海康相机<外触发>模式失败。");
                        return false;
                    }
                }
                m_TriggerMode[nCam] = bTriggerMode;
                return true;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                StaticFun.MessageFun.ShowMessage("设置海康相机触发模式失败。");
                "设置海康相机触发模式失败。".Log();
                return false;
            }
        }

        public static bool GrabImage(int nCam)
        {
            if (nCam >= m_listMyCam.Count)
                return false;
            MyCamera myCamera = m_listMyCam[nCam];
            int nRet = MyCamera.MV_OK;
            if (m_TriggerMode[nCam])  //判断当前相机是否处于软触发状态
            {
                nRet = myCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
                if (MyCamera.MV_OK != nRet)
                {
                    StaticFun.MessageFun.ShowMessage("相机软触发失败。");
                    return false;
                }
            }
            else
            {
                SetTriggerMode(nCam, true);
                //StaticFun.MessageFun.ShowMessage("相机非软触发模式。");
                return false;
            }
            return true;
        }

        public static bool LiveThread(int i, Function fun)
        {
            try
            {
                if (!m_bDevOpen[i])
                {
                    m_bLive[i] = false;
                    StaticFun.MessageFun.ShowMessage("相机未打开。");
                    return false;
                }
                if (m_bLive[i])
                {
                    return false;
                }
                MyCamera myCamera = new MyCamera();
                myCamera = m_listMyCam[i];
                //设置触发模式为0连续触发
                int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", 0);
                myCamera.MV_CC_SetEnumValue_NET("AcquisitionMode", 2);
                // ch:开启抓图 | en:start grab
                nRet = myCamera.MV_CC_StartGrabbing_NET();
                if (MyCamera.MV_OK != nRet)
                {
                    StaticFun.MessageFun.ShowMessage("抓图失败！");
                    m_bLive[i] = false;
                    return false;
                }
                Thread hReceiveImageThreadHandle = new Thread(ReceiveImageWorkThread);
                Tuple<MyCamera, Function> tuple = new Tuple<MyCamera, Function>(myCamera, fun);
                hReceiveImageThreadHandle.Start(tuple);
                m_bLive[i] = true;
                return true;
            }
            catch (SystemException ex)
            {
                ex.ToString();
                m_bLive[i] = false;
                return false;
            }
        }
        public static void StopLiveAll()
        {
            try
            {
                MyCamera myCamera = new MyCamera();
                for (int i = 0; i < m_listMyCam.Count(); i++)
                {
                    if (!m_bDevOpen[i])
                    {
                        StaticFun.MessageFun.ShowMessage("相机" + m_listCamSer[i] + "未打开。");
                        continue;
                    }
                    myCamera = m_listMyCam[i];
                    int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", 1);
                    m_bLive[i] = false;
                }

            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }
        public static void StopLive(int n)
        {
            //结束线程
            MyCamera myCamera = new MyCamera();
            myCamera = m_listMyCam[n];
            if (m_bLive[n])
            {
                m_bLive[n] = false;
                // ch:停止抓图 || en:Stop grab image
                myCamera.MV_CC_StopGrabbing_NET();
            }

            m_bLive[n] = false;
        }

        public static void Exposure(int nCam, int value)
        {
            try
            {
                MyCamera myCamera = new MyCamera();
                myCamera = m_listMyCam[nCam];
                int nRet;
                myCamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
                nRet = myCamera.MV_CC_SetFloatValue_NET("ExposureTime", value);
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Exposure Time Fail!", nRet);
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }
        public static void Gain(int nCam, int value)
        {
            try
            {
                MyCamera myCamera = new MyCamera();
                myCamera = m_listMyCam[nCam];
                int nRet;
                myCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
                nRet = myCamera.MV_CC_SetFloatValue_NET("Gain", (float)value);
                if (nRet != MyCamera.MV_OK)
                {
                    ShowErrorMsg("Set Gain Fail!", nRet);
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }
        }

        public static void DestroyDev()
        {
            try
            {
                // ch:关闭设备 || en: Close device90
                for (int i = 0; i < m_listMyCam.Count; i++)
                {
                    if (m_bDevOpen[i])
                    {
                        MyCamera myCamera = m_listMyCam[i];
                        myCamera.MV_CC_CloseDevice_NET();
                        myCamera.MV_CC_DestroyDevice_NET();
                        m_bDevOpen[i] = false;
                        m_bLive[i] = false;
                    }
                }
            }
            catch (SystemException ex)
            {
                ex.ToString();
                return;
            }

        }

        //获取相机的曝光时间、增益、帧率
        public static CamCommon.CamParam GetCamParam(int nCam)
        {
            CamCommon.CamParam camParam = new CamCommon.CamParam();
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

            MyCamera myCamera = new MyCamera();
            myCamera = m_listMyCam[nCam];

            int nRet = myCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                camParam.exposure = stParam.fCurValue;
            }
            nRet = myCamera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                camParam.gain = stParam.fCurValue;
            }
            nRet = myCamera.MV_CC_GetFloatValue_NET("ResultingFrameRate", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                camParam.frame = stParam.fCurValue;
            }
            return camParam;
        }

        public static void ReceiveImageWorkThread(object obj)
        {
            if (null == m_bLive)
            {
                return;
            }
            int nRet = MyCamera.MV_OK;
            if (!(obj is Tuple<MyCamera, InspectFunction>))
            {
                return;
            }
            Tuple<MyCamera, InspectFunction> tuple = obj as Tuple<MyCamera, InspectFunction>;
            MyCamera device = tuple.Item1;
            InspectFunction fun = tuple.Item2;

            MyCamera.MV_FRAME_OUT stFrameOut = new MyCamera.MV_FRAME_OUT();

            IntPtr pImageBuf = IntPtr.Zero;
            int nImageBufSize = 0;

            IntPtr pTemp = IntPtr.Zero;
            int n = 0;
            for (int i = 0; i < m_listMyCam.Count; i++)
            {
                if (device == m_listMyCam[i])
                {
                    n = i;
                }
            }
            while (m_bLive[n])
            {
                nRet = device.MV_CC_GetImageBuffer_NET(ref stFrameOut, 1000);
                if (MyCamera.MV_OK == nRet)
                {
                    if (IsColorPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                        {
                            pTemp = stFrameOut.pBufAddr;
                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf || nImageBufSize < (stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3))
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }

                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3);
                                if (IntPtr.Zero == pImageBuf)
                                {
                                    break;
                                }
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight * 3;
                            }

                            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;//源数据
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;//图像宽度
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;//图像高度
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;//源数据的格式
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;
                            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                            if (MyCamera.MV_OK != nRet)
                            {
                                break;
                            }
                            pTemp = pImageBuf;
                        }

                        fun.GetImageFromCam(CamColor.color, pTemp, stFrameOut.stFrameInfo.nWidth, stFrameOut.stFrameInfo.nHeight, "rgb");

                    }
                    else if (IsMonoPixelFormat(stFrameOut.stFrameInfo.enPixelType))
                    {
                        if (stFrameOut.stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8)
                        {
                            pTemp = stFrameOut.pBufAddr;
                        }
                        else
                        {
                            if (IntPtr.Zero == pImageBuf || nImageBufSize < (stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight))
                            {
                                if (pImageBuf != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(pImageBuf);
                                    pImageBuf = IntPtr.Zero;
                                }

                                pImageBuf = Marshal.AllocHGlobal((int)stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight);
                                if (IntPtr.Zero == pImageBuf)
                                {
                                    break;
                                }
                                nImageBufSize = stFrameOut.stFrameInfo.nWidth * stFrameOut.stFrameInfo.nHeight;
                            }

                            MyCamera.MV_PIXEL_CONVERT_PARAM stPixelConvertParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();

                            stPixelConvertParam.pSrcData = stFrameOut.pBufAddr;//源数据
                            stPixelConvertParam.nWidth = stFrameOut.stFrameInfo.nWidth;//图像宽度
                            stPixelConvertParam.nHeight = stFrameOut.stFrameInfo.nHeight;//图像高度
                            stPixelConvertParam.enSrcPixelType = stFrameOut.stFrameInfo.enPixelType;//源数据的格式
                            stPixelConvertParam.nSrcDataLen = stFrameOut.stFrameInfo.nFrameLen;

                            stPixelConvertParam.nDstBufferSize = (uint)nImageBufSize;
                            stPixelConvertParam.pDstBuffer = pImageBuf;//转换后的数据
                            stPixelConvertParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8;
                            nRet = device.MV_CC_ConvertPixelType_NET(ref stPixelConvertParam);//格式转换
                            if (MyCamera.MV_OK != nRet)
                            {
                                break;
                            }
                            pTemp = pImageBuf;
                        }
                        fun.GetImageFromCam(CamColor.mono, pTemp, stFrameOut.stFrameInfo.nWidth, stFrameOut.stFrameInfo.nHeight, "rgb");
                    }
                    else
                    {
                        device.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                        continue;
                    }
                    device.MV_CC_FreeImageBuffer_NET(ref stFrameOut);
                }
                else
                {
                    continue;
                }
                Thread.Sleep(10);
            }

            if (pImageBuf != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pImageBuf);
                pImageBuf = IntPtr.Zero;
            }

        }

        static void ImageCallbackFunc(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO_EX pFrameInfo, IntPtr pUser)
        {
            // Function.GetImageFromCam(CamDeviceChannel.color, pData, pFrameInfo);

        }

        private static bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_RGBA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGRA8_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsMonoPixelFormat(MyCamera.MvGvspPixelType enType)
        {
            switch (enType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;
                default:
                    return false;
            }
        }

        private static void ShowErrorMsg(string csMessage, int nErrorNum)
        {
            string errorMsg;
            if (nErrorNum == 0)
            {
                errorMsg = csMessage;
            }
            else
            {
                errorMsg = csMessage + ": Error =" + String.Format("{0:X}", nErrorNum);
            }

            switch (nErrorNum)
            {
                case MyCamera.MV_E_HANDLE: errorMsg += " Error or invalid handle "; break;
                case MyCamera.MV_E_SUPPORT: errorMsg += " Not supported TMfunction "; break;
                case MyCamera.MV_E_BUFOVER: errorMsg += " Cache is full "; break;
                case MyCamera.MV_E_CALLORDER: errorMsg += " TMFunction calling order error "; break;
                case MyCamera.MV_E_PARAMETER: errorMsg += " Incorrect parameter "; break;
                case MyCamera.MV_E_RESOURCE: errorMsg += " Applying resource failed "; break;
                case MyCamera.MV_E_NODATA: errorMsg += " No data "; break;
                case MyCamera.MV_E_PRECONDITION: errorMsg += " Precondition error, or running environment changed "; break;
                case MyCamera.MV_E_VERSION: errorMsg += " Version mismatches "; break;
                case MyCamera.MV_E_NOENOUGH_BUF: errorMsg += " Insufficient memory "; break;
                case MyCamera.MV_E_UNKNOW: errorMsg += " Unknown error "; break;
                case MyCamera.MV_E_GC_GENERIC: errorMsg += " General error "; break;
                case MyCamera.MV_E_GC_ACCESS: errorMsg += " Node accessing condition error "; break;
                case MyCamera.MV_E_ACCESS_DENIED: errorMsg += " No permission "; break;
                case MyCamera.MV_E_BUSY: errorMsg += " Device is busy, or network disconnected "; break;
                case MyCamera.MV_E_NETER: errorMsg += " Network error "; break;
            }

            MessageBox.Show(errorMsg, "PROMPT");
        }
    }
}
