using BaseData;
using EnumData;
using Hi.Ltd;
using OpenVinoSharp.Extensions.result;
using StaticFun;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ThridLibray;

namespace VisionPlatform
{
    public class LEDControl_LAN
    {
        private static Dictionary<string, Socket> dicLanDevice = new Dictionary<string, Socket>();
        ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public bool OpenLedLan(ref BaseData.LEDLAN led)
        {
            try
            {
                //if (null == led.Mac)
                //{
                //    led.bOpen = false;
                //    return false;
                //}
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.SendTimeout = 500;
                clientSocket.ReceiveTimeout = 1000;

                //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
                //clientSocket.Connect(this.IP, this.Port);
                TimeoutObject.Reset();

                if (clientSocket.Connected)
                {
                    clientSocket.Close();
                }
                clientSocket.BeginConnect(led.IP, led.Port, new AsyncCallback(ConnectCallback), clientSocket);
                TimeoutObject.WaitOne(1000, false);//等待5秒
                if (null != dicLanDevice && dicLanDevice.ContainsKey(led.IP))
                {
                    dicLanDevice[led.IP] = clientSocket;
                }
                else
                {
                    dicLanDevice.Add(led.IP, clientSocket);
                }
                led.bOpen = true;
                MessageFun.ShowMessage($"光源控制器网口IP{led.IP}打开成功!", true, "The serial port of the light source controller has been successfully opened!");
                Thread.Sleep(2);
                //if (clientSocket.Connected)
                //{
                //    MessageFun.ShowMessage("连接成功");
                //    string SendData = "SA0" + "255" + "#";
                //    byte[] SendBytes = null;
                //    SendBytes = Encoding.Default.GetBytes(SendData);
                //    clientSocket.SendTimeout = 2000;
                //    clientSocket.Send(SendBytes);
                //    MessageFun.ShowMessage("发送成功");
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                //GlobalParams.logListener.Info(IP + ":" + Port + " Connect Failure " + ex.Message);
                //LogHelper.WriteLog(this.IP + "clientSocket Connect Error", e);
                return false;
            }
        }

        public static void CloseLED(ref BaseData.LEDLAN ledLAN)
        {
            ledLAN.bOpen = false;
            if (null != dicLanDevice && dicLanDevice.ContainsKey(ledLAN.IP))
            {
                dicLanDevice[ledLAN.IP].Close();
            }
        }

        public bool OpenAllLedLan(ref Dictionary<string, BaseData.LEDLAN> dicLed)
        {
            LEDLAN ledLAN = new LEDLAN();
            string IP = "";
            try
            {
                Dictionary<string, BaseData.LEDLAN> dictempLed = dicLed.Clone();
                dicLanDevice = new Dictionary<string, Socket>();
                foreach (var led in dictempLed)
                {
                    IP = led.Key;
                    ledLAN = led.Value;
                    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.SendTimeout = 500;
                    clientSocket.ReceiveTimeout = 1000;

                    //clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
                    //clientSocket.Connect(this.IP, this.Port);
                    TimeoutObject.Reset();
                    if (clientSocket.Connected)
                    {
                        clientSocket.Close();
                    }
                    clientSocket.BeginConnect(ledLAN.IP, ledLAN.Port, new AsyncCallback(ConnectCallback), clientSocket);
                    TimeoutObject.WaitOne(1000, false);//等待5秒

                    if (null != dicLanDevice && dicLanDevice.ContainsKey(ledLAN.IP))
                    {
                        dicLanDevice[ledLAN.IP] = clientSocket;
                    }
                    else
                    {
                        dicLanDevice.Add(ledLAN.IP, clientSocket);
                    }
                    BaseData.LEDLAN eDRTU = dicLed[led.Key];
                    ledLAN.bOpen = true;
                    dicLed[led.Key] = eDRTU;
                    MessageFun.ShowMessage($"光源控制器网口{led.Key}打开成功!", true, $"The lan {led.Key} of the light source controller has been successfully opened!");
                    Thread.Sleep(2);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"光源控制器串口打开失败，请检查光源控制器：{ex}", true, $"The lan of the light source controller open failed,please check it:{ex}");
                if ("" != IP)
                {
                    ledLAN.bOpen = false;
                    dicLed[IP] = ledLAN;
                }
                return false;
            }
        }

        public void CloseAllLED()
        {
            //if ((clientSocket != null) && (clientSocket.Connected))
            //    clientSocket.Disconnect(false);  //clientSocket.Disconnect(false); clientSocket.Close();

            //if (clientSocket != null)
            //{
            //    clientSocket.Close();
            //    clientSocket = null;
            //}
            try
            {
                foreach (var led in DataSerializer._COMConfig.dicLedLan)
                {
                    LEDLAN ledLAN = led.Value;
                    ledLAN.bOpen = false;
                    if (null != dicLanDevice && dicLanDevice.ContainsKey(led.Key))
                    {
                        dicLanDevice[led.Key].Close();
                    }
                    DataSerializer._COMConfig.dicLedLan[led.Key] = ledLAN;
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"CloseAllLED:{ex}", true);
            }
        }

        public bool Ping(string IP)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply pingReply = ping.Send(IP, 500);
                    if (pingReply.Status != IPStatus.Success)
                    {
                        MessageFun.ShowMessage($"主机与 {IP} Ping失败!");
                        return false;
                    }
                    else
                    {
                        MessageFun.ShowMessage($"主机与 {IP} Ping成功!");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage(ex.Message);
                return false;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                if (client != null)
                    client.EndConnect(ar);

            }
            catch (Exception e)
            {
                //OnErrorEvent(new ErrorEventArgs(e));
                //Console.WriteLine(e.Message);
                MessageBox.Show("光源控制器网口连接失败！请检查网线是否连接或网口IPv4配置与光源控制器IP配置是否在同一网段，并打开光源控制界面更新网口配置！" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TimeoutObject.Set();
            }
        }

        /// <summary>
        /// 设置光源某通道的亮度
        /// </summary>
        /// <param name="CH"></param>  通道，从1开始
        /// <param name="brightness"></param> 亮度
        public static bool SetBrightness(BaseData.LEDLAN led, int CH, int brightness)
        {
            string str_Bright = "";
            try
            {
                if (null == led.IP || led.bOpen == false)
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
                    byte[] SendBytes = null;
                    SendBytes = Encoding.Default.GetBytes(SendData);
                    dicLanDevice[led.IP].SendTimeout = 2000;
                    dicLanDevice[led.IP].Send(SendBytes);//发送数据
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

        public void SetLED(BaseData.LEDLAN led, CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl_LAN.SetBrightness(led, n + 1, cHBrights[n].bOpen ? cHBrights[n].nBrightness : 0);
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"设置光源亮度错误：{ex}", true, strEnglish: $"Error while setting LED brightness:{ex}");
            }
        }

        public void LEDAllOff(BaseData.LEDLAN led, CHBright[] cHBrights)
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                for (int n = 0; n < cHBrights.Count(); n++)
                {
                    LEDControl_LAN.SetBrightness(led, n + 1, 0);
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"光源亮度设置0错误：{ex}", true, $"LED brightness setting 0 error:{ex}");
            }
        }

        public static void AllLEDOff()
        {
            try
            {
                if (!GlobalData.Config._InitConfig.initConfig.bDigitLight)
                {
                    return;
                }
                foreach (var led in DataSerializer._COMConfig.dicLedLan)
                {
                    LEDLAN ledLAN = led.Value;
                    CHBright[] cHBrights = new CHBright[4];
                    foreach (var img in DataSerializer._globalData.dicImageing)
                    {
                        string strPort = img.Value.strPort;
                        if (strPort == led.Key)
                        {
                            for (int n = 0; n < cHBrights.Count(); n++)
                            {
                                LEDControl_LAN.SetBrightness(ledLAN, n + 1, 0);
                            }
                            //ledRTU.bOpen = false;
                        }
                    }
                }
                Thread.Sleep(60);
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"光源亮度设置0错误：{ex}", true, $"LED brightness setting 0 error:{ex}");
            }
        }

        #region 实际使用中没有用到收数据功能，这里只是预留代码
        public bool Receive(ref byte[] recBytes, BaseData.LEDLAN led)
        {
            int bytes = 0;

            int recpos = 0;

            int sumbytes = recBytes.Length;

            try
            {
                while (true)
                {
                    //预留接收数据功能
                    bytes = dicLanDevice[led.IP].Receive(recBytes, recpos, sumbytes, 0);

                    if (bytes == 0)
                        throw new Exception("Server Close");

                    recpos = recpos + bytes;

                    sumbytes = sumbytes - bytes;

                    //Thread.Sleep(10);

                    if (sumbytes == 0)
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                //超时报警：由于连接方在一段时间后没有正确答复或连接的主机没有反应，连接尝试失败。   
                //对方关闭连接：1、您的主机中的软件中止了一个已建立的连接。
                //对方关闭连接：2、不报异常，但是返回0，抛出异常

                //GlobalParams.logListener.Info(IP + ":" + Port + " " + clientSocket.LocalEndPoint.ToString() + " Receive Failure " + ex.Message);

                return false;
            }
        }

        public bool ReceiveLCM(ref byte[] recBytes, BaseData.LEDLAN led)
        {
            int bytes = 0;

            int recpos = 0;

            int sumbytes = recBytes.Length;

            try
            {
                dicLanDevice[led.IP].ReceiveTimeout = 2000;
                bytes = dicLanDevice[led.IP].Receive(recBytes, recpos, 12, 0);
                if (bytes == 0)
                    throw new Exception("Server Close");
                recpos = recpos + bytes;

                //获取剩余字节数
                UInt32 RecByteCount = BitConverter.ToUInt32(recBytes, 8);
                sumbytes = Convert.ToInt32(RecByteCount);

                //扩展recBytes数组大小
                //recBytes = (byte[])GlobalFunction.Redim(recBytes, Convert.ToInt32(12 + RecByteCount));

                while (true)
                {
                    bytes = dicLanDevice[led.IP].Receive(recBytes, recpos, sumbytes, 0);

                    if (bytes == 0)
                        throw new Exception("Server Close");

                    recpos = recpos + bytes;

                    sumbytes = sumbytes - bytes;

                    //Thread.Sleep(10);

                    if (sumbytes == 0)
                        break;
                }

                return true;
            }
            catch (Exception e)
            {
                //超时报警：由于连接方在一段时间后没有正确答复或连接的主机没有反应，连接尝试失败。   
                //对方关闭连接：1、您的主机中的软件中止了一个已建立的连接。
                //对方关闭连接：2、不报异常，但是返回0，抛出异常

                //GlobalParams.logListener.Info(IP + ":" + Port + " " + clientSocket.LocalEndPoint.ToString() + " Receive Failure " + ex.Message);
                //LogHelper.WriteLog("", e);
                return false;
            }
        }

        public bool ReceiveByCode(ref byte[] recBytes, BaseData.LEDLAN led)
        {
            int bytes = 0;

            int recpos = 0;

            int sumbytes = recBytes.Length;

            try
            {
                bytes = dicLanDevice[led.IP].Receive(recBytes, recpos, 4, 0);
                if (bytes == 0)
                    throw new Exception("Server Close");
                recpos = recpos + bytes;

                //获取剩余字节数
                int RecByteCount = BitConverter.ToUInt16(recBytes, 2) + 3;  //3== 校验+ 结尾
                sumbytes = Convert.ToInt32(RecByteCount);

                //扩展recBytes数组大小
                //recBytes = (byte[])GlobalFunction.Redim(recBytes, Convert.ToInt16(4 + RecByteCount));

                while (true)
                {
                    bytes = dicLanDevice[led.IP].Receive(recBytes, recpos, sumbytes, 0);

                    if (bytes == 0)
                        throw new Exception("Server Close");

                    recpos = recpos + bytes;

                    sumbytes = sumbytes - bytes;

                    //Thread.Sleep(10);

                    if (sumbytes == 0)
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                //超时报警：由于连接方在一段时间后没有正确答复或连接的主机没有反应，连接尝试失败。   
                //对方关闭连接：1、您的主机中的软件中止了一个已建立的连接。
                //对方关闭连接：2、不报异常，但是返回0，抛出异常

                //GlobalParams.logListener.Info(IP + ":" + Port + " " + clientSocket.LocalEndPoint.ToString() + " Receive Failure " + ex.Message);

                return false;
            }
        }
        #endregion
    }
}
