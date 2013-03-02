using PersonFinancial.Common;

namespace PersonFinancial.Model
{
    public class City
    {
        /// <summary>
        /// 城市编号（从0开始）
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 城市名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 社会基本保险比例
        /// </summary>
        public SBRate Sr { get; set; }
    }

    public class SBRate
    {

        /// <summary>
        /// 个人养老保险缴费比例
        /// </summary>
        public decimal PerYLRate { get; set; }

        /// <summary>
        /// 企业养老保险缴费比例
        /// </summary>
        public decimal ComYLRate { get; set; }

        /// <summary>
        /// 个人医疗缴费比例
        /// </summary>
        public decimal PerYiLRate { get; set; }

        /// <summary>
        /// 企业医疗缴费比例
        /// </summary>
        public decimal ComYiLRate { get; set; }

        /// <summary>
        /// 个人失业缴费比例
        /// </summary>
        public decimal PerShiYeRate { get; set; }

        /// <summary>
        /// 企业失业缴费比例
        /// </summary>
        public decimal ComShiYeRate { get; set; }

        /// <summary>
        /// 个人工伤缴费比例
        /// </summary>
        public decimal PerGSRate { get; set; }

        /// <summary>
        /// 企业工伤缴费比例
        /// </summary>
        public decimal ComGSRate { get; set; }

        /// <summary>
        /// 个人生育缴费比例
        /// </summary>
        public decimal PerSYRate { get; set; }

        /// <summary>
        /// 企业生育缴费比例
        /// </summary>
        public decimal ComSYRate { get; set; }

        /// <summary>
        /// 个人公积金缴费比例
        /// </summary>
        public decimal PerGJJRate { get; set; }

        /// <summary>
        /// 企业公积金缴费比例
        /// </summary>
        public decimal ComGJJRate { get; set; }

        /// <summary>
        /// 社保基数最低值
        /// </summary>
        public int MinSBJS { get; set; }

        /// <summary>
        /// 社保基数最高值
        /// </summary>
        public int MaxSBJS { get; set; }

        /// <summary>
        /// 公积金基数最低值
        /// </summary>
        public int MinGJJJS { get; set; }

        /// <summary>
        /// 公积金基数最高值
        /// </summary>
        public int MaxGJJJS { get; set; }
    }
}
