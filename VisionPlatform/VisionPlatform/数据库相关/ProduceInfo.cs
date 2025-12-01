using System;
using System.Collections;
using System.ComponentModel;
using Hi.Ltd.Enumerations;
using Hi.Ltd.SqlServer;

namespace VisionPlatform.Tables
{
    [Table("ProduceInfo"), Database("VisionPlatform")]
    public class ProduceInfo : BaseTable
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), DisplayName("编号")]
        public int Id { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Required, DisplayName("日期")]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 产品二维码内容
        /// </summary>
        [DisplayName("产品二维码内容"), MaxLength(250)]
        public string Code { get; set; }
        /// <summary>
        /// 字符内容
        /// </summary>
        [DisplayName("字符内容"), MaxLength(250)]
        public string CharacterContent { get; set; }
        /// <summary>
        /// 插件
        /// </summary>
        [DisplayName("插件有无")]
        public bool PlugIn { get; set; }
        /// <summary>
        /// 铜环破损
        /// </summary>
        [DisplayName("铜环破损")]
        public bool CopperRingDamaged { get; set; }
        /// <summary>
        /// 贴片有无
        /// </summary>
        [DisplayName("贴片有无")]
        public bool paster { get; set; }
        /// <summary>
        /// 正面横向间距
        /// </summary>
        [DisplayName("正面横向间距基准最小值"), MaxLength(250)]
        public string HorizontalSpacingMin { get; set; }
        /// <summary>
        /// 正面横向间距
        /// </summary>
        [DisplayName("正面横向间距基准最大值"), MaxLength(250)]
        public string HorizontalSpacingMax { get; set; }
        /// <summary>
        /// 正面横向间距基准
        /// </summary>
        [DisplayName("正面横向间距"), MaxLength(250)]
        public string HorizontalSpacing { get; set; }
        /// <summary>
        /// 正面纵向间距基准最小值
        /// </summary>
        [DisplayName("正面纵向间距基准最小值"), MaxLength(250)]
        public string VerticalSpacingMin { get; set; }
        /// <summary>
        /// 正面纵向间距基准最小值
        /// </summary>
        [DisplayName("正面纵向间距基准最大值"), MaxLength(250)]
        public string VerticalSpacingMax { get; set; }
        /// <summary>
        /// 正面纵向间距
        /// </summary>
        [DisplayName("正面纵向间距"), MaxLength(250)]
        public string VerticalSpacing { get; set; }
        /// <summary>
        /// 横向高度基准最小值
        /// </summary>
        [DisplayName("横向高度基准最小值"), MaxLength(250)]
        public string HorizontalHeightMin { get; set; }
        /// <summary>
        /// 横向高度基准最大值
        /// </summary>
        [DisplayName("横向高度基准最大值"), MaxLength(250)]
        public string HorizontalHeightMax { get; set; }
        /// <summary>
        /// 横向高度
        /// </summary>
        [DisplayName("横向高度"), MaxLength(250)]
        public string HorizontalHeight { get; set; }
        /// <summary>
        /// 横向针脚距离基准最小值
        /// </summary>
        [DisplayName("横向针脚距离基准最小值"), MaxLength(250)]
        public string HorizontalStitchSpacingMin { get; set; }
        /// <summary>
        /// 横向针脚距离基准最大值
        /// </summary>
        [DisplayName("横向针脚距离基准最大值"), MaxLength(250)]
        public string HorizontalStitchSpacingMax { get; set; }
        /// <summary>
        /// 横向针脚距离
        /// </summary>
        [DisplayName("横向针脚距离"), MaxLength(250)]
        public string HorizontalStitchSpacing { get; set; }
        /// <summary>
        /// 焊锡检测
        /// </summary>
        [Required, DisplayName("焊锡检测")]
        public bool SolderInspection { get; set; }
        /// <summary>
        /// 铜柱检测
        /// </summary>
        [DisplayName("铜柱检测")]
        public bool CopperColumnDetection { get; set; }
        /// <summary>
        /// 总结果
        /// </summary>
        [DisplayName(" 总结果")]
        public bool OverallResult { get; set; }
        /// <summary>
        /// 导出CSV文件时的文件列标题头
        /// </summary>
        public static readonly string TitleHeadMessage = "编号, 日期, 产品二维码内容, 字符内容, 插件有无, 铜环破损, 贴片有无,正面横向间距基准最小值,正面横向间距基准最大值, 正面横向间距,正面纵向间距基准最小值,正面纵向间距基准最大值, 正面纵向间距, 横向高度基准最小值,横向高度基准最大值,横向高度, 横向针脚距离最小值,横向针脚距离基准最大值,横向针脚距离, 焊锡检测, 铜柱检测, 总结果";
        public override string[] GetDescriptions()
        {
            return ["编号", "日期", "产品二维码内容", "字符内容", "插件有无", "铜环破损", "贴片有无", "正面横向间距基准最小值", "正面横向间距基准最大值", "正面横向间距", "正面纵向间距基准最小值", "正面纵向间距基准最大值", "正面纵向间距", "横向高度基准最小值", "横向高度基准最大值", "横向高度", "横向针脚距离最小值", "横向针脚距离基准最大值", "横向针脚距离", "焊锡检测", "铜柱检测", " 总结果"];
        }

        public override IEnumerator GetEnumerator()
        {
            yield return Id;
            yield return DateTime;
            yield return Code;
            yield return CharacterContent;
            yield return PlugIn;
            yield return CopperRingDamaged;
            yield return paster;
            yield return HorizontalSpacingMin;
            yield return HorizontalSpacingMax;
            yield return HorizontalSpacing;
            yield return VerticalSpacingMin;
            yield return VerticalSpacingMax;
            yield return VerticalSpacing;
            yield return HorizontalHeightMin;
            yield return HorizontalHeightMax;
            yield return HorizontalHeight;
            yield return HorizontalStitchSpacingMin;
            yield return HorizontalStitchSpacingMax;
            yield return HorizontalStitchSpacing;
            yield return SolderInspection;
            yield return CopperColumnDetection;
            yield return OverallResult;

        }

        public override string[] GetNames()
        {
            return [
            "Id",
            "DateTime",
            " Code",
            " CharacterContent",
            " PlugIn",
            " CopperRingDamaged",
            " paster",
            "HorizontalSpacingMin",
           " HorizontalSpacingMax",
            " HorizontalSpacing",
            "VerticalSpacingMin",
            "VerticalSpacingMax",
            " VerticalSpacing",
            "HorizontalHeightMin",
            "HorizontalHeightMax",
            " HorizontalHeight",
            "HorizontalStitchSpacingMin",
            "HorizontalStitchSpacingMax",
            " HorizontalStitchSpacing",
            " SolderInspection",
            " CopperColumnDetection",
            " OverallResult"];
        }

        public override Type[] GetTypes()
        {
            return [typeof(int), typeof(DateTime), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(bool), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(bool)];
        }

        public override object[] ToArray()
        {
            return [
            Id,
            DateTime,
            Code,
            CharacterContent,
            PlugIn,
            CopperRingDamaged,
            paster,
            HorizontalSpacingMin,
            HorizontalSpacingMax,
            HorizontalSpacing,
            VerticalSpacingMin,
            VerticalSpacingMax,
            VerticalSpacing,
            HorizontalHeightMin,
            HorizontalHeightMax,
            HorizontalHeight,
            HorizontalStitchSpacingMin,
            HorizontalStitchSpacingMax,
            HorizontalStitchSpacing,
            SolderInspection,
            CopperColumnDetection,
            OverallResult];
        }

        public enum Index
        {
            /// <summary>
            /// 编号
            /// </summary>
            Id,
            /// <summary>
            /// 日期
            /// </summary>
            DateTime,
            /// <summary>
            /// 产品二维码内容
            /// </summary>
            Code,
            /// <summary>
            /// 字符内容
            /// </summary>
            CharacterContent,
            /// <summary>
            /// 插件
            /// </summary>
            PlugIn,
            /// <summary>
            /// 铜环破损
            /// </summary>
            CopperRingDamaged,
            /// <summary>
            /// 贴片有无
            /// </summary>
            paster,
            /// <summary>
            /// 正面横向间距基准最小值
            /// </summary>
            HorizontalSpacingMin,
            /// <summary>
            /// 正面横向间距基准最大值
            /// </summary>
            HorizontalSpacingMax,
            /// <summary>
            /// 正面横向间距
            /// </summary>
            HorizontalSpacing,
            /// <summary>
            /// 正面纵向间距基准最小值
            /// </summary>
            VerticalSpacingMin,
            /// <summary>
            /// 正面纵向间距基准最大值
            /// </summary>
            VerticalSpacingMax,
            /// <summary>
            /// 正面纵向间距
            /// </summary>
            VerticalSpacing,
            /// <summary>
            /// 横向高度基准最小值
            /// </summary>
            HorizontalHeightMin,
            /// <summary>
            /// 横向高度基准最大值
            /// </summary>
            HorizontalHeightMax,
            /// <summary>
            /// 横向高度
            /// </summary>
            HorizontalHeight,
            /// <summary>
            /// 横向针脚距离基准最小值
            /// </summary>
            HorizontalStitchSpacingMin,
            /// <summary>
            /// 横向针脚距离基准最大值
            /// </summary>
            HorizontalStitchSpacingMax,
            /// <summary>
            /// 横向针脚距离
            /// </summary>
            HorizontalStitchSpacing,
            /// <summary>
            /// 焊锡检测
            /// </summary>
            SolderInspection,
            /// <summary>
            /// 铜柱检测
            /// </summary>
            CopperColumnDetection,
            /// <summary>
            /// 总结果
            /// </summary>
            OverallResult,
        }

        public override string ToString()
        {
            return $"{Id},{DateTime},{Code},{CharacterContent},{PlugIn},{CopperRingDamaged},{paster},{HorizontalSpacingMin},{HorizontalSpacingMax},{HorizontalSpacing},{VerticalSpacingMin},{VerticalSpacingMax},{VerticalSpacing},{HorizontalHeightMin},{HorizontalHeightMax},{HorizontalHeight},{HorizontalStitchSpacingMin},{HorizontalStitchSpacingMax},{HorizontalStitchSpacing},{SolderInspection},{CopperColumnDetection},{OverallResult} ";
        }
    }
}
