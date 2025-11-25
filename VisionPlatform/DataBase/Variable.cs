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
using Hi.Ltd.SqlServer;

namespace VisionPlatform.Auxiliary
{
    public static partial class Variable
    {
        #region<!--string类型声明-->
        //public static string DogPath = string.Empty;
        //public static string Company = string.Empty;
        //public static string Author = string.Empty;
        //public static string ModeChar = string.Empty;
        //public static string Md5Value = string.Empty;
        //public static string SerserialNumber = string.Empty;
        //public static string GetOrder = string.Empty;
        //public static string GetState = string.Empty;
        //public static string GetAdaptImageSize = string.Empty;
        //public static string GetAdministrator = string.Empty;
        //public static string GetEnvPathName = string.Empty;
        //public static string GetCamDefaultName = string.Empty;
        #endregion

        //public static int GetParameter = -1;

        //public static RSAKeyValue RSAKeyValues;
        //是否是调试模式
        public static bool IsDebug = false;
        //是否已经扫码
        public static bool IsScanCode = false;
        //是否已经到位
        public static bool IsOKorNGCode = false;
        public static string Code = string.Empty;
        public static string sName = string.Empty;
        public static string sComponentCode = string.Empty;//组件编码
        public static string sWorkOrderNumber = string.Empty;//工单号   
        //public static ConnectData RemoteData = new ConnectData();
        //public static ISerializer ini = Ini.Create;
        //public static IniData IniData = Singleton<IniData>.GetInstance();
        //public static readonly object LockObj = new object();
        public static InspectData.FrontResult m_Result10 = new InspectData.FrontResult();//正面检测结果
        public static InspectData.BackResult m_Result30 = new InspectData.BackResult();//背面检测结果

        public static ISqlServer sqlServer = SqlEntities.Create;
    }
}
