using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

using Newtonsoft.Json;

namespace VisionPlatform.Auxiliary
{
    public class MesHelper
    {
        /// <summary>
        /// 单例模式声明
        /// </summary>
        public static MesHelper Create = new MesHelper();
        private readonly object _locker = new object();
        private string _uri;
        private string _qaUri;
        private bool _rOrT;
        private MesHelper()
        {
        }
        /// <summary>
        /// 正式环境网址
        /// </summary>
        public string Uri { get => _uri; set => _uri = value; }
        /// <summary>
        /// QA(测试)环境网址
        /// </summary>
        public string QaUri { get => _qaUri; set => _qaUri = value; }
        /// <summary>
        /// 是正式环境还是测试环境
        /// </summary>
        public bool ROrT { get => _rOrT; set => _rOrT = value; }

        //public string Upload(RubberTable content)
        //{
        //    try
        //    {
        //        lock (_locker)
        //        {
        //            var jsonstr = JsonConvert.SerializeObject(content);
        //            var buff = Encoding.GetEncoding("UTF-8").GetBytes(jsonstr);
        //            var request = _rOrT ? _uri : _qaUri;
        //            var httpWebRequest = (HttpWebRequest)WebRequest.Create(request);
        //            httpWebRequest.Method = "POST";
        //            httpWebRequest.ContentType = "application/json; charset=UTF-8";
        //            httpWebRequest.ContentLength = jsonstr.Length;
        //            httpWebRequest.Accept = "application/json";
        //            httpWebRequest.KeepAlive = true;
        //            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
        //            httpWebRequest.ProtocolVersion = HttpVersion.Version10;
        //            using var requestStream = httpWebRequest.GetRequestStream();
        //            requestStream.Write(buff, 0, buff.Length);
        //            using var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //            using var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
        //            return streamReader.ReadToEnd();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Log(MethodBase.GetCurrentMethod());
        //        return null;
        //    }
        //}
    }
}
