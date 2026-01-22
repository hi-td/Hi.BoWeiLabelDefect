using Hi.Ltd.Data;
using Hi.Ltd.Enumerations;
using Hi.Ltd.Interface;
using Hi.Ltd.Interop;
using System.Collections.Generic;

namespace VisionPlatform.Auxiliary
{
    public static partial class Variable
    {
        public static ConnectData RemoteData = new ConnectData();
        public static IIni ini = IniHelper.Create;
        // public static IniData IniData = Singleton<IniData>.GetInstance();
        /// <summary>
        /// 相机1、相机2触发
        /// </summary>
        public static Address M20 = new Address(SoftType.M, 20, DataType.Bit);
        /// <summary>
        ///相机3触发
        /// </summary>
        public static Address M22 = new Address(SoftType.M, 22, DataType.Bit);

        /// <summary>
        /// 相机1、相机2反馈
        /// </summary>
        public static Address M21 = new Address(SoftType.M, 21, DataType.Bit);
        /// <summary>
        /// 相机3反馈
        /// </summary>
        public static Address M23 = new Address(SoftType.M, 23, DataType.Bit);


        public static List<Address> addresses = [M20, M21, M22, M23];

        public static List<int> addressKeys = [M20.GetHashCode(), M21.GetHashCode(), M22.GetHashCode(), M23.GetHashCode()];
    }
}
