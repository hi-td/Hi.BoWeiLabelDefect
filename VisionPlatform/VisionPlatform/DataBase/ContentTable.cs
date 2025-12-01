using Hi.Ltd.SqlServer;
using System;
using System.ComponentModel;

namespace VisionPlatform.Auxiliary
{
    /// <summary>
    /// 弹片信息表
    /// </summary>
    [Serializable]
    [Table("RubberTable"), Database("Hi.Ltd")]
    public class RubberTable
    {
        [Newtonsoft.Json.JsonIgnore]
        [Key]
        [DisplayName("编号")]
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [MaxLength(150), Required]
        [DisplayName("工单")]
        /// <summary>
        ///工单
        /// </summary>
        public string WorkOrderNumber { get; set; }

        [MaxLength(150), Required]
        [DisplayName("组件编号")]
        /// <summary>
        /// 组件编号
        /// </summary>
        public string ComponentCode { get; set; }

        [MaxLength(150), Required]
        [DisplayName("条码")]
        /// <summary>
        /// 条码
        /// </summary>
        public string ContentId { get; set; }

        [MaxLength(250), Required]
        [DisplayName("型号")]
        /// <summary>
        /// 型号
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 端子弹片下塌基准距离
        /// </summary>
        public double Distance { get; set; }
        /// <summary>
        /// 端子弹片下塌距离上限
        /// </summary>
        public double DistanceUp { get; set; }
        /// <summary>
        /// 端子弹片下塌距离下限
        /// </summary>
        public double DistanceDown { get; set; }
        /// <summary>
        /// 端子弹片下塌检测距离
        /// </summary>
        public string DistanceResult { get; set; }
        /// <summary>
        /// Gap基准
        /// </summary>
        public double GapDistance { get; set; }
        /// <summary>
        /// Gap上限
        /// </summary>
        public double GapDistanceUp { get; set; }
        /// <summary>
        /// Gap下限
        /// </summary>
        public double GapDistanceDown { get; set; }
        /// <summary>
        /// Gap检测结果
        /// </summary>
        public string GapResult { get; set; }
        /// <summary>
        /// 判定结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 判定结果详情
        /// </summary>
        public string ResultParticulars { get; set; }
        internal object[] ToArray()
        {
            return new object[] { Id, WorkOrderNumber, ComponentCode, ContentId, ModelName, DateTime, Distance, DistanceUp, DistanceDown, DistanceResult, GapDistance, GapDistanceUp, GapDistanceDown, GapResult, Result ? "OK" : "NG", ResultParticulars };
        }

        internal enum Index
        {
            Id, WorkOrderNumber, ComponentCode, ContentId, ModelName, DateTime, Distance, DistanceUp, DistanceDown, DistanceResult, GapDistance, GapDistanceUp, GapDistanceDown, GapResult, Result, ResultParticulars
        }
    }
    public enum RubberIndex
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        Id,
        /// <summary>
        /// 工单号
        /// </summary>
        [Description("工单")]
        WorkOrderNumber,
        /// <summary>
        /// 组件编号
        /// </summary>
        [Description("组件编号")]
        ComponentCode,
        /// <summary>
        /// 条码
        /// </summary>
        [Description("条码")]
        ContentId,
        /// <summary>
        /// 型号
        /// </summary>
        [Description("型号")]
        ModelName,
        /// <summary>
        /// 日期
        /// </summary>
        [Description("时间")]
        DateTime,
        /// <summary>
        /// 端子弹片下塌基准距离
        /// </summary>
        [Description("端子弹片下塌基准")]
        Distance,
        /// <summary>
        /// 端子弹片下塌距离上限
        /// </summary>
        [Description("端子弹片下塌上限")]
        DistanceUp,
        /// 端子弹片下塌距离下限
        /// </summary>
        [Description("端子弹片下塌下限")]
        DistanceDown,
        /// <summary>
        /// 端子弹片下塌检测距离
        /// </summary>
        [Description("端子弹片下塌检测结果")]
        DistanceResult,
        /// <summary>
        /// Gap基准
        /// </summary>
        [Description("Gap基准")]
        GapDistance,
        /// <summary>
        /// Gap上限
        /// </summary>
        [Description("Gap上限")]
        GapDistanceUp,
        /// <summary>
        /// Gap下限
        /// </summary>
        [Description("Gap下限")]
        GapDistanceDown,
        /// <summary>
        /// Gap检测结果
        /// </summary>
        [Description("Gap检测结果")]
        GapResult,
        /// <summary>
        /// 判定结果
        /// </summary>
        [Description("判定结果")]
        Result,
        /// <summary>
        /// 判定结果详情
        /// </summary>
        [Description("判定结果详情")]
        ResultParticulars,
    }


    public class ExportData
    {
        /// <summary>
        /// 导出CSV文件时的文件列标题头
        /// </summary>
        public static readonly string TitleHeadMessage = "编号,工单，组件编码，条码,型号，日期,端子弹片下塌基准，端子弹片下塌上限，端子弹片下塌下限，端子弹片下塌检测结果，Gap基准，Gap上限，Gap下限，Gap检测结果，判定结果，判定结果详情";
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工单号
        /// </summary>

        public string WorkOrderNumber { get; set; }
        /// <summary>
        /// 组件编号
        /// </summary>

        public string ComponentCode { get; set; }
        /// <summary>
        /// 条码
        /// </summary>

        public string ContentId { get; set; }
        /// <summary>
        /// 型号
        /// </summary>

        public string ModelName { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 端子弹片下塌基准距离
        /// </summary>
        public double Distance { get; set; }
        /// <summary>
        /// 端子弹片下塌距离上限
        /// </summary>
        public double DistanceUp { get; set; }
        /// <summary>
        /// 端子弹片下塌距离下限
        /// </summary>
        public double DistanceDown { get; set; }
        /// <summary>
        /// 端子弹片下塌检测距离
        /// </summary>
        public string DistanceResult { get; set; }
        /// <summary>
        /// Gap基准
        /// </summary>
        public double GapDistance { get; set; }
        /// <summary>
        /// Gap上限
        /// </summary>
        public double GapDistanceUp { get; set; }
        /// <summary>
        /// Gap下限
        /// </summary>
        public double GapDistanceDown { get; set; }
        /// <summary>
        /// Gap检测结果
        /// </summary>
        public string GapResult { get; set; }
        /// <summary>
        /// 判定结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 判定结果详情
        /// </summary>
        public string ResultParticulars { get; set; }

        public override string ToString()
        {
            return $"{Id},{WorkOrderNumber}, {ComponentCode}, {ContentId},{ModelName},{DateTime}, {Distance}, {DistanceUp}, {DistanceDown}, {DistanceResult}, {GapDistance}, {GapDistanceUp}, {GapDistanceDown}, {GapResult}，{(Result ? "OK" : "NG")},{ResultParticulars}";
        }
    }
}
