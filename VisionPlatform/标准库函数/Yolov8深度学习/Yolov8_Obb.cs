using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp;
using ResultSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yolov8_Obb_Onnx
{
    public class Yolov8_Obb
    {
        // 识别结果类型
        string[] class_names;
        Tensor input_tensor;
        InferRequest infer_request;

        public Yolov8_Obb(int cam)
        {
            Creat_models(cam);
        }

        private void Creat_models(int cam)
        {
			try
			{
                string model_path = "D:\\Ai\\model-obb.xml";
                string classer_path = "D:\\Ai\\lable-obb.txt";
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


        public ResultAi_obb Inference(Mat image, float score_threshold = 0.3f, float nms_threshold = 0.5f)
        {
            ResultAi_obb resultAi_Obb = new ResultAi_obb();
            try
            {
                int max_image_length = image.Cols > image.Rows ? image.Cols : image.Rows;
                Mat max_image = Mat.Zeros(new OpenCvSharp.Size(max_image_length, max_image_length), MatType.CV_8UC3);
                Rect roi = new Rect(0, 0, image.Cols, image.Rows);
                image.CopyTo(new Mat(max_image, roi));
                float factor = (float)(max_image_length / 1024.0);
                Shape input_shape = input_tensor.get_shape();
                Mat input_mat = CvDnn.BlobFromImage(max_image, 1.0 / 255.0, new OpenCvSharp.Size(input_shape[2], input_shape[3]), new OpenCvSharp.Scalar( 0), true, false);
                float[] input_data = new float[input_shape[1] * input_shape[2] * input_shape[3]];
                Marshal.Copy(input_mat.Ptr(0), input_data, 0, input_data.Length);
                input_tensor.set_data<float>(input_data);
                infer_request.infer();
                Tensor output_tensor = infer_request.get_output_tensor();
                int output_length = (int)output_tensor.get_size();
                float[] output_data = output_tensor.get_data<float>(output_length);
                //Mat result_data = new Mat(6, 21504, MatType.CV_32F, output_data);
                Mat result_data = Mat.FromPixelData(6, 21504, MatType.CV_32F, output_data);
                result_data = result_data.T();
                float[] d = new float[output_length];
                result_data.GetArray<float>(out d);
                List<Rect2d> position_boxes = new List<Rect2d>();
                List<int> class_ids = new List<int>();
                List<float> confidences = new List<float>();
                List<float> rotations = new List<float>();
                for (int i = 0; i < result_data.Rows; i++)
                {
                    Mat classes_scores = new Mat(result_data, new Rect(4, i, 1, 1));
                    OpenCvSharp.Point max_classId_point, min_classId_point;
                    double max_score, min_score;
                    Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                        out min_classId_point, out max_classId_point);
                    if (max_score > 0.25)
                    {
                        float cx = result_data.At<float>(i, 0);
                        float cy = result_data.At<float>(i, 1);
                        float ow = result_data.At<float>(i, 2);
                        float oh = result_data.At<float>(i, 3);
                        double x = (cx - 0.5 * ow) * factor;
                        double y = (cy - 0.5 * oh) * factor;
                        double width = ow * factor;
                        double height = oh * factor;
                        Rect2d box = new Rect2d();
                        box.X = x;
                        box.Y = y;
                        box.Width = width;
                        box.Height = height;

                        position_boxes.Add(box);
                        class_ids.Add(max_classId_point.X);
                        confidences.Add((float)max_score);
                        rotations.Add(result_data.At<float>(i, 5));
                    }
                }
                // NMS non maximum suppression
                int[] indexes = new int[position_boxes.Count];
                CvDnn.NMSBoxes(position_boxes, confidences, score_threshold, nms_threshold, out indexes);

                for (int i = 0; i < indexes.Length; i++)
                {
                    int index = indexes[i];

                    float w = (float)position_boxes[index].Width;
                    float h = (float)position_boxes[index].Height;
                    float x = (float)position_boxes[index].X + w / 2;
                    float y = (float)position_boxes[index].Y + h / 2;
                    float r = rotations[index];
                    float w_ = w > h ? w : h;
                    float h_ = w > h ? h : w;
                    r = (float)((w > h ? r : (float)(r + Math.PI / 2)) % Math.PI);
                    RotatedRect rotate = new RotatedRect(new Point2f(x, y), new Size2f(w_, h_), (float)(r * 180.0 / Math.PI));
                    resultAi_Obb.add(confidences[index],rotate, class_names[class_ids[index]]);
                }

                //for (int i = 0; i < indexes.Length; i++)
                //{
                //    int index = indexes[i];

                //    Point2f[] points = resultAi_Obb.rotatedRects[i].Points();
                //    for (int j = 0; j < 4; j++)
                //    {
                //        Cv2.Line(image, (Point)points[j], (Point)points[(j + 1) % 4], new Scalar(255, 100, 200), 2);
                //    }
                //    //Cv2.Rectangle(image, new OpenCvSharp.Point(position_boxes[index].TopLeft.X, position_boxes[index].TopLeft.Y + 30),
                //    //    new OpenCvSharp.Point(position_boxes[index].BottomRight.X, position_boxes[index].TopLeft.Y), new Scalar(0, 255, 255), -1);
                //    Cv2.PutText(image, class_names[class_ids[index]] + "-" + confidences[index].ToString("0.00"),
                //        (Point)points[0], HersheyFonts.HersheySimplex, 0.8, new Scalar(0, 0, 0), 2);

                //}
                //Cv2.ImShow("Result", image);


            }
            catch (Exception ex)
            {
                MessageBox.Show("推理出错!" + ex.ToString());
                return resultAi_Obb;
            }

            return resultAi_Obb;
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
