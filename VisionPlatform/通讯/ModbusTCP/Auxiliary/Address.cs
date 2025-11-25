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
        /// 相机1触发1
        /// </summary>
        public static Address M900 = new Address(SoftType.M, 900, DataType.Bit);
        /// <summary>
        ///相机1触发2
        /// </summary>
        public static Address M901 = new Address(SoftType.M, 901, DataType.Bit);
        /// <summary>
        /// 相机2触发1
        /// </summary>
        public static Address M902 = new Address(SoftType.M, 902, DataType.Bit);
        /// <summary>
        /// 相机2触发2
        /// </summary>
        public static Address M903 = new Address(SoftType.M, 903, DataType.Bit);
        /// <summary>
        /// 相机3触发
        /// </summary>
        public static Address M904 = new Address(SoftType.M, 904, DataType.Bit);
        /// <summary>
        /// 所有拍照完成信号
        /// </summary>
        public static Address M921 = new Address(SoftType.M, 921, DataType.Bit);

        /// <summary>
        /// 相机1反馈1
        /// </summary>
        public static Address D500 = new Address(SoftType.D, 500, DataType.Bit);
        /// <summary>
        /// 相机1反馈2
        /// </summary>
        public static Address D501 = new Address(SoftType.D, 501, DataType.Bit);
        /// <summary>
        /// 相机2反馈1
        /// </summary>
        public static Address D502 = new Address(SoftType.D, 502, DataType.Bit);
        /// <summary>
        ///相机2反馈2
        /// </summary>
        public static Address D503 = new Address(SoftType.D, 503, DataType.Bit);
        /// <summary>
        /// 相机3反馈
        /// </summary>
        public static Address D504 = new Address(SoftType.D, 504, DataType.Bit);

        public static List<Address> addresses = [M900, M901, M902, M903, M904, M921];

        public static List<int> addressKeys = [M900.GetHashCode(), M901.GetHashCode(), M902.GetHashCode(), M903.GetHashCode(), M904.GetHashCode(), M921.GetHashCode()];
    }
}
