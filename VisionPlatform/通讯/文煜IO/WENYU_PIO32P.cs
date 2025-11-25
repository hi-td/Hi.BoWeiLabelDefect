using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;                   //**必须要的**
using StaticFun;
using System.Threading;
using VisionPlatform;
using Hi.Ltd;

namespace WENYU_IO
{
    public static class WENYU_PIO32P
    {
        /// <summary>
        /// 应用程序的主入口点。

        /****************************************************************************
                函数名称: WY_Open
                功能描述: 打开当前板卡，获取当前板卡句柄等DeviceID参数。打开获取DeviceID
                          参数值后，才能对板卡相关操作。在关闭系统前，必须用WY_Close函数关闭。
                          打开成功，所有输出端口16路为关闭状态，5路计数器清零0。
                参数列表:
                  CardNo：板卡编号，对应PCI槽0,1,2,3....
                DeviceID: 反回当前板卡DeviceID参数值;
                  返回值: 表示函数返状态  0:正确    1:板卡打开操作失败
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_Open", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_Open(int CardNo, ref WY_hDevice DeviceID);

        /****************************************************************************
                函数名称: WY_Close
                功能描述: 关闭注销当前板卡。关闭后，不能对板卡相关操作。它与WY_Open函数对应。
                参数列表:
                DeviceID: 关闭注销当前板卡ID;
                  返回值: 表示函数返状态  0:正确    1:板卡关闭操作失败  
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_Close", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_Close(WY_hDevice DeviceID);

        /****************************************************************************
                函数名称: WY_GetCardVersion
                功能描述: 获取本开关量控制卡版本号
                参数列表:
	            DeviceID: 操作当前板卡ID;
               VerNumber: 返回版本号，30代表版本3.0;
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败   2:本函数与板卡不相符
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetCardVersion", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetCardVersion(WY_hDevice DeviceID, ref long VerNumber);

        /*****************************************************************************
                函数名称: WY_GetLowInPutData
                功能描述: 获取开关量控制卡输入端口低8位数据
                参数列表:
	            DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                 LowData: 输入端口低8位数据，对应关系如下：
                                LowData数据: bit7,bit6,bit5,bit4,bit3,bit2,bit1,bit0
                               对应输入端口: Input7,Input6,Input5,Input4,Input3,Input2,Input1,Input0
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ******************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetLowInPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetLowInPutData(WY_hDevice DeviceID, ref long LowData);

        /******************************************************************************
                函数名称: WY_GetHighInPutData
                功能描述: 获取开关量控制卡输入端口高8位数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                HighData: 输入端口高8位数据，对应关系如下：
                               HighData数据:bit7,bit6,bit5,bit4,bit3,bit2,bit1,bit0
                               对应输入端口:Input15,Input14,Input13,Input12,Input11,Input10,Input9,Input8
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *******************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetHighInPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetHighInPutData(WY_hDevice DeviceID, ref long HighData);

        /*****************************************************************************
                函数名称: WY_GetLowOutPutData
                功能描述: 获取开关量控制卡输出端口低8位输出数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                 LowData: 输出端口低8位数据，对应关系如下：
                                LowData数据:bit7,bit6,bit5,bit4,bit3,bit2,bit1,bit0
                               对应输入端口:Output7,Onput6,Onput5,Onput4,Onput3,Onput2,Onput1,Onput0
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetLowOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetLowOutPutData(WY_hDevice DeviceID, ref long LowData);

        /*******************************************************************************
                函数名称: WY_GetHighOutPutData
                功能描述: 获取开关量控制卡输出端口高8位输出数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                HighData: 输出端口高8位数据，对应关系如下：
                               HighData数据:bit7,bit6,bit5,bit4,bit3,bit2,bit1,bit0
                               对应输入端口:Output15,Onput14,Onput13,Onput12,Onput11,Onput10,Onput9,Onput8
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ******************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetHighOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetHighOutPutData(WY_hDevice DeviceID, ref long HighData);

        /****************************************************************************
                函数名称: WY_GetOutPutData
                功能描述: 获取开关量控制卡输出端口输出数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
              OutPutData: 输出端口数据
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetOutPutData(WY_hDevice DeviceID, ref long OutPutData);

        /***************************************************************************
                函数名称: WY_GetInPutData
                功能描述: 获取开关量控制卡输入端数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
               InPutData: 输入端口数据，低位在前，高位在后。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetInPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetInPutData(WY_hDevice DeviceID, ref long InPutData);

        /***************************************************************************
                函数名称: WY_ReadInPutbit0
                功能描述: 获取开关量控制卡输入端口0状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit0(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit1
                功能描述: 获取开关量控制卡输入端口1状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit1(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit2
                功能描述: 获取开关量控制卡输入端口2状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit2(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit3
                功能描述: 获取开关量控制卡输入端口3状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit3(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit4
                功能描述: 获取开关量控制卡输入端口4状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit4(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit5
                功能描述: 获取开关量控制卡输入端口5状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit5(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit6
                功能描述: 获取开关量控制卡输入端口6状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit6(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit7
                功能描述: 获取开关量控制卡输入端口7状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit7(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit8
                功能描述: 获取开关量控制卡输入端口8状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit8(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit9
                功能描述: 获取开关量控制卡输入端口9状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit9(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit10
                功能描述: 获取开关量控制卡输入端口10状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit10(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit11
                功能描述: 获取开关量控制卡输入端口11状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit11(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit12
                功能描述: 获取开关量控制卡输入端口12状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit12", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit12(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit13
                功能描述: 获取开关量控制卡输入端口13状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit13", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit13(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadInPutbit14
                功能描述: 获取开关量控制卡输入端口14状态
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 输入端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit14", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit14(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
            函数名称: WY_ReadInPutbit15
            功能描述: 获取开关量控制卡输入端口15状态
            参数列表:
            DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                 bit: 输入端口电平值（0：表示低电平，1：表示高电平）
              返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadInPutbit15", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadInPutbit15(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_SetLowOutPutData
                功能描述: 设置开关量控制卡输出端口低8位数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                 LowData: 输出端口低8位数据，对应关系如下：
                                 LowData数据:bit7,bit6,bit5,bit4,bit3,bit2,bit1,bit0
                                对应输入端口:Output7,Onput6,Onput5,Onput4,Onput3,Onput2,Onput1,Onput0
                  返回值: 表示函数返状态   0:正确    1:板卡连接失败  3：输入参数错误,输入数值超出范围0x00~0xff
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_SetLowOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_SetLowOutPutData(WY_hDevice DeviceID, long LowData);

        /************************************************************************
                函数名称: WY_SetHighOutPutData
                功能描述: 设置开关量控制卡输出端口高8位数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                HighData: 输出端口高8位数据，对应关系如下：
                                HighData数据:bit 15,bit14,bit13,bit12,bit11,bit10,bit9,bit8,
                                对应输入端口:Output7,Onput6,Onput5,Onput4,Onput3,Onput2,Onput1,Onput0
                  返回值: 表示函数返状态   0:正确    1:板卡连接失败  
                                           3：输入参数错误,输入数值超出范围0x00~0xff
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_SetHighOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_SetHighOutPutData(WY_hDevice DeviceID, long HighData);

        /************************************************************************
                函数名称: WY_SetOutPutData
                功能描述: 设置开关量控制卡输出端口16位数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
              OutPutData: 输出端口数据。
                  返回值: 表示函数返状态   0:正确    1:板卡连接失败   
                                           3：输入参数错误,OutPutData输入数值超出范围0x0000~0xffff
        技术支持联系电话：13510401592
        **************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_SetOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_SetOutPutData(WY_hDevice DeviceID, long OutPutData);

        internal static void WY_WriteOutPutBit0(object deviceID0, int v)
        {
            throw new NotImplementedException();
        }

        /************************************************************************
                函数名称: WY_WriteOutPutBit0
                功能描述: 向开关量控制卡输出端口0写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit0(WY_hDevice DeviceID, int bit);

        /***********************************************************************
                函数名称: WY_WriteOutPutBit1
                功能描述: 向开关量控制卡输出端口1写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit1(WY_hDevice DeviceID, int bit);

        /**********************************************************************
             '* 函数名称: WY_WriteOutPutBit2
             '* 功能描述: 向开关量控制卡输出端口2写入数据
             '* 参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
               '* 返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        **********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit2(WY_hDevice DeviceID, int bit);

        /*********************************************************************
                函数名称: WY_WriteOutPutBit3
                功能描述: 向开关量控制卡输出端口3写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit3(WY_hDevice DeviceID, int bit);

        /*********************************************************************
                函数名称: WY_WriteOutPutBit4
                功能描述: 向开关量控制卡输出端口4写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        **********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit4(WY_hDevice DeviceID, int bit);

        /*********************************************************************
                函数名称: WY_WriteOutPutBit5
                功能描述: 向开关量控制卡输出端口5写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        *********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit5(WY_hDevice DeviceID, int bit);

        /********************************************************************
                函数名称: WY_WriteOutPutBit6
                功能描述: 向开关量控制卡输出端口6写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        *********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit6(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit7
                功能描述: 向开关量控制卡输出端口7写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit7(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit8
                功能描述: 向开关量控制卡输出端口8写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit8(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit9
                功能描述: 向开关量控制卡输出端口9写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit9(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit10
                功能描述: 向开关量控制卡输出端口10写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit10(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit11
                功能描述: 向开关量控制卡输出端口11写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit11(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit12
                功能描述: 向开关量控制卡输出端口12写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit12", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit12(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit13
                功能描述: 向开关量控制卡输出端口13写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit13", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit13(WY_hDevice DeviceID, int bit);

        /************************************************************************
                函数名称: WY_WriteOutPutBit14
                功能描述: 向开关量控制卡输出端口14写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit14", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit14(WY_hDevice DeviceID, int bit);

        /*************************************************************************
                函数名称: WY_WriteOutPutBit15
                功能描述: 向开关量控制卡输出端口15写入数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 表示端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
        技术支持联系电话：13510401592
        ***************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_WriteOutPutBit15", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_WriteOutPutBit15(WY_hDevice DeviceID, int value);

        /************************************************************************
                函数名称: WY_ReadOutPutBit0
                功能描述: 向开关量控制卡输出端口0回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit0(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit1
                功能描述: 向开关量控制卡输出端口1回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit1(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit2
                功能描述: 向开关量控制卡输出端口2回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit2(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit3
                功能描述: 向开关量控制卡输出端口3回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit3(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit4
                功能描述: 向开关量控制卡输出端口4回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit4(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit5
                功能描述: 向开关量控制卡输出端口5回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit5", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit5(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit6
                功能描述: 向开关量控制卡输出端口6回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit6", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit6(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit7
                功能描述: 向开关量控制卡输出端口7回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit7", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit7(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit8
                功能描述: 向开关量控制卡输出端口8回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit8", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit8(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit9
                功能描述: 向开关量控制卡输出端口9回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit9", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit9(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit10
                功能描述: 向开关量控制卡输出端口10回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit10", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit10(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit11
                功能描述: 向开关量控制卡输出端口11回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit11", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit11(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit12
                功能描述: 向开关量控制卡输出端口12回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit12", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit12(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit13
                功能描述: 向开关量控制卡输出端口13回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit13", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit13(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit14
                功能描述: 向开关量控制卡输出端口14回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit14", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit14(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ReadOutPutBit15
                功能描述: 向开关量控制卡输出端口15回读数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                     bit: 回读输出端口电平值（0：表示低电平，1：表示高电平）
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadOutPutBit15", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadOutPutBit15(WY_hDevice DeviceID, ref int bit);

        /************************************************************************
                函数名称: WY_ResetCounter0
                功能描述: 复位计数器0。复位后，计数器0中的计数寄存器清除复位为0。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        *************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ResetCounter0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ResetCounter0(WY_hDevice DeviceID);

        /************************************************************************
                函数名称: WY_ResetCounter1
                功能描述: 复位计数器1。复位后，计数器1中的计数寄存器清除复位为0。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败 
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ResetCounter1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ResetCounter1(WY_hDevice DeviceID);

        /************************************************************************
                函数名称: WY_ResetCounter2
                功能描述: 复位计数器2。复位后，计数器2中的计数寄存器清除复位为0。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ResetCounter2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ResetCounter2(WY_hDevice DeviceID);

        /************************************************************************
                函数名称: WY_ResetCounter3
                功能描述: 复位计数器3。复位后，计数器3中的计数寄存器清除复位为0。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ResetCounter3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ResetCounter3(WY_hDevice DeviceID);

        /**********************************************************************
                函数名称: WY_ResetCounter4
                功能描述: 复位计数器4。复位后，计数器4中的计数寄存器清除复位为0。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ResetCounter4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ResetCounter4(WY_hDevice DeviceID);

        /***********************************************************************
                函数名称: WY_ReadCounter0
                功能描述: 读取计数器0中的计数值。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 计数器0中的计数值。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadCounter0", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadCounter0(WY_hDevice DeviceID, ref int value);

        /***********************************************************************
                函数名称: WY_ReadCounter1
                功能描述: 读取计数器1中的计数值。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 计数器1中的计数值。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadCounter1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadCounter1(WY_hDevice DeviceID, ref int value);

        /**********************************************************************
                函数名称: WY_ReadCounter2
                功能描述: 读取计数器2中的计数值。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 计数器2中的计数值。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadCounter2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadCounter2(WY_hDevice DeviceID, ref int value);

        /**********************************************************************
                函数名称: WY_ReadCounter3
                功能描述: 读取计数器3中的计数值。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 计数器3中的计数值。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadCounter3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadCounter3(WY_hDevice DeviceID, ref int value);

        /**********************************************************************
                函数名称: WY_ReadCounter4
                功能描述: 读取计数器4中的计数值。
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
                   value: 计数器4中的计数值。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ***********************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_ReadCounter4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_ReadCounter4(WY_hDevice DeviceID, ref int value);
        public struct WY_hDevice { IntPtr hDevice; UInt32 Ar; };

        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}
    }

    public static class hzjd_modbusRTU
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

        public static byte IO_COM_Number = 0x00;//串口号
        public static IntPtr DevCOM;
        public static byte IO_Address = 0x01;
        public static byte IO_PARITYBit = 0;
        public static byte IO_BANDRate = 0;

        public const Byte NONE_PARITY = 0;        //none parity
        public const Byte ODD_PARITY = 1;           //Odd parity
        public const Byte EVEN_PARITY = 2;          //Even parity
        public const Byte MARK_PARITY = 3;         //Mark parity 
        public const Byte SPACE_PARITY = 4;         //Space parity

    }
    public static class WENYU
    {
        public static bool isOpen;
        public static WENYU_PIO32P.WY_hDevice DevID;      //定义板卡句柄参数
        private static readonly object readioLock = new object();
        private static readonly object sendioLock = new object();
        public static bool OpenIO()
        {
            //IO板卡通讯
            int Result = -2;
            try
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                    GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    long VersionNumber = 0;
                    Result = WENYU_PIO32P.WY_Open(0, ref DevID);
                    if (Result != 0)
                    {
                        if (GlobalData.Config._language == EnumData.Language.english)
                        {
                            MessageBox.Show("No IO board found!", "Tips", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("未搜索到IO板卡！", "提示", MessageBoxButtons.OK);
                        }
                        isOpen = false;
                        return false;
                    }
                    Result = WENYU_PIO32P.WY_GetCardVersion(DevID, ref VersionNumber);
                    if (Result != 0)
                    {
                        if (GlobalData.Config._language == EnumData.Language.english)
                        {
                            MessageBox.Show("IO board communication abnormality!", "Tips", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("IO板卡通讯异常！", "提示", MessageBoxButtons.OK);
                        }
                        isOpen = false;
                        return false;
                    }
                    isOpen = true;
                    return true;
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {

                    if (-1 == DataSerializer._COMConfig.WENYU232_ComPort)
                    {
                        isOpen = false;
                        MessageFun.ShowMessage("请先设置连接IO板卡的串口", strEnglish: "Please first set up the serial port for connecting the IO board");
                        return false;
                    }
                    Result = hzjd_modbusRTU.DJ_OpenCom(DataSerializer._COMConfig.WENYU232_ComPort, ref hzjd_modbusRTU.DevCOM);

                }
                if (Result != 0)
                {
                    MessageFun.ShowMessage("与IO板卡通讯失败！", strEnglish: "Communication failure with IO board!");
                    MessageFun.ShowMessage("与IO板卡通讯失败！", strEnglish: "Communication failure with IO board!");
                    isOpen = false;
                    return false;
                }
                StaticFun.MessageFun.ShowMessage("与IO板卡通讯成功！", strEnglish: "Communication with IO board successful!");
                isOpen = true;
                return true;
            }
            catch (Exception)
            {
                isOpen = false;
                MessageFun.ShowMessage("与IO板卡通讯失败！", strEnglish: "Communication failure with IO board!");
                return false;
            }
        }
        public static void CloseIO()
        {
            int Result;
            try
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                    GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    Result = WENYU_PIO32P.WY_Close(DevID);
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {
                    Result = hzjd_modbusRTU.DJ_CloseCom(hzjd_modbusRTU.DevCOM);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            isOpen = false;
        }

        //仅232串口转IO卡使用
        public static bool SearchIO()
        {
            //如果搜索成功，串口也会打开
            try
            {
                if (-1 != DataSerializer._COMConfig.WENYU232_ComPort)
                {
                    int Results = hzjd_modbusRTU.JD_Search_Serial_Parameter(DataSerializer._COMConfig.WENYU232_ComPort, ref hzjd_modbusRTU.DevCOM,
                           ref hzjd_modbusRTU.IO_Address, ref hzjd_modbusRTU.IO_PARITYBit, ref hzjd_modbusRTU.IO_BANDRate);
                    if (Results != 0)
                    {
                        MessageFun.ShowMessage("未搜索到IO信号控制器，请检查串口连接！", strEnglish: "No IO signal controller found, please check the serial port connection!");
                        isOpen = false;
                        return false;
                    }
                    MessageFun.ShowMessage("打开IO信号控制器成功！", strEnglish: "Successfully opened IO signal controller!");
                    isOpen = true;
                    return true;
                }
                else
                {
                    isOpen = false;
                    MessageFun.ShowMessage("请先设置IO信号控制器的串口号！", strEnglish: "Please set the serial port number of the IO signal controller first");
                    return false;
                }

            }
            catch (Exception ex)
            {
                isOpen = false;
                MessageFun.ShowMessage("IO信号控制器搜索异常：" + ex.ToString(), strEnglish: "IO signal controller search exception:" + ex.ToString());
                return false;
            }
        }

        public static int ReadIO(int io, ref int bit)
        {
            //  bit:输入端口电平值（0：表示低电平，1：表示高电平）
            int nResult = -1; //表示函数返状态  0:正确    1:板卡连接失败
            lock (readioLock)
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                        GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit0(DevID, ref bit);
                                break;
                            case 1:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit1(DevID, ref bit);
                                break;
                            case 2:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit2(DevID, ref bit);
                                break;
                            case 3:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit3(DevID, ref bit);
                                break;
                            case 4:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit4(DevID, ref bit);
                                break;
                            case 5:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit5(DevID, ref bit);
                                break;
                            case 6:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit6(DevID, ref bit);
                                break;
                            case 7:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit7(DevID, ref bit);
                                break;
                            case 8:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit8(DevID, ref bit);
                                break;
                            case 9:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit9(DevID, ref bit);
                                break;
                            case 10:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit10(DevID, ref bit);
                                break;
                            case 11:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit11(DevID, ref bit);
                                break;
                            case 12:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit12(DevID, ref bit);
                                break;
                            case 13:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit13(DevID, ref bit);
                                break;
                            case 14:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit14(DevID, ref bit);
                                break;
                            case 15:
                                nResult = WENYU_PIO32P.WY_ReadInPutbit15(DevID, ref bit);
                                break;
                            default:
                                break;
                        }
                        if (1 == nResult)
                        {
                            MessageFun.ShowMessage("板卡连接失败!");
                        }
                    }
                    catch
                    {
                        (DateTime.Now.ToString() + "：" + "ReadIO").Log();
                    }
                    return nResult;
                }

                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit0(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 1:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit1(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 2:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit2(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 3:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit3(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 4:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit4(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 5:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit5(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 6:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit6(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 7:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit7(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 8:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit8(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 9:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit9(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 10:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit10(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            case 11:
                                nResult = hzjd_modbusRTU.DJ_ReadInputBit11(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, ref bit);
                                bit = bit == 1 ? 0 : 1;
                                break;
                            default:
                                break;
                        }
                        if (0 != nResult)
                        {
                            MessageFun.ShowMessage("板卡连接失败!", strEnglish: "Board connection failed!");
                        }
                    }
                    catch
                    {
                        (DateTime.Now.ToString() + "：" + "ReadIO").Log();
                    }
                }
            }

            return nResult;
        }
        /// <summary>
        /// 发送IO信号 
        /// </summary>
        /// <param name="io"></param>要发送的点位
        /// <param name="bInvert"></param> 是否立即反转信号
        /// <param name="nSleep"></param> 有效电平发送持续时间
        /// <returns></returns>
        public static int SendIO(int io, bool bInvert, int nSleep = 20)
        {
            //bit: 表示端口电平值（0：表示低电平，1：表示高电平)
            //返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
            int nResult = -1;

            //板卡模式
            int Setlevel = 0;
            int Getlevel = 1;
            if (GlobalData.Config._InitConfig.initConfig.bIOLight)
            {
                Setlevel = 1;
                Getlevel = 0;
            }
            else
            {
                Setlevel = 0;
                Getlevel = 1;
            }

            lock (sendioLock)
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                        GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit0(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);                                          //发送有效电平的持续时间
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit0(DevID, Getlevel);      //置位为无效电平
                                }
                                break;
                            case 1:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit1(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit1(DevID, Getlevel);
                                }
                                break;
                            case 2:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit2(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit2(DevID, Getlevel);
                                }
                                break;
                            case 3:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit3(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit3(DevID, Getlevel);
                                }
                                break;
                            case 4:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit4(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit4(DevID, Getlevel);
                                }
                                break;
                            case 5:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit5(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit5(DevID, Getlevel);
                                }
                                break;
                            case 6:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit6(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit6(DevID, Getlevel);
                                }
                                break;
                            case 7:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit7(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit7(DevID, Getlevel);
                                }
                                break;
                            case 8:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit8(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit8(DevID, Getlevel);
                                }
                                break;
                            case 9:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit9(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit9(DevID, Getlevel);
                                }
                                break;
                            case 10:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit10(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit10(DevID, Getlevel);
                                }
                                break;
                            case 11:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit11(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit11(DevID, Getlevel);
                                }
                                break;
                            case 12:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit12(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit12(DevID, Getlevel);
                                }
                                break;
                            case 13:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit13(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit13(DevID, Getlevel);
                                }
                                break;
                            case 14:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit14(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit14(DevID, Getlevel);
                                }
                                break;
                            case 15:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit15(DevID, Setlevel);
                                if (bInvert)
                                {
                                    Thread.Sleep(nSleep);
                                    nResult = WENYU_PIO32P.WY_WriteOutPutBit15(DevID, Getlevel);
                                }
                                break;
                            default:
                                break;
                        }
                        if (0 != nResult)
                        {
                            MessageFun.ShowMessage("IO板卡连接失败!", strEnglish: "IO Board connection failed!");
                        }
                    }
                    catch (SystemException ex)
                    {
                        (DateTime.Now.ToString() + "：" + ex.ToString()).Log();

                    }
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {
                    byte OutPortNumber = 0;
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = hzjd_modbusRTU.JD_SetOutBit0(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 0;
                                break;
                            case 1:
                                nResult = hzjd_modbusRTU.JD_SetOutBit1(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 1;
                                break;
                            case 2:
                                nResult = hzjd_modbusRTU.JD_SetOutBit2(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 2;
                                break;
                            case 3:
                                nResult = hzjd_modbusRTU.JD_SetOutBit3(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 3;
                                break;
                            case 4:
                                nResult = hzjd_modbusRTU.JD_SetOutBit4(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 4;
                                break;
                            case 5:
                                nResult = hzjd_modbusRTU.JD_SetOutBit5(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 5;
                                break;
                            case 6:
                                nResult = hzjd_modbusRTU.JD_SetOutBit6(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 6;
                                break;
                            case 7:
                                nResult = hzjd_modbusRTU.JD_SetOutBit7(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 7;
                                break;
                            case 8:
                                nResult = hzjd_modbusRTU.JD_SetOutBit8(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 8;
                                break;
                            case 9:
                                nResult = hzjd_modbusRTU.JD_SetOutBit9(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 9;
                                break;
                            case 10:
                                nResult = hzjd_modbusRTU.JD_SetOutBit10(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 10;
                                break;
                            case 11:
                                nResult = hzjd_modbusRTU.JD_SetOutBit11(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 1);
                                OutPortNumber = 11;
                                break;
                            default:
                                break;
                        }
                        if (0 != nResult)
                        {
                            MessageFun.ShowMessage("IO板卡连接失败!", strEnglish: "IO board connection failed!");
                        }
                        else
                        {
                            if (bInvert)
                            {
                                ushort ReverseTime = (ushort)nSleep;
                                hzjd_modbusRTU.JD_SetOutPortFunction(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, OutPortNumber, 1, ReverseTime);
                                //Thread.Sleep(nSleep);
                                //nResult = JD_modbusRTU.Program.JD_SetOutBit3(JD_modbusRTU.Program.Device_COMl, JD_modbusRTU.Program.IO_Address, 0);
                            }
                        }
                    }
                    catch (SystemException ex)
                    {
                        ("IO board link error:" + ex.ToString()).Log();
                    }
                }
            }
            return nResult;
        }

        public static int SendIO_Close(int io)
        {
            //bit: 表示端口电平值（0：表示低电平，1：表示高电平)
            //返回值: 表示函数返状态  0:正确    1:板卡连接失败  3:输入参数错误
            int nResult = -1;

            //板卡模式
            int Setlevel = 1;
            if (GlobalData.Config._InitConfig.initConfig.bIOLight)
            {
                Setlevel = 0;
            }
            else
            {
                Setlevel = 1;
            }

            lock (sendioLock)
            {
                if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU8 ||
                        GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU16)
                {
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit0(DevID, Setlevel);      //置位为无效电平
                                break;
                            case 1:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit1(DevID, Setlevel);
                                break;
                            case 2:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit2(DevID, Setlevel);

                                break;
                            case 3:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit3(DevID, Setlevel);
                                break;
                            case 4:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit4(DevID, Setlevel);
                                break;
                            case 5:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit5(DevID, Setlevel);
                                break;
                            case 6:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit6(DevID, Setlevel);
                                break;
                            case 7:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit7(DevID, Setlevel);
                                break;
                            case 8:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit8(DevID, Setlevel);
                                break;
                            case 9:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit9(DevID, Setlevel);
                                break;
                            case 10:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit10(DevID, Setlevel);
                                break;
                            case 11:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit11(DevID, Setlevel);
                                break;
                            case 12:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit12(DevID, Setlevel);
                                break;
                            case 13:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit13(DevID, Setlevel);
                                break;
                            case 14:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit14(DevID, Setlevel);
                                break;
                            case 15:
                                nResult = WENYU_PIO32P.WY_WriteOutPutBit15(DevID, Setlevel);
                                break;
                            default:
                                break;
                        }
                        if (0 != nResult)
                        {
                            MessageFun.ShowMessage("IO板卡连接失败!", strEnglish: "IO board connection failed!");
                        }
                    }
                    catch (SystemException ex)
                    {
                        (DateTime.Now.ToString() + "：" + ex.ToString()).Log();

                    }
                }
                else if (GlobalData.Config._InitConfig.initConfig.comMode.IO == EnumData.IO.WENYU232)
                {
                    try
                    {
                        switch (io)
                        {
                            case 0:
                                nResult = hzjd_modbusRTU.JD_SetOutBit0(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 1:
                                nResult = hzjd_modbusRTU.JD_SetOutBit1(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 2:
                                nResult = hzjd_modbusRTU.JD_SetOutBit2(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 3:
                                nResult = hzjd_modbusRTU.JD_SetOutBit3(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 4:
                                nResult = hzjd_modbusRTU.JD_SetOutBit4(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 5:
                                nResult = hzjd_modbusRTU.JD_SetOutBit5(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 6:
                                nResult = hzjd_modbusRTU.JD_SetOutBit6(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 7:
                                nResult = hzjd_modbusRTU.JD_SetOutBit7(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 8:
                                nResult = hzjd_modbusRTU.JD_SetOutBit8(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 9:
                                nResult = hzjd_modbusRTU.JD_SetOutBit9(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 10:
                                nResult = hzjd_modbusRTU.JD_SetOutBit10(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            case 11:
                                nResult = hzjd_modbusRTU.JD_SetOutBit11(hzjd_modbusRTU.DevCOM, hzjd_modbusRTU.IO_Address, 0);
                                break;
                            default:
                                break;
                        }
                        if (0 != nResult)
                        {
                            MessageFun.ShowMessage("IO板卡连接失败!", true, "IO board connection failed!");
                        }
                        else
                        {
                        }
                    }
                    catch (SystemException ex)
                    {
                        ("IO board link error:" + ex.ToString()).Log();
                    }
                }
            }
            return nResult;
        }
    }


}
