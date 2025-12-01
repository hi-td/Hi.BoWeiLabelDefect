/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Constant
* 机器名称：HLZN
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：Constant
* 创建时间：2022/1/17 10:31:37
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2021  保留所有权利.
***********************************************************/
namespace VisionPlatform.Auxiliary
{
    public static class Constant
    {
        #region<!--私有常量-->
        public const ushort VID = 0x3689;
        public const ushort PID = 0x8762;
        public const ushort PID_NEW = 0X2020;
        public const ushort VID_NEW = 0X3689;
        public const ushort PID_NEW_2 = 0X2020;
        public const ushort VID_NEW_2 = 0X2020;
        public const short DIGCF_PRESENT = 0x02;
        public const short DIGCF_DEVICEINTERFACE = 0x10;
        public const short INVALID_HANDLE_VALUE = -1;
        public const short ERROR_NO_MORE_ITEMS = 0x103;
        public const uint GENERIC_READ = 0x80000000;
        public const int GENERIC_WRITE = 0x40000000;
        public const uint FILE_SHARE_READ = 0x01;
        public const uint FILE_SHARE_WRITE = 0x02;
        public const uint OPEN_EXISTING = 0x03;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const uint INFINITE = 0xFFFF;
        public const short MAX_LEN = 0x1EF;
        public const int FUNCTION_LENGTH_NAME_MORE_THEN_25 = -79;
        public const int NOUSBKEY = -92;
        public const int CANNOT_OPEN_BIN_FILE = -8017;
        public const int CAN_NOT_READ_FILE = -8026;
        public const int OVER_KEY_LEN = 0x1F59;
        public const int OVER_BIND_SIZE = -8035;
        public const byte GETVERSION = 0x01;
        public const byte GETID = 0x02;
        public const byte GETVEREX = 0x05;
        public const byte CAL_TEA = 0x08;
        public const byte SET_TEAKEY = 0x09;
        public const byte READBYTE = 0x10;
        public const byte WRITEBYTE = 0x11;
        public const byte YTREADBUF = 0x12;
        public const byte YTWRITEBUF = 0x13;
        public const byte MYRESET = 0x20;
        public const byte YTREBOOT = 0x24;
        public const byte SET_ECC_PARA = 0x30;
        public const byte GET_ECC_PARA = 0x31;
        public const byte SET_ECC_KEY = 0x32;
        public const byte GET_ECC_KEY = 0x33;
        public const byte MYENC = 0x34;
        public const byte MYDEC = 0X35;
        public const byte SET_PIN = 0X36;
        public const byte GEN_KEYPAIR = 0x37;
        public const byte YTSIGN = 0x51;
        public const byte YTVERIFY = 0x52;
        public const byte GET_CHIPID = 0x53;
        public const byte YTSIGN_2 = 0x53;
        public const byte MAX_KEY_LEN = 0x10;
        public const byte MAX_FUNNAME = 25;
        public const byte MAX_BUF_SIZE = 0xFF;
        public const byte DOWNLOAD_SIZE = 0xFC;
        public const byte TRANSFER_VAR_SIZE = MAX_BUF_SIZE - 1 - 1 - 4;
        public const byte GETDATA_BUF_SIZE = MAX_BUF_SIZE - 2 - 1 - 1;
        public const byte VERF_CODE_SIZE = 8;
        public const byte NEW_PWD_LEN = 9;
        public const byte NEW_EPROM_TRANSFER_SIZE = MAX_BUF_SIZE - (1 + 1 + sizeof(short) + 1 + 2 * NEW_PWD_LEN);
        public const byte MAX_BIND_MAC_SIZE = 200;
        public const byte GET_LIMIT_DATE = 0x71;
        public const byte SET_LIMIT_DATE = 0x72;
        public const byte GET_USER_ID = 0x73;
        public const byte GET_LEAVE_NUMBER = 0x74;
        public const byte CHECK_NUMBER = 0x75;
        public const byte SET_NUMBER_AUTH = 0x76;
        public const byte SET_BIND_AUTH = 0x77;
        public const byte SET_DATE_AUTH = 0x78;
        public const byte CHECK_DATE = 0x79;
        public const byte CHECK_BIND = 0x7A;
        public const byte GET_LEAVE_DAYS = 0x7B;
        public const byte GET_BIND_INFO = 0x7C;
        public const byte YTDOWNLOAD = 0x80;
        public const byte START_DOWNLOAD = 0x81;
        public const byte RUN_FUNCTION = 0x82;
        public const byte SET_VAR = 0x84;
        public const byte GET_VAR = 0x85;
        public const byte SET_DOWNLOAD_KEY = 0x86;
        public const byte OPEN_KEY = 0x87;
        public const byte CLOSE_KEY = 0x88;
        public const byte COUNTINU_RUNCTION = 0x89;
        public const byte GET_API_PARAM = 0x8A;
        public const byte SET_API_PARAM = 0x8B;
        public const byte GETFUNCVER = 0x8C;
        public const byte WRITE_NEW_EPROM = 0x8D;
        public const byte READ_NEW_EPROM = 0x8E;
        public const byte SET_PWD = 0x8F;
        public const byte GET_DY_DATA_SIZE = 0x9E;
        public const byte GET_DY_DATA_VALUE = 0x9F;
        public const byte SET_DY_DATA_VALUE = 0xA0;
        public const byte CLEAR_DY = 0xA1;
        public const int D8_USHORT = sizeof(short);
        public const int GETDYDATASIZE_LEN = sizeof(int) + D8_USHORT;
        public const int GETDYDATA_LEN = sizeof(int) + D8_USHORT * 2;

        public const string VERF_CODE = "@verfcode";
        public const string DISPLAY_MEMBER = "Text";
        public const string VALUE_MEMBER = "Value";
        public const int USBStatusFail = -50;  //USB操作失败，可能是没有找到相关的指令
        #endregion
    }
}
