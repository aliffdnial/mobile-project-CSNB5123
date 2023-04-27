using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsExpensesTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedExpenses : TabbedPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        string selectedFindMeals;

        public TabbedExpenses ()
        {
            InitializeComponent();

            findMeals.Items.Add("Breakfast");
            findMeals.Items.Add("Lunch");
            findMeals.Items.Add("Dinner");

            findMeals.SelectedIndexChanged += (sender, args) =>
            {
                if (findMeals.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedFindMeals = findMeals.Items[findMeals.SelectedIndex];
                }
            };
        }

        async override protected void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            if (CurrentPage is ContentPage OverallRecordsTab)
            {
                base.OnAppearing();
                display.ItemsSource = await firebaseHelper.GetAllMealTrackerRecord();
            }
            else if (CurrentPage is ContentPage FindStatusTab)
            {
                base.OnAppearing();
            }
        }

        async void OnFindRecord(object sender, EventArgs e)
        {
            //showFindRecord.ItemsSource = await firebaseHelper.GetFindRecord(findRecord.Text);
            showFindRecord.ItemsSource = await firebaseHelper.GetFindRecord(selectedFindMeals);
        }
    }
}