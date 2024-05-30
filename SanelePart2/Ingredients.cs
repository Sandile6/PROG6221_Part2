using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanelePart2
{
        // Delegate to notify when recipe calories exceed 300
        public delegate void CalorieNotification(string message);

        // Ingredient class to store details of each ingredient
        internal class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public int Calories { get; set; }
            public string FoodGroup { get; set; }

            public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
                Calories = calories;
                FoodGroup = foodGroup;
            }

            // Override ToString method to provide a formatted output for ingredients
            public override string ToString()
            {
                return $"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})";
            }
        }
    }