using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;

namespace MealsExpensesTracker
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private double totalSpent = 0.00;

        public MainPage()
        {
            InitializeComponent();
        }

        void OnAdd(object sender, EventArgs e)
        {
            //Meal
            string selectedMeal = mealLabel.SelectedItem as string;
            resMeal.Text = selectedMeal;

            //Name
            string name = inputName.Text;
            resName.Text = name;
            
            //Price
            double price = Convert.ToDouble(inputPrice.Text);
            resPrice.Text = "Rm " + price.ToString("0.00");
        }

        void OnReset(object sender, EventArgs e)
        {
            mealLabel.SelectedIndex = -1 ;
            inputName.Text = "";
            inputPrice.Text = "";
            resMeal.Text = "Meal";
            resName.Text = "Name";
            resPrice.Text = "Rm";
        }

        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }

        async void OnSaveRecord(object sender, EventArgs e)
        {
            var selectdate = selectDate.Date.ToString("dd/MM/yyyy");

            string selectedMeal = mealLabel.SelectedItem as string;
            resMeal.Text = selectedMeal;

            string name = inputName.Text;
            resName.Text = name;

            double price = Convert.ToDouble(inputPrice.Text);
            resPrice.Text = "Rm " + price.ToString("0.00");

            // Update the total spent and display it
            totalSpent = totalSpent += price;
            resTotal.Text = "Rm " + totalSpent.ToString("0.00");

            await firebaseHelper.AddRecord(selectdate, selectedMeal, name, price, totalSpent);

            await DisplayAlert("Record Saved", "Your Spending Record has been saved", "OK");
        }
    }
}