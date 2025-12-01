using System.IO;

namespace GlobalPath
{
    public class SavePath
    {
        public static string AIFlod = @"D:\Program Files\VisionPlatform\Ai";
        private static string configFileFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Config");
        private static string modelFileFlod = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Model");     //模型json文件保存路径
        private static string JosnFileFlod = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Josn");
        private static string ModelImageFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "TemplateImage");   //注：不包含文件名称
        private static string VideoFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "TeachVideo");   //视频教程
        public static string ImageFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "ImageSaving");
        //public static string ImageFold1 = System.IO.Path.Combine("F:\\", "ImageSaving");
        private static string CsvFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Csv");
        private static string IniFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Ini");

        static SavePath()
        {
            if (!Directory.Exists(AIFlod))
            {
                System.IO.Directory.CreateDirectory(AIFlod);
            }
            if (!Directory.Exists(VideoFold))
            {
                System.IO.Directory.CreateDirectory(VideoFold);
            }
            if (!Directory.Exists(configFileFold))
            {
                System.IO.Directory.CreateDirectory(configFileFold);
            }
            if (!Directory.Exists(modelFileFlod))
            {
                System.IO.Directory.CreateDirectory(modelFileFlod);
            }
            if (!Directory.Exists(ModelImagePath))
            {
                System.IO.Directory.CreateDirectory(ModelImagePath);
            }
            if (!Directory.Exists(JosnFileFlod))
            {
                Directory.CreateDirectory(JosnFileFlod);
            }
            if (!Directory.Exists(ImageFold))
            {
                Directory.CreateDirectory(ImageFold);
            }
        }
        public static string IniPath = IniFold + "\\VisionPlatform.ini";
        public static string LanguagePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Language.json");
        //软件配置初始化json文件保存路径
        public static string InitConfigPath = configFileFold + "\\InitConfig.json";
        //相机配置文件路径
        public static string CamConfigPath = configFileFold + "\\CamConfig.json";
        //端子检测组合配置文件
        public static string TMCheckListPath = configFileFold + "\\TMConfig.json";
        //字体检测数据显示位置
        public static string FontShowSetPath = configFileFold + "\\FontShowSet.json";
        //公司名字
        public static string CompanyNamePath = configFileFold + "\\CompanyName.json";
        //公司logo地址
        public static string CompanyLogoPath = configFileFold + "\\CompanyLogo.txt";
        //公司logo地址
        public static string CompanyLogo = configFileFold + "\\CompanyLogoPath.txt";
        //联系我们
        public static string ContactPath = configFileFold + "\\Contact.json";
        //IO时间
        public static string IOPath = configFileFold + "\\IO.json";
        //图片保存天数
        public static string TimePath = configFileFold + "\\Time.json";
        //数据保存路径
        public static string GlobalDataPath = JosnFileFlod + "\\";   //注：不包含文件名称
        //最新保存的数据名称路径
        public static string NewestFile = JosnFileFlod + "\\NewestFileName.json";
        //保存模板路径
        public static string ModelPath = modelFileFlod + "\\";   //注：不包含文件名称

        public static string QRCodePath = ModelPath;
        //模板图片保存路径 
        public static string ModelImagePath = ModelImageFold + "\\";
        //教学视频路径
        public static string VideoPath = VideoFold + "\\端子机视觉检测教学.mov";
        //数据存储
        public static string Count = configFileFold + "\\Count.json";

        public static string ModbusTcpPath = configFileFold + "\\ModbusTcp.json";

        public static string CsvPath = CsvFold + "\\";                          //注：不包含文件名称

    }


}
