using BaseData;
using EnumData;
using StaticFun;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VisionPlatform
{
    public class LEDControl
    {
        private static Dictionary<string, SerialPort> dicComDevice = new Dictionary<string, SerialPort>();
        public static bool OpenLedCom(ref BaseData.LEDRTU led)
        {
            try
            {
                if (null == led.PortName)
                {
                    led.bOpen = false;
                    return false;
                }
                SerialPort ComDevice = new SerialPort();
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
                if (null != dicComDevice && dicComDevice.ContainsKey(led.PortName))
                {
                    dicComDevice[led.PortName] = ComDevice;
                }
                else
                {
                    dicComDevice.Add(led.PortName, ComDevice);
                }
                led.bOpen = true;
                MessageFun.ShowMessage($"光源控制器串口{led.PortName}打开成功!", true, "The serial port of the light source controller has been successfully opened!");
                Thread.Sleep(2);
                return true;
            }
            catch (Exception ex)
            {
                led.bOpen = false;
                MessageFun.ShowMessage($"光源控制器串口{led.PortName}打开失败：" + ex.ToString(), true, "The serial port of the light source controller failed to open:" + ex.ToString());
                return false;
            }
        }
        public static void CloseLED(ref BaseData.LEDRTU ledRTU)
        {
            ledRTU.bOpen = false;
            if (null != dicComDevice && dicComDevice.ContainsKey(ledRTU.PortName))
            {
                dicComDevice[ledRTU.PortName].Close();
            }
        }
        public static bool OpenAllLedCom(ref Dictionary<string, BaseData.LEDRTU> dicLed)
        {
            LEDRTU ledRTU = new LEDRTU();
            string strPortName = "";
            try
            {
                dicComDevice = new Dictionary<string, SerialPort>();
                foreach (var led in dicLed)
                {
                    strPortName = led.Key;
                    ledRTU = led.Value;
                    ledRTU.bOpen = false;
                    SerialPort comDevice = new SerialPort();
                    comDevice.PortName = led.Key;
                    comDevice.BaudRate = ledRTU.BaudRate;
                    comDevice.Parity = ledRTU.parity;
                    comDevice.DataBits = ledRTU.DataBits;
                    comDevice.StopBits = ledRTU.stopBits;
                    if (comDevice.IsOpen)
                    {
                        comDevice.Close();
                    }
                    comDevice.Open();
                    if (null != dicComDevice && dicComDevice.ContainsKey(strPortName))
                    {
                        dicComDevice[strPortName] = comDevice;
                    }
                    else
                    {
                        dicComDevice.Add(strPortName, comDevice);
                    }
                    ledRTU.bOpen = true;
                    dicLed[led.Key] = ledRTU;
                    MessageFun.ShowMessage($"光源控制器{led.Key}打开成功!", true, $"The serial port {led.Key}of the light source controller has been successfully opened!");
                    Thread.Sleep(2);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"光源控制器串口打开失败，请检查光源控制器：{ex}", true, $"The serial port of the light source controller open failed,please check it:{ex}");
                if ("" != strPortName)
                {
                    ledRTU.bOpen = false;
                    dicLed[strPortName] = ledRTU;
                }
                return false;
            }

        }
        public static void CloseAllLED()
        {
            try
            {
                foreach (var led in DataSerializer._COMConfig.dicLed)
                {
                    LEDRTU ledRTU = led.Value;
                    ledRTU.bOpen = false;
                    if (null != dicComDevice && dicComDevice.ContainsKey(led.Key))
                    {
                        dicComDevice[led.Key].Close();
                    }
                    DataSerializer._COMConfig.dicLed[led.Key] = ledRTU;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"CloseAllLED:{ex}", true);
            }
        }

        /// <summary>
        /// 设置光源某通道的亮度
        /// </summary>
        /// <param name="CH"></param>  通道，从1开始
        /// <param name="brightness"></param> 亮度
        public static bool SetBrightness(BaseData.LEDRTU led, int CH, int brightness)
        {
            string str_Bright = "";
            try
            {
                if (null == led.PortName || led.bOpen == false)
                {
                    return false;
                }
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
                if (led.bOpen)
                {
                    comDevice.Open();
                    byte[] SendBytes = null;
                    SendBytes = Encoding.Default.GetBytes(SendData);
                    dicComDevice[led.PortName].Write(SendBytes, 0, SendBytes.Length);//发送数据
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

        public void SetLED(BaseData.LEDRTU led, CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl.SetBrightness(led, n + 1, cHBrights[n].bOpen ? cHBrights[n].nBrightness : 0);
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"设置光源亮度错误：{ex}", true, strEnglish: $"Error while setting LED brightness:{ex}");
            }

        }

        public void LEDAllOff(BaseData.LEDRTU led, CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl.SetBrightness(led, n + 1, 0);
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
