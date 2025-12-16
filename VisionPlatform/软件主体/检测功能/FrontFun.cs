using Aardvark.Base;
using BaseData;
using GlobalPath;
using HalconDotNet;
using Hi.Ltd;
using PaddleOCR;
using ResultSharp;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using yolov8_Det_Onnx;
using static VisionPlatform.InspectData;
using Mat = OpenCvSharp.Mat;

namespace VisionPlatform
{
    public class FrontFun
    {
        public Function fun;
        public static Yolov8_Det yolov8_Broken = new Yolov8_Det(SavePath.AIFlod + @"\broken.onnx", SavePath.AIFlod + @"\broken.txt");
        public static Yolov8_Det yolov8_Dirty = new Yolov8_Det(SavePath.AIFlod + @"\dirty.onnx", SavePath.AIFlod + @"\dirty.txt");
        public void InitFunction(Function fun)
        {
            this.fun = fun;
        }
        //自动运行时使用
        public bool FrontInspect(InspectData.FrontParam param, InspectItem inspectItem, bool bShow, out FrontResult outData, PhotometricStereoImage photometricImages, List<HObject> listOrgImages)
        {
            bool bResult = true;
            outData = new FrontResult();
            try
            {
                if (param.bQRCode)
                {
                    if (fun.FindCode2D((HTuple)param.QRCode.hv_Handel, out List<string> listStrings))
                    {
                        outData.strQRCode = listStrings[0];
                        if (outData.strQRCode.Substring(0, param.QRCode.nCodeCaptureLength - 1) != param.QRCode.strCode.Substring(0, param.QRCode.nCodeCaptureLength - 1))
                        {
                            bResult = false;
                        }
                    }
                    else
                    {
                        bResult = false;
                    }
                }
                #region 模板匹配
                //HTuple hv_homMat2D = null;
                //if (!fun.FindModel(fun.m_GrayImage, param.modelID, param.locateInParams, out List<LocateOutParams> listLocateResults))
                //{
                //    fun.WriteStringtoImage(25, 50, 50, "定位失败！", "red");
                //    return false;
                //}
                //LocateOutParams locate = listLocateResults[0];
                //HOperatorSet.VectorAngleToRigid(param.modelPoint.X, param.modelPoint.Y, 0, locate.dModelRow, locate.dModelCol, locate.dModelAngle, out hv_homMat2D);
                #endregion
                if (param.bPNCode)
                {
                    if (!PNCodeRecognize(param.PNCode, bShow, out string strPNCode, null))
                    {
                        bResult = false;
                    }
                    outData.strPNCode = strPNCode;
                }
                if (!DefectAI(param.Defect, inspectItem, photometricImages.NormalField))
                {
                    bResult = false;
                }
                if (!LabelMoveInspect(param.LabelMove, bShow, out LabelMoveResult labelMoveResult, photometricImages.Albedo))
                {
                    bResult = false;
                }
                outData.labelMoveResult = labelMoveResult;
                if (param.bSealedLabel)
                {
                    if (!SealedLabelInspect(param.SealedLabel, bShow, out SealedLabelResult sealedLabelResult, photometricImages.Albedo))
                    {
                        bResult = false;
                    }
                    outData.sealLabelResult = sealedLabelResult;
                }
            }
            catch (HalconException ex)
            {
                bResult = false;
                MessageFun.ShowMessage(ex, true);
            }
            finally
            {

            }
            return bResult;
        }

        public void FrontResultShow(CamInspectItem camItem, InspectData.FrontParam inData, ref FrontResult result)
        {
            bool bResult = true;
            try
            {
                FontShowParam fontParam = StaticFun.MessageFun.ReadFontParam(camItem.cam, camItem.item);
                int nColStart = 50;
                int nRowSite = fontParam.nRowStartPos;
                int nColSite = fontParam.nColStartPos;
                int nFrontSize = fontParam.nFrontSize;
                string strColor = "green";
                #region 二维码
                if (inData.bQRCode)
                {
                    fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "二维码", "green");
                    strColor = "green";
                    if (result.strQRCode != null)
                    {
                        if (result.strQRCode.Length != inData.QRCode.nCodeLength)
                        {
                            strColor = "red";
                            bResult = false;
                        }
                        if (result.strQRCode.Substring(0, inData.QRCode.nCodeCaptureLength - 1) != inData.QRCode.strCode.Substring(0, inData.QRCode.nCodeCaptureLength - 1))
                        {
                            strColor = "red";
                            bResult = false;
                        }
                    }
                    else
                    {
                        strColor = "red";
                        bResult = false;
                        result.strQRCode = "null";
                    }
                    fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, result.strQRCode, strColor);
                    nRowSite += fontParam.nRowGap;
                }
                #endregion

                #region 周期码
                if (inData.bPNCode)
                {
                    fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "周期码", "green");
                    strColor = "green";
                    if (result.strPNCode != inData.PNCode.strPNCode)
                    {
                        strColor = "red";
                        bResult = false;
                    }
                    fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, result.strPNCode, strColor);
                    nRowSite += fontParam.nRowGap;
                }
                #endregion
                #region 标签有无及角度
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "标签有无", "green");
                strColor = "green";
                string strExist = "有标签";
                if (!result.labelMoveResult.bExist)
                {
                    strColor = "red";
                    strExist = "无标签";
                    bResult = false;
                }
                else
                {
                    strExist = strExist + $",角度偏移：{result.labelMoveResult.dAngleRotate}°";
                    if (result.labelMoveResult.dAngleRotate > inData.LabelMove.AngleValue.dMax ||
                        result.labelMoveResult.dAngleRotate < inData.LabelMove.AngleValue.dMin)
                    {
                        strColor = "red";
                        bResult = false;
                    }
                }
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, strExist, strColor);
                nRowSite += fontParam.nRowGap;
                #endregion

                #region 标签偏移
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "标签偏移", "green");
                strColor = "green";
                if (null != result.labelMoveResult.dicLabelMoveValues)
                {
                    foreach (var label in result.labelMoveResult.dicLabelMoveValues)
                    {
                        if (null != inData.LabelMove.dicLabelMoveItems && inData.LabelMove.dicLabelMoveItems.ContainsKey(label.Key))
                        {
                            LabelMoveItem itemParam = inData.LabelMove.dicLabelMoveItems[label.Key];
                            if (label.Value > itemParam.dist.dMax || label.Value < itemParam.dist.dMin)
                            {
                                strColor = "red";
                                bResult = false;
                            }
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, label.Value.ToString(), strColor);
                            nColSite = nColSite + fontParam.nColGap;
                        }
                    }
                }
                nRowSite += fontParam.nRowGap;
                #endregion

                #region 鼓包褶皱脏污
                nColSite = fontParam.nColStartPos;
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "鼓包褶皱脏污", "green");
                strColor = "green";
                if (!result.bDefect)
                {
                    strColor = "red";
                    bResult = false;
                }
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, result.bDefect.ToString(), strColor);
                nRowSite += fontParam.nRowGap;
                #endregion

                string strOK = "OK";
                strColor = "green";
                if (bResult == false)
                {
                    strOK = "NG";
                    strColor = "red";
                }
                fun.WriteStringtoImage(fontParam.nOKSize, fontParam.nOKRow, fontParam.nOKCol, strOK, strColor);
            }
            catch (SystemException ex)
            {
                ex.Log();
            }
        }
        public bool PNCodeRecognize(PNCodeParam param, bool bShow, out string strPNCode, HTuple hv_homMat2D = null)
        {
            strPNCode = "";
            bool bResult = true;
            HOperatorSet.GenEmptyObj(out HObject ho_ROI);
            HOperatorSet.GenEmptyObj(out HObject ho_TransRegion);
            try
            {
                if (param.rect2ROI.dLength1 == 0)
                {
                    StaticFun.MessageFun.ShowMessage("请先设置检测区域");
                    return false;
                }
                Rect2 rect2 = param.rect2ROI;
                ho_ROI.Dispose();
                HOperatorSet.GenRectangle2(out ho_ROI, param.rect2ROI.dRect2Row, param.rect2ROI.dRect2Col, param.rect2ROI.dPhi, param.rect2ROI.dLength1, param.rect2ROI.dLength2);
                if (null != hv_homMat2D)
                {
                    ho_TransRegion.Dispose();
                    HOperatorSet.AffineTransRegion(ho_ROI, out ho_TransRegion, hv_homMat2D, "nearest_neighbor");
                    fun.DispRegion(ho_TransRegion);
                    HOperatorSet.SmallestRectangle2(ho_TransRegion, out HTuple hv_row, out HTuple hv_col, out HTuple hv_phi, out HTuple hv_len1, out HTuple hv_len2);
                    if (0 == hv_row.TupleLength())
                    {
                        bResult = false;
                    }
                    rect2 = new Rect2(hv_row.D, hv_col.D, hv_phi.D, hv_len1.D, hv_len2.D);
                }
                List<Rect2> listRect2 = new List<Rect2>() { rect2 };
                // List<List<List<int>>> boxsss = OCR_box1(listRect2);
                List<OpenCvSharp.Point[]> listPoints = fun.OCR_box(listRect2);
                List<Mat> img_list = new List<Mat>();
                for (int j = 0; j < listPoints.Count; j++)
                {
                    //Mat crop_img1 = PaddleOcrUtility.get_rotate_crop_image1(fun.AIimage, boxsss[j]);
                    Mat crop_img = PaddleOcrUtility.get_rotate_crop_image(fun.AIimage, listPoints[j]);
                    img_list.Add(crop_img);
                }
                List<List<OCRPredictResult>> ocr_result = Function.pP_OCRv4.InferenceV5(fun.AIimage, img_list);
                if (ocr_result.Count == 0)
                {
                    return false;
                }
                for (int i = 0; i < ocr_result[0].Count(); i++)
                {
                    if (ocr_result[0][i].score > 0.5)
                    {
                        strPNCode = ocr_result[0][i].text;
                        break;
                    }
                }
                if (param.strPNCode != "" && strPNCode != param.strPNCode)
                {
                    bResult = false;
                }
                MessageFun.ShowMessage("字符检测结果：" + strPNCode);
            }
            catch (HalconException ex)
            {
                bResult = false;
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            finally
            {
                ho_ROI?.Dispose();
                ho_TransRegion?.Dispose();
            }
            return bResult;
        }

        public bool LabelMoveInspect(LabelMoveParam param, bool bShow, out LabelMoveResult res, HObject ho_LabelImage = null)
        {
            bool bResult = true;
            res = new LabelMoveResult();
            try
            {
                if (null == ho_LabelImage || !ho_LabelImage.IsInitialized())
                {
                    ho_LabelImage = fun.m_GrayImage.Clone();
                }
                fun.DispRegion(ho_LabelImage);
                if (!fun.NccLocate(param.nccLocate, out Rect2 rect2, ho_LabelImage))
                {
                    res.bExist = false;
                    return false;
                }
                fun.ShowRect2(rect2, "blue");
                double dAngle = Math.Round(Math.Abs(new HTuple(rect2.dPhi - param.nccLocate.rect2.dPhi).TupleDeg().D), 0);
                res.dAngleRotate = dAngle;
                string strColor = "green";
                if (param.AngleValue.bFlag && dAngle > param.AngleValue.dMax)
                {
                    bResult = false;
                    strColor = "red";
                }
                foreach (var item in param.dicLabelMoveItems)
                {
                    if (item.Key == "") continue;
                    //仿射变换
                    HOperatorSet.VectorAngleToRigid(param.nccLocate.rect2.dRect2Row, param.nccLocate.rect2.dRect2Col, 0,
                        rect2.dRect2Row, rect2.dRect2Col, rect2.dPhi, out HTuple homMat2D);
                    double dDist = 0;
                    Line boxLine = new Line();
                    switch (item.Value.type)
                    {
                        case MoveType.point_line:
                            boxLine = AffineTransLine(item.Value.boxLine, homMat2D, ho_LabelImage);
                            HOperatorSet.DistancePl(rect2.dRect2Row, rect2.dRect2Col, boxLine.dStartRow, boxLine.dStartCol, boxLine.dEndRow, boxLine.dEndCol, out HTuple hv_Dist);
                            dDist = Math.Round(hv_Dist.D, 2);
                            break;
                        case MoveType.line_line:
                            Line labelLine = AffineTransLine(item.Value.labelLine, homMat2D, ho_LabelImage);
                            boxLine = AffineTransLine(item.Value.boxLine, homMat2D, ho_LabelImage);
                            HOperatorSet.DistanceSl(labelLine.dStartRow, labelLine.dStartCol, labelLine.dEndRow, labelLine.dEndCol,
                                                    boxLine.dStartRow, boxLine.dStartCol, boxLine.dEndRow, boxLine.dEndCol, out HTuple hv_DistMin, out HTuple hv_DistMax);
                            dDist = Math.Round(hv_DistMax.D, 2);
                            break;
                        case MoveType.point_point:
                            break;
                    }
                    res.dicLabelMoveValues.Add(item.Key, dDist);
                }
            }
            catch (HalconException ex)
            {
                bResult = false;
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return bResult;
        }

        public bool SealedLabelInspect(SealedLabelParam param, bool bShow, out SealedLabelResult res, HObject ho_LabelImage = null)
        {
            bool bResult = true;
            res = new SealedLabelResult();
            Rect2 rect22 = new Rect2();
            try
            {
                if (null != ho_LabelImage) fun.DispRegion(ho_LabelImage);
                if (!fun.NccLocate(param.nccLocate1, out Rect2 rect21, ho_LabelImage))
                {
                    res.bExist1 = false;
                }
                else
                {
                    fun.ShowRect2(rect21, "blue");
                }
                if (param.bTwoLabels)
                {
                    if (fun.NccLocate(param.nccLocate2, out rect22, ho_LabelImage))
                    {
                        res.bExist2 = true;
                        fun.ShowRect2(rect22, "blue");
                    }
                }
                if (!res.bExist1 && !res.bExist2)
                {
                    bResult = false;
                    return bResult;
                }
                foreach (var item in param.listROIItems)
                {
                    //仿射变换
                    double dDist1 = 0, dDist2 = 0;
                    HTuple hv_homMat2D = new HTuple();
                    if (res.bExist1)
                    {
                        HOperatorSet.VectorAngleToRigid(param.nccLocate1.rect2.dRect2Row, param.nccLocate1.rect2.dRect2Col, 0, rect21.dRect2Row, rect21.dRect2Col, rect21.dPhi, out hv_homMat2D);
                    }
                    if (!res.bExist1 && res.bExist2)
                    {
                        HOperatorSet.VectorAngleToRigid(param.nccLocate2.rect2.dRect2Row, param.nccLocate2.rect2.dRect2Col, 0, rect22.dRect2Row, rect22.dRect2Col, rect22.dPhi, out hv_homMat2D);
                    }
                    Line line = AffineTransLine(item.roiLine, hv_homMat2D, ho_LabelImage);
                    if (res.bExist1)
                    {
                        HOperatorSet.DistancePl(rect21.dRect2Row, rect21.dRect2Col, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out HTuple hv_Dist);
                        dDist1 = Math.Round(hv_Dist.D, 2);
                    }
                    if (res.bExist2)
                    {
                        HOperatorSet.DistancePl(rect22.dRect2Row, rect22.dRect2Col, line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol, out HTuple hv_Dist);
                        dDist2 = Math.Round(hv_Dist.D, 2);
                    }
                    res.listDist1.Add(dDist1);
                    res.listDist2.Add(dDist2);
                }
            }
            catch (HalconException ex)
            {
                bResult = false;
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return bResult;
        }

        public Line AffineTransLine(ROILine roiLine, HTuple homMat2D, HObject ho_Image)
        {
            Line lineOut = new Line();
            try
            {
                HOperatorSet.AffineTransPoint2d(homMat2D, roiLine.rect2.dRect2Row, roiLine.rect2.dRect2Col, out HTuple hv_x, out HTuple hv_y);
                Rect2 rect2 = new Rect2(hv_x, hv_y, roiLine.rect2.dPhi, roiLine.rect2.dLength1, roiLine.rect2.dLength2);
                fun.ShowRect2(rect2);
                fun.GetRect2CornerPoint(rect2, out PointF[] points);
                Line line = new Line();
                switch (roiLine.lineParam.measure.direct)
                {
                    case MesDirect.UpDown:
                        line = new Line((points[0].X + points[3].X) / 2.0,
                                        (points[0].Y + points[3].Y) / 2.0,
                                        (points[1].X + points[2].X) / 2.0,
                                        (points[1].Y + points[2].Y) / 2.0);
                        break;
                    case MesDirect.DownUp:
                        line = new Line((points[1].X + points[2].X) / 2.0,
                                        (points[1].Y + points[2].Y) / 2.0,
                                        (points[0].X + points[3].X) / 2.0,
                                        (points[0].Y + points[3].Y) / 2.0);
                        break;
                    case MesDirect.LeftRight:
                        line = new Line((points[2].X + points[3].X) / 2.0,
                                       (points[2].Y + points[3].Y) / 2.0,
                                       (points[0].X + points[1].X) / 2.0,
                                       (points[0].Y + points[1].Y) / 2.0);
                        break;
                    case MesDirect.RightLeft:
                        line = new Line((points[0].X + points[1].X) / 2.0,
                                       (points[0].Y + points[1].Y) / 2.0,
                                       (points[2].X + points[3].X) / 2.0,
                                       (points[2].Y + points[3].Y) / 2.0);
                        break;
                    default:
                        break;
                }
                roiLine.lineParam.lineIn = line;
                fun.FitLine(roiLine.lineParam, out lineOut, out _, ho_Image);
                fun.HWnd.DispLine(lineOut.dStartRow, lineOut.dStartCol, lineOut.dEndRow, lineOut.dEndCol);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return lineOut;
        }

        public bool DividRubberRect2(PointF center, double dPhi, ROIParam roi, bool[] arrayDelTM, out List<Rect2> listRect2, out HObject ho_Rect2Regions)
        {
            bool bResult = true;
            listRect2 = new List<Rect2>();

            HOperatorSet.GenEmptyObj(out ho_Rect2Regions);
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);

            try
            {
                double dMoveRow = 0, dMoveCol = 0;
                double dRow = 0, dCol = 0;
                if (roi.bDivid)
                {
                    roi.nNum = 1;
                    arrayDelTM = new bool[roi.nNum];
                }
                for (int i = 0; i < roi.nNum; i++)
                {
                    dMoveRow = center.Y - (Math.Cos(dPhi) * roi.nMoveY) - (Math.Sin(dPhi) * roi.nMoveX);
                    dMoveCol = center.X - (Math.Sin(dPhi) * roi.nMoveY) + (Math.Cos(dPhi) * roi.nMoveX);
                    dRow = dMoveRow - i * Math.Sin(dPhi) * roi.nGap;
                    dCol = dMoveCol + i * Math.Cos(dPhi) * roi.nGap;
                    ho_Rect2.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rect2, dRow, dCol, dPhi, roi.nROIWidth, roi.nROIHeight);
                    if (!arrayDelTM[i])
                    {
                        listRect2.Add(new Rect2(dRow, dCol, dPhi, roi.nROIWidth, roi.nROIHeight));
                        HOperatorSet.ConcatObj(ho_Rect2Regions, ho_Rect2, out ho_Rect2Regions);
                    }
                }
                fun.DispRegion(ho_Rect2Regions);
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage("胶壳定位错位：" + ex.ToString(), true);
                bResult = false;
            }
            finally
            {
                ho_Rect2?.Dispose();
            }
            return bResult;
        }
        public BaseData.Line FitBaseLine(InspectData.BaseLineParam param)
        {
            BaseData.Line line = new BaseData.Line();
            try
            {
                fun.GetRect2CornerPoint(param.rect2, out PointF[] points);
                LineParam lineParam = new LineParam();
                //lineParam.measure = param.lineMes;
                lineParam.measure.nLen1 = param.nLen2;
                lineParam.measure.dLen2 = 3;
                double dRow1 = (points[0].X + points[3].X) / 2;
                double dRow2 = (points[1].X + points[2].X) / 2;
                double dCol1 = (points[0].Y + points[3].Y) / 2;
                double dCol2 = (points[1].Y + points[2].Y) / 2;
                if (param.strDirection == "从左往右")
                {
                    lineParam.lineIn.dStartRow = dRow1;
                    lineParam.lineIn.dStartCol = dCol1;
                    lineParam.lineIn.dEndRow = dRow2;
                    lineParam.lineIn.dEndCol = dCol2;
                }
                else if (param.strDirection == "从右往左")
                {
                    lineParam.lineIn.dStartRow = dRow2;
                    lineParam.lineIn.dStartCol = dCol2;
                    lineParam.lineIn.dEndRow = dRow1;
                    lineParam.lineIn.dEndCol = dCol1;
                }
                if (!fun.FitLine(lineParam, out line, out _))
                {
                    StaticFun.MessageFun.ShowMessage("基准线拟合错误。");
                }
                fun.HWnd.DispLine(line.dStartRow, line.dStartCol, line.dEndRow, line.dEndCol);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return line;
        }

        public bool SideRubberInsert(InspectData.SideRubberParam param, bool bShow, out SideRubberResult outData)
        {
            bool bResult = true;
            outData = new SideRubberResult()
            {
                dic_FitDist = new Dictionary<int, List<double>>(),
                dic_TMExist = new Dictionary<int, List<bool>>(),
                dic_TMArea = new Dictionary<int, List<double>>(),
            };
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2Left);
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2Right);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_OpenCircle);
            HOperatorSet.GenEmptyObj(out HObject ho_Connections);
            HOperatorSet.GenEmptyObj(out HObject ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out HObject ho_TransRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_DiffRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);
            HOperatorSet.GenEmptyObj(out HObject ho_tempRect2);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionCols);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionRows);
            try
            {
                double dRow = 0, dCol = 0;      //定位中心点
                HTuple hv_Phi = new HTuple();  //定位角度
                if (param.method == LocateMethod.match)
                {
                    //param.rubberLocate.nRubberNum = 1;
                    //if (NccRubberLocate( param.rubberLocate, out bool bMatch, out HObject ho_RubberRegion, out List<Rect2> listRubberRect2))
                    //{
                    //    dRow = listRubberRect2[0].dRect2Row;
                    //    dCol = listRubberRect2[0].dRect2Col;
                    //    hv_Phi = new HTuple(listRubberRect2[0].dPhi);
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
                else if (param.method == LocateMethod.roi)
                {
                    ho_Rect2Left.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rect2Left, param.leftRect2.dRect2Row, param.leftRect2.dRect2Col, param.leftRect2.dPhi, param.leftRect2.dLength1, param.leftRect2.dLength2);
                    ho_Rect2Right.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rect2Right, param.rightRect2.dRect2Row, param.rightRect2.dRect2Col, param.rightRect2.dPhi, param.rightRect2.dLength1, param.rightRect2.dLength2);
                    ho_RegionUnion.Dispose();
                    HOperatorSet.Union2(ho_Rect2Left, ho_Rect2Right, out ho_RegionUnion);
                    ho_ImageReduced.Dispose();
                    HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_RegionUnion, out ho_ImageReduced);
                    ho_Region.Dispose();
                    HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, 50, 255);
                    //fun.DispRegion(ho_Region, draw:"fill");
                    ho_OpenCircle.Dispose();
                    HOperatorSet.OpeningCircle(ho_Region, out ho_OpenCircle, 3);
                    ho_Connections.Dispose();
                    HOperatorSet.Connection(ho_OpenCircle, out ho_Connections);
                    ho_SelectedRegions.Dispose();
                    HOperatorSet.SelectShape(ho_Connections, out ho_SelectedRegions, "area", "and", 5000, 999999);
                    //fun.DispRegion(ho_Region,"red", draw: "fill");
                    CenterPoint(ho_Rect2Left, ho_SelectedRegions, out HTuple hv_Row1, out HTuple hv_Col1);
                    CenterPoint(ho_Rect2Right, ho_SelectedRegions, out HTuple hv_Row2, out HTuple hv_Col2);
                    if (hv_Row1.TupleLength() == 0)
                    {
                        return false;
                    }
                    dRow = (hv_Row1 + hv_Row2).D / 2.0;
                    dCol = (hv_Col1 + hv_Col2).D / 2.0;
                    HOperatorSet.AngleLl(hv_Row1, hv_Col1, hv_Row1, hv_Col1 + 500, hv_Row1, hv_Col1, hv_Row2, hv_Col2, out hv_Phi);
                }
                else
                {
                    fun.WriteStringtoImage(20, 50, 50, "请选择一种定位方法！", "red", strEnglish: "Please choose a positioning method!");
                    return false;
                }

                Rect2 rect2 = new Rect2(dRow + param.roi.nMoveY, dCol + param.roi.nMoveX, hv_Phi, param.roi.nROIWidth, param.roi.nROIHeight);
                ho_Rect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_Rect2, rect2.dRect2Row, rect2.dRect2Col, rect2.dPhi, rect2.dLength1, rect2.dLength2);
                fun.DispRegion(ho_Rect2);
                double dlen1 = param.roi.nROIWidth - 2 * param.roi.nROIWidth;
                dlen1 = dlen1 <= 0 ? 1 : dlen1;
                ho_tempRect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_tempRect2, rect2.dRect2Row, rect2.dRect2Col, rect2.dPhi, dlen1, rect2.dLength2 * 1.2);
                //fun.DispRegion(ho_tempRect2,"blue");
                ho_Region.Dispose();
                HOperatorSet.Difference(ho_Rect2, ho_tempRect2, out ho_Region);
                ho_Connections.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_Connections);
                ho_TransRegion.Dispose();
                HOperatorSet.SortRegion(ho_Connections, out ho_TransRegion, "first_point", "true", "column");
                ho_Region.Dispose();
                HOperatorSet.SelectObj(ho_TransRegion, out ho_Region, 1);  //第一个端子
                                                                           //fun.DispRegion(ho_Region, "blue");                                                             //fun.HWnd.DispObj(ho_Region);
                HOperatorSet.GenEmptyObj(out ho_RegionCols);
                HOperatorSet.ConcatObj(ho_RegionCols, ho_Region, out ho_RegionCols);

                //从第二个端子开始
                double dMove = 0, dMoveRow = 0, dMoveCol = 0;
                for (int m = 1; m < param.nCols; m++)
                {
                    dMove = m * (param.roi.nROIWidth + param.roi.nGap);
                    dMoveRow = Math.Sin(rect2.dPhi) * dMove;
                    dMoveCol = Math.Cos(rect2.dPhi) * dMove;
                    ho_SelectedRegions.Dispose();
                    HOperatorSet.MoveRegion(ho_Region, out ho_SelectedRegions, -dMoveRow, dMoveCol);
                    HOperatorSet.ConcatObj(ho_RegionCols, ho_SelectedRegions, out ho_RegionCols);
                }
                ho_Region.Dispose();
                HOperatorSet.Union1(ho_RegionCols, out ho_Region);
                HOperatorSet.GenEmptyObj(out ho_RegionRows);
                HOperatorSet.ConcatObj(ho_RegionRows, ho_Region, out ho_RegionRows);
                // fun.DispRegion(ho_SumRegion, "red");
                if (param.nRows > 1)
                {
                    for (int m = 1; m < param.nRows; m++)
                    {

                        dMove = m * (2 * param.roi.nROIHeight + param.nRowGap);
                        dMoveRow = Math.Sin(rect2.dPhi - Math.PI / 2.0) * dMove;
                        dMoveCol = Math.Cos(rect2.dPhi - Math.PI / 2.0) * dMove;
                        ho_SelectedRegions.Dispose();
                        HOperatorSet.MoveRegion(ho_Region, out ho_SelectedRegions, -dMoveRow, dMoveCol);
                        HOperatorSet.ConcatObj(ho_RegionRows, ho_SelectedRegions, out ho_RegionRows);
                    }
                }
                fun.DispRegion(ho_RegionRows, "blue");
                List<double> listFitDistCols = new List<double>();
                List<bool> listTMExistCols = new List<bool>();
                List<double> listTMAreaCols = new List<double>();
                bool bExist;
                for (int r = 0; r < ho_RegionRows.CountObj(); r++)
                {
                    listFitDistCols = new List<double>();
                    listTMExistCols = new List<bool>();
                    listTMAreaCols = new List<double>();
                    ho_SelectedRegions.Dispose();
                    HOperatorSet.SelectObj(ho_RegionRows, out ho_SelectedRegions, r + 1);
                    ho_ImageReduced.Dispose();
                    HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_SelectedRegions, out ho_ImageReduced);
                    ho_Region.Dispose();
                    HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, 0, 50);
                    ho_OpenCircle.Dispose();
                    HOperatorSet.ClosingCircle(ho_Region, out ho_OpenCircle, 3);
                    ho_Connections.Dispose();
                    HOperatorSet.Connection(ho_OpenCircle, out ho_Connections);
                    ho_Region.Dispose();
                    HOperatorSet.FillUp(ho_Connections, out ho_Region);
                    ho_OpenCircle.Dispose();
                    HOperatorSet.OpeningCircle(ho_Region, out ho_OpenCircle, 2);
                    ho_Connections.Dispose();
                    HOperatorSet.Connection(ho_OpenCircle, out ho_Connections);
                    //fun.DispRegion(ho_Connections);
                    ho_Region.Dispose();
                    HOperatorSet.SelectShape(ho_Connections, out ho_Region, "area", "and", 1000, 999999);
                    ho_Connections.Dispose();
                    HOperatorSet.Connection(ho_SelectedRegions, out ho_Connections);
                    ho_TransRegion.Dispose();
                    HOperatorSet.SortRegion(ho_Connections, out ho_TransRegion, "first_point", "true", "column");
                    ho_RegionCols.Dispose();
                    HOperatorSet.Intersection(ho_TransRegion, ho_Region, out ho_RegionCols);
                    ho_Region.Dispose();
                    HOperatorSet.ShapeTrans(ho_RegionCols, out ho_Region, "convex");
                    ho_TransRegion.Dispose();
                    HOperatorSet.ErosionRectangle1(ho_Region, out ho_TransRegion, 11, 7);
                    ho_Rect2.Dispose();
                    HOperatorSet.ShapeTrans(ho_RegionCols, out ho_Rect2, "rectangle2");
                    //fun.DispRegion(ho_Rect2);
                    for (int c = 0; c < ho_RegionCols.CountObj(); c++)
                    {
                        //屏蔽端子 
                        if (null != param.arrayDelTM && param.arrayDelTM[r * param.nCols + c])
                        {
                            listTMAreaCols.Add(-1);
                            listTMExistCols.Add(true);
                            listFitDistCols.Add(-1);
                            continue;
                        }
                        #region 有无端子
                        bExist = true;
                        ho_SelectedRegions.Dispose();
                        HOperatorSet.SelectObj(ho_Rect2, out ho_SelectedRegions, c + 1);
                        HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out HTuple hv_row, out HTuple hv_col, out HTuple hv_phi, out HTuple hv_len1, out HTuple hv_len2);
                        rect2 = new Rect2(hv_row, hv_col, hv_phi, hv_len1, hv_len2);
                        fun.Rect2Trans(ref rect2);
                        fun.GetRect2CornerPoint(rect2, out PointF[] points);
                        ho_ImageReduced.Dispose();
                        HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_SelectedRegions, out ho_ImageReduced);
                        ho_Region.Dispose();
                        HOperatorSet.VarThreshold(ho_ImageReduced, out ho_Region, 55, 55, 0.25, 9, "light");
                        //fun.DispRegion(ho_Region);
                        ho_OpenCircle.Dispose();
                        HOperatorSet.ClosingCircle(ho_Region, out ho_OpenCircle, 5);
                        //fun.DispRegion(ho_OpenCircle);
                        ho_ImageReduced.Dispose();
                        HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_OpenCircle, out ho_ImageReduced);
                        //端子有无
                        ho_Region.Dispose();
                        HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, param.nTMThd, 255);
                        ho_OpenCircle.Dispose();
                        HOperatorSet.ClosingCircle(ho_Region, out ho_OpenCircle, 3.5);
                        ho_Connections.Dispose();
                        HOperatorSet.Connection(ho_OpenCircle, out ho_Connections);
                        ho_SelectedRegions.Dispose();
                        HOperatorSet.SelectShape(ho_Connections, out ho_SelectedRegions, "area", "and", 50, 9999999);
                        ho_OpenCircle.Dispose();
                        HOperatorSet.Union1(ho_SelectedRegions, out ho_OpenCircle);
                        fun.DispRegion(ho_OpenCircle, "yellow");
                        HOperatorSet.RegionFeatures(ho_OpenCircle, "area", out HTuple hv_area);
                        if (hv_area.TupleLength() == 0 || hv_area.D < param.nTMMinArea)
                        {
                            bExist = false;
                            fun.HWnd.SetLineWidth(2);
                            fun.DispRegion(ho_SelectedRegions, "red");
                            bResult = false;
                            fun.HWnd.SetLineWidth(1);
                        }
                        listTMAreaCols.Add(hv_area.D);
                        listTMExistCols.Add(bExist);
                        #endregion

                        //卡扣高度
                        ho_Region.Dispose();
                        HOperatorSet.ShapeTrans(ho_OpenCircle, out ho_Region, "rectangle1");
                        //fun.DispRegion(ho_Region);
                        ho_SelectedRegions.Dispose();
                        HOperatorSet.SelectObj(ho_TransRegion, out ho_SelectedRegions, c + 1);
                        //fun.DispRegion(ho_SelectedRegions, "yellow");
                        ho_DiffRegion.Dispose();
                        HOperatorSet.Difference(ho_SelectedRegions, ho_Region, out ho_DiffRegion);
                        // fun.DispRegion(ho_DiffRegion);
                        ho_ImageReduced.Dispose();
                        HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_DiffRegion, out ho_ImageReduced);
                        ho_Region.Dispose();
                        HOperatorSet.VarThreshold(ho_ImageReduced, out ho_Region, 35, 35, 0.35, param.nFitThd, "light");
                        //HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, param.nFitThd, param.nTMThd - 5);
                        ho_OpenCircle.Dispose();
                        HOperatorSet.ClosingRectangle1(ho_Region, out ho_OpenCircle, 5, 5);
                        ho_Region.Dispose();
                        HOperatorSet.OpeningCircle(ho_OpenCircle, out ho_Region, 1.5);
                        ho_Connections.Dispose();
                        HOperatorSet.Connection(ho_Region, out ho_Connections);
                        HOperatorSet.RegionFeatures(ho_Connections, "inner_radius", out HTuple dr);
                        //fun.DispRegion(ho_Connections,"blue");
                        ho_Region.Dispose();
                        HOperatorSet.SelectShape(ho_Connections, out ho_Region, "inner_radius", "and", 3, 15);
                        //HOperatorSet.RegionFeatures(ho_Region, "width", out HTuple hv_w);
                        ho_Connections.Dispose();
                        HOperatorSet.SelectShape(ho_Region, out ho_Connections, "width", "and", param.nFitWidthMin, param.nFitWidthMax);
                        //fun.DispRegion(ho_Connections, "yellow");
                        HOperatorSet.RegionFeatures(ho_Connections, "height", out HTuple hv_wg);
                        ho_SelectedRegions.Dispose();
                        HOperatorSet.SelectShape(ho_Connections, out ho_SelectedRegions, "height", "and", param.nFitHeightMin, param.nFitHeightMax);
                        fun.DispRegion(ho_SelectedRegions, "yellow");
                        ho_RegionUnion.Dispose();
                        HOperatorSet.Union1(ho_SelectedRegions, out ho_RegionUnion);
                        ho_Region.Dispose();
                        HOperatorSet.GenRegionLine(out ho_Region, points[0].X, points[0].Y, points[1].X, points[1].Y);
                        HOperatorSet.DistanceLr(ho_RegionUnion, points[0].X, points[0].Y, points[1].X, points[1].Y, out HTuple hv_DistMin, out HTuple hv_DistMax);
                        HOperatorSet.DistanceRrMin(ho_RegionUnion, ho_Region, out hv_DistMin, out HTuple r1, out HTuple c1, out HTuple r2, out HTuple c2);
                        double dDist = 0;
                        if (0 != hv_DistMin.TupleLength())
                        {
                            fun.HWnd.DispArrow(r1, c1, r2, c2, 3);
                            dDist = Math.Round(hv_DistMin.D, 2);
                        }
                        listFitDistCols.Add(dDist);
                        if (dDist > param.dDistMax || dDist < param.dDistMin)
                        {
                            fun.HWnd.SetLineWidth(2);
                            fun.DispRegion(ho_RegionUnion, "red");
                            fun.DispRegion(ho_Connections, "red");
                            bResult = false;
                            fun.HWnd.SetLineWidth(1);
                        }
                    }
                    outData.dic_FitDist.Add(r, listFitDistCols);
                    outData.dic_TMExist.Add(r, listTMExistCols);
                    outData.dic_TMArea.Add(r, listTMAreaCols);
                }
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage(ex.ToString());
                bResult = false;
            }
            finally
            {
                ho_Rect2Left?.Dispose();
                ho_Rect2Right?.Dispose();
                ho_RegionUnion?.Dispose();
                ho_ImageReduced?.Dispose();
                ho_Region?.Dispose();
                ho_OpenCircle?.Dispose();
                ho_Connections?.Dispose();
                ho_SelectedRegions?.Dispose();
                ho_TransRegion?.Dispose();
                ho_Rect2?.Dispose();
                ho_tempRect2?.Dispose();
                ho_RegionCols?.Dispose();
                ho_RegionRows?.Dispose();
            }
            return bResult;
        }

        public void SideRubberResultShow(int cam, InspectData.SideRubberParam inData, SideRubberResult result)
        {
            try
            {
                FontShowParam fontParam = StaticFun.MessageFun.ReadFontParam(cam, InspectItem.Front);
                if (null == result.dic_TMExist) return;
                int nColStart = 15;
                int nRowSite = fontParam.nRowStartPos;
                int nColSite = fontParam.nColStartPos;
                int nFrontSize = fontParam.nFrontSize;
                int nTM = inData.nRows * inData.nCols;
                for (int n = 0; n < inData.nRows; n++)
                {
                    for (int m = 0; m < inData.nCols; m++)
                    {
                        nColSite = fontParam.nColStartPos + (n * inData.nCols + m) * fontParam.nColGap;
                        fun.WriteStringtoImage(nFrontSize, fontParam.nRowStartPos - 80, nColSite, (n + 1).ToString() + "-" + (m + 1).ToString(), "green", bBox: true);
                    }

                }
                #region 端子有无
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "端子有无", "green", strEnglish: "Terminal presence or absence");
                int i = 0;
                foreach (int row in result.dic_TMExist.Keys)
                {
                    List<bool> list = result.dic_TMExist[row];
                    for (int n = 0; n < inData.nCols; n++)
                    {
                        nColSite = fontParam.nColStartPos + (i * list.Count + n) * fontParam.nColGap;
                        if (inData.arrayDelTM != null && inData.arrayDelTM[row * inData.nCols + n])
                        {
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, "[]", "green");
                            continue;
                        }
                        if (!list[n])
                        {
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, "NG", "red");
                            fun.WriteStringtoImage(nFrontSize, fontParam.nRowStartPos - 80, nColSite, (i + 1).ToString() + "-" + (n + 1).ToString(), "red", bBold: true);
                        }
                        else
                        {
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, "OK", "green");
                        }
                    }
                    i++;
                }
                nRowSite = nRowSite + fontParam.nRowGap;
                #endregion

                #region 端子面积
                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "端子面积", "green", strEnglish: "Terminal area");
                i = 0;
                foreach (List<double> list in result.dic_TMArea.Values)
                {
                    for (int n = 0; n < list.Count; n++)
                    {
                        nColSite = fontParam.nColStartPos + (i * list.Count + n) * fontParam.nColGap;
                        double dRatio = Math.Round(list[n], 2);
                        if (dRatio < inData.nTMMinArea || dRatio > 9999)
                        {
                            if (dRatio == -1)
                            {
                                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, "[]", "green");
                            }
                            else
                            {
                                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, dRatio.ToString(), "red");
                                fun.WriteStringtoImage(nFrontSize, fontParam.nRowStartPos - 80, nColSite, (i + 1).ToString() + "-" + (n + 1).ToString(), "red", bBold: true);
                            }

                        }
                        else
                        {
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, dRatio.ToString());
                        }
                    }
                    i++;
                }
                nRowSite = nRowSite + fontParam.nRowGap;
                #endregion

                #region 卡扣距离

                fun.WriteStringtoImage(nFrontSize, nRowSite, nColStart, "卡扣距离", "green", strEnglish: "Snap distance");
                i = 0;
                foreach (List<double> list in result.dic_FitDist.Values)
                {
                    for (int n = 0; n < list.Count; n++)
                    {
                        nColSite = fontParam.nColStartPos + (i * list.Count + n) * fontParam.nColGap;
                        double dRatio = Math.Round(list[n], 2);
                        if (dRatio > inData.dDistMax || dRatio < inData.dDistMin)
                        {
                            if (dRatio == -1)
                            {
                                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, "[]", "green");
                            }
                            else
                            {
                                fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, dRatio.ToString(), "red");
                                fun.WriteStringtoImage(nFrontSize, fontParam.nRowStartPos - 80, nColSite, (i + 1).ToString() + "-" + (n + 1).ToString(), "red", bBold: true);
                            }

                        }
                        else
                        {
                            fun.WriteStringtoImage(nFrontSize, nRowSite, nColSite, dRatio.ToString());
                        }
                    }
                    i++;
                }
                nRowSite = nRowSite + fontParam.nRowGap;
                #endregion
            }
            catch (SystemException ex)
            {
                ex.ToString();
            }
            fun.HWnd.SetLineWidth(1);
        }

        private void CenterPoint(HObject ho_Rect2, HObject ho_SelectedRegions, out HTuple hv_Row, out HTuple hv_Column)
        {
            hv_Row = new HTuple();
            hv_Column = new HTuple();
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_TransRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionDiff);
            try
            {
                ho_Region.Dispose();
                HOperatorSet.Intersection(ho_Rect2, ho_SelectedRegions, out ho_Region);
                //fun.DispRegion(ho_Region, draw: "fill");
                ho_TransRegion.Dispose();
                HOperatorSet.ShapeTrans(ho_Region, out ho_TransRegion, "convex");
                fun.DispRegion(ho_TransRegion);
                ho_RegionDiff.Dispose();
                HOperatorSet.Difference(ho_TransRegion, ho_Region, out ho_RegionDiff);
                //fun.DispRegion(ho_RegionDiff, "red", draw: "fill");
                ho_Region.Dispose();
                HOperatorSet.OpeningCircle(ho_RegionDiff, out ho_Region, 15);
                //fun.DispRegion(ho_Region, "red", draw: "fill");
                ho_TransRegion.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_TransRegion);
                ho_Region.Dispose();
                HOperatorSet.SelectShapeStd(ho_TransRegion, out ho_Region, "max_area", 70);
                fun.DispRegion(ho_Region, draw: "fill");

                HOperatorSet.AreaCenter(ho_Region, out HTuple hv_area, out hv_Row, out hv_Column);
            }
            catch (HalconException ex)
            {
                ex.ToString();
            }
            finally
            {
                ho_Region?.Dispose();
                ho_TransRegion?.Dispose();
                ho_RegionDiff?.Dispose();
            }
        }

        public bool GetRubberRectROI(out Rect2 rect2)
        {
            rect2 = new Rect2();
            bool bResult = true;

            HOperatorSet.GenEmptyObj(out HObject ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionThr);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionConn);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionSel);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionObj);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionUnions);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionTrans);

            try
            {
                ho_ImageScaled.Dispose();
                fun.scale_image_range(fun.m_GrayImage, out ho_ImageScaled, 50, 200);
                ho_RegionThr.Dispose();
                HOperatorSet.Threshold(ho_ImageScaled, out ho_RegionThr, 0, 55);
                HOperatorSet.RegionFeatures(fun.m_GrayImage, "area", out HTuple hv_Area);
                ho_RegionConn.Dispose();
                HOperatorSet.Connection(ho_RegionThr, out ho_RegionConn);
                ho_RegionSel.Dispose();
                HOperatorSet.SelectShape(ho_RegionConn, out ho_RegionSel, "area", "and", hv_Area.D / 2, 9999999);
                int balckNum = ho_RegionSel.CountObj();
                if (balckNum == 0)
                {
                    ho_Region.Dispose();
                    //白底
                    GetHObject(true, out ho_Region);
                    ho_RegionUnions.Dispose();
                    HOperatorSet.Union1(ho_Region, out ho_RegionUnions);
                    ho_RegionTrans.Dispose();
                    HOperatorSet.ShapeTrans(ho_RegionUnions, out ho_RegionTrans, "rectangle2");
                    HOperatorSet.DilationRectangle1(ho_RegionTrans, out ho_RegionTrans, 500, 50);
                    fun.DispRegion(ho_RegionTrans);
                    ho_RegionObj.Dispose();
                    HOperatorSet.SelectObj(ho_Region, out ho_RegionObj, 1);
                    ho_Region.Dispose();
                    HOperatorSet.DilationRectangle1(ho_RegionObj, out ho_Region, 20, 20);
                    fun.DispRegion(ho_Region, "blue");
                    HOperatorSet.SmallestRectangle2(ho_Region, out HTuple hv_Row, out HTuple hv_Col, out HTuple hv_Phi, out HTuple hv_Len1, out HTuple hv_Len2);
                    rect2 = new Rect2(hv_Row, hv_Col, hv_Phi, hv_Len1, hv_Len2);
                }
                else
                {
                    //黑底
                    GetHObject(false, out ho_Region);
                    ho_RegionUnions.Dispose();
                    HOperatorSet.Union1(ho_Region, out ho_RegionUnions);
                    ho_RegionTrans.Dispose();
                    HOperatorSet.ShapeTrans(ho_RegionUnions, out ho_RegionTrans, "rectangle2");
                    HOperatorSet.DilationRectangle1(ho_RegionTrans, out ho_RegionTrans, 500, 50);
                    fun.DispRegion(ho_RegionTrans);
                    ho_RegionObj.Dispose();
                    HOperatorSet.SelectObj(ho_Region, out ho_RegionObj, 1);
                    ho_Region.Dispose();
                    HOperatorSet.DilationRectangle1(ho_RegionObj, out ho_Region, 20, 20);
                    fun.DispRegion(ho_Region, "blue");
                    HOperatorSet.SmallestRectangle2(ho_Region, out HTuple hv_Row, out HTuple hv_Col, out HTuple hv_Phi, out HTuple hv_Len1, out HTuple hv_Len2);
                    rect2 = new Rect2(hv_Row, hv_Col, hv_Phi, hv_Len1, hv_Len2);
                }


            }
            catch (Exception ex)
            {
                bResult = false;
                MessageFun.ShowMessage("插壳AI画框失败！" + ex.ToString());
            }
            finally
            {
                ho_ImageScaled.Dispose();
                ho_RegionThr.Dispose();
                ho_RegionConn.Dispose();
                ho_RegionSel.Dispose();
                ho_Region.Dispose();
                ho_RegionObj.Dispose();
                ho_RegionUnions.Dispose();
                ho_RegionTrans.Dispose();
            }
            return bResult;

        }
        public bool GetHObject(bool bChose, out HObject ho_Region)
        {
            bool bResult = true;
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionThr);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionOpen);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionFillUp);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionConn);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionSel);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionTrans);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionErosion);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionDiff);
            HOperatorSet.GenEmptyObj(out HObject ho_SortedRegions);

            try
            {
                ho_ImageScaled.Dispose();
                fun.scale_image_range(fun.m_GrayImage, out ho_ImageScaled, 30, 200);
                ho_RegionThr.Dispose();
                if (bChose)
                {
                    HOperatorSet.Threshold(ho_ImageScaled, out ho_RegionThr, 240, 255);
                }
                else
                {
                    HOperatorSet.Threshold(ho_ImageScaled, out ho_RegionThr, 0, 15);
                }
                ho_RegionOpen.Dispose();
                HOperatorSet.OpeningCircle(ho_RegionThr, out ho_RegionOpen, 5);
                ho_RegionFillUp.Dispose();
                HOperatorSet.FillUp(ho_RegionOpen, out ho_RegionFillUp);
                ho_RegionConn.Dispose();
                HOperatorSet.Connection(ho_RegionFillUp, out ho_RegionConn);
                ho_RegionSel.Dispose();
                HOperatorSet.SelectShapeStd(ho_RegionConn, out ho_RegionSel, "max_area", 70);
                ho_RegionTrans.Dispose();
                HOperatorSet.ShapeTrans(ho_RegionSel, out ho_RegionTrans, "convex");
                ho_RegionErosion.Dispose();
                HOperatorSet.ErosionRectangle1(ho_RegionTrans, out ho_RegionErosion, 1, 10);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_RegionErosion, out ho_ImageReduced);
                ho_ImageScaled.Dispose();
                fun.scale_image_range(ho_ImageReduced, out ho_ImageScaled, 100, 200);
                ho_RegionThr.Dispose();
                if (bChose)
                {
                    HOperatorSet.Threshold(ho_ImageScaled, out ho_RegionThr, 240, 255);
                }
                else
                {
                    HOperatorSet.Threshold(ho_ImageScaled, out ho_RegionThr, 0, 15);
                }
                ho_RegionDiff.Dispose();
                HOperatorSet.Difference(ho_RegionErosion, ho_RegionThr, out ho_RegionDiff);
                //fun.DispRegion(ho_RegionThr, "red", "fill");

                ho_RegionOpen.Dispose();
                HOperatorSet.OpeningCircle(ho_RegionDiff, out ho_RegionOpen, 5);
                ho_RegionFillUp.Dispose();
                HOperatorSet.FillUp(ho_RegionOpen, out ho_RegionFillUp);
                ho_RegionConn.Dispose();
                HOperatorSet.Connection(ho_RegionFillUp, out ho_RegionConn);
                ho_RegionSel.Dispose();
                HOperatorSet.SelectShape(ho_RegionConn, out ho_RegionSel, "area", "and", 1500, 99999999);
                ho_RegionOpen.Dispose();
                HOperatorSet.OpeningRectangle1(ho_RegionSel, out ho_RegionOpen, 100, 1);
                ho_RegionTrans.Dispose();
                HOperatorSet.ShapeTrans(ho_RegionOpen, out ho_RegionTrans, "rectangle2");
                ho_SortedRegions.Dispose();
                HOperatorSet.SortRegion(ho_RegionTrans, out ho_Region, "upper_left", "true", "column");

            }
            catch (Exception ex)
            {
                bResult = false;
                MessageFun.ShowMessage("获取失败！" + ex.ToString());
            }
            finally
            {
                ho_ImageScaled.Dispose();
                ho_RegionThr.Dispose();
                ho_RegionOpen.Dispose();
                ho_RegionFillUp.Dispose();
                ho_RegionConn.Dispose();
                ho_RegionSel.Dispose();
                ho_RegionTrans.Dispose();
                ho_RegionErosion.Dispose();
                ho_ImageReduced.Dispose();
                ho_RegionDiff.Dispose();
                ho_SortedRegions.Dispose();
            }

            return bResult;
        }

        #region 二维码识别

        #endregion

        #region 外观检测
        public bool DefectAI(InspectData.DefectParam param, InspectItem inspectItem, HObject ho_BrokenImg)
        {
            bool bResult = true;
            HOperatorSet.GenEmptyObj(out HObject ho_ROI);
            try
            {
                Mat mat = null == ho_BrokenImg ? fun.AIimage.Clone() : fun.HObjectToMat(ho_BrokenImg);
                List<Arbitrary> listArbitrary = new List<Arbitrary>() { param.arbitrary };
                ho_ROI.Dispose();
                ho_ROI = fun.GenArbitrary(listArbitrary);
                //光度立体预处理图
                ResultAi AIResult_broken = yolov8_Broken.Inference(mat, (float)param.dBrokenScore, 0.5f);
                //switch (inspectItem)
                //{
                //    case InspectItem.Front:
                //        AIResult_broken = yolov8_Broken.Inference(mat, (float)param.dBrokenScore, 0.5f);
                //        break;
                //    case InspectItem.LeftSide:
                //        AIResult_broken = yolov8_Broken.Inference(mat, (float)param.dBrokenScore, 0.5f);
                //        break;
                //    case InspectItem.RightSide:
                //        AIResult_broken = yolov8_Broken.Inference(mat, (float)param.dBrokenScore, 0.5f);
                //        break;
                //    default:
                //        break;
                //}
                if (!ShowAIResult(AIResult_broken, ho_ROI, param.nBrokenMinArea, "red"))
                {
                    bResult = false;
                }
                //原彩色图
                ResultAi AIResult_dirty = yolov8_Dirty.Inference(fun.AIimage, (float)param.dDirtyScore, 0.5f);
                if (!ShowAIResult(AIResult_dirty, ho_ROI, param.nBrokenMinArea, "green"))
                {
                    bResult = false;
                }
            }
            catch (Exception ex)
            {
                MessageFun.ShowMessage($"AI线序识别错误：{ex}", true);
                bResult = false;
            }
            finally
            {
                ho_ROI?.Dispose();
            }
            return bResult;
        }

        public bool ShowAIResult(ResultAi aiResult, HObject ho_ROI = null, int nMinArea = 10, string strColor = "")
        {
            bool bResult = true;
            HOperatorSet.GenEmptyObj(out HObject ho_Rect1);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            try
            {
                if (null == ho_ROI || ho_ROI.CountObj() == 0)
                {
                    HOperatorSet.GenRectangle1(out ho_ROI, 1, 1, Function.imageHeight, Function.imageWidth);
                }
                int nNum = aiResult.scores.Count;
                if (nNum != 0)
                {
                    List<int> listR1 = new List<int>();
                    List<int> listC1 = new List<int>();
                    List<int> listR2 = new List<int>();
                    List<int> listC2 = new List<int>();
                    for (int i = 0; i < nNum; i++)
                    {
                        listR1.Add(aiResult.rects[i].Y);
                        listC1.Add(aiResult.rects[i].X);
                        listR2.Add(aiResult.rects[i].Y + aiResult.rects[i].Height);
                        listC2.Add(aiResult.rects[i].X + aiResult.rects[i].Width);
                        ho_Rect1.Dispose();
                        HOperatorSet.GenRectangle1(out ho_Rect1, listR1[i], listC1[i], listR2[i], listC2[i]);
                        //fun.DispRegion(ho_Rect1, "red");
                        ho_Region.Dispose();
                        HOperatorSet.Intersection(ho_Rect1, ho_ROI, out ho_Region);
                        HOperatorSet.RegionFeatures(ho_Region, "area", out HTuple hv_area);
                        if (0 != hv_area.TupleLength() && hv_area[0].D > nMinArea)
                        {
                            bResult = false;
                            fun.WriteStringtoImage(15, aiResult.rects[i].Y, aiResult.rects[i].X + aiResult.rects[i].Height / 2 - 10, aiResult.scores[i].ToString("F2"), strColor);
                            fun.DispRegion(ho_Region, strColor);
                        }
                    }
                }
            }
            catch (HalconException ex)
            {
                bResult = false;
                StaticFun.MessageFun.ShowMessage(ex);
            }
            finally
            {
                ho_Rect1?.Dispose();
                ho_Region?.Dispose();
            }
            return bResult;
        }
        #endregion
    }
}
