﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealsExpensesTracker
{

    public class MasterDetailPageMealsFlyoutMenuItem
    {
        public MasterDetailPageMealsFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageMealsFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}