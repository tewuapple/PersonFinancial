using PersonFinancial.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PersonFinancial.ViewModel
{
    public class SalaryCalculatorVM : INotifyPropertyChanged
    {
        public ObservableCollection<City> City { get; set; }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Person"));
            }
        }

        public SalaryCalculatorVM()
        {
            City = new ObservableCollection<City>
                       {
                new City
                    {
                        ID=0,
                        Name="上海",
                    Sr=new SBRate
                           {
                               PerYLRate=8,
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
                },
                new City
                    {
                        ID=1,
                        Name="北京",
                        Sr=new SBRate
                               {
                                   PerYLRate=8,
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
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
