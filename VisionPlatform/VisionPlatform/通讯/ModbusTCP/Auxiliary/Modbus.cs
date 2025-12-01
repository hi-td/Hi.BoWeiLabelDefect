/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Modbus
* 机器名称：CHUSTANGE
* 命名空间：Hi.Ltd.XinLun
* 文 件 名：Modbus
* 创建时间：2024/4/22 13:43:42
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2024  保留所有权利.
***********************************************************/
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

using NModbus.Device;
using NModbus;

namespace VisionPlatform.Auxiliary
{
    public abstract class Modbus : IDisposable, IModbus
    {
        protected TcpClient client;
        protected ModbusIpMaster master;
        protected IModbusFactory factory;
        protected bool _disposed;
        /// <summary>
        /// 设备从站地址，即站号
        /// </summary>
        protected byte slaveAddress = 0x01;
        public Modbus()
        {
            client = null;
            factory = new ModbusFactory();
        }
        public abstract bool Connect(string ipAddress, int port = 502);

        public virtual bool[] ReadCoils(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadCoils(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads from 1 to 2000 contiguous coils status.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of coils to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public virtual Task<bool[]> ReadCoilsAsync(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadCoilsAsync(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Reads from 1 to 2000 contiguous discrete input status.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of discrete inputs to read.
        //
        // 返回结果:
        //     Discrete inputs status.
        public virtual bool[] ReadInputs(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputs(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads from 1 to 2000 contiguous discrete input status.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of discrete inputs to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public virtual Task<bool[]> ReadInputsAsync(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputsAsync(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Reads contiguous block of holding registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     Holding registers status.
        public virtual ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads contiguous block of holding registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public virtual Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadHoldingRegistersAsync(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Reads contiguous block of input registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     Input registers status.
        public virtual ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputRegisters(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads contiguous block of input registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public virtual Task<ushort[]> ReadInputRegistersAsync(ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputRegistersAsync(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Writes a single coil value.
        //
        // 参数:
        //   coilAddress:
        //     Address to write value to.
        //
        //   value:
        //     Value to write.
        public virtual void WriteSingleCoil(ushort coilAddress, bool value)
        {
            master.WriteSingleCoil(slaveAddress, coilAddress, value);
        }

        //
        // 摘要:
        //     Asynchronously writes a single coil value.
        //
        // 参数:
        //   coilAddress:
        //     Address to write value to.
        //
        //   value:
        //     Value to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public virtual Task WriteSingleCoilAsync(ushort coilAddress, bool value)
        {
            return master.WriteSingleCoilAsync(slaveAddress, coilAddress, value);
        }

        //
        // 摘要:
        //     Write a single holding register.
        //
        // 参数:
        //   registerAddress:
        //     Address to write.
        //
        //   value:
        //     Value to write.
        public virtual void WriteSingleRegister(ushort registerAddress, ushort value)
        {
            master.WriteSingleRegister(slaveAddress, registerAddress, value);
        }

        //
        // 摘要:
        //     Asynchronously writes a single holding register.
        //
        // 参数:
        //   registerAddress:
        //     Address to write.
        //
        //   value:
        //     Value to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public virtual Task WriteSingleRegisterAsync(ushort registerAddress, ushort value)
        {
            return master.WriteSingleRegisterAsync(slaveAddress, registerAddress, value);
        }

        //
        // 摘要:
        //     Write a block of 1 to 123 contiguous registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        public virtual void WriteMultipleRegisters(ushort startAddress, ushort[] data)
        {
            master.WriteMultipleRegisters(slaveAddress, startAddress, data);
        }

        //
        // 摘要:
        //     Asynchronously writes a block of 1 to 123 contiguous registers.
        //
        // 参数:
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public virtual Task WriteMultipleRegistersAsync(ushort startAddress, ushort[] data)
        {
            return master.WriteMultipleRegistersAsync(slaveAddress, startAddress, data);
        }

        //
        // 摘要:
        //     Force each coil in a sequence of coils to a provided value.
        //
        // 参数:
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        public virtual void WriteMultipleCoils(ushort startAddress, bool[] data)
        {
            master.WriteMultipleCoils(slaveAddress, startAddress, data);
        }

        //
        // 摘要:
        //     Asynchronously writes a sequence of coils.
        //
        // 参数:
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation
        public virtual Task WriteMultipleCoilsAsync(ushort startAddress, bool[] data)
        {
            return master.WriteMultipleCoilsAsync(slaveAddress, startAddress, data);
        }

        //
        // 摘要:
        //     Performs a combination of one read operation and one write operation in a single
        //     MODBUS transaction. The write operation is performed before the read. Message
        //     uses default TCP slave id of 0.
        //
        // 参数:
        //   startReadAddress:
        //     Address to begin reading (Holding registers are addressed starting at 0).
        //
        //   numberOfPointsToRead:
        //     Number of registers to read.
        //
        //   startWriteAddress:
        //     Address to begin writing (Holding registers are addressed starting at 0).
        //
        //   writeData:
        //     Register values to write.
        public virtual ushort[] ReadWriteMultipleRegisters(ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
        {
            return master.ReadWriteMultipleRegisters(slaveAddress, startReadAddress, numberOfPointsToRead, startWriteAddress, writeData);
        }

        //
        // 摘要:
        //     Asynchronously performs a combination of one read operation and one write operation
        //     in a single Modbus transaction. The write operation is performed before the read.
        //
        // 参数:
        //   startReadAddress:
        //     Address to begin reading (Holding registers are addressed starting at 0).
        //
        //   numberOfPointsToRead:
        //     Number of registers to read.
        //
        //   startWriteAddress:
        //     Address to begin writing (Holding registers are addressed starting at 0).
        //
        //   writeData:
        //     Register values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous operation.
        public virtual Task<ushort[]> ReadWriteMultipleRegistersAsync(ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
        {
            return master.ReadWriteMultipleRegistersAsync(slaveAddress, startReadAddress, numberOfPointsToRead, startWriteAddress, writeData);
        }


        //
        // 摘要:
        //     Reads from 1 to 2000 contiguous coils status.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of coils to read.
        //
        // 返回结果:
        //     Coils status.
        public bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadCoils(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads from 1 to 2000 contiguous coils status.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of coils to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadCoilsAsync(slaveAddress, startAddress, numberOfPoints);

        }
        //
        // 摘要:
        //     Reads from 1 to 2000 contiguous discrete input status.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of discrete inputs to read.
        //
        // 返回结果:
        //     Discrete inputs status.
        public bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputs(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Asynchronously reads from 1 to 2000 contiguous discrete input status.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of discrete inputs to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputsAsync(slaveAddress, startAddress, numberOfPoints);

        }

        //
        // 摘要:
        //     Reads contiguous block of holding registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     Holding registers status.
        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);

        }

        //
        // 摘要:
        //     Asynchronously reads contiguous block of holding registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadHoldingRegistersAsync(slaveAddress, startAddress, numberOfPoints);
        }

        //
        // 摘要:
        //     Reads contiguous block of input registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     Input registers status.
        public ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputRegisters(slaveAddress, startAddress, numberOfPoints);

        }

        //
        // 摘要:
        //     Asynchronously reads contiguous block of input registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startAddress:
        //     Address to begin reading.
        //
        //   numberOfPoints:
        //     Number of holding registers to read.
        //
        // 返回结果:
        //     A task that represents the asynchronous read operation.
        public Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadInputRegistersAsync(slaveAddress, startAddress, numberOfPoints);

        }

        //
        // 摘要:
        //     Writes a single coil value.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   coilAddress:
        //     Address to write value to.
        //
        //   value:
        //     Value to write.
        public void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value)
        {
            master.WriteSingleCoil(slaveAddress, coilAddress, value);
        }

        //
        // 摘要:
        //     Asynchronously writes a single coil value.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   coilAddress:
        //     Address to write value to.
        //
        //   value:
        //     Value to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value)
        {
            return master.WriteSingleCoilAsync(slaveAddress, coilAddress, value);
        }

        //
        // 摘要:
        //     Writes a single holding register.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   registerAddress:
        //     Address to write.
        //
        //   value:
        //     Value to write.
        public void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value)
        {
            master.WriteSingleRegister(slaveAddress, registerAddress, value);
        }

        //
        // 摘要:
        //     Asynchronously writes a single holding register.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   registerAddress:
        //     Address to write.
        //
        //   value:
        //     Value to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value)
        {
            return master.WriteSingleRegisterAsync(slaveAddress, registerAddress, value);

        }

        //
        // 摘要:
        //     Write a block of 1 to 123 contiguous 16 bit holding registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        public void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data)
        {
            master.WriteMultipleRegisters(slaveAddress, startAddress, data);

        }

        //
        // 摘要:
        //     Asynchronously writes a block of 1 to 123 contiguous registers.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data)
        {
            return master.WriteMultipleRegistersAsync(slaveAddress, startAddress, data);

        }

        //
        // 摘要:
        //     Writes a sequence of coils.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        public void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data)
        {
            master.WriteMultipleCoils(slaveAddress, startAddress, data);
        }

        //
        // 摘要:
        //     Asynchronously writes a sequence of coils.
        //
        // 参数:
        //   slaveAddress:
        //     Address of the device to write to.
        //
        //   startAddress:
        //     Address to begin writing values.
        //
        //   data:
        //     Values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous write operation.
        public Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data)
        {
            return master.WriteMultipleCoilsAsync(slaveAddress, startAddress, data);

        }

        //
        // 摘要:
        //     Performs a combination of one read operation and one write operation in a single
        //     Modbus transaction. The write operation is performed before the read.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startReadAddress:
        //     Address to begin reading (Holding registers are addressed starting at 0).
        //
        //   numberOfPointsToRead:
        //     Number of registers to read.
        //
        //   startWriteAddress:
        //     Address to begin writing (Holding registers are addressed starting at 0).
        //
        //   writeData:
        //     Register values to write.
        public ushort[] ReadWriteMultipleRegisters(byte slaveAddress, ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
        {
            return master.ReadWriteMultipleRegisters(slaveAddress, slaveAddress, numberOfPointsToRead, startWriteAddress, writeData);

        }

        //
        // 摘要:
        //     Asynchronously performs a combination of one read operation and one write operation
        //     in a single Modbus transaction. The write operation is performed before the read.
        //
        // 参数:
        //   slaveAddress:
        //     Address of device to read values from.
        //
        //   startReadAddress:
        //     Address to begin reading (Holding registers are addressed starting at 0).
        //
        //   numberOfPointsToRead:
        //     Number of registers to read.
        //
        //   startWriteAddress:
        //     Address to begin writing (Holding registers are addressed starting at 0).
        //
        //   writeData:
        //     Register values to write.
        //
        // 返回结果:
        //     A task that represents the asynchronous operation.
        public Task<ushort[]> ReadWriteMultipleRegistersAsync(byte slaveAddress, ushort startReadAddress, ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData)
        {
            return master.ReadWriteMultipleRegistersAsync(slaveAddress, startReadAddress, numberOfPointsToRead, startWriteAddress, writeData);
        }

        //
        // 摘要:
        //     Write a file record to the device.
        //
        // 参数:
        //   slaveAdress:
        //     Address of device to write values to
        //
        //   fileNumber:
        //     The Extended Memory file number
        //
        //   startingAddress:
        //     The starting register address within the file
        //
        //   data:
        //     The data to be written
        public void WriteFileRecord(byte slaveAdress, ushort fileNumber, ushort startingAddress, byte[] data)
        {
            master.WriteFileRecord(slaveAdress, fileNumber, startingAddress, data);
        }

        //
        // 摘要:
        //     Executes the custom message.
        //
        // 参数:
        //   request:
        //     The request.
        //
        // 类型参数:
        //   TResponse:
        //     The type of the response.
        public TResponse ExecuteCustomMessage<TResponse>(IModbusMessage request) where TResponse : IModbusMessage, new()
        {
            return master.ExecuteCustomMessage<TResponse>(request);

        }

        public abstract bool Disconnect();
        protected void Dispose(bool disposed)
        {
            if (!_disposed)
            {

                if (disposed)
                {
                    client?.Dispose();
                    client = null;

                    master?.Dispose();
                    master = null;
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
