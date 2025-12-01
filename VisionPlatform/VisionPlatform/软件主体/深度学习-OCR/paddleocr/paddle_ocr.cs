using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using VisionPlatform.多线插.检测功能.深度学习.paddleocr;

namespace PaddleOCR
{
    public class OCRPredictor
    {

        protected OcrDet ocrDet;

        protected OcrCls ocrCls;

        protected OcrRec ocrRec;

        protected bool flag_det;

        protected bool flag_rec;

        protected bool flag_cls;
        public OCRPredictor(string det_model = null, string cls_model = null, string rec_model = null)
        {
            try
            {
                if (det_model != null)
                {
                    flag_det = true;
                    ocrDet = new OcrDet(det_model);
                }

                if (cls_model != null)
                {
                    flag_cls = true;
                    ocrCls = new OcrCls(cls_model);
                }

                if (rec_model != null)
                {
                    flag_rec = true;
                    ocrRec = new OcrRec(rec_model);
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"OCRPredictor:+{ex}", true);
            }

        }

        public List<OCRPredictResult> cls(List<Mat> img_list, List<OCRPredictResult> ocr_results)
        {
            List<int> list = new List<int>();
            List<float> list2 = new List<float>();
            ocrCls.predict(img_list, list, list2);
            for (int i = 0; i < list.Count; i++)
            {
                ocr_results[i].cls_label = list[i];
                ocr_results[i].cls_score = list2[i];
            }

            return ocr_results;
        }

        public List<OCRPredictResult> rec(List<Mat> img_list, List<OCRPredictResult> ocr_results)
        {
            List<string> list = new List<string>(new string[img_list.Count]);
            List<float> list2 = new List<float>(new float[img_list.Count]);
            ocrRec.predict(img_list, list, list2);
            for (int i = 0; i < list.Count; i++)
            {
                ocr_results[i].text = list[i];
                ocr_results[i].score = list2[i];
            }

            return ocr_results;
        }

        public List<OCRPredictResult> ocr(Mat img, bool det, bool rec, bool cls)
        {
            List<OCRPredictResult> list = new List<OCRPredictResult>();
            if (det)
            {
                if (!flag_det)
                {
                    throw new Exception("The ocrDet is not init!");
                }
                list = this.det(img, list);
            }
            else
            {
                OCRPredictResult oCRPredictResult = new OCRPredictResult();
                int width = img.Size().Width;
                int height = img.Size().Height;
                oCRPredictResult.box = new OpenCvSharp.Point[4]
            {
                new OpenCvSharp.Point() { X=1,Y =1 },
                new OpenCvSharp.Point(){X=1,Y =height - 1 },
                new OpenCvSharp.Point(){X= width - 1,Y =1 },
                 new OpenCvSharp.Point(){X= width - 1,Y =height - 1}
            };
                list.Add(oCRPredictResult);
            }

            List<Mat> list2 = new List<Mat>();
            for (int i = 0; i < list.Count; i++)
            {
                Mat mat = new Mat();
                mat = PaddleOcrUtility.get_rotate_crop_image(img, list[i].box);
                list2.Add(mat);
            }

            if (cls)
            {
                if (!flag_cls)
                {
                    throw new Exception("The ocrCls is not init!");
                }

                list = this.cls(list2, list);
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list[j].cls_label % 2 == 1 && list[j].cls_score > ocrCls.m_cls_thresh)
                    {
                        Cv2.Rotate(list2[j], list2[j], RotateFlags.Rotate180);
                    }
                }
            }

            if (rec)
            {
                if (!flag_rec)
                {
                    throw new Exception("The ocrRec is not init!");
                }

                list = this.rec(list2, list);
            }

            return list;
        }

        public List<OCRPredictResult> ocr(Mat img, List<OpenCvSharp.Point[]> boxss)
        {
            List<OCRPredictResult> ocr_result = new List<OCRPredictResult>();

            ocr_result = det(img, ocr_result);
            // crop image
            List<Mat> img_list = new List<Mat>();
            for (int j = 0; j < boxss.Count; j++)
            {
                Mat crop_img = new Mat();
                crop_img = PaddleOcrUtility.get_rotate_crop_image(img, boxss[j]);
                img_list.Add(crop_img);
            }

            for (int i = 0; i < img_list.Count; i++)
            {
                //Cv2.Rotate(img_list[i], img_list[i], RotateFlags.Rotate180);
                //Point2f center = new Point2f(img_list[i].Cols / 2f, img_list[i].Rows / 2f);
                ////使用了Cv2.GetRotationMatrix2D()函数构建旋转矩阵，然后使用Cv2.WarpAffine()函数进行仿射变换。
                //Mat matrix = Cv2.GetRotationMatrix2D(center, 0, 1);
                //Cv2.WarpAffine(img_list[i], img_list[i], matrix, img_list[i].Size());
                //Cv2.ImShow("ss", img_list[i]);
                //Cv2.WaitKey(0);
            }
            ocr_result = this.rec(img_list, ocr_result);

            return ocr_result;
        }
        public List<OCRPredictResult> det1(List<OpenCvSharp.Point[]> boxes, List<OCRPredictResult> ocr_results)
        {
            // 文字区域识别

            for (int i = 0; i < boxes.Count; i++)
            {
                OCRPredictResult res = new OCRPredictResult();
                res.box = boxes[i];
                ocr_results.Add(res);
            }
            return PaddleOcrUtility.sorted_boxes(ocr_results);
        }
        public List<OCRPredictResult> det(Mat image, List<OCRPredictResult> ocr_results)
        {
            List<OpenCvSharp.Point[]> list = ocrDet.predict(image);
            for (int i = 0; i < list.Count; i++)
            {
                OCRPredictResult oCRPredictResult = new OCRPredictResult();
                oCRPredictResult.box = list[i];
                ocr_results.Add(oCRPredictResult);
            }

            return PaddleOcrUtility.sorted_boxes(ocr_results);
        }

        public List<List<OCRPredictResult>> ocr(List<Mat> img_list, bool det, bool rec, bool cls)
        {
            List<List<OCRPredictResult>> results = new List<List<OCRPredictResult>>();
            foreach (Mat img in img_list)
            {
                results.Add(ocr(img, det, rec, cls));
            }
            return results;
        }

    }
}
