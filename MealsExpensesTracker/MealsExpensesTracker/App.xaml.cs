using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsExpensesTracker
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();

            //MainPage = new MainPage();
            //DevExpress.XamarinForms.Charts.Initializer.Init(); //For Chart Testing
            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MasterDetailPageMeals();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
