using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionPlatform.多线插.检测功能.深度学习.paddleocr
{
    public class OcrConfig
    {
        public class DetOption
        {
            public string device = "CPU";

            public float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public long[] input_size = new long[4] { 1L, 3L, 960L, 960L };

            public bool is_scale = true;

            public bool use_gpu;

            public bool is_dynamic;

            public float det_db_thresh = 0.3f;

            public float det_db_box_thresh = 0.5f;

            public int limit_side_len = 960;

            public string limit_type = "max";

            public string db_score_mode = "slow";

            public float db_unclip_ratio = 2f;
        }

        public class ClsOption
        {
            public string device = "CPU";

            public float[] mean = new float[3] { 0.5f, 0.5f, 0.5f };

            public float[] scale = new float[3] { 2f, 2f, 2f };

            public long[] input_size = new long[4] { 1L, 3L, 48L, 192L };

            public bool is_scale = true;

            public bool use_gpu;

            public bool is_dynamic = true;

            public float cls_thresh = 0.9f;

            public int batch_num = 1;
        }

        public class RecOption
        {
            public string device = "CPU";

            public string label_path = "dict/ppocr_keys_v1.txt";

            public float[] mean = new float[3] { 0.5f, 0.5f, 0.5f };

            public float[] scale = new float[3] { 2f, 2f, 2f };

            public long[] input_size = new long[4] { 1L, 3L, 48L, 1024L };

            public bool is_scale = true;

            public bool use_gpu;

            public bool is_dynamic = true;

            public int batch_num = 1;
        }

        public class StruTabRecOption
        {
            public string device = "CPU";

            public string label_path = "dict/table_structure_dict_ch.txt";

            public float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public long[] input_size = new long[4] { 1L, 3L, 488L, 488L };

            public bool is_scale = true;

            public bool use_gpu;

            public int batch_num = 1;

            public float thresh = 0.9f;

            public bool merge_no_span_structure = true;
        }

        public class StruLayRecOption
        {
            public string device = "CPU";

            public string label_path = "dict/layout_cdla_dict.txt";

            public float[] mean = new float[3] { 0.485f, 0.456f, 0.406f };

            public float[] scale = new float[3] { 4.366812f, 4.46428537f, 4.44444466f };

            public long[] input_size = new long[4] { 1L, 3L, 800L, 608L };

            public bool is_scale = true;

            public bool use_gpu;

            public int batch_num = 1;

            public double score_threshold = 0.4;

            public double nms_threshold = 0.5;

            public List<int> fpn_stride = new List<int>(new int[4] { 8, 16, 32, 64 });
        }

        public DetOption det_option;

        public ClsOption cls_option;

        public RecOption rec_option;

        public StruTabRecOption strutabrec_option;

        public StruLayRecOption strulayrec_option;

        public string det_model_path;

        public string cls_model_path;

        public string rec_model_path;

        public string table_rec_model_path;

        public string strulay_rec_model_path;

        public OcrConfig()
        {
            det_option = new DetOption();
            cls_option = new ClsOption();
            rec_option = new RecOption();
            strutabrec_option = new StruTabRecOption();
            strulayrec_option = new StruLayRecOption();
        }

        public OcrConfig(OcrModel model)
        {
            det_option = new DetOption();
            cls_option = new ClsOption();
            rec_option = new RecOption();
            strutabrec_option = new StruTabRecOption();
            strulayrec_option = new StruLayRecOption();
            det_model_path = model.det_model_path;
            cls_model_path = model.cls_model_path;
            rec_model_path = model.rec_model_path;
            rec_option.label_path = model.dict_path;
        }

        public void set_det_option(DetOption op)
        {
            det_option = op;
        }

        public void set_cls_option(ClsOption op)
        {
            cls_option = op;
        }

        public void set_rec_option(RecOption op)
        {
            rec_option = op;
        }

        public void set_table_option(StruTabRecOption op)
        {
            strutabrec_option = op;
        }

        public void set_layout_option(StruLayRecOption op)
        {
            strulayrec_option = op;
        }

        public void set_rec_dict_path(string path)
        {
            rec_option.label_path = path;
        }

        public void set_table_dict_path(string path)
        {
            strutabrec_option.label_path = path;
        }

        public void set_layout_dict_path(string path)
        {
            strulayrec_option.label_path = path;
        }

        public void set_det_model_path(string path)
        {
            det_model_path = path;
        }

        public void set_cls_model_path(string path)
        {
            cls_model_path = path;
        }

        public void set_rec_model_path(string path)
        {
            rec_model_path = path;
        }

        public void set_table_model_path(string path)
        {
            table_rec_model_path = path;
        }

        public void set_layout_model_path(string path)
        {
            strulay_rec_model_path = path;
        }
    }
}
