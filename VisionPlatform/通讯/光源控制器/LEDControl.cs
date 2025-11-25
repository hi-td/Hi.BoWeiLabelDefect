using BaseData;
using EnumData;
using StaticFun;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionPlatform
{
    public class LEDControl
    {
        public static bool isOpen = false;      //监听光源控制器串口是否打开
        private static SerialPort ComDevice = new SerialPort();
        int[] nSetLed = new int[6];
        public static bool OpenLedCom(BaseData.LEDRTU led)
        {
            try
            {
                if (null == led.PortName)
                {
                    isOpen = false;
                    return false;
                }
                ComDevice.PortName = led.PortName;
                ComDevice.BaudRate = led.BaudRate;
                ComDevice.Parity = led.parity;
                ComDevice.DataBits = led.DataBits;
                ComDevice.StopBits = led.stopBits;
                if (ComDevice.IsOpen)
                {
                    ComDevice.Close();
                }
                ComDevice.Open();
                isOpen = true;
                MessageFun.ShowMessage("光源控制器串口打开成功!", true, "The serial port of the light source controller has been successfully opened!");
                Thread.Sleep(2);
                return true;
            }
            catch (Exception ex)
            {
                isOpen = false;
                MessageFun.ShowMessage("光源控制器串口打开失败：" + ex.ToString(), true, "The serial port of the light source controller failed to open:" + ex.ToString());
                return false;
            }
        }

        public static void CloseLED()
        {
            ComDevice.Close();
            isOpen = false;
        }

        /// <summary>
        /// 设置光源某通道的亮度
        /// </summary>
        /// <param name="CH"></param>  通道，从1开始
        /// <param name="brightness"></param> 亮度
        public static bool SetBrightness(int CH, int brightness)
        {
            string str_Bright = "";
            try
            {
                int length = brightness.ToString().Length;
                if (length == 1)
                {
                    str_Bright = "00" + brightness.ToString();
                }
                else if (length == 2)
                {
                    str_Bright = "0" + brightness.ToString();
                }
                else
                {
                    str_Bright = brightness.ToString();
                }
                string SendData = "";
                switch (CH)
                {
                    case 1:
                        SendData = "SA0";
                        break;
                    case 2:
                        SendData = "SB0";
                        break;
                    case 3:
                        SendData = "SC0";
                        break;
                    case 4:
                        SendData = "SD0";
                        break;
                    case 5:
                        SendData = "SE0";
                        break;
                    case 6:
                        SendData = "SF0";
                        break;
                    default:
                        break;
                }
                SendData = SendData + str_Bright + "#";
                if (isOpen)
                {
                    byte[] SendBytes = null;
                    SendBytes = Encoding.Default.GetBytes(SendData);
                   // MessageFun.ShowMessage($"发送数据:{SendData}");
                    ComDevice.Write(SendBytes, 0, SendBytes.Length);//发送数据
                }
                else
                {
                    if (GlobalData.Config._language == Language.english)
                    {
                        MessageBox.Show("The communication of the light source controller is abnormal, please check the serial port!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("光源控制器通讯异常，请检查串口！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("设置光源通道" + CH.ToString() + "亮度错误：" + ex.ToString(), true, "Set up light source channels" + CH.ToString() + "Brightness error:" + ex.ToString());
                return false;
            }
        }

        private static readonly object setCHLock = new object();

        public void SetLED(CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl.SetBrightness(n+1, cHBrights[n].bOpen ? cHBrights[n].nBrightness : 0);
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"设置光源亮度错误：{ex}", true, strEnglish: $"Error while setting LED brightness:{ex}");
            }

        }

        public void LEDAllOff(CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl.SetBrightness(n+1, 0);
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"光源亮度设置0错误：{ex}", true, $"LED brightness setting 0 error:{ex}");
            }

        }
    }
}
