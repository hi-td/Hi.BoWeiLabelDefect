/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：Parse
* 机器名称：HLZN
* 命名空间：Hi.RL.DTM.Method.Static
* 文 件 名：Parse
* 创建时间：2022/5/19 19:10:33
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2022  保留所有权利.
***********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

using Hi.Ltd;
using Hi.Ltd.Enumerations;
using Newtonsoft.Json.Linq;

namespace VisionPlatform.Auxiliary
{
    public static class Parse
    {
        public static int Nullable(this int? value) => value ?? -1;
        public static short Nullable(this short? value) => value ?? -1;
        public static float Nullable(this float? value) => value ?? -1F;
        public static double Nullable(this double? value) => value ?? -1D;
        /// <summary>
        /// 将object对象转化成已知的数据类型
        /// </summary>
        /// <typeparam name="T">目标数据类型</typeparam>
        /// <param name="value">目标对象</param>
        /// <returns>成功返回对应的目标数据类型的对象，否则返回default&lt;T&gt;();</returns>
        public static T Typeof<T>(this object value) => value is T result ? result : default;

        public static int ToInt(this string value) => int.TryParse(value, out var i) ? i : default;
        public static int ToInt(this object value) => int.TryParse((value ?? string.Empty).ToString(), out var i) ? i : default;
        public static decimal ToDecimal(this string value) => decimal.TryParse(value, out var d) ? d : default;
        public static int ShortToInt(short x, short y) => BitConverter.ToInt32(BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y).ToList()).ToArray(), 0);
        public static uint ShortToUInt(short x, short y) => BitConverter.ToUInt32(BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y).ToList()).ToArray(), 0);
        public static uint ToUInt(this string value) => uint.TryParse(value, out var result) ? result : default;
        public static ushort ToUShort(this string value) => ushort.TryParse(value, out var result) ? result : default;
        public static short ToShort(this string value) => short.TryParse(value, out var result) ? result : default;
        public static short ToShort(this object value) => short.TryParse((value ?? string.Empty).ToString(), out var result) ? result : default;
        public static List<short> IntToShort(int i) => new List<short>() { BitConverter.ToInt16(BitConverter.GetBytes(i).Take(2).ToArray(), 0), BitConverter.ToInt16(BitConverter.GetBytes(i).Skip(2).ToArray(), 0) };
        public static List<short> UIntToShort(uint i) => new List<short>() { BitConverter.ToInt16(BitConverter.GetBytes(i).Take(2).ToArray(), 0), BitConverter.ToInt16(BitConverter.GetBytes(i).Skip(2).ToArray(), 0) };
        public static List<short> FloatToShort(float f) => new List<short>() { BitConverter.ToInt16(BitConverter.GetBytes(f).Take(2).ToArray(), 0), BitConverter.ToInt16(BitConverter.GetBytes(f).Skip(2).ToArray(), 0) };
        public static List<short> DoubleToShort(double d) => new List<short>()
        {
            BitConverter.ToInt16(BitConverter.GetBytes(d).Take(2).ToArray(), 0),
            BitConverter.ToInt16(BitConverter.GetBytes(d).Take(4).Skip(2).ToArray(), 0),
            BitConverter.ToInt16(BitConverter.GetBytes(d).Take(6).Skip(4).ToArray(), 0),
            BitConverter.ToInt16(BitConverter.GetBytes(d).Skip(6).ToArray(), 0)
        };
        public static float ToFloat(this string value) => float.TryParse(value, out var result) ? result : default;
        public static float ToFloat(this object value) => float.TryParse((value ?? string.Empty).ToString(), out var result) ? result : default;
        public static float ShortToFloat(short x, short y) => BitConverter.ToSingle(BitConverter.GetBytes(x).Concat(BitConverter.GetBytes(y).ToList()).ToArray(), 0);
        public static double ToDouble(this string value) => double.TryParse(value, out var result) ? result : default;
        public static double ToDouble(this object value) => double.TryParse((value ?? string.Empty).ToString(), out var result) ? result : default;
        public static double ShortToDouble(short a, short b, short c, short d) => BitConverter.ToSingle(BitConverter.GetBytes(a).Concat(BitConverter.GetBytes(b).Concat(BitConverter.GetBytes(c).Concat(BitConverter.GetBytes(d).ToList()))).ToArray(), 0);

        public static DateTime ToDateTime(this string date) => DateTime.TryParse(date, out var result) ? result : default;
        public static long ToLong(this DateTime date)
        {
            var start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2022, 1, 1));
            var ts = date.Subtract(start);
            return long.Parse(ts.Ticks.ToString().Substring(0, ts.Ticks.ToString().Length - 4));
        }
        public static byte[] ToByte(this short value) => BitConverter.GetBytes(value);
        public static short ToShort(this byte[] value) => BitConverter.ToInt16(value, 0);
        public static int ToInt(this byte[] value) => BitConverter.ToInt32(value, 0);
        public static float ToFloat(this byte[] value) => BitConverter.ToSingle(value, 0);
        public static DateTime ToDateTime(this long value)
        {
            var start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2022, 1, 1));
            var time = long.Parse(value + "0000");
            return start.Add(new TimeSpan(time));
        }
        public static bool ToBoolean(this object value)
        {
            if (int.TryParse((value ?? "0").ToString(), out var i))
            {
                return i == 1;
            }
            else if (bool.TryParse((value ?? false).ToString(), out var b))
            {
                return b;
            }
            else if ((value ?? "false").ToString().ToLower().Equals("true"))
            {
                return true;
            }
            else if ((value ?? "off").ToString().ToLower().Equals("on"))
            {
                return true;
            }
            return false;
        }

        public static bool[] ToBoolean(this short[] value)
        {
            var result = new List<bool>();
            foreach (short x in value)
            {
                result.Add(x == 1);
            }
            return result.ToArray();
        }

        public static short SetBitValue(this short target, int index = 0, bool value = false) => value ? (short)(target | (short)(1 << index)) : (short)(target & ~(1 << index));
        public static bool GetBitValue(this short target, int index) => target.ToBitArray()[index];

        #region<!--ReflectionClone:反射克隆-->
        /// <summary>
        /// 反射克隆
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="Target">克隆目标</param>
        /// <returns>返回克隆结果</returns>
        public static T ReflectionClone<T>(this T Target)
        {
            var oRes = default(T);
            var oType = typeof(T);
            try
            {
                //得到新的对象对象
                oRes = (T)Activator.CreateInstance(oType);

                //给新的对象复制
                var lstPro = oType.GetProperties();
                foreach (var oPro in lstPro)
                {
                    //从旧对象里面取值
                    var oValue = oPro.GetValue(Target);

                    //复制给新的对象
                    oPro.SetValue(oRes, oValue);
                }
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
            }
            return oRes;
        }
        #endregion

        public static char[] ToChar(this byte[] value) => Encoding.ASCII.GetChars(value);
        public static byte[] ToByte(this char[] value) => Encoding.ASCII.GetBytes(value);

        public static short ToShort(this List<short> value)
        {
            List<byte> result = new List<byte>();
            byte lvalue = 0;
            byte hvalue = 0;
            if (value.Count <= 8)
            {
                for (var i = 0; i < 8; i++)
                {
                    if (value.ElementAt(i) == 1) lvalue += (byte)Math.Pow(2, i);
                }
            }
            else
            {
                for (var i = 0; i < 8; i++)
                {
                    if (value.ElementAt(i) == 1) lvalue += (byte)Math.Pow(2, i);

                    if (8 + i < value.Count)
                    {
                        if (value.ElementAt(8 + i) == 1) hvalue += (byte)Math.Pow(2, i);
                    }
                }
            }
            result.Add(lvalue);
            result.Add(hvalue);
            return BitConverter.ToInt16(result.ToArray(), 0);
        }

        #region<!--ToBitArray：将目标对象转化成BitArray数组-->
        public static BitArray ToBitArray(this short value) => new BitArray(BitConverter.GetBytes(value));
        public static BitArray ToBitArray(this ushort value) => new BitArray(BitConverter.GetBytes(value));
        public static BitArray ToBitArray(this uint value) => new BitArray(BitConverter.GetBytes(value));
        public static BitArray ToBitArray(this int value) => new BitArray(BitConverter.GetBytes(value));
        public static BitArray ToBitArray(this float value) => new BitArray(BitConverter.GetBytes(value));
        public static BitArray ToBitArray(this double value) => new BitArray(BitConverter.GetBytes(value));
        #endregion

        #region<!--ToEnum：将目标对象转化成枚举成员-->
        public static T ToEnum<T>(this string value) where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }

        }
        /// <summary>
        /// 将Int类型安全转化成对应枚举的项
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="value">待转化的值</param>
        /// <returns>返回目标值的对应枚举项</returns>
        public static T ToEnum<T>(this int value) where T : Enum
        {
            try
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }
        }
        /// <summary>
        /// 将short类型安全转化成对应枚举的项
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="value">待转化的值</param>
        /// <returns>返回目标值的对应枚举项</returns>
        public static T ToEnum<T>(this short value) where T : Enum
        {
            try
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }
        }
        #endregion

        #region<!--Description：获取目标枚举对应项的描述信息-->
        /// <summary>
        /// 获取目标枚举对应项的描述信息
        /// </summary>
        /// <param name="obj">目标枚举项</param>
        /// <returns>如果目标枚举有对应的描述信息，成功则返回对应的描述信息，失败则返回null</returns>
        public static string Description(this Enum obj)
        {
            try
            {
                return ((DescriptionAttribute[])obj.GetType().GetField(obj.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
            }
            catch (Exception ex)
            {
                ex.Log(MethodBase.GetCurrentMethod());
                return default;
            }
        }
        #endregion

        #region<!--GetEnum：从枚举的描述字符找到对应的枚举项-->
        /// <summary>
        /// 从枚举的描述字符找到对应的枚举项
        /// </summary>
        /// <typeparam name="T">目标枚举</typeparam>
        /// <param name="description">描述字符</param>
        /// <returns>如果目标枚举有对应的描述符，则返回对应的枚举项，如果没有则抛出异常</returns>
        /// <exception cref="InvalidOperationException">无效的枚举目标</exception>
        /// <exception cref="ArgumentException">引发错误</exception>
        public static T GetEnum<T>(this string description) where T : Enum
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException();

            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description) return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("当前枚举类型，没有相关的描述信息属性！", "Description");
        }
        #endregion

        public static string ToLower(this object value) => value?.ToString().ToLower();
        public static string ToUpper(this object value) => value?.ToString().ToUpper();



#if DOG || DEBUG || RELEASE  //加密用，正式发布，在项目属性->生成->常规->条件编译和符号(Y):中增加DOG项
        public static string GetValue(this RSAKeyValue keyValue)
        {
            FieldInfo[] fieldInfos = typeof(RSAKeyValue).GetFields();
            var value = $@"<RSAKeyValue>";
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                value += $@"<{fieldInfos[i].Name}>";
                value += keyValue[i];
                value += $@"</{fieldInfos[i].Name}>";
            }
            value += $@"</RSAKeyValue>";
            return value;
        }

#if TRACE //追踪用，正式发布，在项目属性->生成->常规->取消 定义TRACE常量(T)的勾选
        public static string GetKey(this RSAKeyValue keyValue)
        {
            FieldInfo[] fieldInfos = typeof(RSAKeyValue).GetFields();
            var value = $@"<RSAKeyValue>";
            for (int i = 0; i < 2; i++)
            {
                value += $@"<{fieldInfos[i].Name}>";
                value += keyValue[i];
                value += $@"</{fieldInfos[i].Name}>";
            }
            value += $@"</RSAKeyValue>";
            return value;
        }
#endif
#endif

        public static string[] ToSplit(this string Value) => Value.Split(',');

        public static Image ToImage(this byte[] value)
        {
            using (var ms = new MemoryStream(value))
            {
                var image = Image.FromStream(ms);

                return image;
            }
        }

        public static byte[] ToBytes(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var bytes = new byte[ms.Length];
                bytes = ms.GetBuffer();
                return bytes;
            }
        }
        /// <summary>
        /// 查找当前数组中符合指定长度数组数据所在的位置索引的集合
        /// </summary>
        /// <param name="source">目标数组</param>
        /// <param name="start">起始位置</param>
        /// <param name="pattern">待查数组</param>
        /// <returns>返回待查数组所在位置的索引的集合</returns>
        /// <exception cref="ArgumentNullException">目标数组或待查数组为Null</exception>
        public static IEnumerable<long> IndexesOf(this byte[] source, int start, byte[] pattern)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            long valueLength = source.LongLength;
            long patternLength = pattern.LongLength;

            if ((valueLength == 0) || (patternLength == 0) || (patternLength > valueLength))
            {
                yield break;
            }

            var badCharacters = new long[256];

            for (var i = 0; i < 256; i++)
            {
                badCharacters[i] = patternLength;
            }

            var lastPatternByte = patternLength - 1;

            for (long i = 0; i < lastPatternByte; i++)
            {
                badCharacters[pattern[i]] = lastPatternByte - i;
            }

            long index = start;

            while (index <= valueLength - patternLength)
            {
                for (var i = lastPatternByte; source[index + i] == pattern[i]; i--)
                {
                    if (i == 0)
                    {
                        yield return index;
                        break;
                    }
                }
                index += badCharacters[source[index + lastPatternByte]];
            }
        }
        /// <summary>
        /// 指示指定的对象是否为 null 或者 Empty
        /// </summary>
        /// <param name="source">要测试的对象</param>
        /// <returns>如果为 null 或者 Empty ,则返回 true ，否则 false </returns>
        //public static bool IsNullOrEmpty<T>(this T source) => source == null || source.Equals(default(T)) || source.GetType() == typeof(DBNull) || (source.GetType() == typeof(string) && string.IsNullOrWhiteSpace(source.ToString()));
        /// <summary>
        /// 指示指定的对象列表是否为 null
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="source">要测试的对象列表</param>
        /// <returns>如果为 null ,则返回 true ，否则 false</returns>
        //public static bool IsNullOrEmpty<T>(this List<T> source) => source == null || source.Equals(default(T)) || source.Count == 0;
        /// <summary>
        /// 指示指定的对象数组是否为 null
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="source">要测试的对象数组</param>
        /// <returns>如果为 null ,则返回 true ，否则 false</returns>
        //public static bool IsNullOrEmpty<T>(this T[] source) => source == null || source.Equals(default(T)) || source.Length == 0;
        /// <summary>
        /// 指示指定的对象数组是否为 null
        /// </summary>
        /// <typeparam name="T">指定的类型</typeparam>
        /// <param name="source">要测试的对象数组</param>
        /// <returns>如果为 null ,则返回 true ，否则 false</returns>
        //public static bool IsNullOrEmpty(this Array source) => source == null || source.Equals(default(Array)) || source.Length == 0;
        /// <summary>
        /// 指示指定的对象集合是否为 null
        /// </summary>
        /// <typeparam name="TKey">指定集合的键类型</typeparam>
        /// <typeparam name="TValue">指定集合的值类型</typeparam>
        /// <param name="source">要测试的对象集合</param>
        /// <returns>如果为 null ,则返回 true ，否则 false</returns>
        //public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> source) => source == null || source.Equals(default(Dictionary<TKey, TValue>)) || source.Count == 0;
        /// <summary>
        /// 将一种 ARGB 颜色转换成用于填充图形形状（如矩形、椭圆、饼形、多边形和封闭路径）的内部的对象。
        /// </summary>
        /// <param name="color">表示一种 ARGB 颜色（alpha、红色、绿色、蓝色）。</param>
        /// <returns>返回用于填充图形形状（如矩形、椭圆、饼形、多边形和封闭路径）的内部的对象</returns>
        public static Brush ToBrush(this Color color) => new SolidBrush(color);
        /// <summary>
        /// 用于填充图形形状（如矩形、椭圆、饼形、多边形和封闭路径）的内部的对象转化成一种 ARGB 颜色
        /// </summary>
        /// <returns>返回用于填充图形形状（如矩形、椭圆、饼形、多边形和封闭路径）的内部的对象</returns>
        /// <param name="brush"></param>
        /// <returns>返回一种 ARGB 颜色（alpha、红色、绿色、蓝色）</returns>
        public static Color ToColor(this Brush brush) => ((SolidBrush)brush).Color;
        /// <summary>
        /// 将object对象转化成已知的数据类型
        /// </summary>
        /// <typeparam name="T">目标数据类型</typeparam>
        /// <param name="source">目标对象</param>
        /// <param name="defaultvalue">失败时指定的默认值，默认为 null </param>
        /// <returns>成功返回对应的目标数据类型的对象，否则返回default&lt;T&gt;();</returns>
        public static T Is<T>(this object source, T defaultvalue = default) => source is T result ? result : defaultvalue;
        /// <summary>
        /// 将表达式结果显式转换为给定的引用或可以为 null 值的类型。 如果无法进行转换，则返回 null
        /// </summary>
        /// <typeparam name="T">给定的引用或可以为 null 值的类型</typeparam>
        /// <param name="source">目标对象</param>
        /// <returns>返回指定的引用或可以为null值的类型的对象</returns>
        public static T As<T>(this object source) where T : class => source as T;     
 
        public static bool IsEquals<T>(this string source, T target) where T : Enum => !source.IsNullOrEmpty() && !target.IsNullOrEmpty() && source.Equals(target.ToString());
        /// <summary>
        /// 验证IP地址是否合法
        /// </summary>
        /// <param name="source">要验证的IP地址</param>
        /// <returns>如果匹配，则为 true；否则为 false。</returns>
        public static bool IsValidIpAddress(this string source)
        {
            if (source.IsNullOrEmpty()) return false;
            return new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").IsMatch(source.Trim());
        }
        /// <summary>
        ///  将两个数组进行拼接，组成一个新的数组
        /// </summary>
        /// <typeparam name="T">目标数据类型</typeparam>
        /// <param name="source">数组 1 </param>
        /// <param name="Items">数组 2 </param>
        /// <returns>返回一个包含数组 1 所有成员和数组 2 所有成员的数组</returns>
        public static T[] Concat<T>(this T[] source, T[] Items)
        {
            if (source.IsNullOrEmpty()) return (T[])Items.Clone();
            if (Items.IsNullOrEmpty()) return (T[])source.Clone();
            var result = new T[source.Length + Items.Length];
            Array.Copy(source, 0, result, 0, source.Length);
            Array.Copy(Items, 0, result, source.Length, Items.Length);
            return result;
        }

        public static string Input(this object sender, double _maximum = 99999, double _minimum = -99999, DataType _dataType = DataType.Double, int _point = 1)
        {
            if (sender is Control ctrl)
            {
                var input = new Input(_maximum, _minimum, _dataType, _point)
                {
                    TopMost = true,
                    StartPosition = FormStartPosition.Manual,
                    ShowInTaskbar = false,
                };

                var location = ctrl.PointToScreen(Point.Empty);

                var screen = Screen.FromControl(ctrl);

                var workingArea = screen.WorkingArea;

                var inputWidth = input.Width;
                var inputHeight = input.Height;
                // 默认位置左下方
                var inputLocation = new Point(location.X + ctrl.Width, location.Y + ctrl.Height);
                // 检查是否超出屏幕右边界
                if (inputLocation.X + inputWidth > workingArea.Right)
                {
                    // 调整到右下方
                    inputLocation.X = location.X - inputWidth;
                }
                // 检查是否超出屏幕下边界
                if (inputLocation.Y + inputHeight > workingArea.Bottom)
                {
                    // 优先调整到左上方
                    inputLocation.Y = location.Y - inputHeight;

                    // 如果左上方也不行，调整到右上方
                    if (inputLocation.X + inputWidth > workingArea.Right)
                    {
                        inputLocation.X = location.X - inputWidth + ctrl.Width;
                    }
                }

                // 检查是否超出屏幕左边界和上边界
                if (inputLocation.X < workingArea.Left)
                {
                    inputLocation.X = workingArea.Left;
                }

                if (inputLocation.Y < workingArea.Top)
                {
                    inputLocation.Y = workingArea.Top;
                }


                input.Location = inputLocation;

                var result = input.ShowDialog(ctrl);

                if (result == DialogResult.OK)
                {
                    if (_point == 0)
                    {
                        return input.Content;
                    }
                    else
                    {
                        return input.Content.ToDouble().ToString($"f{_point}");
                    }
                }
            }
            return string.Empty;
        }

        public static PLCRecipeRecord GenPLCRecipeRecord(this Dictionary<int, Hi.Ltd.Data.Address> content)
        {
            var record = new PLCRecipeRecord();
            int index = 0;
            foreach (var item in content.Values)
            {
                record[index] = item.Value.ToString();
                index++;
            }
            return record;
        }

        public static bool[] GenAlarmStatus(this Dictionary<int, Hi.Ltd.Data.Address> content, List<Hi.Ltd.Data.Address> addresses)
        {
            var record = new bool[addresses.Count];
            int index = 0;
            foreach (var item in addresses)
            {
                var key = item.GetHashCode();
                record[index] = Convert.ToBoolean(content[key].Value);
                index++;
            }
            return record;
        }
    }
}
