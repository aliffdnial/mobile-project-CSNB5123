using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace MealsExpensesTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tracker.txt");
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public Record()
        {
            InitializeComponent();
            //display.Text = File.ReadAllText(fileName);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            display.ItemsSource = await firebaseHelper.GetAllMealTrackerRecord();
        }
    }
}