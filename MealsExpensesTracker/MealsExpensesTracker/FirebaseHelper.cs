using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;

namespace MealsExpensesTracker
{
    internal class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://mealexptrackmet-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddRecord(string dt, string ms, string nm, double pc, double tp)

        {
            await firebase.Child("MealTrackerRecord").PostAsync(new MealTrackerRecord() { DateRecorded = dt, Meals = ms, Name = nm, Price = pc, TotalPrice = tp});
        }

        public async Task<List<MealTrackerRecord>> GetAllMealTrackerRecord()
        {
            return (await firebase.Child("MealTrackerRecord").OnceAsync<MealTrackerRecord>()).Select(item => new MealTrackerRecord
            {
                DateRecorded = item.Object.DateRecorded,Meals = item.Object.Meals,
                Name = item.Object.Name,Price = item.Object.Price,TotalPrice = item.Object.TotalPrice
            }).ToList();
        }

        public async Task<List<MealTrackerRecord>> GetFindRecord(string meals)
        {
            var allMealTrackerRecord = await GetAllMealTrackerRecord();
            await firebase.Child("MealTrackerRecord").OnceAsync<MealTrackerRecord>();
            return allMealTrackerRecord.Where(a => a.Meals == meals).ToList();
        }
    }
}
