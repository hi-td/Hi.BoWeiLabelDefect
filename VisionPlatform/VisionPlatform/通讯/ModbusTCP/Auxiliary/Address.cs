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
        public static Address M0 = new Address(SoftType.M, 0, DataType.Bit);
        /// <summary>
        ///相机2触发
        /// </summary>
        public static Address M2 = new Address(SoftType.M, 2, DataType.Bit);

        /// <summary>
        /// 相机1、相机2反馈
        /// </summary>
        public static Address M1 = new Address(SoftType.M, 1, DataType.Bit);
        /// <summary>
        /// 相机3反馈
        /// </summary>
        public static Address M3 = new Address(SoftType.M, 3, DataType.Bit);


        public static List<Address> addresses = [M0, M1, M2, M3];

        public static List<int> addressKeys = [M0.GetHashCode(), M1.GetHashCode(), M2.GetHashCode(), M3.GetHashCode()];
    }
}
