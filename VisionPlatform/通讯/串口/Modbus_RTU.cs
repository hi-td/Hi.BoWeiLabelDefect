using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Modbus.Device;
using VisionPlatform;
using System.Windows.Forms;

namespace DAL
{
    public class Modbus_RTU
    {
        private SerialPort MyCom = new SerialPort();
        private IModbusMaster master;
        public bool isOpen = false;

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns>打开成功：true 打开失败：false</returns>
        public bool OpenCom(InspectData.PLCRTU pLCRTU)
        {
            try
            {
                if (MyCom.IsOpen)
                {
                    MyCom.Close();
                    isOpen = MyCom.IsOpen;
                }
                if (pLCRTU.PortName != null && pLCRTU.BaudRate != 0 && pLCRTU.DataBits != 0)
                {
                    //串口号
                    MyCom.PortName = pLCRTU.PortName;
                    //波特率
                    MyCom.BaudRate = pLCRTU.BaudRate;
                    //数据位
                    MyCom.DataBits = pLCRTU.DataBits;
                    //校验位
                    MyCom.Parity = pLCRTU.parity;
                    //停止位
                    MyCom.StopBits = pLCRTU.stopBits;
                    master = ModbusSerialMaster.CreateRtu(MyCom);
                    MyCom.Open();
                    isOpen = MyCom.IsOpen;
                    return true;
                }
                else
                {
                    MessageBox.Show("当前软件通讯配置文件异常，请先进入PLC调试界面进行设置保存！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void ClosePort()
        {
            if (MyCom.IsOpen)
            {
                MyCom.Close();
                isOpen = MyCom.IsOpen;
            }
        }


        /// <summary>
        /// 读线圈
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">数据长度</param>
        public bool[] Read_Coils(string functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            bool[] coilsBuffer = null;
            try
            {
                //每次操作是要开启串口 操作完成后需要关闭串口
                //目的是为了slave更换连接是不报错
                if (MyCom.IsOpen == false)
                {
                    MyCom.Open();
                    isOpen = MyCom.IsOpen;
                }

                if (functionCode != null)
                {
                    switch (functionCode)
                    {
                        case "01"://读取单个线圈 Read Coils
                            coilsBuffer = master.ReadCoils(slaveAddress, startAddress, numberOfPoints);
                            break;
                        case "02"://读取输入线圈/离散量线圈 Read DisCrete Inputs
                            coilsBuffer = master.ReadInputs(slaveAddress, startAddress, numberOfPoints);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                }
                //MyCom.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return coilsBuffer;
        }

        /// <summary>
        /// 读寄存器
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">数据长度</param>
        public ushort[] Read_Register(string functionCode, byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            ushort[] registerBuffer = null;
            try
            {
                //每次操作是要开启串口 操作完成后需要关闭串口
                //目的是为了slave更换连接是不报错
                if (MyCom.IsOpen == false)
                {
                    MyCom.Open();
                    isOpen = MyCom.IsOpen;
                }
                if (functionCode != null)
                {
                    switch (functionCode)
                    {
                        case "03"://读取保持寄存器 Read Holding Registers
                            registerBuffer = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                            //registerBuffer = master.ReadHoldingRegistersAsync(slaveAddress, startAddress, numberOfPoints);
                            break;
                        case "04"://读取输入寄存器 Read Input Registers
                            registerBuffer = master.ReadInputRegisters(slaveAddress, startAddress, numberOfPoints);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                }
                //MyCom.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return registerBuffer;
        }

        /// <summary>
        /// 写线圈
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="slaveAddress">地址</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">数据</param>
        public async void Write_Coil(string functionCode, byte slaveAddress, ushort startAddress, bool[] coilsBuffer)
        {
            try
            {
                //每次操作是要开启串口 操作完成后需要关闭串口
                //目的是为了slave更换连接是不报错
                if (MyCom.IsOpen == false)
                {
                    MyCom.Open();
                    isOpen = MyCom.IsOpen;
                }
                if (functionCode != null)
                {
                    switch (functionCode)
                    {
                        case "05"://写单个线圈 Write Single Coil
                            await master.WriteSingleCoilAsync(slaveAddress, startAddress, coilsBuffer[0]);
                            break;
                        case "0F"://写一组线圈 Write Multiple Coils
                            await master.WriteMultipleCoilsAsync(slaveAddress, startAddress, coilsBuffer);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                }
                //MyCom.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// 写寄存器
        /// </summary>
        /// <param name="functionCode">功能码</param>
        /// <param name="slaveAddress">从站地址</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">数据</param>
        public async void Write_Register(string functionCode, byte slaveAddress, ushort startAddress, ushort[] registerBuffer)
        {
            try
            {
                //每次操作是要开启串口 操作完成后需要关闭串口
                //目的是为了slave更换连接是不报错
                if (MyCom.IsOpen == false)
                {
                    MyCom.Open();
                    isOpen = MyCom.IsOpen;
                }
                if (functionCode != null)
                {
                    switch (functionCode)
                    {
                        case "06"://写单个输入线圈/离散量线圈 Write Single Registers
                            await master.WriteSingleRegisterAsync(slaveAddress, startAddress, registerBuffer[0]);
                            break;
                        case "10"://写一组保持寄存器 Write Multiple Registers
                            await master.WriteMultipleRegistersAsync(slaveAddress, startAddress, registerBuffer);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                }
                //MyCom.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
