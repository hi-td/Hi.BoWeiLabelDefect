/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：GrabEvent
* 机器名称：WIN-C8KIOVQPABN
* 命名空间：VisionPlatform
* 文 件 名：GrabEvent
* 创建时间：2023/6/1 9:45:37
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司  2021  保留所有权利.
***********************************************************/
using Basler.Pylon;
using EnumData;
using StaticFun;
using System;
using System.Runtime.InteropServices;

namespace VisionPlatform.相机SDK.巴斯勒
{
    class GrabEvent
    {
        Function m_myFun = null;
        private  PixelDataConverter converter = new PixelDataConverter();
        public GrabEvent(Function fun)
        {
            m_myFun = fun;
        }
        public  void OnImageGrabbed(Object sender, ImageGrabbedEventArgs e)
        {
            //TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
            IGrabResult grabResult = e.GrabResult;
            if (grabResult.GrabSucceeded)
            {
                try
                {
                    if (grabResult.PixelTypeValue == PixelType.Mono8)
                    {
                        byte[] pixelData = (byte[])grabResult.PixelData;
                        IntPtr pixelPointer = Marshal.UnsafeAddrOfPinnedArrayElement(pixelData, 0);
                        //Marshal.Copy(pixelData, 0, pixelPointer, pixelData.Length);
                        m_myFun.GetImageFromCam(CamColor.mono, pixelPointer, grabResult.Width, grabResult.Height,"rgb");
                    }
                    else
                    {
                        byte[] buffer_rgb = new byte[grabResult.Width * grabResult.Height * 3];
                        converter.OutputPixelFormat = PixelType.RGB8packed;
                        converter.Convert(buffer_rgb, grabResult);
                        IntPtr p = Marshal.UnsafeAddrOfPinnedArrayElement(buffer_rgb, 0);
                        //Marshal.Copy(buffer_rgb, 0, p, buffer_rgb.Length);
                        m_myFun.GetImageFromCam(CamColor.color, p, grabResult.Width, grabResult.Height, "rgb");

                    }
                }
                finally
                {
                    //TimeSpan ts2_z = new TimeSpan(DateTime.Now.Ticks);
                    //double spanTotalSeconds2 = ts2_z.Subtract(ts).Duration().TotalMilliseconds;
                    //MessageFun.ShowMessage("拍照用时：" + spanTotalSeconds2.ToString(), "Image capture time：" + spanTotalSeconds2.ToString());
                }
            }
            else
            {
                MessageFun.ShowMessage("Error Code:"+ e.GrabResult.ErrorCode+"Error Description: "+ e.GrabResult.ErrorDescription);
            }
        }
    }
}
