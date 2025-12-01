using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSharp
{
    public class ResultAi_obb
    {
        public int length
        {
            get
            {
                return scores.Count;
            }
        }
        // 识别结果类
        public List<string> classes = new List<string>();
        // 置信值
        public List<float> scores = new List<float>();
        //检测框
        public List<RotatedRect> rotatedRects  = new List<RotatedRect>();

        public void add(float score, RotatedRect rotatedRect, string cla)
        {
            this.scores.Add(score);
            this.rotatedRects.Add(rotatedRect);
            this.classes.Add(cla);
        }

    }
}
