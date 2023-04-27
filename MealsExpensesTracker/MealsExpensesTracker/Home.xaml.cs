using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsExpensesTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public List<Data> Data { get; set; }

        public Home()
        {
            InitializeComponent();

            Data = new List<Data>
            {
                new Data { Meals = "Breakfast", Price = 4.50 },
                new Data { Meals = "Lunch", Price = 15.50 },
                new Data { Meals = "Dinner", Price = 12.00 },
            };
            BindingContext = this;
        }
    }

    public class Data
    {
        public string Meals { get; set; }
        public double Price { get; set; }
    }

}