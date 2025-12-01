using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class ResultAi
    {
        // 获取结果长度
        public int length 
        { get 
            { 
                return scores.Count;
            } 
        }

        // 识别结果类
        public List<string> classes = new List<string>();
        // 置信值
        public List<float> scores = new List<float>();
        // 预测框
        public List<Rect> rects = new List<Rect>();
        // 分割区域
        public List<Mat> masks = new List<Mat>();
        /// <summary>
        /// 物体检测
        /// </summary>
        /// <param name="score">预测分数</param>
        /// <param name="rect">识别框</param>
        /// <param name="cla">识别类</param>
        public void add(float score, Rect rect, string cla) {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
        }
        /// <summary>
        /// 物体分割
        /// </summary>
        /// <param name="score">预测分数</param>
        /// <param name="rect">识别框</param>
        /// <param name="cla">识别类</param>
        /// <param name="mask">语义分割结果</param>
        public void add(float score, Rect rect, string cla, Mat mask)
        {
            scores.Add(score);
            rects.Add(rect);
            classes.Add(cla);
            masks.Add(mask);
        }
    }
}

