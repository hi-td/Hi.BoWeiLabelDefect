/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Dog
* 机器名称：HLZN
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：Dog
* 创建时间：2022/1/17 10:30:43
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2021  保留所有权利.
***********************************************************/
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System;
using static VisionPlatform.Auxiliary.Constant;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Hi.Ltd;

namespace VisionPlatform.Auxiliary
{
    public class Dog
    {
        [DllImport("kernel32.dll", EntryPoint = "CreateSemaphoreA")]
        public static extern IntPtr CreateSemaphore(int lpSemaphoreAttributes, int lInitialCount, int lMaximumCount, string lpName);
        [DllImport("kernel32.dll")]
        public static extern int WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);
        [DllImport("kernel32.dll")]
        public static extern int ReleaseSemaphore(IntPtr hSemaphore, int lReleaseCount, int lpPreviousCount);
        [DllImport("kernel32.dll", EntryPoint = "CreateFileA")]
        public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);
        [DllImport("kernel32.dll")]
        public static extern int CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll")]
        public static extern int GetLastError();

        [DllImport("HID.dll")]
        public static extern int HidD_GetHidGuid(ref GUID HidGuid);
        [DllImport("HID.dll")]
        public static extern bool HidD_GetAttributes(IntPtr HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);
        [DllImport("HID.dll")]
        public static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);
        [DllImport("HID.dll")]
        public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);
        [DllImport("HID.dll")]
        public static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);
        [DllImport("HID.dll")]
        public static extern bool HidD_SetFeature(IntPtr HidDeviceObject, byte[] ReportBuffer, int ReportBufferLength);
        [DllImport("HID.dll")]
        public static extern bool HidD_GetFeature(IntPtr HidDeviceObject, byte[] ReportBuffer, int ReportBufferLength);

        [DllImport("SetupApi.dll")]
        public static extern IntPtr SetupDiGetClassDevsA(ref GUID ClassGuid, int Enumerator, int hwndParent, int Flags);
        [DllImport("SetupApi.dll")]
        public static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
        [DllImport("SetupApi.dll")]
        public static extern bool SetupDiGetDeviceInterfaceDetailA(IntPtr DeviceInfoSet, ref SP_INTERFACE_DEVICE_DATA DeviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, int DeviceInfoData);
        [DllImport("SetupApi.dll")]
        public static extern bool SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref GUID InterfaceClassGuid, int MemberIndex, ref SP_INTERFACE_DEVICE_DATA DeviceInterfaceData);

        public static int FindPort(int start, ref string OutPath)
        {
            int ret;
            IntPtr hsignal;
            hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            ret = NT_FindPort(start, ref OutPath);
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }
        public static int DogisExist()
        {
            string KeyPath = string.Empty;
            return FindDog(0, VERF_CODE, ref KeyPath);
        }
        public static int FindDog(int pos, string VerfCode, ref string KeyPath)
        {
            int ret; int count = 0, D8_count = 0;
            while (true)
            {
                ret = FindPort(count, ref KeyPath);
                if (ret != 0) return ret;
                ret = OpenKey(VerfCode, KeyPath);
                CloseKey(KeyPath);
                if (ret == 0)
                {
                    if (pos == D8_count) return 0;
                    D8_count++;
                }
                count++;
            }
        }
        public static int OpenKey(string VerfCode, string InPath)
        {
            if (VerfCode.Length > MAX_KEY_LEN)
            {
                return OVER_KEY_LEN;
            }
            IntPtr hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            int ret = NT_OpenKey(VerfCode, InPath);
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }

        private static string GetString() => "1234";

        public static int CloseKey(string InPath) => GetBufCarryData(CLOSE_KEY, null, 0, null, 0, InPath);

        public static int RunFuntion(string FunctionName, string InPath)
        {
            IntPtr hsignal; int ret;
            int FunNameLen = FunctionName.Length + 1;
            if (FunNameLen > MAX_FUNNAME)
            {
                return FUNCTION_LENGTH_NAME_MORE_THEN_25;
            }
            hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            ret = NT_RunFun(FunctionName, FunNameLen, InPath);
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }
        public static int GetDogID(ref string dogID, string InPath)
        {
            byte[] b_OutChipID = new byte[16];
            IntPtr hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            int ret = NT_GetChipID(b_OutChipID, InPath); ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            dogID = ByteArrayToHexString(b_OutChipID, 16, 0);
            return ret;

        }
        public static string GetValue(string name, string KeyPath)
        {
            string _Company = string.Empty;
            byte[] Buf = new byte[50];
            var LastErr = SetVar(Buf, 50, 50, KeyPath);
            if (LastErr != 0) return _Company;
            LastErr = RunFuntion(name, KeyPath);
            if (LastErr == -7999) { ApiCall(KeyPath); }
            if (LastErr != 0) return _Company;
            LastErr = GetVar(Buf, 0, 50, KeyPath);
            if (LastErr != 0) return _Company;
            Buf2Var(ref _Company, Buf, 0);
            return _Company;
        }
        public static int SetVar(byte[] Buf, int MemBeginPos, int BufLen, string InPath)
        {
            IntPtr hsignal; int ret = 0; int n; int SendLen;
            hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            for (n = 0; n < BufLen; n = n + TRANSFER_VAR_SIZE)
            {
                SendLen = BufLen - n;
                if (SendLen > TRANSFER_VAR_SIZE) SendLen = TRANSFER_VAR_SIZE;
                ret = NT_SetVar(Buf, n, MemBeginPos, (byte)SendLen, InPath);
                if (ret != 0) break;
                MemBeginPos = MemBeginPos + TRANSFER_VAR_SIZE;
            }
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }
        public static int GetVar(byte[] OutBuf, int MemBeginPos, int OutBufLen, string InPath)
        {
            IntPtr hsignal; int ret = 0, n; int SendLen;
            hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            for (n = 0; n < OutBufLen; n = n + TRANSFER_VAR_SIZE)
            {
                SendLen = OutBufLen - n;
                if (SendLen > TRANSFER_VAR_SIZE) SendLen = TRANSFER_VAR_SIZE;
                ret = NT_GetVar(OutBuf, n, MemBeginPos, (byte)SendLen, InPath);
                if (ret != 0) break;
                MemBeginPos = MemBeginPos + TRANSFER_VAR_SIZE;
            }
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }
        private static int GetBufCarryData(byte Cmd, byte[] Inbuf, int Inlen, byte[] OutData, int Outlen, string InPath)
        {
            byte[] array_in = new byte[MAX_BUF_SIZE];
            byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = Cmd;
            if (Inlen > 0) Array.Copy(Inbuf, 0, array_in, 2, Inlen);
            IntPtr hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            int ret = Hanldetransfer(array_in, Inlen + 1, array_out, Outlen + sizeof(short), InPath);
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            if (Outlen > 0) Array.Copy(array_out, sizeof(short), OutData, 0, Outlen);

            return ret;
        }

        public static int GetApiParam(byte[] OutBuf, string InPath)
        {
            IntPtr hsignal; int ret = 0; byte OutLen = 0; int count = 0;
            hsignal = CreateSemaphore(0, 1, 1, "ex_sim");
            WaitForSingleObject(hsignal, INFINITE);
            while (OutLen == 0)
            {
                ret = NT_GetApiParam(OutBuf, count, ref OutLen, InPath);
                count = count + GETDATA_BUF_SIZE;
                if (ret != 0) break;
            }
            ReleaseSemaphore(hsignal, 1, 0);
            CloseHandle(hsignal);
            return ret;
        }

        #region<!--私有静态方法-->
        private static bool Subisfindmydevice(int pos, ref int count, ref string OutPath)
        {
            IntPtr hardwareDeviceInfo;
            SP_INTERFACE_DEVICE_DATA DeviceInfoData = new SP_INTERFACE_DEVICE_DATA();
            int i;
            GUID HidGuid = new GUID();
            SP_DEVICE_INTERFACE_DETAIL_DATA functionClassDeviceData = new SP_DEVICE_INTERFACE_DETAIL_DATA();
            int requiredLength;
            IntPtr d_handle;
            HIDD_ATTRIBUTES Attributes = new HIDD_ATTRIBUTES();

            i = 0; count = 0;
            HidD_GetHidGuid(ref HidGuid);

            hardwareDeviceInfo = SetupDiGetClassDevsA(ref HidGuid, 0, 0, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

            if (hardwareDeviceInfo == (IntPtr)INVALID_HANDLE_VALUE) return false;

            DeviceInfoData.cbSize = Marshal.SizeOf(DeviceInfoData);

            while (SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, 0, ref HidGuid, i, ref DeviceInfoData))
            {
                if (GetLastError() == ERROR_NO_MORE_ITEMS) break;
                if (System.IntPtr.Size == 4)
                    functionClassDeviceData.cbSize = 5;
                else
                    functionClassDeviceData.cbSize = 8;
                requiredLength = 0;
                if (!SetupDiGetDeviceInterfaceDetailA(hardwareDeviceInfo, ref DeviceInfoData, ref functionClassDeviceData, 300, ref requiredLength, 0))
                {
                    SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
                    return false;
                }
                OutPath = ByteConvertString(functionClassDeviceData.DevicePath);
                d_handle = CreateFile(OutPath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
                if ((IntPtr)INVALID_HANDLE_VALUE != d_handle)
                {
                    if (HidD_GetAttributes(d_handle, ref Attributes))
                    {
                        if ((Attributes.ProductID == PID) && (Attributes.VendorID == VID) ||
                            (Attributes.ProductID == PID_NEW) && (Attributes.VendorID == VID_NEW) ||
                            (Attributes.ProductID == PID_NEW_2) && (Attributes.VendorID == VID_NEW_2))
                        {
                            if (pos == count)
                            {
                                SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
                                CloseHandle(d_handle);
                                return true;
                            }
                            count++;
                        }
                    }
                    CloseHandle(d_handle);
                }
                i++;

            }
            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
            return false;
        }

        private static int NT_FindPort(int start, ref string OutPath)
        {
            int count = 0;
            if (!Subisfindmydevice(start, ref count, ref OutPath))
            {
                return -92;
            }
            return 0;
        }

        //以下函数用于将字节数组转化为宽字符串
        private static string ByteConvertString(byte[] buffer) => Encoding.Default.GetString(buffer).TrimEnd(new char[] { '\0', '\0' });

        private static int NT_OpenKey(string VerfCode, string Path)
        {

            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = OPEN_KEY;

            HexStringToByteArray(VerfCode, ref array_in, 2);
            return Hanldetransfer(array_in, 1 + MAX_KEY_LEN, array_out, sizeof(short), Path);
        }

        private static int HexStringToByteArray(string InString, ref byte[] b, int pos)
        {
            int nlen = InString.Length;
            int retutn_len = 0;
            if (nlen < 16) retutn_len = 16;
            retutn_len = nlen / 2;
            int i = 0;
            for (int n = 0; n < nlen - 1; n += 2)
            {
                string temp = InString.Substring(n, 2);
                b[i + pos] = (byte)HexToInt(temp);
                i++;
            }
            return retutn_len;
        }

        private static int Hanldetransfer(byte[] InBuf, int InBufLen, byte[] OutBuf, int OutBufLen, string Path)
        {
            int ret = 0;
            IntPtr hUsbDevice = IntPtr.Zero;
            if (OpenMydivece(ref hUsbDevice, Path) != 0) return NOUSBKEY;

            if (InBufLen > 0) if (!SetFeature(hUsbDevice, InBuf, InBufLen))
                {
                    ret = GetLastError();
                    if (ret != 121)
                    {
                        CloseHandle(hUsbDevice); return -93;
                    }
                }
            resume:
            if (OutBufLen > 0) if (!GetFeature(hUsbDevice, OutBuf, OutBufLen))
                {
                    ret = GetLastError();
                    if (ret == 121) goto resume;
                    CloseHandle(hUsbDevice);
                    return -94;
                }
            if (ret != 0) return ret;
            ret = BitConverter.ToInt16(OutBuf, 0);
            return ret;
        }

        //以下用于将16进制字符串转化为无符号长整型
        private static uint HexToInt(string s)
        {
            string[] hexch = { "0", "1", "2", "3", "4", "5", "6", "7",
                                       "8", "9", "A", "B", "C", "D", "E", "F"};
            s = s.ToUpper();
            int r = 0;
            int k = 1;
            for (int i = s.Length; i > 0; i--)
            {
                string ch = s.Substring(i - 1, 1);
                int n = 0;
                for (int j = 0; j < 16; j++)
                {
                    if (ch == hexch[j])
                    {
                        n = j;
                    }
                }
                r += n * k;
                k *= 16;
            }
            return unchecked((uint)r);
        }

        private static int OpenMydivece(ref IntPtr hUsbDevice, string Path)
        {
            if (Path?.Length < 1)
            {
                string OutPath = string.Empty;
                int count = 0;
                if (!Subisfindmydevice(0, ref count, ref OutPath)) return NOUSBKEY;
                hUsbDevice = CreateFile(OutPath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
                if (hUsbDevice == (IntPtr)INVALID_HANDLE_VALUE) return NOUSBKEY;
            }
            else
            {
                hUsbDevice = CreateFile(Path, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0);
                if (hUsbDevice == (IntPtr)INVALID_HANDLE_VALUE) return NOUSBKEY;
            }
            return 0;
        }

        private static bool SetFeature(IntPtr hDevice, byte[] array_in, int in_len)
        {
            byte[] FeatureReportBuffer = new byte[512];
            IntPtr Ppd = IntPtr.Zero;
            HIDP_CAPS Caps = new HIDP_CAPS();

            if (!HidD_GetPreparsedData(hDevice, ref Ppd)) return false;

            if (HidP_GetCaps(Ppd, ref Caps) <= 0)
            {
                HidD_FreePreparsedData(Ppd);
                return false;
            }

            bool Status = true;

            FeatureReportBuffer[0] = 2;

            for (int i = 0; i < in_len; i++)
            {
                FeatureReportBuffer[i + 1] = array_in[i + 1];

            }
            bool FeatureStatus = HidD_SetFeature(hDevice, FeatureReportBuffer, Caps.FeatureReportByteLength);

            Status = Status && FeatureStatus;
            HidD_FreePreparsedData(Ppd);

            return Status;

        }

        private static bool GetFeature(IntPtr hDevice, byte[] array_out, int out_len)
        {

            bool FeatureStatus;
            bool Status;
            int i;
            byte[] FeatureReportBuffer = new byte[512];
            IntPtr Ppd = System.IntPtr.Zero;
            HIDP_CAPS Caps = new HIDP_CAPS();

            if (!HidD_GetPreparsedData(hDevice, ref Ppd)) return false;

            if (HidP_GetCaps(Ppd, ref Caps) <= 0)
            {
                HidD_FreePreparsedData(Ppd);
                return false;
            }

            Status = true;

            FeatureReportBuffer[0] = 1;

            FeatureStatus = HidD_GetFeature(hDevice, FeatureReportBuffer, Caps.FeatureReportByteLength);
            if (FeatureStatus)
            {
                for (i = 0; i < out_len; i++)
                {
                    array_out[i] = FeatureReportBuffer[i];
                }
            }


            Status = Status && FeatureStatus;
            HidD_FreePreparsedData(Ppd);

            return Status;

        }

        private static int NT_GetChipID(byte[] OutChipID, string Path)
        {
            int[] t = new int[8];
            byte[] array_in = new byte[25];
            byte[] array_out = new byte[25];
            IntPtr hUsbDevice = IntPtr.Zero;
            if (OpenMydivece(ref hUsbDevice, Path) != 0) return -92;
            array_in[1] = GET_CHIPID;
            if (!SetFeature(hUsbDevice, array_in, 1)) { CloseHandle(hUsbDevice); return -93; }
            if (!GetFeature(hUsbDevice, array_out, 17)) { CloseHandle(hUsbDevice); return -93; }
            CloseHandle(hUsbDevice);
            if (array_out[0] != 0x20) return USBStatusFail;
            for (int n = 0; n < 16; n++)
            {
                OutChipID[n] = array_out[1 + n];
            }

            return 0;
        }

        private static int NT_RunFun(string FunctionName, int FunNameLen, string Path)
        {
            byte[] FuncNameBuf = Encoding.Default.GetBytes(FunctionName);
            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = RUN_FUNCTION;
            Array.Copy(FuncNameBuf, 0, array_in, 2, FuncNameBuf.Length);
            return Hanldetransfer(array_in, 1 + FunNameLen, array_out, sizeof(short), Path);
        }

        private static string ByteArrayToHexString(byte[] in_data, int nlen, int pos)
        {
            string OutString = string.Empty;
            for (int n = 0; n < nlen; n++)
            {
                OutString += in_data[n + pos].ToString("X2");
            }
            return OutString;
        }
        private static void Buf2Var(ref string OutData, byte[] Buf, int pos)
        {
            OutData = Encoding.Default.GetString(Buf, pos, Buf.Length - pos);
            char[] null_string = { '\0', '\0' };
            string[] sArray = OutData.Split(null_string);
            if (sArray.Length > 0) OutData = sArray[0];
        }

        private static int ApiCall(string KeyPath)
        {

            byte[] ApiNameBuf = new byte[50];
            var LastErr = GetApiParam(ApiNameBuf, KeyPath);
            if (LastErr != 0) return LastErr;
            LastErr = GetBufCarryData(COUNTINU_RUNCTION, null, 0, null, 0, KeyPath);
            if (LastErr == -7999) { ApiCall(KeyPath); }
            return LastErr;
        }

        private static int NT_SetApiParam(byte[] Buf, int pos, byte BufLen, string Path)
        {
            int ret;
            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = SET_API_PARAM;
            array_in[2] = BufLen;
            Array.Copy(Buf, pos, array_in, 3, BufLen);
            ret = Hanldetransfer(array_in, 1 + 1 + BufLen, array_out, sizeof(short), Path);

            return ret;
        }
        private static int NT_SetVar(byte[] Buf, int pos, int MemBeginPos, byte BufLen, string Path)
        {

            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = SET_VAR;
            Dword2Buf(array_in, 2, MemBeginPos, sizeof(short));
            array_in[2 + sizeof(short)] = BufLen;
            array_in[2 + sizeof(short) + 1] = 0;//只用一个字节，用2个字节的作用是为了与DEBUGer相同
            Array.Copy(Buf, pos, array_in, 2 + sizeof(short) + sizeof(short), BufLen);
            return Hanldetransfer(array_in, 1 + sizeof(short) + sizeof(short) + BufLen, array_out, sizeof(short), Path);

        }

        private static int NT_GetVar(byte[] OutBuf, int pos, int MemBeginPos, byte OutBufLen, string Path)
        {
            int ret;
            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = GET_VAR;
            Dword2Buf(array_in, 2, MemBeginPos, sizeof(short));
            array_in[2 + sizeof(short)] = OutBufLen;
            array_in[2 + sizeof(short) + 1] = 0;
            ret = Hanldetransfer(array_in, 1 + sizeof(short) + sizeof(short), array_out, sizeof(short) + OutBufLen, Path);
            Array.Copy(array_out, sizeof(short), OutBuf, pos, OutBufLen);
            return ret;

        }
        private static int NT_GetApiParam(byte[] OutBuf, int pos, ref byte OutLen, string Path)
        {
            int ret;
            byte[] array_in = new byte[MAX_BUF_SIZE]; byte[] array_out = new byte[MAX_BUF_SIZE];
            array_in[1] = GET_API_PARAM;

            ret = Hanldetransfer(array_in, 1, array_out, MAX_BUF_SIZE, Path);
            OutLen = array_out[sizeof(short)];
            if (OutLen > 0)
            {
                Array.Copy(array_out, sizeof(short) + 1, OutBuf, pos, OutLen);
            }
            else
            {
                Array.Copy(array_out, sizeof(short) + 1, OutBuf, pos, GETDATA_BUF_SIZE);
            }
            return ret;

        }

        private static void Dword2Buf(byte[] Buf, int pos, int InData, int size)
        {
            byte[] TmpBuf = BitConverter.GetBytes(InData);
            Array.Copy(TmpBuf, 0, Buf, pos, size);
        }
        #endregion
    }

    public static class Data
    {
        private static readonly ReaderWriterLockSlim DataLock = new ReaderWriterLockSlim();

        public static void SerializeData<T>(this T value, string filePath)
        {
            try
            {
                DataLock.EnterWriteLock();

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, value);
                }
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
            }
            finally
            {
                DataLock.ExitWriteLock();
            }
        }

        public static T DeserializeData<T>(this string filePath)
        {
            try
            {
                DataLock.EnterReadLock();
                if (File.Exists(filePath))
                {
                    if (new FileInfo(filePath).Length > 0)
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            var binaryFormatter = new BinaryFormatter();
                            return (T)binaryFormatter.Deserialize(fileStream);
                        }
                    }
                }
                return default;
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }
            finally
            {
                DataLock.ExitReadLock();
            }
        }
    }



    #region<!--Dog类引用-->
    public struct GUID
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Data1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Data2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Data3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Data4;
    }
    public struct SP_INTERFACE_DEVICE_DATA
    {
        public int cbSize;
        public GUID InterfaceClassGuid;
        public int Flags;
        public IntPtr Reserved;
    }
    public struct SP_DEVINFO_DATA
    {
        public int cbSize;
        public GUID ClassGuid;
        public int DevInst;
        public IntPtr Reserved;
    }
    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public int cbSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[] DevicePath;
    }
    public struct HIDD_ATTRIBUTES
    {
        public int Size;
        public ushort VendorID;
        public ushort ProductID;
        public ushort VersionNumber;
    }
    public struct HIDP_CAPS
    {
        public short Usage;
        public short UsagePage;
        public short InputReportByteLength;
        public short OutputReportByteLength;
        public short FeatureReportByteLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public short[] Reserved;
        public short NumberLinkCollectionNodes;
        public short NumberInputButtonCaps;
        public short NumberInputValueCaps;
        public short NumberInputDataIndices;
        public short NumberOutputButtonCaps;
        public short NumberOutputValueCaps;
        public short NumberOutputDataIndices;
        public short NumberFeatureButtonCaps;
        public short NumberFeatureValueCaps;
        public short NumberFeatureDataIndices;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_HDR
    {
        public int dbcc_size;
        public int dbcc_devicetype;
        public int dbcc_reserved;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_DEVICEINTERFACE
    {
        public int dbcc_size;
        public int dbcc_devicetype;
        public int dbcc_reserved;
        public Guid dbcc_classguid;
        public short dbcc_name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class DEV_BROADCAST_DEVICEINTERFACE1
    {
        public int dbcc_size;
        public int dbcc_devicetype;
        public int dbcc_reserved;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
        public byte[] dbcc_classguid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] dbcc_name;
    }
    #endregion



}
