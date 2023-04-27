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
    public partial class Budgets : ContentPage
    {
        public Budgets()
        {
            InitializeComponent();
            LoadBudget();
        }

        private void LoadBudget()
        {
            if (App.Current.Properties.ContainsKey("BreakfastBudget"))
            {
                BreakfastEntry.Text = App.Current.Properties["BreakfastBudget"].ToString();
            }
            if (App.Current.Properties.ContainsKey("LunchBudget"))
            {
                LunchEntry.Text = App.Current.Properties["LunchBudget"].ToString();
            }
            if (App.Current.Properties.ContainsKey("DinnerBudget"))
            {
                DinnerEntry.Text = App.Current.Properties["DinnerBudget"].ToString();
            }
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            double breakfastBudget;
            double lunchBudget;
            double dinnerBudget;

            if (double.TryParse(BreakfastEntry.Text, out breakfastBudget))
            {
                App.Current.Properties["BreakfastBudget"] = breakfastBudget;
            }
            if (double.TryParse(LunchEntry.Text, out lunchBudget))
            {
                App.Current.Properties["LunchBudget"] = lunchBudget;
            }
            if (double.TryParse(DinnerEntry.Text, out dinnerBudget))
            {
                App.Current.Properties["DinnerBudget"] = dinnerBudget;
            }

            App.Current.SavePropertiesAsync();

            DisplayAlert("Budgets Saved", "Your budgets have been saved.", "OK");
        }
    }
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    //public partial class Budgets : ContentPage
    //{
    //    public Budgets()
    //    {
    //        InitializeComponent();
    //        SetChart();
    //    }

    //    private void SetChart()
    //    {
    //        var entries = new List<EntryChart> {
    //            new EntryChart(float.Parse(breakfastBudgetEntry.Text), SKColor.Parse("#FFA07A")),
    //            new EntryChart(float.Parse(lunchBudgetEntry.Text), SKColor.Parse("#40E0D0")),
    //            new EntryChart(float.Parse(dinnerBudgetEntry.Text), SKColor.Parse("#9370DB"))
    //        };

    //        chartView.Chart = new RadialGaugeChart
    //        {
    //            Entries = entries,
    //            MinValue = 0,
    //            MaxValue = 100,
    //            LabelTextSize = 32
    //        };
    //    }

    //    private void OnSaveClicked(object sender, EventArgs e)
    //    {
    //        SetChart();
    //    }
    //}

    //public class EntryChart : Entry
    //{
    //    public EntryChart(float value, SKColor color)
    //    {
    //        Value = value;
    //        Color = color;
    //    }

    //    public float Value { get; set; }
    //    public SKColor Color { get; set; }
    //}

    //public partial class Budgets : ContentPage
    //{
    //    public Budgets()
    //    {
    //        InitializeComponent();

    //        // Set default values
    //        breakfastEntry.Text = "0";
    //        lunchEntry.Text = "0";
    //        dinnerEntry.Text = "0";

    //        // Initialize chart
    //        UpdateChart();
    //    }

    //    void OnValueChanged(object sender, EventArgs e)
    //    {
    //        UpdateChart();
    //    }

    //    void UpdateChart()
    //    {
    //        // Get values from entries
    //        float breakfastValue = float.Parse(breakfastEntry.Text);
    //        float lunchValue = float.Parse(lunchEntry.Text);
    //        float dinnerValue = float.Parse(dinnerEntry.Text);

    //        // Create chart entries
    //        List<ChartEntry> entries = new List<ChartEntry>
    //        {
    //            new ChartEntry(breakfastValue)
    //            {
    //                Color = SKColor.Parse("#FFCE00"),
    //                Label = "Breakfast"
    //            },
    //            new ChartEntry(lunchValue)
    //            {
    //                Color = SKColor.Parse("#D81159"),
    //                Label = "Lunch"
    //            },
    //            new ChartEntry(dinnerValue)
    //            {
    //                Color = SKColor.Parse("#8F2D56"),
    //                Label = "Dinner"
    //            }
    //        };

    //        // Create chart
    //        Chart chart = new DonutChart
    //        {
    //            Entries = entries,
    //            HoleRadius = 0.5f
    //        };

    //        // Set chart as image source for chartImage
    //        chartImage.Source = chart.ToBitmap();
}
    //}
//}