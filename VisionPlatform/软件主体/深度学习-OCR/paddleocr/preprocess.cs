using HalconDotNet;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisionPlatform.Auxiliary;
using Size = OpenCvSharp.Size;

namespace PaddleOCR
{
    public static class PreProcess
    {
        public static float[] permute(Mat im)
        {
            int rows = im.Rows;
            int cols = im.Cols;
            int num = im.Channels();
            float[] array = new float[rows * cols * num];
            GCHandle gCHandle = default(GCHandle);
            try
            {
                gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                nint num2 = gCHandle.AddrOfPinnedObject();
                for (int i = 0; i < num; i++)
                {
                    Mat mat = Mat.FromPixelData(rows, cols, MatType.CV_32FC1, num2 + i * rows * cols * 4, 0L);
                    Cv2.ExtractChannel(im, mat, i);
                }

                return array;
            }
            finally
            {
                gCHandle.Free();
            }
        }


        public static float[] permute_batch(List<Mat> imgs)
        {
            int rows = imgs[0].Rows;
            int cols = imgs[0].Cols;
            int num = imgs[0].Channels();
            float[] array = new float[rows * cols * num * imgs.Count];
            GCHandle gCHandle = default(GCHandle);
            gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            nint num2 = gCHandle.AddrOfPinnedObject();
            try
            {
                for (int i = 0; i < imgs.Count; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        Mat mat = Mat.FromPixelData(rows, cols, MatType.CV_32FC1, num2 + (i * num + j) * rows * cols * 4, 0L);
                        Cv2.ExtractChannel(imgs[i], mat, j);
                    }
                }

                return array;
            }
            finally
            {
                gCHandle.Free();
            }
        }



        public static Mat normalize(Mat im, float[] mean, float[] scale, bool is_scale)
        {
            double num = 1.0;
            if (is_scale)
            {
                num /= 255.0;
            }

            im.ConvertTo(im, MatType.CV_32FC3, num);
            Mat[] mv = new Mat[3];
            Cv2.Split(im, out mv);
            for (int i = 0; i < mv.Length; i++)
            {
                mv[i].ConvertTo(mv[i], MatType.CV_32FC1, 1.0 * (double)scale[i], (0.0 - (double)mean[i]) * (double)scale[i]);
            }

            Mat mat = new Mat();
            Cv2.Merge(mv, mat);
            return mat;
        }


        public static Mat resize_imgtype0(Mat img, string limit_type, int limit_side_len,
            out float ratio_h, out float ratio_w)
        {
            int w = img.Cols;
            int h = img.Rows;
            float ratio = 1.0f;
            if (limit_type == "min")
            {
                int min_wh = Math.Min(h, w);
                if (min_wh < limit_side_len)
                {
                    if (h < w)
                    {
                        ratio = (float)limit_side_len / (float)h;
                    }
                    else
                    {
                        ratio = (float)limit_side_len / (float)w;
                    }
                }
            }
            else
            {
                int max_wh = Math.Max(h, w);
                if (max_wh > limit_side_len)
                {
                    if (h > w)
                    {
                        ratio = (float)(limit_side_len) / (float)(h);
                    }
                    else
                    {
                        ratio = (float)(limit_side_len) / (float)(w);
                    }
                }
            }

            int resize_h = (int)((float)(h) * ratio);
            int resize_w = (int)((float)(w) * ratio);

            //int resize_h = 960;
            //int resize_w = 960;

            resize_h = Math.Max((int)(Math.Round((float)(resize_h) / 32.0f) * 32), 32);
            resize_w = Math.Max((int)(Math.Round((float)(resize_w) / 32.0f) * 32), 32);

            Mat resize_img = new Mat();
            Cv2.Resize(img, resize_img, new Size(resize_w, resize_h));
            ratio_h = (float)(resize_h) / (float)(h);
            ratio_w = (float)(resize_w) / (float)(w);
            return resize_img;
        }

        public static Mat cls_resize_img(Mat img, List<int> cls_image_shape)
        {
            int imgC, imgH, imgW;
            imgC = cls_image_shape[0];
            imgH = cls_image_shape[1];
            imgW = cls_image_shape[2];

            float ratio = (float)img.Cols / (float)img.Rows;
            int resize_w, resize_h;
            if (Math.Ceiling(imgH * ratio) > imgW)
                resize_w = imgW;
            else
                resize_w = (int)(Math.Ceiling(imgH * ratio));
            Mat resize_img = new Mat();
            Cv2.Resize(img, resize_img, new Size(resize_w, imgH), 0.0f, 0.0f, InterpolationFlags.Linear);
            return resize_img;
        }


        public static Mat crnn_resize_img(Mat img, float wh_ratio, int[] rec_image_shape)
        {
            _ = rec_image_shape[0];
            int num = rec_image_shape[1];
            int num2 = rec_image_shape[2];
            num2 = (int)((float)num * wh_ratio);
            float num3 = (float)img.Cols / (float)img.Rows;
            int width = ((!(Math.Ceiling((float)num * num3) > (double)num2)) ? ((int)Math.Ceiling((float)num * num3)) : num2);
            Mat mat = new Mat();
            Cv2.Resize(img, mat, new Size(width, num));
            Cv2.CopyMakeBorder(mat, mat, 0, 0, 0, num2 - mat.Cols, BorderTypes.Constant, new Scalar(127.0, 127.0, 127.0));
            return mat;
        }



        public static void TableResizeImg(Mat img, Mat resize_img, int max_len = 488)
        {
            int w = img.Cols;
            int h = img.Rows;

            int max_wh = w >= h ? w : h;
            float ratio = w >= h ? (float)(max_len) / (float)(w) : (float)(max_len) / (float)(h);

            int resize_h = (int)((float)(h) * ratio);
            int resize_w = (int)((float)(w) * ratio);

            Cv2.Resize(img, resize_img, new Size(resize_w, resize_h));
        }
        public static Mat TablePadImg(Mat img, int max_len = 488)
        {
            int w = img.Cols;
            int h = img.Rows;
            Mat resize_img = new Mat();
            Cv2.CopyMakeBorder(img, resize_img, 0, max_len - h, 0, max_len - w, BorderTypes.Constant, new Scalar(0, 0, 0));
            return resize_img;
        }

        public static Mat Resize(Mat img, int h, int w)
        {
            Mat resize_img = new Mat();
            Cv2.Resize(img, resize_img, new Size(w, h));
            return resize_img;
        }
    }
}
