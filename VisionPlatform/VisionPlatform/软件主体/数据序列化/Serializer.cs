using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BaseData;
using EnumData;

namespace GlobalData
{
    //框架通用序列化数据
    public class Config
    {
        public static Language _language = new Language();
        //软件启动初始化配置：相机，通讯方式等
        public class InitConfig
        {
            public ConfigData initConfig = new ConfigData();
            public OtherConfig otherConfig = new OtherConfig();
        }
        public static InitConfig _InitConfig = new InitConfig();

        public class ContactUs
        {
            public ContactData contact = new ContactData();
        }
        public static ContactUs _Contact = new ContactUs();
        /// <summary>
        /// 相机配置
        /// </summary>
        public class CamConfig
        {
            //<相机ID，相机序列号> 
            public Dictionary<int, CamShowItem> camConfig = new Dictionary<int, CamShowItem>();     
        }
        public static CamConfig _CamConfig = new CamConfig();

    }

}
