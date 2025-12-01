using BaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using static VisionPlatform.InspectData.SingleTM;
using static VisionPlatform.InspectData.TM;

namespace VisionPlatform
{
    public class InspectData
    {
        [Serializable]
        public struct Count
        {
            public CamInspectItem camInspect;
            public int nTotalOK;
            public int nTotalNG;
            public int nTotal;
        }

        [Serializable]
        public enum InspectItem
        {
            Default,
            Front,
            LeftSide,
            RightSide,
        }

        [Serializable]
        public struct CamInspectItem
        {
            public CamInspectItem()
            {
                cam = -1;
                item = InspectItem.Default;
            }
            public int cam { get; set; }                  //cam用两位数表示，第一位数是main相机，第二位数是分出来的子画面，若无子画面则用0代替
            public InspectItem item { get; set; }          //对应的检测项

            //对两位数cam进行分解，返回十位：main相机，个位：子画面
            public int ten()
            {
                return (cam % 100) / 10 == 0 ? cam : ((cam % 100) / 10);
            }
            public int unit()
            {
                return (cam % 100) / 10 == 0 ? 0 : (cam % 10);
            }
            public CamInspectItem(int camID, InspectItem item)
            {
                this.cam = camID; this.item = item;
            }
        }
        public struct InspectResult
        {
            public InspectResult()
            {
                outcome = new Dictionary<string, string>();
            }
            public double InspectTime;                              //检测时间
            public double GrabTime;                                 //拍照时间
            public Dictionary<string, string> outcome { get; set; } //端子检测结果：检测项及其对应的OK/NG结果
        }

        [Serializable]
        //字体大小、检测数据显示设置
        public struct FontShowParam
        {
            public FontShowParam()
            {
                nOKSize = 50;
                nOKRow = 80;
                nOKCol = Function.imageWidth - 80;
            }
            public int nOKSize { get; set; }            //OK/NG字体大小
            public int nOKRow { get; set; }              //OK/NG显示位置
            public int nOKCol { get; set; }
            public int nRowStartPos;       //Row起始位置
            public int nColStartPos;       //Col起始位置
            public int nFrontSize;         //字体大小
            public int nRowGap;            //行间距
            public int nColGap;            //列间距
        }

        #region WENYU8 或 WENYU16
        [Serializable]
        public struct IOSet
        {
            public CamInspectItem camItem;   //相机及其对应的检测
            public int read;                 //读取的点位
            public IOSend send;
        }

        [Serializable]
        public struct IOSend
        {
            public bool bSendOK;             //是否发送OK信号
            public bool bSendNG;             //是否发送NG信号
            public int sendOK;             //发送OK信号的点位
            public int sendNG;               //发送NG信号的点位
            public bool bSendInvert;         //是否立即反转发送的信号
            public int nSleep;               //发送信号的持续时间
        }
        #endregion

        #region ModbusTCP
        [Serializable]
        public struct ItemAddress
        {
            public CamInspectItem camItem;       //相机及其对应的检测
            public string readKey;               //信号读取地址
            public bool bSend;                   //是否需要发送数据
            public string sendKey;               //数据发送地址
        }
        public struct isAddress
        {
            public bool bUse;
            public string strAddress;
            public isAddress(bool bUse, string strAddress)
            {
                this.bUse = bUse; this.strAddress = strAddress;
            }
        }
        [Serializable]
        public struct ModbusTCPConfig
        {
            public ModbusTCPConfig()
            {
                listItemsAdress = new List<ItemAddress>();
                strDataAdress = new string[2];
            }
            public List<ItemAddress> listItemsAdress;
            public isAddress isOK;
            public isAddress isNG;
            public isAddress isTrigger;
            public isAddress isFinish;
            public bool bSendData;
            public string[] strDataAdress;
        }
        #endregion
        #region 正面检测
        [Serializable]
        public struct FrontParam
        {
            public object modelID;
            public LocateInParams locateInParams;
            public PointF modelPoint;
            public bool bQRCode;
            public bool bPNCode;
            public bool bPlug;
            public bool bCopperRing;
            public bool bTorsionExist;
            public bool bPasterExist;
            public bool bfrontPinBasePos;
            public QRCodeParam QRCode;
            public PNCodeParam PNCode;
            public DefectParam Defect;
            public LabelMoveParam LabelMove;
        }

        public struct FrontResult
        {
            public FrontResult()
            {

            }
            public string strQRCode;
            public string strPNCode;
            public bool bFrontResult = true;
        }

        public struct QRCodeParam
        {
            public object hv_Handel;      //句柄
            public string strCode;        //二维码
            public string strCodeType;    //二维码类型
            public Rect2 rect2ROI;        //限定识别区域
            public int nCodeLength;        //二维码长度
            public int nCodeCaptureLength;//二维码截取长度
        }

        public struct PNCodeParam
        {
            public Rect2 rect2ROI;        //周期码识别区域
            public string strPNCode;      //周期码
        }
        [Serializable]
        public enum MoveType
        {
            line_line,
            point_line,
            point_point,
        }

        public struct LabelMoveParam
        {
            public BaseData.NccLocateParam nccLocate;
        }
        public struct LabelMoveResult
        {
        }

        public struct DefectParam
        {
            public BaseData.Arbitrary arbitrary;
            public double dBrokenScore;
            public int nBrokenMinArea;
            public double dDirtyScore;
            public int nDirtyMinArea;
        }
        public struct DefectResult
        {
        }
        #endregion

        #region 背面检测
        [Serializable]
        public struct BackParam
        {
            public bool bSolder;
            public bool bGuidePin;
            public GuidePinParam GuidePin;
            public SolderParam Solder;
            public bool bCopperRing;
        }

        public struct BackResult
        {
            public SolderResult SolderRes;
            public GuidePinResult GuidePinRes;
            public bool bBackResult;
        }
        public struct SolderParam
        {
            public Rect2 rect2ROI;
            public System.Drawing.Point pin;
            public BaseData.ValueRange pinArea;
            public ColorSpaceThdData colorSpace;
        }
        public struct SolderResult
        {

        }
        public struct GuidePinParam
        {
            public GuidePinParam()
            {
                listCircles = new List<BaseData.Circle>();
            }
            public List<BaseData.Circle> listCircles;
            public ColorSpaceThdData colorSpaceThdData;
            public BaseData.ValueRange ValArea;
            public double dCircularity;
        }
        public struct GuidePinResult
        {
            public GuidePinResult()
            {
                listArea = new List<double>();
                listCircularity = new List<double>();
                listFlag = new List<bool>();
            }
            public List<double> listArea;
            public List<double> listCircularity;
            public List<bool> listFlag;
        }
        #endregion


        #region 插壳检测
        [Serializable]
        public struct RubberParam
        {
            public RubberParam()
            {
                nRubberNum = 0;
                nPinNum = 0;
                arrayDelTM = null;
                listInspectItem = new List<RubberItemParam>();
            }
            public int nRubberNum { get; set; }                       //胶壳数量
            public int nPinNum { get; set; }                     //pin数
            public bool[] arrayDelTM { get; set; }               //屏蔽某些pin不检测
            public RubberLocateParam rubberLocate;               //胶壳定位参数
            public List<RubberItemParam> listInspectItem { get; set; }//同一胶壳检测位置集合
            public BaseLineParam baseLine;                       //基准线
            public LineColorTrainParam lineColor;                     //线序检测
                                                                      //public ColorCharParam chars;                         //字符与线序对应检测
            public RubberBottom bottom;             //底部线束检测
            public RubberBroken broken;             //胶壳破损
                                                    // public MissingPartParam missingPart;    //漏件检测
        }

        [Serializable]
        public struct RubberItemParam
        {
            public ROIParam roi;                    //检测位置
            public RubberMethod method;             //检测方法
        }
        [Serializable]
        public struct RubberLocateParam
        {
            public bool bLimitROI;
            public double dScore;             //匹配分数
            [JsonIgnore]
            public object nModelID;           //ncc模板ID
            public Rect2 rect2;               //用于建立模板的区域
            public Rect2 limitRect2;          //限定检测区域      
        }
        [Serializable]
        public enum LocateMethod
        {
            roi,
            match
        }
        [Serializable]
        public struct SideRubberParam
        {
            public LocateMethod method;             //定位方法
            public RubberLocateParam rubberLocate;  //胶壳定位参数
            public Rect2 leftRect2;                //左定位区域
            public Rect2 rightRect2;               //右定位区域 
            public int nRows;                     //行数
            public int nCols;                     //列数
            public bool[] arrayDelTM;             //屏蔽某些端子不检测
            public ROIParam roi;                  //胶壳检测框
            public int nRowGap;                  //行间距
                                                 //端子有无
            public int nTMThd;                   //端子亮度
            public int nTMMinArea;               //端子最小面积
                                                 //卡扣位置
            public int nFitThd;                  //卡扣阈值
            public int nFitWidthMin;             //卡扣宽度min
            public int nFitWidthMax;             //卡扣宽度max
            public int nFitHeightMin;            //卡扣高度min
            public int nFitHeightMax;            //卡扣高度max
            public double dDistMin;              //卡扣最小距离
            public double dDistMax;              //卡扣最大距离

        }
        public struct SideRubberResult
        {
            public Dictionary<int, List<double>> dic_FitDist;
            public Dictionary<int, List<bool>> dic_TMExist;
            public Dictionary<int, List<double>> dic_TMArea;
        }

        [Serializable]
        public struct DynThdParam
        {
            public DynThdParam()
            {
                bInspect = false;
                nMeanFilter = 15;
                nThd = 128;
            }
            public bool bInspect { get; set; }         //是否检测
            public int nMeanFilter { get; set; }       //均值滤波，用于动态阈值分割
            public int nThd { get; set; }              //分割的阈值
            public DynThdParam(bool inspect, int filter, int thd)
            {
                this.bInspect = inspect;
                this.nMeanFilter = filter;
                this.nThd = thd;
            }
        }
        //插壳检测:检测方法参数
        [Serializable]
        public struct RubberMethod
        {
            public BaseData.ValueRange high;        //端子高度
            public BaseData.ValueRange width;       //端子宽度
            public BaseData.ValueRange dist;        //端子顶点到基准线的距离
            public BaseData.ValueRange area;        //端子面积
            public BaseData.ValueRange rubberAngle; //胶壳的角度
            public int nFeatureSel;                 //根据特征1：亮斑；2：轮廓使用不同的方法  
            public ShapeParam shape;                //亮斑参数
            public GrayParam gray;                  //轮廓参数
            public bool bScaleImage;                //是否对图像拉伸的参数进行调节
            public int nScaleMin;
            public int nScaleMax;
        }

        [Serializable]
        public struct ShapeParam
        {
            public ShapeParam()
            {
                nFilter = 15;
                nContThd = 0;
                nLight = 128;
                nArea = 0;
            }
            public int nFilter { get; set; }
            public int nContThd { get; set; }
            public int nLight { get; set; }
            public int nArea { get; set; }

        }
        [Serializable]
        public struct GrayParam
        {
            public GrayParam()
            {
                light = new DynThdParam();
                dark = new DynThdParam();
                nMinArea = 0;
            }
            public DynThdParam light { get; set; }           //根据亮
            public DynThdParam dark { get; set; }            //根据暗
            public int nMinArea { get; set; }             //最小面积
        }
        //插壳检测:底部线缆检测
        [Serializable]
        public struct RubberBottom
        {
            public bool bAddBottom;    //是否添加的底部检测框
            public int nMoveX;         //底部检测框水平方向平移量（基于匹配点）
            public int nMoveY;         //底部检测框垂直方向平移量（基于匹配点）
            public int nHeight;        //底部检测框高度
            public int dWidth;         //底部检测框宽度
            public int nMethod;        //检测方法
            public RubberBottomMethod1 method1;
            public RubberBottomMethod2 method2;
        }
        [Serializable]
        public struct RubberBottomMethod1
        {
            public int nLineNum;       //线缆数目
            public int nDrakThd;       //线缆阈值0-X
            public double dLineDia;    //单根线缆直径
            public double dLineDiaMin; //单根线缆最小比例（基于直径）
            public double dLineDiaMax; //单根线缆最大比例（基于直径）
            public double dTotalW;     //线缆总宽度
            public double dTotalWMin;  //线缆总宽度最小比例（基于宽度）
            public double dTotalWMax;  //线缆总宽度最大比例（基于宽度）
            public int nMinGap;       //线缆间的最小间距
        }
        [Serializable]
        public struct RubberBottomMethod2
        {
            public int nLightThd;       //端子阈值X-255
            public int nMinArea;        //端子露出面积
            public int nMaxArea;
        }
        //基准线
        [Serializable]
        public struct BaseLineParam
        {
            public bool bBaseLine;             //是否添加基准线
            public List<bool> listCheckRubber; //要检测的胶壳序号（从左往右）
            public int nLen1;                  //检测区域的宽度
            public int nLen2;                  //检测区域的高度
            public int nMoveX;                 //检测区域平移量X/胶壳
            public int nMoveY;                 //检测区域平移量Y/胶壳
            public string strTransiton;        //灰度极性变化
            public string strDirection;        //拟合方向
            public string strPoint;
            public int nThd;                   //分割值
            public Rect2 rect2;                //用于拟合直线的矩形2
            public Rect1 rect1;
            public int nMove;
        }
        public struct RubberBottomResult
        {
            //按胶壳划分
            public List<int> listLineNum;      //线缆数    
            public List<double> listLineDia;      //最大线缆直径
            public List<double> listTotalWidth;   //所有线缆总宽
            public List<double> listMinGap;      //最小线缆间距
            public double dAreas;
        }
        //胶壳破损
        public struct BrokenROIParam
        {
            public DynThdParam dark;
            public DynThdParam light;
            public int nMinArea;
            public int nMaxArea;
            public Rect2 rect2;
        }
        [Serializable]
        public struct BrokenParam
        {
            public Rect2 rect2Broken;         //破损检测区域
            public Rect2 rect2Nearest;        //破损检测区域最近邻胶壳
            public BrokenROIParam roiData;    //破损检测区域检测参数
        }
        public struct RubberBroken
        {
            public bool bInspect;                                    //是否添加胶壳破损检测
            public List<BrokenParam> listBroken;
            public Dictionary<int, BrokenROIParam> dicROIParam;    //破损检测区域及其检测参数
        }
        public struct RubberBrokenResult
        {
            public Dictionary<Rect2, List<double>> dicArea;               //破损检测区域及其对应的面积
        }
        public struct RubberResult
        {
            public List<Rect2> listRubberRect2;                              //胶壳定位框
            public List<List<RubberInsertResult>> listRubberInsertResults;   //插壳检测结果
            public LineColorResult lineColorResult;                          //线序检测结果
                                                                             //public CharsResult charsResult;
            public double dLineArea;                                         //底部检测框，线的面积
            public RubberBottomResult bottomResult;                          //底部检测结果
            public RubberBrokenResult brokenResult;                          //胶壳破损检测结果
                                                                             // public MissingPartResult missingPartResult;                    //插件检测
        }
        public struct RubberInsertResult
        {
            public RubberInsertResult()
            {
                dListHeight = new List<double>();
                dListWidth = new List<double>();
                dListDist = new List<double>();
                dListArea = new List<double>();
                listOK = new List<bool> { false };
            }
            public List<double> dListHeight { get; set; }        //高度
            public List<double> dListWidth { get; set; }         //宽度
            public List<double> dListDist { get; set; }          //距离
            public List<double> dListArea { get; set; }          //面积
            public List<bool> listOK { get; set; }               //OK数
        }
        #endregion

        public class SingleStripLength
        {
            [Serializable]
            public struct StripLenParam
            {
                public Rect2 rect2;           //设置的检测区域
                public double dWidth;         //剥皮宽度
                public double dHeight;        //剥皮高度
                public double dWLow;          //剥皮宽度下浮比例
                public double dWHigh;         //剥皮宽度上浮比例
                public double dHLow;          //剥皮长度下浮比例
                public double dHHigh;         //剥皮长度上浮比例
                public int nMethod;           //方法一：正面打光； 方法二：背面打光
                                              //正面打光
                public int nScaleMin;         //图像拉伸
                public int nThd;              //阈值

            }
            public struct StripLenResult
            {
                public double dWidth;
                public double dHeight;
                public bool bResult;
            }
            //剥皮长度检测
            [Serializable]
            public struct SkinParam
            {
                public double coefficient;//转换系数
                public double physics;//物理值
                public double pixel;//像素值

                //剥皮
                public ColorSpaceTransParam colorSpace_skin;           //剥皮是否使用颜色空间转换

                public bool skintof;   //剥皮检测
                public bool skinwtof_width;      //剥皮检测宽
                public bool skinwtof_high;      //剥皮检测高
                public double skin_width;      //剥皮检测宽值
                public double skin_minwidth;      //剥皮检测宽最小值
                public double skin_maxwidth;      //剥皮检测宽最大值

                public double skin_high;      //剥皮检测高值
                public double skin_minhigh;      //剥皮检测高最小值
                public double skin_maxhigh;      //剥皮检测高最大值

                public bool skinThd0;         //剥皮检测亮度从0开始
                public int skinnThd;    //剥皮检测亮度
                public int skinArea;    //剥皮检测最小面积
                public int skinAreamax;    //剥皮检测最大面积

                public Rect1 rect1;               //剥皮检测位置
                                                  //胶塞
                public ColorSpaceTransParam colorSpace;           //是否使用颜色空间转换
                public bool skintof_rubber;  //胶塞检测
                public bool skinwtof_rubberwidth;      //胶塞检测宽
                public bool skinwtof_rubberhigh;      //胶塞检测高
                public bool skinwtof_rubberll;      //胶塞检测距离
                public bool skinrubbernThd0;         //胶塞检测亮度从0开始

                public double skinrubber_width;      //胶塞检测宽值
                public double skinrubber_minwidth;      //胶塞检测宽最小值
                public double skinrubber_maxwidth;      //胶塞检测宽最大值

                public double skinrubber_high;      //胶塞检测高值
                public double skinrubber_minhigh;      //胶塞检测高最小值
                public double skinrubber_maxhigh;      //胶塞检测高最大值

                public double skinrubber_ll;      //胶塞检测高值
                public double skinrubber_minll;      //胶塞检测高最小值
                public double skinrubber_maxll;      //胶塞检测高最大值

                public int skinrubbernThd;         //胶塞亮度
                public int skinrubberArea;         //胶塞面积

                public int skinrubber_corrosionwidth;         //胶塞宽腐蚀
                public int skinrubber_corrosionhigh;         //胶塞高腐蚀
                public int skinrubber_threshold;         //胶塞边缘幅度
                public double skinrubber_sigma;         //胶塞平滑
                public int skinrubber_ROIhigh;         //胶塞ROI高

            }
            public struct SkinResult
            {
                public SkinResult_skin skinResult_skin;
                public SkinResult_rubber skinPosResult_rubber;
            }
            public struct SkinResult_skin
            {
                public Rect2 skin;
                //public double skin_high;
            }
            public struct SkinResult_rubber
            {
                public double skinrubber_width;
                public double skinrubber_high;
                public double skinrubber_ll;
            }
        }

        public class MultiStripLength
        {
            [Serializable]
            public struct StripLenParam
            {
                public StripLenParam()
                {
                    dicPos = new List<double>();
                }
                public int nLineNum;                       //线的根数
                public Rect2 rect2;                        //设置的检测区域
                public bool bSetBasePos;                   //是否设置基准位置
                public BaseData.Line basePosLine;          //基准位置：顶点连线位置
                public int nOffsetDown;                    //未达到基准线的偏移量
                public int nOffsetUp;                      //超过基准线的偏移量    
                public RatioRange lineWidth;               //芯线宽度
                public RatioRange stripLen;                //剥皮长度
                public bool bWrongOrder;                   //是否开启芯线错位检测
                public List<double> dicPos { get; set; }   //每根线芯的位置<序号，位置>
                public int nPosOffset;                     //每根芯线的偏移量，大于此值NG
                public int nMethod;                        //1：背面打光； 2：正面打光
                                                           //方法1
                public ThdParam thd;                       //方法1：阈值分割参数
                public bool bErosion;                      //是否根据芯线粗细检测
                public int nErosion;                       //根据芯线粗细进行腐蚀
                                                           //方法2
                public int nContThd;                       //正面打光：轮廓图阈值
                                                           //线序检测
                public LineColorTrainParam lineColor;
            }

            public struct StripLenResult
            {
                public StripLenResult()
                {
                    basePosLine = new BaseData.Line();
                    listDist = new List<double>();
                    listStripLen = new List<double>();
                    listLineWidth = new List<double>();
                    listLinePos = new List<double>();
                    listColorFlag = new List<bool>();
                }
                public BaseData.Line basePosLine { get; set; }      //剥皮顶点的基准线
                public List<double> listDist { get; set; }          //到基准线的距离
                public List<double> listStripLen { get; set; }      //剥皮长度
                public List<double> listLineWidth { get; set; }     //芯线宽度
                public List<double> listLinePos { get; set; }       //每根芯线的坐标Col
                public List<bool> listColorFlag { get; set; }       //线序检测结果
            }
        }

        #region 线序检测
        [Serializable]
        public struct LineColorParam
        {
            public bool bInspect;                   //是否检测线序
            public List<ColorData> listColorData;   //颜色ID
            public ColorPos pos;                    //颜色检测位置
            public int nMinColorArea;               //最小颜色面积
        }
        [Serializable]
        public struct LineColorTrainParam
        {
            public LineColorTrainParam()
            {
                listColorID = new List<ColorID>();
            }
            public bool bInspect;                          //是否检测线序
            public List<ColorID> listColorID { get; set; } //颜色ID
            public ColorPos pos;                           //颜色检测位置
        }
        [Serializable]
        public struct ColorPos
        {
            public bool bSelfDefine;                //是否自定义检测位置
            public ROIParam locateROI;              //根据定位结果定位检测位置
            public Rect2 selfRect2;                 //白定义检测位置（固定位置）
            public bool bSegment;                   //是否自动分割出检测区域
            public bool bThd0_X;                    //阈值分割取值范围0—X
            public int nThd;                        //阈值
            public int nLineWidth;                  //线宽
            public int nLineGap;                    //线间距
        }

        public struct LineColorResult
        {
            public List<bool> listFlag;
        }
        [Serializable]
        public enum ColorMethod
        {
            Defult,
            ColorSpace,
            Train,
            AddNew,
        }
        [Serializable]
        public struct ColorSpaceThdData
        {
            /// <summary>
            /// 选择几个组合图像运算
            /// </summary>
            public ColorSpaceTransParam spaceTrans;
            public BaseData.ValueRange Thd;
        }
        [Serializable]
        public struct ColorTrainData
        {
            public ColorID colorID;                              //颜色模板ID(0:Gmm，1:LUT)
            public double dRejThd;                               //lut
        }
        [Serializable]
        public struct ColorData
        {
            public ColorMethod method;              //使用的方法
            public ColorID defaultID;               //
            public ColorSpaceThdData colorSpace; //颜色空间
            public ColorTrainData colorTrain;       //Gmm模型
            public bool bAdd;                       //是否使用两种颜色模型
            public ColorTrainData colorAdd;
            public ColorID[] GetColorID()
            {
                if (bAdd)
                {
                    ColorID[] colorIDs = new ColorID[2];
                    colorIDs[0] = colorTrain.colorID;
                    colorIDs[1] = colorAdd.colorID;
                    return colorIDs;
                }
                else
                {
                    ColorID[] colorIDs = new ColorID[1];
                    colorIDs[0] = colorTrain.colorID;
                    return colorIDs;
                }
            }
        }

        #endregion

        [Serializable]
        public struct ROIParam
        {
            public bool bDivid;                     //是否均分检测框，勾选为不均分
            public int nNum;                        //检测框个数
            public int nROIWidth;                   //检测框宽度
            public int nROIHeight;                  //检测框高度
            public int nMoveX;                      //检测框沿定位中心水平方向移动
            public int nMoveY;                      //检测框沿定位中心垂直方向移动
            public int nGap;                        //间距
        }


        [Serializable]
        public struct SlmpPara
        {
            public string IpAddress;
            public int ReadPort;
            public int WritePort;
        }
        //PLC串口通讯设置
        [Serializable]
        public struct PLCRTU
        {
            public int BaudRate;          //波特率
            public string PortName;       //串口号
            public int DataBits;          //数据位
            public Parity parity;         //校验位
            public StopBits stopBits;     //停止位
            public byte slaveAddress;      //站号
        }
        [Serializable]
        public struct ModbusTcpPara
        {
            public string IpAddress;
            public int Port;
            // Token: 0x04000D9A RID: 3482
            public byte nSlaveAddress;
            public int ConnectTimeout;
            public int ResponseTimeout;
            public int ReadTimeout;
            public int Retries;
        }


        //IO和时间
        [Serializable]
        public struct IO
        {
            public string cam1DI;
            public string cam1DO;
            public int cam1ytime;
            public int cam1stime;
            public string cam2DI;
            public string cam2DO;
            public int cam2ytime;
            public int cam2stime;
        }
        //IO和时间
        [Serializable]
        public struct Splitter_Distance
        {
            public int splitterDistance;
        }
        public enum SelRegion
        {
            left,
            right,
            max
        }


        //是否显示
        [Serializable]
        public struct Display
        {
            public bool display;
        }
        //芯线检测
        [Serializable]
        public struct CoreNumParam
        {
            public int nShow;                 //芯线检出显示的方式
            public int method;
            public int nCoreNum;              //线芯标准数量
            public int nCoreNumLess;          //线芯最少数量
            public int nCoreNumMuch;          //线芯最多数量
            public bool bSetROI;              //是否限定检测区域
            public bool bSetROIshow;              //限定检测区域检测时是否显示
            public Rect1 rect1;               //芯线检测位置
            public double nRadius;            //芯线半径
            public double dCoreArea;
            public int nThd;

            public double score_threshold;  //置信度
            public double nms_threshold;  //非极大值抑制阈值
            public bool bRadius;            //是否启用芯线半径

            public int narea2;             //线芯总面积
            public double nCoreNumLessArea2;  //线芯少百分比
            public double nCoreNumMuchArea2;  //线芯多百分比
            public int noneArea2;         //单线芯标准面积
            public int n2ScaleMin;             //图像拉伸最小值
            public int n2ScaleMax;             //图像拉伸最大值
            public int n2BackGray;             //图像背景最大值
            #region method 3
            public int nScaleMin;             //图像拉伸最小值
            public int nScaleMax;             //图像拉伸最大值
            public int nBackGray;             //图像背景最大值
            #endregion
            //分割
        }
        [Serializable]
        public struct TMItem
        {
            public bool bInspect;
            public string name;
            public TMItem(bool inspect, string strName)
            {
                bInspect = inspect; name = strName;
            }
        }
        [Serializable]
        public struct TMCheckList
        {
            public TMItem SkinWeld;    //绝缘皮压脚检测
            public TMItem SkinPos;     //绝缘皮位置检测
            public TMItem LineWeld;    //线芯压脚检测
            public TMItem LinePos;     //线芯位置检测
            public TMItem LineSide;    //线芯两侧飞边检测
            public TMItem LineOnWeld;  //线芯压脚上方飞丝
            public TMItem TMHead;      //端子头检测
            public TMItem TMNose;      //端子鼻检测
            public bool bLineColor;    //线序（颜色）检测
            public bool Waterproof;    //防水栓检测
        }

        public class TM
        {
            #region 绝缘皮压脚参数

            [Serializable]
            public struct SkinWeldParam
            {
                public BaseData.RectROIMove roi;         //检测位置
                public int nWeldType;                    //压脚类型（1：左右 2：上下 3：不区分）
                public int nAngle;                       //当压脚类型为左右时，中间间隔的角度
                public bool bRoughPos;                   //压脚粗定位
                public RatioRange tmWidth;               //端子宽度取值范围
                public RatioRange tmHeight;              //端子高度取值范围 
                public int nRect2Gap;                    //计算面积比中，压脚区域中分的间隔
                public RatioRange tmArea1;               //铆压面积1取值范围
                public RatioRange tmArea2;               //铆压面积2取值范围
                public double[] arrayAreaRatio;          //压脚面积比
                public bool bColorSpace;                 //是否使用颜色空间
                public ColorSpaceTransParam colorSpace;  //颜色空间转换参数
                public BaseData.ThdParam thdParam;       //阈值分割
                public Rect2 skinWeldRect2;              //示教时找到的绝缘皮压脚的区域

            }

            public struct SkinWeldResult
            {
                public Rect2 skinWeldROI;             //用来检测后计算出来的当前绝缘皮压脚区域
                public double dWidthRatio;
                public double dHeightRatio;
                public int nBinaryThd;               //使用binary_threshold得到的阈值    
                public double[] dAreaRatio;
                public bool bFlag;
            }
            #endregion

            #region 绝缘皮位置参数
            public enum SkinPosMethod
            {
                line,
                lineColor,
                skinColor
            }
            public struct SkinPosParam
            {
                public BaseData.RectROIMove roi;        //检测位置
                public SkinPosMethod method;            //检测方法
                public double dSkinAreaRatioMin;        //绝缘皮面积最小占比
                public double dSkinAreaRatioMax;        //绝缘皮面积最大占比
                public bool bSkinAllOK;                 //全绝缘皮OK
                public int nMinLineArea;                //最小线芯面积
                public BaseData.ThdParam lineThd;       //芯线阈值
                public ColorData colorData;             //颜色空间参数
                public int nMinColorArea;               //最小颜色面积
            }
            public struct SkinPosResult
            {
                public Rect2 skinPosROI;
                public double dSkinWidthRatio;
                public double dLineArea;
            }
            #endregion

            #region 铜丝露出
            [Serializable]
            public struct LinePosParam
            {
                public LinePosParam()
                {
                    bColorSpace = false;
                    ScaleImage.bFlag = false;
                    bDiameter = false;
                }
                public BaseData.RectROIMove roi;           //检测框
                public LinePosMethod method;               //检测方法：是否根据颜色进行检测？针对线芯是铜的情况
                public BaseData.ValueRange LenRatio;       //芯线长度比
                public BaseData.ValueRange ContRatio;      //芯线轮廓比
                public BaseData.ValueRange Area;           //面积取值范围
                public bool bColorSpace { get; set; }      //是否使用颜色空间转换
                public ColorSpaceTransParam colorSpace;    //颜色空间转换参数
                public BaseData.ValueRange ScaleImage;     //图像灰度拉伸
                public ThdParam thd;                       //阈值分割参数
                public int nMinArea;                       //阈值分割方法时，单根芯线最小面积
                public bool bDiameter { get; set; }        //是否使用芯线直径作为筛选调节
                public double dLineDiam;                   //阈值分割方法时，单根芯线最大直径
            }
            public struct LinePosResult
            {
                public double dLenRatio;       //芯线与检测框的宽度比
                public double dContRatio;      //芯线与检测框的宽度比
                public double dArea;           //芯线的面积
            }
            #endregion
        }


        public class SingleTM
        {
            //端子预处理参数
            [Serializable]
            public struct TMParam
            {
                public bool bAI;                       //是否使用深度学习模型
                [JsonIgnore]
                public object nModelID;                //模板ID号
                public double dScore;                  //匹配分数
                public Rect2 LineWeldROI;              //创建模板时绘制的线芯压脚区域，用于定位
                public LocateOutParams model_center;   //模板的中心点
                public TMCheckList checkList;          //检测项目列表
                public TM.SkinWeldParam skinWeld;         //绝缘皮压脚参数
                public SkinPosParam skinPos;           //绝缘皮位置参数
                public LineWeldParam lineWeld;         //线芯压脚检测参数
                public LineOnWeldParam lineOnWeld;     //露铜芯检测参数
                public LineSideParam lineSide;         //芯线两侧飞边检测
                public LinePosParam linePos;           //芯线位置检测
                public TMNoseParam tmNose;             //端子鼻检测
                public TMheadParam tmhead;             //端子头检测
                public LineColorParam lineColor;       //线序检测
            }

            public struct TMResult
            {
                public TM.SkinWeldResult skinWeldResult;
                public SkinPosResult skinPosResult;
                public LineWeldResult lineWeldResult;
                public LineOnWeldResult lineOnWeldResult;
                public LinePosResult linePosResult;
                public LineSideResult lineSideResult;
                public TMNoseResult tmNoseResult;
                public TMheadResult tmheadResult;
                public LineColorResult lineColorResult;
                public Dictionary<string, string> outcome;
            }

            #region 线芯压脚参数
            [Serializable]
            public struct LineWeldParam
            {
                public int nMidGap;             //中分值
                public double dAreaRatioMin;    //面积比最小值
                public double dAreaRatioMax;    //面积比最大值
                public double dDislocation;     //两瓣铆压错位值
            }
            public struct LineWeldResult
            {
                public double[] arrayAreaRatio;
                public double dDislocation;
                public double dGrayDiff;
                public bool bFlag;
            }
            #endregion

            #region 压脚上方飞丝参数
            public struct LineOnWeldParam
            {
                public double[] dStandDev;          //检测区域方差标准值 
                public double[] dDev;               //检测区域的方差
                                                    //public double dStandMeanGray;     //检测区域平均灰度标准值
                                                    //public double dMeanGray;
                public int nStandThd;             //检测区域阈值标准值
                public int nThd;                   //认为有铜的最小阈值
                public bool bthd0;//从0开始
                public int area;//最小面积
            }
            public struct LineOnWeldResult
            {
                public bool bResult;               //检测结果
                public int nThd;                   //自动阈值返回的阈值
                                                   //  public double dMeanGray;           //线芯压脚检测区域的平均灰度
                public double[] dDeviation;          //线芯压脚检测区域的方差
                public int area;

            }
            #endregion

            #region 芯线位置检测
            [Serializable]
            public enum LinePosMethod
            {
                thd,       //阈值分割
                cont,      //轮廓度
            }

            [Serializable]
            public struct BackGround
            {
                public int nThd;                  //阈值:从0到nThd
                public double dWRatioMin;              //芯线到左边线的最小距离
                public double dWRatioMax;              //芯线到左边线的最大距离
            }

            [Serializable]
            public struct LineColorTM
            {
                public ColorSpaceTransParam colorSpace;//颜色空间
                public bool bThd0X;               //静态阈值取值范围
                public int nThd;                  //静态阈值
                public double dDistMin;           //芯线与检测框的宽度比最小值
                public double dDistMax;           //芯线与检测框的宽度比最大值
                public int minarea;   //最小面积
            }
            [Serializable]
            public struct LineOutline
            {

                public double dDistMin;           //芯线轮廓最小值
                public double dDistMax;           //芯线与轮廓最大值
            }

            #endregion

            [Serializable]
            public struct LineSideParam
            {
                public List<Arbitrary> arbitrary;    //轮廓提取区域
                public int minthd;
                public int minarea;
                public bool background;   //背景颜色
            }
            [Serializable]
            public struct TMNoseParam
            {
                public int nXMove;           //端子鼻检测框中心Col
                public int nYMove;           //端子鼻检测框中心Row
                public int nROILen1;         //端子鼻检测框宽度
                public int nROILen2;         //端子鼻检测框高度
                public double dNoseLen;      //端子鼻长度
                public int nNoseLenLow;      //端子鼻长度下限
                public int nNoseLenHigh;     //端子鼻长度上限
                public double dAngle;        //端子鼻与端子的角度（非弧度）
                public int nAngleLow;        //端子鼻与端子的角度下限（非弧度）
                public int nAngleHigh;       //端子鼻与端子的角度上限（非弧度）
            }
            [Serializable]
            public struct TMheadParam
            {
                public int nROIWidth;              //端子头检测框宽度
                public int nROIHeight;             //端子头检测框高度
                public int nROIGap;                //端子头检测框间距
                public int nLineThd;               //亮度：静态阈值
                public int Area;   //面积
                public double AreaMin;   //面积最小占比
            }
            [Serializable]
            public struct TMNoseResult
            {
                public bool bResult;
                public double dNoseLen;
                public double dAngle;
            }
            [Serializable]
            public struct TMheadResult
            {
                public bool bResult;
                public int dArea;
            }
            [Serializable]
            public struct LineSideResult
            {
                public bool bResult;
            }
        }

        public class MultiTM
        {
            [Serializable]
            public struct MultiTMParam
            {
                public TMCheckList checkList;          //检测项目列表
                public int nTMNum;                     //端子个数
                public bool bBackgroundDark;           //背景黑还是白
                public int nTMGap;                     //端子间距
                public double dScore;                  //匹配分数
                public object nModelID;                //模板ID
                #region 设置来料基准位置
                public bool bBaseLine;                 //是否设定顶点为基准线
                public BaseData.Line baseLine;         //端子顶点基准线
                public int nPosOffset;
                #endregion
                public bool bLoaction;                 //是否设定限制检测区域
                public List<Rect2> listRect2ROI;        //限定的图像检测区域
                public List<Rect2> weldlistRect2ROI;

                #region 绝缘皮压脚位置
                public Rect2 skinWeldROI;               //绝缘皮压脚检测区域
                public int nBackThd;                   //背景灰度值
                public int nSkinWeldArea;              //绝缘皮压脚区域最小面积
                #endregion
                public bool bSetROI;                    //是否设定检测区域
                public bool bweldetROI;                 //是否限定线芯压脚匹配区域
                public bool bLineWeldLocate;            //是否使用线芯压脚定位
                public Rect2 tmRect2;                  //模板端子的大小
                public ROIS roi;                       //各检测区域大小
                public TM.SkinWeldParam skinWeld;         //绝缘皮压脚参数
                public TM.SkinPosParam skinPos;           //绝缘皮位置参数
                public ThdParam LineWeldThd;           //线芯压脚参数     
                public double dLineCoreWeldRatioMin;   //线芯压脚白色金属与检测区域面积比
                public double dLineCoreWeldRatioMax;
                public TM.LinePosParam linePos;
                public LineSideParam lineSide;         //芯线翘出
                public WaterproofParam waterproof;     //防水栓
                public LineColorParam lineColor;       //线序检测参数
                public DistortParam distort;          //歪曲检测
            }
            public struct DistortParam
            {
                public Rect2 DisRect2;
                public int _Thd;
                public int _iHeight;
                public double _hightDow;
                public double _hightUp;
                public double _wightDow;
                public double _wightUp;
                public double _phiDow;
                public double _phiUp;
            }
            public struct MultiResult
            {
                public MultiResult()
                {
                    baseLine = new BaseData.Line();
                    listSkinWeldResults = new List<SkinWeldResult>();
                    listSkinPosResults = new List<SkinPosResult>();
                    linePosResults = new List<LinePosResult>();
                }
                public bool bResult;
                public BaseData.Line baseLine { get; set; }
                public List<SkinWeldResult> listSkinWeldResults { get; set; }
                public List<SkinPosResult> listSkinPosResults { get; set; }

                public double[] dLineWeldRatio;
                public List<LinePosResult> linePosResults { get; set; }
                public double[] dLinePosLineRatio;
                public bool[] bLineSide;
                public double[] dWaterproofW;
                public LineColorResult lineColorResult;
                public List<Rect2> listTMRect2;
                public List<Rect2> listLineWeldRect2;
                public DistortResult distortResult;
            }
            public struct DistortResult
            {
                public List<double> dHight;
                public List<double> dWidth;
                public List<double> dPhi;
            }

            [Serializable]
            public struct SkinPosParam
            {
                public int nMethod;                 //1：根据芯线亮度 2：根据芯线颜色 3：根据胶皮颜色
                public LineColorParam colorParam;   //当使用方法3时
                public bool bAutoThd;               //true：自动阈值 false：静态阈值
                public int nColorThd;               //静态阈值
                public double dSkinPosRatioMin;     //绝缘皮与整个检测区域的面积比：最小值
                public double dSkinPosRatioMax;     //绝缘皮与整个检测区域的面积比：最大值
                public double dSkinPosLineAreaMin;  //芯线的面积最小值
                public double dSkinPosLineAreaMax;  //芯线的面积最大值
                public double dLineRatioMin;       //芯线长度比最小值
                public double dLineRatioMax;       //芯线长度比最大值
            }
            public struct SkinPosResult
            {
                public double[] arraySkinRatio;     //绝缘皮面积比
                public double[] arrayLineArea;      //芯线面积
                public double[] arrayLineRatio;     //芯线高度占比
                public int nColorThd;
            }
            [Serializable]
            public struct LinePosParam
            {
                public bool bColor;          //true:根据颜色进行检测   false:根据芯线进行检测
                public bool bAreaRatio;      //true:根据面积比进行判别 false:根据宽度比进行判别
                public double dRatioMin;     //比值最小值
                public double dRatioMax;     //比值最大值
                                             //public bool thd0;
                                             //public int iMean;
                public bool bmethod;         //true:根据轮廓比进行判别 false:根据轮廓比进行判别
                public ThdParam thd;         //阈值
                public int nOpenCircle;      //开运算
                public int nMinArea;         //最小面积
            }
            [Serializable]
            public struct LineSideParam
            {
                public int nGap;        //检测区域：与芯线压脚的间距
                public int nWidth;      //检测区域的宽度
                public int nHeight;     //检测区域侧面的高度
                public int nDownExt;    //检测区域的角度
                public int minthd;
                public int minarea;
            }

            #region 防水栓参数
            public struct WaterproofParam
            {
                public double dGap;       //ROI中心点
                public double dWidth;     //ROI宽度
                public double dHeight;    //ROI高度
                public int nScaleMin;     //图像拉伸Min
                public int nScaleMax;     //图像拉伸Max
                public double dLen1;      //防水栓宽度
                public double dLen1High;  //防水栓宽度上限
                public double dLen1Low;   //防水栓宽度下限
            }
            #endregion

            public struct ROIS
            {
                public Rect2 TMROI;          //示教时，在主窗体图像上画的矩形2
                public Rect2 skinWeld;       //示教时，在示教界面窗体上画的绝缘皮压脚检测框
                public Rect2 skinPos;        //示教时，在示教界面窗体上画的绝缘皮位置检测框   
                public Rect2 lineCoreWeld;   //示教时，在示教界面窗体上画的线芯压脚检测框
                public Rect2 lineCorePos;    //示教时，在示教界面窗体上画的线芯位置检测框
                public Rect2 lineCoreOut;    //示教时，在示教界面窗体上画的线芯飞边脚检测框
                public double dGapSkin()
                {
                    double gap = skinWeld.dRect2Row - skinPos.dRect2Row - skinWeld.dLength2 - skinPos.dLength2;
                    return gap;
                }
                public double dGapSkin_Line()
                {
                    double gap = skinPos.dRect2Row - lineCoreWeld.dRect2Row - skinPos.dLength2 - lineCoreWeld.dLength2;
                    return gap;
                }
                public double dGapLine()
                {
                    double gap = lineCoreWeld.dRect2Row - lineCorePos.dRect2Row - lineCorePos.dLength2 - lineCoreWeld.dLength2;
                    return gap;
                }
                public double dGapWaterproof;
            }
        }

    }
}
