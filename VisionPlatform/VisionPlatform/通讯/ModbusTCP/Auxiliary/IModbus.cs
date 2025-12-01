using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NModbus;

namespace VisionPlatform.Auxiliary
{
    public interface IModbus
    {
        bool Connect(string ipAddress, int port = 502);
        bool[] ReadCoils(ushort startAddress, ushort numberOfPoints);
        Task<bool[]> ReadCoilsAsync(ushort startAddress, ushort numberOfPoints);

        bool[] ReadInputs(ushort startAddress, ushort numberOfPoints);

        Task<bool[]> ReadInputsAsync(ushort startAddress, ushort numberOfPoints);

        ushort[] ReadHoldingRegisters(ushort startAddress, ushort numberOfPoints);

        Task<ushort[]> ReadHoldingRegistersAsync(ushort startAddress, ushort numberOfPoints);

        ushort[] ReadInputRegisters(ushort startAddress, ushort numberOfPoints);

        Task<ushort[]> ReadInputRegistersAsync(ushort startAddress, ushort numberOfPoints);

        void WriteSingleCoil(ushort coilAddress, bool value);

        Task WriteSingleCoilAsync(ushort coilAddress, bool value);

        void WriteSingleRegister(ushort registerAddress, ushort value);

        Task WriteSingleRegisterAsync(ushort registerAddress, ushort value);

        void WriteMultipleRegisters(ushort startAddress, ushort[] data);

        Task WriteMultipleRegistersAsync(ushort startAddress, ushort[] data);

        void WriteMultipleCoils(ushort startAddress, bool[] data);

        Task WriteMultipleCoilsAsync(ushort startAddress, bool[] data);

        ushort[] ReadWriteMultipleRegisters(ushort startReadAddress, ushort numberOfPointsToRead,
            ushort startWriteAddress, ushort[] writeData);

        Task<ushort[]> ReadWriteMultipleRegistersAsync(ushort startReadAddress, ushort numberOfPointsToRead,
            ushort startWriteAddress, ushort[] writeData);

        bool[] ReadCoils(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        Task<bool[]> ReadCoilsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        bool[] ReadInputs(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        Task<bool[]> ReadInputsAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        Task<ushort[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        ushort[] ReadInputRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        Task<ushort[]> ReadInputRegistersAsync(byte slaveAddress, ushort startAddress, ushort numberOfPoints);

        void WriteSingleCoil(byte slaveAddress, ushort coilAddress, bool value);

        Task WriteSingleCoilAsync(byte slaveAddress, ushort coilAddress, bool value);

        void WriteSingleRegister(byte slaveAddress, ushort registerAddress, ushort value);

        Task WriteSingleRegisterAsync(byte slaveAddress, ushort registerAddress, ushort value);

        void WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data);

        Task WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] data);

        void WriteMultipleCoils(byte slaveAddress, ushort startAddress, bool[] data);

        Task WriteMultipleCoilsAsync(byte slaveAddress, ushort startAddress, bool[] data);

        ushort[] ReadWriteMultipleRegisters(byte slaveAddress, ushort startReadAddress, ushort numberOfPointsToRead,
            ushort startWriteAddress, ushort[] writeData);

        Task<ushort[]> ReadWriteMultipleRegistersAsync(byte slaveAddress, ushort startReadAddress,
            ushort numberOfPointsToRead, ushort startWriteAddress, ushort[] writeData);

        void WriteFileRecord(byte slaveAdress, ushort fileNumber, ushort startingAddress, byte[] data);

        TResponse ExecuteCustomMessage<TResponse>(IModbusMessage request) where TResponse : IModbusMessage, new();

        bool Disconnect();
    }
}
