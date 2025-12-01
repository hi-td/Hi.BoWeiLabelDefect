using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionPlatform.多线插.检测功能.深度学习.paddleocr;

namespace PaddleOCR
{
    public class RunTimeOption
    {
        // ocr det
        public static class DetOption
        {
            public static string device = "CPU";

            public static float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public static float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public static long[] input_size = new long[4] { 1L, 3L, 960L, 960L };

            public static bool is_scale = true;

            public static bool use_gpu = false;

            public static bool is_dynamic = false;

            public static float det_db_thresh = 0.3f;

            public static float det_db_box_thresh = 0.5f;

            public static int limit_side_len = 960;

            public static string limit_type = "max";

            public static string db_score_mode = "slow";

            public static float db_unclip_ratio = 2.5f;
        }

        public static class ClsOption
        {
            public static string device = "CPU";

            public static float[] mean = new float[3] { 0.5f, 0.5f, 0.5f };

            public static float[] scale = new float[3] { 2f, 2f, 2f };

            public static long[] input_size = new long[4] { 1L, 3L, 48L, 192L };

            public static bool is_scale = true;

            public static bool use_gpu = false;

            public static bool is_dynamic = true;

            public static float cls_thresh = 0.5f;

            public static int batch_num = 1;
        }

        public static class RecOption
        {
            public static string device = "CPU";

            public static string label_path = "D:\\Model\\ppocrv5_dict.txt";

            public static float[] mean = new float[3] { 0.5f, 0.5f, 0.5f };

            public static float[] scale = new float[3] { 2f, 2f, 2f };

            public static long[] input_size = new long[4] { 1L, 3L, 48L, 1024L };

            public static bool is_scale = true;

            public static bool use_gpu = false;

            public static bool is_dynamic = true;

            public static int batch_num = 1;
        }

        public static class StruTabRecOption
        {
            public static string device = "CPU";

            public static string label_path = "dict/table_structure_dict_ch.txt";

            public static float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public static float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public static long[] input_size = new long[4] { 1L, 3L, 488L, 488L };

            public static bool is_scale = true;

            public static bool use_gpu = false;

            public static int batch_num = 1;

            public static float thresh = 0.9f;
        }

        public static class StruLayRecOption
        {
            public static string device = "CPU";

            public static string label_path = "dict/layout_cdla_dict.txt";

            public static float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public static float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public static long[] input_size = new long[4] { 1L, 3L, 800L, 608L };

            public static bool is_scale = true;

            public static bool use_gpu = false;

            public static int batch_num = 1;

            public static double score_threshold = 0.4;

            public static double nms_threshold = 0.5;

            public static List<int> fpn_stride = new List<int>(new int[4] { 8, 16, 32, 64 });
        }
    }
}

