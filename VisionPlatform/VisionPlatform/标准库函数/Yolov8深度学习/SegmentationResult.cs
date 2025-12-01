using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResultSharp
{
    public class SegmentationResult
    {
        // 识别结果类型
        public string[] class_names;
        // 图片信息  缩放比例h, 缩放比例h,,height, width
        public float[] arrayScales;
        public float scales;
        // 置信度阈值
        public float score_threshold;
        // 非极大值抑制阈值
        public float nms_threshold;
        //检测区域
        public Rect rect1;

        /// <summary>
        /// 结果处理类构造
        /// </summary>
        /// <param name="class_names">识别结果类型</param>
        /// <param name="scales">缩放比例</param>
        /// <param name="score_threshold">分数阈值</param>
        /// <param name="nms_threshold">非极大值抑制阈值</param>
        public SegmentationResult(string[] class_names, float[] scales, Rect rect1, float score_threshold = 0.3f, float nms_threshold = 0.5f)
        {
            this.class_names = class_names;
            this.arrayScales = scales;
            this.score_threshold = score_threshold;
            this.nms_threshold = nms_threshold;
            this.rect1 = rect1;
        }
        public SegmentationResult(string[] class_names, float scales, float score_threshold = 0.3f, float nms_threshold = 0.5f)
        {
            this.class_names = class_names;
            this.scales = scales;
            this.score_threshold = score_threshold;
            this.nms_threshold = nms_threshold;
        }
        /// <summary>
        /// 结果处理
        /// </summary>
        /// <param name="detect">目标检测输出</param>
        /// <param name="proto">语义分割输出</param>
        /// <returns></returns>
        public ResultAi process_result11(float[] detect)
        {
            ResultAi re_result = new ResultAi(); // 输出结果类
            try
            {
                //Mat detect_data = new Mat(37, 8400, MatType.CV_32F, detect);
                Mat detect_data = Mat.FromPixelData(5, 8400, MatType.CV_32F, detect);
                detect_data = detect_data.T();

                // 存放结果list
                List<Rect> position_boxes = new List<Rect>();
                List<int> class_ids = new List<int>();
                List<float> confidences = new List<float>();
                List<Mat> masks = new List<Mat>();
                // 预处理输出结果
                for (int i = 0; i < detect_data.Rows; i++)
                {
                    Mat classes_scores = detect_data.Row(i).ColRange(4, 5);//GetArray(i, 5, classes_scores);
                    OpenCvSharp.Point max_classId_point, min_classId_point;
                    double max_score, min_score;
                    // 获取一组数据中最大值及其位置
                    Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                        out min_classId_point, out max_classId_point);
                    // 置信度 0～1之间
                    // 获取识别框信息
                    if (max_score > 0.25)
                    {
                        Mat mask = detect_data.Row(i).ColRange(5, 37);

                        float cx = detect_data.At<float>(i, 0);
                        float cy = detect_data.At<float>(i, 1);
                        float ow = detect_data.At<float>(i, 2);
                        float oh = detect_data.At<float>(i, 3);
                        //int x = (int)((cx - 0.5 * ow) * this.scales[0]);
                        //int y = (int)((cy - 0.5 * oh) * this.scales[1]);
                        //int width = (int)(ow * this.scales[0]);
                        //int height = (int)(oh * this.scales[1]);
                        int x = (int)((cx - 0.5 * ow) * this.scales);
                        int y = (int)((cy - 0.5 * oh) * this.scales);
                        int width = (int)(ow * this.scales);
                        int height = (int)(oh * this.scales);
                        Rect box = new Rect();
                        box.X = x;
                        box.Y = y;
                        box.Width = width;
                        box.Height = height;
                        //限定检测区域
                        if (rect1.Width != 0)
                        {
                            RotatedRect rect = new RotatedRect(new Point2f((float)rect1.X, (float)rect1.Y), new Size2f((float)rect1.Width, (float)rect1.Height), 0); // 矩形
                            double distance = Cv2.PointPolygonTest(rect.Points(), new Point2f(x, y), true);
                            if (distance >= 0)
                            {
                                position_boxes.Add(box);
                                class_ids.Add(max_classId_point.X);
                                confidences.Add((float)max_score);
                                masks.Add(mask);
                            }
                        }
                        else
                        {
                            position_boxes.Add(box);
                            class_ids.Add(max_classId_point.X);
                            confidences.Add((float)max_score);
                            masks.Add(mask);
                        }
                    }
                }
                // NMS非极大值抑制
                int[] indexes = new int[position_boxes.Count];
                CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out indexes);
                // 识别结果
                for (int i = 0; i < indexes.Length; i++)
                {
                    int index = indexes[i];
                    re_result.add(confidences[index], position_boxes[index], this.class_names[class_ids[index]]);
                }

            }
            catch (Exception ex)
            {
            }
            return re_result;
        }
        public ResultAi process_result(float[] detect)
        {
            ResultAi re_result = new ResultAi(); // 输出结果类
            Mat result_data = Mat.FromPixelData(5, 8400, MatType.CV_32F, detect);
            result_data = result_data.T();

            // Storage results list
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            // Preprocessing output results
            for (int i = 0; i < result_data.Rows; i++)
            {
                Mat classes_scores = new Mat(result_data, new Rect(4, i, 1, 1));
                OpenCvSharp.Point max_classId_point, min_classId_point;
                double max_score, min_score;
                // Obtain the maximum value and its position in a set of data
                Cv2.MinMaxLoc(classes_scores, out min_score, out max_score,
                    out min_classId_point, out max_classId_point);
                // Confidence level between 0 ~ 1
                // Obtain identification box information
                if (max_score > 0.25)
                {
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
                    int x = (int)((cx - 0.5 * ow) * scales);
                    int y = (int)((cy - 0.5 * oh) * scales);
                    int width = (int)(ow * scales);
                    int height = (int)(oh * scales);
                    Rect box = new Rect();
                    box.X = x;
                    box.Y = y;
                    box.Width = width;
                    box.Height = height;

                    position_boxes.Add(box);
                    class_ids.Add(max_classId_point.X);
                    confidences.Add((float)max_score);
                }
            }
            // NMS非极大值抑制
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out indexes);
            // 识别结果
            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                re_result.add(confidences[index], position_boxes[index], this.class_names[class_ids[index]]);
            }
            return re_result;
        }

        public ResultAi process_result2(float[] detect, int a, int b, bool bMaxScore = false)
        {
            ResultAi re_result = new ResultAi(); // 输出结果类
            try
            {
                //转置为8400x12
                Mat result_data = Mat.FromPixelData(a, b, MatType.CV_32F, detect);
                result_data = result_data.T();
                List<Rect> position_boxes = new List<Rect>();
                List<int> class_ids = new List<int>();
                List<float> confidences = new List<float>();
                OpenCvSharp.Point max_classId_point, min_classId_point;
                double max_score, min_score;
                Mat classes_scores;
                // Preprocessing output results
                for (int i = 0; i < result_data.Rows; i++)
                {
                    classes_scores = new Mat(result_data, new Rect(4, i, class_names.Length, 1));
                    // Obtain the maximum value and its position in a set of data
                    Cv2.MinMaxLoc(classes_scores, out min_score, out max_score, out min_classId_point, out max_classId_point);
                    // Confidence level between 0 ~ 1
                    // Obtain identification box information
                    Rect box = new Rect();
                    float cx, cy, ow, oh;
                    int x, y, width, height;
                    if (max_score > 0.25)
                    {
                        cx = result_data.At<float>(i, 0);
                        cy = result_data.At<float>(i, 1);
                        ow = result_data.At<float>(i, 2);
                        oh = result_data.At<float>(i, 3);
                        x = (int)((cx - 0.5 * ow) * scales);
                        y = (int)((cy - 0.5 * oh) * scales);
                        width = (int)(ow * scales);
                        height = (int)(oh * scales);
                        box = new Rect();
                        box.X = x;
                        box.Y = y;
                        box.Width = width;
                        box.Height = height;
                        position_boxes.Add(box);
                        class_ids.Add(max_classId_point.X);
                        confidences.Add((float)max_score);
                    }
                }
                // 修改NMS部分（取消注释并正确接收out参数）
                CvDnn.NMSBoxes(position_boxes, confidences, this.score_threshold, this.nms_threshold, out int[] indexes);
                // 遍历NMS筛选后的索引
                int index;
                for (int i = 0; i < indexes.Length; i++)
                {
                    index = indexes[i]; // 正确的索引
                    re_result.add(confidences[index], position_boxes[index], this.class_names[class_ids[index]]);
                }
                if (bMaxScore)
                {
                    // 1. 创建索引序列
                    var indices = Enumerable.Range(0, re_result.classes.Count);
                    //// 或者转换为列表
                    //List<int> indices = Enumerable.Range(0, re_result.classes.Count).ToList();

                    // 2. 组合所有属性到匿名对象，这个匿名对象将每个索引对应的四个值组合在一起，使得我们可以通过一个对象来访问这四个值。select就是根据索引创建对象
                    var combinedItems = indices.Select(index => new
                    {
                        Index = index,
                        Class = re_result.classes[index],
                        Score = re_result.scores[index],
                        Rects = re_result.rects[index],
                    });

                    // 3. 分组并选择每组最高分项
                    var bestItems = combinedItems
                        .GroupBy(item => item.Class)
                        .Select(group => group
                            .OrderByDescending(item => item.Score)
                            .First()
                        )
                        .ToList();

                    re_result = new ResultAi();
                    for (int i = 0; i < bestItems.Count; i++)
                    {
                        re_result.classes.Add(bestItems[i].Class);
                        re_result.scores.Add(bestItems[i].Score);
                        re_result.rects.Add(bestItems[i].Rects);
                    }
                }
            }
            catch (Exception ex)
            {
                StaticFun.MessageFun.ShowMessage($"ResultAi:{ex}", true);
            }
            return re_result;
        }
        /// <summary>
        /// 结果绘制
        /// </summary>
        /// <param name="result">识别结果</param>
        /// <param name="image">绘制图片</param>
        /// <returns></returns>
        public Mat draw_result(ResultAi result, Mat image)
        {
            Mat masked_img = new Mat();
            // 将识别结果绘制到图片上
            for (int i = 0; i < result.length; i++)
            {
                Cv2.Rectangle(image, result.rects[i], new Scalar(0, 0, 255), 2, LineTypes.Link8);
                Cv2.Rectangle(image, new OpenCvSharp.Point(result.rects[i].TopLeft.X, result.rects[i].TopLeft.Y - 20),
                   new OpenCvSharp.Point(result.rects[i].BottomRight.X, result.rects[i].TopLeft.Y), new Scalar(0, 255, 255), -1);
                Cv2.PutText(image, result.classes[i] + "-" + result.scores[i].ToString("0.00"),
                    new OpenCvSharp.Point(result.rects[i].X, result.rects[i].Y - 10),
                    HersheyFonts.HersheySimplex, 0.6, new Scalar(0, 0, 0), 1);
                Cv2.AddWeighted(image, 0.5, result.masks[i], 0.5, 0, masked_img);
            }
            return masked_img;
        }
    }
}
