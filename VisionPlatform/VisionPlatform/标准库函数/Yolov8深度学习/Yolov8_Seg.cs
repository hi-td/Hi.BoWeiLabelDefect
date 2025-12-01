
using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp;
using ResultSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace yolov8_Seg_Onnx
{
    public class Yolov8_Seg
    {

        SegmentationResult result_pro;

        // 识别结果类型
        string[] class_names;
        Tensor input_tensor;
        InferRequest infer_request;
        public Yolov8_Seg(int cam)
        {
            //Create_models(cam);
        }

        private void Create_models(int cam)
        {
            try
            {
                //string startupPath = System.Windows.Forms.Application.StartupPath;
                string model_path = "D:\\Ai\\model.xml";
                string classer_path = "D:\\Ai\\lable.txt";
                if (!File.Exists(model_path))
                {
                    MessageBox.Show("未找到Ai模型!");
                    return;
                }
                if (!File.Exists(classer_path))
                {
                    MessageBox.Show("未找到Ai文本!");
                    return;
                }
                Core core = new Core(); // 初始化推理核心
                Model model = core.read_model(model_path); // 读取本地模型
                CompiledModel compiled_model = core.compile_model(model, "CPU"); // 读取模型到指定设备
                read_class_names(classer_path);
                // 创建推理请求
                infer_request = compiled_model.create_infer_request();
                // 获取输入张量
                input_tensor = infer_request.get_input_tensor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建推理出错!" + ex.ToString());
                return;
            }

        }
        /// <summary>
        /// 推理并获取结果
        /// </summary>
        /// <param name="image">输入图像</param>
        /// <param name="rect1">检测区域</param>
        /// <param name="score_threshold">分数阈值</param>
        /// <param name="nms_threshold">非极大值抑制阈值</param>
        public ResultAi Inference(Mat image, Rect rect1 = new Rect(), float score_threshold = 0.3f, float nms_threshold = 0.5f)
        {
            ResultAi re_result = new ResultAi(); // 输出结果类
            try
            {
                // 读取并处理输入数据
                int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
                Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
                Rect roi = new Rect(0, 0, image.Cols, image.Rows);
                image.CopyTo(new Mat(max_image, roi));
                float[] factors = new float[4];
                factors[0] = factors[1] = (float)(max_image_length / 640.0);
                factors[2] = image.Rows;
                factors[3] = image.Cols;
                // 将图片转为RGB通道
                Mat image_rgb = new Mat();
                Cv2.CvtColor(max_image, image_rgb, ColorConversionCodes.BGR2RGB);
                Mat input_mat = new Mat();
                input_mat = CvDnn.BlobFromImage(image_rgb, 1.0 / 255.0, new OpenCvSharp.Size(640, 640), new OpenCvSharp.Scalar(0), true, false);
                // 加载推理数据
                Shape input_shape = input_tensor.get_shape();
                long channels = input_shape[1];
                long height = input_shape[2];
                long width = input_shape[3];
                float[] input_data = new float[channels * height * width];
                Marshal.Copy(input_mat.Ptr(0), input_data, 0, input_data.Length);
                input_tensor.set_data(input_data);
                // 模型推理
                infer_request.infer();

                image_rgb.Dispose();
                input_mat.Dispose();
                Tensor output_tensor_0 = infer_request.get_output_tensor(0);
                float[] result_detect = output_tensor_0.get_data<float>((int)output_tensor_0.get_size());

                Tensor output_tensor_1 = infer_request.get_output_tensor(1);
                float[] result_proto = output_tensor_1.get_data<float>((int)output_tensor_1.get_size());
                result_pro = new SegmentationResult(class_names, factors, rect1, score_threshold, nms_threshold);
                //re_result = result_pro.process_result(result_detect, result_proto);
                re_result = result_pro.process_result(result_detect);
            }
            catch (Exception ex)
            {

            }
            return re_result;
        }
        /// <summary>
        /// 读取本地识别结果类型文件到内存
        /// </summary>
        /// <param name="path">文件路径</param>
        private void read_class_names(string path)
        {

            List<string> str = new List<string>();
            StreamReader sr = new StreamReader(path);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                str.Add(line);
            }

            class_names = str.ToArray();
        }
    }
}