using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PaddleOCR
{
    public class Predictor : IDisposable
    {
        protected Core m_core;

        protected Model m_model;

        protected CompiledModel m_compiled_model;

        protected InferRequest m_infer_request;

        protected Shape m_output_shape;

        protected PartialShape m_input_shape;

        protected bool m_is_scale;

        protected float[] m_mean;

        protected float[] m_scale;

        protected bool m_use_gpu;

        protected bool m_is_dynamic;

        private bool m_disposed_value;

        public Predictor(string model_path, string device, float[] mean, float[] scale, long[] input_size, bool is_scale = true, bool use_gpu = false, bool is_dynamic = true)
        {
            m_core = new Core();
            m_core.set_property(device, Ov.cache_dir("./"));
            m_model = m_core.read_model(model_path);
            m_input_shape = m_model.get_input().get_partial_shape();
            if (use_gpu && !is_dynamic)
            {
                if (input_size == null)
                {
                    throw new ArgumentNullException("input_size");
                }

                m_model.reshape(new PartialShape(new Shape(input_size)));
            }

            m_compiled_model = m_core.compile_model(m_model, device);
            m_infer_request = m_compiled_model.create_infer_request();
            m_mean = mean;
            m_scale = scale;
            m_is_scale = is_scale;
            m_use_gpu = use_gpu;
        }

        public void Dispose()
        {
            m_infer_request.Dispose();
            m_compiled_model.Dispose();
            m_model.Dispose();
            m_core.Dispose();
            Dispose(disposing: true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed_value)
            {
                m_disposed_value = true;
            }
        }

        protected float[] infer(float[] input_data, long[] shape = null)
        {
            Tensor input_tensor = m_infer_request.get_input_tensor();
            if (shape != null)
            {
                input_tensor.set_shape(new Shape(shape));
            }

            input_tensor.set_data(input_data);
            m_infer_request.infer();
            if (m_model.get_outputs_size() > 1)
            {
                Tensor tensor = m_infer_request.get_output_tensor(0uL);
                m_output_shape = tensor.get_shape();
                return tensor.get_data<float>((int)tensor.get_size());
            }

            Tensor output_tensor = m_infer_request.get_output_tensor();
            m_output_shape = output_tensor.get_shape();
            return output_tensor.get_data<float>((int)output_tensor.get_size());
        }
    }
}