using BaseData;
using System;
using System.Collections.Generic;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public class DataSerializer
    {
        [Serializable]
        public class GlobalData
        {
            //这里所有的相机int用两位数表示，第一位为主相机，第二位是子画面，若无子画面则用0表示
            //<相机ID, 检测项目列表>
            public Dictionary<int, List<InspectData.InspectItem>> dicInspectList = new Dictionary<int, List<InspectData.InspectItem>>();
            //<相机ID, 画质调节参数>
            public Dictionary<int, Imageing> dicImageing = new Dictionary<int, Imageing>();
            //<相机ID，<检测项,字体显示位置>>
            //一个相机可能对应多个检测项目，一个检测项一一对应一组字体参数
            public Dictionary<int, Dictionary<InspectItem, FontShowParam>> dicFontShowSet = new Dictionary<int, Dictionary<InspectItem, FontShowParam>>();
            //<相机ID, 正面检测参数>
            public Dictionary<int, InspectData.FrontParam> dic_FrontParam = new Dictionary<int, InspectData.FrontParam>();
            //<相机ID,背面检测参数>>
            public Dictionary<int, InspectData.BackParam> dic_BackParam = new Dictionary<int, InspectData.BackParam>();
            //线序（颜色检测）
            public List<ColorID> listColorID = new List<ColorID>();          //颜色模板ID
            //PLC
            public SlmpPara SlmpPara = new SlmpPara();
        }
        public static GlobalData _globalData = new GlobalData();
        //标定
        [Serializable]
        public class GlobalData_Calib
        {
            public Dictionary<int, BaseData.XYCalibParam> dic_XYCalibParam = new Dictionary<int, XYCalibParam>();
        }
        public static GlobalData_Calib _globalCalib = new GlobalData_Calib();
        [Serializable]
        public class GlobalData_COM
        {
            public List<IOSet> listIOSet = new List<IOSet>();                    //WENYU8或WENYU16-IO信号配置
            public int WENYU232_ComPort = -1;                                    //WENYU232转IO通讯端口号
            public BaseData.LEDRTU Led = new BaseData.LEDRTU();                  //光源控制器串口配置
        }
        public static GlobalData_COM _COMConfig = new GlobalData_COM();
        //plc串口配置
        public class GlobalData_Mobus
        {
            public PLCRTU[] PlcRTU = new PLCRTU[2];
        }
        public static GlobalData_Mobus _PlcRTU = new GlobalData_Mobus();
        public class GlobalData_ModbusTcp
        {
            public InspectData.ModbusTCPConfig ModbusTcpConfig = new ModbusTCPConfig();
            public InspectData.ModbusTcpPara ModbusTcpPara = new InspectData.ModbusTcpPara();
        }
        public static GlobalData_ModbusTcp _ModbusTcp = new GlobalData_ModbusTcp();
        //显示设置
        public class GlobalData_Show
        {
            public InspectData.Display Show = new InspectData.Display();
        }
        public static GlobalData_Show _Show = new GlobalData_Show();
        public class GlobalData_IOandtime
        {
            public InspectData.IO Io = new InspectData.IO();
        }
        public static GlobalData_IOandtime _Ioandtime = new GlobalData_IOandtime();
        //splitContainer1间距
        public class GlobalData_Splitter_Distance
        {
            public InspectData.Splitter_Distance Distance = new InspectData.Splitter_Distance();
        }
        public static GlobalData_Splitter_Distance _splitter_Distance = new GlobalData_Splitter_Distance();
        //计数
        public class GlobalData_ShowCount
        {
            /// <summary>
            /// 计数
            /// </summary>
            public List<Count> Count = new List<Count>();
        }
        public static GlobalData_ShowCount _ShowCount = new();
    }
}
