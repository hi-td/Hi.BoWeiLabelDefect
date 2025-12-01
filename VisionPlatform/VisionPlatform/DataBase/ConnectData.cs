/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：ConnectData
* 机器名称：HLZN
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：ConnectData
* 创建时间：2023/9/27 15:56:14
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2023 保留所有权利.
***********************************************************/
using System;

namespace VisionPlatform.Auxiliary
{
    [Serializable]
    public class ConnectData
    {
        public string Address { get; set; }
        public string DataBase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
    [Serializable]
    public class IniData(string ipAddress, int port)
    {
        public string IpAddress { get; set; } = ipAddress;

        public int Port { get; set; } = port;
        public IniData() : this("192.168.1.88", 502)
        {

        }
    }
}
