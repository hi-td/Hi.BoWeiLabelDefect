using CamSDK;
using EnumData;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;

namespace BaseData
{
    //相机图像窗口数据结构
    [Serializable]
    public struct CamShowItem
    {
        public CamShowItem()
        {
            listMirror = new List<Mirror>();
        }
        public string strCamSer;                       //相机的序列号
        public List<Mirror> listMirror { get; set; }   //镜像图片
        public CamShowItem(string camSer, List<Mirror> listMirror)
        {
            this.strCamSer = camSer; this.listMirror = listMirror;
        }
    }
    //图像光源亮度、曝光时间等参数
    [Serializable]
    public struct Imageing
    {
        public Imageing()
        {
            CHBright = new CHBright[6];
        }
        public CamCommon.CamParam camParam;
        public string strPort;
        public CHBright[] CHBright { get; set; }
    }

    #region 光源控制器
    [Serializable]
    public struct CHBright
    {
        public CHBright()
        {
            bOpen = false;
            nBrightness = 0;
        }
        public bool bOpen;          //是否开启
        public int nBrightness;     //亮度
        public CHBright(bool open, int nBright)
        {
            this.bOpen = open; this.nBrightness = nBright;
        }
    }
    //光源串口通讯设置
    [Serializable]
    public struct LEDRTU
    {
        public string PortName;          //端口号
        public bool bOpen;               //是否打开
        public int BaudRate;             //波特率
        public int DataBits;             //数据位
        public Parity parity;            //校验位
        public StopBits stopBits;        //停止位
    }
    #endregion

    //通讯方式：网口
    [Serializable]
    public class ComMode
    {
        private COMType type;
        private COM com;
        private IO io;
        private WAN ip;
        public COMType TYPE
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public COM COM
        {
            get
            {
                return com;
            }
            set
            {
                com = value;
            }
        }
        public IO IO
        {
            get
            {
                return io;
            }
            set
            {
                io = value;
            }
        }

        public WAN wan
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

    }
    [Serializable]
    public class WAN
    {
        private string brand;
        private string model;
        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
    }

    //初始化数据：软件启动时配置一次
    [Serializable]
    public struct ConfigData
    {
        public CamBrand camBrand;                 //相机品牌
        public int CamNum;                        //相机数量
        public Dictionary<int, int> dic_SubCam;   //相机及其对应的子画面数量
        public ComMode comMode;                   //通讯方式
        public bool bIOLight;                     //io板卡是否常亮模式
        public bool bUSBCam;                     //是否USB相机
        public bool bDigitLight;                  //是否数字型光源控制器
        public int nLightCH;                      //光源控制器通道数
        public bool bLogo;                        //是否显示logo界面
        //public int nImageSaveDays;              //图片保存天数
        //public string strImgAddress;            //图片保存地址
        public int nDaySave;                      //图像保存天数
        public bool bAutostarts;                  //开机自启
    }

    [Serializable]
    public struct OtherConfig
    {
        public string strCompanyName;   //公司名称
        public bool bDisplay;           //运行中，是否在图像上显示检测数据
        public bool bOrgOK;             //是否保存原始OK图像
        public bool bOrgNG;             //是否保存原始NG图像
        public bool bResultOK;          //是否保存结果OK图像
        public bool bResultNG;          //是否保存结果NG图像
        public int nImageSaveDays;      //图片保存天数
        public string strImgAddress;    //图片保存地址
        public int nErrorNum;           //管理员权限：芯线检测时，设置允许容错的个数
        public bool OKorNG;      //自动运行检测结果只显示ok.ng
    }

    [Serializable]
    public struct SetImageSaveDays
    {
        public int days;
    }

    #region 联系我们
    [Serializable]
    public struct ContactData
    {
        public string strCompanyName;    //公司名称
        public string strWeb;            //公司网址
        public string strAdress;         //公司地址
        public string strContactName;    //联系人
        public string strTel;            //手机号码
        public string strCode2DPath;     //联系人二维码
        public string strMail;           //邮箱
        public string strPhone;          //电话号码
    }
    #endregion

    ////IO通讯和时间
    //[Serializable]
    //public struct CamIO
    //{
    //    public string cam1DI;
    //    public string cam1DO;
    //    public int cam1ytime;
    //    public int cam1stime;
    //    public string cam2DI;
    //    public string cam2DO;
    //    public int cam2ytime;
    //    public int cam2stime;
    //}

    [Serializable]
    //矩形1
    public struct Rect1
    {
        public double dRectRow1;
        public double dRectCol1;
        public double dRectRow2;
        public double dRectCol2;
        public Rect1(double row1, double col1, double row2, double col2)
        {
            dRectRow1 = row1; dRectCol1 = col1; dRectRow2 = row2; dRectCol2 = col2;
        }
    }

    [Serializable]
    //矩形2
    public struct Rect2
    {
        public double dRect2Row;
        public double dRect2Col;
        public double dPhi;
        public double dLength1;
        public double dLength2;
        public Rect2(double row, double col, double phi, double len1, double len2)
        {
            dRect2Row = row; dRect2Col = col; dPhi = phi; dLength1 = len1; dLength2 = len2;
        }
        public bool isEmpty()
        {
            return (dRect2Row == 0 && dRect2Col == 0 && dPhi == 0 && dLength1 == 0 && dLength2 == 0);
        }
    }

    [Serializable]
    //圆
    public struct Circle
    {
        public double dRow;
        public double dCol;
        public double dRadius;
        public Circle(double row, double col, double radius)
        {
            dRow = row; dCol = col; dRadius = radius;
        }
        public bool isEmpty()
        {
            return (dRow == 0 && dCol == 0 && dRadius == 0);
        }
    }

    [Serializable]
    //椭圆
    public struct Ellipse
    {
        public double dRow;
        public double dColumn;
        public double dPhi;
        public double dRadius1;
        public double dRadius2;

    }

    [Serializable]
    //直线
    public struct Line
    {
        public double dStartRow;            //直线起始点row
        public double dStartCol;            //直线起始点col
        public double dEndRow;              //直线结束点row
        public double dEndCol;              //直线结束点col
        public Line(double row1, double col1, double row2, double col2)
        {
            dStartRow = row1; dStartCol = col1; dEndRow = row2; dEndCol = col2;
        }
        public bool isEmpty()
        {
            return (dStartRow == 0 && dStartCol == 0 && dEndRow == 0 && dEndCol == 0);
        }
    }
    [Serializable]
    public struct Arbitrary
    {
        public List<double> dListRow;
        public List<double> dListCol;
        public Arbitrary(List<double> list_row, List<double> list_col)
        {
            list_row = dListRow; list_col = dListCol;
        }
        public bool isEmpty()
        {
            return (dListRow?.Count == 0 && dListCol?.Count == 0);
        }
    }
    [Serializable]
    public enum MesDirect
    {
        UpDown,
        DownUp,
        LeftRight,
        RightLeft
    }
    [Serializable]
    //边缘梯度变化点参数
    public struct EdgePointMeasure
    {
        public bool bShow;              //是否显示拟合过程
        public int nLen1;               //直线搜索框length1
        public double dLen2;            //直线搜索框length2
        public int nThd;                //边缘点阈值  
        public string strTrans;         //边缘灰度变化,暗到亮positive，亮到暗negative
        public string strSelect;        //边缘点选择:first,last
        public MesDirect direct;        //扫描方向
        public EdgePointMeasure(int len1, double len2, int thd, string trans, string pointSelect)
        {
            nLen1 = len1; dLen2 = len2; nThd = thd; strTrans = trans; strSelect = pointSelect;
        }
    }

    public enum ColorSpace
    {
        gray,
        rgb,
        hsv,
        hsi,
        hls,
        lms,
        ihs
    }


    [Serializable]
    public struct ColorSpaceTransParam
    {
        public ColorSpaceTransParam()
        {
            strColorSpace = "hsi";
            arrayImageChannels = new bool[8];
        }
        public string strColorSpace { get; set; }
        public bool[] arrayImageChannels { get; set; }  //8维数组：轮廓图、灰度图、R、G、B、image1、image2、image3
    }

    [Serializable]
    public struct ColorID
    {
        [JsonIgnore]
        public HTuple[] ID;      //颜色模板ID
    }

    #region 定位
    [Serializable]
    public enum ModelType
    {
        contour,
        region,
        ncc,
        gmm,
        dcm
    }
    [Serializable]
    public enum ObjDraw
    {
        empty,
        line,
        rect1,
        rect2,
        circle,
        ellipse,
        arbitrary,
        gap
    }
    [Serializable]

    //定位模板输入参数
    public struct LocateInParams
    {
        public ModelType modelType;    //创建模板的方式：1轮廓，0区域，2灰度
        public double dAngleStart;     //模板搜索起始角度  备注：弧度
        public double dAngleEnd;       //模板搜索结束角度  备注：弧度
        public string strModelName;    //模板名字
        public bool bScale;            //是否使用缩放匹配
        public double dScaleMin;       //最小缩放倍率
        public double dScaleMax;       //最大缩放倍率
        public double dScore;          //匹配分数   
    }

    [Serializable]
    //定位模板输出参数
    public struct LocateOutParams
    {
        public double dModelRow;
        public double dModelCol;
        public double dModelAngle;
        public double dScore;
        public LocateOutParams(double row, double col, double angle, double score)
        {
            dModelRow = row; dModelCol = col; dModelAngle = angle; dScore = score;
        }
    }

    #endregion

    #region 相机标定
    public enum CamCalibType
    {
        Checker,
        CirclePoint,
        Code2D
    };

    //棋盘格标定
    [Serializable]
    public struct CheckerCalibParam
    {
        public double dLength;    //棋盘格大小
        public double dRectangularity; //棋盘格矩形度
        public int nThreshold;     //阈值：白色背景，黑色格子
    }

    //圆点标定
    [Serializable]
    public struct CirclePointCalibParam
    {
        public double dCircleDiam;  //圆点直径
        public double dCircleSpace; //圆点间距    
        public int nThd;            //阈值：白色背景，黑色圆点
        public double dCircularity; //圆形度
    }
    //二维码标定
    [Serializable]
    public struct Code2DCalibParam
    {
        public string strCodeType;
    }

    [Serializable]
    //标定结果
    public struct CalibrateResult
    {
        public double dXCalib;    //水平方向标定系数
        public double dYCalib;    //垂直方向标定系数
        public double dCalibVal() //平均标定系数
        {
            double dCalib = (dXCalib + dYCalib) / 2.0;
            return dCalib;
        }
    }
    #endregion

    #region XY标定
    [Serializable]
    public struct CalibParam
    {
        public Line line;             //起点-终点
        public double dCalibVal;      //标定系数
        public double dAngleCol;      //与图像水平方向的夹角
        public double dAngleRow;      //与图像垂直方向的夹角
    }

    public struct XYCalibParam
    {
        public CalibParam calibX;      //X轴标定
        public CalibParam calibY;      //Y轴标定
    }
    [Serializable]
    public struct CenterParam
    {
        public PointF point;    //定位中心点
        public double dAngle;   //定位角度：与图像水平方向的夹角
    }
    [Serializable]
    public struct LocateParam
    {
        public CenterParam modelCenter;  //定位点
        public Line lineX;               //运动轴X轴：需沿X轴正方向
        public Line lineY;               //运动轴Y轴：需沿Y轴正方向
    }
    #endregion

    [Serializable]
    public struct DoubleLineParam
    {
        public int nThd;                     //阈值分割
        public int nTransType;
        public EdgePointMeasure EPMeasure;
        public Rect2 rect2;
    }

    [Serializable]
    public struct DoubleLineOut
    {
        public Line lineLeft;
        public Line lineRight;
        public double dDist;     //像素距离
        public double dAngle;
    }

    [Serializable]
    public struct LineParam
    {
        public EdgePointMeasure measure;
        public Line lineIn;
    }

    [Serializable]
    public struct CircleParam
    {
        public EdgePointMeasure EPMeasure;
        public Circle circleIn;
    }

    [Serializable]
    public struct EllipseParam
    {
        public EdgePointMeasure EPMeasure;
        public Ellipse ellipseIn;
    }
    [Serializable]
    public struct Rect2Param
    {
        public EdgePointMeasure EPMeasure;
        public Rect2 rect2In;
    }

    [Serializable]
    public struct LineInterLineResult
    {
        public bool bIsSegInter;   //作为线段是否相交
        public bool bIsLineInter;  //作为直线是否相交
        public PointF InterPoint;  //交点
        public double dDistMin;    //最小距离
        public double dDistMax;    //最大距离
        public double dAngle;
    }

    [Serializable]
    public struct CircleInterCircleResult
    {
        public bool bIsIntersect;             //是否相交
        public double dDistCenter;          //两圆圆心距离
        public List<PointF> listInterPoint; //交点

    }

    [Serializable]
    public struct Code1DParam
    {
        public string strCodeType;
        public double dMeasThreshAbs;
        public int nContrastMin;
    }

    [Serializable]
    public struct Code1DDecode
    {
        public string strDecode;
        public string strCodeType;
    }
    [Serializable]
    public struct Code1DResult
    {
        public List<Code1DDecode> listCode1DDecode;
    }
    [Serializable]
    public struct roiParam
    {
        public Rect1 rect1;
        public Rect2 rect2;
        public Circle circle;
        public Line line;
        public Ellipse ellipse;
    }
    [Serializable]
    public struct MeanImageParam
    {
        public int nMaskWidth;
        public int nMaskHeight;
    }
    [Serializable]
    public struct MedianImageParam
    {
        public string strMaskType;
        public int nMaskRadius;
    }

    [Serializable]
    public struct OCRParam
    {
        public string strMethod;
        public string strCharType;
        public int nBackGround;
        public string strDirect;
        public double dMinWidth;
        public double dMaxWidth;
        public double dMinHeight;
        public double dMaxHeight;

    }
    [Serializable]
    public struct ValueRange
    {
        public ValueRange()
        {
            bFlag = true;
        }
        public bool bFlag { get; set; }    //是否使用     
        public double dMax;                //最大值
        public double dMin;                //最小值
        public ValueRange(bool flag, double min, double max)
        {
            this.bFlag = flag;
            this.dMin = min;
            this.dMax = max;
        }
    }
    [Serializable]
    public struct RatioRange
    {
        public RatioRange()
        {
            dVal = 0;
            dRatioMax = 1;
            dRatioMin = 0;
        }
        public double dVal { get; set; }          //标准值     
        public double dRatioMax { get; set; }     //最大比值
        public double dRatioMin { get; set; }     //最小比值
        public RatioRange(double val, double ratioMin, double ratioMax)
        {
            this.dVal = val;
            this.dRatioMax = ratioMax;
            this.dRatioMin = ratioMin;
        }
        public double MinVal()
        {
            return dVal * dRatioMin;
        }
        public double MaxVal()
        {
            return dVal * dRatioMax;
        }
    }

    [Serializable]
    public struct ThdParam
    {
        public bool bAutoThd;              //true：自动阈值 false：静态阈值
        public int nStaticThd;             //最低亮度值
        public int nMeanMask;              //动态阈值：均值滤波
        public int nDynThd;                //动态阈值：Offset
        public string sLightDark;
        public int nStaticThdMin;          //最低亮度值
        public int nStaticThdMax;          //最低亮度值
    }
    [Serializable]
    public struct StaticThdParam
    {
        public bool b0_x;              //阈值取值范围是否为0-X，否则X-255
        public int nThd;               //静态阈值
        public StaticThdParam(bool b0_X, int thd)
        {
            this.b0_x = b0_X;
            this.nThd = thd;
        }
        public int[] ThdValue()
        {
            int[] thd = new int[2];
            try
            {
                if (b0_x)
                {
                    thd[0] = 0;
                    thd[1] = nThd;
                }
                else
                {
                    thd[0] = nThd;
                    thd[1] = 255;
                }
            }
            catch (Exception e) { }
            return thd;
        }
    }

    [Serializable]
    public struct RectROIMove
    {
        public int nWidth;               //检测框宽度
        public int nHeight;              //检测框高度
        public int nXMove;               //水平移动量
        public int nYMove;               //垂直移动量
        public RectROIMove(int width, int height, int xMove, int yMove)
        {
            nWidth = width; nHeight = height; nXMove = xMove; nYMove = yMove;
        }
    }

    [Serializable]
    public struct NccLocateParam
    {
        public bool bLimitROI;
        public double dScore;             //匹配分数
        [JsonIgnore]
        public object nModelID;           //ncc模板ID
        public Rect2 rect2;               //用于建立模板的区域
        public Rect2 limitRect2;          //限定检测区域      
    }

    #region 光度立体法
    [Serializable]
    public enum PhotometricStereoImageType
    {
        NormalField,  //法向量
        Albedo,       //反照率信息图
        Gradient,     //梯度信息图
        Curvature,    //曲率
        HeightField,  //高度信息图
    }
    public struct PhotometricStereoImage : IDisposable
    {
        public PhotometricStereoImage()
        {
        }
        public HObject NormalField { get; set; } = new HObject();

        public HObject Albedo { get; set; } = new HObject();
        public HObject Gradient { get; set; } = new HObject();
        public HObject Curvature { get; set; } = new HObject();
        public HObject HeightField { get; set; } = new HObject();

        public HObject this[PhotometricStereoImageType type]
        {
            get
            {
                return type switch
                {
                    PhotometricStereoImageType.NormalField => NormalField,
                    PhotometricStereoImageType.Albedo => Albedo,
                    PhotometricStereoImageType.Gradient => Gradient,
                    PhotometricStereoImageType.Curvature => Curvature,
                    PhotometricStereoImageType.HeightField => HeightField,
                    _ => null,
                };
            }
            set
            {
                switch (type)
                {
                    case PhotometricStereoImageType.NormalField:
                        NormalField = value;
                        break;
                    case PhotometricStereoImageType.Albedo:
                        Albedo = value;
                        break;
                    case PhotometricStereoImageType.Gradient:
                        Gradient = value;
                        break;
                    case PhotometricStereoImageType.Curvature:
                        Curvature = value;
                        break;
                    case PhotometricStereoImageType.HeightField:
                        HeightField = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public readonly IEnumerable<HObject> GetHObjects
        {
            get
            {
                yield return NormalField;
                yield return Albedo;
                yield return Gradient;
                yield return Curvature;
                yield return HeightField;
            }
        }

        public void Dispose()
        {
            foreach (var img in GetHObjects)
            {
                img?.Dispose();
            }
        }
    }
    #endregion
}
