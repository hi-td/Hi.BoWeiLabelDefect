using BaseData;
using HalconDotNet;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static VisionPlatform.InspectData;

namespace VisionPlatform
{
    public class LineColor
    {
        public Function fun;
        public void InitFunction(Function fun)
        {
            this.fun = fun;
        }
        public bool LineColorMLP(InspectData.LineColorTrainParam param, List<Rect2> listLocate, bool bShow, out LineColorResult outData, bool[] arrayDelTM = null)
        {
            bool bResult = true;
            outData.listFlag = new List<bool>();
            HOperatorSet.GenEmptyObj(out HObject ho_ColorRegion);
            try
            {
                HOperatorSet.CountChannels(fun.m_hImage, out HTuple hv_channels);
                if (3 != hv_channels.I)
                {
                    MessageFun.ShowMessage("非彩色图像，请导入一张彩色图像！", strEnglish: "Non color image, please import a color image!");
                    return false;
                }
                ho_ColorRegion.Dispose();
                if (!ColorLocate(param.pos, listLocate, true, out ho_ColorRegion, out Rect2 rect2ROI))
                {
                    return false;
                }
                if (0 == ho_ColorRegion.CountObj())
                {
                    MessageFun.ShowMessage("【线序检测】定位失败！", strEnglish: "[Line sequence detection] Positioning failed!");
                    return false;
                }
                int num = ho_ColorRegion.CountObj();
                if (!FindColor(param.listColorID, ho_ColorRegion, out outData.listFlag))
                {
                    bResult = false;
                }
            }
            catch (Exception error)
            {
                bResult = false;
                MessageFun.ShowMessage(error.ToString());
            }
            finally
            {
                ho_ColorRegion?.Dispose();
            }
            return bResult;
        }

        public bool CreateLineColorModel(InspectData.ColorPos pos, List<Rect2> listLocate, out List<ColorID> listColorID)
        {
            listColorID = new List<ColorID>();
            HTuple hv_GMMHandle = new HTuple(), hv_ErrorLog = new HTuple(), hv_Error = new HTuple();
            HOperatorSet.GenEmptyObj(out HObject ho_ColorRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_ClassRegions);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            try
            {
                HOperatorSet.CountChannels(fun.m_hImage, out HTuple hv_channels);
                if (3 != hv_channels.I)
                {
                    MessageFun.ShowMessage("非彩色图像，请导入一张彩色图像！", strEnglish: "Non color image, please import a color image!");
                    return false;
                }
                ho_ColorRegion.Dispose();
                if (!ColorLocate(pos, listLocate, true, out ho_ColorRegion, out Rect2 rect2ROI))
                {
                    return false;
                }
                if (0 == ho_ColorRegion.CountObj())
                {
                    MessageFun.ShowMessage("【线序检测】定位失败！", strEnglish: "[Line sequence detection] Positioning failed!");
                    return false;
                }
                ho_Region.Dispose();
                HOperatorSet.Connection(ho_ColorRegion, out ho_Region);
                ho_ClassRegions.Dispose();
                HOperatorSet.SortRegion(ho_Region, out ho_ClassRegions, "upper_left", "true", "column");
                int num = ho_ClassRegions.CountObj();
                ColorID colorID = new ColorID();
                for (int i = 0; i < num; i++)
                {
                    colorID = new ColorID();
                    ho_Region.Dispose();
                    HOperatorSet.SelectObj(ho_ClassRegions, out ho_Region, i + 1);
                    if (fun.CreateColorGmm(ho_Region, out colorID, 0.05))
                    {
                        listColorID.Add(colorID);
                    }
                }
                return true;
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage($"创建颜色模型出错：{ex}", true, $"Create color model error :{ex}");
                return false;
            }
            finally
            {
                ho_ColorRegion?.Dispose();
                ho_ClassRegions?.Dispose();
                ho_Region?.Dispose();
            }

        }

        private bool FindColor(List<ColorID> listClassID, HObject ho_ColorRegions, out List<bool> listFlag)
        {
            //ho_ColorRegions定位到的区域
            listFlag = new List<bool>();
            HOperatorSet.GenEmptyObj(out HObject ho_ClassRegions);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_Connections);
            HOperatorSet.GenEmptyObj(out HObject ho_ObjSel);
            HOperatorSet.GenEmptyObj(out HObject ho_ColorROIs);
            HOperatorSet.GenEmptyObj(out HObject ho_RegionUion);
            try
            {
                List<double> listGray = new List<double>();
                if (null == listClassID || listClassID.Count == 0)
                {
                    MessageFun.ShowMessage("无线序ID");
                    return false;
                }
                ho_Connections.Dispose();
                HOperatorSet.Connection(ho_ColorRegions, out ho_Connections);
                ho_ColorROIs.Dispose();
                HOperatorSet.SortRegion(ho_Connections, out ho_ColorROIs, "upper_left", "true", "column");
                ho_RegionUion.Dispose();
                HOperatorSet.Union1(ho_ColorRegions, out ho_RegionUion);
                for (int i = 0; i < ho_ColorROIs.CountObj(); i++)
                {
                    if (listClassID[i].ID == null)
                    {
                        return false;
                    }
                    ho_ClassRegions = fun.FindColorGMM(listClassID[i], out bool bExist, ho_RegionUion);
                    ho_ObjSel.Dispose();
                    HOperatorSet.SelectObj(ho_ColorROIs, out ho_ObjSel, (i + 1));  //取出第(i)根线
                    fun.DispRegion(ho_ObjSel, "blue");
                    ho_Region.Dispose();
                    HOperatorSet.Intersection(ho_ObjSel, ho_ClassRegions, out ho_Region);
                    //HOperatorSet.RegionFeatures(ho_Region, "area", out HTuple hv_Value);
                    ho_ClassRegions.Dispose();
                    HOperatorSet.SelectShape(ho_Region, out ho_ClassRegions, "area", "and", 50, 99999);
                    HOperatorSet.RegionFeatures(ho_ClassRegions, "area", out HTuple hv_Value);
                    int num = 0;
                    if (hv_Value.TupleLength() != 0 && hv_Value[0].D != 0)
                    {
                        num = ho_ClassRegions.CountObj();
                    }
                    if (0 == num)
                    {
                        listFlag.Add(false);
                    }
                    else
                    {
                        listFlag.Add(true);
                    }
                    fun.DispRegion(ho_ClassRegions, "green", draw: "fill");
                }
                if (listFlag.Contains(false))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (HalconException ex)
            {
                MessageFun.ShowMessage($"线序检测出错：{ex}", true);
                return false;
            }
            finally
            {
                ho_ClassRegions?.Dispose();
                ho_Region?.Dispose();
                ho_Connections?.Dispose();
                ho_ObjSel?.Dispose();
                ho_ColorROIs?.Dispose();
                ho_RegionUion?.Dispose();
            }
        }

        public bool ColorLocate(InspectData.ColorPos param, List<Rect2> lineRect2s, bool bShow, out HObject ho_ColorRegion, out Rect2 rect2ROI)
        {
            rect2ROI = new Rect2();
            bool bResult = true;
            HOperatorSet.GenEmptyObj(out ho_ColorRegion);
            HOperatorSet.GenEmptyObj(out HObject ho_StartRect2);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_ROIS);
            try
            {
                //自定义检测区域
                if (param.bSelfDefine)
                {
                    fun.Rect2Trans(ref param.selfRect2);
                    rect2ROI = param.selfRect2;
                    fun.ShowRect2(rect2ROI);
                    ho_ColorRegion = SegmentRect2(rect2ROI, param.bThd0_X, param.nThd, bShow, out double dLineWidth);
                    if (!param.bSegment)
                    {
                        HOperatorSet.Union1(ho_ColorRegion, out ho_ColorRegion);
                        HOperatorSet.SmallestRectangle2(ho_ColorRegion, out HTuple hv_row, out HTuple hv_col, out HTuple hv_phi, out HTuple hv_len1, out HTuple hv_len2);
                        Rect2 rect2 = new Rect2(hv_row.D, hv_col.D, hv_phi.D, hv_len1.D, hv_len2.D);
                        fun.Rect2Trans(ref rect2);
                        fun.GetRect2CornerPoint(rect2, out PointF[] points);
                        double dLen1 = param.nLineWidth / 2;
                        double dRowStart = (points[0].X + points[3].X) / 2.0 - dLen1 * Math.Sin(param.selfRect2.dPhi);
                        double dColStart = (points[0].Y + points[3].Y) / 2.0 + dLen1 * Math.Cos(param.selfRect2.dPhi);  //只能加
                        ho_StartRect2.Dispose();
                        HOperatorSet.GenRectangle2(out ho_StartRect2, dRowStart, dColStart, param.selfRect2.dPhi, dLen1, param.selfRect2.dLength2);
                        HOperatorSet.GenEmptyObj(out ho_ColorRegion);
                        double dMove = 0;
                        double dTotalLen = 0;
                        int n = 0;
                        while ((rect2.dLength1 * 2 - dTotalLen) > (param.nLineWidth * 0.8) && n < 30)
                        {
                            dTotalLen = param.nLineWidth * (n + 1) + param.nLineGap * n;
                            dMove = (param.nLineGap + param.nLineWidth) * n;
                            ho_Region.Dispose();
                            HOperatorSet.MoveRegion(ho_StartRect2, out ho_Region, -Math.Sin(param.selfRect2.dPhi) * dMove, Math.Cos(param.selfRect2.dPhi) * dMove);
                            HOperatorSet.ConcatObj(ho_ColorRegion, ho_Region, out ho_ColorRegion);
                            n++;
                        }
                    }
                }
                //根据匹配结果
                else
                {
                    double nMoveXX, nMoveXY, nMoveYX, nMoveYY;
                    for (int i = 0; i < lineRect2s.Count(); i++)
                    {
                        //Y方向平移量
                        nMoveXX = Math.Cos(lineRect2s[i].dPhi) * param.locateROI.nMoveX;
                        nMoveXY = Math.Sin(lineRect2s[i].dPhi) * param.locateROI.nMoveX;
                        nMoveYX = Math.Cos(lineRect2s[i].dPhi) * param.locateROI.nMoveY;
                        nMoveYY = Math.Sin(lineRect2s[i].dPhi) * param.locateROI.nMoveY;
                        Rect2 temp = new Rect2(lineRect2s[i].dRect2Row + nMoveXY + nMoveYX,
                                      lineRect2s[i].dRect2Col + nMoveXX + nMoveYY,
                                      lineRect2s[i].dPhi,
                                      param.locateROI.nROIWidth,
                                      param.locateROI.nROIHeight);
                        fun.ShowRect2(temp);
                        ho_StartRect2.Dispose();
                        HOperatorSet.GenRectangle2(out ho_StartRect2, temp.dRect2Row, temp.dRect2Col, temp.dPhi, temp.dLength1, temp.dLength2);
                        ho_ColorRegion = ho_ColorRegion.ConcatObj(ho_StartRect2);
                    }
                }
                if (0 == ho_ColorRegion.CountObj())
                {
                    StaticFun.MessageFun.ShowMessage("【线序检测】定位失败！");
                    bResult = false;
                }
                fun.DispRegion(ho_ColorRegion, "blue");
            }
            catch (Exception error)
            {
                bResult = false;
                MessageFun.ShowMessage("线序检测定位错误：" + error.ToString());
            }
            finally
            {
                ho_StartRect2?.Dispose();
                ho_Region?.Dispose();
            }
            return bResult;
        }

        public HObject SegmentRect2(Rect2 rect2, bool bThd0X, int nThd, bool bShow, out double dLineWidth)
        {
            dLineWidth = 0;
            HOperatorSet.GenEmptyObj(out HObject ho_ROIS);
            HOperatorSet.GenEmptyObj(out HObject ho_Rect2);
            HOperatorSet.GenEmptyObj(out HObject ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out HObject ho_Region);
            HOperatorSet.GenEmptyObj(out HObject ho_Connections);
            try
            {
                ho_Rect2.Dispose();
                HOperatorSet.GenRectangle2(out ho_Rect2, rect2.dRect2Row, rect2.dRect2Col, rect2.dPhi, rect2.dLength1, rect2.dLength2);
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(fun.m_GrayImage, ho_Rect2, out ho_ImageReduced);
                //HWnd.DispObj(ho_ImageReduced);
                ho_Region.Dispose();
                if (bThd0X)
                {
                    HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, 0, nThd);
                }
                else
                {
                    HOperatorSet.Threshold(ho_ImageReduced, out ho_Region, nThd, 255);
                }
                ho_Connections.Dispose();
                HOperatorSet.Connection(ho_Region, out ho_Connections);
                ho_Region.Dispose();
                HOperatorSet.FillUp(ho_Connections, out ho_Region);
                ho_ROIS.Dispose();
                HOperatorSet.SelectShape(ho_Region, out ho_ROIS, "area", "and", 10, 999999);
                //HOperatorSet.ShapeTrans(ho_ROIS, out ho_ROIS, "convex");
                #region 分割并计算线宽
                HOperatorSet.RegionFeatures(ho_ROIS, "width", out HTuple hv_Widths);
                HOperatorSet.RegionFeatures(ho_ROIS, "inner_radius", out HTuple hv_Radius);
                HOperatorSet.GenEmptyObj(out HObject ho_ColorRegions);
                List<double> listWidth = new List<double>();
                double dWidth = 0;
                for (int n = 0; n < hv_Widths.TupleLength(); n++)
                {
                    dWidth = hv_Widths[n].D;
                    if (hv_Radius[n].D * 2 > hv_Widths[n].D * 0.7 && hv_Radius[n].D * 2 < hv_Widths[n].D * 1.1)
                    {
                        dWidth = hv_Radius[n].D * 2.1;
                    }
                    listWidth.Add(dWidth);
                }
                dLineWidth = listWidth.Count > 0 ? listWidth.Average() : 0;
                #endregion
                fun.DispRegion(ho_ROIS, "blue");
            }
            catch (HalconException ex)
            {
                StaticFun.MessageFun.ShowMessage(ex.ToString());
            }
            finally
            {
                ho_Rect2?.Dispose();
                ho_ImageReduced?.Dispose();
                ho_Region?.Dispose();
                ho_Connections?.Dispose();
            }
            return ho_ROIS;
        }

    }
}
