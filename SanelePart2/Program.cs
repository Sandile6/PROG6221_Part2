using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanelePart2
{
    internal class Program
    {
            static void Main(string[] args)
            {
                List<Recipe> recipes = new List<Recipe>();
                bool exitProgram = false;

                while (!exitProgram)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Enter a new recipe");
                    Console.WriteLine("2. Display all recipes");
                    Console.WriteLine("3. Select a recipe to display");
                    Console.WriteLine("4. Exit");

                    Console.Write("Choose an option: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            EnterNewRecipe(recipes);
                            break;
                        case 2:
                            DisplayAllRecipes(recipes);
                            break;
                        case 3:
                            SelectAndDisplayRecipe(recipes);
                            break;
                        case 4:
                            exitProgram = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }

            static void EnterNewRecipe(List<Recipe> recipes)
            {
                Console.Write("Enter the recipe name: ");
                string recipeName = Console.ReadLine();

                Recipe recipe = new Recipe(recipeName);
                recipe.OnCaloriesExceeded += message => Console.WriteLine(message);

                Console.Write("\nEnter number of ingredients: ");
                int numIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.Write($"Ingredient {i + 1} name: ");
                    string name = Console.ReadLine();

                    Console.Write($"Quantity of {name}: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write($"Unit of measurement: ");
                    string unit = Console.ReadLine();

                    Console.Write($"Calories of {name}: ");
                    int calories = int.Parse(Console.ReadLine());

                    Console.Write($"Food group of {name}: ");
                    string foodGroup = Console.ReadLine();

                    recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
                }

                Console.Write("\nEnter number of steps: ");
                int numSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.Write($"Step {i + 1}: ");
                    string description = Console.ReadLine();

                    recipe.AddStep(description);
                }

                recipes.Add(recipe);

                Console.WriteLine("\nRecipe created:");
                recipe.DisplayRecipe();
            }

            static void DisplayAllRecipes(List<Recipe> recipes)
            {
                if (recipes.Count == 0)
                {
                    Console.WriteLine("                          ");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("No recipes available.");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("                          ");
                    return;
                }

                Console.WriteLine("Recipes:");
                foreach (var recipe in recipes.OrderBy(r => r.Name))
                {
                    Console.WriteLine(recipe.Name);
                }
            }

            static void SelectAndDisplayRecipe(List<Recipe> recipes)
            {
                if (recipes.Count == 0)
                {
                    Console.WriteLine("                          ");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("No recipes available.");
                    Console.WriteLine("*****************************************************");
                    Console.WriteLine("                          ");
                    return;
                }

                Console.WriteLine("Recipes:");
                int index = 1;
                foreach (var recipe in recipes.OrderBy(r => r.Name))
                {
                    Console.WriteLine($"{index}. {recipe.Name}");
                    index++;
                }

                Console.Write("Choose a recipe number to display: ");
                int recipeIndex = int.Parse(Console.ReadLine()) - 1;

                if (recipeIndex >= 0 && recipeIndex < recipes.Count)
                {
                    var selectedRecipe = recipes.OrderBy(r => r.Name).ElementAt(recipeIndex);
                    selectedRecipe.DisplayRecipe();
                    ManageRecipe(selectedRecipe);
                }
                else
                {
                    Console.WriteLine("Invalid recipe number. Please try again.");
                }
            }

            static void ManageRecipe(Recipe recipe)
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nOptions:");
                    Console.WriteLine("1. Scale recipe");
                    Console.WriteLine("2. Reset quantities");
                    Console.WriteLine("3. Clear recipe");
                    Console.WriteLine("4. Exit");

                    Console.Write("Choose an option: ");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor;
                            if (double.TryParse(Console.ReadLine(), out factor) && (factor == 0.5 || factor == 2 || factor == 3))
                            {
                                recipe.ScaleRecipe(factor);
                                Console.WriteLine("\nRecipe scaled:");
                                recipe.DisplayRecipe();
                            }
                            else
                            {
                                Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                            }
                            break;

                        case 2:
                            recipe.ResetQuantities();
                            break;

                        case 3:
                            recipe.ClearRecipe();
                            exit = true;
                            break;

                        case 4:
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }
    }