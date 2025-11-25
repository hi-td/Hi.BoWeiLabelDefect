/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：ModbusSerial
* 机器名称：CHUSTANGE
* 命名空间：Hi.Ltd.XinLun
* 文 件 名：ModbusSerial
* 创建时间：2024/4/22 13:49:10
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2024  保留所有权利.
***********************************************************/
using Hi.Ltd;
using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using Hi.Ltd.Windows.Interfaces;
using NModbus.Device;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Threading;
namespace VisionPlatform.Auxiliary;

public sealed class ModbusTcp : Modbus, IModbusTcp
{
    private const int ReadBitCount = 120;

    private const int ReadRegisterCount = 120;
    public ModbusTcp() : base()
    {

    }
    public bool Connected { get; set; }

    public byte SlaveAddress { get => slaveAddress; set => slaveAddress = value; }

    private string ipAddress;
    public string IpAddress { get => ipAddress; set => ipAddress = value; }

    private int port;

    public int Port { get => port; set => port = value; }

    public int ReadTimeout { get => master.Transport.ReadTimeout; set => master.Transport.ReadTimeout = value; }

    public int WriteTimeout { get => master.Transport.WriteTimeout; set => master.Transport.WriteTimeout = value; }
    /// <summary>
    /// 重试次数
    /// </summary>
    public int Retry { get; set; }
    /// <summary>
    /// 操作结果
    /// </summary>
    public int Result { get; set; }
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public Parity Parity { get; set; }
    public StopBits StopBits { get; set; }
    int IModbusTcp.Result { get; set; }

    bool IPlc.Connected => Connected;

    int IPlc.Retry { get => Retry; set => Retry = value; }
    byte IPlc.SlaveAddress { get => SlaveAddress; set => SlaveAddress = value; }
    string IPlc.IpAddress { get => IpAddress; set => IpAddress = value; }
    int IPlc.ConnectedTimeout { get; set; }
    int IPlc.ReadTimeout { get => ReadTimeout; set => ReadTimeout = value; }
    int IPlc.WriteTimeout { get => WriteTimeout; set => WriteTimeout = value; }
    int IPlc.Port { get => Port; set => Port = value; }
    string IPlc.PortName { get => IpAddress; set => IpAddress = value; }
    int IPlc.BaudRate { get => BaudRate; set => BaudRate = value; }
    int IPlc.DataBits { get => DataBits; set => DataBits = value; }
    Parity IPlc.Parity { get => Parity; set => Parity = value; }
    StopBits IPlc.StopBits { get => StopBits; set => StopBits = value; }

    public override bool Connect(string ipAddress, int port = 502)
    {
        try
        {
            client = new System.Net.Sockets.TcpClient();
            this.ipAddress = ipAddress;
            this.port = port;
            client.Connect(IPAddress.Parse(ipAddress), port);
            master = (ModbusIpMaster)factory.CreateMaster(client);
            ReadTimeout = 1000;
            WriteTimeout = 1000;
            Connected = true;
            return true;
        }
        catch (Exception ex)
        {
            ex.Log();
            Connected = false;
            return false;
        }
    }

    public override bool Disconnect()
    {
        if (client != null)
        {
            client.Close();
            client = null;
            master = null;
            Connected = false;
            return true;
        }
        return false;
    }

    private readonly object readDeviceBlockLock = new();

    private readonly object writeDeviceBlockLock = new();

    private readonly object readDeviceRandomLock = new();

    private readonly object WriteDeviceRandomLock = new();

    public int ReadDeviceBlock(ushort startAddress, DataType type, ushort numberOfPoints, out ushort[] lplData)
    {
        int iReturnCode = -1;
        lplData = [];

        var tempList = new List<ushort>();
        if (master != null && type >= DataType.UInt16)
        {
            lock (readDeviceBlockLock)
            {
                ushort index = startAddress;
                ushort count = 0;
                var maxlenth = numberOfPoints;
                while (maxlenth > 0)
                {
                    if (maxlenth > ReadRegisterCount)
                    {
                        index += count;
                        count = ReadRegisterCount;
                        maxlenth -= count;
                    }
                    else
                    {
                        index += count;
                        count = maxlenth;
                        maxlenth = 0;
                    }
                    var result = ReadHoldingRegisters(index, count);
                    tempList = tempList.Concat(result.ToList()).ToList();
                    Thread.Sleep(1);
                }
                if (tempList.Count == numberOfPoints)
                {
                    lplData = tempList.ToArray();
                    iReturnCode = 0;
                }
            }
        }
        else
        {
            iReturnCode = 2;
        }
        return iReturnCode;
    }

    private int ReadDeviceBlock(Address address, out bool[] lplData)
    {
        int iReturnCode = -1;
        lplData = [];
        var tempList = new List<bool>();
        if (master != null && address.DataType == DataType.Bit)
        {
            lock (readDeviceBlockLock)
            {
                ushort index = (ushort)address.Index;
                ushort count = 0;
                var maxlenth = address.Length;
                while (maxlenth > 0)
                {
                    if (maxlenth > ReadRegisterCount)
                    {
                        index += count;
                        count = ReadRegisterCount;
                        maxlenth -= count;
                    }
                    else
                    {
                        index += count;
                        count = maxlenth;
                        maxlenth = 0;
                    }

                    if (address.SoftType == SoftType.X)
                    {
                        var result = ReadInputs(index, count);

                        tempList = tempList.Concat(result).ToList();
                    }
                    else if (address.SoftType == SoftType.Y || address.SoftType == SoftType.M)
                    {
                        var result = ReadCoils(index, count);
                        tempList = tempList.Concat(result).ToList();
                    }
                    Thread.Sleep(1);
                }
                if (tempList.Count == address.Length)
                {
                    lplData = tempList.ToArray();
                    iReturnCode = 0;
                }
            }
        }
        else
        {
            iReturnCode = 2;
        }
        return iReturnCode;

    }

    private int ReadDeviceBlock(Address address, out ushort[] lplData)
    {
        int iReturnCode = -1;
        lplData = [];
        var tempList = new List<ushort>();
        if (master != null)
        {
            lock (readDeviceBlockLock)
            {
                ushort index = (ushort)address.Index;
                ushort count = 0;
                var maxlenth = address.Length;
                while (maxlenth > 0)
                {
                    if (maxlenth > ReadRegisterCount)
                    {
                        index += count;
                        count = ReadRegisterCount;
                        maxlenth -= count;
                    }
                    else
                    {
                        index += count;
                        count = maxlenth;
                        maxlenth = 0;
                    }
                    var sw = new Stopwatch();
                    sw.Start();
                    var result = ReadHoldingRegisters(index, count);
                    sw.Stop();
                    var swe = sw.ElapsedMilliseconds;
                    tempList = tempList.Concat(result).ToList();
                    Thread.Sleep(1);
                }
                if (tempList.Count == address.Length)
                {
                    lplData = tempList.ToArray();
                    iReturnCode = 0;
                }
            }
        }
        else
        {
            iReturnCode = 2;
        }
        return iReturnCode;
    }

    private int ReadDeviceRandom(ref List<Address> addresses)
    {
        int iReturnCode = -1;

        if (master != null && client != null && client.Connected)
        {
            lock (readDeviceBlockLock)
            {
                try
                {
                    if (addresses.Exists(x => x.SoftType == SoftType.M))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.M).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;

                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 8000)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)(mAddr[i].Index + 8192), ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses.Where(a => a.SoftType == SoftType.M &&
                                                                 a.Index >= mAddr[i].Index &&
                                                                 a.Index < mAddr[i].Index + ReadBitCount)
                                                     .Select(address =>
                                                     {
                                                         var index = address.Index - mAddr[i].Index;
                                                         address.Value = content[index];
                                                         return address;
                                                     }).ToList();
                                        }
                                    }
                                    CurrnetRow = ReadBitCount + (ushort)mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.X))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.X).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 1024)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)(mAddr[i].Index + 0xF800), ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses?.Where(a => a.SoftType == SoftType.X &&
                                                             a.Index >= mAddr[i].Index &&
                                                             a.Index < mAddr[i].Index + ReadBitCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;
                                                     address.Value = content[index];
                                                     return address;
                                                 }).ToList();
                                        }
                                    }
                                    CurrnetRow = ReadBitCount + (ushort)mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.Y))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.Y).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 1024)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)(mAddr[i].Index + 0xFC00), ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses.Where(a => a.SoftType == SoftType.Y &&
                                                             a.Index >= mAddr[i].Index &&
                                                             a.Index < mAddr[i].Index + ReadBitCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;
                                                     address.Value = content[index];
                                                     return address;
                                                 }).ToList();
                                        }
                                    }
                                    CurrnetRow = ReadBitCount + (ushort)mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.D))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.D).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    //如果当前最大值索引与最小值之间的数据 一次性读取完成
                                    var lplData = ReadHoldingRegisters((ushort)mAddr[i].Index, ReadRegisterCount);
                                    sw.Stop();
                                    var elipse = sw.ElapsedMilliseconds;
                                    if (lplData?.Length == ReadRegisterCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses?.Where(a => a.SoftType == SoftType.D && a.Index >= mAddr[i].Index && a.Index < mAddr[i].Index + ReadRegisterCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;

                                                     if (address.DataType == DataType.Int32)
                                                     {
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index].GetInt32(lplData[index + 1]);
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index].GetInt32(lplData[index + 1]) / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     else if (address.DataType == DataType.UInt32)
                                                     {
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index].GetUInt32(lplData[index + 1]);
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index].GetUInt32(lplData[index + 1]) / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     else if (address.DataType == DataType.Double)
                                                     {
                                                         address.Value = lplData[index].GetDouble(lplData[index + 1], lplData[index + 2], lplData[index + 3]);
                                                     }
                                                     else if (address.DataType == DataType.Single)
                                                     {
                                                         address.Value = lplData[index].GetSingle(lplData[index + 1]);
                                                     }
                                                     else if (address.DataType == DataType.Int16)
                                                     {
                                                         unchecked
                                                         {
                                                             // 直接赋值
                                                             if (address.DecimalPlace == 0)
                                                             {
                                                                 address.Value = (short)lplData[index];
                                                             }
                                                             else
                                                             {
                                                                 address.Value = (short)lplData[index] / Math.Pow(10, address.DecimalPlace);
                                                             }
                                                         }
                                                     }
                                                     else if (lplData.Length > index)
                                                     {
                                                         // 直接赋值
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index];
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index] / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     return address;
                                                 }).ToList();
                                        }
                                    }
                                    CurrnetRow = mAddr[i].Index + ReadRegisterCount;
                                }
                            }

                            iReturnCode = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Error();
                }
            }
        }
        else
        {
            iReturnCode = 2;
        }
        return iReturnCode;

    }

    /// <summary>
    /// 写入值
    /// </summary>
    /// <param name="startAddress">起始地址</param>
    /// <param name="type">写入数据类型</param>
    /// <param name="value">目标值</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">未能识别正确的类型或尚未实现字符串解析的方法</exception>
    public int WriteDevice(ushort startAddress, DataType type, object value)
    {
        int iReturnCode = -1;

        if (master != null)
        {
            lock (writeDeviceBlockLock)
            {
                switch (type)
                {
                    case DataType.Bit:
                        WriteSingleCoil(startAddress, value.ToBoolean());
                        iReturnCode = 0;
                        break;
                    case DataType.UInt16:
                    case DataType.Int16:
                        WriteSingleRegister(startAddress, value.ToUInt16());
                        iReturnCode = 0;
                        break;
                    case DataType.UInt32:
                    case DataType.Int32:
                    case DataType.Single:
                    case DataType.Double:
                        ushort[] data = [];
                        if (value is uint uintValue)
                        {
                            data = uintValue.GetUInt16s();
                        }
                        else if (value is int intValue)
                        {
                            data = intValue.GetUInt16s();
                        }
                        else if (value is float singleValue)
                        {
                            data = singleValue.GetUInt16s();

                        }
                        else if (value is double doubleValue)
                        {
                            data = doubleValue.GetUInt16s();
                        }
                        if (data.Length > 0)
                        {
                            WriteMultipleRegisters(startAddress, value.GetUInt16s());
                            iReturnCode = 0;
                        }
                        break;
                    default:
                        throw new ArgumentException("未能识别正确的类型或尚未实现字符串解析的方法");
                }
                Thread.Sleep(1);
            }
        }
        return iReturnCode;
    }


    private int WriteDevice(Address address)
    {
        int iReturnCode = -1;

        if (master != null)
        {
            lock (writeDeviceBlockLock)
            {
                switch (address.DataType)
                {
                    case DataType.Bit:
                        WriteSingleCoil((ushort)address.Index, address.Value.ToBoolean());
                        iReturnCode = 0;
                        break;
                    case DataType.UInt16:
                    case DataType.Int16:
                        unchecked
                        {
                            if (address.DecimalPlace > 0)
                            {
                                var content = Math.Pow(10, address.DecimalPlace) * address.Value.ToDouble();
                                WriteSingleRegister((ushort)address.Index, (ushort)content);
                            }
                            else
                            {
                                WriteSingleRegister((ushort)address.Index, address.Value.ToUInt16());
                            }
                        }
                        iReturnCode = 0;
                        break;
                    case DataType.UInt32:
                        if (address.DecimalPlace > 0)
                        {
                            uint content = (Math.Pow(10, address.DecimalPlace) * address.Value.ToDouble()).ToUInt32();
                            WriteMultipleRegisters((ushort)address.Index, content.GetUInt16s());
                        }
                        else
                        {
                            WriteMultipleRegisters((ushort)address.Index, address.Value.ToUInt32().Content.GetUInt16s());
                        }
                        iReturnCode = 0;
                        break;
                    case DataType.Int32:
                        if (address.DecimalPlace > 0)
                        {
                            int content = (Math.Pow(10, address.DecimalPlace) * address.Value.ToDouble()).ToInt32();
                            WriteMultipleRegisters((ushort)address.Index, content.GetUInt16s());
                        }
                        else
                        {
                            if (int.TryParse(address.Value.ToString(), out var content))
                            {
                                ushort[] contnetRes = content.GetUInt16s();
                                WriteMultipleRegisters((ushort)address.Index, contnetRes);
                            }
                        }
                        iReturnCode = 0;
                        break;
                    case DataType.Single:
                        ushort[] scontent = Convert.ToSingle(address.Value).GetUInt16s();
                        WriteMultipleRegisters((ushort)address.Index, scontent);
                        iReturnCode = 0;
                        break;
                    case DataType.Double:
                        WriteMultipleRegisters((ushort)address.Index, address.Value.ToDouble().GetUInt16s());
                        iReturnCode = 0;
                        break;
                    default:
                        throw new ArgumentException("未能识别正确的类型或尚未实现字符串解析的方法");
                }
                Thread.Sleep(1);
            }
        }
        return iReturnCode;
    }

    private int WriteDevice(Address address, params object[] args)
    {
        int iReturnCode = -1;

        if (args.IsNullOrEmpty()) return WriteDevice(address);

        if (address.IsNullOrEmpty()) return iReturnCode;

        if (master != null && args.Length == address.Length)
        {
            lock (writeDeviceBlockLock)
            {
                switch (address.DataType)
                {
                    case DataType.Bit:
                        WriteMultipleCoils((ushort)address.Index, args.ToBooleans());
                        iReturnCode = 0;
                        break;
                    case DataType.UInt16:
                    case DataType.Int16:
                        unchecked
                        {
                            if (address.DecimalPlace > 0)
                            {
                                var content = Math.Pow(10, address.DecimalPlace) * address.Value.ToDouble();
                                WriteSingleRegister((ushort)address.Index, (ushort)content);
                            }
                            else
                            {
                                WriteSingleRegister((ushort)address.Index, address.Value.ToUInt16());
                            }
                        }
                        iReturnCode = 0;
                        break;
                    default:
                        throw new ArgumentException("未能识别正确的类型或尚未实现字符串解析的方法");
                }
                Thread.Sleep(1);
            }
        }
        return iReturnCode;
    }


    int IPlc.Open()
    {
        try
        {
            client = new System.Net.Sockets.TcpClient();
            client.Connect(IPAddress.Parse(ipAddress), port);
            master = (ModbusIpMaster)factory.CreateMaster(client);
            ReadTimeout = 1000;
            WriteTimeout = 1000;
            Connected = true;
            return 0;
        }
        catch (Exception ex)
        {
            "TCP通讯打开异常".Error(ex);
            Connected = false;
            return -1;
        }
    }

    int IPlc.Close()
    {
        if (client != null)
        {
            client.Close();
            client = null;
            master = null;
            Connected = false;
            return 0;
        }
        return -1;
    }

    int IPlc.WriteDevice(Address addresses)
    {
        return WriteDevice(addresses);
    }

    private int ReadDeviceRandom(List<Address> addresses, out Dictionary<int, Address> source)
    {
        int iReturnCode = -1;
        source = [];
        if (master != null && client != null && client.Connected)
        {
            lock (readDeviceBlockLock)
            {
                try
                {
                    if (addresses.Exists(x => x.SoftType == SoftType.M))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.M).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;

                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 8000)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)mAddr[i].Index, ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses.Where(a => a.SoftType == SoftType.M &&
                                                                 a.Index >= mAddr[i].Index &&
                                                                 a.Index < mAddr[i].Index + ReadBitCount)
                                                     .Select(address =>
                                                     {
                                                         var index = address.Index - mAddr[i].Index;
                                                         address.Value = content[index];
                                                         return address;
                                                     }).ToList();
                                        }
                                    }

                                    CurrnetRow = ReadBitCount + mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.X))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.X).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 1024)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)(mAddr[i].Index + 0xF800), ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses?.Where(a => a.SoftType == SoftType.X &&
                                                             a.Index >= mAddr[i].Index &&
                                                             a.Index < mAddr[i].Index + ReadBitCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;
                                                     address.Value = content[index];
                                                     return address;
                                                 }).ToList();
                                        }
                                    }
                                    CurrnetRow = ReadBitCount + mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.Y))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.Y).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow && mAddr[i].Index < 1024)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    var content = ReadCoils((ushort)(mAddr[i].Index + 0xFC00), ReadBitCount);
                                    sw.Stop();
                                    var elapsed = sw.ElapsedMilliseconds;

                                    if (content?.Length == ReadBitCount)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses.Where(a => a.SoftType == SoftType.Y &&
                                                             a.Index >= mAddr[i].Index &&
                                                             a.Index < mAddr[i].Index + ReadBitCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;
                                                     address.Value = content[index];
                                                     return address;
                                                 }).ToList();
                                        }
                                    }
                                    CurrnetRow = ReadBitCount + mAddr[i].Index;
                                }
                            }
                            iReturnCode = 0;
                        }
                    }

                    if (addresses.Exists(x => x.SoftType == SoftType.D))
                    {
                        //筛选M点位数据
                        var mAddr = addresses.Where(a => a.SoftType == SoftType.D).ToList();
                        //如果此次读取包含M点
                        if (mAddr?.Count > 0)
                        {
                            //匹配索引是否处于读取范围
                            int CurrnetRow = -1;
                            for (var i = 0; i < mAddr.Count; i++)
                            {
                                if (mAddr[i].Index >= CurrnetRow)
                                {
                                    var sw = new Stopwatch();
                                    sw.Start();
                                    //如果当前最大值索引与最小值之间的数据 一次性读取完成,额外多读取4位，防止最后一位恰好是双精度浮点数导致读取的数据切割异常
                                    var lplData = ReadHoldingRegisters((ushort)mAddr[i].Index, ReadRegisterCount + 4);
                                    sw.Stop();
                                    var elipse = sw.ElapsedMilliseconds;
                                    //判断读取的数目与实际的数目是否一致
                                    if (lplData?.Length == ReadRegisterCount + 4)
                                    {
                                        lock ((addresses as ICollection).SyncRoot)
                                        {
                                            addresses?.Where(a => a.SoftType == SoftType.D && a.Index >= mAddr[i].Index && a.Index < mAddr[i].Index + ReadRegisterCount)
                                                 .Select(address =>
                                                 {
                                                     var index = address.Index - mAddr[i].Index;

                                                     if (address.DataType == DataType.Int32)
                                                     {
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index].GetInt32(lplData[index + 1]);
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index].GetInt32(lplData[index + 1]) / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     else if (address.DataType == DataType.UInt32)
                                                     {
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index].GetUInt32(lplData[index + 1]);
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index].GetUInt32(lplData[index + 1]) / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     else if (address.DataType == DataType.Double)
                                                     {
                                                         address.Value = lplData[index].GetDouble(lplData[index + 1], lplData[index + 2], lplData[index + 3]);
                                                     }
                                                     else if (address.DataType == DataType.Single)
                                                     {
                                                         address.Value = lplData[index].GetSingle(lplData[index + 1]);
                                                     }
                                                     else if (address.DataType == DataType.Int16)
                                                     {
                                                         unchecked
                                                         {
                                                             // 直接赋值
                                                             if (address.DecimalPlace == 0)
                                                             {
                                                                 address.Value = (short)lplData[index];
                                                             }
                                                             else
                                                             {
                                                                 address.Value = (short)lplData[index] / Math.Pow(10, address.DecimalPlace);
                                                             }
                                                         }
                                                     }
                                                     else if (lplData.Length > index)
                                                     {
                                                         // 直接赋值
                                                         if (address.DecimalPlace == 0)
                                                         {
                                                             address.Value = lplData[index];
                                                         }
                                                         else
                                                         {
                                                             address.Value = lplData[index] / Math.Pow(10, address.DecimalPlace);
                                                         }
                                                     }
                                                     return address;
                                                 }).ToList();


                                        }
                                    }
                                    CurrnetRow = mAddr[i].Index + ReadRegisterCount;
                                }
                            }

                            iReturnCode = 0;
                        }
                    }

                    if (addresses?.Count > 0)
                    {
                        source = new Dictionary<int, Address>(addresses.ToDictionary(addr => addr.GetHashCode(),
                                                                                     addr => addr));
                    }
                }
                catch (Exception ex)
                {
                    ex.Error();
                }
            }
        }
        else
        {
            iReturnCode = 2;
        }
        return iReturnCode;
    }

    int IPlc.ReadDeviceRandom(List<Address> addresses, out Dictionary<int, Address> source)
    {
        return ReadDeviceRandom(addresses, out source);
    }

    int IPlc.WriteDevice(Address addresses, params object[] args)
    {
        throw new NotImplementedException();
    }

    public int ReadDevice(out Address address)
    {
        throw new NotImplementedException();
    }

    public int ReadDevice(Address address, out object[] lplData)
    {
        throw new NotImplementedException();
    }

    int IPlc.ReadDevice(out Address address)
    {
        throw new NotImplementedException();
    }

    int IPlc.ReadDevice(Address address, out object[] lplData)
    {
        throw new NotImplementedException();
    }

    public int WriteDeviceRandom(List<Address> addresses)
    {
        throw new NotImplementedException();
    }
}
