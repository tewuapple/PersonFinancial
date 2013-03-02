using PersonFinancial.Common;
using PersonFinancial.Model;
using System;

namespace PersonFinancial
{
    /// <summary>
    /// 工资计算器类
    /// </summary>
    public class SalaryCalculator
    {
        /// <summary>
        /// 百分比常量
        /// </summary>
        private const decimal PERCENTRATE = 0.01m;

        /// <summary>
        /// 工资计算小数点位数
        /// </summary>
        private const int DIGIT = 2;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salary">税前工资</param>
        /// <param name="sb">社保比例类</param>
        /// <param name="yearbonus">年终奖</param>
        public SalaryCalculator(decimal salary, SBRate sb,decimal yearbonus=0)
        {
            _sb = sb;
            if (salary < _sb.MinSBJS)
                _sbjs = _sb.MinSBJS;
            else if (salary > _sb.MaxSBJS)
                _sbjs = _sb.MaxSBJS;
            else
                _sbjs = salary;
            if (salary < _sb.MinGJJJS)
                _gjjjs = _sb.MinGJJJS;
            else if (salary > _sb.MaxGJJJS)
                _gjjjs = _sb.MaxGJJJS;
            else
                _gjjjs = salary;
        }

        private SBRate _sb;

        public SBRate SB
        {
            get { return _sb; }
            set { _sb = value; }
        }

        private decimal _sbjs;

        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal SBJS
        {
            get { return _sbjs; }
            set { _sbjs = value; }
        }

        private decimal _gjjjs;

        /// <summary>
        /// 公积金基数
        /// </summary>
        public decimal GJJJS
        {
            get { return _gjjjs; }
            set { _gjjjs = value; }
        }

        private decimal _taxRate;

        private decimal _deduct;

        /// <summary>
        /// 根据工资计算个人养老保险缴费金额
        /// </summary>
        /// <returns>个人养老保险缴费金额</returns>
        public decimal GetPerYL()
        {
            return Math.Round(_sbjs * _sb.PerYLRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业养老保险缴费金额
        /// </summary>
        /// <returns>企业养老保险缴费金额</returns>
        public decimal GetComYL()
        {
            return Math.Round(_sbjs * _sb.ComYLRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算个人医疗保险缴费金额
        /// </summary>
        /// <returns>个人医疗保险缴费金额</returns>
        public decimal GetPerYiL()
        {
            return Math.Round(_sbjs * _sb.PerYiLRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业医疗保险缴费金额
        /// </summary>
        /// <returns>企业医疗保险缴费金额</returns>
        public decimal GetComYiL()
        {
            return Math.Round(_sbjs * _sb.ComYiLRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算个人失业保险缴费金额
        /// </summary>
        /// <returns>个人失业保险缴费金额</returns>
        public decimal GetPerShiYe()
        {
            return Math.Round(_sbjs * _sb.PerShiYeRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业失业保险缴费金额
        /// </summary>
        /// <returns>企业失业保险缴费金额</returns>
        public decimal GetComShiYe()
        {
            return Math.Round(_sbjs * _sb.ComShiYeRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算个人工伤保险缴费金额
        /// </summary>
        /// <returns>个人工伤保险缴费金额</returns>
        public decimal GetPerGS()
        {
            return Math.Round(_sbjs * _sb.PerGSRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业工伤保险缴费金额
        /// </summary>
        /// <returns>企业工伤保险缴费金额</returns>
        public decimal GetComGS()
        {
            return Math.Round(_sbjs * _sb.ComGSRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算个人生育保险缴费金额
        /// </summary>
        /// <returns>个人生育保险缴费金额</returns>
        public decimal GetPerSY()
        {
            return Math.Round(_sbjs * _sb.PerSYRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业生育保险缴费金额
        /// </summary>
        /// <returns>企业生育保险缴费金额</returns>
        public decimal GetComSY()
        {
            return Math.Round(_sbjs * _sb.ComSYRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算个人公积金缴费金额
        /// </summary>
        /// <returns>个人公积金缴费金额</returns>
        public decimal GetPerGJJ()
        {
            return Math.Round(_gjjjs * _sb.PerGJJRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据工资计算企业公积金缴费金额
        /// </summary>
        /// <returns>企业公积金缴费金额</returns>
        public decimal GetComGJJ()
        {
            return Math.Round(_gjjjs * _sb.ComGJJRate * PERCENTRATE, DIGIT);
        }

        /// <summary>
        /// 根据应纳税额计算个税
        /// </summary>
        /// <param name="taxableamount">应纳税额</param>
        /// <returns>个税</returns>
        public decimal GetPerTax(decimal taxableamount)
        {
            GetTaxRate(taxableamount);
            return Math.Round(taxableamount * _taxRate * PERCENTRATE - _deduct, DIGIT);
        }

        /// <summary>
        /// 根据应纳税额获取相应的税率
        /// </summary>
        /// <param name="taxableamount">应纳税额</param>
        /// <returns>税率</returns>
        private void GetTaxRate(decimal taxableamount)
        {
            if (taxableamount <= 1500)
            {
                _taxRate = 3; _deduct = 0;
            }
            else if (taxableamount > 1500 && taxableamount <= 4500)
            {
                _taxRate = 10; _deduct = 105;
            }
            else if (taxableamount > 4500 && taxableamount <= 9000)
            {
                _taxRate = 20; _deduct = 555;
            }
            else if (taxableamount > 9000 && taxableamount <= 35000)
            {
                _taxRate = 25; _deduct = 1005;
            }
            else if (taxableamount > 35000 && taxableamount <= 55000)
            {
                _taxRate = 30; _deduct = 2755;
            }
            else if (taxableamount > 55000 && taxableamount <= 80000)
            {
                _taxRate = 35; _deduct = 5505;
            }
            else
            {
                _taxRate = 45; _deduct = 13505;
            }
        }
    }

    /// <summary>
    /// 交税人
    /// </summary>
    public class Person:BindableBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="salary">税前工资</param>
        /// <param name="sb">社保比例类</param>
        /// <param name="yearbonus">年终奖</param>
        public Person(decimal salary, SBRate sb,decimal yearbonus=0)
        {
            var sc = new SalaryCalculator(salary, sb);
            _sbjs = sc.SBJS;
            _gjjjs = sc.GJJJS;
            _perYL = sc.GetPerYL();
            _perYiL = sc.GetPerYiL();
            _perSY = sc.GetPerSY();
            _perShiYe = sc.GetPerShiYe();
            _perGS = sc.GetPerGS();
            _perGJJ = sc.GetPerGJJ();
            _comGJJ = sc.GetComGJJ();
            _comGS = sc.GetComGS();
            _comShiYe = sc.GetComShiYe();
            _comSY = sc.GetComSY();
            _comYiL = sc.GetComYiL();
            _comYL = sc.GetComYL();
            _perSum = _perYL + _perYiL + _perSY + _perShiYe + _perGS + _perGJJ;
            _comSum = _comYL + _comYiL + _comSY + _comShiYe + _comGS + _comGJJ;
            _comTotal = _comSum + salary;
            _taxableAmount = salary - _perSum - 3500;
            if (_taxableAmount < 0)
                _taxableAmount = 0;
            _perTax = _taxableAmount > 0 ? sc.GetPerTax(_taxableAmount) : 0;
            _salaryAfterTax = salary - _perSum - _perTax;
        }
       
        private decimal _perYL;

        /// <summary>
        /// 个人养老保险缴费金额
        /// </summary>
        public decimal PerYL
        {
            get { 
                return _perYL; }
            set {               
                _perYL = value;
                base.SetProperty(ref _perYL, value, "PerYL");
            }
        }

        private decimal _comYL;

        /// <summary>
        /// 企业养老保险缴费金额
        /// </summary>
        public decimal ComYL
        {
            get { return _comYL; }
            set { _comYL = value; }
        }

        private decimal _perYiL;

        /// <summary>
        /// 个人医疗保险缴费金额
        /// </summary>
        public decimal PerYiL
        {
            get { return _perYiL; }
            set { _perYiL = value; }
        }

        private decimal _comYiL;

        /// <summary>
        /// 企业医疗保险缴费金额
        /// </summary>
        public decimal ComYiL
        {
            get { return _comYiL; }
            set { _comYiL = value; }
        }

        private decimal _perShiYe;

        /// <summary>
        /// 个人失业保险缴费金额
        /// </summary>
        public decimal PerShiYe
        {
            get { return _perShiYe; }
            set { _perShiYe = value; }
        }

        private decimal _comShiYe;

        /// <summary>
        /// 企业失业保险缴费金额
        /// </summary>
        public decimal ComShiYe
        {
            get { return _comShiYe; }
            set { _comShiYe = value; }
        }

        private decimal _perGS;

        /// <summary>
        /// 个人工伤保险缴费金额
        /// </summary>
        public decimal PerGS
        {
            get { return _perGS; }
            set { _perGS = value; }
        }

        private decimal _comGS;

        /// <summary>
        /// 企业工伤保险缴费金额
        /// </summary>
        public decimal ComGS
        {
            get { return _comGS; }
            set { _comGS = value; }
        }

        private decimal _perSY;

        /// <summary>
        /// 个人生育保险缴费金额
        /// </summary>
        public decimal PerSY
        {
            get { return _perSY; }
            set { _perSY = value; }
        }

        private decimal _comSY;

        /// <summary>
        /// 企业生育保险缴费金额
        /// </summary>
        public decimal ComSY
        {
            get { return _comSY; }
            set { _comSY = value; }
        }

        private decimal _perGJJ;

        /// <summary>
        /// 个人公积金缴费金额
        /// </summary>
        public decimal PerGJJ
        {
            get { return _perGJJ; }
            set { _perGJJ = value; }
        }

        private decimal _comGJJ;

        /// <summary>
        /// 企业公积金缴费金额
        /// </summary>
        public decimal ComGJJ
        {
            get { return _comGJJ; }
            set { _comGJJ = value; }
        }

        private decimal _perSum;

        /// <summary>
        /// 个人缴费合计
        /// </summary>
        public decimal PerSum
        {
            get { return _perSum; }
            set { _perSum = value; }
        }

        private decimal _comSum;

        /// <summary>
        /// 单位缴费合计
        /// </summary>
        public decimal ComSum
        {
            get { return _comSum; }
            set { _comSum = value; }
        }

        private decimal _comTotal;

        /// <summary>
        /// 单位支出总计
        /// </summary>
        public decimal ComTotal
        {
            get { return _comTotal; }
            set { _comTotal = value; }
        }

        private decimal _perTax;

        /// <summary>
        /// 个税
        /// </summary>
        public decimal PerTax
        {
            get { return _perTax; }
            set { _perTax = value; }
        }

        private decimal _taxableAmount;

        /// <summary>
        /// 应纳税额总计
        /// </summary>
        public decimal TaxableAmount
        {
            get { return _taxableAmount; }
            set { _taxableAmount = value; }
        }

        private decimal _salaryAfterTax;

        /// <summary>
        /// 税后工资
        /// </summary>
        public decimal SalaryAfterTax
        {
            get { return _salaryAfterTax; }
            set { _salaryAfterTax = value; }
        }

        private decimal _sbjs;

        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal SBJS
        {
            get { return _sbjs; }
            set { _sbjs = value; }
        }

        private decimal _gjjjs;

        /// <summary>
        /// 公积金基数
        /// </summary>
        public decimal GJJJS
        {
            get { return _gjjjs; }
            set { _gjjjs = value; }
        }

        private decimal _yearBonusAfterTax;

        /// <summary>
        /// 税后年终奖
        /// </summary>
        public decimal YearBonusAfterTax
        {
            get { return _yearBonusAfterTax; }
            set { _yearBonusAfterTax = value; }
        }
    }
}
