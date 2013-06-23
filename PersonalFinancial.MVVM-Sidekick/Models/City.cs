using MVVMSidekick.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancial.MVVM_Sidekick.Models
{
    
    //[DataContract(IsReference=true) ] //if you want
    public class City : BindableBase<City>
    {
        public City()
        {
            // Use propery to init value here:
            if (IsInDesignMode)
            {
                //Add design time demo data init here. These will not execute in runtime.
            }


        }

        //Use propvm + tab +tab  to create a new property of bindable here:
        
        public int ID
        {
            get { return _IDLocator(this).Value; }
            set { _IDLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int ID Setup
        protected Property<int> _ID = new Property<int> { LocatorFunc = _IDLocator };
        static Func<BindableBase, ValueContainer<int>> _IDLocator = RegisterContainerLocator<int>("ID", model => model.Initialize("ID", ref model._ID, ref _IDLocator, _IDDefaultValueFactory));
        static Func<int> _IDDefaultValueFactory = null;
        #endregion


        
        public String Name
        {
            get { return _NameLocator(this).Value; }
            set { _NameLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property String Name Setup
        protected Property<String> _Name = new Property<String> { LocatorFunc = _NameLocator };
        static Func<BindableBase, ValueContainer<String>> _NameLocator = RegisterContainerLocator<String>("Name", model => model.Initialize("Name", ref model._Name, ref _NameLocator, _NameDefaultValueFactory));
        static Func<String> _NameDefaultValueFactory = null;
        #endregion


        
        public SBRate Sr
        {
            get { return _SrLocator(this).Value; }
            set { _SrLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property SBRate Sr Setup
        protected Property<SBRate> _Sr = new Property<SBRate> { LocatorFunc = _SrLocator };
        static Func<BindableBase, ValueContainer<SBRate>> _SrLocator = RegisterContainerLocator<SBRate>("Sr", model => model.Initialize("Sr", ref model._Sr, ref _SrLocator, _SrDefaultValueFactory));
        static Func<SBRate> _SrDefaultValueFactory = null;
        #endregion




    }

    
    //[DataContract(IsReference=true) ] //if you want
    public class SBRate : BindableBase<SBRate>
    {
        public SBRate()
        {
            // Use propery to init value here:
            if (IsInDesignMode)
            {
                //Add design time demo data init here. These will not execute in runtime.
            }


        }

        //Use propvm + tab +tab  to create a new property of bindable here:

         /// <summary>
        /// 个人养老保险缴费比例
        /// </summary>
        
      //  public decimal PerYLRate { get; set; }
        public decimal PerYLRate
        {
            get { return _PerYLRateLocator(this).Value; }
            set { _PerYLRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerYLRate Setup
        protected Property<decimal> _PerYLRate = new Property<decimal> { LocatorFunc = _PerYLRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerYLRateLocator = RegisterContainerLocator<decimal>("PerYLRate", model => model.Initialize("PerYLRate", ref model._PerYLRate, ref _PerYLRateLocator, _PerYLRateDefaultValueFactory));
        static Func<decimal> _PerYLRateDefaultValueFactory = null;
        #endregion


        /// <summary>
        /// 企业养老保险缴费比例
        /// </summary>
       // public decimal ComYLRate { get; set; }

        
        public decimal  ComYLRate
        {
            get { return _ComYLRateLocator(this).Value; }
            set { _ComYLRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  ComYLRate Setup
        protected Property<decimal > _ComYLRate = new Property<decimal > { LocatorFunc = _ComYLRateLocator };
        static Func<BindableBase, ValueContainer<decimal >> _ComYLRateLocator = RegisterContainerLocator<decimal >("ComYLRate", model => model.Initialize("ComYLRate", ref model._ComYLRate, ref _ComYLRateLocator, _ComYLRateDefaultValueFactory));
        static Func<decimal > _ComYLRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 个人医疗缴费比例
        /// </summary>
        //public decimal PerYiLRate { get; set; }
        
        public decimal  PerYiLRate
        {
            get { return _PerYiLRateLocator(this).Value; }
            set { _PerYiLRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  PerYiLRate Setup
        protected Property<decimal > _PerYiLRate = new Property<decimal > { LocatorFunc = _PerYiLRateLocator };
        static Func<BindableBase, ValueContainer<decimal >> _PerYiLRateLocator = RegisterContainerLocator<decimal >("PerYiLRate", model => model.Initialize("PerYiLRate", ref model._PerYiLRate, ref _PerYiLRateLocator, _PerYiLRateDefaultValueFactory));
        static Func<decimal > _PerYiLRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 企业医疗缴费比例
        /// </summary>
        //public decimal ComYiLRate { get; set; }
        
        public decimal  ComYiLRate
        {
            get { return _ComYiLRateLocator(this).Value; }
            set { _ComYiLRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  ComYiLRate Setup
        protected Property<decimal > _ComYiLRate = new Property<decimal > { LocatorFunc = _ComYiLRateLocator };
        static Func<BindableBase, ValueContainer<decimal >> _ComYiLRateLocator = RegisterContainerLocator<decimal >("ComYiLRate", model => model.Initialize("ComYiLRate", ref model._ComYiLRate, ref _ComYiLRateLocator, _ComYiLRateDefaultValueFactory));
        static Func<decimal > _ComYiLRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 个人失业缴费比例
        /// </summary>
        //public decimal PerShiYeRate { get; set; }
        
        public decimal PerShiYeRate
        {
            get { return _PerShiYeRateLocator(this).Value; }
            set { _PerShiYeRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerShiYeRate Setup
        protected Property<decimal> _PerShiYeRate = new Property<decimal> { LocatorFunc = _PerShiYeRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerShiYeRateLocator = RegisterContainerLocator<decimal>("PerShiYeRate", model => model.Initialize("PerShiYeRate", ref model._PerShiYeRate, ref _PerShiYeRateLocator, _PerShiYeRateDefaultValueFactory));
        static Func<decimal> _PerShiYeRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 企业失业缴费比例
        /// </summary>
        // decimal ComShiYeRate { get; set; }
        
        public decimal ComShiYeRate
        {
            get { return _ComShiYeRateLocator(this).Value; }
            set { _ComShiYeRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal  ComShiYeRate Setup
        protected Property<decimal > _ComShiYeRate = new Property<decimal > { LocatorFunc = _ComShiYeRateLocator };
        static Func<BindableBase, ValueContainer<decimal >> _ComShiYeRateLocator = RegisterContainerLocator<decimal >("ComShiYeRate", model => model.Initialize("ComShiYeRate", ref model._ComShiYeRate, ref _ComShiYeRateLocator, _ComShiYeRateDefaultValueFactory));
        static Func<decimal > _ComShiYeRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 个人工伤缴费比例
        /// </summary>
     //   public decimal PerGSRate { get; set; }
        
        public decimal PerGSRate
        {
            get { return _PerGSRateLocator(this).Value; }
            set { _PerGSRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerGSRate Setup
        protected Property<decimal> _PerGSRate = new Property<decimal> { LocatorFunc = _PerGSRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerGSRateLocator = RegisterContainerLocator<decimal>("PerGSRate", model => model.Initialize("PerGSRate", ref model._PerGSRate, ref _PerGSRateLocator, _PerGSRateDefaultValueFactory));
        static Func<decimal> _PerGSRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 企业工伤缴费比例
        /// </summary>
       // public decimal ComGSRate { get; set; }
        
        public decimal ComGSRate
        {
            get { return _ComGSRateLocator(this).Value; }
            set { _ComGSRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComGSRate Setup
        protected Property<decimal> _ComGSRate = new Property<decimal> { LocatorFunc = _ComGSRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComGSRateLocator = RegisterContainerLocator<decimal>("ComGSRate", model => model.Initialize("ComGSRate", ref model._ComGSRate, ref _ComGSRateLocator, _ComGSRateDefaultValueFactory));
        static Func<decimal> _ComGSRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 个人生育缴费比例
        /// </summary>
       // public decimal PerSYRate { get; set; }
        
        public decimal PerSYRate
        {
            get { return _PerSYRateLocator(this).Value; }
            set { _PerSYRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerSYRate Setup
        protected Property<decimal> _PerSYRate = new Property<decimal> { LocatorFunc = _PerSYRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerSYRateLocator = RegisterContainerLocator<decimal>("PerSYRate", model => model.Initialize("PerSYRate", ref model._PerSYRate, ref _PerSYRateLocator, _PerSYRateDefaultValueFactory));
        static Func<decimal> _PerSYRateDefaultValueFactory = null;
        #endregion  

        /// <summary>
        /// 企业生育缴费比例
        /// </summary>
        //public decimal ComSYRate { get; set; }
        
        public decimal ComSYRate
        {
            get { return _ComSYRateLocator(this).Value; }
            set { _ComSYRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComSYRate Setup
        protected Property<decimal> _ComSYRate = new Property<decimal> { LocatorFunc = _ComSYRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComSYRateLocator = RegisterContainerLocator<decimal>("ComSYRate", model => model.Initialize("ComSYRate", ref model._ComSYRate, ref _ComSYRateLocator, _ComSYRateDefaultValueFactory));
        static Func<decimal> _ComSYRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 个人公积金缴费比例
        /// </summary>
        //public decimal PerGJJRate { get; set; }
        
        public decimal PerGJJRate
        {
            get { return _PerGJJRateLocator(this).Value; }
            set { _PerGJJRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal PerGJJRate Setup
        protected Property<decimal> _PerGJJRate = new Property<decimal> { LocatorFunc = _PerGJJRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _PerGJJRateLocator = RegisterContainerLocator<decimal>("PerGJJRate", model => model.Initialize("PerGJJRate", ref model._PerGJJRate, ref _PerGJJRateLocator, _PerGJJRateDefaultValueFactory));
        static Func<decimal> _PerGJJRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 企业公积金缴费比例
        /// </summary>
        //public decimal ComGJJRate { get; set; }
        
        public decimal ComGJJRate
        {
            get { return _ComGJJRateLocator(this).Value; }
            set { _ComGJJRateLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property decimal ComGJJRate Setup
        protected Property<decimal> _ComGJJRate = new Property<decimal> { LocatorFunc = _ComGJJRateLocator };
        static Func<BindableBase, ValueContainer<decimal>> _ComGJJRateLocator = RegisterContainerLocator<decimal>("ComGJJRate", model => model.Initialize("ComGJJRate", ref model._ComGJJRate, ref _ComGJJRateLocator, _ComGJJRateDefaultValueFactory));
        static Func<decimal> _ComGJJRateDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 社保基数最低值
        /// </summary>
        //public int MinSBJS { get; set; }
        
        public int MinSBJS
        {
            get { return _MinSBJSLocator(this).Value; }
            set { _MinSBJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int MinSBJS Setup
        protected Property<int> _MinSBJS = new Property<int> { LocatorFunc = _MinSBJSLocator };
        static Func<BindableBase, ValueContainer<int>> _MinSBJSLocator = RegisterContainerLocator<int>("MinSBJS", model => model.Initialize("MinSBJS", ref model._MinSBJS, ref _MinSBJSLocator, _MinSBJSDefaultValueFactory));
        static Func<int> _MinSBJSDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 社保基数最高值
        /// </summary>
        //public int MaxSBJS { get; set; }
        
        public int MaxSBJS
        {
            get { return _MaxSBJSLocator(this).Value; }
            set { _MaxSBJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int MaxSBJS Setup
        protected Property<int> _MaxSBJS = new Property<int> { LocatorFunc = _MaxSBJSLocator };
        static Func<BindableBase, ValueContainer<int>> _MaxSBJSLocator = RegisterContainerLocator<int>("MaxSBJS", model => model.Initialize("MaxSBJS", ref model._MaxSBJS, ref _MaxSBJSLocator, _MaxSBJSDefaultValueFactory));
        static Func<int> _MaxSBJSDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 公积金基数最低值
        /// </summary>
        //public int MinGJJJS { get; set; }
        
        public int MinGJJJS
        {
            get { return _MinGJJJSLocator(this).Value; }
            set { _MinGJJJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int MinGJJJS Setup
        protected Property<int> _MinGJJJS = new Property<int> { LocatorFunc = _MinGJJJSLocator };
        static Func<BindableBase, ValueContainer<int>> _MinGJJJSLocator = RegisterContainerLocator<int>("MinGJJJS", model => model.Initialize("MinGJJJS", ref model._MinGJJJS, ref _MinGJJJSLocator, _MinGJJJSDefaultValueFactory));
        static Func<int> _MinGJJJSDefaultValueFactory = null;
        #endregion

        /// <summary>
        /// 公积金基数最高值
        /// </summary>
       // public int MaxGJJJS { get; set; }
        
        public int MaxGJJJS
        {
            get { return _MaxGJJJSLocator(this).Value; }
            set { _MaxGJJJSLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property int MaxGJJJS Setup
        protected Property<int> _MaxGJJJS = new Property<int> { LocatorFunc = _MaxGJJJSLocator };
        static Func<BindableBase, ValueContainer<int>> _MaxGJJJSLocator = RegisterContainerLocator<int>("MaxGJJJS", model => model.Initialize("MaxGJJJS", ref model._MaxGJJJS, ref _MaxGJJJSLocator, _MaxGJJJSDefaultValueFactory));
        static Func<int> _MaxGJJJSDefaultValueFactory = null;
        #endregion

    }
     
        
        
        

        
        

}
