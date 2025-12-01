using OpenCvSharp;
using OpenVinoSharp;
using PaddleOCR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPlatform.多线插.检测功能.深度学习.paddleocr
{
    public class OcrCls : Predictor
    {
        public float m_cls_thresh;

        private int m_cls_batch_num;

        private long[] m_input_size;

        private bool m_disposed_value;

        public OcrCls(string cls_model, string? device = null, bool? use_gpu = null, bool? is_dynamic = null, bool? is_scale = null, float[]? mean = null, float[]? scale = null, long[]? input_size = null, float? cls_thresh = null, int? batch_num = null)
            : base(cls_model, device ?? RunTimeOption.ClsOption.device, mean ?? RunTimeOption.ClsOption.mean, scale ?? RunTimeOption.ClsOption.scale, input_size ?? RunTimeOption.ClsOption.input_size, is_scale ?? RunTimeOption.ClsOption.is_scale, use_gpu ?? RunTimeOption.ClsOption.use_gpu, is_dynamic ?? RunTimeOption.ClsOption.is_dynamic)
        {
            m_cls_batch_num = batch_num ?? RunTimeOption.ClsOption.batch_num;
            m_cls_thresh = cls_thresh ?? RunTimeOption.ClsOption.cls_thresh;
            m_input_size = input_size ?? RunTimeOption.ClsOption.input_size;
            Dimension[] dimensions = m_input_shape.get_dimensions();
            for (int i = 0; i < dimensions.Length; i++)
            {
                if (!dimensions[i].is_dynamic() && dimensions[i].get_max() != m_input_size[i])
                {
                    m_input_size[i] = dimensions[i].get_max();
                }
            }
        }

        //public OcrCls(OcrConfig config)
        //    : base(config.cls_model_path, config.cls_option.device, config.cls_option.mean, config.cls_option.scale, config.cls_option.input_size, config.cls_option.is_scale, config.cls_option.use_gpu, config.cls_option.is_dynamic)
        //{
        //    m_cls_batch_num = config.cls_option.batch_num;
        //    m_cls_thresh = config.cls_option.cls_thresh;
        //    m_input_size = config.cls_option.input_size;
        //    Dimension[] dimensions = m_input_shape.get_dimensions();
        //    for (int i = 0; i < dimensions.Length; i++)
        //    {
        //        if (!dimensions[i].is_dynamic() && dimensions[i].get_max() != m_input_size[i])
        //        {
        //            m_input_size[i] = dimensions[i].get_max();
        //        }
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (!m_disposed_value)
            {
                m_disposed_value = true;
            }

            base.Dispose(disposing);
        }

        public void predict(List<Mat> img_list, List<int> lables, List<float> scores)
        {
            int count = img_list.Count;
            List<int> list = new List<int>
        {
            (int)m_input_size[1],
            (int)m_input_size[2],
            (int)m_input_size[3]
        };
            for (int i = 0; i < count; i += m_cls_batch_num)
            {
                int num = Math.Min(count, i + m_cls_batch_num);
                int num2 = num - i;
                m_input_size[0] = num2;
                List<Mat> list2 = new List<Mat>();
                for (int j = i; j < num; j++)
                {
                    Mat mat = new Mat();
                    img_list[j].CopyTo(mat);
                    Mat mat2 = PreProcess.cls_resize_img(mat, list);
                    PreProcess.normalize(mat2, m_mean, m_scale, m_is_scale);
                    if (mat2.Cols < list[2])
                    {
                        Cv2.CopyMakeBorder(mat2, mat2, 0, 0, 0, list[2] - mat2.Cols, BorderTypes.Constant, new Scalar(0.0, 0.0, 0.0));
                    }

                    list2.Add(mat2);
                }

                float[] input_data = PreProcess.permute_batch(list2);
                float[] array = infer(input_data, m_input_size);
                for (int k = 0; k < num2; k++)
                {
                    int num3 = ((!(array[2 * k] > array[2 * k + 1])) ? 1 : 0);
                    lables.Add(num3);
                    scores.Add(array[2 * k + num3]);
                }
            }
        }
    }
}
