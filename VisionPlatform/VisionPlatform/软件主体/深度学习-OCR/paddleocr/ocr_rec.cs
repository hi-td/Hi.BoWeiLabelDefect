using OpenCvSharp;
using OpenVinoSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionPlatform.多线插.检测功能.深度学习.paddleocr;
#nullable enable

namespace PaddleOCR
{
   // using rec_opt = RuntimeOption.RecOption;
    public class OcrRec : Predictor
    {

        private int[] m_rec_image_shape;

        private long[] m_input_size;

        private List<string> m_label_list;

        private int m_rec_batch_num;

        private bool m_disposed_value;

        public OcrRec(string rec_model, string? device = null, string? label_path = null, bool? use_gpu = null, bool? is_dynamic = null, bool? is_scale = null, float[]? mean = null, float[]? scale = null, long[]? input_size = null, int? batch_num = null)
            : base(rec_model, device ?? RunTimeOption.RecOption.device, mean ?? RunTimeOption.RecOption.mean, scale ?? RunTimeOption.RecOption.scale, input_size ?? RunTimeOption.RecOption.input_size, is_scale ?? RunTimeOption.RecOption.is_scale, use_gpu ?? RunTimeOption.RecOption.use_gpu, is_dynamic ?? RunTimeOption.RecOption.is_dynamic)
        {
            m_label_list = PaddleOcrUtility.read_dict(label_path ?? RunTimeOption.RecOption.label_path);
            m_label_list.Insert(0, "#");
            m_label_list.Add(" ");
            m_rec_batch_num = batch_num ?? RunTimeOption.RecOption.batch_num;
            m_input_size = input_size ?? RunTimeOption.RecOption.input_size;
            m_rec_image_shape = new int[3]
            {
            (int)m_input_size[1],
            (int)m_input_size[2],
            (int)m_input_size[3]
            };
        }

        public OcrRec(OcrConfig config)
            : base(config.rec_model_path, config.rec_option.device, config.rec_option.mean, config.rec_option.scale, config.rec_option.input_size, config.rec_option.is_scale, config.rec_option.use_gpu, config.rec_option.is_dynamic)
        {
            m_label_list = PaddleOcrUtility.read_dict(config.rec_option.label_path);
            m_label_list.Insert(0, "#");
            m_label_list.Add(" ");
            m_rec_batch_num = config.rec_option.batch_num;
            m_input_size = config.rec_option.input_size;
            m_rec_image_shape = new int[3]
            {
            (int)m_input_size[1],
            (int)m_input_size[2],
            (int)m_input_size[3]
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (!m_disposed_value)
            {
                m_disposed_value = true;
            }

            base.Dispose(disposing);
        }
        public void predict(List<Mat> img_list, List<string> rec_texts, List<float> rec_text_scores)
        {
            int count = img_list.Count;
            List<float> list = new List<float>();
            for (int i = 0; i < count; i++)
            {
                list.Add((float)img_list[i].Cols / (float)img_list[i].Rows);
            }

            List<int> list2 = PaddleOcrUtility.argsort(list);
            for (int j = 0; j < count; j += m_rec_batch_num)
            {
                int num = Math.Min(count, j + m_rec_batch_num);
                int num2 = num - j;
                int num3 = m_rec_image_shape[1];
                float num4 = (float)m_rec_image_shape[2] * 1f / (float)num3;
                for (int k = j; k < num; k++)
                {
                    int rows = img_list[list2[k]].Rows;
                    float val = (float)img_list[list2[k]].Cols * 1f / (float)rows;
                    num4 = Math.Min(num4, val);
                }

                int num5 = 0;
                List<Mat> list3 = new List<Mat>();
                for (int l = j; l < num; l++)
                {
                    Mat mat = new Mat();
                    img_list[list2[l]].CopyTo(mat);
                    Mat mat2 = PreProcess.crnn_resize_img(mat, num4, m_rec_image_shape);
                    PreProcess.normalize(mat2, m_mean, m_scale, m_is_scale);
                    list3.Add(mat2);
                    num5 = Math.Max(mat2.Cols, num5);
                }

                float[] input_data = PreProcess.permute_batch(list3);
                float[] array = infer(input_data, new long[4]
                {
                num2,
                3L,
                m_input_size[2],
                num5
                });
                int num6 = (int)Math.Round((double)(array.Length / num2 / m_output_shape.Last()));
                for (int m = 0; m < m_rec_batch_num; m++)
                {
                    if (j + m >= count)
                    {
                        return;
                    }

                    string text = "";
                    int num7 = 0;
                    float num8 = 0f;
                    int num9 = 0;
                    float max = 0f;
                    int num10 = (int)(m * num6 * m_output_shape.Last());
                    for (int n = 0; n < num6; n++)
                    {
                        float[] array2 = new float[m_output_shape.Last()];
                        Array.Copy(array, m_output_shape.Last() * n + num10, array2, 0L, m_output_shape.Last());
                        int num11 = PaddleOcrUtility.argmax(array2, out max);
                        if (num11 > 0 && (n <= 0 || num11 != num7))
                        {
                            num8 += max;
                            num9++;
                            text += m_label_list[num11];
                        }

                        num7 = num11;
                    }

                    num8 /= (float)num9;
                    if (num8 != 0f)
                    {
                        rec_texts[list2[j + m]] = text;
                        rec_text_scores[list2[j + m]] = num8;
                    }
                }
            }
        }

    }
    }



