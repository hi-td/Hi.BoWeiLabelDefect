
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace OpenVinoSharp.Extensions.Utility
{
    public static partial class Utility
    {

        public static bool chech_path(string path) 
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine(path + " 已存在");
                return true;
            }
            else
            {
                Console.WriteLine(path + "不存在");
                return false;
            }
        }

        public static bool chech_file(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine(path + " 已存在");
                return true;
            }
            else
            {
                Console.WriteLine(path + "不存在");
                return false;
            }
        }

        public static  T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

       
    }



    public class DownloadConsole
    {
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string _twirl = "-\\|/";

        float total_m;
        long total_len;

        float last_down = 0;
        long last_time = 0;
        int num = 0;

        public DownloadConsole(long total_len) 
        {
            this.total_m = (float)total_len / (1024.0f * 1024.0f);
            this.total_len = total_len;
        }
        public void progress_bar(long down_len , long time, bool update = false)
        {
            int percent = (int)(((float)down_len / (float)total_len) * 100);
            float down = down_len / (1024.0f * 1024.0f);
            if (update)
                Console.Write(_back);
            Console.Write("<{0}> Downloading: [", TimeSpan.FromMilliseconds(time).ToString(@"hh\:mm\:ss"));
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i > p)
                    Console.Write("  ");
                else if (i == p)
                    Console.Write(_twirl[percent % _twirl.Length]);
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);

            if (num > 1000) 
            {
                float down_speed = (down - last_down) / (time - last_time) * 1000;
                string s = string.Format(" <{0} Mb/s> {1} Mb/{2} Mb downloaded.", 
                    down_speed.ToString("0.00"), down.ToString("0.00"), total_m.ToString("0.00"));
                Console.Write(s);
                num = 0;
                last_down = down;
                last_time = time;
            }
            else 
            {
                float down_speed = (down - last_down) / (time - last_time) * 1000;
                TimeSpan time_now = TimeSpan.FromMilliseconds(time);
                string formattedTime = time_now.ToString(@"hh\:mm\:ss");
                string s = string.Format(" <{0} {1} Mb/s> {2} Mb/{3} Mb downloaded.",
                                    formattedTime, down_speed.ToString("0.00"), down.ToString("0.00"), total_m.ToString("0.00"));
                Console.Write(s);
            }
            num++;
        }
    }

}
