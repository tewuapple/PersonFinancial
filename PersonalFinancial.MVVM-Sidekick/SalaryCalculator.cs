using MVVMSidekick.ViewModels;
using PersonalFinancial.MVVM_Sidekick.Models;
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
    public class Person : BindableBase<Person>
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
            SBJS = sc.SBJS;
            GJJJS = sc.GJJJS;
            PerYL = sc.GetPerYL();
            PerYiL = sc.GetPerYiL();
            PerSY = sc.GetPerSY();
            PerShiYe = sc.GetPerShiYe();
            PerGS = sc.GetPerGS();
            PerGJJ = sc.GetPerGJJ();
            ComGJJ = sc.GetComGJJ();
            ComGS = sc.GetComGS();
            ComShiYe = sc.GetComShiYe();
            ComSY = sc.GetComSY();
            ComYiL = sc.GetComYiL();
            ComYL = sc.GetComYL();
            PerSum = PerYL + PerYiL + PerSY + PerShiYe + PerGS + PerGJJ;
            ComSum = ComYL + ComYiL + ComSY + ComShiYe + ComGS + ComGJJ;
            ComTotal = ComSum + salary;
            TaxableAmount = salary - PerSum - 3500;
            if (TaxableAmount < 0)
                TaxableAmount = 0;
            PerTax = TaxableAmount > 0 ? sc.GetPerTax(TaxableAmount) : 0;
            SalaryAfterTax = salary - PerSum - PerTax;
        }
       
        //private decimal _perYL;

        /// <summary>
        /// 个人养老保险缴费金额
        /// </summary>
        //public decimal PerYL
        //{
        //    get { 
        //        return _perYL; }
        //    set {               
        //        _perYL = value;
        //        base.SetProperty(ref _perYL, value, "PerYL");
        //    }
        //}
        
        public decimal PerYL
        {
            get { return _PerYLLocator(this).Value; }
            set { _PerYLLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerYL Setup
        protected Property<decimal> _PerYL = new Property<decimal> { LocatorFunc = _PerYLLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerYLLocator = RegisterContainerLocator<decimal>("PerYL", model => model.Initialize("PerYL", ref model._PerYL, ref _PerYLLocator, _PerYLDefaultValueFactory));
        static Func<decimal> _PerYLDefaultValueFactory = null;
        #endregion

        //private decimal _comYL;

        /// <summary>
        /// 企业养老保险缴费金额
        /// </summary>
        //public decimal ComYL
        //{
        //    get { return _comYL; }
        //    set { _comYL = value; }
        //}
        
        public decimal ComYL
        {
            get { return _ComYLLocator(this).Value; }
            set { _ComYLLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComYL Setup
        protected Property<decimal> _ComYL = new Property<decimal> { LocatorFunc = _ComYLLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComYLLocator = RegisterContainerLocator<decimal>("ComYL", model => model.Initialize("ComYL", ref model._ComYL, ref _ComYLLocator, _ComYLDefaultValueFactory));
        static Func<decimal> _ComYLDefaultValueFactory = null;
        #endregion


       // private decimal _perYiL;

        /// <summary>
        /// 个人医疗保险缴费金额
        /// </summary>
        //public decimal PerYiL
        //{
        //    get { return _perYiL; }
        //    set { _perYiL = value; }
        //}
        
        public decimal PerYiL
        {
            get { return _PerYiLLocator(this).Value; }
            set { _PerYiLLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerYiL Setup
        protected Property<decimal> _PerYiL = new Property<decimal> { LocatorFunc = _PerYiLLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerYiLLocator = RegisterContainerLocator<decimal>("PerYiL", model => model.Initialize("PerYiL", ref model._PerYiL, ref _PerYiLLocator, _PerYiLDefaultValueFactory));
        static Func<decimal> _PerYiLDefaultValueFactory = null;
        #endregion

        //private decimal _comYiL;

        /// <summary>
        /// 企业医疗保险缴费金额
        /// </summary>
        //public decimal ComYiL
        //{
        //    get { return _comYiL; }
        //    set { _comYiL = value; }
        //}
        
        public decimal ComYiL
        {
            get { return _ComYiLLocator(this).Value; }
            set { _ComYiLLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComYiL Setup
        protected Property<decimal> _ComYiL = new Property<decimal> { LocatorFunc = _ComYiLLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComYiLLocator = RegisterContainerLocator<decimal>("ComYiL", model => model.Initialize("ComYiL", ref model._ComYiL, ref _ComYiLLocator, _ComYiLDefaultValueFactory));
        static Func<decimal> _ComYiLDefaultValueFactory = null;
        #endregion

        //private decimal _perShiYe;

        /// <summary>
        /// 个人失业保险缴费金额
        /// </summary>
        //public decimal PerShiYe
        //{
        //    get { return _perShiYe; }
        //    set { _perShiYe = value; }
        //}
        
        public decimal  PerShiYe
        {
            get { return _PerShiYeLocator(this).Value; }
            set { _PerShiYeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  PerShiYe Setup
        protected Property<decimal > _PerShiYe = new Property<decimal > { LocatorFunc = _PerShiYeLocator };
        static Func<BindableBase, ValueContainer<decimal >> _PerShiYeLocator = RegisterContainerLocator<decimal >("PerShiYe", model => model.Initialize("PerShiYe", ref model._PerShiYe, ref _PerShiYeLocator, _PerShiYeDefaultValueFactory));
        static Func<decimal > _PerShiYeDefaultValueFactory = null;
        #endregion

        //private decimal _comShiYe;

        /// <summary>
        /// 企业失业保险缴费金额
        /// </summary>
        //public decimal ComShiYe
        //{
        //    get { return _comShiYe; }
        //    set { _comShiYe = value; }
        //}
        
        public decimal ComShiYe
        {
            get { return _ComShiYeLocator(this).Value; }
            set { _ComShiYeLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComShiYe Setup
        protected Property<decimal> _ComShiYe = new Property<decimal> { LocatorFunc = _ComShiYeLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComShiYeLocator = RegisterContainerLocator<decimal>("ComShiYe", model => model.Initialize("ComShiYe", ref model._ComShiYe, ref _ComShiYeLocator, _ComShiYeDefaultValueFactory));
        static Func<decimal> _ComShiYeDefaultValueFactory = null;
        #endregion

        //private decimal _perGS;

        /// <summary>
        /// 个人工伤保险缴费金额
        /// </summary>
        //public decimal PerGS
        //{
        //    get { return _perGS; }
        //    set { _perGS = value; }
        //}

        
        public decimal PerGS
        {
            get { return _PerGSLocator(this).Value; }
            set { _PerGSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerGS Setup
        protected Property<decimal> _PerGS = new Property<decimal> { LocatorFunc = _PerGSLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerGSLocator = RegisterContainerLocator<decimal>("PerGS", model => model.Initialize("PerGS", ref model._PerGS, ref _PerGSLocator, _PerGSDefaultValueFactory));
        static Func<decimal> _PerGSDefaultValueFactory = null;
        #endregion


        //private decimal _comGS;

        /// <summary>
        /// 企业工伤保险缴费金额
        /// </summary>
        //public decimal ComGS
        //{
        //    get { return _comGS; }
        //    set { _comGS = value; }
        //}

        
        public decimal  ComGS
        {
            get { return _ComGSLocator(this).Value; }
            set { _ComGSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  ComGS Setup
        protected Property<decimal > _ComGS = new Property<decimal > { LocatorFunc = _ComGSLocator };
        static Func<BindableBase, ValueContainer<decimal >> _ComGSLocator = RegisterContainerLocator<decimal >("ComGS", model => model.Initialize("ComGS", ref model._ComGS, ref _ComGSLocator, _ComGSDefaultValueFactory));
        static Func<decimal > _ComGSDefaultValueFactory = null;
        #endregion


        //private decimal _perSY;

        /// <summary>
        /// 个人生育保险缴费金额
        /// </summary>
        //public decimal PerSY
        //{
        //    get { return _perSY; }
        //    set { _perSY = value; }
        //}
        
        public decimal  PerSY
        {
            get { return _PerSYLocator(this).Value; }
            set { _PerSYLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  PerSY Setup
        protected Property<decimal > _PerSY = new Property<decimal > { LocatorFunc = _PerSYLocator };
        static Func<BindableBase, ValueContainer<decimal >> _PerSYLocator = RegisterContainerLocator<decimal >("PerSY", model => model.Initialize("PerSY", ref model._PerSY, ref _PerSYLocator, _PerSYDefaultValueFactory));
        static Func<decimal > _PerSYDefaultValueFactory = null;
        #endregion



        //private decimal _comSY;

        /// <summary>
        /// 企业生育保险缴费金额
        /// </summary>
        //public decimal ComSY
        //{
        //    get { return _comSY; }
        //    set { _comSY = value; }
        //}
        
        public decimal ComSY
        {
            get { return _ComSYLocator(this).Value; }
            set { _ComSYLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComSY Setup
        protected Property<decimal> _ComSY = new Property<decimal> { LocatorFunc = _ComSYLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComSYLocator = RegisterContainerLocator<decimal>("ComSY", model => model.Initialize("ComSY", ref model._ComSY, ref _ComSYLocator, _ComSYDefaultValueFactory));
        static Func<decimal> _ComSYDefaultValueFactory = null;
        #endregion



        //private decimal _perGJJ;

        /// <summary>
        /// 个人公积金缴费金额
        /// </summary>
        //public decimal PerGJJ
        //{
        //    get { return _perGJJ; }
        //    set { _perGJJ = value; }
        //}
        
        public decimal PerGJJ
        {
            get { return _PerGJJLocator(this).Value; }
            set { _PerGJJLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerGJJ Setup
        protected Property<decimal> _PerGJJ = new Property<decimal> { LocatorFunc = _PerGJJLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerGJJLocator = RegisterContainerLocator<decimal>("PerGJJ", model => model.Initialize("PerGJJ", ref model._PerGJJ, ref _PerGJJLocator, _PerGJJDefaultValueFactory));
        static Func<decimal> _PerGJJDefaultValueFactory = null;
        #endregion




        //private decimal _comGJJ;

        /// <summary>
        /// 企业公积金缴费金额
        /// </summary>
        //public decimal ComGJJ
        //{
        //    get { return _comGJJ; }
        //    set { _comGJJ = value; }
        //}
        
        public decimal ComGJJ
        {
            get { return _ComGJJLocator(this).Value; }
            set { _ComGJJLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComGJJ Setup
        protected Property<decimal> _ComGJJ = new Property<decimal> { LocatorFunc = _ComGJJLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComGJJLocator = RegisterContainerLocator<decimal>("ComGJJ", model => model.Initialize("ComGJJ", ref model._ComGJJ, ref _ComGJJLocator, _ComGJJDefaultValueFactory));
        static Func<decimal> _ComGJJDefaultValueFactory = null;
        #endregion

        //private decimal _perSum;

        /// <summary>
        /// 个人缴费合计
        /// </summary>
        //public decimal PerSum
        //{
        //    get { return _perSum; }
        //    set { _perSum = value; }
        //}
        
        public decimal PerSum
        {
            get { return _PerSumLocator(this).Value; }
            set { _PerSumLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerSum Setup
        protected Property<decimal> _PerSum = new Property<decimal> { LocatorFunc = _PerSumLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerSumLocator = RegisterContainerLocator<decimal>("PerSum", model => model.Initialize("PerSum", ref model._PerSum, ref _PerSumLocator, _PerSumDefaultValueFactory));
        static Func<decimal> _PerSumDefaultValueFactory = null;
        #endregion

        //private decimal _comSum;

        /// <summary>
        /// 单位缴费合计
        /// </summary>
        //public decimal ComSum
        //{
        //    get { return _comSum; }
        //    set { _comSum = value; }
        //}

        
        public decimal ComSum
        {
            get { return _ComSumLocator(this).Value; }
            set { _ComSumLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComSum Setup
        protected Property<decimal> _ComSum = new Property<decimal> { LocatorFunc = _ComSumLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComSumLocator = RegisterContainerLocator<decimal>("ComSum", model => model.Initialize("ComSum", ref model._ComSum, ref _ComSumLocator, _ComSumDefaultValueFactory));
        static Func<decimal> _ComSumDefaultValueFactory = null;
        #endregion




        //private decimal _comTotal;

        /// <summary>
        /// 单位支出总计
        /// </summary>
        //public decimal ComTotal
        //{
        //    get { return _comTotal; }
        //    set { _comTotal = value; }
        //}
        
        public decimal ComTotal
        {
            get { return _ComTotalLocator(this).Value; }
            set { _ComTotalLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComTotal Setup
        protected Property<decimal> _ComTotal = new Property<decimal> { LocatorFunc = _ComTotalLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComTotalLocator = RegisterContainerLocator<decimal>("ComTotal", model => model.Initialize("ComTotal", ref model._ComTotal, ref _ComTotalLocator, _ComTotalDefaultValueFactory));
        static Func<decimal> _ComTotalDefaultValueFactory = null;
        #endregion



        //private decimal _perTax;

        /// <summary>
        /// 个税
        /// </summary>
        //public decimal PerTax
        //{
        //    get { return _perTax; }
        //    set { _perTax = value; }
        //}
        
        public decimal PerTax
        {
            get { return _PerTaxLocator(this).Value; }
            set { _PerTaxLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerTax Setup
        protected Property<decimal> _PerTax = new Property<decimal> { LocatorFunc = _PerTaxLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerTaxLocator = RegisterContainerLocator<decimal>("PerTax", model => model.Initialize("PerTax", ref model._PerTax, ref _PerTaxLocator, _PerTaxDefaultValueFactory));
        static Func<decimal> _PerTaxDefaultValueFactory = null;
        #endregion


        //private decimal _taxableAmount;

        /// <summary>
        /// 应纳税额总计
        /// </summary>
        //public decimal TaxableAmount
        //{
        //    get { return _taxableAmount; }
        //    set { _taxableAmount = value; }
        //}
        
        public decimal TaxableAmount
        {
            get { return _TaxableAmountLocator(this).Value; }
            set { _TaxableAmountLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal TaxableAmount Setup
        protected Property<decimal> _TaxableAmount = new Property<decimal> { LocatorFunc = _TaxableAmountLocator };
        static Func<BindableBase, ValueContainer<decimal>> _TaxableAmountLocator = RegisterContainerLocator<decimal>("TaxableAmount", model => model.Initialize("TaxableAmount", ref model._TaxableAmount, ref _TaxableAmountLocator, _TaxableAmountDefaultValueFactory));
        static Func<decimal> _TaxableAmountDefaultValueFactory = null;
        #endregion

        //private decimal _salaryAfterTax;

        /// <summary>
        /// 税后工资
        /// </summary>
        //public decimal SalaryAfterTax
        //{
        //    get { return _salaryAfterTax; }
        //    set { _salaryAfterTax = value; }
        //}
        
        public decimal SalaryAfterTax
        {
            get { return _SalaryAfterTaxLocator(this).Value; }
            set { _SalaryAfterTaxLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal SalaryAfterTax Setup
        protected Property<decimal> _SalaryAfterTax = new Property<decimal> { LocatorFunc = _SalaryAfterTaxLocator };
        static Func<BindableBase, ValueContainer<decimal>> _SalaryAfterTaxLocator = RegisterContainerLocator<decimal>("SalaryAfterTax", model => model.Initialize("SalaryAfterTax", ref model._SalaryAfterTax, ref _SalaryAfterTaxLocator, _SalaryAfterTaxDefaultValueFactory));
        static Func<decimal> _SalaryAfterTaxDefaultValueFactory = null;
        #endregion


        //private decimal _sbjs;

        /// <summary>
        /// 社保基数
        /// </summary>
        //public decimal SBJS
        //{
        //    get { return _sbjs; }
        //    set { _sbjs = value; }
        //}
        
        public decimal SBJS
        {
            get { return _SBJSLocator(this).Value; }
            set { _SBJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal SBJS Setup
        protected Property<decimal> _SBJS = new Property<decimal> { LocatorFunc = _SBJSLocator };
        static Func<BindableBase, ValueContainer<decimal>> _SBJSLocator = RegisterContainerLocator<decimal>("SBJS", model => model.Initialize("SBJS", ref model._SBJS, ref _SBJSLocator, _SBJSDefaultValueFactory));
        static Func<decimal> _SBJSDefaultValueFactory = null;
        #endregion


        //private decimal _gjjjs;

        /// <summary>
        /// 公积金基数
        /// </summary>
        //public decimal GJJJS
        //{
        //    get { return _gjjjs; }
        //    set { _gjjjs = value; }
        //}
        
        public decimal GJJJS
        {
            get { return _GJJJSLocator(this).Value; }
            set { _GJJJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal GJJJS Setup
        protected Property<decimal> _GJJJS = new Property<decimal> { LocatorFunc = _GJJJSLocator };
        static Func<BindableBase, ValueContainer<decimal>> _GJJJSLocator = RegisterContainerLocator<decimal>("GJJJS", model => model.Initialize("GJJJS", ref model._GJJJS, ref _GJJJSLocator, _GJJJSDefaultValueFactory));
        static Func<decimal> _GJJJSDefaultValueFactory = null;
        #endregion


        //private decimal _yearBonusAfterTax;

        /// <summary>
        /// 税后年终奖
        /// </summary>
        //public decimal YearBonusAfterTax
        //{
        //    get { return _yearBonusAfterTax; }
        //    set { _yearBonusAfterTax = value; }
        //}
        
        public decimal YearBonusAfterTax
        {
            get { return _YearBonusAfterTaxLocator(this).Value; }
            set { _YearBonusAfterTaxLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal YearBonusAfterTax Setup
        protected Property<decimal> _YearBonusAfterTax = new Property<decimal> { LocatorFunc = _YearBonusAfterTaxLocator };
        static Func<BindableBase, ValueContainer<decimal>> _YearBonusAfterTaxLocator = RegisterContainerLocator<decimal>("YearBonusAfterTax", model => model.Initialize("YearBonusAfterTax", ref model._YearBonusAfterTax, ref _YearBonusAfterTaxLocator, _YearBonusAfterTaxDefaultValueFactory));
        static Func<decimal> _YearBonusAfterTaxDefaultValueFactory = null;
        #endregion

    }
}
