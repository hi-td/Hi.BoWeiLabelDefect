using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;                   //**必须要的**
using static VisionPlatform.TMData_Serializer;
using VisionPlatform;
using HalconDotNet;
using EnumData;
using Chustange.Functional;
using StaticFun;
using System.Threading;
using WENYU_PIO32Ptest;

namespace JD_modbusRTU
{
    public static class Program
    {
        /****************************************************************************
                函数名称: DJ_OpenCom
                功能描述: 打开与IO控制器通讯的RS232的通讯串口，获取串口句柄。
                参数列表:
                 ComPort：与串口通讯的COM口编号0,1,2,3......20，对应串口名称"COM1"，"COM2"，"COM3"，"COM3"......，"COM21"。
                DeviceID: 反回当串口DeviceID句柄;
                  返回值: 表示函数返回状态  0:正确    1:串口打开失败
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_OpenCom", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]//, CharSet = CharSet.Unicode)
        public static extern int DJ_OpenCom(int ComPort, ref IntPtr DeviceID);
        /****************************************************************************
                函数名称: DJ_CloseCom
                功能描述: 关闭注销当前串口。关闭后，不能对当前串口相关操作。它与DJ_OpenCom函数对应。
                参数列表:
                DeviceID: 关闭注销当前串口;
                  返回值: 表示函数返回状态  0:正确    1:串口关闭操作失败  
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_CloseCom", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_CloseCom(IntPtr DeviceID);
        /****************************************************************************
                函数名称: DJ_InitCom
                功能描述: 初始当前串口的。
                参数列表:
                DeviceID: 关闭注销当前串口;
                  返回值: 表示函数返回状态  0:正确    1:串口关闭操作失败  
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_InitCom", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_InitCom(IntPtr DeviceID, byte Parity, byte BaudRate);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit(IntPtr DeviceID, byte IO_Address, int bit, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit0(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit1(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit2(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit3(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit4(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit5(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit6(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit7(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit8(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit9(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit10(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutBit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutBit11(IntPtr DeviceID, byte IO_Address, int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputPortData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputPortData(IntPtr DeviceID, byte IO_Address, ref UInt16 value);


        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit(IntPtr DeviceID, byte IO_Address, int bit, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit0(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit1(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit2(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit3(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit4(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit5(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit6(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit7(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit8(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit9(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit10(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_ReadInputBit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_ReadInputBit11(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "DJ_SetOutputPortData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int DJ_SetOutputPortData(IntPtr DeviceID, byte IO_Address, UInt16 value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputData(IntPtr DeviceID, byte IO_Address, ref UInt16 value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit(IntPtr DeviceID, byte IO_Address, int bit, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit0(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit1(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit2(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit3(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit4(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit5(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit6(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit7(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit8(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit9(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit10(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadOutputBit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadOutputBit11(IntPtr DeviceID, byte IO_Address, ref int value);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_ReadIOControllerParam", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_ReadIOControllerParam(IntPtr DeviceID, ref byte IO_Address, ref byte PARITYBit, ref byte BAND_Rate);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_Search_Serial_Parameter", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_Search_Serial_Parameter(int ComPort, ref IntPtr DeviceID, ref byte IO_Address, ref byte PARITYBit, ref byte BAND_Rate);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetIOControllerParam", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetIOControllerParam(IntPtr DeviceID, byte IO_Address, byte PARITYBit, byte BAND_Rate);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_SetOutPortFunction", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_SetOutPortFunction(IntPtr DeviceID, byte IO_Address, byte OutPortNumber, byte function, UInt16 ReverseTime);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "JD_GetOutPortFunction", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int JD_GetOutPortFunction(IntPtr DeviceID, byte IO_Address, byte OutPortNumber, ref byte function, ref UInt16 ReverseTime);

        [DllImport("hzjd_modbusRTU.dll", EntryPoint = "ModbusRTU_CRC16", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ModbusRTU_CRC16(byte[] modbusdata, int length, ref byte Low_Data, ref byte high_Data);

        public static IntPtr Device_COMl;
        public static byte IO_COM_Number = 0x00;//串口号
        public static byte IO_Address = 0x01;
        public static byte IO_PARITYBit = 0;
        public static byte IO_BANDRate = 0;

        public const Byte NONE_PARITY = 0;        //none parity
        public const Byte ODD_PARITY = 1;           //Odd parity
        public const Byte EVEN_PARITY = 2;          //Even parity
        public const Byte MARK_PARITY = 3;         //Mark parity 
        public const Byte SPACE_PARITY = 4;         //Space parity

    }

    //class WENYU_232IO
    //{
    //    public static bool isOpen;
    //    public static bool SearchIO()
    //    {
    //        //如果搜索成功，串口也会打开
    //        try
    //        {
    //            if (-1 != TMData_Serializer._COMConfig.WENYU232_ComPort)
    //            {
    //                int Results = JD_modbusRTU.Program.JD_Search_Serial_Parameter(TMData_Serializer._COMConfig.WENYU232_ComPort, ref JD_modbusRTU.Program.Device_COMl,
    //                       ref JD_modbusRTU.Program.IO_Address, ref JD_modbusRTU.Program.IO_PARITYBit, ref JD_modbusRTU.Program.IO_BANDRate);
    //                if (Results != 0)
    //                {
    //                    MessageBox.Show("未搜索到IO信号控制器，请检查串口连接！");
    //                    isOpen = false;
    //                    return false;
    //                }
    //                StaticFun.MessageFun.ShowMessage("打开IO信号控制器成功！");
    //                isOpen = true;
    //                return true;
    //            }
    //            else
    //            {
    //                isOpen = false;
    //                MessageBox.Show("请先设置IO信号控制器的串口号");
    //                return false;
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            isOpen = false;
    //            MessageBox.Show("IO信号控制器搜索异常：" + ex.ToString());
    //            return false;
    //        }
    //    }

    //    public static bool OpenIO()
    //    {
    //        try
    //        {
    //            if (-1 != TMData_Serializer._COMConfig.WENYU232_ComPort)
    //            {
    //                int Result = Program.DJ_OpenCom(TMData_Serializer._COMConfig.WENYU232_ComPort, ref Program.Device_COMl);
    //                if (Result != 0)
    //                {
    //                    MessageBox.Show("打开IO控制器失败！");
    //                    StaticFun.MessageFun.ShowMessage("打开IO控制器失败！");
    //                    isOpen = false;
    //                    return false;
    //                }
    //                StaticFun.MessageFun.ShowMessage("打开IO控制器成功！");
    //                isOpen = true;
    //                return true;
    //            }
    //            else
    //            {
    //                isOpen = false;
    //                MessageBox.Show("请先设置IO串口");
    //                return false;
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            isOpen = false;
    //            MessageBox.Show("打开IO控制器失败！");
    //            return false;
    //        }
    //    }

    //    public static void CloseIO()
    //    {
    //        try
    //        {
    //            int Result = Program.DJ_CloseCom(Program.Device_COMl);
    //        }
    //        catch (Exception)
    //        {

    //        }
    //    }

    //    private static readonly object readioLock = new object();
    //    private static readonly object sendioLock = new object();
    //    public static int ReadIO(int io, ref int bit)
    //    {
    //        //  bit:输入端口电平值（0：表示低电平，1：表示高电平）
    //        int nResult = -1; //表示函数返状态  0:正确    1:板卡连接失败
    //        lock (readioLock)
    //            {
    //                try
    //                {
    //                    switch (io)
    //                    {
    //                        case 0:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit0(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 1:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit1(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 2:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit2(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 3:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit3(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 4:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit4(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 5:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit5(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 6:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit6(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 7:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit7(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 8:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit8(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 9:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit9(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 10:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit10(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        case 11:
    //                            nResult = JD_modbusRTU.Program.DJ_ReadInputBit11(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, ref bit);
    //                            break;
    //                        default:
    //                            break;
    //                    }
    //                    if (0 != nResult)
    //                    {
    //                        MessageFun.ShowMessage("板卡连接失败!");
    //                    }
    //                }
    //                catch
    //                {
    //                    (DateTime.Now.ToString() + "：" + "ReadIO").ToLog();
    //                }
    //            }
    //        return nResult;
    //    }
    //    /// <summary>
    //    /// 发送IO信号 
    //    /// </summary>
    //    /// <param name="io"></param>要发送的点位
    //    /// <param name="bInvert"></param> 是否立即反转信号
    //    /// <param name="nSleep"></param> 有效电平发送持续时间
    //    /// <returns></returns>
    //    public static int SendIO(int io, bool bInvert, int nSleep = 20)
    //    {
    //        //bit: 表示端口电平值（0：表示低电平，1：表示高电平)
    //        //返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
    //        int nResult = -1;
    //        byte OutPortNumber = 0;

    //        lock (sendioLock)
    //        {
    //            try
    //            {
    //                switch (io)
    //                {
    //                    case 0:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit0(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 0;
    //                        break;
    //                    case 1:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit1(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 1;
    //                        break;
    //                    case 2:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit2(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 2;
    //                        break;
    //                    case 3:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit3(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 3;
    //                        break;
    //                    case 4:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit4(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 4;
    //                        break;
    //                    case 5:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit5(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 5;
    //                        break;
    //                    case 6:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit6(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 6;
    //                        break;
    //                    case 7:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit7(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 7;
    //                        break;
    //                    case 8:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit8(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 8;
    //                        break;
    //                    case 9:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit9(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 9;
    //                        break;
    //                    case 10:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit10(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 10;
    //                        break;
    //                    case 11:
    //                        nResult = JD_modbusRTU.Program.JD_SetOutBit11(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 1);
    //                        OutPortNumber = 11;
    //                        break;
    //                    default:
    //                        break;
    //                }
    //                if (0 != nResult)
    //                {
    //                    MessageFun.ShowMessage("板卡连接失败!");
    //                }
    //                else
    //                {
    //                    if (bInvert)
    //                    {
    //                        ushort ReverseTime = (ushort)nSleep;
    //                        JD_modbusRTU.Program.JD_SetOutPortFunction(
    //                        JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, OutPortNumber, 1, ReverseTime);
    //                        //Thread.Sleep(nSleep);
    //                        //nResult = JD_modbusRTU.Program.JD_SetOutBit3(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 0);
    //                    }
    //                }
    //            }
    //            catch (SystemException ex)
    //            {
    //                ("IO板卡链接错误：" + ex.ToString()).ToLog();
    //            }
    //        }
    //        return nResult;
    //    }
    //}

}
