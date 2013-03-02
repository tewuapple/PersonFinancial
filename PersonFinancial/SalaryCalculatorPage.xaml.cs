using PersonFinancial.Common;
using PersonFinancial.Model;
using PersonFinancial.ViewModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace PersonFinancial
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SalaryCalculatorPage : PersonFinancial.Common.LayoutAwarePage
    {
        public SalaryCalculatorPage()
        {
            this.InitializeComponent();
            this.ViewModel = new SalaryCalculatorVM();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            cbbCity.SelectedIndex = -1;
            cbbInsuranceType.Items.Add("社会基本保险");
            cbbInsuranceType.SelectedIndex = 0;
            cbbInsuranceType.IsEnabled = false;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {

        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            decimal salary;
            if(decimal.TryParse(txtSalary.Text,out salary))
            {
                var sc = this.ViewModel as SalaryCalculatorVM;
                var city= cbbCity.SelectedItem as City;
                var p = new Person(salary, sc.City[city.ID].Sr);
                sc.Person = p;
            }
        }

        private void ResetCalc_Click(object sender, RoutedEventArgs e)
        {
            cbbCity.SelectedIndex = -1;
            Clear(this.pageRoot);
        }

        /// <summary>
        /// 清空所有文本数据
        /// </summary>
        /// <param name="element"></param>
        private void Clear(DependencyObject element)
        {
            // If this is a text box, clear the text. 
            var txt = element as TextBox;
            if (txt != null)
                txt.Text = "";
            // Check for nested children. 
            int children = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < children; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(element, i);
                Clear(child);
            }
        }

    }
}
