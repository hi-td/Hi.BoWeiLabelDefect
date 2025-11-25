/***********************************************************
* CLR版本：4.0.30319.42000
* 类 名 称：$safeprojectname$
* 机器名称：DELL-CHUSTANGE
* 命名空间：VisionPlatform.Auxiliary
* 文 件 名：PLCRecipeRecord
* 创建时间：2025/1/17 14:07:14
* 作    者： Chustange
* 公    司：HaiLan Intelligent
* 说   明：
* 修改时间：
* 修 改 人：
* 修改说明：
* 深圳市海蓝智能科技有限公司 © 2025  保留所有权利.
***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi.Ltd;

namespace VisionPlatform.Auxiliary
{
    /// <summary>
    /// PLC配方数据
    /// </summary>
    [Serializable]
    public class PLCRecipeRecord
    {
        /// <summary>
        /// Z轴JOG速度
        /// </summary>
        public float D2000 { get; set; }
        /// <summary>
        /// Z轴加减速
        /// </summary>
        public float D2020 { get; set; }
        /// <summary>
        /// Z轴定位位置/待机位
        /// </summary>
        public float D2042 { get; set; }
        /// <summary>
        /// Z轴定位位置/拍照位
        /// </summary>
        public float D2044 { get; set; }
        /// <summary>
        /// Z轴定位速度
        /// </summary>
        public float D2074 { get; set; }
        /// <summary>
        /// Y轴JOG速度
        /// </summary>
        public float D2100 { get; set; }
        /// <summary>
        /// Y轴加减速
        /// </summary>
        public float D2120 { get; set; }
        /// <summary>
        /// Y轴定位位置/待机位
        /// </summary>
        public float D2142 { get; set; }
        /// <summary>
        /// Y轴定位位置/拍照位
        /// </summary>
        public float D2144 { get; set; }
        /// <summary>
        /// Y轴定位速度
        /// </summary>
        public float D2174 { get; set; }
        /// <summary>
        /// Z1轴JOG速度
        /// </summary>
        public float D2200 { get; set; }
        /// <summary>
        /// Z1轴加减速
        /// </summary>
        public float D2220 { get; set; }
        /// <summary>
        /// Z1轴定位位置/待机位
        /// </summary>
        public float D2242 { get; set; }
        /// <summary>
        /// Z1轴定位位置/拍照位
        /// </summary>
        public float D2244 { get; set; }
        /// <summary>
        /// Z1轴定位速度
        /// </summary>
        public float D2274 { get; set; }
        /// <summary>
        /// Y1轴JOG速度
        /// </summary>
        public float D2300 { get; set; }
        /// <summary>
        /// Y1轴加减速
        /// </summary>
        public float D2320 { get; set; }
        /// <summary>
        /// Y1轴定位位置/待机位
        /// </summary>
        public float D2342 { get; set; }
        /// <summary>
        /// Y1轴定位位置/拍照位
        /// </summary>
        public float D2344 { get; set; }
        /// <summary>
        /// Y1轴定位速度
        /// </summary>
        public float D2374 { get; set; }
        /// <summary>
        /// R轴JOG速度
        /// </summary>
        public float D2400 { get; set; }
        /// <summary>
        /// R轴加减速
        /// </summary>
        public float D2420 { get; set; }
        /// <summary>
        /// R轴定位位置/待机位
        /// </summary>
        public float D2442 { get; set; }
        /// <summary>
        /// R轴定位位置/拍照位
        /// </summary>
        public float D2444 { get; set; }
        /// <summary>
        /// R轴定位速度
        /// </summary>
        public float D2474 { get; set; }
        /// <summary>
        /// 贯穿轴JOG速度
        /// </summary>
        public float D2500 { get; set; }
        /// <summary>
        /// 贯穿轴加减速
        /// </summary>
        public float D2520 { get; set; }
        /// <summary>
        /// 贯穿轴定位位置/待机位
        /// </summary>
        public float D2542 { get; set; }
        /// <summary>
        /// 贯穿轴定位位置/拍照位
        /// </summary>
        public float D2544 { get; set; }
        /// <summary>
        /// 贯穿轴定位速度
        /// </summary>
        public float D2574 { get; set; }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return D2000;
                    case 1:
                        return D2020;
                    case 2:
                        return D2042;
                    case 3:
                        return D2044;
                    case 4:
                        return D2074;
                    case 5:
                        return D2100;
                    case 6:
                        return D2120;
                    case 7:
                        return D2142;
                    case 8:
                        return D2144;
                    case 9:
                        return D2174;
                    case 10:
                        return D2200;
                    case 11:
                        return D2220;
                    case 12:
                        return D2242;
                    case 13:
                        return D2244;
                    case 14:
                        return D2274;
                    case 15:
                        return D2300;
                    case 16:
                        return D2320;
                    case 17:
                        return D2342;
                    case 18:
                        return D2344;
                    case 19:
                        return D2374;
                    case 20:
                        return D2400;
                    case 21:
                        return D2420;
                    case 22:
                        return D2442;
                    case 23:
                        return D2444;
                    case 24:
                        return D2474;
                    case 25:
                        return D2500;
                    case 26:
                        return D2520;
                    case 27:
                        return D2542;
                    case 28:
                        return D2544;
                    case 29:
                        return D2574;
                    default:
                        return null;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        D2000 = Convert.ToSingle(value);
                        break;
                    case 1:
                        D2020 = Convert.ToSingle(value);
                        break;
                    case 2:
                        D2042 = Convert.ToSingle(value);
                        break;
                    case 3:
                        D2044 = Convert.ToSingle(value);
                        break;
                    case 4:
                        D2074 = Convert.ToSingle(value);
                        break;
                    case 5:
                        D2100 = Convert.ToSingle(value);
                        break;
                    case 6:
                        D2120 = Convert.ToSingle(value);
                        break;
                    case 7:
                        D2142 = Convert.ToSingle(value);
                        break;
                    case 8:
                        D2144 = Convert.ToSingle(value);
                        break;
                    case 9:
                        D2174 = Convert.ToSingle(value);
                        break;
                    case 10:
                        D2200 = Convert.ToSingle(value);
                        break;
                    case 11:
                        D2220 = Convert.ToSingle(value);
                        break;
                    case 12:
                        D2242 = Convert.ToSingle(value);
                        break;
                    case 13:
                        D2244 = Convert.ToSingle(value);
                        break;
                    case 14:
                        D2274 = Convert.ToSingle(value);
                        break;
                    case 15:
                        D2300 = Convert.ToSingle(value);
                        break;
                    case 16:
                        D2320 = Convert.ToSingle(value);
                        break;
                    case 17:
                        D2342 = Convert.ToSingle(value);
                        break;
                    case 18:
                        D2344 = Convert.ToSingle(value);
                        break;
                    case 19:
                        D2374 = Convert.ToSingle(value);
                        break;
                    case 20:
                        D2400 = Convert.ToSingle(value);
                        break;
                    case 21:
                        D2420 = Convert.ToSingle(value);
                        break;
                    case 22:
                        D2442 = Convert.ToSingle(value);
                        break;
                    case 23:
                        D2444 = Convert.ToSingle(value);
                        break;
                    case 24:
                        D2474 = Convert.ToSingle(value);
                        break;
                    case 25:
                        D2500 = Convert.ToSingle(value);
                        break;
                    case 26:
                        D2520 = Convert.ToSingle(value);
                        break;
                    case 27:
                        D2542 = Convert.ToSingle(value);
                        break;
                    case 28:
                        D2544 = Convert.ToSingle(value);
                        break;
                    case 29:
                        D2574 = Convert.ToSingle(value);
                        break;
                    default:
                        break;
                }
            }


        }
    }



}
