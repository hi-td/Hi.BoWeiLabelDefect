using BaseData;
using EnumData;
using GlobalPath;
using HalconDotNet;
using Hi.Ltd;
using OpenCvSharp;
using PP_OCR;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Circle = BaseData.Circle;
using Ellipse = BaseData.Ellipse;
using Line = BaseData.Line;

namespace VisionPlatform
{
    public class Function
    {
        public HWindow m_hWnd = null;
        public HObject HImage { get => m_hImage; }
        public HWindow HWnd { get => m_hWnd; set => m_hWnd = value; }
        public HWindowControl m_hWndCtrl = null;
        public HWindowControl HWndCtrl { get => m_hWndCtrl; set => m_hWndCtrl = value; }
        public HObject m_OrgImage = null;
        public HObject m_hImage = null;
        public HObject m_GrayImage = null;
        public HObject ho_Reduceimage = null;
        public static int imageWidth;
        public static int imageHeight;
        public static RichTextBox m_richTextBox = null;
        public BaseData.Line m_line = new Line();
        public Circle m_circle = new Circle();
        public Rect1 m_rect1 = new Rect1();
        public Rect2 m_rect2 = new Rect2();
        public Ellipse m_ellipse = new Ellipse();
        public Arbitrary m_arbitrary = new Arbitrary();
        public ObjDraw m_lastDraw = new ObjDraw();  //最后一次绘制的形状
        private static HObject m_ObjShow = new HObject();              //随窗体大小变化显示Object
        public int m_nPreFontSize = 15;
        public List<int> m_listFontSize = new List<int> { 15 };        //图像窗口显示的字体大小
        public List<int> m_listRowSite = new List<int> { 12 };
        public List<int> m_listColSite = new List<int> { 12 };
        public List<string> m_listStrshow = new List<string> { "" };
        public List<string> m_listColorFont = new List<string> { "red" };
        public string m_colorRegion = "red";
        private HObject m_XLDCont = new HObject();          //使用轮廓创建模板时使用
        public bool b_image = false;
        public List<Mirror> m_ListImgMirror = new List<Mirror>();
        public double dReslutRow0 = 0;
        public double dReslutCol0 = 0;
        public double dReslutRow1 = 0;
        public double dReslutCol1 = 0;

        public Mat AIimage = new Mat();
        public Mat MOAIimage = new Mat();
        private Mat image_gray = new Mat();
        public static PP_OCRv4 pP_OCRv4 = new PP_OCRv4();

        public static void InitSystem()
        {
            try
            {
                HOperatorSet.SetSystem("tsp_width", 3000);
                HOperatorSet.SetSystem("tsp_height", 3000);
                HOperatorSet.SetSystem("do_low_error", "false");//少报错
                HOperatorSet.SetSystem("clip_region", "false");//region在图像外不切掉
                HOperatorSet.SetSystem("border_shape_models", "true");//依然匹配边缘的图形
            }
            catch (Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        public Function()
        {
            //InitSystem();
        }
        ~Function()
        {
            GC.Collect();
        }

        #region 图像格式转化
        public Mat HObjectToMat(HObject ho_Img)
        {
            Mat dst = new Mat();
            HTuple hv_type = new HTuple(), hv_width = new HTuple(), hv_height = new HTuple();
            try
            {
                HOperatorSet.CountChannels(ho_Img, out HTuple hv_Channels);
                //if (hv_Channels.Length == 0)
                //    return dst;
                if (hv_Channels[0].I == 1)
                {
                    HTuple hv_Pointer = null;
                    IntPtr intPtr = IntPtr.Zero;
                    HOperatorSet.GetImagePointer1(ho_Img, out hv_Pointer, out hv_type, out hv_width, out hv_height);
                    intPtr = hv_Pointer;
                    dst = Mat.FromPixelData(hv_width, hv_height, MatType.CV_8UC1, intPtr);
                }
                else if (hv_Channels[0].I == 3)
                {
                    HTuple hv_ptrRed = null;
                    HTuple hv_ptrGreen = null;
                    HTuple hv_ptrBlue = null;
                    IntPtr ptrRed = IntPtr.Zero;
                    IntPtr ptrGreen = IntPtr.Zero;
                    IntPtr ptrBlue = IntPtr.Zero;
                    HOperatorSet.GetImagePointer3(ho_Img, out hv_ptrRed, out hv_ptrGreen, out hv_ptrBlue, out hv_type, out hv_width, out hv_height);
                    ptrRed = hv_ptrRed;
                    ptrGreen = hv_ptrGreen;
                    ptrBlue = hv_ptrBlue;
                    // 分别生成3张图片
                    Mat matRed = new Mat();
                    Mat matGreen = new Mat();
                    Mat matBlue = new Mat();
                    matRed = Mat.FromPixelData(hv_height, hv_width, MatType.CV_8UC1, ptrRed);
                    matGreen = Mat.FromPixelData(hv_height, hv_width, MatType.CV_8UC1, ptrGreen);
                    matBlue = Mat.FromPixelData(hv_height, hv_width, MatType.CV_8UC1, ptrBlue);
                    // 合成
                    Mat[] multi = new Mat[] { matBlue, matGreen, matRed };
                    Cv2.Merge(multi, dst);
                    matBlue.Dispose();
                    matGreen.Dispose();
                    matRed.Dispose();
                }
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"HObjectToMat:{ex}", true);
            }
            return dst;
        }
        #endregion
        //保存图片
        public void SaveImage(string strSavePath, bool bOK = true, string sCode = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strSavePath))
                    return;
                var folder = System.IO.Path.GetDirectoryName(strSavePath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string str = strSavePath + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".");
                if (sCode != "")
                {
                    str = strSavePath + (sCode + DateTime.Now).ToString().Replace("/", ".").Replace(":", ".");
                }
                str = str.Replace("\\", "/");
                if (null != m_hImage)
                {
                    if (bOK)
                    {
                        HOperatorSet.WriteImage(m_hImage, "jpg", 0, str);
                    }
                    else
                    {
                        HOperatorSet.WriteImage(m_hImage, "bmp", 0, str);
                    }

                }
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return;
            }


        }
        #region 运行中保存原始图像和结果图像

        public void SaveRunImage(bool bResult, int cam, string strCheckItem, string sCode)
        {
            if (bResult)
            {
                SaveOKImage(cam, strCheckItem, sCode);
            }
            else
            {
                SaveNGImage(cam, strCheckItem, sCode);
            }
        }

        public void SaveOKImage(int cam, string strCheckItem, string sCode = "")
        {
            try
            {
                string strDate = DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.Hour.ToString() + "\\";
                string orgImageFath = SavePath.ImageFold + $"\\相机{cam}\\原始图像\\OK\\{strCheckItem}\\{strDate}";
                string resImageFath = SavePath.ImageFold + $"\\相机{cam}\\结果图像\\OK\\{strCheckItem}\\{strDate}";
                //保存原始OK图
                if (GlobalData.Config._InitConfig.otherConfig.bOrgOK)
                {
                    SaveImage(orgImageFath, true, sCode);
                }
                //保存结果OK图
                if (GlobalData.Config._InitConfig.otherConfig.bResultOK)
                {
                    SaveResultImage(resImageFath, sCode);
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"OK图像保存出错：{ex}", true, strEnglish: $"OK Image Save Error:{ex}");
                return;
            }
        }

        public void SaveNGImage(int cam, string strCheckItem, string sCode)
        {
            try
            {
                string strDate = DateTime.Now.ToString("yyyy-MM-dd") + "\\" + DateTime.Now.Hour.ToString() + "\\";
                string orgImageFath = SavePath.ImageFold + $"\\相机{cam}\\原始图像\\NG\\{strCheckItem}\\{strDate}";
                string resImageFath = SavePath.ImageFold + $"\\相机{cam}\\结果图像\\NG\\{strCheckItem}\\{strDate}";
                //保存原始NG图
                if (GlobalData.Config._InitConfig.otherConfig.bOrgNG)
                {
                    SaveImage(orgImageFath, false, sCode);
                }
                //保存结果NG图
                if (GlobalData.Config._InitConfig.otherConfig.bResultNG)
                {
                    SaveResultImage(resImageFath, sCode);
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"NG图像保存出错：{ex}", true, strEnglish: $"NG Image Save Error:{ex}");
                return;
            }
        }

        #endregion

        public void SaveModelImage(int cam, string strImageName)
        {
            try
            {
                string strSavePath = "";
                int ten = Tools.SplitInt(cam, out int unit);
                string strSend = "";
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    strSavePath = GlobalPath.SavePath.ModelImagePath + "Camera" + ten.ToString();
                    if (unit != 0)
                    {
                        strSavePath = strSavePath + "_" + unit;
                    }
                }
                else
                {
                    strSavePath = GlobalPath.SavePath.ModelImagePath + "相机" + ten.ToString();
                    if (unit != 0)
                    {
                        strSavePath = strSavePath + "_" + unit;
                    }
                }
                //strSavePath = GlobalPath.SavePath.ModelImagePath + "Camera" + ten.ToString();
                //if (unit != 0)
                //{
                //    strSavePath = strSavePath + "_" + unit;
                //}
                strSavePath = strSavePath + "\\";
                if (string.IsNullOrWhiteSpace(strSavePath))
                    return;
                var folder = System.IO.Path.GetDirectoryName(strSavePath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                strSavePath = strSavePath + strImageName;//不能包含中文
                string str = strSavePath.Replace("\\", "/");
                if (null != m_hImage)
                {
                    HOperatorSet.WriteImage(m_hImage, "bmp", 0, str);
                }
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return;
            }
        }
        public void SaveImageWithoutDate(string strSavePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strSavePath))
                    return;
                var folder = System.IO.Path.GetDirectoryName(strSavePath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                //string str = strSavePath + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".");
                string str = strSavePath.Replace("\\", "/");
                if (null != m_hImage)
                {
                    HOperatorSet.WriteImage(m_hImage, "bmp", 0, str);
                }
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return;
            }


        }
        #region 从相机获取图像
        public void MirrorImage(ref HObject ho_Image)
        {
            try
            {
                if (null == m_ListImgMirror)
                {
                    return;
                }
                foreach (Mirror mir in m_ListImgMirror)
                {
                    if (mir == Mirror.Left_Right)
                    {
                        HOperatorSet.MirrorImage(ho_Image, out ho_Image, "column");
                    }
                    else if (mir == Mirror.Up_Down)
                    {
                        HOperatorSet.MirrorImage(ho_Image, out ho_Image, "row");
                    }
                }
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("镜像图像错误：" + ex.ToString(), true, strEnglish: "Mirror image error:" + ex.ToString());
            }
        }

        public bool mirrorLoR = false;
        public bool mirrorUoD = false;
        public static bool m_bShowCross;
        //适用于大恒、海康威视
        public void GetImageFromCam(CamColor channel, IntPtr pImageBuf, int nWidth, int nHeight, string Selector)
        {
            HOperatorSet.GenEmptyObj(out HObject image);
            try
            {
                if (channel == CamColor.color)
                {
                    HOperatorSet.GenImageInterleaved(out image, (HTuple)pImageBuf, (HTuple)Selector, nWidth, nHeight, -1, "byte", 0, 0, 0, 0, -1, 0);
                    // 创建Mat对象
                    AIimage = Mat.FromPixelData(nHeight, nWidth, MatType.CV_8UC3, pImageBuf);
                }
                else if (channel == CamColor.mono)
                {
                    HOperatorSet.GenImage1Extern(out image, "byte", nWidth, nHeight, pImageBuf, IntPtr.Zero);
                    // 创建Mat对象
                    image_gray = Mat.FromPixelData(nHeight, nWidth, MatType.CV_8UC1, pImageBuf);
                    // 将图片转为3通道
                    Cv2.CvtColor(image_gray, AIimage, ColorConversionCodes.GRAY2BGR);
                }
                else
                {
                    return;
                }
                m_hImage = image.Clone();
                if (mirrorLoR)
                {
                    HOperatorSet.MirrorImage(m_hImage, out m_hImage, "column");
                }
                if (mirrorUoD)
                {
                    HOperatorSet.MirrorImage(m_hImage, out m_hImage, "row");
                }
                HOperatorSet.Rgb1ToGray(m_hImage, out m_GrayImage);
                if (m_bShowCross)
                {
                    ShowCenterCross();
                }
                // m_PreImage = m_hImage.Clone();   //示教使用
                // ColorSpaceTrans();
                b_image = true;
                FitImageToWindow(ref dReslutRow0, ref dReslutCol0, ref dReslutRow1, ref dReslutCol1);
                return;

            }
            catch (System.Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                (ex.Message + ex.StackTrace).Log();
            }
            finally
            {
                image.Dispose();
            }
        }

        //适用于大华相机
        public void Bitmap2HObject(Bitmap bitmap, bool m_bTrig)
        {
            // double dReslutRow0 = 0, dReslutCol0 = 0, dReslutRow1 = 0, dReslutCol1 = 0;

            HTuple hv_Channels = new HTuple();
            try
            {
                Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                IntPtr intPtr = bitmapData.Scan0;
                b_image = false;
                //m_hImage?.Dispose();
                HOperatorSet.GenEmptyObj(out m_hImage);
                HOperatorSet.GenImageInterleaved(out m_hImage, intPtr, "bgrx", bitmap.Width, bitmap.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                HOperatorSet.CountChannels(m_hImage, out hv_Channels);

                {
                    HOperatorSet.Rgb1ToGray(m_hImage, out m_hImage);
                    //HTuple hv_Gray = new HTuple(); 
                    //HOperatorSet.GetGrayval(m_hImage, 12, 12, out hv_Gray);
                    HOperatorSet.ConvertImageType(m_hImage, out m_hImage, "byte");
                }
                b_image = true;
                if (!m_bTrig)
                {
                    //list集合保存图片
                    //  m_listImage.Add(m_hImage);
                }
                FitImageToWindow(ref dReslutRow0, ref dReslutCol0, ref dReslutRow1, ref dReslutCol1);
                bitmap.UnlockBits(bitmapData);

            }
            catch (SystemException ex)
            {
                (ex.Message + ex.StackTrace).Log();
                ex.ToString();
                return;
            }
        }

        #endregion

        //获取主界面最后一次绘制的图形
        public HObject GetLastDrawObj(ObjDraw lastDraw)
        {
            HObject ho_region = null;

            HOperatorSet.GenEmptyObj(out ho_region);
            try
            {
                switch (lastDraw)
                {
                    case ObjDraw.line:
                        HOperatorSet.GenRegionLine(out ho_region, m_line.dStartRow, m_line.dStartCol, m_line.dEndRow, m_line.dEndCol);
                        break;
                    case ObjDraw.rect1:
                        HOperatorSet.GenRectangle1(out ho_region, m_rect1.dRectRow1, m_rect1.dRectCol1, m_rect1.dRectRow2, m_rect1.dRectCol2);
                        break;
                    case ObjDraw.rect2:
                        HOperatorSet.GenRectangle2(out ho_region, m_rect2.dRect2Row, m_rect2.dRect2Col, m_rect2.dPhi, m_rect2.dLength1, m_rect2.dLength2);
                        break;
                    case ObjDraw.circle:
                        HOperatorSet.GenCircle(out ho_region, m_circle.dRow, m_circle.dCol, m_circle.dRadius);
                        break;
                    case ObjDraw.ellipse:
                        HOperatorSet.GenEllipse(out ho_region, m_ellipse.dRow, m_ellipse.dColumn, m_ellipse.dPhi, m_ellipse.dRadius1, m_ellipse.dRadius2);
                        break;
                    default:
                        break;
                }
                m_hWnd.DispObj(ho_region);
                m_ObjShow = m_ObjShow.ConcatObj(ho_region);
                return ho_region;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return ho_region;
            }
            finally
            {
                //if (null != ho_region) ho_region.Dispose();
            }
        }

        public Rect2 MoveRect2ROI(Rect2 OrgRect2, BaseData.RectROIMove roi, bool bShow = false)
        {
            Rect2 newRect2 = new Rect2();
            HOperatorSet.GenEmptyObj(out HObject ho_OrgRect2);
            try
            {
                double dx = Math.Cos(OrgRect2.dPhi) * roi.nXMove;
                double dy = Math.Sin(OrgRect2.dPhi) * roi.nXMove;
                double drow = OrgRect2.dRect2Row - dy;
                double dcol = OrgRect2.dRect2Col + dx;
                dx = Math.Sin(OrgRect2.dPhi) * roi.nYMove;
                dy = Math.Cos(OrgRect2.dPhi) * roi.nYMove;
                drow = drow + dy;
                dcol = dcol + dx;
                newRect2 = new Rect2(drow, dcol, OrgRect2.dPhi, roi.nWidth, roi.nHeight);
                Rect2Trans(ref newRect2);
                ho_OrgRect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_OrgRect2, drow, dcol, OrgRect2.dPhi, roi.nWidth, roi.nHeight);
                if (bShow) DispRegion(ho_OrgRect2);

            }
            catch (HalconException error)
            {
                StaticFun.MessageFun.ShowMessage(error, true);
            }
            finally
            {
                ho_OrgRect2?.Dispose();
            }
            return newRect2;
        }

        #region 工具函数
        public void DispRegion(HObject obj, string strColor = "green", string draw = "margin", int lineWidth = 1)
        {
            if (null == obj || obj.CountObj() == 0) return;
            var run = Task.Run(() =>
            {
                try
                {
                    //HOperatorSet.RegionFeatures(obj, "area", out HTuple hv_area);
                    //if (hv_area.TupleLength() == 0) return;
                    m_hWnd.SetColor(strColor);
                    m_hWnd.SetDraw(draw);
                    m_hWnd.SetLineWidth(lineWidth);
                    m_hWnd.DispObj(obj);
                }
                catch (Exception ex)
                {
                }
            });
            run.Wait();
            m_hWnd.SetColor("green");
            m_hWnd.SetDraw("margin");
            m_hWnd.SetLineWidth(1);
        }
        //清除m_ObjShow
        public void ClearObjShow()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    m_listFontSize.Clear();
                    m_listRowSite.Clear();
                    m_listColorFont.Clear();
                    m_listColSite.Clear();
                    m_listStrshow.Clear();
                    //m_ObjShow?.Dispose();
                    //HOperatorSet.GenEmptyObj(out m_ObjShow);
                    HOperatorSet.ClearWindow(m_hWnd);
                    if (null != m_hImage)
                        m_hWnd.DispObj(m_hImage);
                });
                task.Wait();

            }
            catch (Exception)
            {
                return;
            }

        }

        ////获取WindowControl的句柄
        //public static void GetHalconWnd(HWindowControl hWndCtrl)
        //{
        //    m_hWnd = hWndCtrl.HalconWindow;
        //    m_hWndCtrl = hWndCtrl;
        //}

        //获取鼠标按下时的图像坐标
        public System.Drawing.Point GetMousePos()
        {
            System.Drawing.Point point = new System.Drawing.Point();
            int row, col, button;
            try
            {
                m_hWnd.GetMposition(out row, out col, out button);
                point.X = col;
                point.Y = row;
                return point;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                return point;
            }


        }
        //画矩形1

        public void ShowCenterCross()
        {
            HOperatorSet.GenEmptyObj(out HObject ho_cross);
            try
            {
                if (null == m_hImage) return;
                HOperatorSet.GetImageSize(m_hImage, out HTuple hv_width, out HTuple hv_height);
                ho_cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_cross, hv_height / 2.0, hv_width / 2.0, hv_width * 1.1, 0);
                DispRegion(ho_cross);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_cross?.Dispose();
            }
        }
        #region 按窗口比例显示图像
        public void FitImageToWindow(ref double dReslutRow0, ref double dReslutCol0, ref double dReslutRow1, ref double dReslutCol1)
        {
            HTuple hv_width = null, hv_height = null;
            try
            {
                if (dReslutRow0 == 0 && dReslutCol0 == 0 && dReslutRow1 == 0 && dReslutCol1 == 0)
                {
                    if (m_hImage != null)
                    {
                        HOperatorSet.GetImageSize(m_hImage, out hv_width, out hv_height);
                    }
                    else
                    {
                        return;
                    }
                    double dRow0 = 0, dCol0 = 0, dRow1 = hv_height.D - 1, dCol1 = hv_width.D - 1;
                    if (hv_height != null && hv_width != null)
                    {
                        float fImage = (float)hv_width / (float)hv_height;
                        float fWindow = (float)m_hWndCtrl.Width / m_hWndCtrl.Height;
                        if (fWindow > fImage)
                        {
                            float w = fWindow * (float)hv_height;
                            dRow0 = 0;
                            dCol0 = -(w - hv_width) / 2;
                            dRow1 = hv_height - 1;
                            dCol1 = hv_width + (w - hv_width) / 2;
                        }
                        else
                        {
                            float h = (float)hv_width / fWindow;
                            dRow0 = -(h - hv_height) / 2;
                            dCol0 = 0;
                            dRow1 = hv_height + (h - hv_height) / 2;
                            dCol1 = hv_width.D - 1;
                        }
                    }
                    dReslutRow0 = dRow0;
                    dReslutCol0 = dCol0;
                    dReslutRow1 = dRow1;
                    dReslutCol1 = dCol1;

                    imageWidth = hv_width.I;
                    imageHeight = hv_height.I;
                }
                ShowImages(dReslutRow0, dReslutCol0, dReslutRow1, dReslutCol1);
            }
            catch (System.Exception ex)
            {
                ex.ToString();
                return;
            }


        }
        public void FitImageToWindow1(HObject ho_Image, ref double dReslutRow0, ref double dReslutCol0, ref double dReslutRow1, ref double dReslutCol1)
        {
            HTuple m_hWidth = null, m_hHeight = null;
            try
            {
                if (dReslutRow0 == 0 && dReslutCol0 == 0 && dReslutRow1 == 0 && dReslutCol1 == 0)
                {
                    if (ho_Image != null)
                    {
                        HOperatorSet.GetImageSize(ho_Image, out m_hWidth, out m_hHeight);
                    }
                    else
                    {
                        return;
                    }
                    if (0 == m_hHeight.Length)
                    {
                        return;
                    }
                    double dRow0 = 0, dCol0 = 0, dRow1 = m_hHeight.D - 1, dCol1 = m_hWidth.D - 1;
                    if (m_hHeight != null && m_hWidth != null)
                    {
                        float fImage = (float)m_hWidth / (float)m_hHeight;
                        if (m_hWndCtrl.Width != 0 && m_hWndCtrl.Height != 0)
                        {
                            float fWindow = (float)m_hWndCtrl.Width / m_hWndCtrl.Height;

                            if (fWindow > fImage)
                            {
                                float w = fWindow * (float)m_hHeight;
                                dRow0 = 0;
                                dCol0 = -(w - m_hWidth) / 2;
                                dRow1 = m_hHeight - 1;
                                dCol1 = m_hWidth + (w - m_hWidth) / 2;
                            }
                            else
                            {
                                float h = (float)m_hWidth / fWindow;
                                dRow0 = -(h - m_hHeight) / 2;
                                dCol0 = 0;
                                dRow1 = m_hHeight + (h - m_hHeight) / 2;
                                dCol1 = m_hWidth.D - 1;
                            }
                        }
                    }
                    dReslutRow0 = dRow0;
                    dReslutCol0 = dCol0;
                    dReslutRow1 = dRow1;
                    dReslutCol1 = dCol1;

                    //imageWidth = m_hWidth.I;
                    //imageHeight = m_hHeight.I;
                }
                HOperatorSet.SetSystem("flush_graphic", "false");
                HOperatorSet.ClearWindow(m_hWnd);
                if (ho_Image != null)
                {
                    HOperatorSet.SetPart(m_hWnd, dReslutRow0, dReslutCol0, dReslutRow1 - 1, dReslutCol1 - 1);
                    m_hWnd.DispObj(ho_Image);
                }
                ShowRegions();
                WriteStringtoImage_zoom();
                HOperatorSet.SetSystem("flush_graphic", "true");
                HObject emptyObject = null;
                HOperatorSet.GenEmptyObj(out emptyObject);
                m_hWnd.DispObj(emptyObject);
            }
            catch (System.Exception ex)
            {
                ex.ToString();
                return;
            }
        }
        public void ReadImageToHWnd(string strPath, HWindowControl hWndCtrl)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Image);
            try
            {
                ho_Image.Dispose();
                HOperatorSet.ReadImage(out ho_Image, strPath);
                ShowImageToHWnd(ho_Image, hWndCtrl);
            }
            catch (HalconException ex)
            {
                return;
            }
        }
        public void ShowImageToHWnd(HObject ho_Image, HWindowControl hWndCtrl)
        {
            HTuple hv_Width = null, hv_Height = null;

            try
            {
                if (ho_Image == null) return;
                HWindow hWnd = hWndCtrl.HalconWindow;
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                if (0 == hv_Height.Length)
                {
                    return;
                }
                double dRow0 = 0, dCol0 = 0, dRow1 = hv_Height.D - 1, dCol1 = hv_Width.D - 1;
                if (hv_Height != null && hv_Width != null)
                {
                    float fImage = (float)hv_Width / (float)hv_Height;
                    if (hWndCtrl.Width != 0 && hWndCtrl.Height != 0)
                    {
                        float fWindow = (float)hWndCtrl.Width / hWndCtrl.Height;
                        if (fWindow > fImage)
                        {
                            float w = fWindow * (float)hv_Height;
                            dRow0 = 0;
                            dCol0 = -(w - hv_Width) / 2;
                            dRow1 = hv_Height - 1;
                            dCol1 = hv_Width + (w - hv_Width) / 2;
                        }
                        else
                        {
                            float h = (float)hv_Width / fWindow;
                            dRow0 = -(h - hv_Height) / 2;
                            dCol0 = 0;
                            dRow1 = hv_Height + (h - hv_Height) / 2;
                            dCol1 = hv_Width.D - 1;
                        }
                    }
                }
                HOperatorSet.SetSystem("flush_graphic", "false");
                HOperatorSet.ClearWindow(hWnd);
                if (ho_Image != null)
                {
                    HOperatorSet.SetPart(hWnd, dRow0, dCol0, dRow1 - 1, dCol1 - 1);
                    hWnd.DispObj(ho_Image);
                }
                HOperatorSet.SetSystem("flush_graphic", "true");
                HOperatorSet.GenEmptyObj(out HObject emptyObject);
                hWnd.DispObj(emptyObject);
            }
            catch (System.Exception ex)
            {
                return;
            }
        }
        #endregion
        private void ShowRegions()
        {
            if (m_ObjShow.IsInitialized())
            {
                m_hWnd.SetColor(m_colorRegion);
                m_hWnd.DispObj(m_ObjShow);
            }
        }
        /// <summary>
        /// 在缩放时窗体上显示字符
        /// </summary>
        public void WriteStringtoImage_zoom()
        {
            try
            {
                //设置字体大小
                for (int i = 0; i < m_listFontSize.Count; i++)
                {
                    string strFontWithSize = "Arial-Normal-" + m_listFontSize[i];
                    m_hWnd.SetFont(strFontWithSize);
                    //设置字体显示的位置
                    m_hWnd.SetTposition(m_listRowSite[i], m_listColSite[i]);
                    //字体内容
                    m_hWnd.SetColor(m_listColorFont[i]);
                    m_hWnd.WriteString(m_listStrshow[i]);
                }
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
            }
            return;
        }
        //画圆形
        public Circle DrawCircle()
        {
            Circle circle = new Circle();

            HObject ho_Circle = null;
            HOperatorSet.GenEmptyObj(out ho_Circle);

            HTuple hv_Row = new HTuple(), hv_Col = new HTuple(), hv_Radius = new HTuple();

            try
            {
                if (null == m_hImage || null == m_hWnd) return circle;
                m_hWnd.SetColor("red");
                m_hWnd.SetDraw("margin");
                m_hWnd.DispObj(m_hImage);
                HOperatorSet.DrawCircle(m_hWnd, out hv_Row, out hv_Col, out hv_Radius);
                HOperatorSet.GenCircle(out ho_Circle, hv_Row, hv_Col, hv_Radius);
                m_hWnd.DispObj(ho_Circle);
                if (0 != ho_Circle.CountObj())
                {
                    circle.dRow = hv_Row.D;
                    circle.dCol = hv_Col.D;
                    circle.dRadius = hv_Radius.D;
                }
                return circle;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                return circle;
            }
            finally
            {
                if (null != ho_Circle) ho_Circle.Dispose();
            }
        }

        public void ShowCircle(Circle circle)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Circle);
            try
            {
                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, circle.dRow, circle.dCol, circle.dRadius);
                DispRegion(ho_Circle, lineWidth: 2);
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
            }
            finally
            {
                ho_Circle?.Dispose();
            }
        }

        #region 任意形状
        public Arbitrary DrawArbitrary()
        {
            Arbitrary arbitrary = new Arbitrary();
            arbitrary.dListRow = new List<double>();
            arbitrary.dListCol = new List<double>();
            HTuple hv_arrayRow = new HTuple(), hv_arrayCol = new HTuple();
            HTuple hv_Button = new HTuple(), hv_row = new HTuple(), hv_column = new HTuple();

            HObject ho_Contour = null; ;

            HOperatorSet.GenEmptyObj(out ho_Contour);
            try
            {
                if (null == m_hImage || m_hWnd == null)
                {
                    if (null == m_hImage)
                        MessageFun.ShowMessage("无图像", true, strEnglish: "No image");
                    else if (null == m_hWnd)
                        MessageFun.ShowMessage("无窗体句柄", true, strEnglish: "No Windows handle");
                    return arbitrary;
                }
                m_hWnd.DispObj(m_hImage);
                m_hWnd.SetDraw("margin");
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    WriteStringtoImage(15, 12, 12, "Left click to start (continuous clicking), right click to end (clicking).", "red");
                }
                else
                {
                    WriteStringtoImage(15, 12, 12, "鼠标左键开始（连续单击），右键结束（单击）。", "red");
                }
                hv_Button = 1;
                while (hv_Button.I == 1)
                {
                    HOperatorSet.GetMbutton(m_hWnd, out hv_row, out hv_column, out hv_Button);
                    m_hWnd.SetColor("green");
                    m_hWnd.DispCross(hv_row.D, hv_column.D, 30, 0);
                    hv_arrayRow = hv_arrayRow.TupleConcat(hv_row);
                    hv_arrayCol = hv_arrayCol.TupleConcat(hv_column);
                    m_hWnd.SetColor("red");
                    m_hWnd.DispPolygon(hv_arrayRow, hv_arrayCol);
                    arbitrary.dListRow.Add(hv_row.D);
                    arbitrary.dListCol.Add(hv_column.D);
                }
                hv_arrayRow = hv_arrayRow.TupleConcat(hv_arrayRow[0]);
                hv_arrayCol = hv_arrayCol.TupleConcat(hv_arrayCol[0]);
                arbitrary.dListRow.Add(hv_arrayRow[0].D);
                arbitrary.dListCol.Add(hv_arrayCol[0].D);
                if (arbitrary.dListRow.Count <= 3)
                {
                    arbitrary = new Arbitrary();
                    MessageFun.ShowMessage("点数少于3个点，请重新绘制。", false, strEnglish: "At least 3 points needed, please redraw.");
                    return arbitrary;
                }
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_arrayRow, hv_arrayCol);
                DispRegion(ho_Contour);
                return arbitrary;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage(ex, true);
                return arbitrary;
            }
            finally
            {
                ho_Contour?.Dispose();
            }
        }

        public void ShowArbitrary(Arbitrary arbitrary)
        {
            try
            {
                if (null == arbitrary.dListRow)
                {
                    MessageFun.ShowMessage("无任意形状轮廓所需轮廓点。", false, strEnglish: "no points is provited for arbitrary shape");
                    return;
                }
                if (null != m_hImage)
                {
                    m_hWnd.DispObj(m_hImage);
                }
                HTuple hv_row = arbitrary.dListRow.ToArray();
                HTuple hv_col = arbitrary.dListCol.ToArray();
                m_hWnd.SetColor("green");
                m_hWnd.DispCross(hv_row, hv_col, 20, 0);
                m_hWnd.SetColor("red");
                HOperatorSet.GenContourPolygonXld(out m_XLDCont, hv_row, hv_col);
                DispRegion(m_XLDCont, "green");
                return;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("获取任意形状轮廓出错：" + ex.ToString(), true, strEnglish: "Error when getting arbitrary shape" + ex.ToString());
                return;
            }

        }
        public void GenArbitrary(List<Arbitrary> arbitrary)
        {
            HObject ho_Contour = null, ho_bitrary = null;
            HTuple hv_row = new HTuple(), hv_column = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_bitrary);

            try
            {
                foreach (var item in arbitrary)
                {
                    hv_row = item.dListRow.ToArray();
                    hv_column = item.dListCol.ToArray();

                    HOperatorSet.GenRegionPolygonFilled(out ho_Contour, hv_row, hv_column);
                    HOperatorSet.ConcatObj(ho_bitrary, ho_Contour, out ho_bitrary);
                }
                ClearObjShow();
                m_hWnd.SetDraw("margin");
                m_hWnd.DispObj(m_hImage);
                DispRegion(ho_bitrary, "green");
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return;
            }
            finally
            {
                ho_Contour?.Dispose();
                ho_bitrary?.Dispose();
            }

        }
        #endregion
        //画直线
        private static void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {
            HObject ho_TempArrow = null;

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);

            ho_Arrow.Dispose();
            HOperatorSet.GenEmptyObj(out ho_Arrow);

            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
            if (-1 != hv_ZeroLengthIndices[0])
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            //
            //Calculate end points of the arrow head.
            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            //
            //Finally create output XLD contour for each input point pair
            for (int i = 0; i <= (hv_Length.TupleLength() - 1); i++)
            {
                if (-1 == hv_Length[i].D)
                {
                    //Create_ single points for arrows with identical start and end point
                    ho_TempArrow.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1[i], hv_Column1[i]);
                }
                else
                {
                    //Create arrow contour
                    ho_TempArrow.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_TempArrow, new HTuple(hv_RowP1[i].D).TupleConcat(hv_Row2[i].D).TupleConcat(hv_RowP2[i].D).TupleConcat(hv_RowP1[i].D),
                        new HTuple(hv_ColP1[i].D).TupleConcat(hv_Column2[i].D).TupleConcat(hv_ColP2[i].D).TupleConcat(hv_ColP1[i].D));
                    HOperatorSet.GenRegionContourXld(ho_TempArrow, out ho_TempArrow, "filled");
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                    ho_Arrow.Dispose();
                    ho_Arrow = ExpTmpOutVar_0;
                }
            }
            ho_TempArrow.Dispose();
            return;
        }
        public Line DrawLine()
        {
            Line line = new Line();

            HObject ho_Line = null, ho_Arrow = null;
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Arrow);

            HTuple hv_StartRow = new HTuple(), hv_StartCol = new HTuple();
            HTuple hv_EndRow = new HTuple(), hv_EndCol = new HTuple();

            try
            {
                if (null == m_hImage || null == m_hWnd) return line;
                m_hWnd.DispObj(m_hImage);
                HOperatorSet.DrawLine(m_hWnd, out hv_StartRow, out hv_StartCol, out hv_EndRow, out hv_EndCol);
                HTuple hv_midRow = (hv_StartRow + hv_EndRow) / 2.0;
                HTuple hv_midCol = (hv_EndCol + hv_StartCol) / 2.0;
                double dDist = Math.Sqrt(Math.Pow((hv_midRow - hv_StartRow), 2) + Math.Pow((hv_midCol - hv_StartCol), 2)) / 10;
                gen_arrow_contour_xld(out ho_Arrow, hv_StartRow, hv_StartCol, hv_midRow, hv_midCol, dDist, dDist * 1.5);
                HOperatorSet.GenRegionLine(out ho_Line, hv_StartRow, hv_StartCol, hv_EndRow, hv_EndCol);
                m_hWnd.DispObj(ho_Line);
                m_hWnd.SetColor("green");
                // m_hWnd.SetDraw("fill");
                m_hWnd.DispObj(ho_Arrow);
                // SetShow(m_showParam);
                if (0 != ho_Line.CountObj())
                {
                    line.dStartRow = hv_StartRow.D;
                    line.dStartCol = hv_StartCol.D;
                    line.dEndRow = hv_EndRow.D;
                    line.dEndCol = hv_EndCol.D;
                }
                return line;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                return line;
            }
            finally
            {
                if (null != ho_Line) ho_Line.Dispose();
            }
        }

        public void DispLine(Line line)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Line);
            try
            {
                ho_Line.Dispose();
                HOperatorSet.GenRegionLine(out ho_Line, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol);
                DispRegion(ho_Line, lineWidth: 2);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex);
            }
        }
        //绘制椭圆
        public Ellipse DrawEllipse()
        {
            Ellipse ellipse = new Ellipse();

            HObject ho_Ellipse = null;
            HOperatorSet.GenEmptyObj(out ho_Ellipse);

            HTuple hv_row = new HTuple(), hv_column = new HTuple(), hv_phi = new HTuple(), hv_radius1 = new HTuple(), hv_radius2 = new HTuple();

            try
            {
                m_ObjShow.Dispose();
                if (null == m_hImage || null == m_hWnd) return ellipse;
                m_hWnd.DispObj(m_hImage);
                HOperatorSet.DrawEllipse(m_hWnd, out hv_row, out hv_column, out hv_phi, out hv_radius1, out hv_radius2);
                HOperatorSet.GenEllipse(out ho_Ellipse, hv_row, hv_column, hv_phi, hv_radius1, hv_radius2);
                m_hWnd.DispObj(ho_Ellipse);
                if (0 != ho_Ellipse.CountObj())
                {
                    ellipse.dRow = hv_row.D;
                    ellipse.dColumn = hv_column.D;
                    ellipse.dPhi = hv_phi.D;
                    ellipse.dRadius1 = hv_radius1.D;
                    ellipse.dRadius2 = hv_radius2.D;
                }
                return ellipse;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                ellipse.dRow = 0;
                ellipse.dColumn = 0;
                ellipse.dPhi = 0;
                ellipse.dRadius1 = 0;
                ellipse.dRadius2 = 0;
                return ellipse;
            }
            finally
            {
                if (null != ho_Ellipse) ho_Ellipse.Dispose();
            }
        }
        //显示十字线
        public void ShowCross(double dRow0, double dCol0, double dRow1, double dCol1)
        {
            try
            {
                int row, col, button;
                m_hWnd.GetMposition(out row, out col, out button);
                ShowImages(dRow0, dCol0, dRow1, dCol1);
                m_hWnd.DispLine(row, 0, row, (double)imageWidth);
                m_hWnd.DispLine(0, col, (double)imageHeight, col);
            }
            catch (System.Exception ex)
            {
                ex.ToString();
                return;
            }
            finally
            {
            }
        }
        //显示坐标和灰度值
        public void ShowCoordinateGrayVal(out int nRow, out int nCol, out List<double> listGrayVal)
        {
            nRow = 0;
            nCol = 0;
            listGrayVal = new List<double>();
            HTuple hv_GrayVal = new HTuple(), hv_channels = new HTuple();

            try
            {
                if (null == m_hImage)
                    return;
                int button;
                m_hWnd.GetMposition(out nRow, out nCol, out button);
                HOperatorSet.GetGrayval(m_hImage, nRow, nCol, out hv_GrayVal);
                for (int i = 0; i < hv_GrayVal.TupleLength(); i++)
                {
                    listGrayVal.Add(hv_GrayVal[i].D);
                }
            }
            catch (HalconException error)
            {
                error.ToString();
                return;
            }
        }

        //画点
        public PointF DrawPoint()
        {
            PointF point = new PointF();

            HTuple hv_row = new HTuple(), hv_col = new HTuple(), hv_button = new HTuple();
            HObject ho_Cross = null;
            HOperatorSet.GenEmptyObj(out ho_Cross);
            try
            {
                m_hWnd.DispObj(m_hImage);
                HOperatorSet.GetMbuttonSubPix(m_hWnd, out hv_row, out hv_col, out hv_button);
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_row, hv_col, 60, 0);
                m_hWnd.DispObj(ho_Cross);
                point.Y = (float)hv_row.D;
                point.X = (float)hv_col.D;
                return point;
            }
            catch (HalconException error)
            {
                MessageBox.Show(error.ToString());
                return point;
            }
            finally
            {
                if (null != ho_Cross) ho_Cross.Dispose();
            }
        }

        //辅助：计算与水平方向夹角
        public bool CalAngleLx(Line line, out double dAngle)
        {
            dAngle = 0;

            HObject ho_Line = null, ho_Arrow = null, ho_LineX = null, ho_ArrowX = null;
            HObject ho_contCircle = null;
            HOperatorSet.GenEmptyObj(out ho_Line);
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_LineX);
            HOperatorSet.GenEmptyObj(out ho_ArrowX);
            HOperatorSet.GenEmptyObj(out ho_contCircle);

            HTuple hv_angle = new HTuple();

            try
            {
                HOperatorSet.GenContourPolygonXld(out ho_Line, ((HTuple)line.dStartRow).TupleConcat(line.dEndRow), ((HTuple)line.dStartCol).TupleConcat(line.dEndCol));
                HOperatorSet.GenContourPolygonXld(out ho_LineX, ((HTuple)line.dStartRow).TupleConcat(line.dStartRow), ((HTuple)line.dStartCol).TupleConcat(imageWidth));
                double dDist = Math.Sqrt(Math.Pow((line.dEndRow - line.dStartRow), 2) + Math.Pow((line.dEndCol - line.dStartCol), 2)) / 30;
                gen_arrow_contour_xld(out ho_Arrow, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, dDist, dDist * 1.5);
                double dDist1 = (imageWidth - line.dStartCol) / 30;
                gen_arrow_contour_xld(out ho_ArrowX, line.dStartRow, line.dStartCol, line.dStartRow, imageWidth, dDist1, dDist1 * 1.5);

                HOperatorSet.AngleLx(line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out hv_angle);
                if (hv_angle.D < 0)
                    HOperatorSet.GenCircleContourXld(out ho_contCircle, line.dStartRow, line.dStartCol, dDist * 2, hv_angle, 0, "positive", 1);
                else
                    HOperatorSet.GenCircleContourXld(out ho_contCircle, line.dStartRow, line.dStartCol, dDist * 2, 0, hv_angle, "positive", 1);
                HOperatorSet.SetTposition(m_hWnd, line.dStartRow + dDist, line.dStartCol + dDist);
                m_hWnd.SetColor("green");
                m_hWnd.WriteString(Math.Round(hv_angle.TupleDeg().D, 2).ToString());
                m_hWnd.SetColor("red");
                m_hWnd.DispObj(ho_Line);
                m_hWnd.DispObj(ho_LineX);
                m_hWnd.SetDraw("fill");
                m_hWnd.DispObj(ho_Arrow);
                m_hWnd.DispObj(ho_ArrowX);
                m_hWnd.DispObj(ho_contCircle);
                return true;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (null != ho_Line) ho_Line.Dispose();
                if (null != ho_Arrow) ho_Arrow.Dispose();
                if (null != ho_LineX) ho_LineX.Dispose();
                if (null != ho_ArrowX) ho_ArrowX.Dispose(); ;
                if (null != ho_contCircle) ho_contCircle.Dispose();
            }
        }
        //辅助：计算夹角
        public double DrawAngleLl()
        {
            double dAngle = 0;
            int nRow = 0, nCol = 0, nButton = 0; ;
            double dDist = 0;

            HTuple hv_Angle = new HTuple(), hv_button = new HTuple();
            HTuple hv_angle1 = new HTuple(), hv_angle2 = new HTuple();

            HObject ho_Line1 = null, ho_Line2 = null;
            HObject ho_arrow1 = null, ho_arrow2 = null, ho_contCircle = null;

            HOperatorSet.GenEmptyObj(out ho_Line1);
            HOperatorSet.GenEmptyObj(out ho_Line2);
            HOperatorSet.GenEmptyObj(out ho_arrow1);
            HOperatorSet.GenEmptyObj(out ho_arrow2);
            HOperatorSet.GenEmptyObj(out ho_contCircle);
            try
            {
                m_hWnd.SetColor("red");
                m_hWnd.SetDraw("fill");
                int[] arrayRows = new int[3];
                int[] arrayCols = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    //m_hWnd.DrawPoint(out nRow, out nCol);
                    m_hWnd.GetMbutton(out nRow, out nCol, out nButton);
                    m_hWnd.SetColor("green");
                    m_hWnd.DispCross((double)nRow, (double)nCol, 25, 0);
                    m_hWnd.SetColor("red");
                    arrayRows[i] = nRow;
                    arrayCols[i] = nCol;
                    if (1 == i)
                    {
                        HOperatorSet.GenContourPolygonXld(out ho_Line1, ((HTuple)arrayRows[0]).TupleConcat(arrayRows[1]), ((HTuple)arrayCols[0]).TupleConcat(arrayCols[1]));
                        dDist = Math.Sqrt(Math.Pow((arrayRows[1] - arrayRows[0]), 2) + Math.Pow((arrayCols[1] - arrayCols[0]), 2)) / 30;
                        gen_arrow_contour_xld(out ho_arrow1, arrayRows[1], arrayCols[1], arrayRows[0], arrayCols[0], dDist, dDist * 1.5);
                        HOperatorSet.AngleLx(arrayRows[1], arrayCols[1], arrayRows[0], arrayCols[0], out hv_angle1);
                        m_hWnd.DispObj(ho_Line1);
                        m_hWnd.DispObj(ho_arrow1);
                    }
                    if (2 == i)
                    {
                        HOperatorSet.GenContourPolygonXld(out ho_Line2, ((HTuple)arrayRows[2]).TupleConcat(arrayRows[1]), ((HTuple)arrayCols[2]).TupleConcat(arrayCols[1]));
                        double dDist1 = Math.Sqrt(Math.Pow((arrayRows[1] - arrayRows[2]), 2) + Math.Pow((arrayCols[1] - arrayCols[2]), 2)) / 30;
                        gen_arrow_contour_xld(out ho_arrow2, arrayRows[1], arrayCols[1], arrayRows[2], arrayCols[2], dDist1, dDist1 * 1.5);
                        HOperatorSet.AngleLx(arrayRows[1], arrayCols[1], arrayRows[2], arrayCols[2], out hv_angle2);
                        m_hWnd.DispObj(ho_Line2);
                        m_hWnd.DispObj(ho_arrow2);
                    }
                }

                HOperatorSet.AngleLl(arrayRows[1], arrayCols[1], arrayRows[0], arrayCols[0], arrayRows[1], arrayCols[1], arrayRows[2], arrayCols[2], out hv_Angle);
                if (hv_angle2.D < hv_angle1.D)
                    HOperatorSet.GenCircleContourXld(out ho_contCircle, arrayRows[1], arrayCols[1], dDist * 1.5, hv_angle2, hv_angle1, "positive", 1);
                else
                    HOperatorSet.GenCircleContourXld(out ho_contCircle, arrayRows[1], arrayCols[1], dDist * 1.5, hv_angle1, hv_angle2, "positive", 1);
                m_hWnd.SetColor("green");
                m_hWnd.DispObj(ho_contCircle);
                m_hWnd.SetTposition((int)(arrayRows[1]), (int)(arrayCols[1] + dDist * 2));
                m_hWnd.WriteString(Math.Round(hv_Angle.TupleDeg().D, 2).ToString());
                m_hWnd.SetColor("red");
                return dAngle = hv_Angle.TupleDeg().D;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return dAngle;
            }
            finally
            {
                if (null != ho_Line1) ho_Line1.Dispose();
                if (null != ho_Line2) ho_Line2.Dispose();
                if (null != ho_arrow1) ho_arrow1.Dispose();
                if (null != ho_arrow2) ho_arrow2.Dispose();
                if (null != ho_contCircle) ho_contCircle.Dispose();
            }
        }


        //读取图像
        public void ReadImage(string strImagePath)
        {
            try
            {
                if (null != m_ObjShow)
                    m_ObjShow.Dispose();
                //m_nLastDraw = -1;
                LoadImageFromFile(strImagePath);
                //HOperatorSet.ReadImage(out m_hImage, strImagePath);
                //m_hWnd.ClearWindow();
                //m_hWnd.DispObj(m_hImage);
                //ShowRegion(m_ObjShow);
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return;
            }
        }
        //清除界面显示
        public void Clearwindow()
        {
            HOperatorSet.ClearWindow(m_hWnd);
        }
        //显示图片
        private void ShowImages(double dRow0, double dCol0, double dRow1, double dCol1)
        {
            try
            {
                if (null != m_hImage)
                {
                    HOperatorSet.SetSystem("flush_graphic", "false");
                    HOperatorSet.ClearWindow(m_hWnd);
                    if (m_hImage != null)
                    {
                        HOperatorSet.SetPart(m_hWnd, dRow0, dCol0, dRow1 - 1, dCol1 - 1);
                        m_hWnd.DispObj(m_hImage);
                    }
                    if (m_bShowCross) ShowCenterCross();
                    HOperatorSet.SetSystem("flush_graphic", "true");
                    HObject emptyObject = null;
                    HOperatorSet.GenEmptyObj(out emptyObject);
                    m_hWnd.DispObj(emptyObject);
                }
            }
            catch (HalconException error)
            {
                error.ToString();
                return;
            }
        }

        public bool LoadImageFromFile(string strFilePath)
        {
            try
            {
                if (null != m_ObjShow)
                    m_ObjShow.Dispose();
                HOperatorSet.ReadImage(out m_hImage, strFilePath);
                AIimage = new Mat(strFilePath);
                dReslutRow0 = 0;
                dReslutCol0 = 0;
                dReslutRow1 = 0;
                dReslutCol1 = 0;
                FitImageToWindow(ref dReslutRow0, ref dReslutCol0, ref dReslutRow1, ref dReslutCol1);
                HOperatorSet.Rgb1ToGray(m_hImage, out m_GrayImage);
                if (m_bShowCross)
                    ShowCenterCross();
                return true;
            }
            catch (System.Exception ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                return false;
            }

        }
        //縮放图片
        public void ZoomImage(double x, double y, double zoom)
        {
            try
            {
                double lengthC, lengthR;
                double percentC, percentR;

                percentC = (x - dReslutCol0) / (dReslutCol1 - dReslutCol0);
                percentR = (y - dReslutRow0) / (dReslutRow1 - dReslutRow0);

                lengthC = (dReslutCol1 - dReslutCol0) * zoom;
                lengthR = (dReslutRow1 - dReslutRow0) * zoom;

                dReslutCol0 = x - lengthC * percentC;

                dReslutCol1 = x + lengthC * (1 - percentC);

                dReslutRow0 = y - lengthR * percentR;
                dReslutRow1 = y + lengthR * (1 - percentR);
                ShowImages(dReslutRow0, dReslutCol0, dReslutRow1, dReslutCol1);
            }

            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        //平移图像   
        public void MoveImage(System.Drawing.Point pMouseDown, System.Drawing.Point pMouseUp)
        {
            if (pMouseDown.X == 0 || pMouseDown.Y == 0) //像素坐标
                return;
            //int row, col, button;
            try
            {
                //m_hWnd.GetMposition(out row, out col, out button);

                double dbRowMove, dbColMove;
                dbRowMove = (pMouseDown.Y - pMouseUp.Y);// * (dReslutRow1 - dReslutRow0) / hWndCtrl.Height;//计算光标在X轴拖动的距离
                dbColMove = (pMouseDown.X - pMouseUp.X);// (dReslutCol1 - dReslutCol0) / hWndCtrl.Width;//计算光标在Y轴拖动的距离

                dReslutRow0 = dReslutRow0 + dbRowMove;
                dReslutCol0 = dReslutCol0 + dbColMove;
                dReslutRow1 = dReslutRow1 + dbRowMove;
                dReslutCol1 = dReslutCol1 + dbColMove;

                ShowImages(dReslutRow0, dReslutCol0, dReslutRow1, dReslutCol1);
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return;
            }
        }

        //保存结果图片
        public void SaveResultImage(string strFilePath, string sCode = "")  //输入文件夹路径，不包含文件名字
        {
            try
            {
                if (string.IsNullOrWhiteSpace(strFilePath))
                    return;
                var folder = System.IO.Path.GetDirectoryName(strFilePath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string str = strFilePath + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".");
                if (sCode == "")
                {
                    str = strFilePath + (sCode + DateTime.Now).ToString().Replace("/", ".").Replace(":", ".");
                }
                str = str.Replace("\\", "/");
                if ("" != strFilePath)
                {
                    //HOperatorSet.DumpWindow(m_hWnd, "bmp", strFilePath);
                    HOperatorSet.DumpWindow(m_hWnd, "jpeg", str);
                }
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return;
            }
        }

        public void SaveResultImageToByte(string strFilePath)
        {
            HTuple hv_Pointer = new HTuple(), hv_Type = new HTuple(), hv_Width = new HTuple(), hv_Height = new HTuple();


            HObject ho_image = null;

            HOperatorSet.GenEmptyObj(out ho_image);
            try
            {
                if ("" != strFilePath)
                {
                    HOperatorSet.DumpWindowImage(out ho_image, m_hWnd);
                    HOperatorSet.GetImagePointer1(ho_image, out hv_Pointer, out hv_Type, out hv_Width, out hv_Height);
                    unsafe
                    {
                        byte* p = (byte*)hv_Pointer[0].L;
                        int height = hv_Height.I;
                        int width = hv_Width.I;
                    }


                }
            }
            catch (HalconException error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return;
            }
        }


        //导入图像文件夹
        public static void list_image_files(string strImageDirectory, HTuple hv_Extensions, out List<string> listImageFiles)
        {
            HTuple hv_HalconImages = null, hv_OS = null;
            HTuple hv_Directories = null, hv_Length = null;
            HTuple hv_network_drive = null, hv_Substring = new HTuple();
            HTuple hv_FileExists = new HTuple(), hv_AllFiles = new HTuple();
            HTuple hv_Selection = new HTuple();
            HTuple hv_Extensions_COPY_INP_TMP = hv_Extensions.Clone();
            string strImageDirectoryTemp = strImageDirectory;
            // HTuple hv_ImageDirectory_COPY_INP_TMP = hv_ImageDirectory.Clone();

            //output parameter:
            //ImageFiles: A tuple of all found image file names
            //
            //            if (Extensions == [] or Extensions == '' or Extensions == 'default')
            //    Extensions:= ['ima', 'tif', 'tiff', 'gif', 'bmp', 'jpg', 'jpeg', 'jp2', 'jxr', 'png', 'pcx', 'ras', 'xwd', 'pbm', 'pnm', 'pgm', 'ppm']
            //   *
            //endif
            if (/*hv_Extensions_COPY_INP_TMP[0] == 0 ||*/ hv_Extensions_COPY_INP_TMP == "" || hv_Extensions_COPY_INP_TMP == "default")
            {
                hv_Extensions_COPY_INP_TMP = new HTuple();
                hv_Extensions_COPY_INP_TMP[0] = "ima";
                hv_Extensions_COPY_INP_TMP[1] = "tif";
                hv_Extensions_COPY_INP_TMP[2] = "tiff";
                hv_Extensions_COPY_INP_TMP[3] = "gif";
                hv_Extensions_COPY_INP_TMP[4] = "bmp";
                hv_Extensions_COPY_INP_TMP[5] = "jpg";
                hv_Extensions_COPY_INP_TMP[6] = "jpeg";
                hv_Extensions_COPY_INP_TMP[7] = "jp2";
                hv_Extensions_COPY_INP_TMP[8] = "jxr";
                hv_Extensions_COPY_INP_TMP[9] = "png";
                hv_Extensions_COPY_INP_TMP[10] = "pcx";
                hv_Extensions_COPY_INP_TMP[11] = "ras";
                hv_Extensions_COPY_INP_TMP[12] = "xwd";
                hv_Extensions_COPY_INP_TMP[13] = "pbm";
                hv_Extensions_COPY_INP_TMP[14] = "pnm";
                hv_Extensions_COPY_INP_TMP[15] = "pgm";
                hv_Extensions_COPY_INP_TMP[16] = "ppm";
                //
            }
            if ("" == strImageDirectoryTemp)
            {
                strImageDirectoryTemp = ".";
            }
            HOperatorSet.GetSystem("image_dir", out hv_HalconImages);
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                hv_HalconImages = hv_HalconImages.TupleSplit(";");
            }
            else
            {
                hv_HalconImages = hv_HalconImages.TupleSplit(":");
            }
            hv_Directories = strImageDirectoryTemp;
            for (int i = 0; i <= (hv_HalconImages.TupleLength() - 1); i++)
            {
                hv_Directories = hv_Directories.TupleConcat((hv_HalconImages[i] + "/") + strImageDirectoryTemp);
            }
            HOperatorSet.TupleStrlen(hv_Directories, out hv_Length);
            HOperatorSet.TupleGenConst(hv_Length.TupleLength(), 0, out hv_network_drive);
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                for (int i = 0; i <= (hv_Length.TupleLength() - 1); i++)
                {

                    if (new HTuple(hv_Directories[i].ToString()).TupleStrlen() > 1)
                    {
                        HOperatorSet.TupleStrFirstN(hv_Directories[i], 1, out hv_Substring);
                        if (hv_Substring != "//")
                        {
                            if (hv_network_drive == null)
                                hv_network_drive = new HTuple();
                            hv_network_drive[i] = 1;
                        }
                    }
                }
            }
            listImageFiles = new List<string>();
            for (int i = 0; i <= (hv_Directories.TupleLength() - 1); i++)
            {
                HOperatorSet.FileExists(hv_Directories[i], out hv_FileExists);
                if ((int)(hv_FileExists) != 0)
                {
                    HOperatorSet.ListFiles(hv_Directories[i], (new HTuple("files")).TupleConcat(new HTuple()), out hv_AllFiles);
                    HTuple hv_ImageFiles = new HTuple();
                    for (int j = 0; j <= (hv_Extensions_COPY_INP_TMP.TupleLength() - 1); j++)
                    {
                        HOperatorSet.TupleRegexpSelect(hv_AllFiles, (((".*" + (hv_Extensions_COPY_INP_TMP[j])) + "$")).TupleConcat("ignore_case"), out hv_Selection);
                        hv_ImageFiles = hv_ImageFiles.TupleConcat(hv_Selection);
                    }

                    //HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("\\\\")).TupleConcat("replace_all"), "/", out hv_ImageFiles);
                    //if (hv_network_drive[i].I != 0)
                    //{
                    //    HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("//")).TupleConcat("replace_all"), "/", out hv_ImageFiles);
                    //    hv_ImageFiles = "/" + hv_ImageFiles;
                    //}
                    //else
                    //{
                    //    HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("//")).TupleConcat("replace_all"), "/", out hv_ImageFiles);
                    //}
                    for (int n = 0; n < hv_ImageFiles.TupleLength(); n++)
                    {
                        listImageFiles.Add(hv_ImageFiles[n]);
                    }
                    listImageFiles.Sort();
                    return;
                }

            }

            return;
        }

        //定位函数

        //拟合直线

        public bool FitLine(LineParam lineParam, out Line lineOut, out HObject ho_ContLine)
        {
            lineOut = new Line(0, 0, 0, 0);

            HTuple hv_Width = new HTuple(), hv_Height = new HTuple(), hv_MetrologyHandle = new HTuple(), hv_Indices = new HTuple();
            HTuple hv_RowBegin = new HTuple(), hv_ColBegin = new HTuple(), hv_RowEnd = new HTuple(), hv_ColEnd = new HTuple();
            HTuple hv_AllRow = new HTuple(), hv_AllColumn = new HTuple(), hv_Nr = new HTuple(), hv_Nc = new HTuple(), hv_Dist = new HTuple();
            HTuple hv_LineLen = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_MeasureCross);
            HOperatorSet.GenEmptyObj(out HObject ho_MeasureLineContours);
            HOperatorSet.GenEmptyObj(out HObject ho_MeasuredLines);
            HOperatorSet.GenEmptyObj(out ho_ContLine);
            try
            {
                HOperatorSet.GetImageSize(m_GrayImage, out hv_Width, out hv_Height);
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectLineMeasure(hv_MetrologyHandle, lineParam.lineIn.dStartRow, lineParam.lineIn.dStartCol, lineParam.lineIn.dEndRow, lineParam.lineIn.dEndCol, lineParam.measure.nLen1, lineParam.measure.dLen2, 1, lineParam.measure.nThd, new HTuple(), new HTuple(), out hv_Indices);
                HOperatorSet.DistancePp(lineParam.lineIn.dStartRow, lineParam.lineIn.dStartCol, lineParam.lineIn.dEndRow, lineParam.lineIn.dEndCol, out hv_LineLen);
                int nMeasureNum = (int)(hv_LineLen.D / 3.0);
                //设置直线拟合参数
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "num_instances", 1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "measure_select", lineParam.measure.strSelect);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "measure_transition", lineParam.measure.strTrans);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "num_measures", nMeasureNum);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "min_score", 0.5);
                //HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "measure_interpolation", "bicubic");
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Indices, "instances_outside_measure_regions", "true");
                //获取直线拟合结果
                HOperatorSet.ApplyMetrologyModel(m_GrayImage, hv_MetrologyHandle);
                HOperatorSet.GetMetrologyObjectMeasures(out ho_MeasureLineContours, hv_MetrologyHandle, "all", "all", out hv_AllRow, out hv_AllColumn);
                //DispRegion(ho_MeasureLineContours);
                HOperatorSet.GenCrossContourXld(out ho_MeasureCross, hv_AllRow, hv_AllColumn, 10, 0);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Indices, "all", "result_type", "row_begin", out hv_RowBegin);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Indices, "all", "result_type", "column_begin", out hv_ColBegin);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Indices, "all", "result_type", "row_end", out hv_RowEnd);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Indices, "all", "result_type", "column_end", out hv_ColEnd);
                HOperatorSet.GetMetrologyObjectResultContour(out ho_MeasuredLines, hv_MetrologyHandle, "all", "all", 1.5);
                //清除直线拟合句柄
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
                ho_ContLine.Dispose();
                if (0 == hv_RowBegin.TupleLength())
                {
                    if (hv_AllRow.TupleLength() >= 2)
                    {
                        HOperatorSet.GenContourPolygonXld(out ho_ContLine, hv_AllRow, hv_AllColumn);
                        HOperatorSet.FitLineContourXld(ho_ContLine, "tukey", -1, 0, 5, 2, out hv_RowBegin, out hv_ColBegin, out hv_RowEnd, out hv_ColEnd, out hv_Nr, out hv_Nc, out hv_Dist);
                        if (hv_RowBegin.TupleLength() == 0)
                            return false;
                        HOperatorSet.GenRegionLine(out ho_MeasuredLines, hv_RowBegin, hv_ColBegin, hv_RowEnd, hv_ColEnd);

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    HOperatorSet.GenContourPolygonXld(out ho_ContLine, hv_AllRow, hv_AllColumn);
                }
                lineOut = new Line(hv_RowBegin.D, hv_ColBegin.D, hv_RowEnd.D, hv_ColEnd.D);
                //
                if (lineParam.measure.bShow)
                {
                    DispRegion(ho_MeasureLineContours, "green");
                    DispRegion(ho_MeasureCross, "blue");
                    DispRegion(ho_MeasuredLines, "red");
                }

                return true;
            }
            catch (HalconException error)
            {
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
                return false;
            }
            finally
            {
                ho_MeasureCross?.Dispose();
                ho_MeasureLineContours?.Dispose();
                ho_MeasuredLines?.Dispose();
            }
        }
        //拟合圆
        public bool FitCircle(CircleParam param, out Circle circleOut)
        {
            bool bResult = true;
            circleOut.dRow = 0;
            circleOut.dCol = 0;
            circleOut.dRadius = 0;

            HTuple hv_MetrologyHandle = new HTuple();
            HTuple hv_Rows = null, hv_Cols;
            HTuple hv_CircleRow = new HTuple(), hv_CircleCol = new HTuple(), hv_Radius = new HTuple();
            HTuple hv_StartPhi = new HTuple(), hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_Contours);
            HOperatorSet.GenEmptyObj(out HObject ho_ContRect);
            HOperatorSet.GenEmptyObj(out HObject ho_Circle);
            HOperatorSet.GenEmptyObj(out HObject ho_Cross);
            try
            {
                int nMeasureNum = (int)((Math.PI * 2 * param.circleIn.dRadius) / (2 * param.EPMeasure.dLen2));
                HOperatorSet.GetImageSize(m_GrayImage, out HTuple hv_Width, out HTuple hv_Height);
                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectCircleMeasure(hv_MetrologyHandle, param.circleIn.dRow, param.circleIn.dCol, param.circleIn.dRadius, param.EPMeasure.nLen1, param.EPMeasure.dLen2, 1.2, param.EPMeasure.nThd, new HTuple(), new HTuple(), out HTuple hv_Index);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_instances", 1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_measures", nMeasureNum);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_transition", param.EPMeasure.strTrans);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_select", param.EPMeasure.strSelect);
                HOperatorSet.ApplyMetrologyModel(m_GrayImage, hv_MetrologyHandle);
                ho_ContRect.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_ContRect, hv_MetrologyHandle, "all", "all", out hv_Rows, out hv_Cols);
                if (0 == hv_Rows.TupleLength())
                    return false;
                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Rows, hv_Cols, 6, 0);
                ho_Contours.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contours, hv_MetrologyHandle, "all", "all", 1.5);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "row", out hv_CircleRow);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "column", out hv_CircleCol);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "radius", out hv_Radius);
                if (0 == hv_CircleRow.TupleLength() && hv_Rows.TupleLength() >= 5)
                {
                    ho_Contours.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contours, hv_Rows, hv_Cols);
                    HOperatorSet.FitCircleContourXld(ho_Contours, "algebraic", -1, 0, 0, 3, 2, out hv_CircleRow, out hv_CircleCol, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
                }
                else if (0 == hv_CircleRow.TupleLength() && hv_Rows.TupleLength() < 5)
                    return false;
                ho_Circle.Dispose();
                HOperatorSet.GenCircle(out ho_Circle, hv_CircleRow, hv_CircleCol, hv_Radius);
                circleOut = new BaseData.Circle(hv_CircleRow.D, hv_CircleCol.D, hv_Radius.D);
                if (param.EPMeasure.bShow)
                {
                    m_hWnd.DispObj(m_hImage);
                    DispRegion(ho_Cross, "green");
                    DispRegion(ho_ContRect, "red");
                    DispRegion(ho_Circle);
                }
                m_hWnd.DispCross(hv_CircleRow, hv_CircleCol, hv_Radius / 3, 0);
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error, true);
                bResult = false;
            }
            finally
            {
                ho_Contours?.Dispose();
                ho_ContRect?.Dispose();
                ho_Circle?.Dispose();
                ho_Cross?.Dispose();
            }
            HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);
            return bResult;
        }
        //拟合椭圆
        public bool FitEllipse(EllipseParam param, out Ellipse ellipseOut)
        {
            ellipseOut = new Ellipse();

            HTuple hv_MetrologyHandle, hv_Width, hv_Height;
            HTuple hv_Index, hv_Rows = null, hv_Cols;
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Phi = new HTuple(), hv_Radius1 = new HTuple(), hv_Radius2 = new HTuple();
            HTuple hv_StartPhi = new HTuple(), hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();

            HObject ho_Contours = null, ho_ContRect = null, ho_Ellipse = null;
            HObject ho_Cross = null;

            HOperatorSet.GenEmptyObj(out ho_Contours);
            HOperatorSet.GenEmptyObj(out ho_ContRect);
            HOperatorSet.GenEmptyObj(out ho_Ellipse);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            try
            {
                m_hWnd.DispObj(m_hImage);
                //椭圆周长公式：L=2πb+4（a-b）
                int nMeasureNum = (int)((Math.PI * 2 * param.ellipseIn.dRadius2 + 4 * (param.ellipseIn.dRadius1 - param.ellipseIn.dRadius2)) / (2 * param.EPMeasure.dLen2));
                HOperatorSet.GetImageSize(m_hImage, out hv_Width, out hv_Height);

                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectEllipseMeasure(hv_MetrologyHandle, param.ellipseIn.dRow, param.ellipseIn.dColumn, param.ellipseIn.dPhi, param.ellipseIn.dRadius1, param.ellipseIn.dRadius2, param.EPMeasure.nLen1, param.EPMeasure.dLen2, 1.2, param.EPMeasure.nThd, new HTuple(), new HTuple(), out hv_Index);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_instances", 1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_measures", nMeasureNum);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_transition", param.EPMeasure.strTrans);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_select", param.EPMeasure.strSelect);

                HOperatorSet.ApplyMetrologyModel(m_hImage, hv_MetrologyHandle);
                HOperatorSet.GetMetrologyObjectMeasures(out ho_ContRect, hv_MetrologyHandle, "all", "all", out hv_Rows, out hv_Cols);
                if (0 == hv_Rows.TupleLength())
                    return false;
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Rows, hv_Cols, 6, 0);

                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contours, hv_MetrologyHandle, "all", "all", 1.5);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "row", out hv_Row);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "column", out hv_Column);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "phi", out hv_Phi);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "radius1", out hv_Radius1);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "radius2", out hv_Radius2);
                if (0 == hv_Row.TupleLength() && hv_Rows.TupleLength() >= 5)
                {
                    HOperatorSet.GenContourPolygonXld(out ho_Contours, hv_Rows, hv_Cols);
                    HOperatorSet.FitEllipseContourXld(ho_Contours, "fitzgibbon", -1, 0, 0, 200, 3, 2, out hv_Row, out hv_Column, out hv_Phi, out hv_Radius1, out hv_Radius2,
                                                      out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);

                }
                else if (0 == hv_Row.TupleLength() && hv_Rows.TupleLength() < 5)
                    return false;
                HOperatorSet.GenEllipse(out ho_Ellipse, hv_Row, hv_Column, hv_Phi, hv_Radius1, hv_Radius2);
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                ellipseOut.dRow = hv_Row.D;
                ellipseOut.dColumn = hv_Column.D;
                ellipseOut.dPhi = hv_Phi.D;
                ellipseOut.dRadius1 = hv_Radius1.D;
                ellipseOut.dRadius2 = hv_Radius2.D;

                //显示
                m_hWnd.SetColor("green");
                m_ObjShow = ho_Cross;
                m_hWnd.DispObj(m_ObjShow);
                m_hWnd.SetColor("red");
                m_hWnd.DispObj(ho_ContRect);
                //SetShow(m_showParam);
                DispRegion(ho_Ellipse);
                m_hWnd.DispCross(hv_Row, hv_Column, hv_Radius2 / 5, hv_Phi);
                return true;
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_Contours) ho_Contours.Dispose();
                if (null != ho_ContRect) ho_ContRect.Dispose();
                if (null != ho_Ellipse) ho_Ellipse.Dispose();
                if (null != ho_Cross) ho_Cross.Dispose();
            }
        }
        //拟合矩形2
        public bool FitRect2(Rect2Param param, out Rect2 rect2)
        {
            rect2 = new Rect2();

            HTuple hv_MetrologyHandle, hv_Width, hv_Height;
            HTuple hv_Index, hv_Rows = null, hv_Cols;
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Phi = new HTuple(), hv_Length1 = new HTuple(), hv_Length2 = new HTuple();
            HTuple hv_StartPhi = new HTuple(), hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();

            HObject ho_Contours = null, ho_ContRect = null, ho_Rect2 = null;
            HObject ho_Cross = null;

            HOperatorSet.GenEmptyObj(out ho_Contours);
            HOperatorSet.GenEmptyObj(out ho_ContRect);
            HOperatorSet.GenEmptyObj(out ho_Rect2);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            try
            {
                m_hWnd.DispObj(m_hImage);
                //长方形周长
                int nMeasureNum = (int)((4 * param.rect2In.dLength1 + param.rect2In.dLength2) / (2 * param.EPMeasure.dLen2));
                HOperatorSet.GetImageSize(m_hImage, out hv_Width, out hv_Height);

                HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
                HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);
                HOperatorSet.AddMetrologyObjectRectangle2Measure(hv_MetrologyHandle, param.rect2In.dRect2Row, param.rect2In.dRect2Col, param.rect2In.dPhi, param.rect2In.dLength1, param.rect2In.dLength2, param.EPMeasure.nLen1, param.EPMeasure.dLen2, 1.2, param.EPMeasure.nThd, new HTuple(), new HTuple(), out hv_Index);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_instances", 1);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "num_measures", nMeasureNum);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_transition", param.EPMeasure.strTrans);
                HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_Index, "measure_select", param.EPMeasure.strSelect);

                HOperatorSet.ApplyMetrologyModel(m_hImage, hv_MetrologyHandle);
                HOperatorSet.GetMetrologyObjectMeasures(out ho_ContRect, hv_MetrologyHandle, "all", "all", out hv_Rows, out hv_Cols);
                if (0 == hv_Rows.TupleLength())
                    return false;
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Rows, hv_Cols, 6, 0);

                HOperatorSet.GetMetrologyObjectResultContour(out ho_Contours, hv_MetrologyHandle, "all", "all", 1.5);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "row", out hv_Row);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "column", out hv_Column);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "phi", out hv_Phi);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "length1", out hv_Length1);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, hv_Index, "all", "result_type", "length2", out hv_Length2);
                if (0 == hv_Row.TupleLength() && hv_Rows.TupleLength() >= 5)
                {
                    HOperatorSet.GenContourPolygonXld(out ho_Contours, hv_Rows, hv_Cols);
                    HOperatorSet.FitRectangle2ContourXld(ho_Contours, "regression", -1, 0, 0, 3, 2, out hv_Row, out hv_Column, out hv_Phi, out hv_Length1, out hv_Length2,
                                                         out hv_PointOrder);

                }
                else if (0 == hv_Row.TupleLength() && hv_Rows.TupleLength() < 5)
                    return false;
                HOperatorSet.GenRectangle2(out ho_Rect2, hv_Row, hv_Column, hv_Phi, hv_Length1, hv_Length2);
                HOperatorSet.ClearMetrologyModel(hv_MetrologyHandle);

                rect2.dRect2Row = hv_Row.D;
                rect2.dRect2Col = hv_Column.D;
                rect2.dPhi = hv_Phi.D;
                rect2.dLength1 = hv_Length1.D;
                rect2.dLength2 = hv_Length2.D;

                //显示
                m_hWnd.SetColor("green");
                m_ObjShow = ho_Cross;
                m_hWnd.DispObj(m_ObjShow);
                m_hWnd.SetColor("red");
                m_hWnd.DispObj(ho_ContRect);
                //SetShow(m_showParam);
                m_ObjShow = m_ObjShow.ConcatObj(ho_Rect2);
                m_hWnd.DispObj(m_ObjShow);
                m_hWnd.DispCross(hv_Row, hv_Column, hv_Length2 / 5, hv_Phi);
                return true;
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_Contours) ho_Contours.Dispose();
                if (null != ho_ContRect) ho_ContRect.Dispose();
                if (null != ho_Rect2) ho_Rect2.Dispose();
                if (null != ho_Cross) ho_Cross.Dispose();
            }
        }
        //双线段
        public bool FitDoubleLine(DoubleLineParam param, out DoubleLineOut result)
        {
            /*边缘搜索方法：从中间往两边*/
            result = new DoubleLineOut();

            HObject ho_Rect2 = null, ho_ImageReduced = null;
            HObject ho_Border = null, ho_UnionContours = null, ho_SelectedXLD = null, ho_SortedContours = null;
            HObject ho_ObjSelected = null, ho_line1 = null, ho_line2 = null;

            HTuple hv_Number = null, hv_RowBegin = new HTuple(), hv_Orientation = new HTuple();
            HTuple hv_ColBegin = new HTuple(), hv_RowEnd = new HTuple(), hv_ColEnd = new HTuple(), hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist = new HTuple(), hv_DistMin = new HTuple(), hv_DistMax = new HTuple();
            HTuple hv_AngleLl = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_Rect2);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Border);
            HOperatorSet.GenEmptyObj(out ho_UnionContours);
            HOperatorSet.GenEmptyObj(out ho_SelectedXLD);
            HOperatorSet.GenEmptyObj(out ho_SortedContours);
            HOperatorSet.GenEmptyObj(out ho_ObjSelected);
            HOperatorSet.GenEmptyObj(out ho_line1);
            HOperatorSet.GenEmptyObj(out ho_line2);

            try
            {
                HOperatorSet.GenRectangle2(out ho_Rect2, param.rect2.dRect2Row, param.rect2.dRect2Col, param.rect2.dPhi, param.rect2.dLength1, param.rect2.dLength2);
                m_hWnd.DispObj(ho_Rect2);
                HOperatorSet.ReduceDomain(m_hImage, ho_Rect2, out ho_ImageReduced);
                int nThd = param.nThd;
                int nStep = 5;
                hv_Number = 1;
                while (hv_Number != 2 && nThd < 255)
                {
                    HOperatorSet.ThresholdSubPix(ho_ImageReduced, out ho_Border, nThd);
                    HOperatorSet.UnionAdjacentContoursXld(ho_Border, out ho_UnionContours, 5, 1, "attr_keep");
                    //m_hWnd.DispObj(ho_UnionContours);
                    // HOperatorSet.UnionCollinearContoursXld(ho_Border, out ho_UnionContours, 10, 1, 2, 0.1, "attr_keep");
                    //if (ho_UnionContours.CountObj() > 100)
                    //    continue;
                    HOperatorSet.SelectShapeXld(ho_UnionContours, out ho_SelectedXLD, (new HTuple("rect2_len1")).TupleConcat("rect2_len2"), "and",
                                               ((new HTuple(param.rect2.dLength2)) / 1.5).TupleConcat(0), (new HTuple(param.rect2.dLength2) * 1.5).TupleConcat(10));
                    HOperatorSet.CountObj(ho_SelectedXLD, out hv_Number);
                    nThd = nThd + nStep;
                }
                if (2 != hv_Number.I)
                {
                    return false;
                }
                m_hWnd.DispObj(ho_SelectedXLD);
                //HOperatorSet.SortContoursXld(ho_SelectedXLD, out ho_SortedContours, "upper_left", "true", "column");
                List<Line> listLine = new List<Line>();
                LineParam lineParam = new LineParam();
                lineParam.measure.nLen1 = 5;
                lineParam.measure.dLen2 = param.EPMeasure.dLen2;
                lineParam.measure.nThd = param.EPMeasure.nThd;
                switch (param.nTransType)
                {
                    case 0: //中间黑两边白
                        lineParam.measure.strTrans = "positive";
                        break;
                    case 1: //中间白两边黑
                        lineParam.measure.strTrans = "negative";
                        break;
                    default:
                        break;
                }
                lineParam.measure.strSelect = "first";
                for (int i = 1; i <= 2; i++)
                {
                    HOperatorSet.SelectObj(ho_SelectedXLD, out ho_ObjSelected, i);
                    HOperatorSet.FitLineContourXld(ho_ObjSelected, "tukey", -1, 0, 5, 2, out hv_RowBegin, out hv_ColBegin, out hv_RowEnd, out hv_ColEnd,
                                                   out hv_Nr, out hv_Nc, out hv_Dist);

                    lineParam.lineIn.dStartRow = hv_RowBegin.D;
                    lineParam.lineIn.dStartCol = hv_ColBegin.D;
                    lineParam.lineIn.dEndRow = hv_RowEnd.D;
                    lineParam.lineIn.dEndCol = hv_ColEnd.D;

                    Line outLine = new Line();
                    if (!FitLine(lineParam, out outLine, out _))
                    {
                        lineParam.lineIn.dStartRow = hv_RowEnd.D;
                        lineParam.lineIn.dStartCol = hv_ColEnd.D;
                        lineParam.lineIn.dEndRow = hv_RowBegin.D;
                        lineParam.lineIn.dEndCol = hv_ColBegin.D;
                        if (!FitLine(lineParam, out outLine, out _))
                            return false;
                    }
                    listLine.Add(outLine);
                }
                result.lineLeft = listLine[0];
                result.lineRight = listLine[1];
                HOperatorSet.DistanceSl(listLine[0].dStartRow, listLine[0].dStartCol, listLine[0].dEndRow, listLine[0].dEndCol,
                                        listLine[1].dStartRow, listLine[1].dStartCol, listLine[1].dEndRow, listLine[1].dEndCol, out hv_DistMin, out hv_DistMax);
                result.dDist = (hv_DistMin.D + hv_DistMax.D) / 2.0;
                HOperatorSet.AngleLl(listLine[0].dStartRow, listLine[0].dStartCol, listLine[0].dEndRow, listLine[0].dEndCol,
                                     listLine[1].dEndRow, listLine[1].dEndCol, listLine[1].dStartRow, listLine[1].dStartCol, out hv_AngleLl);
                result.dAngle = hv_AngleLl.TupleDeg().D;

                //显示
                m_hWnd.DispObj(m_hImage);
                m_hWnd.SetColor("green");
                HOperatorSet.GenContourPolygonXld(out ho_line1, ((HTuple)listLine[0].dStartRow).TupleConcat(listLine[0].dEndRow),
                                                                ((HTuple)listLine[0].dStartCol).TupleConcat(listLine[0].dEndCol));
                HOperatorSet.GenContourPolygonXld(out ho_line2, ((HTuple)listLine[1].dStartRow).TupleConcat(listLine[1].dEndRow),
                                                                ((HTuple)listLine[1].dStartCol).TupleConcat(listLine[1].dEndCol));
                //m_hWnd.DispLine(listLine[0].dStartRow, listLine[0].dStartCol, listLine[0].dEndRow, listLine[0].dEndCol);
                //m_hWnd.DispLine(listLine[1].dStartRow, listLine[1].dStartCol, listLine[1].dEndRow, listLine[1].dEndCol);
                HObject obj = ho_line1.ConcatObj(ho_line2);
                DispRegion(obj);
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_Rect2) ho_Rect2.Dispose();
                if (null != ho_ImageReduced) ho_ImageReduced.Dispose();
                if (null != ho_Border) ho_Border.Dispose();
                if (null != ho_UnionContours) ho_UnionContours.Dispose();
                if (null != ho_SelectedXLD) ho_SelectedXLD.Dispose();
                if (null != ho_SortedContours) ho_SortedContours.Dispose();
                if (null != ho_ObjSelected) ho_ObjSelected.Dispose();
                if (null != ho_line1) ho_line1.Dispose();
                if (null != ho_line2) ho_line2.Dispose();
            }
        }

        /*直线到直线的距离*/
        /*返回交点，最大距离，最小距离，和夹角*/
        public bool LineInterLine(Line line1, Line line2, out LineInterLineResult result)
        {
            result = new LineInterLineResult();
            result.InterPoint = new PointF();

            HTuple hv_DistMin = new HTuple(), hv_DistMax = new HTuple(), hv_InterRow = new HTuple(), hv_InterCol = new HTuple();
            HTuple hv_isOverlapping = new HTuple(), hv_isParallel = new HTuple(), hv_angle = new HTuple();
            HTuple hv_SegInterRow = new HTuple(), hv_SegInterCol = new HTuple();
            HTuple hv_rowProj1 = new HTuple(), hv_colProj1 = new HTuple();
            HTuple hv_rowProj2 = new HTuple(), hv_colProj2 = new HTuple();

            HObject obj = new HObject(), ho_cross = new HObject(), ho_line1 = new HObject(), ho_line2 = new HObject();
            HObject ho_arrow1 = new HObject(), ho_arrow2 = new HObject(), ho_arrowline1 = new HObject(), ho_arrowline2 = new HObject();

            HOperatorSet.GenEmptyObj(out obj);
            HOperatorSet.GenEmptyObj(out ho_cross);
            HOperatorSet.GenEmptyObj(out ho_line1);
            HOperatorSet.GenEmptyObj(out ho_line2);
            HOperatorSet.GenEmptyObj(out ho_arrow1);
            HOperatorSet.GenEmptyObj(out ho_arrow2);
            HOperatorSet.GenEmptyObj(out ho_arrowline1);
            HOperatorSet.GenEmptyObj(out ho_arrowline2);

            try
            {
                HOperatorSet.IntersectionLl(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                            line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_InterRow, out hv_InterCol, out hv_isParallel);
                HOperatorSet.DistanceSl(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                        line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_DistMin, out hv_DistMax);
                result.dDistMin = hv_DistMin.D;
                result.dDistMax = hv_DistMax.D;
                if (0 == hv_InterRow.TupleLength())//两套直线平行
                {
                    result.bIsLineInter = false;
                    result.bIsSegInter = false;
                    result.dAngle = 0;
                }
                else
                {
                    HOperatorSet.AngleLl(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                            line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_angle);
                    result.dAngle = hv_angle.TupleDeg().D;
                    HOperatorSet.DistanceSl(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                                line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_DistMin, out hv_DistMax);

                    HOperatorSet.DistanceSs(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                            line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_DistMin, out hv_DistMax);
                    if (0 == hv_DistMin.D)//两条线段相交
                    {
                        result.bIsLineInter = true;
                        result.bIsSegInter = true;
                        result.dDistMin = hv_DistMin.D;
                        result.dDistMax = hv_DistMax.D;
                        HOperatorSet.IntersectionSegments(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
                                                          line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_SegInterRow, out hv_SegInterCol, out hv_isOverlapping);
                        if (0 != hv_InterRow.TupleLength())
                        {
                            result.InterPoint.Y = (float)hv_SegInterRow.D;
                            result.InterPoint.X = (float)hv_SegInterCol.D;
                        }
                    }
                    else
                    {
                        result.bIsLineInter = true;
                        result.bIsSegInter = false;
                        result.InterPoint.Y = (float)hv_InterRow.D;
                        result.InterPoint.X = (float)hv_InterCol.D;
                    }
                }
                //显示
                if (result.bIsLineInter || result.bIsSegInter)
                    HOperatorSet.GenCrossContourXld(out ho_cross, result.InterPoint.Y, result.InterPoint.X, 20, 0);
                HOperatorSet.GenContourPolygonXld(out ho_line1, ((HTuple)line1.dStartRow).TupleConcat(line1.dEndRow), ((HTuple)line1.dStartCol).TupleConcat(line1.dEndCol));
                HOperatorSet.GenContourPolygonXld(out ho_line2, ((HTuple)line2.dStartRow).TupleConcat(line2.dEndRow), ((HTuple)line2.dStartCol).TupleConcat(line2.dEndCol));
                HOperatorSet.ProjectionPl(line1.dStartRow, line1.dStartCol, line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_rowProj1, out hv_colProj1);
                HOperatorSet.ProjectionPl(line1.dEndRow, line1.dEndCol, line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_rowProj2, out hv_colProj2);
                gen_arrow_contour_xld(out ho_arrow1, line1.dStartRow, line1.dStartCol, hv_rowProj1, hv_colProj1, 10, 3);
                gen_arrow_contour_xld(out ho_arrow2, line1.dEndRow, line1.dEndCol, hv_rowProj2, hv_colProj2, 10, 3);
                HOperatorSet.GenContourPolygonXld(out ho_arrowline1, ((HTuple)line1.dStartRow).TupleConcat(hv_rowProj1), ((HTuple)line1.dStartCol).TupleConcat(hv_colProj1));
                HOperatorSet.GenContourPolygonXld(out ho_arrowline2, ((HTuple)line1.dEndRow).TupleConcat(hv_rowProj2), ((HTuple)line1.dEndCol).TupleConcat(hv_colProj2));
                obj = obj.ConcatObj(ho_cross);
                obj = obj.ConcatObj(ho_line1);
                obj = obj.ConcatObj(ho_line2);
                //ShowRegion(obj);
                //m_hWnd.SetColor("green");
                //HOperatorSet.GenEmptyObj(out obj);
                obj = obj.ConcatObj(ho_arrow1);
                obj = obj.ConcatObj(ho_arrow2);
                obj = obj.ConcatObj(ho_arrowline1);
                obj = obj.ConcatObj(ho_arrowline2);
                DispRegion(obj);
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                if (null != obj) obj.Dispose();
                if (null != ho_cross) ho_cross.Dispose();
                if (null != ho_line1) ho_line1.Dispose();
                if (null != ho_line2) ho_line2.Dispose();
                if (null != ho_arrow1) ho_arrow1.Dispose();
                if (null != ho_arrow2) ho_arrow2.Dispose();
                if (null != ho_arrowline1) ho_arrowline1.Dispose();
                if (null != ho_arrowline2) ho_arrowline2.Dispose();
            }
        }

        /*直线到圆的距离*/
        public static bool LineInterCircle(Line line, Circle circle, out List<PointF> listPoint, out double dDistMin, out double dDistMax)
        {
            listPoint = new List<PointF>();
            dDistMax = -1;
            dDistMin = -1;
            HTuple hv_interRow = new HTuple(), hv_interCol = new HTuple(), hv_DistMin = new HTuple(), hv_DistMax = new HTuple();

            HObject ho_contCircle = new HObject();

            HOperatorSet.GenEmptyObj(out ho_contCircle);
            try
            {
                HOperatorSet.IntersectionLineCircle(line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, circle.dRow, circle.dCol, circle.dRadius, 0, 6.28318,
                                                    "positive", out hv_interRow, out hv_interCol);
                if (0 == hv_interRow.TupleLength())
                {//直线与圆不相交
                    HOperatorSet.GenCircleContourXld(out ho_contCircle, circle.dRow, circle.dCol, circle.dRadius, 0, 6.28318, "positive", 1);
                    HOperatorSet.DistanceLc(ho_contCircle, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out hv_DistMin, out hv_DistMax);
                }
                else
                {
                    int n = hv_interRow.TupleLength();
                    if (1 == n)
                    {
                        HOperatorSet.DistancePs(hv_interRow, hv_interCol, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out hv_DistMin, out hv_DistMax);
                        if (0 == hv_DistMin.D)
                        {

                        }
                    }
                    else if (2 == n)
                    {

                    }
                    //HOperatorSet.DistancePs()
                }
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }

        }

        /*圆到圆的距离*/
        public bool CircleInterCircle(Circle circle1, Circle circle2, out CircleInterCircleResult result)
        {
            result = new CircleInterCircleResult();
            result.listInterPoint = new List<PointF>();

            HTuple hv_InterRow = new HTuple(), hv_InterCol = new HTuple(), hv_isOverLapping = new HTuple();
            HTuple hv_DistCenters = new HTuple();

            HObject ho_Obj = new HObject(), ho_circle1 = new HObject(), ho_circle2 = new HObject();
            HObject ho_cross1 = new HObject(), ho_cross2 = new HObject();

            HOperatorSet.GenEmptyObj(out ho_Obj);
            HOperatorSet.GenEmptyObj(out ho_circle1);
            HOperatorSet.GenEmptyObj(out ho_circle2);
            HOperatorSet.GenEmptyObj(out ho_circle1);
            HOperatorSet.GenEmptyObj(out ho_circle2);
            try
            {
                HOperatorSet.IntersectionCircles(circle1.dRow, circle1.dCol, circle1.dRadius, 0, 6.28318, "positive",
                                                 circle2.dRow, circle2.dCol, circle2.dRadius, 0, 6.28318, "positive", out hv_InterRow, out hv_InterCol, out hv_isOverLapping);
                //不相交
                if (0 == hv_InterRow.TupleLength())
                {
                    result.bIsIntersect = false;
                }
                else
                {
                    result.bIsIntersect = true;
                    for (int i = 0; i < hv_InterCol.TupleLength(); i++)
                    {
                        PointF point = new PointF();
                        point.X = (float)hv_InterCol.D;
                        point.Y = (float)hv_InterRow.D;
                        result.listInterPoint.Add(point);
                        HOperatorSet.GenCrossContourXld(out ho_cross1, hv_InterRow[i], hv_InterCol[i], circle1.dRadius / 5, 0);
                        DispRegion(ho_cross1);
                    }
                }
                //计算两个圆心的距离
                HOperatorSet.DistancePp(circle1.dRow, circle1.dCol, circle2.dRow, circle2.dCol, out hv_DistCenters);
                result.dDistCenter = hv_DistCenters.D;

                //显示
                HOperatorSet.GenCircle(out ho_circle1, circle1.dRow, circle1.dCol, circle1.dRadius);
                HOperatorSet.GenCircle(out ho_circle2, circle2.dRow, circle2.dCol, circle2.dRadius);
                ho_Obj = ho_Obj.ConcatObj(ho_circle1);
                ho_Obj = ho_Obj.ConcatObj(ho_circle2);
                HOperatorSet.GenCrossContourXld(out ho_cross1, circle1.dRow, circle1.dCol, circle1.dRadius / 3, 0);
                HOperatorSet.GenCrossContourXld(out ho_cross2, circle2.dRow, circle2.dCol, circle2.dRadius / 3, 0);
                ho_Obj = ho_Obj.ConcatObj(ho_cross1);
                ho_Obj = ho_Obj.ConcatObj(ho_cross2);
                DispRegion(ho_Obj);
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_Obj) ho_Obj.Dispose();
                if (null != ho_circle1) ho_circle1.Dispose();
                if (null != ho_circle2) ho_circle2.Dispose();
                if (null != ho_circle1) ho_circle1.Dispose();
                if (null != ho_circle2) ho_circle2.Dispose();
            }
        }

        /*点到直线的距离*/
        public static bool DistPL(double dRow, double dCol, Line line, out double dDistPl)
        {
            dDistPl = -1;
            HTuple hv_Distance = null;

            try
            {
                dDistPl = -1;
                HOperatorSet.DistancePl(dRow, dCol, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out hv_Distance);
                if (0 == hv_Distance.TupleLength())
                {
                    return false;
                }
                dDistPl = hv_Distance.D;
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //
        public static void list_image_files(HTuple hv_ImageDirectory, HTuple hv_Extensions, HTuple hv_Options, out HTuple hv_ImageFiles)
        {
            // Local iconic variables 

            // Local control variables 

            HTuple hv_HalconImages = null, hv_OS = null;
            HTuple hv_Directories = null, hv_Index = null, hv_Length = null;
            HTuple hv_network_drive = null, hv_Substring = new HTuple();
            HTuple hv_FileExists = new HTuple(), hv_AllFiles = new HTuple();
            HTuple hv_i = new HTuple(), hv_Selection = new HTuple();
            HTuple hv_Extensions_COPY_INP_TMP = hv_Extensions.Clone();
            HTuple hv_ImageDirectory_COPY_INP_TMP = hv_ImageDirectory.Clone();

            // Initialize local and output iconic variables 
            //This procedure returns all files in a given directory
            //with one of the suffixes specified in Extensions.
            //
            //input parameters:
            //ImageDirectory: as the name says
            //   If a tuple of directories is given, only the images in the first
            //   existing directory are returned.
            //   If a local directory is not found, the directory is searched
            //   under %HALCONIMAGES%/ImageDirectory. If %HALCONIMAGES% is not set,
            //   %HALCONROOT%/images is used instead.
            //Extensions: A string tuple containing the extensions to be found
            //   e.g. ['png','tif',jpg'] or others
            //If Extensions is set to 'default' or the empty string '',
            //   all image suffixes supported by HALCON are used.
            //Options: as in the operator list_files, except that the 'files'
            //   option is always used. Note that the 'directories' option
            //   has no effect but increases runtime, because only files are
            //   returned.
            //
            //output parameter:
            //ImageFiles: A tuple of all found image file names
            //
            if ((int)((new HTuple((new HTuple(hv_Extensions_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Extensions_COPY_INP_TMP.TupleEqual(""))))).TupleOr(new HTuple(hv_Extensions_COPY_INP_TMP.TupleEqual(
                "default")))) != 0)
            {
                hv_Extensions_COPY_INP_TMP = new HTuple();
                hv_Extensions_COPY_INP_TMP[0] = "ima";
                hv_Extensions_COPY_INP_TMP[1] = "tif";
                hv_Extensions_COPY_INP_TMP[2] = "tiff";
                hv_Extensions_COPY_INP_TMP[3] = "gif";
                hv_Extensions_COPY_INP_TMP[4] = "bmp";
                hv_Extensions_COPY_INP_TMP[5] = "jpg";
                hv_Extensions_COPY_INP_TMP[6] = "jpeg";
                hv_Extensions_COPY_INP_TMP[7] = "jp2";
                hv_Extensions_COPY_INP_TMP[8] = "jxr";
                hv_Extensions_COPY_INP_TMP[9] = "png";
                hv_Extensions_COPY_INP_TMP[10] = "pcx";
                hv_Extensions_COPY_INP_TMP[11] = "ras";
                hv_Extensions_COPY_INP_TMP[12] = "xwd";
                hv_Extensions_COPY_INP_TMP[13] = "pbm";
                hv_Extensions_COPY_INP_TMP[14] = "pnm";
                hv_Extensions_COPY_INP_TMP[15] = "pgm";
                hv_Extensions_COPY_INP_TMP[16] = "ppm";
                //
            }
            if ((int)(new HTuple(hv_ImageDirectory_COPY_INP_TMP.TupleEqual(""))) != 0)
            {
                hv_ImageDirectory_COPY_INP_TMP = ".";
            }
            HOperatorSet.GetSystem("image_dir", out hv_HalconImages);
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                hv_HalconImages = hv_HalconImages.TupleSplit(";");
            }
            else
            {
                hv_HalconImages = hv_HalconImages.TupleSplit(":");
            }
            hv_Directories = hv_ImageDirectory_COPY_INP_TMP.Clone();
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_HalconImages.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_Directories = hv_Directories.TupleConcat(((hv_HalconImages.TupleSelect(hv_Index)) + "/") + hv_ImageDirectory_COPY_INP_TMP);
            }
            HOperatorSet.TupleStrlen(hv_Directories, out hv_Length);
            HOperatorSet.TupleGenConst(new HTuple(hv_Length.TupleLength()), 0, out hv_network_drive);
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((((hv_Directories.TupleSelect(hv_Index))).TupleStrlen())).TupleGreater(1))) != 0)
                    {
                        HOperatorSet.TupleStrFirstN(hv_Directories.TupleSelect(hv_Index), 1, out hv_Substring);
                        if ((int)(new HTuple(hv_Substring.TupleEqual("//"))) != 0)
                        {
                            if (hv_network_drive == null)
                                hv_network_drive = new HTuple();
                            hv_network_drive[hv_Index] = 1;
                        }
                    }
                }
            }
            hv_ImageFiles = new HTuple();
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Directories.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                HOperatorSet.FileExists(hv_Directories.TupleSelect(hv_Index), out hv_FileExists);
                if ((int)(hv_FileExists) != 0)
                {
                    HOperatorSet.ListFiles(hv_Directories.TupleSelect(hv_Index), (new HTuple("files")).TupleConcat(
                        hv_Options), out hv_AllFiles);
                    hv_ImageFiles = new HTuple();
                    for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Extensions_COPY_INP_TMP.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                    {
                        HOperatorSet.TupleRegexpSelect(hv_AllFiles, (((".*" + (hv_Extensions_COPY_INP_TMP.TupleSelect(
                            hv_i))) + "$")).TupleConcat("ignore_case"), out hv_Selection);
                        hv_ImageFiles = hv_ImageFiles.TupleConcat(hv_Selection);
                    }
                    HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("\\\\")).TupleConcat(
                        "replace_all"), "/", out hv_ImageFiles);
                    if ((int)(hv_network_drive.TupleSelect(hv_Index)) != 0)
                    {
                        HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("//")).TupleConcat(
                            "replace_all"), "/", out hv_ImageFiles);
                        hv_ImageFiles = "/" + hv_ImageFiles;
                    }
                    else
                    {
                        HOperatorSet.TupleRegexpReplace(hv_ImageFiles, (new HTuple("//")).TupleConcat(
                            "replace_all"), "/", out hv_ImageFiles);
                    }

                    return;
                }
            }

            return;
        }

        ////圆与直线的交点
        //public static bool Circle_Inter_Line(CircleLineInterParam circleLineParam, out PointF intersection)
        //{
        //    intersection = new PointF();

        //    HTuple hv_InterRow = new HTuple(), hv_InterCol = new HTuple();
        //    HTuple hv_Dist1 = new HTuple(), hv_Dist2 = new HTuple();
        //    HTuple hv_Row = new HTuple(), hv_Col = new HTuple();

        //    try
        //    {
        //        Circle circle = new Circle();
        //        if (!FitCircle(circleLineParam.circleParam, out circle))
        //            return false;
        //        Line line = new Line();
        //        if (!FitLine(circleLineParam.lineParam, out line))
        //            return false;
        //        HOperatorSet.IntersectionLineCircle(line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol,  circle.dRow, circle.dCol, circle.dRadius,
        //                                            new HTuple(0), new HTuple(Math.PI * 2), "positive", out hv_InterRow, out hv_InterCol);
        //        if (1 >= hv_InterRow.TupleLength())
        //            return false;

        //        double dHalfRow = (hv_InterRow[0] + hv_InterRow[1]) / 2.0;
        //        double dHalfCol = (hv_InterCol[0] + hv_InterCol[1]) / 2.0;
        //        HOperatorSet.DistancePp(dHalfRow, dHalfCol, line.dStartRow, line.dStartCol, out hv_Dist1);
        //        HOperatorSet.DistancePp(dHalfRow, dHalfCol, line.dEndRow, line.dEndCol, out hv_Dist2);
        //        double dLineRow=0, dLineCol = 0;
        //        if (hv_Dist1.D > hv_Dist2.D)
        //        {
        //            dLineRow = line.dStartRow;
        //            dLineCol = line.dStartCol;
        //        }
        //        else
        //        {
        //            dLineRow = line.dEndRow;
        //            dLineCol = line.dEndCol;
        //        }
        //        HOperatorSet.IntersectionSegmentCircle(dLineRow, dLineCol, dHalfRow, dHalfCol, circle.dRow, circle.dCol, circle.dRadius,
        //                                            new HTuple(0), new HTuple(Math.PI * 2), "positive", out hv_Row, out hv_Col);
        //        if (1 != hv_Row.TupleLength())
        //            return false;
        //        intersection.X = (float)hv_Col.D;
        //        intersection.Y = (float)hv_Row.D;
        //        //显示
        //        //m_hWnd.DispObj(m_hImage);
        //        m_hWnd.SetColor("green");
        //        m_hWnd.DispCircle(circle.dRow, circle.dCol, circle.dRadius);
        //        m_hWnd.DispLine(dLineRow, dLineCol, dHalfRow, dHalfCol);
        //        m_hWnd.SetColor("red");
        //        m_hWnd.DispCross(hv_Row, hv_Col, 20, 0);
        //        return true; 
        //    }
        //    catch(HalconException error)
        //    {
        //        return false;
        //    }
        //    finally
        //    {

        //    }
        //}

        ////直线与直线的交点
        //public static bool Line_Inter_Line(LineLineInterParam lineLineParam, out PointP intersection)
        //{
        //    intersection = new PointP();
        //    HTuple hv_InterRow = new HTuple(), hv_InterCol = new HTuple(), hv_isParallel = new HTuple();

        //    try
        //    {
        //        Line line1 = new Line();
        //        if (!FitLine(lineLineParam.arrayLineParam[0], out line1))
        //            return false;
        //        Line line2 = new Line();
        //        if (!FitLine(lineLineParam.arrayLineParam[1], out line2))
        //            return false;
        //        HOperatorSet.IntersectionLl(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol,
        //                                    line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol, out hv_InterRow, out hv_InterCol, out hv_isParallel);
        //        if (1 != hv_InterRow.TupleLength())
        //            return false;
        //        intersection.dRow = hv_InterRow.D;
        //        intersection.dCol = hv_InterCol.D;
        //        //显示
        //        m_hWnd.SetColor("green");
        //        m_hWnd.DispLine(line1.dStartRow, line1.dStartCol, line1.dEndRow, line1.dEndCol);
        //        m_hWnd.DispLine(line2.dStartRow, line2.dStartCol, line2.dEndRow, line2.dEndCol);
        //        m_hWnd.SetColor("red");
        //        m_hWnd.DispCross(hv_InterRow, hv_InterCol, 40, 0);

        //        return true;

        //    }
        //    catch(HalconException error)
        //    {
        //        ErrorPrinter.WriteLine(string.Format("直线与直线的交点计算出错！錯誤信息：{0}", error.Message), ETraceDisplay.LISTBOX);
        //        return false;
        //    }
        //}

        public void set_display_font(HTuple hv_Size, HTuple hv_Font, HTuple hv_Bold, HTuple hv_Slant)
        {
            HTuple hv_OS = null, hv_Fonts = new HTuple();
            HTuple hv_Style = null, hv_Exception = new HTuple(), hv_AvailableFonts = null;
            HTuple hv_Fdx = null, hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            //
            //Input parameters:
            //WindowHandle: The graphics window for which the font will be set
            //Size: The font size. If Size=-1, the default of 16 is used.
            //Bold: If set to 'true', a bold font is used
            //Slant: If set to 'true', a slanted font is used
            //
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            {
                hv_Size_COPY_INP_TMP = 16;
            }
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                //Restore previous behaviour
                hv_Size_COPY_INP_TMP = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt();
            }
            else
            {
                hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP.TupleInt();
            }
            if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
            {
                hv_Fonts = new HTuple();
                hv_Fonts[0] = "Courier";
                hv_Fonts[1] = "Courier 10 Pitch";
                hv_Fonts[2] = "Courier New";
                hv_Fonts[3] = "CourierNew";
                hv_Fonts[4] = "Liberation Mono";
            }
            else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
            {
                hv_Fonts = new HTuple();
                hv_Fonts[0] = "Consolas";
                hv_Fonts[1] = "Menlo";
                hv_Fonts[2] = "Courier";
                hv_Fonts[3] = "Courier 10 Pitch";
                hv_Fonts[4] = "FreeMono";
                hv_Fonts[5] = "Liberation Mono";
            }
            else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
            {
                hv_Fonts = new HTuple();
                hv_Fonts[0] = "Luxi Sans";
                hv_Fonts[1] = "DejaVu Sans";
                hv_Fonts[2] = "FreeSans";
                hv_Fonts[3] = "Arial";
                hv_Fonts[4] = "Liberation Sans";
            }
            else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
            {
                hv_Fonts = new HTuple();
                hv_Fonts[0] = "Times New Roman";
                hv_Fonts[1] = "Luxi Serif";
                hv_Fonts[2] = "DejaVu Serif";
                hv_Fonts[3] = "FreeSerif";
                hv_Fonts[4] = "Utopia";
                hv_Fonts[5] = "Liberation Serif";
            }
            else
            {
                hv_Fonts = hv_Font_COPY_INP_TMP.Clone();
            }
            hv_Style = "";
            if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
            {
                hv_Style = hv_Style + "Bold";
            }
            else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
            {
                hv_Exception = "Wrong value of control parameter Bold";
                throw new HalconException(hv_Exception);
            }
            if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
            {
                hv_Style = hv_Style + "Italic";
            }
            else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
            {
                hv_Exception = "Wrong value of control parameter Slant";
                throw new HalconException(hv_Exception);
            }
            if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
            {
                hv_Style = "Normal";
            }
            HOperatorSet.QueryFont(m_hWnd, out hv_AvailableFonts);
            hv_Font_COPY_INP_TMP = "";
            for (hv_Fdx = 0; (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1); hv_Fdx = (int)hv_Fdx + 1)
            {
                hv_Indices = hv_AvailableFonts.TupleFind(hv_Fonts.TupleSelect(hv_Fdx));
                if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(0))) != 0)
                {
                    if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                    {
                        hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_Fdx);
                        break;
                    }
                }
            }
            if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
            {
                throw new HalconException("Wrong value of control parameter Font");
            }
            hv_Font_COPY_INP_TMP = (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
            HOperatorSet.SetFont(m_hWnd, hv_Font_COPY_INP_TMP);

            return;
        }

        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
       HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {

            // Local iconic variables 

            // Local control variables 

            HTuple hv_GenParamName = null, hv_GenParamValue = null;
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_CoordSystem_COPY_INP_TMP = hv_CoordSystem.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Column: The column coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically...
            //   - if |Row| == |Column| == 1: for each new textline
            //   = else for each text position.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow
            //       otherwise -> use given string as color string for the shadow color
            //
            //It is possible to display multiple text strings in a single call.
            //In this case, some restrictions apply:
            //- Multiple text positions can be defined by specifying a tuple
            //  with multiple Row and/or Column coordinates, i.e.:
            //  - |Row| == n, |Column| == n
            //  - |Row| == n, |Column| == 1
            //  - |Row| == 1, |Column| == n
            //- If |Row| == |Column| == 1,
            //  each element of String is display in a new textline.
            //- If multiple positions or specified, the number of Strings
            //  must match the number of positions, i.e.:
            //  - Either |String| == n (each string is displayed at the
            //                          corresponding position),
            //  - or     |String| == 1 (The string is displayed n times).
            //
            //
            //Convert the parameters for disp_text.
            if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
            {

                return;
            }
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            //
            //Convert the parameter Box to generic parameters.
            hv_GenParamName = new HTuple();
            hv_GenParamValue = new HTuple();
            hv_GenParamName = hv_GenParamName.TupleConcat("box");
            hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
            //if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
            //{
            //    if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
            //    {
            //        //Display no box
            //        hv_GenParamName = hv_GenParamName.TupleConcat("box");
            //        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
            //    }
            //    else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual("true"))) != 0)
            //    {
            //        //Set a color other than the default.
            //        hv_GenParamName = hv_GenParamName.TupleConcat("box_color");
            //        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(0));
            //    }
            //}
            //if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
            //{
            //    if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
            //    {
            //        //Display no shadow.
            //        hv_GenParamName = hv_GenParamName.TupleConcat("shadow");
            //        hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
            //    }
            //    else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual("true"))) != 0)
            //    {
            //        //Set a shadow color other than the default.
            //        hv_GenParamName = hv_GenParamName.TupleConcat("shadow_color");
            //        hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(1));
            //    }
            //}
            //Restore default CoordSystem behavior.
            if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
            {
                hv_CoordSystem_COPY_INP_TMP = "image";
            }
            //
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
            {
                //disp_text does not accept an empty string for Color.
                hv_Color_COPY_INP_TMP = new HTuple();
            }
            //
            HOperatorSet.DispText(hv_WindowHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                    hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, "box",
                    hv_GenParamValue);

            return;
        }

        /// <summary>
        /// 字符显示设置
        /// </summary>
        /// <param name="nFontSize"></param> 字体大小
        /// <param name="nRowSite"></param> 字体显示位置Row
        /// <param name="nColSite"></param> 字体显示位置Col
        /// <param name="str"></param>      要显示的字符
        /// <param name="color"></param>    显示的颜色
        /// <param name="bBold"></param>    是否加粗
        /// <param name="bBox"></param>     是否背景填充
        public void WriteStringtoImage(int nFontSize, object nRowSite, object nColSite, string str, string color = "green", string strEnglish = "", bool bBold = false, bool bBox = false)
        {
            HTuple hv_Font = new HTuple();

            try
            {

                //设置字体大小
                // hv_Font = m_hWnd.QueryFont();
                // hv_FontWithSize = HTuple(hv_Font[0]) + "20-";
                // HTuple strFontWithSize = hv_Font[0];

                // strFontWithSize = strFontWithSize + nFontSize.ToString()+"-";
                //* -*-0-0-1-0-GB2312_CHARSET-
                //*-*-0-[下划线]-[中划线]-[粗体]-[编码格式]    

                string strFontWithSize = "-Microsoft YaHei UI-" + nFontSize + " * -*-0-0-0-0-GB2312_CHARSET-";
                if (bBold)
                {
                    strFontWithSize = "-Microsoft YaHei UI-" + nFontSize + " * -*-0-1-0-1-GB2312_CHARSET-";
                }
                m_hWnd.SetFont(strFontWithSize);

                //if(bBox)
                //{
                //    disp_message(m_hWnd, str, "image", nRowSite, nColSite, color, "true");
                //}
                //else
                //{
                //设置字体显示的位置
                m_hWnd.SetTposition(Convert.ToInt32(nRowSite), Convert.ToInt32(nColSite));
                // 字体内容
                m_hWnd.SetColor(color);
                m_hWnd.WriteString(str);
                //}
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                //ErrorPrinter.WriteLine(string.Format("显示字符出错！错误信息：{0}", error.Message), ETraceDisplay.LISTBOX);
            }
            m_hWnd.SetLineWidth(1);
            return;
        }
        #endregion

        #region 标定
        /*圆点标定板*/
        public bool CirclePointCalib(CirclePointCalibParam param, out double dMeanDiam, out CalibrateResult calibResult)
        {
            dMeanDiam = 0;
            calibResult = new CalibrateResult();

            HTuple hv_DiamVal = new HTuple(), hv_areas = new HTuple(), hv_areaDiff = new HTuple();
            HTuple hv_area = new HTuple(), hv_row = new HTuple(), hv_column = new HTuple();

            HObject ho_Region = null, ho_SelectedRegions = null, ho_UnionRegions = null;
            HObject ho_RegionDilaX = null, ho_RegionDilaXConnect = null;
            HObject ho_SelObj = null, ho_RegionInter = null, ho_SortRegion = null;
            HObject ho_RegionDilaY = null;

            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_UnionRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionDilaX);
            HOperatorSet.GenEmptyObj(out ho_RegionDilaXConnect);
            HOperatorSet.GenEmptyObj(out ho_SelObj);
            HOperatorSet.GenEmptyObj(out ho_RegionInter);
            HOperatorSet.GenEmptyObj(out ho_SortRegion);
            HOperatorSet.GenEmptyObj(out ho_RegionDilaY);

            try
            {
                HTuple hv_channels = new HTuple();
                HOperatorSet.CountChannels(m_hImage, out hv_channels);
                if (1 != hv_channels.I)
                    HOperatorSet.Rgb1ToGray(m_hImage, out m_hImage);
                HOperatorSet.Threshold(m_hImage, out ho_Region, 0, param.nThd);
                HOperatorSet.Connection(ho_Region, out ho_Region);
                if (param.dCircularity > 1)
                    param.dCircularity = 1;
                HOperatorSet.SelectShape(ho_Region, out ho_SelectedRegions, "circularity", "and", param.dCircularity, 1);
                HOperatorSet.RegionFeatures(ho_SelectedRegions, "area", out hv_areas);
                HTuple hv_max = hv_areas.TupleMax();
                HTuple hv_min = hv_areas.TupleMin();
                HOperatorSet.TupleDifference(hv_areas, hv_max.TupleConcat(hv_min), out hv_areaDiff);
                double dAreaMean = hv_areaDiff.TupleMean();
                HOperatorSet.SelectShape(ho_SelectedRegions, out ho_SelectedRegions, "area", "and", dAreaMean * 0.8, dAreaMean * 2);
                HOperatorSet.RegionFeatures(ho_SelectedRegions, "max_diameter", out hv_DiamVal);
                m_hWnd.DispObj(m_hImage);
                m_hWnd.DispObj(ho_SelectedRegions);
                dMeanDiam = (param.dCircleDiam / hv_DiamVal).TupleMean();
                //
                HOperatorSet.Union1(ho_SelectedRegions, out ho_UnionRegions);
                //计算X方向的圆点间距
                HOperatorSet.DilationRectangle1(ho_UnionRegions, out ho_RegionDilaX, imageWidth / 2, 1);
                HOperatorSet.Connection(ho_RegionDilaX, out ho_RegionDilaXConnect);
                int nCol = ho_RegionDilaXConnect.CountObj();
                HTuple hv_xLen = new HTuple();
                for (int i = 1; i < nCol; i++)
                {
                    HOperatorSet.SelectObj(ho_RegionDilaXConnect, out ho_SelObj, i);
                    HOperatorSet.Intersection(ho_SelectedRegions, ho_SelObj, out ho_RegionInter);
                    HOperatorSet.SortRegion(ho_RegionInter, out ho_SortRegion, "first_point", "true", "column");
                    HOperatorSet.AreaCenter(ho_SortRegion, out hv_area, out hv_row, out hv_column);
                    for (int j = 0; j < hv_column.TupleLength() - 2; j++)
                    {
                        double dXLen = Math.Sqrt(Math.Pow((hv_column[j + 1] - hv_column[j]), 2) + Math.Pow((hv_row[j + 1] - hv_row[j]), 2));
                        hv_xLen = hv_xLen.TupleConcat(dXLen);
                    }
                }
                calibResult.dXCalib = param.dCircleSpace / hv_xLen.TupleMean();
                //计算Y方向的圆点间距
                HOperatorSet.DilationRectangle1(ho_SelectedRegions, out ho_RegionDilaY, 1, imageHeight / 2);
                HOperatorSet.Connection(ho_RegionDilaY, out ho_RegionDilaY);
                int nRow = ho_RegionDilaY.CountObj();
                HTuple hv_yLen = new HTuple();
                for (int m = 1; m < nRow; m++)
                {
                    HOperatorSet.SelectObj(ho_RegionDilaY, out ho_SelObj, m);
                    HOperatorSet.Intersection(ho_SelectedRegions, ho_SelObj, out ho_RegionInter);
                    ho_SortRegion.Dispose();
                    HOperatorSet.SortRegion(ho_RegionInter, out ho_SortRegion, "first_point", "true", "row");
                    HOperatorSet.AreaCenter(ho_SortRegion, out hv_area, out hv_row, out hv_column);
                    for (int n = 0; n < hv_row.TupleLength() - 2; n++)
                    {
                        double dYLen = Math.Sqrt(Math.Pow((hv_column[n + 1] - hv_column[n]), 2) + Math.Pow((hv_row[n + 1] - hv_row[n]), 2));
                        hv_yLen = hv_yLen.TupleConcat(dYLen);
                    }
                }
                calibResult.dYCalib = param.dCircleSpace / hv_yLen.TupleMean();
                return true;
            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_Region) ho_Region.Dispose();
                if (null != ho_SelectedRegions) ho_SelectedRegions.Dispose();
                if (null != ho_UnionRegions) ho_UnionRegions.Dispose();
                if (null != ho_RegionDilaX) ho_RegionDilaX.Dispose();
                if (null != ho_RegionDilaXConnect) ho_RegionDilaXConnect.Dispose();
                if (null != ho_SelObj) ho_SelObj.Dispose();
                if (null != ho_RegionInter) ho_RegionInter.Dispose();
                if (null != ho_SortRegion) ho_SortRegion.Dispose();
                if (null != ho_RegionDilaY) ho_RegionDilaY.Dispose();
            }
        }
        /*棋盘格标定*/
        public bool CheckerCalib(CheckerCalibParam param, out CalibrateResult calibResult)
        {
            calibResult = new CalibrateResult();

            HObject ho_Region = null, ho_RegionOpening = null, ho_ConnectedRegions = null;
            HObject ho_SelectedRegions = null, ho_SortedRegions = null, ho_ObjectSelected = null;

            HTuple hv_Number = new HTuple(), hv_Areas = new HTuple(), hv_AreaDiff = new HTuple();
            HTuple hv_Dist1 = new HTuple(), hv_Dist2 = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SortedRegions);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);

            try
            {
                HOperatorSet.Threshold(m_hImage, out ho_Region, 0, param.nThreshold);
                HOperatorSet.OpeningCircle(ho_Region, out ho_RegionOpening, 2);
                HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
                HOperatorSet.RegionFeatures(ho_ConnectedRegions, "area", out hv_Areas);
                HTuple hv_max = hv_Areas.TupleMax();
                HTuple hv_Min = hv_Areas.TupleMin();
                HOperatorSet.TupleDifference(hv_Areas, hv_max.TupleConcat(hv_Min), out hv_AreaDiff);
                HTuple hv_AreaMean = hv_AreaDiff.TupleMean();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, new HTuple("rectangularity").TupleConcat("area"), "and",
                                                                                      new HTuple(param.dRectangularity).TupleConcat(hv_AreaMean * 0.8),
                                                                                      new HTuple(1).TupleConcat(hv_AreaMean * 2));
                HOperatorSet.ShapeTrans(ho_SelectedRegions, out ho_SelectedRegions, "rectangle2");
                HOperatorSet.CountObj(ho_SelectedRegions, out hv_Number);
                if (0 == hv_Number.I)
                    return false;
                HOperatorSet.SortRegion(ho_SelectedRegions, out ho_SortedRegions, "first_point", "true", "row");

                HTuple hv_x_Len = new HTuple();
                HTuple hv_y_Len = new HTuple();

                for (int i = 1; i <= hv_Number.I; i++)
                {
                    HOperatorSet.SelectObj(ho_SortedRegions, out ho_ObjectSelected, i);
                    if (1 == ho_ObjectSelected.CountObj())
                    {
                        HOperatorSet.RegionFeatures(ho_ObjectSelected, "rect2_len1", out hv_Dist1);
                        HOperatorSet.RegionFeatures(ho_ObjectSelected, "rect2_len2", out hv_Dist2);
                        hv_x_Len = (hv_x_Len.TupleConcat(2.0 * hv_Dist1));
                        hv_y_Len = (hv_y_Len.TupleConcat(2.0 * hv_Dist2));
                    }
                }
                if (0 == hv_x_Len.TupleLength())
                    return false;
                calibResult.dXCalib = param.dLength / (hv_x_Len.TupleMean().D);
                calibResult.dYCalib = param.dLength / (hv_y_Len.TupleMean().D);
                //显示
                m_hWnd.DispObj(m_hImage);
                m_hWnd.DispObj(ho_SortedRegions);

                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_Region) ho_Region.Dispose();
                if (null != ho_RegionOpening) ho_RegionOpening.Dispose();
                if (null != ho_ConnectedRegions) ho_ConnectedRegions.Dispose();
                if (null != ho_SelectedRegions) ho_SelectedRegions.Dispose();
                if (null != ho_SortedRegions) ho_SortedRegions.Dispose();
                if (null != ho_ObjectSelected) ho_ObjectSelected.Dispose();
            }
        }
        /*二维码标定*/
        public bool BarCode2DCalib(Code2DCalibParam param, out CalibrateResult calibResult)
        {
            calibResult = new CalibrateResult();

            HTuple hv_width = new HTuple(), hv_height = new HTuple();
            HTuple hv_DataCodeHandle = new HTuple(), hv_ResultHandles = new HTuple(), hv_DecodedDataString = new HTuple();
            HTuple hv_TupleNum = new HTuple(), hv_area = new HTuple(), hv_row = new HTuple(), hv_column = new HTuple(), hv_pointOrder = new HTuple();
            HTuple hv_indices = new HTuple(), hv_dist = new HTuple(), hv_SubString = new HTuple(), hv_SubString1 = new HTuple();
            HTuple hv_BarCodeDist = new HTuple();

            HObject ho_SymbolXlds = null, ho_SymbolRegion = null, ho_HRegion = null, ho_HSortRegion = null;
            HObject ho_VRegion = null, ho_VSortRegion = null;
            HObject ho_selectObj = null, ho_ReiongInter = null, ho_ImgReduced = null;

            HOperatorSet.GenEmptyObj(out ho_SymbolXlds);
            HOperatorSet.GenEmptyObj(out ho_SymbolRegion);
            HOperatorSet.GenEmptyObj(out ho_HRegion);
            HOperatorSet.GenEmptyObj(out ho_HSortRegion);
            HOperatorSet.GenEmptyObj(out ho_VRegion);
            HOperatorSet.GenEmptyObj(out ho_VSortRegion);
            HOperatorSet.GenEmptyObj(out ho_selectObj);
            HOperatorSet.GenEmptyObj(out ho_ReiongInter);
            HOperatorSet.GenEmptyObj(out ho_ImgReduced);

            try
            {
                HOperatorSet.GetImageSize(m_hImage, out hv_width, out hv_height);
                HOperatorSet.CreateDataCode2dModel(param.strCodeType, new HTuple(), new HTuple(), out hv_DataCodeHandle);
                HOperatorSet.FindDataCode2d(m_hImage, out ho_SymbolXlds, hv_DataCodeHandle, "stop_after_result_num", 99, out hv_ResultHandles, out hv_DecodedDataString);
                if (0 == ho_SymbolXlds.CountObj())
                    return false;
                HOperatorSet.AreaCenterXld(ho_SymbolXlds, out hv_area, out hv_row, out hv_column, out hv_pointOrder);
                for (int i = 0; i < ho_SymbolXlds.CountObj(); i++)
                {
                    m_hWnd.SetTposition(hv_row.TupleSelect(i).TupleInt().I, hv_column.TupleSelect(i).TupleInt().I);
                    m_hWnd.WriteString(hv_DecodedDataString.TupleSelect(i));
                }
                m_hWnd.DispObj(ho_SymbolXlds);
                HOperatorSet.GenRegionContourXld(ho_SymbolXlds, out ho_SymbolRegion, "filled");
                HOperatorSet.Union1(ho_SymbolRegion, out ho_SymbolRegion);
                HOperatorSet.DilationRectangle1(ho_SymbolRegion, out ho_HRegion, hv_width, 40);
                HOperatorSet.Connection(ho_HRegion, out ho_HRegion);
                HOperatorSet.SortRegion(ho_HRegion, out ho_HSortRegion, "first_point", "true", "row");
                //X方向
                HTuple hv_xCalib = new HTuple();
                for (int i = 1; i <= ho_HSortRegion.CountObj(); i++)
                {
                    ho_SymbolXlds.Dispose();
                    hv_ResultHandles = new HTuple();
                    hv_DecodedDataString = new HTuple();
                    HOperatorSet.SelectObj(ho_HSortRegion, out ho_selectObj, i);
                    //  m_hWnd.DispObj(ho_selectObj);
                    HOperatorSet.ReduceDomain(m_hImage, ho_selectObj, out ho_ImgReduced);
                    HOperatorSet.FindDataCode2d(ho_ImgReduced, out ho_SymbolXlds, hv_DataCodeHandle, "stop_after_result_num", 3, out hv_ResultHandles, out hv_DecodedDataString);
                    if (1 >= hv_DecodedDataString.TupleLength())
                        return false;
                    HOperatorSet.TupleNumber(hv_DecodedDataString, out hv_TupleNum);
                    HOperatorSet.AreaCenterXld(ho_SymbolXlds, out hv_area, out hv_row, out hv_column, out hv_pointOrder);
                    HOperatorSet.TupleSortIndex(hv_column, out hv_indices);
                    for (int n = 0; n < hv_column.TupleLength() - 1; n++)
                    {

                        HOperatorSet.DistancePp(hv_row.TupleSelect(hv_indices[n]), hv_column.TupleSelect(hv_indices[n]),
                                                hv_row.TupleSelect(hv_indices[n + 1]), hv_column.TupleSelect(hv_indices[n + 1]), out hv_dist);
                        HOperatorSet.TupleSplit(hv_DecodedDataString.TupleSelect(hv_indices[n]), ",", out hv_SubString);
                        HOperatorSet.TupleSplit(hv_DecodedDataString.TupleSelect(hv_indices[n + 1]), ",", out hv_SubString1);
                        HOperatorSet.TupleNumber(hv_SubString, out hv_SubString);
                        HOperatorSet.TupleNumber(hv_SubString1, out hv_SubString1);
                        HOperatorSet.DistancePp(hv_SubString[0].D, hv_SubString[1].D, hv_SubString1[0].D, hv_SubString1[1].D, out hv_BarCodeDist);
                        hv_xCalib = hv_xCalib.TupleConcat(hv_BarCodeDist / hv_dist);
                    }
                }
                if (1 == ho_HSortRegion.CountObj())
                {
                    calibResult.dXCalib = hv_xCalib.TupleMean().D;
                    calibResult.dYCalib = calibResult.dXCalib;
                    return true;
                }
                //Y方向
                HOperatorSet.DilationRectangle1(ho_SymbolRegion, out ho_VRegion, 40, hv_height);
                HOperatorSet.Connection(ho_VRegion, out ho_VRegion);
                HOperatorSet.SortRegion(ho_VRegion, out ho_VSortRegion, "first_point", "true", "col");
                HTuple hv_yCalib = new HTuple();
                for (int i = 1; i <= ho_VSortRegion.CountObj(); i++)
                {
                    ho_SymbolXlds.Dispose();
                    hv_ResultHandles = new HTuple();
                    hv_DecodedDataString = new HTuple();
                    HOperatorSet.SelectObj(ho_VSortRegion, out ho_selectObj, i);
                    // m_hWnd.DispObj(ho_selectObj);
                    HOperatorSet.ReduceDomain(m_hImage, ho_selectObj, out ho_ImgReduced);
                    HOperatorSet.FindDataCode2d(ho_ImgReduced, out ho_SymbolXlds, hv_DataCodeHandle, "stop_after_result_num", 3, out hv_ResultHandles, out hv_DecodedDataString);
                    if (1 >= hv_DecodedDataString.TupleLength())
                        return false;
                    HOperatorSet.TupleNumber(hv_DecodedDataString, out hv_TupleNum);
                    HOperatorSet.AreaCenterXld(ho_SymbolXlds, out hv_area, out hv_row, out hv_column, out hv_pointOrder);
                    HOperatorSet.TupleSortIndex(hv_row, out hv_indices);
                    for (int n = 0; n < hv_row.TupleLength() - 1; n++)
                    {

                        HOperatorSet.DistancePp(hv_row.TupleSelect(hv_indices[n]), hv_column.TupleSelect(hv_indices[n]),
                                                hv_row.TupleSelect(hv_indices[n + 1]), hv_column.TupleSelect(hv_indices[n + 1]), out hv_dist);
                        HOperatorSet.TupleSplit(hv_DecodedDataString.TupleSelect(hv_indices[n]), ",", out hv_SubString);
                        HOperatorSet.TupleSplit(hv_DecodedDataString.TupleSelect(hv_indices[n + 1]), ",", out hv_SubString1);
                        HOperatorSet.TupleNumber(hv_SubString, out hv_SubString);
                        HOperatorSet.TupleNumber(hv_SubString1, out hv_SubString1);
                        HOperatorSet.DistancePp(hv_SubString[0].D, hv_SubString[1].D, hv_SubString1[0].D, hv_SubString1[1].D, out hv_BarCodeDist);
                        hv_yCalib = hv_yCalib.TupleConcat(hv_BarCodeDist / hv_dist);
                    }
                }
                calibResult.dXCalib = hv_xCalib.TupleMean().D;
                calibResult.dYCalib = hv_yCalib.TupleMean().D;
                return true;

            }
            catch (HalconException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_SymbolXlds) ho_SymbolXlds.Dispose();
                if (null != ho_SymbolRegion) ho_SymbolRegion.Dispose();
                if (null != ho_HRegion) ho_HRegion.Dispose();
                if (null != ho_HSortRegion) ho_HSortRegion.Dispose();
                if (null != ho_VRegion) ho_VRegion.Dispose();
                if (null != ho_VSortRegion) ho_VSortRegion.Dispose();
                if (null != ho_selectObj) ho_selectObj.Dispose();
                if (null != ho_ReiongInter) ho_ReiongInter.Dispose();
                if (null != ho_ImgReduced) ho_ImgReduced.Dispose();
            }

        }

        public static bool LocateCalib(double[] dCol, double[] dRow, //9 Image Point
                                       double[] dX, double[] dY,     //9 machine point 
                                       double[] homMat2d)
        {
            homMat2d = new double[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            HTuple hv_Col = new HTuple(), hv_Row = new HTuple(), hv_X = new HTuple(), hv_Y = new HTuple();
            HTuple hv_homMat2d = new HTuple();
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    hv_Col[i] = dCol[i];
                    hv_Row[i] = dRow[i];
                    hv_X[i] = dX[i];
                    hv_Y[i] = dY[i];
                }
                HOperatorSet.VectorToHomMat2d(hv_Col, hv_Row, hv_X, hv_Y, out hv_homMat2d);
                if (hv_homMat2d.TupleLength() != 0)
                {
                    for (int i = 0; i < hv_homMat2d.TupleLength(); i++)
                    {
                        homMat2d[i] = hv_homMat2d[i];
                    }
                }
                return true;
            }
            catch (System.Exception error)
            {
                MessageBox.Show("错误：" + error.ToString(), "Error:" + error.ToString());
                return false;
            }
        }
        #endregion

        public void SetImageSize(int width, int height)
        {
            imageWidth = width;
            imageHeight = height;
        }
        public void GetImage(byte[] imageData)
        {
            try
            {
                if (imageData == null || imageData.Length < 1)
                    throw new Exception(string.Format("图像数据转换失败！原因：图像数据为空！"));

                if (m_hImage == null)
                    m_hImage = new HObject();

                GCHandle gc = GCHandle.Alloc(imageData, GCHandleType.Pinned);
                IntPtr ptr = gc.AddrOfPinnedObject();

                if (gc.IsAllocated)
                {
                    gc.Free();
                }

                m_hImage.Dispose();
                HOperatorSet.GenImage1(out m_hImage, "byte", imageWidth, imageHeight, ptr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetImage(byte[] imageData, HWindowControl hWndCtrl)
        {
            try
            {
                if (imageData == null || imageData.Length < 1)
                    throw new Exception(string.Format("图像数据转换失败！原因：图像数据为空！"));

                if (m_hImage == null)
                    m_hImage = new HObject();

                GCHandle gc = GCHandle.Alloc(imageData, GCHandleType.Pinned);
                IntPtr ptr = gc.AddrOfPinnedObject();

                if (gc.IsAllocated)
                {
                    gc.Free();
                }

                m_hImage.Dispose();
                HOperatorSet.GenImage1(out m_hImage, "byte", imageWidth, imageHeight, ptr);

                double dReslutRow0 = 0, dReslutCol0 = 0, dReslutRow1 = 0, dReslutCol1 = 0;
                FitImageToWindow(ref dReslutRow0, ref dReslutCol0, ref dReslutRow1, ref dReslutCol1);
                //ShowImages(dReslutRow0, dReslutCol0, dReslutRow1, dReslutCol1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region 矩形1
        public Rect1 DrawRect1()
        {
            Rect1 rect1 = new Rect1();
            HOperatorSet.GenEmptyObj(out HObject ho_Rect1);

            HTuple hRectRow1 = new HTuple(), hRectCol1 = new HTuple(), hRectRow2 = new HTuple(), hRectCol2 = new HTuple();
            try
            {
                if (null == m_hWnd || null == m_hImage) return rect1;
                m_hWnd.DispObj(m_hImage);
                HOperatorSet.DrawRectangle1(m_hWnd, out hRectRow1, out hRectCol1, out hRectRow2, out hRectCol2);
                ho_Rect1.Dispose();
                HOperatorSet.GenRectangle1(out ho_Rect1, hRectRow1, hRectCol1, hRectRow2, hRectCol2);
                DispRegion(ho_Rect1);
                if (0 != ho_Rect1.CountObj())
                {
                    rect1.dRectRow1 = hRectRow1.D;
                    rect1.dRectCol1 = hRectCol1.D;
                    rect1.dRectRow2 = hRectRow2.D;
                    rect1.dRectCol2 = hRectCol2.D;
                }
                return rect1;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                ho_Rect1?.Dispose();
            }
            return rect1;
        }
        public void ShowRect1(Rect1 rect1)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Rect1);
            try
            {
                ho_Rect1.Dispose();
                HOperatorSet.GenRectangle1(out ho_Rect1, rect1.dRectRow1, rect1.dRectCol1, rect1.dRectRow2, rect1.dRectCol2);
                DispRegion(ho_Rect1, lineWidth: 2);
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
            }
            finally
            {
                ho_Rect1?.Dispose();
            }
        }
        #endregion

        #region 矩形2
        /// <summary>
        /// 绘制矩形2
        /// </summary>
        /// <returns></returns>返回矩形2的中心点和四个角点
        public Rect2 DrawRect2()
        {
            Rect2 rect2 = new Rect2();
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);

            HTuple hRect2Row = new HTuple(), hRect2Col = new HTuple(), hPhi = new HTuple(), hLength1 = new HTuple(), hLength2 = new HTuple();

            try
            {
                if (null == m_hImage || null == m_hWnd) return rect2;
                m_hWnd.DispObj(m_hImage);
                if (GlobalData.Config._language == EnumData.Language.english)
                {
                    WriteStringtoImage(20, 30, 30, "Please click the left mouse button to start drawing the detection area, and click the right mouse button to end", "red");
                }
                else
                {
                    WriteStringtoImage(20, 30, 30, "请点击鼠标左键开始绘制检测区域，点击鼠标右键结束", "red");
                }

                HOperatorSet.DrawRectangle2(m_hWnd, out hRect2Row, out hRect2Col, out hPhi, out hLength1, out hLength2);
                ho_Rect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_Rect2, hRect2Row, hRect2Col, hPhi, hLength1, hLength2);
                DispRegion(ho_Rect2);
                if (0 != ho_Rect2.CountObj())
                {
                    rect2.dRect2Row = hRect2Row.D;
                    rect2.dRect2Col = hRect2Col.D;
                    rect2.dPhi = hPhi.D;
                    rect2.dLength1 = hLength1.D;
                    rect2.dLength2 = hLength2.D;
                }
                return rect2;
            }
            catch (HalconException ex)
            {
                MessageBox.Show(ex.ToString());
                rect2.dRect2Row = 0;
                rect2.dRect2Col = 0;
                rect2.dPhi = 0;
                rect2.dLength1 = 0;
                rect2.dLength2 = 0;
                return rect2;
            }
            finally
            {
                if (null != ho_Rect2) ho_Rect2.Dispose();
            }
        }
        /// <summary>
        /// 显示矩形2
        /// </summary>
        /// <param name="rect2"></param>
        public void ShowRect2(Rect2 rect2, string strColor = "green")
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);
            try
            {
                ho_Rect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_Rect2, rect2.dRect2Row, rect2.dRect2Col, rect2.dPhi, rect2.dLength1, rect2.dLength2);
                DispRegion(ho_Rect2, strColor, lineWidth: 2);
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
            }
            finally
            {
                ho_Rect2?.Dispose();
            }
        }
        /// <summary>
        /// 获取矩形2的四个角点坐标
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="pionts"></param>（row,col）顺序依次为：左上、右上、右下、左下
        /// <returns></returns>
        public bool GetRect2CornerPoint(Rect2 rect, out PointF[] pionts)
        {
            pionts = new PointF[4]; //顺序：左上角、右上角、右下角、
            try
            {
                //
                double dCos = Math.Cos(rect.dPhi);
                double dSin = Math.Sin(rect.dPhi);
                //左上角
                double a = ((-rect.dLength1) * dCos) - (rect.dLength2 * dSin);
                double b = ((-rect.dLength1) * dSin) + (rect.dLength2 * dCos);
                pionts[0] = new PointF((float)(rect.dRect2Row - b), (float)(rect.dRect2Col + a));
                //右上角
                double c = (rect.dLength1 * dCos) - (rect.dLength2 * dSin);
                double d = (rect.dLength1 * dSin) + (rect.dLength2 * dCos);
                pionts[1] = new PointF((float)(rect.dRect2Row - d), (float)(rect.dRect2Col + c));
                //右下角
                double e = (rect.dLength1 * dCos) + (rect.dLength2 * dSin);
                double f = (rect.dLength1 * dSin) - (rect.dLength2 * dCos);
                pionts[2] = new PointF((float)(rect.dRect2Row - f), (float)(rect.dRect2Col + e));
                //左下角
                double g = ((-rect.dLength1) * dCos) + (rect.dLength2 * dSin);
                double h = ((-rect.dLength1) * dSin) - (rect.dLength2 * dCos);
                pionts[3] = new PointF((float)(rect.dRect2Row - h), (float)(rect.dRect2Col + g));
                return true;
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage($"GetRect2CornerPoint: {error}");
                return false;
            }
        }
        /// <summary>
        /// 将矩形2的phi变换为水平正向方向，宽为length1,高为length2
        /// </summary>
        /// <param name="rect2"></param>
        /// <returns></returns>
        public bool Rect2Trans(ref Rect2 rect2)
        {
            try
            {
                if (rect2.dLength1 == 0)
                {
                    return false;
                }
                if (rect2.dPhi < 0)
                {
                    rect2.dPhi = Math.PI + rect2.dPhi;
                }
                if (rect2.dPhi > (Math.PI / 4 * 3) && rect2.dPhi <= Math.PI)
                {
                    rect2.dPhi = rect2.dPhi - Math.PI;
                }
                else if (rect2.dPhi >= Math.PI / 4 && rect2.dPhi <= (Math.PI / 4 * 3))
                {
                    double dTemp = rect2.dLength1;
                    rect2.dLength1 = rect2.dLength2;
                    rect2.dLength2 = dTemp;
                    rect2.dPhi = rect2.dPhi - Math.PI / 2;
                }
                else if (rect2.dPhi <= (Math.PI / 2 + Math.PI / 12) && rect2.dPhi >= (Math.PI / 2 - Math.PI / 12))
                {
                    double dTemp = rect2.dLength1;
                    rect2.dLength1 = rect2.dLength2;
                    rect2.dLength2 = dTemp;
                    rect2.dPhi = rect2.dPhi - Math.PI / 2;
                }
                //else if (rect2.dPhi <= (Math.PI / 12) && rect2.dPhi >= (-Math.PI / 12))
                //{
                //    rect2.dPhi = 0;
                //}
                return true;
            }
            catch (SystemException error)
            {
                MessageFun.ShowMessage(error.ToString());
                return false;
            }

        }
        /// <summary>
        /// 显示所有矩形2
        /// </summary>
        /// <param name="listRect2ROI"></param>
        public void ShowAllRect2(List<Rect2> listRect2)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);
            try
            {
                if (null == listRect2)
                {
                    StaticFun.MessageFun.ShowMessage("请先添加检测区域。");
                    return;
                }
                m_hWnd.DispObj(m_hImage);
                foreach (Rect2 tempRect2 in listRect2)
                {
                    ho_Rect2.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rect2, tempRect2.dRect2Row, tempRect2.dRect2Col, tempRect2.dPhi, tempRect2.dLength1, tempRect2.dLength2);
                    DispRegion(ho_Rect2);
                }
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"ShowAllRect2:{ex.ToString()}");
            }
            finally
            {
                ho_Rect2.Dispose();
            }
        }

        public HObject GenAllRect2(List<Rect2> listRect2)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_arrayRect2);
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);
            try
            {
                if (null == listRect2)
                {
                    StaticFun.MessageFun.ShowMessage("请先添加检测区域。");
                    return ho_arrayRect2;
                }
                foreach (Rect2 tempRect2 in listRect2)
                {
                    ho_Rect2.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rect2, tempRect2.dRect2Row, tempRect2.dRect2Col, tempRect2.dPhi, tempRect2.dLength1, tempRect2.dLength2);
                    ho_arrayRect2 = ho_arrayRect2.ConcatObj(ho_Rect2);
                }
                HOperatorSet.Union1(ho_arrayRect2, out ho_arrayRect2);
                DispRegion(ho_arrayRect2);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"GenAllRect2:{ex.ToString()}");
            }
            finally
            {
                ho_Rect2.Dispose();
            }
            return ho_arrayRect2;
        }
        #endregion

        #region 直线
        public void ShowLine(BaseData.Line line, string strColor = "green")
        {
            HOperatorSet.GenEmptyObj(out HObject ho_Line);
            try
            {
                ho_Line.Dispose();
                HOperatorSet.GenRegionLine(out ho_Line, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol);
                DispRegion(ho_Line, strColor, lineWidth: 2);
            }
            catch (Exception ex)
            {
                (ex.Message + ex.StackTrace).Log();
            }
            finally
            {
                ho_Line?.Dispose();
            }
        }
        #endregion

        #region 模板匹配及保存
        //基于区域创建模板
        public bool CreateRegionModel(LocateInParams inPara, out int nModelID, out LocateOutParams outData)
        {
            outData = new LocateOutParams();
            outData.dModelRow = 0;
            outData.dModelCol = 0;
            outData.dModelAngle = 0;
            nModelID = -1;
            HObject ho_RegionROI = null, ho_ImageReduced = null, ho_contModel = null;


            HTuple hv_ModelID, hv_homMat2D = new HTuple();
            HTuple hv_Row, hv_Column, hv_Angle, hv_Score;

            HOperatorSet.GenEmptyObj(out ho_RegionROI);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_contModel);

            try
            {
                //ho_RegionROI = GetLastDrawObj(m_lastDraw);
                m_hWnd.SetColor("green");
                m_hWnd.DispObj(ho_RegionROI);
                HOperatorSet.ReduceDomain(m_hImage, ho_RegionROI, out ho_ImageReduced);
                if (!inPara.bScale)
                {
                    HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", new HTuple(inPara.dAngleStart).TupleRad(), new HTuple(inPara.dAngleEnd).TupleRad(),
                                                 "auto", "auto", "use_polarity", "auto", "auto", out hv_ModelID);
                }
                else
                {
                    HOperatorSet.CreateScaledShapeModel(ho_ImageReduced, "auto", new HTuple(inPara.dAngleStart).TupleRad(), new HTuple(inPara.dAngleEnd).TupleRad(),
                                                        "auto", inPara.dScaleMin, inPara.dScaleMax, "auto", "auto", "use_polarity", "auto", "auto", out hv_ModelID);
                }

                HOperatorSet.FindShapeModel(m_hImage, hv_ModelID, new HTuple(inPara.dAngleStart).TupleRad(), new HTuple(inPara.dAngleEnd).TupleRad(), 0.5, 1, 0.5,
                                            "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                if (0 == hv_Row.TupleLength())
                {
                    MessageBox.Show("模板创建失败！", "Template creation failed!");
                    return false;
                }
                HOperatorSet.GetShapeModelContours(out ho_contModel, hv_ModelID, 1);
                HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row, hv_Column, hv_Angle, out hv_homMat2D);
                HOperatorSet.AffineTransContourXld(ho_contModel, out ho_contModel, hv_homMat2D);
                m_hWnd.SetColor("red");
                m_hWnd.DispObj(ho_contModel);
                HOperatorSet.DispCross(m_hWnd, hv_Row, hv_Column, 20, hv_Angle);
                outData.dModelRow = hv_Row.D;
                outData.dModelCol = hv_Column.D;
                outData.dModelAngle = hv_Angle.D;
                nModelID = hv_ModelID.I;
                return true;

            }
            catch (HalconException error)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_RegionROI) ho_RegionROI.Dispose();
                if (null != ho_ImageReduced) ho_ImageReduced.Dispose();
                if (null != ho_contModel) ho_contModel.Dispose();
            }
        }
        //基于轮廓创建模板
        public bool CreateXLDModel_1(LocateInParams Param, int nEdgeThd, out int nModelID, out LocateOutParams outData)
        {
            outData = new LocateOutParams();
            nModelID = -1;
            HTuple hv_ModelID, hv_Area = new HTuple(), hv_AreaMax = new HTuple();
            HTuple hv_Row, hv_Column, hv_Angle, hv_Score;

            HObject ho_RegionROI = null, ho_ImageReduced = null;
            HObject ho_Region = null, ho_SelRegion = null, ho_RegClosing = null, ho_RegionSelect = null;
            HObject ho_ModelCont = null;

            HOperatorSet.GenEmptyObj(out ho_RegionROI);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_SelRegion);
            HOperatorSet.GenEmptyObj(out ho_RegClosing);
            HOperatorSet.GenEmptyObj(out ho_ModelCont);
            try
            {
                //ho_RegionROI = GetLastDrawObj(m_lastDraw);
                m_hWnd.DispObj(ho_RegionROI);
                HOperatorSet.ReduceDomain(m_hImage, ho_RegionROI, out ho_ImageReduced);
                HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, nEdgeThd, 255);
                HOperatorSet.FillUp(ho_Region, out ho_Region);
                HOperatorSet.Connection(ho_Region, out ho_Region);
                HOperatorSet.SelectShapeStd(ho_Region, out ho_SelRegion, "max_area", 70);
                HOperatorSet.RegionFeatures(ho_Region, "area", out hv_Area);
                HOperatorSet.RegionFeatures(ho_SelRegion, "area", out hv_AreaMax);
                HOperatorSet.SelectShape(ho_Region, out ho_RegionSelect, "area", "and", hv_Area.TupleMean() * 2, hv_AreaMax + 20);
                HOperatorSet.ClosingCircle(ho_RegionSelect, out ho_RegClosing, 5);
                HOperatorSet.Union1(ho_RegClosing, out ho_RegClosing);
                HOperatorSet.GenContourRegionXld(ho_RegClosing, out ho_ModelCont, "border");
                HOperatorSet.CreateShapeModelXld(ho_ModelCont, "auto", Param.dAngleStart, Param.dAngleEnd, "auto", "auto", "ignore_local_polarity", 5, out hv_ModelID);
                HOperatorSet.FindShapeModel(m_hImage, hv_ModelID, new HTuple(Param.dAngleStart).TupleRad(), new HTuple(Param.dAngleEnd).TupleRad(), 0.5, 1, 0.5,
                                            "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                if (0 == hv_Row.TupleLength())
                {
                    MessageBox.Show("轮廓模板创建失败！", "Profile template creation failed!");
                    return false;
                }
                else
                {
                    m_hWnd.DispObj(ho_ModelCont);
                    HOperatorSet.DispCross(m_hWnd, hv_Row, hv_Column, 20, hv_Angle);
                    outData.dModelRow = hv_Row.D;
                    outData.dModelCol = hv_Column.D;
                    outData.dModelAngle = hv_Angle.D;

                    return true;
                }
            }
            catch (HalconException ex)
            {
                ex.ToString();
                MessageBox.Show("轮廓模板创建失败。", "Profile template creation failed!");
                return false;
            }
            finally
            {
                // if (null != ho_Rectangle) ho_Rectangle.Dispose();
                if (null != ho_ImageReduced) ho_ImageReduced.Dispose();
                if (null != ho_Region) ho_Region.Dispose();
                if (null != ho_SelRegion) ho_SelRegion.Dispose();
                if (null != ho_RegClosing) ho_RegClosing.Dispose();
                if (null != ho_ModelCont) ho_ModelCont.Dispose();
            }

        }

        //基于ncc创建模板：待优化
        public bool CreateNccModel(LocateInParams inParam, out object ModelID, out List<LocateOutParams> listOutData)
        {
            listOutData = new List<LocateOutParams>();
            ModelID = -1;

            HTuple hv_ModelID = new HTuple();
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Angle = new HTuple(), hv_Score = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_RegionROI);
            HOperatorSet.GenEmptyObj(out HObject ho_imgReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_cross);

            try
            {
                ho_RegionROI.Dispose();
                ho_RegionROI = GetLastDrawObj(m_lastDraw);
                ho_imgReduced.Dispose();
                HOperatorSet.ReduceDomain(m_GrayImage, ho_RegionROI, out ho_imgReduced);
                HOperatorSet.CreateNccModel(ho_imgReduced, "auto", new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), 0.01, "use_polarity", out hv_ModelID);
                HOperatorSet.FindNccModel(m_GrayImage, hv_ModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), 0.6, 0, 0.5, "true", 0, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                if (0 == hv_Row.TupleLength())
                {
                    MessageBox.Show("模板创建失败！", "Template creation failed!");
                    return false;
                }
                for (int i = 0; i < hv_Row.TupleLength(); i++)
                {
                    LocateOutParams outData = new LocateOutParams(hv_Row[i].D, hv_Column[i].D, hv_Angle.TupleSelect(i).TupleDeg(), hv_Score[i].D);
                    ho_cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_Row[i], hv_Column[i], 30, 0);
                    DispRegion(ho_cross);
                    listOutData.Add(outData);
                }
                ModelID = (object)hv_ModelID;
                return true;

            }
            catch (HalconException ex)
            {
                MessageBox.Show("模板创建失败！" + ex.ToString(), "Template creation failed!" + ex.ToString());
                return false;
            }
            finally
            {
                ho_RegionROI?.Dispose();
                ho_imgReduced?.Dispose();
                ho_cross?.Dispose();
            }
        }

        public HObject NccLocate(LocateInParams inParam, int nModelID, Rect2 modelRect2, out Rect2 outRect2, HObject ho_Image = null)
        {
            outRect2 = new Rect2(0, 0, 0, 0, 0);
            HOperatorSet.GenEmptyObj(out HObject ho_LocateRegion);
            ho_LocateRegion = null;
            try
            {
                if (null == ho_Image)
                {
                    ho_Image = m_GrayImage.Clone();
                }
                if (FindModel_Several(ho_Image, nModelID, inParam, out List<LocateOutParams> listOutData))
                {
                    outRect2 = new Rect2(listOutData[0].dModelRow, listOutData[0].dModelCol,
                                       listOutData[0].dModelAngle + modelRect2.dPhi,
                                       modelRect2.dLength1, modelRect2.dLength2);
                    Rect2Trans(ref outRect2);
                    ho_LocateRegion?.Dispose();
                    HOperatorSet.GenRectangle2(out ho_LocateRegion, outRect2.dRect2Row, outRect2.dRect2Col, outRect2.dPhi, outRect2.dLength1, outRect2.dLength2);
                    DispRegion(ho_LocateRegion);
                }
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"NccLocate:{ex}", true);
            }
            return ho_LocateRegion;
        }
        public bool CreateShapModel(LocateInParams inParam, out object ModelID, out List<LocateOutParams> listOutData)
        {
            listOutData = new List<LocateOutParams>();
            ModelID = -1;
            HTuple hv_ModelID = new HTuple();
            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Angle = new HTuple(), hv_Score = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_RegionROI);
            HOperatorSet.GenEmptyObj(out HObject ho_imgReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_cross);

            try
            {
                ho_RegionROI.Dispose();
                ho_RegionROI = GetLastDrawObj(m_lastDraw);
                ho_imgReduced.Dispose();
                HOperatorSet.ReduceDomain(m_GrayImage, ho_RegionROI, out ho_imgReduced);
                //HOperatorSet.Threshold(ho_imgReduced, out HObject hO_Region, 0, 240);
                //HOperatorSet.Connection(hO_Region, out HObject ho_connectRegion);
                //HOperatorSet.RegionFeatures(ho_connectRegion, "area", out HTuple hv_area);
                //DispRegion(ho_connectRegion, "green", draw: "fill");
                //HOperatorSet.SelectShape(ho_connectRegion, out HObject ho_selectRegion, "area", "and", 2000, 8500);
                ////if (ho_selectRegion.CountObj ()==0)
                ////{
                ////    MessageBox.Show("模板创建区域筛选出错！", "Template creation failed!");
                ////    return false ;
                ////}
                //HOperatorSet.Union1(ho_selectRegion, out HObject ho_UnionRegion);
                //DispRegion(ho_selectRegion, "red", draw: "fill");
                //HOperatorSet.ReduceDomain(m_GrayImage, ho_UnionRegion, out ho_imgReduced);


                HOperatorSet.CreateShapeModel(ho_imgReduced, "auto", new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto", out hv_ModelID);
                //HOperatorSet.CreateNccModel(ho_imgReduced, "auto", new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), 0.01, "use_polarity", out hv_ModelID);
                HOperatorSet.FindShapeModel(m_GrayImage, hv_ModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), inParam.dScore, 1, 0.5, "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                //HOperatorSet.FindShapeModel (m_GrayImage, hv_ModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), 0.6, 0, 0.5, "true", 0, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                if (0 == hv_Row.TupleLength())
                {
                    MessageBox.Show("模板创建失败！", "Template creation failed!");
                    return false;
                }
                for (int i = 0; i < hv_Row.TupleLength(); i++)
                {
                    LocateOutParams outData = new LocateOutParams(hv_Row[i].D, hv_Column[i].D, hv_Angle.TupleSelect(i).TupleDeg(), hv_Score[i].D);
                    ho_cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_Row[i], hv_Column[i], 30, 0);
                    DispRegion(ho_cross);
                    listOutData.Add(outData);
                }
                ModelID = (object)hv_ModelID;
                return true;

            }
            catch (HalconException ex)
            {
                MessageBox.Show("模板创建失败！" + ex.ToString(), "Template creation failed!" + ex.ToString());
                return false;
            }
            finally
            {
                ho_RegionROI?.Dispose();
                ho_imgReduced?.Dispose();
                ho_cross?.Dispose();
            }
        }
        //模板匹配
        public bool FindModel(HObject ho_Image, object ModelID, LocateInParams inParam, out List<LocateOutParams> listOutData)
        {
            listOutData = new List<LocateOutParams>();

            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Angle = new HTuple();
            HTuple hv_Score = new HTuple(), hv_HomMat2D = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_ModelContours);
            HOperatorSet.GenEmptyObj(out HObject ho_ContoursAffinTrans);
            HOperatorSet.GenEmptyObj(out HObject ho_cross);

            try
            {
                if (ModelID == null)
                {
                    WriteStringtoImage(25, 50, 20, "无模板ID！", strEnglish: "No model ID!");
                    MessageFun.ShowMessage("无模板ID！", strEnglish: "No model ID!");
                    return false;
                }
                if (inParam.modelType == ModelType.contour || inParam.modelType == ModelType.region)
                {
                    HOperatorSet.FindShapeModel(ho_Image, (HTuple)ModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd - inParam.dAngleStart).TupleRad(), inParam.dScore, 1, 0.5, "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                }
                else
                {
                    HOperatorSet.CountChannels(ho_Image, out HTuple hv_channels);
                    if (1 != hv_channels.I)
                    {
                        MessageFun.ShowMessage("非单通道图像。", strEnglish: "This is not a single channel image.");
                        return false;
                    }
                    var model = (HTuple)ModelID;
                    HOperatorSet.FindNccModel(ho_Image, (HTuple)ModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd - inParam.dAngleStart).TupleRad(), inParam.dScore, 1, 0.5, "true", 0, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                }
                if (0 == hv_Row.TupleLength())
                {
                    //WriteStringtoImage(20, 50, 20, "未匹配到模板！", "red", "No model matched!");
                    MessageFun.ShowMessage("模板匹配失败！", strEnglish: "Match failed!");
                    return false;
                }
                if (inParam.modelType == ModelType.contour || inParam.modelType == ModelType.region)
                {
                    ho_ModelContours.Dispose();
                    HOperatorSet.GetShapeModelContours(out ho_ModelContours, (HTuple)ModelID, 1);
                    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row, hv_Column, hv_Angle, out hv_HomMat2D);
                    ho_ContoursAffinTrans.Dispose();
                    HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans, hv_HomMat2D);
                    DispRegion(ho_ContoursAffinTrans);
                }
                LocateOutParams outData;
                for (int i = 0; i < hv_Row.TupleLength(); i++)
                {
                    outData = new LocateOutParams(hv_Row[i].D, hv_Column[i].D, hv_Angle[i].D, hv_Score[i].D);
                    ho_cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_Row[i], hv_Column[i], 30, 0);
                    DispRegion(ho_cross);
                    listOutData.Add(outData);
                }
                return true;
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
                return false;
            }
            finally
            {
                ho_ModelContours?.Dispose();
                ho_ContoursAffinTrans?.Dispose();
                ho_cross?.Dispose();
            }
        }

        public bool FindModel_Several(HObject ho_Image, object nModelID, LocateInParams inParam, out List<LocateOutParams> listOutData)
        {
            listOutData = new List<LocateOutParams>();

            HTuple hv_Row = new HTuple(), hv_Column = new HTuple(), hv_Angle = new HTuple();
            HTuple hv_Score = new HTuple(), hv_HomMat2D = new HTuple();

            HOperatorSet.GenEmptyObj(out HObject ho_ModelContours);
            HOperatorSet.GenEmptyObj(out HObject ho_ContoursAffinTrans);
            HOperatorSet.GenEmptyObj(out HObject ho_cross);

            try
            {

                if (inParam.modelType == ModelType.contour || inParam.modelType == ModelType.region)
                {
                    HOperatorSet.FindShapeModel(ho_Image, (HTuple)nModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), inParam.dScore, 1, 0.5,
                                               "least_squares", 0, 0.9, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                }
                else
                {
                    HOperatorSet.CountChannels(ho_Image, out HTuple hv_channels);
                    if (1 != hv_channels.I)
                    {
                        MessageFun.ShowMessage("请输入单通道图像。", true, strEnglish: "Please enter a single channel image.");
                        return false;
                    }
                    HOperatorSet.FindNccModel(ho_Image, (HTuple)nModelID, new HTuple(inParam.dAngleStart).TupleRad(), new HTuple(inParam.dAngleEnd).TupleRad(), inParam.dScore, 0, 0.5, "true", 0, out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                }
                if (0 == hv_Row.TupleLength())
                {
                    return false;
                }
                if (inParam.modelType == ModelType.contour || inParam.modelType == ModelType.region)
                {
                    ho_ModelContours.Dispose();
                    HOperatorSet.GetShapeModelContours(out ho_ModelContours, (HTuple)nModelID, 1);
                    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row, hv_Column, hv_Angle, out hv_HomMat2D);
                    HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursAffinTrans, hv_HomMat2D);
                    m_hWnd.DispObj(ho_ContoursAffinTrans);
                }
                for (int i = 0; i < hv_Row.TupleLength(); i++)
                {
                    LocateOutParams outData = new LocateOutParams();
                    outData.dModelRow = hv_Row[i].D;
                    outData.dModelCol = hv_Column[i].D;
                    outData.dModelAngle = hv_Angle[i];
                    outData.dScore = hv_Score[i].D;
                    listOutData.Add(outData);
                }
                return true;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("定位失败：" + ex.ToString(), true, strEnglish: "Positioning failed:" + ex.ToString());
                return false;
            }
            finally
            {
                ho_ModelContours?.Dispose();
                ho_ContoursAffinTrans?.Dispose();
                ho_cross?.Dispose();
            }

        }
        //保存模板
        public bool WriteModel(int camID, string strModelName, ModelType modelType, object nModelID)
        {
            try
            {
                string CamName = GlobalData.Config._language == Language.english ? "Camera" : "相机";
                string strFilePath = GlobalPath.SavePath.ModelPath + CamName + camID.ToString();
                if (!Directory.Exists(strFilePath))
                    Directory.CreateDirectory(strFilePath);
                string strSavePath = "";
                if (modelType == ModelType.contour || modelType == ModelType.region)
                    strSavePath = strFilePath + "\\" + strModelName + ".shm";//不能包含中文
                else
                    strSavePath = strFilePath + "\\" + strModelName + ".ncm";//不能包含中文

                if (modelType == ModelType.contour || modelType == ModelType.region)
                {
                    HOperatorSet.WriteShapeModel((HTuple)nModelID, strSavePath);
                }
                else if (modelType == ModelType.ncc)
                {
                    HOperatorSet.WriteNccModel((HTuple)nModelID, strSavePath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"模板保存失败！{ex}", $"Model save failed!{ex}");
                return false;
            }
        }

        //查找指定目录下的.shm文件
        public static bool FindModelFile(out List<string> strModelName)
        {
            strModelName = new List<string>();
            try
            {
                string strCurPath = Environment.CurrentDirectory.ToString();
                string strFilePath = strCurPath + "\\";//不能包含中文

                string[] filedir = Directory.GetFiles(strFilePath, "*.shm", SearchOption.AllDirectories);
                int n = 0;
                string str1 = ".shm";
                int num = str1.Length;
                foreach (string str in filedir)
                {
                    string newStr = str.Remove(0, strFilePath.Count());
                    newStr = newStr.TrimEnd('.', 's', 'h', 'm');
                    //  string newName = newStr.Remove(newStr.Length- 1, num);
                    strModelName.Add(newStr);
                    n++;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;

            }
        }
        //显示模板形状：只针对基于轮廓和基于区域的//
        public bool ShowModelshape(HWindowControl hWndCtrl, string strFilePath, out int modelID)
        {
            modelID = -1;
            HTuple hv_ModelID = new HTuple(), hv_homMat2D = new HTuple();
            HTuple hv_row1 = new HTuple(), hv_col1 = new HTuple(), hv_row2 = new HTuple(), hv_col2 = new HTuple();

            HObject ho_modelCont = null, ho_modelRegion = null, ho_objSel = null;
            HOperatorSet.GenEmptyObj(out ho_modelCont);
            HOperatorSet.GenEmptyObj(out ho_modelRegion);
            HOperatorSet.GenEmptyObj(out ho_objSel);
            try
            {
                HWindow hWnd = hWndCtrl.HalconWindow;

                HOperatorSet.ReadShapeModel(strFilePath, out hv_ModelID);
                HOperatorSet.GetShapeModelContours(out ho_modelCont, hv_ModelID, 1);
                HOperatorSet.UnionAdjacentContoursXld(ho_modelCont, out ho_modelCont, 20, 2, "attr_keep");
                HOperatorSet.SmallestRectangle1Xld(ho_modelCont, out hv_row1, out hv_col1, out hv_row2, out hv_col2);

                double height = (hv_row2.TupleMax() - hv_row1.TupleMin()) * 1.2;
                double width = (hv_col2.TupleMax() - hv_col1.TupleMin()) * 1.2;

                double dRow0 = 0, dCol0 = 0, dRow1 = height - 1, dCol1 = width - 1;
                float fImage = (float)dCol1 / (float)dRow1;
                float fWindow = (float)hWndCtrl.Width / hWndCtrl.Height;

                if (fWindow > fImage)
                {
                    float w = fWindow * (float)height;
                    dRow0 = 0;
                    dCol0 = -(w - width) / 2;
                    dRow1 = height - 1;
                    dCol1 = width + (w - width) / 2;
                }
                else
                {
                    float h = (float)width / fWindow;
                    dRow0 = -(h - height) / 2;
                    dCol0 = 0;
                    dRow1 = height + (h - height) / 2;
                    dCol1 = width - 1;
                }

                HOperatorSet.SetSystem("flush_graphic", "false");
                hWnd.ClearWindow();
                hWnd.SetColor("red");
                hWnd.SetPart(dRow0, dCol0, dRow1, dCol1);

                HOperatorSet.VectorAngleToRigid(0, 0, 0, height / 2, width / 2, 0, out hv_homMat2D);
                HOperatorSet.AffineTransContourXld(ho_modelCont, out ho_modelCont, hv_homMat2D);
                hWnd.DispObj(ho_modelCont);

                HOperatorSet.SetSystem("flush_graphic", "true");
                HObject emptyObject = null;
                HOperatorSet.GenEmptyObj(out emptyObject);
                hWnd.DispObj(emptyObject);
                modelID = hv_ModelID.I;
                return true;
            }
            catch (HalconException error)
            {
                MessageBox.Show("模板读取出错！" + error.ToString(), "Template reading error!" + error.ToString());
                return false;
            }
            finally
            {
                if (null != ho_modelCont) ho_modelCont.Dispose();
            }
        }

        //读取模板//
        public static bool ReadModelFromFile(ModelType modelType, string strFilePath, out object modelID)
        {
            modelID = -1;
            HTuple hv_ModelID = new HTuple();
            try
            {
                if (modelType == ModelType.contour || modelType == ModelType.region)
                {
                    HOperatorSet.ReadShapeModel(strFilePath, out hv_ModelID);

                }
                else if (modelType == ModelType.ncc)
                {
                    HOperatorSet.ReadNccModel(strFilePath, out hv_ModelID);

                }
                else if (modelType == ModelType.dcm)
                {
                    HOperatorSet.ReadDataCode2dModel(strFilePath, out hv_ModelID);
                }
                modelID = (object)hv_ModelID;
                return true;
            }
            catch (HalconException error)
            {
                MessageBox.Show("模板读取出错！" + error.ToString(), "Template reading error!" + error.ToString());
                return false;
            }

        }

        #endregion

        public bool Code1DIdentify(Code1DParam param, out Code1DResult result)
        {
            result = new Code1DResult();
            result.listCode1DDecode = new List<Code1DDecode>();
            HObject ho_SymbolRegions = null;

            HTuple hv_BarCodeHandle = null;
            HTuple hv_DecodedDataStrings = new HTuple();
            HTuple hv_BarCodeResults = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_SymbolRegions);
            try
            {
                HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);
                //meas_thresh:在条形码区域受到干扰或噪声水平较高的情况下，应增加“meas_thresh”的值
                double dMeasThresh = 0.05;
                while (dMeasThresh <= 0.2)
                {
                    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "meas_thresh", dMeasThresh);
                    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "meas_thresh_abs", param.dMeasThreshAbs);
                    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "contrast_min", param.nContrastMin);
                    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, (new HTuple("orientation")).TupleConcat("orientation_tol"), (new HTuple(-90)).TupleConcat(90));
                    HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, "merge_scanlines", "true");
                    ho_SymbolRegions.Dispose();
                    HOperatorSet.FindBarCode(m_hImage, out ho_SymbolRegions, hv_BarCodeHandle, param.strCodeType, out hv_DecodedDataStrings);
                    if (0 == hv_DecodedDataStrings.TupleLength())
                    {
                        HOperatorSet.SetBarCodeParam(hv_BarCodeHandle, (new HTuple("orientation")).TupleConcat("orientation_tol"), (new HTuple(0)).TupleConcat(90));
                        ho_SymbolRegions.Dispose();
                        HOperatorSet.FindBarCode(m_hImage, out ho_SymbolRegions, hv_BarCodeHandle, param.strCodeType, out hv_DecodedDataStrings);
                        if (0 != hv_DecodedDataStrings.TupleLength())
                        {
                            break;
                        }
                    }
                    else
                        break;
                    dMeasThresh = dMeasThresh + 0.01;
                }
                DispRegion(ho_SymbolRegions);
                if (0 == hv_DecodedDataStrings.TupleLength())
                    return false;
                HOperatorSet.GetBarCodeResult(hv_BarCodeHandle, "all", "decoded_types", out hv_BarCodeResults);
                for (int i = 0; i < hv_DecodedDataStrings.TupleLength(); i++)
                {
                    Code1DDecode decode = new Code1DDecode();
                    decode.strDecode = hv_DecodedDataStrings[i].S;
                    decode.strCodeType = hv_BarCodeResults[i].S;
                    result.listCode1DDecode.Add(decode);
                }
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                HOperatorSet.ClearBarCodeModel(hv_BarCodeHandle);
                if (null != ho_SymbolRegions) ho_SymbolRegions.Dispose();
            }
        }


        #region 二维码识别
        public bool CreateCode2dModel(int camId, string strCodeType, out HTuple hv_Code2DHandle)
        {
            hv_Code2DHandle = new HTuple();

            try
            {
                string[] arrayCodeTypes = new string[] { "QR Code", "Data Matrix ECC 200", "Micro QR Code", "PDF417", "Aztec Code", "GS1 DataMatrix", "GS1 QR Code", "GS1 Aztec Code" };
                if (!strCodeType.Contains(strCodeType))
                {
                    MessageBox.Show("请输入正确的二维码类型！");
                    return false;
                }
                HOperatorSet.CreateDataCode2dModel(strCodeType, new HTuple(), new HTuple(), out hv_Code2DHandle);
                //使用增强识别模式
                HOperatorSet.SetDataCode2dParam(hv_Code2DHandle, "default_parameters", "enhanced_recognition");
                //适应低对比度场景
                //set_data_code_2d_param (DataCodeHandle, 'contrast_tolerance', 'high')
                //设置最小模块尺寸为10像素
                HOperatorSet.SetDataCode2dParam(hv_Code2DHandle, "module_size_min", 10);
                string strFilePath = SavePath.QRCodePath + $"相机{camId}";
                if (!Directory.Exists(strFilePath))
                {
                    System.IO.Directory.CreateDirectory(strFilePath);
                }
                var sCodePath = strFilePath + "\\" + "data_code_model.dcm";
                HOperatorSet.WriteDataCode2dModel(hv_Code2DHandle, sCodePath);
                return true;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage($"创建二维码模型失败:{ex}");
                return false;
            }
        }
        public HTuple ReadCode2dModel(int camID)
        {
            HTuple hv_DataCodeHandle = new HTuple();
            try
            {
                string strFilePath = SavePath.QRCodePath + $"相机{camID}";
                if (Directory.Exists(strFilePath))
                {
                    var sCodePath = strFilePath + "\\" + "data_code_model.dcm";
                    HOperatorSet.ReadDataCode2dModel(sCodePath, out hv_DataCodeHandle);
                }

            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage("未找到模型，请先创建!");
            }
            return hv_DataCodeHandle;
        }
        public bool FindCode2D(HTuple DataCodeHandel, out List<string> listStrings, int num = 1)
        {
            bool bResult = true;
            listStrings = new List<string>();
            HOperatorSet.GenEmptyObj(out HObject ho_SymbolXLDs);
            try
            {
                // HOperatorSet.SetDataCode2dParam(DataCodeHandel, "default_parameters", "standard");

                ho_SymbolXLDs.Dispose();
                HOperatorSet.FindDataCode2d(m_GrayImage, out ho_SymbolXLDs, DataCodeHandel,
                    new HTuple(), new HTuple(), out HTuple hv_ResultHandles, out HTuple hv_DecodedDataStrings);
                if (hv_DecodedDataStrings.TupleLength() != 0)
                {
                    DispRegion(ho_SymbolXLDs, lineWidth: 2);
                    for (int i = 0; i < hv_DecodedDataStrings.TupleLength(); i++)
                    {
                        string s = hv_DecodedDataStrings[i].S;
                        listStrings.Add(s);
                    }
                }
                else
                {
                    bResult = false;
                }
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("二维码识别失败:" + ex.Message);
                bResult = false;
            }
            finally
            {
                ho_SymbolXLDs?.Dispose();
            }
            return bResult;
        }

        #endregion

        //图像灰度拉伸
        public void scale_image_range(HObject ho_Image, out HObject ho_ImageScaled, HTuple hv_Min, HTuple hv_Max)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_SelectedChannel = null, ho_LowerRegion = null;
            HObject ho_UpperRegion = null;

            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);

            // Local control variables 

            HTuple hv_LowerLimit = new HTuple(), hv_UpperLimit = new HTuple();
            HTuple hv_Mult = null, hv_Add = null, hv_Channels = null;
            HTuple hv_Index = null, hv_MinGray = new HTuple(), hv_MaxGray = new HTuple();
            HTuple hv_Range = new HTuple();
            HTuple hv_Max_COPY_INP_TMP = hv_Max.Clone();
            HTuple hv_Min_COPY_INP_TMP = hv_Min.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_SelectedChannel);
            HOperatorSet.GenEmptyObj(out ho_LowerRegion);
            HOperatorSet.GenEmptyObj(out ho_UpperRegion);
            //Convenience procedure to scale the gray values of the
            //input image Image from the interval [Min,Max]
            //to the interval [0,255] (default).
            //Gray values < 0 or > 255 (after scaling) are clipped.
            //
            //If the image shall be scaled to an interval different from [0,255],
            //this can be achieved by passing tuples with 2 values [From, To]
            //as Min and Max.
            //Example:
            //scale_image_range(Image:ImageScaled:[100,50],[200,250])
            //maps the gray values of Image from the interval [100,200] to [50,250].
            //All other gray values will be clipped.
            //
            //input parameters:
            //Image: the input image
            //Min: the minimum gray value which will be mapped to 0
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //Max: The maximum gray value which will be mapped to 255
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //
            //output parameter:
            //ImageScale: the resulting scaled image
            //
            if (hv_Min_COPY_INP_TMP.TupleLength() == 2)
            {
                hv_LowerLimit = hv_Min_COPY_INP_TMP[1];
                hv_Min_COPY_INP_TMP = hv_Min_COPY_INP_TMP[0];
            }
            else
            {
                hv_LowerLimit = 0.0;
            }
            if (hv_Max_COPY_INP_TMP.TupleLength() == 2)
            {
                hv_UpperLimit = hv_Max_COPY_INP_TMP[1];
                hv_Max_COPY_INP_TMP = hv_Max_COPY_INP_TMP[0];
            }
            else
            {
                hv_UpperLimit = 255.0;
            }
            //
            //Calculate scaling parameters
            hv_Mult = (((hv_UpperLimit - hv_LowerLimit)).TupleReal()) / (hv_Max_COPY_INP_TMP - hv_Min_COPY_INP_TMP);
            hv_Add = ((-hv_Mult) * hv_Min_COPY_INP_TMP) + hv_LowerLimit;
            //
            //Scale image
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.ScaleImage(ho_Image_COPY_INP_TMP, out ExpTmpOutVar_0, hv_Mult, hv_Add);
                ho_Image_COPY_INP_TMP.Dispose();
                ho_Image_COPY_INP_TMP = ExpTmpOutVar_0;
            }
            //
            //Clip gray values if necessary
            //This must be done for each channel separately
            HOperatorSet.CountChannels(ho_Image_COPY_INP_TMP, out hv_Channels);
            HTuple end_val48 = hv_Channels;
            HTuple step_val48 = 1;
            for (hv_Index = 1; hv_Index.Continue(end_val48, step_val48); hv_Index = hv_Index.TupleAdd(step_val48))
            {
                ho_SelectedChannel.Dispose();
                HOperatorSet.AccessChannel(ho_Image_COPY_INP_TMP, out ho_SelectedChannel, hv_Index);
                HOperatorSet.MinMaxGray(ho_SelectedChannel, ho_SelectedChannel, 0, out hv_MinGray, out hv_MaxGray, out hv_Range);
                ho_LowerRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_LowerRegion, ((hv_MinGray.TupleConcat(hv_LowerLimit))).TupleMin(), hv_LowerLimit);
                ho_UpperRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_UpperRegion, hv_UpperLimit,
                    ((hv_UpperLimit.TupleConcat(hv_MaxGray))).TupleMax());
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.PaintRegion(ho_LowerRegion, ho_SelectedChannel, out ExpTmpOutVar_0, hv_LowerLimit, "fill");
                    ho_SelectedChannel.Dispose();
                    ho_SelectedChannel = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.PaintRegion(ho_UpperRegion, ho_SelectedChannel, out ExpTmpOutVar_0, hv_UpperLimit, "fill");
                    ho_SelectedChannel.Dispose();
                    ho_SelectedChannel = ExpTmpOutVar_0;
                }
                if ((int)(new HTuple(hv_Index.TupleEqual(1))) != 0)
                {
                    ho_ImageScaled.Dispose();
                    HOperatorSet.CopyObj(ho_SelectedChannel, out ho_ImageScaled, 1, 1);
                }
                else
                {
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AppendChannel(ho_ImageScaled, ho_SelectedChannel, out ExpTmpOutVar_0);
                        ho_ImageScaled.Dispose();
                        ho_ImageScaled = ExpTmpOutVar_0;
                    }
                }
            }
            ho_Image_COPY_INP_TMP.Dispose();
            ho_SelectedChannel.Dispose();
            ho_LowerRegion.Dispose();
            ho_UpperRegion.Dispose();

            return;
        }
        //
        public bool MeanImage(HObject orgImage, HObject roi, out HObject filterImage, MeanImageParam param)
        {
            filterImage = new HObject();

            HObject ho_ImageMean = null;
            HOperatorSet.GenEmptyObj(out ho_ImageMean);
            try
            {
                if (roi.IsInitialized())
                {
                    HOperatorSet.ReduceDomain(orgImage, roi, out ho_ImageMean);
                }
                else
                {
                    ho_ImageMean = orgImage.Clone();
                }
                HOperatorSet.MeanImage(ho_ImageMean, out filterImage, param.nMaskWidth, param.nMaskHeight);
                m_hWnd.DispObj(filterImage);
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_ImageMean) ho_ImageMean.Dispose();
            }
        }

        public bool MedianImage(HObject orgImage, HObject roi, out HObject filterImage, MedianImageParam param)
        {
            filterImage = new HObject();
            HObject ho_ImageMedian = null;
            HOperatorSet.GenEmptyObj(out ho_ImageMedian);
            try
            {
                if (roi.IsInitialized())
                {
                    HOperatorSet.ReduceDomain(orgImage, roi, out ho_ImageMedian);
                }
                else
                {
                    ho_ImageMedian = orgImage.Clone();
                }
                HOperatorSet.MedianImage(ho_ImageMedian, out filterImage, param.strMaskType, param.nMaskRadius, "mirrored");
                m_hWnd.DispObj(filterImage);
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_ImageMedian) ho_ImageMedian.Dispose();
            }
        }

        public bool EquHistImage(HObject orgImage, HObject roi, out HObject enhancedImage)
        {
            enhancedImage = new HObject();
            HObject ho_ImageEquHist = null;
            HOperatorSet.GenEmptyObj(out ho_ImageEquHist);
            try
            {
                m_hWnd.DispObj(roi);
                if (roi.IsInitialized())
                {
                    HOperatorSet.ReduceDomain(orgImage, roi, out ho_ImageEquHist);
                }
                else
                {
                    ho_ImageEquHist = orgImage.Clone();
                }
                HOperatorSet.EquHistoImage(ho_ImageEquHist, out enhancedImage);
                m_hWnd.DispObj(enhancedImage);
                return true;
            }
            catch (HalconException ex)
            {
                ex.ToString();
                return false;
            }
            finally
            {
                if (null != ho_ImageEquHist) ho_ImageEquHist.Dispose();
            }
        }

        //public bool TrainVariationModel(LocateInParams locateParam, LocateOutParams modelCenter, int nModelID)
        //{
        //    HTuple hv_width = new HTuple(), hv_height = new HTuple();
        //    HTuple hv_VariationModelID = new HTuple(), hv_HomMat2D = new HTuple();

        //    HObject ho_ImageTrans = null, ho_MeanImage = null, ho_VarImage = null;
        //    HOperatorSet.GenEmptyObj(out ho_ImageTrans);
        //    HOperatorSet.GenEmptyObj(out ho_MeanImage);
        //    HOperatorSet.GenEmptyObj(out ho_VarImage);

        //    try
        //    {
        //        HOperatorSet.GetImageSize(m_hImage, out hv_width, out hv_height);
        //        HOperatorSet.CreateVariationModel(hv_width, hv_height, "byte", "standard", out hv_VariationModelID);
        //        LocateOutParams pre_model = new LocateOutParams();
        //        if (!FindModel(nModelID, locateParam, out pre_model))
        //        {
        //            return false;
        //        }
        //        HOperatorSet.VectorAngleToRigid(modelCenter.dModelRow, modelCenter.dModelCol, modelCenter.dModelAngle,
        //                                           pre_model.dModelRow, pre_model.dModelCol, pre_model.dModelAngle, out hv_HomMat2D);
        //        HOperatorSet.AffineTransImage(m_hImage, out ho_ImageTrans, hv_HomMat2D, "constant", "false");
        //        HOperatorSet.TrainVariationModel(ho_ImageTrans, hv_VariationModelID);
        //        m_hWnd.DispObj(ho_ImageTrans);

        //        HOperatorSet.GetVariationModel(out ho_MeanImage, out ho_VarImage, hv_VariationModelID);
        //        HOperatorSet.PrepareVariationModel(hv_VariationModelID, 20, 3);
        //        //We can now free the training data to save some memory.

        //        return true;
        //    }
        //    catch (HalconException error)
        //    {
        //        MessageBox.Show(error.ToString());
        //        return false;
        //    }
        //    finally
        //    {
        //        HOperatorSet.ClearTrainDataVariationModel(hv_VariationModelID);
        //        if (null != ho_ImageTrans) ho_ImageTrans.Dispose();
        //        if (null != ho_MeanImage) ho_MeanImage.Dispose();
        //        if (null != ho_VarImage) ho_VarImage.Dispose();
        //    }
        //}

        /*适用于印刷体检测*/
        public bool VariationCheck(LocateInParams locateParam, LocateOutParams modelCenter, int nModelID)
        {
            HTuple hv_width = new HTuple(), hv_height = new HTuple();
            HTuple hv_VariationModelID = new HTuple(), hv_HomMat2D = new HTuple();

            HObject ho_ImageTrans = null, ho_modelCont = null;
            HObject ho_contTrans = null, ho_RegionROI = null, ho_ImageReduced = null, ho_RegionDiff = null;

            HOperatorSet.GenEmptyObj(out ho_ImageTrans);
            HOperatorSet.GenEmptyObj(out ho_modelCont);
            HOperatorSet.GenEmptyObj(out ho_contTrans);
            HOperatorSet.GenEmptyObj(out ho_RegionROI);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_RegionDiff);

            try
            {
                List<LocateOutParams> pre_model = new List<LocateOutParams>();
                if (!FindModel(m_hImage, nModelID, locateParam, out pre_model))
                {
                    return false;
                }
                HOperatorSet.VectorAngleToRigid(modelCenter.dModelRow, modelCenter.dModelCol, modelCenter.dModelAngle,
                                                   pre_model[0].dModelRow, pre_model[0].dModelCol, pre_model[0].dModelAngle, out hv_HomMat2D);
                HOperatorSet.AffineTransImage(m_hImage, out ho_ImageTrans, hv_HomMat2D, "constant", "false");
                //设定对比区域
                HOperatorSet.GetShapeModelContours(out ho_modelCont, nModelID, 1);
                HOperatorSet.AffineTransContourXld(ho_modelCont, out ho_contTrans, hv_HomMat2D);
                HOperatorSet.ShapeTransXld(ho_contTrans, out ho_contTrans, "convex");
                HOperatorSet.GenRegionContourXld(ho_contTrans, out ho_RegionROI, "filled");
                HOperatorSet.ReduceDomain(ho_ImageTrans, ho_RegionROI, out ho_ImageReduced);
                //与模板比较，找出异常点
                HOperatorSet.CompareVariationModel(ho_ImageReduced, out ho_RegionDiff, hv_VariationModelID);
                HOperatorSet.Connection(ho_RegionDiff, out ho_RegionDiff);
                //筛选
                //HOperatorSet.SelectShape(ho_RegionDiff, out ho_RegionsError, "area", "and", 20, 1000000);
                //HOperatorSet.CountObj(ho_RegionsError, out hv_NumError);

                return true;
            }
            catch (HalconException error)
            {
                error.ToString();
                return false;
            }
            finally
            {

            }
        }

        #region XY标定
        public static double m_dCalibVal = 0.018;    //标定系数
        public bool GetCalibVal(PointF pStart, PointF pEnd, double[] pMm, out double dCalibVal, out double dAngleX, out double dAngleY)
        {
            dCalibVal = 0;
            dAngleX = 0;
            dAngleY = 0;
            try
            {
                HOperatorSet.DistancePp(pStart.Y, pStart.X, pEnd.Y, pEnd.X, out HTuple hv_DistPixel);
                double dmm = pMm[1] - pMm[0];
                dCalibVal = Math.Round(dmm / hv_DistPixel.D, 3);
                HOperatorSet.GetImageSize(m_hImage, out HTuple hv_width, out HTuple hv_height);
                m_hWnd.SetColor("red");
                m_hWnd.SetDraw("fill");
                m_hWnd.SetLineWidth(2);
                m_hWnd.DispCross((double)pStart.Y, pStart.X, 25, 0);
                m_hWnd.DispCross((double)pEnd.Y, pEnd.X, 25, 0);
                m_hWnd.DispArrow((double)pStart.Y, (double)pStart.X, (double)pEnd.Y, (double)pEnd.X, 10);
                m_hWnd.SetColor("green");

                m_hWnd.SetLineStyle(10);
                m_hWnd.DispLine(pStart.Y, pStart.X, pStart.Y, hv_width);
                m_hWnd.DispLine((double)pStart.Y, pStart.X, 0, pStart.X);
                m_hWnd.SetLineStyle(new HTuple());
                //与水平方向的夹角:顺时针方向为负值，逆时针方向为正值，取值范围-PI ~ PI
                HOperatorSet.AngleLl(pStart.Y, pStart.X, pEnd.Y, pEnd.X,
                                     pStart.Y, pStart.X, pStart.Y, hv_width, out HTuple hv_angleX);
                dAngleX = hv_angleX.TupleDeg();
                //与垂直方向的夹角
                HOperatorSet.AngleLl(pStart.Y, pStart.X, pEnd.Y, pEnd.X,
                                     pStart.Y, pStart.X, 0, pStart.X, out HTuple hv_angleY);
                dAngleY = hv_angleY.TupleDeg();
                return true;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("计算标定系数错误：" + ex.ToString());
                return false;
            }
            finally
            {
                m_hWnd.SetDraw("margin");
            }
        }

        public bool Offset(LocateParam modelLocate, CenterParam nowCenter, out double dOffsetX, out double dOffsetY)
        {
            dOffsetX = 0;
            dOffsetY = 0;

            HTuple hv_Dist = new HTuple(), hv_AngleXY = new HTuple(), hv_AngleYX = new HTuple();
            HTuple hv_AngleX = new HTuple(), hv_AngleY = new HTuple(), hv_AngleZ = new HTuple();
            try
            {
                //当前点到模板点的距离
                HOperatorSet.DistancePp(modelLocate.modelCenter.point.X, modelLocate.modelCenter.point.Y, nowCenter.point.X, nowCenter.point.Y, out hv_Dist);
                double dDist = hv_Dist.D * m_dCalibVal;
                //偏移量与运动轴X的夹角
                HOperatorSet.AngleLl(nowCenter.point.Y, nowCenter.point.X, modelLocate.modelCenter.point.Y, modelLocate.modelCenter.point.X,
                                     modelLocate.lineX.dStartRow, modelLocate.lineX.dStartCol, modelLocate.lineX.dEndRow, modelLocate.lineX.dEndCol, out hv_AngleX);
                //偏移量与运动轴Y的夹角
                HOperatorSet.AngleLl(nowCenter.point.Y, nowCenter.point.X, modelLocate.modelCenter.point.Y, modelLocate.modelCenter.point.X,
                                     modelLocate.lineY.dStartRow, modelLocate.lineY.dStartCol, modelLocate.lineY.dEndRow, modelLocate.lineY.dEndCol, out hv_AngleY);

                //计算偏移量dX,dY
                double dAngleX = Math.Abs(hv_AngleX.D);
                double dAngleY = Math.Abs(hv_AngleY.D);
                //double dAngleYX = Math.Abs(hv_AngleYX.D);
                if (dAngleX > (Math.PI / 2))
                {
                    dAngleX = Math.PI - dAngleX;
                }
                if (dAngleY > (Math.PI / 2))
                {
                    dAngleY = Math.PI - dAngleY;
                }
                double dAngleZ = Math.PI - dAngleX - dAngleY;
                double dX = Math.Sin(dAngleY) / Math.Sin(dAngleZ) * dDist;
                double dY = Math.Sin(dAngleX) / Math.Sin(dAngleZ) * dDist;
                //在第一项目和第四项目为正
                //运动轴X与运动轴Y的夹角：输入为图像坐标
                HOperatorSet.AngleLl(modelLocate.lineY.dStartRow, modelLocate.lineY.dStartCol, modelLocate.lineY.dEndRow, modelLocate.lineY.dEndCol,
                                     modelLocate.lineX.dStartRow, modelLocate.lineX.dStartCol, modelLocate.lineX.dEndRow, modelLocate.lineX.dEndCol, out hv_AngleYX);
                //计算偏移量的符号：（不能基于标定坐标系）
                HOperatorSet.TupleSgn(hv_AngleX - 0, out HTuple hv_sgnX);
                HOperatorSet.TupleSgn(hv_AngleYX - 0, out HTuple hv_sgnYX);
                //如果角度方向相同
                dOffsetX = -1 * dX;
                if (hv_sgnX.I == hv_sgnYX.I && Math.Abs(hv_AngleX.D) < Math.Abs(hv_AngleYX.D))
                {
                    dOffsetX = dX;
                }
                HOperatorSet.AngleLl(modelLocate.lineY.dEndRow, modelLocate.lineY.dEndCol, modelLocate.lineY.dStartRow, modelLocate.lineY.dStartCol,
                                    modelLocate.lineX.dStartRow, modelLocate.lineX.dStartCol, modelLocate.lineX.dEndRow, modelLocate.lineX.dEndCol, out HTuple hv_AngleYX1);
                if (hv_sgnX.I != hv_sgnYX.I && Math.Abs(hv_AngleX.D) < Math.Abs(hv_AngleYX1.D))
                {
                    dOffsetX = dX;
                }
                //运动轴X与运动轴Y的夹角：输入为图像坐标
                HOperatorSet.AngleLl(modelLocate.lineX.dStartRow, modelLocate.lineX.dStartCol, modelLocate.lineX.dEndRow, modelLocate.lineX.dEndCol,
                                     modelLocate.lineY.dStartRow, modelLocate.lineY.dStartCol, modelLocate.lineY.dEndRow, modelLocate.lineY.dEndCol, out hv_AngleXY);
                HOperatorSet.TupleSgn(hv_AngleY - 0, out HTuple hv_sgnY);
                HOperatorSet.TupleSgn(hv_AngleXY - 0, out HTuple hv_sgnXY);
                dOffsetY = -1 * dY;
                if (hv_sgnY.I == hv_sgnXY.I && Math.Abs(hv_AngleY.D) < Math.Abs(hv_AngleXY.D))
                {
                    dOffsetY = dY;
                    // dY = dY;
                }
                HOperatorSet.AngleLl(modelLocate.lineX.dEndRow, modelLocate.lineX.dEndCol, modelLocate.lineX.dStartRow, modelLocate.lineX.dStartCol,
                                     modelLocate.lineY.dStartRow, modelLocate.lineY.dStartCol, modelLocate.lineY.dEndRow, modelLocate.lineY.dEndCol, out HTuple hv_AngleXY1);
                if (hv_sgnY.I != hv_sgnXY.I && Math.Abs(hv_AngleY.D) < Math.Abs(hv_AngleXY1.D))
                {
                    dOffsetY = dY;
                }
                return true;

            }
            catch (SystemException ex)
            {
                ex.ToString().Log();
                return false;
            }
        }
        #endregion

        #region 颜色空间转换
        /// <summary>
        /// 颜色空间图像组合显示
        /// </summary>
        /// <param name="arrayBool">选择组合的空间图像</param>
        /// <param name="bShow">是否在窗口显示</param>
        /// <returns>返回图像组合</returns>
        public HObject SpaceTransImage(ColorSpaceTransParam data, bool bShow)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_EdgeImage);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageMixed);
            HOperatorSet.GenEmptyObj(out HObject ho_Image1);
            HOperatorSet.GenEmptyObj(out HObject ho_Image2);
            HOperatorSet.GenEmptyObj(out HObject ho_Image3);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult1);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult2);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult3);
            HOperatorSet.GenEmptyObj(out HObject ho_ColorSpaceImages);
            HOperatorSet.GenEmptyObj(out HObject ho_SelImage1);
            HOperatorSet.GenEmptyObj(out HObject ho_SelImage2);
            try
            {
                ho_EdgeImage.Dispose();
                HOperatorSet.KirschAmp(m_GrayImage, out ho_EdgeImage);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_EdgeImage);
                if (null != data.arrayImageChannels && data.arrayImageChannels[0])
                {
                    ho_ImageMixed = ho_EdgeImage.Clone();
                    return ho_ImageMixed;
                }
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(m_GrayImage);
                //if (!data.arrayImageChannels.Contains(true) && bShow)
                //{
                //    m_hWnd.DispObj(m_hImage);
                //    return ho_ImageMixed;
                //}
                //颜色空间转换
                ho_Image1.Dispose();
                ho_Image2.Dispose();
                ho_Image3.Dispose();
                HOperatorSet.Decompose3(m_hImage, out ho_Image1, out ho_Image2, out ho_Image3);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_Image1);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_Image2);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_Image3);
                ho_ImageResult1.Dispose();
                ho_ImageResult2.Dispose();
                ho_ImageResult3.Dispose();
                if (null == data.strColorSpace)
                {
                    return ho_ImageMixed;
                }
                HOperatorSet.TransFromRgb(ho_Image1, ho_Image2, ho_Image3, out ho_ImageResult1, out ho_ImageResult2, out ho_ImageResult3, data.strColorSpace);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_ImageResult1);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_ImageResult2);
                ho_ColorSpaceImages = ho_ColorSpaceImages.ConcatObj(ho_ImageResult3);

                HTuple hv_arrayID = new HTuple();//图像组合
                for (int n = 0; n < data.arrayImageChannels.Length; n++)
                {
                    if (data.arrayImageChannels[n])
                    {
                        hv_arrayID = hv_arrayID.TupleConcat(n);
                    }
                }
                ho_ImageMixed.Dispose();
                if (hv_arrayID.TupleLength() == 1)
                {//单通道图片显示
                    int nSel = hv_arrayID[0] + 1;
                    ho_ImageMixed = ho_ColorSpaceImages.SelectObj(nSel).Clone();
                }
                else if (hv_arrayID.TupleLength() == 2)
                {
                    ho_SelImage1.Dispose();
                    int nSel1 = hv_arrayID[0] + 1;
                    ho_SelImage1 = ho_ColorSpaceImages.SelectObj(nSel1).Clone();
                    ho_SelImage2.Dispose();
                    int nSel2 = hv_arrayID[1] + 1;
                    ho_SelImage2 = ho_ColorSpaceImages.SelectObj(nSel2).Clone();
                    HOperatorSet.AddImage(ho_SelImage1, ho_SelImage2, out ho_ImageMixed, 0.8, 0);
                }
                else if (hv_arrayID.TupleLength() == 3)
                {
                    MessageBox.Show("不能将3个通道的图像进行叠加。");
                }
                if (bShow && ho_ImageMixed.IsInitialized())
                {
                    DispRegion(ho_ImageMixed);
                }
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_Image1?.Dispose();
                ho_Image2?.Dispose();
                ho_Image3?.Dispose();
                ho_ImageResult1?.Dispose();
                ho_ImageResult2?.Dispose();
                ho_ImageResult3?.Dispose();
                ho_ColorSpaceImages?.Dispose();
                ho_SelImage1?.Dispose();
                ho_SelImage2?.Dispose();
            }
            return ho_ImageMixed;
        }

        #endregion

        #region GMM颜色识别

        /// <summary>
        /// 创建GMM颜色模型
        /// </summary>
        /// <param name="ho_ColorRegion"></param> 颜色区域
        /// <param name="colorID"></param> 返回颜色ID号
        /// <returns></returns> 是否创建成功
        public bool CreateColorGmm(HObject ho_ColorRegion, out BaseData.ColorID colorID, double dRejThd = 0.05)
        {
            colorID = new ColorID()
            {
                ID = new HTuple[2],
            };
            bool bExist = false;
            HTuple hv_GMMHandle = new HTuple(), hv_ErrorLog = new HTuple(), hv_Error = new HTuple();
            HTuple[] hv_ColorID = new HTuple[2];
            try
            {
                HOperatorSet.CountChannels(m_hImage, out HTuple hv_channels);
                if (3 != hv_channels.I)
                {
                    MessageFun.ShowMessage("非彩色图像，请导入一张彩色图像！", false, strEnglish: "please import a color image!");
                    return false;
                }
                HOperatorSet.CreateClassGmm(numDim: 3, 1, 1, "full", "normalization", 10, 42, out hv_GMMHandle);
                HOperatorSet.AddSamplesImageClassGmm(m_hImage, ho_ColorRegion, hv_GMMHandle, randomize: 0);
                HOperatorSet.TrainClassGmm(hv_GMMHandle, maxIter: 100, 0.003, "training", 0.002, out hv_Error, out hv_ErrorLog);
                hv_ColorID[0] = hv_GMMHandle;
                ColorClassGmmConvert(ref hv_GMMHandle, dRejThd);
                hv_ColorID[1] = hv_GMMHandle;
                colorID.ID = hv_ColorID;
                FindColorGMM(colorID, out bExist, null);
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("创建颜色模型出错：" + ex.ToString(), true, strEnglish: "Error creating color model:" + ex.ToString());
            }
            return bExist;
        }

        /// <summary>
        /// GMM模型颜色匹配
        /// </summary>
        /// <param name="ho_ROI"></param> 颜色查找区域
        /// <param name="colorID"></param> 颜色GMM模型ID
        /// <param name="bExist"></param> 是否存在该颜色
        /// <returns></returns> 返回颜色区域
        public HObject FindColorGMM(ColorID colorID, out bool bExist, HObject ho_ROI = null)
        {
            bExist = false;
            HOperatorSet.GenEmptyObj(out HObject ho_ImgReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_ColorRegion);

            try
            {
                if (null != ho_ROI)
                {
                    ho_ImgReduced.Dispose();
                    HOperatorSet.ReduceDomain(m_hImage, ho_ROI, out ho_ImgReduced);
                    ho_Region.Dispose();
                    HOperatorSet.ClassifyImageClassLut(ho_ImgReduced, out ho_Region, colorID.ID[1]);
                }
                else
                {
                    ho_Region.Dispose();
                    HOperatorSet.ClassifyImageClassLut(m_hImage, out ho_Region, colorID.ID[1]);
                }
                ho_ColorRegion.Dispose();
                HOperatorSet.ClosingCircle(ho_Region, out ho_ColorRegion, 1.5);
                HOperatorSet.RegionFeatures(ho_ColorRegion, "area", out HTuple hv_Value);
                if (hv_Value.TupleLength() != 0 && hv_Value[0].D != 0)
                {
                    bExist = true;
                    DispRegion(ho_ColorRegion, "green", draw: "fill");
                }
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage("线序检测出错：" + ex.ToString(), true);
            }
            finally
            {
                ho_ImgReduced?.Dispose();
                ho_Region?.Dispose();
            }
            return ho_ColorRegion;
        }
        public bool WriteColor(string strFilePath, string strName, ColorID colorID)
        {
            try
            {
                ////nID从1开始
                //int main_cam = (cam % 100) / 10 == 0 ? cam : ((cam % 100) / 10);
                //int sub_cam = (cam % 100) / 10 == 0 ? 0 : (cam % 10);
                //string strFilePath = GlobalPath.SavePath.ModelPath + "相机" + main_cam.ToString();
                //if (sub_cam != 0)
                //{
                //    strFilePath = strFilePath + "_" + sub_cam.ToString();
                //}
                if (!Directory.Exists(strFilePath))
                    Directory.CreateDirectory(strFilePath);
                string strSavePath = strFilePath + "\\" + strName + ".gmm";
                HOperatorSet.WriteClassGmm(colorID.ID[0], strSavePath);
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("模板保存失败！" + ex.ToString());
                return false;
            }
        }
        public bool WriteListColor(string strFilePath, string strName, List<ColorID> listClassID)
        {
            try
            {
                if (null == listClassID)
                {
                    return false;
                }
                if (!Directory.Exists(strFilePath))
                    Directory.CreateDirectory(strFilePath);
                string strSavePath = "";
                for (int n = 0; n < listClassID.Count; n++)
                {
                    strSavePath = strFilePath + "\\" + strName + n.ToString() + ".gmm";
                    HOperatorSet.WriteClassGmm(listClassID[n].ID[0], strSavePath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("线序模板保存失败！" + ex.ToString());
                return false;
            }
        }
        public static bool ReadGmmModel(string strFilePath, out HTuple[] hv_colorID)
        {
            hv_colorID = new HTuple[2];
            try
            {
                HOperatorSet.ReadClassGmm(strFilePath, out HTuple hv_ModelID);
                hv_colorID[0] = hv_ModelID;
                ColorClassGmmConvert(ref hv_ModelID, 0.05);
                hv_colorID[1] = hv_ModelID;
                return true;
            }
            catch (HalconException error)
            {
                MessageBox.Show("模板读取出错！" + error.ToString());
                return false;
            }

        }

        public static void ColorClassGmmConvert(ref HTuple hv_ColorID, double dRejThd)
        {
            //防止多处使用该函数数，修改了一处忘记修改另一处
            HTuple hv_ClassLUTHandle = new HTuple();
            try
            {
                HOperatorSet.CreateClassLutGmm(hv_ColorID, (new HTuple("bit_depth")).TupleConcat("rejection_threshold"), (new HTuple(6)).TupleConcat(dRejThd), out hv_ClassLUTHandle);
                hv_ColorID = new HTuple();
                hv_ColorID = hv_ClassLUTHandle;
            }
            catch (HalconException error)
            {
                ("线序检测句柄转换错误：" + error.ToString()).Log();
                MessageFun.ShowMessage("线序检测句柄转换错误：" + error.ToString());
            }
        }

        #endregion

        #region 调节图像饱和度
        public HObject ImageSaturation(int[] array)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_ImageSaturation);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageR);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageG);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageB);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult1);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult2);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult3);
            HOperatorSet.GenEmptyObj(out HObject ho_MultiImage);
            try
            {
                HOperatorSet.CountChannels(m_hImage, out HTuple hv_channels);
                if (hv_channels.I != 3)
                {
                    MessageFun.ShowMessage("请输入一张彩色图像。");
                    return ho_ImageSaturation;
                }
                ho_ImageR.Dispose();
                ho_ImageG.Dispose();
                ho_ImageB.Dispose();
                HOperatorSet.Decompose3(m_hImage, out ho_ImageR, out ho_ImageG, out ho_ImageB);
                ho_ImageResult1.Dispose();
                ho_ImageResult2.Dispose();
                ho_ImageResult3.Dispose();
                HOperatorSet.TransFromRgb(ho_ImageR, ho_ImageG, ho_ImageB, out ho_ImageResult1, out ho_ImageResult2, out ho_ImageResult3, "hsv");
                HObject ho_ImageH = ReplaceGraval(ho_ImageResult1, array[0]);
                HObject ho_ImageS = ReplaceGraval(ho_ImageResult2, array[1]);
                HObject ho_ImageV = ReplaceGraval(ho_ImageResult3, array[2]);
                ho_ImageR.Dispose();
                ho_ImageG.Dispose();
                ho_ImageB.Dispose();
                HOperatorSet.TransFromRgb(ho_ImageH, ho_ImageS, ho_ImageV, out ho_ImageR, out ho_ImageG, out ho_ImageB, "hsv");
                ho_MultiImage.Dispose();
                HOperatorSet.Compose3(ho_ImageR, ho_ImageG, ho_ImageB, out ho_MultiImage);
                ho_ImageSaturation.Dispose();
                HOperatorSet.Emphasize(ho_MultiImage, out ho_ImageSaturation, 5, 5, 1.5);
                DispRegion(ho_ImageSaturation);
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
            }
            finally
            {
                ho_ImageR?.Dispose();
                ho_ImageG?.Dispose();
                ho_ImageB?.Dispose();
                ho_ImageResult1?.Dispose();
                ho_ImageResult2?.Dispose();
                ho_ImageResult3?.Dispose();
                ho_MultiImage?.Dispose();
            }
            return ho_ImageSaturation;
        }

        private HObject ReplaceGraval(HObject ho_OrgImage, int nAdd)
        {
            try
            {
                HOperatorSet.GetRegionPoints(ho_OrgImage, out HTuple hv_rows, out HTuple hv_cols);
                HOperatorSet.GetGrayval(ho_OrgImage, hv_rows, hv_cols, out HTuple hv_GrayVal);
                HTuple hv_AddVal = hv_GrayVal + nAdd;
                //如果大于255则=255
                HOperatorSet.TupleSgn(hv_AddVal - 255, out HTuple hv_sgn);
                HOperatorSet.TupleFind(hv_sgn, 1, out HTuple hv_indices);
                HTuple hv_Replaced255 = hv_AddVal;
                if (0 != hv_indices.TupleLength() && -1 != hv_indices[0].I)
                {
                    hv_Replaced255 = new HTuple();
                    HOperatorSet.TupleReplace(hv_AddVal, hv_indices, 255, out hv_Replaced255);
                }
                //如果小于0则=0
                hv_sgn = new HTuple();
                HOperatorSet.TupleSgn(hv_AddVal, out hv_sgn);
                hv_indices = new HTuple();
                HOperatorSet.TupleFind(hv_sgn, -1, out hv_indices);
                HTuple hv_Replaced0 = hv_Replaced255;
                if (0 != hv_indices.TupleLength() && -1 != hv_indices[0].I)
                {
                    hv_Replaced0 = new HTuple();
                    HOperatorSet.TupleReplace(hv_Replaced255, hv_indices, 255, out hv_Replaced0);
                }
                ho_OrgImage.Dispose();
                HOperatorSet.SetGrayval(ho_OrgImage, hv_rows, hv_cols, hv_Replaced0);
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage(ex.ToSingle(), true);
            }
            return ho_OrgImage;
        }
        #endregion

        #region 阈值分割
        public HObject DynThd(BaseData.ThdParam thdParam, HObject ho_Image, HObject ho_ROI)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_OutRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageMean);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            try
            {

                if (thdParam.bAutoThd)
                {
                    ho_ImageMean.Dispose();
                    HOperatorSet.MeanImage(ho_Image, out ho_ImageMean, thdParam.nMeanMask, thdParam.nMeanMask);
                    ho_ImageReduced.Dispose();
                    HOperatorSet.ReduceDomain(ho_ImageMean, ho_ROI, out ho_ImageReduced);
                    ho_Region.Dispose();
                    HOperatorSet.DynThreshold(ho_Image, ho_ImageReduced, out ho_Region, thdParam.nDynThd, thdParam.sLightDark);
                    ho_ImageReduced.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_Region, out ho_ImageReduced);
                }
                else
                {
                    ho_ImageReduced.Dispose();
                    HOperatorSet.ReduceDomain(ho_Image, ho_ROI, out ho_ImageReduced);
                }
                ho_OutRegion.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced, out ho_OutRegion, thdParam.nStaticThdMin, thdParam.nStaticThdMax);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_ImageMean?.Dispose();
                ho_ImageReduced?.Dispose();
                ho_Region?.Dispose();
            }
            return ho_OutRegion;
        }

        public HObject StaticThd(BaseData.StaticThdParam thdParam, HObject ho_Image, HObject ho_ROI)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_OutRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            try
            {
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_Image, ho_ROI, out ho_ImageReduced);
                int nMin = 0;
                int nMax = 255;
                if (thdParam.b0_x)
                {
                    nMin = 0;
                    nMax = thdParam.nThd;
                }
                else
                {
                    nMin = thdParam.nThd;
                    nMax = 255;
                }
                ho_OutRegion.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced, out ho_OutRegion, nMin, nMax);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_ImageReduced?.Dispose();
            }
            return ho_OutRegion;
        }
        public HObject StaticThd(BaseData.StaticThdParam thdParam, BaseData.StaticThdParam thdParam1, HObject ho_Image, HObject ho_ROI)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_OutRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            try
            {
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_Image, ho_ROI, out ho_ImageReduced);
                //int nMin = 0;
                //int nMax = 255;
                //if (thdParam.b0_x)
                //{
                //    nMin = 0;
                //    nMax = thdParam.nThd;
                //}
                //else
                //{
                //    nMin = thdParam.nThd;
                //    nMax = 255;
                //}
                ho_OutRegion.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced, out ho_OutRegion, thdParam.nThd, thdParam1.nThd);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_ImageReduced?.Dispose();
            }
            return ho_OutRegion;
        }
        #endregion

        #region 字符识别
        public List<OpenCvSharp.Point[]> OCR_box(List<Rect2> listRect2s)
        {
            List<OpenCvSharp.Point[]> listCornerPoints = new List<OpenCvSharp.Point[]>();
            try
            {
                Rect2 rect;
                for (int n = 0; n < listRect2s.Count; n++)
                {
                    rect = listRect2s[n];
                    Rect2Trans(ref rect);
                    //逆时针：左上、左下、右下、右上 : (Column:x,Row:y) 
                    OpenCvSharp.Point[] points = new OpenCvSharp.Point[4];
                    double dCos = Math.Cos(rect.dPhi);
                    double dSin = Math.Sin(rect.dPhi);
                    //左上角
                    double a = ((-rect.dLength1) * dCos) - (rect.dLength2 * dSin);
                    double b = ((-rect.dLength1) * dSin) + (rect.dLength2 * dCos);
                    points[0] = new OpenCvSharp.Point((rect.dRect2Col + a), (rect.dRect2Row - b));
                    //HWnd.DispCross(new HTuple(points[0].Y), new HTuple(points[0].X), 50, 0);
                    //左下角
                    double g = ((-rect.dLength1) * dCos) + (rect.dLength2 * dSin);
                    double h = ((-rect.dLength1) * dSin) - (rect.dLength2 * dCos);
                    points[1] = new OpenCvSharp.Point((rect.dRect2Col + g), (rect.dRect2Row - h));
                    //HWnd.DispCross(new HTuple(points[1].Y), new HTuple(points[1].X), 50, 0);

                    //右上角
                    double c = (rect.dLength1 * dCos) - (rect.dLength2 * dSin);
                    double d = (rect.dLength1 * dSin) + (rect.dLength2 * dCos);
                    points[2] = new OpenCvSharp.Point((rect.dRect2Col + c), (float)(rect.dRect2Row - d));
                    //HWnd.DispCross(new HTuple(points[2].Y), new HTuple(points[2].X), 50, 0);

                    //右下角
                    double e = (rect.dLength1 * dCos) + (rect.dLength2 * dSin);
                    double f = (rect.dLength1 * dSin) - (rect.dLength2 * dCos);
                    points[3] = new OpenCvSharp.Point((float)(rect.dRect2Col + e), (float)(rect.dRect2Row - f));
                    //HWnd.DispCross(new HTuple(points[3].Y), new HTuple(points[3].X), 50, 0);
                    //添加
                    listCornerPoints.Add(points);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return listCornerPoints;
        }
        #endregion

        #region 光度立体法
        public PhotometricStereoImage PhotometricStereo(List<HObject> listOrgImages)
        {
            PhotometricStereoImage ho_ResultImages = new PhotometricStereoImage();
            HOperatorSet.GenEmptyObj(out HObject ho_Images);
            HOperatorSet.GenEmptyObj(out HObject ho_HeightField);
            HOperatorSet.GenEmptyObj(out HObject ho_Gradient);
            HOperatorSet.GenEmptyObj(out HObject ho_Albedo);
            HOperatorSet.GenEmptyObj(out HObject ho_NormalField);
            HOperatorSet.GenEmptyObj(out HObject ho_Curvature);
            HOperatorSet.GenEmptyObj(out HObject ho_RowImage);
            HOperatorSet.GenEmptyObj(out HObject ho_ColImage);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageResult);
            try
            {
                if (listOrgImages.Count < 3)
                {
                    StaticFun.MessageFun.ShowMessage("请输入至少3张及以上的图像！");
                    return ho_ResultImages;
                }
                //安装角度
                HTuple hv_arrayTilts = new HTuple(45, 135, 215.9, 315.5);
                //照射角度
                HTuple hv_arraySlants = new HTuple(31.4, 32.6, 31.7, 30.9);
                foreach (HObject img in listOrgImages)
                {
                    HOperatorSet.ConcatObj(ho_Images, img, out ho_Images);
                }
                ho_HeightField.Dispose();
                ho_NormalField.Dispose();
                ho_Gradient.Dispose();
                ho_Albedo.Dispose();
                //HOperatorSet.PhotometricStereo(ho_Images, out ho_HeightField, out ho_Gradient, out ho_Albedo, hv_arraySlants, hv_arrayTilts, "all", "possion", new HTuple(), new HTuple());
                HTuple hv_ResultType = new HTuple("gradient", "albedo");
                HOperatorSet.UncalibratedPhotometricStereo(ho_Images, out ho_NormalField, out ho_Gradient, out ho_Albedo, "all");
                ho_ResultImages.NormalField = ConvertImageGrayVal(ho_NormalField).Clone();
                ho_ResultImages.Albedo = ConvertImageGrayVal(ho_Albedo);
                ho_Curvature.Dispose();
                HOperatorSet.DerivateVectorField(ho_Gradient, out ho_Curvature, 3, "mean_curvature");
                ho_ResultImages.Curvature = ConvertImageGrayVal(ho_Curvature);
                ho_RowImage.Dispose();
                ho_ColImage.Dispose();
                HOperatorSet.VectorFieldToReal(ho_Gradient, out ho_RowImage, out ho_ColImage);
                ho_ImageResult.Dispose();
                HOperatorSet.AddImage(ho_RowImage, ho_ColImage, out ho_ImageResult, 1, 0);
                ho_ResultImages.Gradient = ConvertImageGrayVal(ho_ImageResult);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"PhotometricStereo:{ex}", true);
            }
            finally
            {
                ho_Images?.Dispose();
                ho_HeightField?.Dispose();
                ho_Gradient?.Dispose();
                ho_Albedo?.Dispose();
                ho_NormalField?.Dispose();
                ho_Curvature?.Dispose();
                ho_RowImage?.Dispose();
                ho_ColImage?.Dispose();
                ho_ImageResult?.Dispose();
            }
            return ho_ResultImages;
        }

        public HObject ConvertImageGrayVal(HObject ho_FloatImage)
        {
            HOperatorSet.GenEmptyObj(out HObject ho_ImageConverted);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageScaled);
            try
            {
                HOperatorSet.MinMaxGray(ho_FloatImage, ho_FloatImage, 0, out HTuple hv_Min, out HTuple hv_Max, out HTuple hv_Range);
                double dMult = 255 / (hv_Max - hv_Min).D;
                double dMin = -1 * dMult * hv_Min.D;
                ho_ImageScaled.Dispose();
                HOperatorSet.ScaleImage(ho_FloatImage, out ho_ImageScaled, dMult, dMin);
                ho_ImageConverted.Dispose();
                HOperatorSet.ConvertImageType(ho_ImageScaled, out ho_ImageConverted, "byte");
                //DispRegion(ho_ImageConverted);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage($"ConvertImageGrayVal:{ex}", true);
            }
            finally
            {
                ho_ImageScaled?.Dispose();
            }
            return ho_ImageConverted;
        }

        #endregion

    }
}



