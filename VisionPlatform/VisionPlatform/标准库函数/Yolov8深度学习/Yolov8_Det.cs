
using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp;
using ResultSharp;
using StaticFun;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace yolov8_Det_Onnx
{
    public class Yolov8_Det
    {
        SegmentationResult result_pro;
        // 识别结果类型
        string[] class_names;
        Tensor input_tensor;
        InferRequest infer_request;
        public Yolov8_Det(string model_path, string modelclass_path)
        {
            Create_models(model_path, modelclass_path);
        }

        public Yolov8_Det()
        {

        }
        private void Create_models(string model_path, string modelclass_path)
        {
            try
            {
                if (!File.Exists(model_path))
                {
                    MessageFun.ShowMessage("未找到Ai模型!");
                    return;
                }
                if (!File.Exists(modelclass_path))
                {
                    MessageBox.Show("未找到Ai文本!");
                    return;
                }
                Core core = new Core(); // 初始化推理核心
                Model model = core.read_model(model_path); // 读取本地模型
                CompiledModel compiled_model = core.compile_model(model, "CPU"); // 读取模型到指定设备
                read_class_names(modelclass_path);
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
        public ResultAi Inference(Mat image, float score_threshold = 0.3f, float nms_threshold = 0.5f, bool bMaxScore = false)
        {
            ResultAi re_result = new ResultAi(); // 输出结果类
            Stopwatch stopWatch = new Stopwatch();
            Stopwatch stopWatch1 = new Stopwatch();
            try
            {
                // 读取并处理输入数据
                int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
                Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
                Rect roi = new Rect(0, 0, image.Cols, image.Rows);
                image.CopyTo(new Mat(max_image, roi));
                float factor = (float)(max_image_length / 640.0);

                // 加载推理数据
                Shape input_shape = input_tensor.get_shape();
                Mat input_mat = CvDnn.BlobFromImage(max_image, 1.0 / 255.0, new OpenCvSharp.Size(input_shape[2], input_shape[3]), (Scalar)0, true, false);
                float[] input_data = new float[input_shape[1] * input_shape[2] * input_shape[3]];
                Marshal.Copy(input_mat.Ptr(0), input_data, 0, input_data.Length);
                input_tensor.set_data<float>(input_data);

                stopWatch.Start();
                stopWatch1.Start();
                // 模型推理
                infer_request.infer();
                stopWatch.Stop();
                MessageFun.ShowMessage(stopWatch.ElapsedMilliseconds);
                input_mat.Dispose();
                Tensor output_tensor = infer_request.get_output_tensor();
                int output_length = (int)output_tensor.get_size();
                float[] output_data = output_tensor.get_data<float>(output_length);
                //自适应获取类别数
                Shape output_shape = output_tensor.get_shape();
                int num_classes = (int)(output_shape[1]);
                int num_anchors = (int)output_shape[2];
                //Tensor output_tensor_1 = infer_request.get_output_tensor(0);
                //float[] result_proto = output_tensor_1.get_data<float>((int)output_tensor_1.get_size());
                result_pro = new SegmentationResult(class_names, factor, score_threshold, nms_threshold);
                //re_result = result_pro.process_result(output_data, num_classes, num_anchors, bMaxScore);
                //re_result = result_pro.process_result(output_data, num_classes, num_anchors);
                re_result = result_pro.process_result2(output_data, num_classes, num_anchors);
                stopWatch1.Stop();
                MessageFun.ShowMessage(stopWatch1.ElapsedMilliseconds);
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