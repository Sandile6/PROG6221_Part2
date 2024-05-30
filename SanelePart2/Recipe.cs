using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanelePart2
{ 
    
    using System;
    internal class Recipe
    {

    // Recipe class to manage recipe details and operations
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<Step> steps;
        private List<double> originalQuantities; // List to store original quantities

        public event CalorieNotification OnCaloriesExceeded;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
            originalQuantities = new List<double>();
        }

        // Method to add a new ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            var ingredient = new Ingredient(name, quantity, unit, calories, foodGroup);
            ingredients.Add(ingredient);
            originalQuantities.Add(quantity);

            CheckCalories();
        }

        // Method to add a step to the recipe
        public void AddStep(string description)
        {
            steps.Add(new Step(description));
        }

        // Method to display the full recipe including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("--------------------------------------------");

            // Display ingredients
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }

            // Display steps
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }

            // Display total calories
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}");
            Console.WriteLine("--------------------------------------------");
        }

        // Method to calculate the total calories of the recipe
        private int CalculateTotalCalories()
        {
            return ingredients.Sum(ingredient => ingredient.Calories);
        }

        // Method to check if total calories exceed 300
        private void CheckCalories()
        {
            int totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: Total calories of {totalCalories} exceed 300 calories!");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            Console.WriteLine($"Scaling recipe by a factor of {factor}...");
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity *= factor;
            }
        }

        // Method to reset quantities to original values
        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }
            Console.WriteLine("Quantities reset to original values.");
        }

        // Method to clear the recipe data
        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
            originalQuantities.Clear();
            Console.WriteLine("Recipe has been cleared. You can now enter a new recipe.");
        }
    }
}