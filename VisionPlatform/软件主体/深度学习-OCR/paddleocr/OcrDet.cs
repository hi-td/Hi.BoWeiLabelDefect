using OpenCvSharp;
using PaddleOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPlatform.多线插.检测功能.深度学习.paddleocr
{
    public class OcrDet : Predictor
    {
        private float m_det_db_thresh;

        private float m_det_db_box_thresh;

        private string m_det_db_score_mode;

        private float m_det_db_unclip_ratio;

        private string m_limit_type;

        private int m_limit_side_len;

        private bool m_disposed_value;

        public OcrDet(string det_model, string? device = null, bool? use_gpu = null, bool? is_dynamic = null, bool? is_scale = null, float[]? mean = null, float[]? scale = null, float? db_thresh = null, float? db_box_thresh = null, long[]? input_size = null, string? db_score_mode = null, float? db_unclip_ratio = null, string? limit_type = null, int? limit_side_len = null)
            : base(det_model, device ?? RunTimeOption.DetOption.device, mean ?? RunTimeOption.DetOption.mean, scale ?? RunTimeOption.DetOption.scale, input_size ?? RunTimeOption.DetOption.input_size, is_scale: true, use_gpu ?? RunTimeOption.DetOption.use_gpu, is_dynamic ?? RunTimeOption.DetOption.is_dynamic)
        {
            m_det_db_thresh = db_thresh ?? RunTimeOption.DetOption.det_db_thresh;
            m_det_db_box_thresh = db_box_thresh ?? RunTimeOption.DetOption.det_db_box_thresh;
            m_det_db_score_mode = db_score_mode ?? RunTimeOption.DetOption.db_score_mode;
            m_det_db_unclip_ratio = db_unclip_ratio ?? RunTimeOption.DetOption.db_unclip_ratio;
            m_limit_type = limit_type ?? RunTimeOption.DetOption.limit_type;
            m_limit_side_len = limit_side_len ?? RunTimeOption.DetOption.limit_side_len;
        }

        public OcrDet(OcrConfig config)
            : base(config.det_model_path, config.det_option.device, config.det_option.mean, config.det_option.scale, config.det_option.input_size, is_scale: true, config.det_option.use_gpu, config.det_option.is_dynamic)
        {
            m_det_db_thresh = config.det_option.det_db_thresh;
            m_det_db_box_thresh = config.det_option.det_db_box_thresh;
            m_det_db_score_mode = config.det_option.db_score_mode;
            m_det_db_unclip_ratio = config.det_option.db_unclip_ratio;
            m_limit_type = config.det_option.limit_type;
            m_limit_side_len = config.det_option.limit_side_len;
        }

        protected override void Dispose(bool disposing)
        {
            if (!m_disposed_value)
            {
                m_disposed_value = true;
            }

            base.Dispose(disposing);
        }

        public List<OpenCvSharp.Point[]> predict1(Mat image)
        {
            Mat im = PreProcess.resize_imgtype0(image, m_limit_type, m_limit_side_len, out var ratio_h, out var ratio_w);
            im = PreProcess.normalize(im, m_mean, m_scale, m_is_scale);
            Mat mat = new Mat();
            Mat mat2 = new Mat();
            if (m_use_gpu)
            {
                Mat mat3 = Mat.Zeros(new Size(960, 960), MatType.CV_32FC3);
                Rect roi = new Rect(0, 0, image.Cols, image.Rows);
                im.CopyTo(new Mat(mat3, roi));
                float[] input_data = PreProcess.permute(mat3);
                float[] array = infer(input_data, new long[4] { 1L, 3L, 960L, 960L });
                byte[] array2 = new byte[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array2[i] = (byte)(array[i] * 255f);
                }

                //Mat m = Mat.FromPixelData(960, 960, MatType.CV_8UC1, array2, 0L);
                //Mat m2 = Mat.FromPixelData(960, 960, 5, array, 0L);
                //mat = new Mat(m, roi);
                //mat2 = new Mat(m2, roi);
            }
            else
            {
                float[] input_data2 = PreProcess.permute(im);
                float[] array3 = infer(input_data2, new long[4] { 1L, 3L, im.Rows, im.Cols });
                byte[] array4 = new byte[array3.Length];
                for (int j = 0; j < array3.Length; j++)
                {
                    array4[j] = (byte)(array3[j] * 255f);
                }

                //mat = Mat.FromPixelData(im.Rows, im.Cols, MatType.CV_8UC1, array4, 0L);
                //mat2 = Mat.FromPixelData(im.Rows, im.Cols, 5, array3, 0L);
            }

            double thresh = m_det_db_thresh * 255f;
            double maxval = 255.0;
            Mat mat4 = new Mat();
            Cv2.Threshold(mat, mat4, thresh, maxval, ThresholdTypes.Binary);
            return PostProcessor.filter_tag_det_res(PostProcessor.boxes_from_bitmap(mat2, mat4, m_det_db_box_thresh, m_det_db_unclip_ratio, m_det_db_score_mode), ratio_w, ratio_h, image);
        }
        //public List<List<List<int>>> predict(Mat image)
        //{
        //    Mat im = PreProcess.resize_imgtype0(image, m_limit_type, m_limit_side_len, out var ratio_h, out var ratio_w);
        //    im = PreProcess.normalize(im, m_mean, m_scale, m_is_scale);
        //    Mat mat = new Mat();
        //    Mat mat2 = new Mat();

        //    try
        //    {
        //        if (m_use_gpu)
        //        {
        //            Mat mat3 = Mat.Zeros(new Size(960, 960), MatType.CV_32FC3);
        //            Rect roi = new Rect(0, 0, image.Cols, image.Rows);
        //            im.CopyTo(new Mat(mat3, roi));

        //            float[] input_data = PreProcess.permute(mat3);
        //            float[] array = infer(input_data, new long[4] { 1L, 3L, 960L, 960L });

        //            // 处理二值化结果 (CV_8UC1)
        //            byte[] array2 = new byte[array.Length];
        //            for (int i = 0; i < array.Length; i++)
        //            {
        //                array2[i] = (byte)(array[i] * 255f);
        //            }

        //            // 使用构造函数和 CopyTo 替代 FromPixelData
        //            Mat m = new Mat(960, 960, MatType.CV_8UC1);
        //            using (Mat tempMat = new Mat(960, 960, MatType.CV_8UC1, array2))
        //            {
        //                tempMat.CopyTo(m);
        //            }

        //            // 处理浮点结果 (CV_32FC1)
        //            Mat m2 = new Mat(960, 960, MatType.CV_32FC1);
        //            using (Mat tempMat2 = new Mat(960, 960, MatType.CV_32FC1, array))
        //            {
        //                tempMat2.CopyTo(m2);
        //            }

        //            mat = new Mat(m, roi);
        //            mat2 = new Mat(m2, roi);
        //            m.Dispose();
        //            m2.Dispose();
        //        }
        //        else
        //        {
        //            float[] input_data2 = PreProcess.permute(im);
        //            float[] array3 = infer(input_data2, new long[4] { 1L, 3L, im.Rows, im.Cols });

        //            byte[] array4 = new byte[array3.Length];
        //            for (int j = 0; j < array3.Length; j++)
        //            {
        //                array4[j] = (byte)(array3[j] * 255f);
        //            }

        //            // 同样使用构造函数和 CopyTo
        //            Mat m = new Mat(im.Rows, im.Cols, MatType.CV_8UC1);
        //            using (Mat tempMat = new Mat(im.Rows, im.Cols, MatType.CV_8UC1, array4))
        //            {
        //                tempMat.CopyTo(m);
        //            }

        //            Mat m2 = new Mat(im.Rows, im.Cols, MatType.CV_32FC1);
        //            using (Mat tempMat2 = new Mat(im.Rows, im.Cols, MatType.CV_32FC1, array3))
        //            {
        //                tempMat2.CopyTo(m2);
        //            }

        //            mat = m;
        //            mat2 = m2;
        //        }

        //        double thresh = m_det_db_thresh * 255f;
        //        double maxval = 255.0;
        //        Mat mat4 = new Mat();

        //        try
        //        {
        //            Cv2.Threshold(mat, mat4, thresh, maxval, ThresholdTypes.Binary);
        //            return PostProcessor.filter_tag_det_res(
        //                PostProcessor.boxes_from_bitmap(mat2, mat4, m_det_db_box_thresh, m_det_db_unclip_ratio, m_det_db_score_mode),
        //                ratio_w, ratio_h, image);
        //        }
        //        finally
        //        {
        //            mat4.Dispose();
        //        }
        //    }
        //    finally
        //    {
        //        // 确保所有 Mat 对象被释放
        //        mat?.Dispose();
        //        mat2?.Dispose();
        //        im.Dispose();
        //    }
        //}



        public List<OpenCvSharp.Point[]> predict(Mat image)
        {
            Mat im = PreProcess.resize_imgtype0(image, m_limit_type, m_limit_side_len, out var ratio_h, out var ratio_w);
            im = PreProcess.normalize(im, m_mean, m_scale, m_is_scale);
            Mat mat = new Mat();
            Mat mat2 = new Mat();
            if (m_use_gpu)
            {
                Mat mat3 = Mat.Zeros(new Size(960, 960), MatType.CV_32FC3);
                Rect roi = new Rect(0, 0, image.Cols, image.Rows);
                im.CopyTo(new Mat(mat3, roi));
                float[] input_data = PreProcess.permute(mat3);
                float[] array = infer(input_data, new long[4] { 1L, 3L, 960L, 960L });
                byte[] array2 = new byte[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array2[i] = (byte)(array[i] * 255f);
                }
                Mat m = Mat.FromPixelData(960, 960, MatType.CV_8UC1, array2, 0L);
                Mat m2 = Mat.FromPixelData(960, 960, 5, array, 0L);
                mat = new Mat(m, roi);
                mat2 = new Mat(m2, roi);
            }
            else
            {
                float[] input_data2 = PreProcess.permute(im);
                float[] array3 = infer(input_data2, new long[4] { 1L, 3L, im.Rows, im.Cols });
                byte[] array4 = new byte[array3.Length];
                for (int j = 0; j < array3.Length; j++)
                {
                    array4[j] = (byte)(array3[j] * 255f);
                }

                mat = Mat.FromPixelData(im.Rows, im.Cols, MatType.CV_8UC1, array4, 0L);
                mat2 = Mat.FromPixelData(im.Rows, im.Cols, 5, array3, 0L);
            }

            double thresh = m_det_db_thresh * 255f;
            double maxval = 255.0;
            Mat mat4 = new Mat();
            Cv2.Threshold(mat, mat4, thresh, maxval, ThresholdTypes.Binary);
            PostProcessor.boxes_from_bitmap1(mat2, mat4, m_det_db_box_thresh, m_det_db_unclip_ratio, m_det_db_score_mode);
            PostProcessor.filter_tag_det_res1(PostProcessor.boxes_from_bitmap1(mat2, mat4, m_det_db_box_thresh, m_det_db_unclip_ratio, m_det_db_score_mode), ratio_w, ratio_h, image);

            return PostProcessor.filter_tag_det_res(PostProcessor.boxes_from_bitmap(mat2, mat4, m_det_db_box_thresh, m_det_db_unclip_ratio, m_det_db_score_mode), ratio_w, ratio_h, image);
            
           
        }
    }
}
