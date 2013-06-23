using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using PersonalFinancial.MVVM_Sidekick.Models;
using MVVMSidekick.Patterns.ItemsAndSelection;

namespace PersonalFinancial.MVVM_Sidekick.ViewModels
{

    [DataContract]
    public class MainPage_Model : ViewModelBase<MainPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property propcmd for command
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性 propcmd 输入命令

        public MainPage_Model()
        {
            if (IsInDesignMode )
            {
               
            }

            Cities.GetValueContainer(x => x.SelectedItem)
                .GetNullObservable()
                .Where(_ => Cities.SelectedItem != null)
                .Select(_ => Cities.SelectedItem.Sr )
                .Where (sr=>sr!=null)
                .Subscribe(sr => {
                    SelectedSBRateCopy = sr.Clone ();                
                })
                .DisposeWith(this);
        }

        
        public SBRate SelectedSBRateCopy
        {
            get { return _SelectedSBRateCopyLocator(this).Value; }
            set { _SelectedSBRateCopyLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property SBRate SelectedSBRateCopy Setup
        protected Property<SBRate> _SelectedSBRateCopy = new Property<SBRate> { LocatorFunc = _SelectedSBRateCopyLocator };
        static Func<BindableBase, ValueContainer<SBRate>> _SelectedSBRateCopyLocator = RegisterContainerLocator<SBRate>("SelectedSBRateCopy", model => model.Initialize("SelectedSBRateCopy", ref model._SelectedSBRateCopy, ref _SelectedSBRateCopyLocator, _SelectedSBRateCopyDefaultValueFactory));
        static Func<SBRate> _SelectedSBRateCopyDefaultValueFactory = null;
        #endregion



        protected override async Task OnBindedViewLoad(IView view)
        {
            await base.OnBindedViewLoad(view);
            // This method will be called when View is raising Loaded Event, and this instance of VM is already set to ViewModel Propery.  
            // TODO: Add Loaded Handle Logic here.

            Cities.Items.Add(new City
            {
                ID = 0,
                Name = "上海",
                Sr = new SBRate
                {
                    PerYLRate = 8,
                    ComYLRate = 22,
                    PerYiLRate = 2,
                    ComYiLRate = 12,
                    PerShiYeRate = 1,
                    ComShiYeRate = 1.7m,
                    PerGSRate = 0,
                    ComGSRate = 0.5m,
                    PerSYRate = 0,
                    ComSYRate = 0.8m,
                    PerGJJRate = 7,
                    ComGJJRate = 7,
                    MinSBJS = 2599,
                    MaxSBJS = 12993,
                    MinGJJJS = 1280,
                    MaxGJJJS = 12993
                }
            });
            await Task.Delay(100);
            Cities.Items.Add
                (
                new City
                {
                    ID = 1,
                    Name = "北京",
                    Sr = new SBRate
                    {
                        PerYLRate = 8,
                        ComYLRate = 20,
                        PerYiLRate = 2,
                        ComYiLRate = 10,
                        PerShiYeRate = 0.2m,
                        ComShiYeRate = 1,
                        PerGSRate = 0,
                        ComGSRate = 0.3m,
                        PerSYRate = 0,
                        ComSYRate = 0.8m,
                        PerGJJRate = 12,
                        ComGJJRate = 12,
                        MinSBJS = 1869,
                        MaxSBJS = 14016,
                        MinGJJJS = 1160,
                        MaxGJJJS = 14016
                    }
                }            
                );


        }

        //propvm tab tab string tab Title

        




        public ItemsAndSelectionGroup<City> Cities
        {
            get { return _CitiesLocator(this).Value; }
            set { _CitiesLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City>  Cities Setup
        protected Property<MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City> > _Cities = new Property<MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City> > { LocatorFunc = _CitiesLocator };
        static Func<BindableBase, ValueContainer<MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City> >> _CitiesLocator = RegisterContainerLocator<MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City> >("Cities", model => model.Initialize("Cities", ref model._Cities, ref _CitiesLocator, _CitiesDefaultValueFactory));
        static Func<MVVMSidekick.Patterns.ItemsAndSelection.ItemsAndSelectionGroup<City> > _CitiesDefaultValueFactory = ()=>
            new ItemsAndSelectionGroup<City>();
        #endregion


    }

}

