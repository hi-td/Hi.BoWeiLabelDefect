/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Variable
* 机器名称：HLZN
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：Variable
* 创建时间：2022/1/17 10:48:26
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2021  保留所有权利.
***********************************************************/
using System;

namespace VisionPlatform.Auxiliary
{
    public static partial class Variable
    {
        #region<!--string类型声明-->
        public static string DogPath = string.Empty;
        public static string Company = string.Empty;
        public static string Author = string.Empty;
        public static string ModeChar = string.Empty;
        public static string Md5Value = string.Empty;
        public static string SerserialNumber = string.Empty;
        public static string GetOrder = string.Empty;
        public static string GetState = string.Empty;
        public static string GetAdaptImageSize = string.Empty;
        public static string GetAdministrator = string.Empty;
        public static string GetEnvPathName = string.Empty;
        public static string GetCamDefaultName = string.Empty;
        #endregion

        public static int GetParameter = -1;

        public static RSAKeyValue RSAKeyValues;

        public static int OpenRes = -1;

        public static Hi.Ltd.SqlServer.ISqlServer SqlServer;
    }
    [Serializable]
    public struct RSAKeyValue
    {
        public string Modulus;
        public string Exponent;
        public string P;
        public string Q;
        public string DP;
        public string DQ;
        public string InverseQ;
        public string D;
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Modulus;
                    case 1:
                        return Exponent;
                    case 2:
                        return P;
                    case 3:
                        return Q;
                    case 4:
                        return DP;
                    case 5:
                        return DQ;
                    case 6:
                        return InverseQ;
                    case 7:
                        return D;
                    default:
                        return default;
                };
            }
        }
    }
}
