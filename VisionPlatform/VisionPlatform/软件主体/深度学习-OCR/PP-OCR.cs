using Aardvark.Base.Native;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenVinoSharp;
using PaddleOCR;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionPlatform.多线插.检测功能.深度学习.paddleocr;
using static Aardvark.Base.Converters;
using Color = System.Drawing.Color;

namespace PP_OCR
{
    public class PP_OCRv4
    {
        public OCRPredictor myOCR;
        string det_model;
        string cls_model;
        string rec_model;

        public PP_OCRv4()
        {
            //CreateOCRPredictor();
        }
        private void CreateOCRPredictor()
        {
            try
            {
                //string configFileFold = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Config");
                //string det_model = "./paddle/ch_PP-OCRv4_det_infer/inference.pdmodel";
                //string cls_model = "./paddle/ch_ppocr_mobile_v2.0_cls_infer/inference.pdmodel";
                //string rec_model = "./paddle/ch_PP-OCRv4_rec_infer/inference.pdmodel";
                //路径不能包含中文
                det_model = @"D:\\Model\\PP-OCRv5_server_det_onnx.onnx";
                cls_model = @"D:\\Model\\PP-OCRv5_server_cls_onnx.onnx";
                rec_model = @"D:\\Model\\PP-OCRv5_server_rec_onnx.onnx";
                if (File.Exists(det_model) && File.Exists(cls_model)&& File.Exists(rec_model))
                {
                    myOCR = new OCRPredictor(det_model, cls_model, rec_model);
                }
                else
                {
                    MessageBox.Show("onnx文件路径不存在！请模型检测路径。" );
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"Failed CreateOCRPredictor:{ex}", true);
            }

        }
        public List<OCRPredictResult> Inference(Mat image, List<OpenCvSharp.Point[]> boxss)
        {
            List<OCRPredictResult> ocr_result = new List<OCRPredictResult>();
            ocr_result = myOCR.ocr(image, boxss);
            PaddleOcrUtility.print_result(ocr_result);
            return ocr_result;
        }
        public List<List<OCRPredictResult>> InferenceV5(Mat mImage, List<Mat> img_list)
        {
            List<List<OCRPredictResult>> ocr_result = new List<List<OCRPredictResult>>();
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ocr_result = myOCR.ocr(img_list, true, true, true);
                sw.Stop();
                MessageFun.ShowMessage("推理耗时：" + sw.ElapsedMilliseconds + " ms");
                //print_result(ocr_result[0]);
                //Mat result = visualize_bboxes(mImage, ocr_result[0]);
                //Cv2.ImShow("result", result);
                //string sText = string.Empty;
                //for (int i = 0; i < ocr_result[0].Count(); i++)
                //{
                //    if (ocr_result[0][i].score > 0.5)
                //    {
                //        sText += ocr_result[0][i].text;
                //    }
                //}
                //MessageFun.ShowMessage("字符检测结果：" + sText);
            }
            catch(Exception ex)
            {
                StaticFun.MessageFun.ShowMessage(ex, true);
            }
            return ocr_result;
        }

        public static void print_result(List<OCRPredictResult> ocr_result)
        {
            for (int i = 0; i < ocr_result.Count; i++)
            {
                string text = "";
                text += $"{i}  ";
                OpenCvSharp.Point[] box = ocr_result[i].box;
                if (box.Length > 0)
                {
                    text += " det boxes:[";
                    for (int j = 0; j < box.Length; j++)
                    {
                        text += $"[{box[j].Y}, {box[j].X}]";
                        if (j != box.Length - 1)
                        {
                            text += ",";
                        }
                    }

                    text += "]\t";
                }

                if ((double)ocr_result[i].score != -1.0)
                {
                    text += string.Format(" rec text: {0}\t  rec score: {1} \t", ocr_result[i].text, ocr_result[i].score.ToString("0.00"));
                }

                if (ocr_result[i].cls_label != -1)
                {
                    text += string.Format(" cls label: {0}\t cls score: {1}", ocr_result[i].cls_label, ocr_result[i].cls_score.ToString("0.00"));
                }

                MessageFun.ShowMessage("字符检测结果：" + text);
            }
        }

        public static Mat visualize_bboxes(Mat srcimg, List<OCRPredictResult> ocr_result)
        {
            Mat mat = srcimg.Clone();
            for (int i = 0; i < ocr_result.Count; i++)
            {
                OpenCvSharp.Point[] array = new OpenCvSharp.Point[4]
                {
                new OpenCvSharp.Point(ocr_result[i].box[0].X, ocr_result[i].box[0].Y),
                new OpenCvSharp.Point(ocr_result[i].box[2].X, ocr_result[i].box[2].Y),
                new OpenCvSharp.Point(ocr_result[i].box[3].X, ocr_result[i].box[3].Y),
                new OpenCvSharp.Point(ocr_result[i].box[1].X, ocr_result[i].box[1].Y)
                };
                OpenCvSharp.Point[][] pts = new OpenCvSharp.Point[1][] { array };
                Cv2.Polylines(mat, pts, isClosed: true, new Scalar(0.0, 255.0, 0.0), 2);
            }
           
            Image image = mat.ToBitmap();
            //Graphics graphics = Graphics.FromImage(image);
            //SolidBrush brush = new SolidBrush(Color.Red);
            //for (int j = 0; j < ocr_result.Count; j++)
            //{
            //    int num = (int)Math.Ceiling((double)(ocr_result[j].box[1][1] - ocr_result[j].box[0][1]) / 3.0) + 1;
            //    int num2 = (int)Math.Ceiling((double)(ocr_result[j].box[2][0] - ocr_result[j].box[0][0]) / 3.0) + 1;
            //    int num3 = ((num < num2) ? num : num2);
            //    Font font = new Font("Arial", num3);
            //    float num4 = ocr_result[j].box[0][1];
            //    if ((double)num4 > (double)num3 * 1.5)
            //    {
            //        num4 -= (float)(int)((double)num3 * 1.5);
            //    }

            //    PointF point = new PointF(ocr_result[j].box[0][0], num4);
            //    string text = ocr_result[j].text;
            //    graphics.DrawString(text, font, brush, point);
            //}

            return ((Bitmap)image).ToMat();
        }

    }
}
