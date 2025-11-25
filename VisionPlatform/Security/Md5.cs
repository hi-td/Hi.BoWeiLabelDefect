/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Md5
* 机器名称：HLZN
* 命名空间：VisionPlatform.Security
* 文 件 名：Md5
* 创建时间：2022/1/17 10:51:31
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2021  保留所有权利.
***********************************************************/
using Hi.Ltd;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using VisionPlatform.Auxiliary;

namespace VisionPlatform.Security
{
    public static class Md5
    {
        public static Func<string, string> Encrypt => source =>
        {
            if (string.IsNullOrEmpty(source)) return default;
            try
            {
                using (var provider = HashAlgorithm.Create("System.Security.Cryptography.MD5"))
                {
                    var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(source));

                    var result = string.Empty;
                    foreach (var item in hash)
                    {
                        result += item.ToString("X2");
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.Log();
                return default;
            }

        };
        public static Func<string, string, string, int> Analyze => (modeChar, Password, Key) =>
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            checked
            {
                do
                {
                    int num6 = modeChar.IndexOf(Password[num5]);

                    if (num6 == -1)
                    {
                        num4 = 0;
                        break;
                    }
                    num2 += num6 << num3;
                    num3 += 5;
                    if (num3 >= 8)
                    {
                        if (num4 == 0)
                        {
                            num4 = Key[num] ^ (num2 & 0xFF);
                        }
                        else
                        {
                            num6 = Key[num];
                            num6 ^= num2 & 0xFF;
                            if (num4 != num6)
                            {
                                num4 = 0;
                                break;
                            }
                        }
                        num++;
                        num2 >>= 8;
                        num3 -= 8;
                    }
                    num5++;
                }
                while (num5 < 16);
                return num4;
            }
        };
        public static Func<string, string> Verify => fileName =>
        {

            if (!File.Exists(fileName)) return default;
            try
            {
                using (var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    using (var md5 = HashAlgorithm.Create("System.Security.Cryptography.MD5"))
                    {
                        var bytes = md5.ComputeHash(file);
                        var result = string.Empty;
                        foreach (var item in bytes)
                        {
                            result += item.ToString("X2");
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Log();
                return default;
            }
        };

        public static Func<string, string, string> AddSalt => (source, salt) =>
        {
            try
            {
                if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(salt)) return default;

                StringBuilder result = new StringBuilder();
                var saltindex = 0;
                var random = new Random();
                var value = 0x30;
                for (var i = 0; i < source.Length; i++)
                {
                    var index = random.Next(source.Length);
                    if (index == 0) index = 1;
                    if (saltindex < salt.Length && index % (saltindex + 1) == 0)
                    {
                        result.Append(salt[saltindex]);

                        if (result.Length + value > 0x39)
                        {
                            value = 0x40;
                        }
                        else if (result.Length + value > 0x5A)
                        {
                            value = 0x61;
                        }
                        result.Append((char)(result.Length + value - 1));
                        saltindex++;
                    }
                    result.Append(source[i]);
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                ex.Log();
                return default;
            }
        };


        public static Func<string, string, string> RemoveSalt => (source, salt) =>
        {
            try
            {
                if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(salt)) return default;

                string result = string.Empty;
                var saltIndex = 0;
                var temp = 0x30;
                for (var i = 0; i < source.Length; i++)
                {
                    if (saltIndex <= salt.Length)
                    {
                        if (source[i].Equals(salt[saltIndex]))
                        {
                            if (i + 1 < source.Length)
                            {
                                var index = (int)source[i + 1];
                                if (index > 0x39)
                                {
                                    temp = 0x40;
                                }
                                else if (index > 0x5A)
                                {
                                    temp = 0x61;
                                }
                                if (i == index - temp)
                                {
                                    saltIndex++;
                                    i++;
                                }
                                else
                                {
                                    result += source[i];
                                }
                            }
                        }
                        else
                        {
                            result += source[i];
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                ex.Log();
                return default;
            }
        };
    }
}
