/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：CameraOperator1
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：VisionPlatform.相机SDK.大华
* 文 件 名：CameraOperator1
* 创建时间：2022/7/26 11:43:40
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using EnumData;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using ThridLibray;

namespace VisionPlatform
{
    class CameraOperator1
    {
        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>();        // 图像缓存列表 | frame data list 
        Mutex m_mutex = new Mutex();           // 锁，保证多线程安全 | mutex 
        Function m_tmFun = null;                //<图片显示

        IDevice m_dev;
        public CameraOperator1(IDevice dev, Function fun)
        {
            m_dev = dev;
            m_tmFun = fun;
            zhucei();
        }

        ~CameraOperator1() { }
        private void zhucei()
        {
            /* 注册码流回调事件，每收到一帧图像后自动进入注册的回调函数里取图，不需要另开线程*/
            m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;
        }
        // 码流数据回调 
        // grab callback function
        int nRGB = 0;
        private void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            m_mutex.WaitOne();
            m_frameList.Add(e.GrabResult.Clone());
            IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
            m_frameList.Clear();
            if (frame.PixelFmt == GvspPixelFormatType.gvspPixelMono8)
            {
                nRGB = RGBFactory.EncodeLen(frame.Width, frame.Height, false);
                IntPtr pData = Marshal.AllocHGlobal(nRGB);
                Marshal.Copy(frame.Image, 0, pData, frame.ImageSize);
                m_tmFun.GetImageFromCam(CamColor.mono, pData, frame.Width, frame.Height, "bgr");
                Marshal.FreeHGlobal(pData);
            }
            else
            {
                nRGB = RGBFactory.EncodeLen(frame.Width, frame.Height, true);
                IntPtr pData = Marshal.AllocHGlobal(nRGB);
                RGBFactory.ToRGB(frame.Image, frame.Width, frame.Height, true, frame.PixelFmt, pData, nRGB);
                m_tmFun.GetImageFromCam(CamColor.color, pData, frame.Width, frame.Height, "bgr");
                Marshal.FreeHGlobal(pData);
            }
            //调用Marshal.AllocHGlobal必须调用 Marshal.FreeHGlobal(ptr);来手动释放内存，即使调用GC.Collect();方法也无法释放。
            m_mutex.ReleaseMutex();

        }

        // 停止码流 
        // stop grabbing 
        public  void Closecam()
        {
            try
            {
                m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调 | unregister grab event callback 
                //m_dev.ShutdownGrab();                                       // 停止码流 | stop grabbing
                //m_dev.Close();                                              // 关闭相机 | close camera 
            }
            catch (Exception exception)
            {
                MessageFun.ShowMessage(exception.ToString());
            }
        }
    }
}
