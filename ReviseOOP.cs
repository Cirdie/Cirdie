using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

// Abstract class representing a food item

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeInterface();

        Console.WriteLine("Press any key to start...");
        Console.ReadKey(true); // Wait for a key press

        RecipeManager recipeManager = new RecipeManager("", new List<string>(), "", 0, "");
        recipeManager.MainMenu();
    }

    static void DisplayWelcomeInterface()
    {
        Console.WriteLine(@"
 ######   ########   #######  ##     ## ########        ###    
##    ##  ##     ## ##     ## ##     ## ##     ##      ## ##   
##        ##     ## ##     ## ##     ## ##     ##     ##   ##  
##   #### ########  ##     ## ##     ## ########     ##     ## 
##    ##  ##   ##   ##     ## ##     ## ##           ######### 
##    ##  ##    ##  ##     ## ##     ## ##           ##     ## 
 ######   ##     ##  #######   #######  ##           ##     ## 
");
        Console.WriteLine("    \n    Welcome to Cookbook Companion: Your Recipe Manager\n");
        Console.WriteLine("    ----------------------------------------------------");
        Console.WriteLine("               Manage your recipes with ease!            ");
        Console.WriteLine("    ----------------------------------------------------\n");
    }
}

abstract class FoodItem
{
    // Properties to store information about the food item
    public string Name { get; set; }                // Name of the food item
    public List<string> Ingredients { get; set; }   // List of ingredients required
    public string Instructions { get; set; }        // Cooking instructions or recipe steps
    public int CookingTime { get; set; }            // Time required to cook or prepare the food item
    public string Category { get; set; }            // Category to which the food item belongs (e.g., Appetizers, Main Dishes, etc.)

    // Constructor to initialize the properties of the food item
    public FoodItem(string name, List<string> ingredients, string instructions, int cookingTime, string category)
    {
        Name = name;
        Ingredients = ingredients;
        Instructions = instructions;
        CookingTime = cookingTime;
        Category = category;
    }

    // Abstract method for displaying details of the food item
    public abstract void DisplayDetails();
}


// Derived class representing a recipe, inheriting from FoodItem
class Recipe : FoodItem
{
    // Constructor calling the base class constructor
    public Recipe(string name, List<string> ingredients, string instructions, int cookingTime, string category)
        : base(name, ingredients, instructions, cookingTime, category)
    {
    }

    // Override method to display recipe details
    public override void DisplayDetails()
    {
        Console.WriteLine("");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine($"                     {Name.ToUpper()}                 ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine($"Category          |  {Category}");
        Console.WriteLine($"Cooking Time      |  {CookingTime} minutes");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("Ingredients:");
        foreach (string ingr in Ingredients)
        {
            Console.WriteLine($"- {ingr}");
        }
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("Instructions:");
        Console.WriteLine(Instructions);
        Console.WriteLine("────────────────────────────────────────────────────");
    }




}



// Interface for managing recipes


// Class representing a recipe manager
class RecipeManager : Recipe
{
    private List<Recipe> recipes = new List<Recipe>();

    // Constructor of RecipeManager class
    public RecipeManager(string name, List<string> ingredients, string instructions, int cookingTime, string category)
        // Calling the constructor of the base class (Recipe) using the 'base' keyword
        : base(name, ingredients, instructions, cookingTime, category)
    {
        // Constructor body
    }

    // Method to add a new recipe to the recipe manager
    public void AddRecipe()
    {
        Console.Clear();
        Console.WriteLine("[1] Add Recipe\n");

        // Prompt for recipe name
        Console.WriteLine("");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("            Please Enter the Name of the Recipe      ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.Write("\n> ");
        string name = Console.ReadLine();

        // Check if the recipe with the same name already exists
        Recipe existingRecipe = recipes.Find(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (existingRecipe != null)
        {
            Console.Clear();
            Console.WriteLine("");

            Console.WriteLine("             Recipe with the Same Name              ");
            Console.WriteLine("                  Already Exists                    ");
            existingRecipe.DisplayDetails();
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return; // Exit the method
        }

        // Prompt for ingredients
        Console.WriteLine("");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("           Please Enter the Ingredients             ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("\n(one ingredient per line, press Enter twice when finished)\n");
        List<string> ingredients = new List<string>();
        string ingredient;
        while (!string.IsNullOrWhiteSpace(ingredient = Console.ReadLine()))
        {
            ingredients.Add(ingredient);
        }

        // Check if ingredients are blank
        if (ingredients.Count == 0)
        {
            Console.WriteLine("Error: Ingredients cannot be blank. Please try again.");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return; // Exit the method
        }

        // Prompt for cooking instructions
        Console.Clear();
        Console.WriteLine("                 RECIPE INGREDIENTS                 ");
        Console.WriteLine("────────────────────────────────────────────────────\n");
        foreach (var item in ingredients)
        {
            Console.WriteLine($"- {item}");
        }

        Console.WriteLine("");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("           Please Enter the Instructions            ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("\n(one ingredient per line, press Enter twice when finished)\n");
        string instructions = "";
        string line;
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            instructions += line + "\n";
        }

        // Check if instructions are blank
        if (string.IsNullOrWhiteSpace(instructions))
        {
            Console.WriteLine("Error: Instructions cannot be blank. Please try again.");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return; // Exit the method
        }

        // Prompt for cooking time
        Console.Clear();

        Console.WriteLine("                 RECIPE INGREDIENTS                 ");
        Console.WriteLine("────────────────────────────────────────────────────\n");
        foreach (var item in ingredients)
        {
            Console.WriteLine($"- {item}");
        }
        Console.WriteLine("                 RECIPE INSTRUCTIONS                ");
        Console.WriteLine("────────────────────────────────────────────────────\n");
        Console.WriteLine(instructions);

        Console.WriteLine("\nPlease enter the cooking time for the recipe (in minutes):");
        int cookingTime;
        while (!int.TryParse(Console.ReadLine(), out cookingTime) || cookingTime <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid cooking time in minutes:");
        }

        // Prompt for category selection
        Console.Clear();
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("              Please Select a Category              ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("[1] » Appetizers & Snacks");
        Console.WriteLine("[2] » Main Dishes");
        Console.WriteLine("[3] » Side Dishes");
        Console.WriteLine("[4] » Desserts");
        Console.WriteLine("[5] » Breakfast & Brunch");
        Console.WriteLine("[6] » Beverages");
        Console.WriteLine("[7] » Soups & Salads");
        Console.WriteLine("────────────────────────────────────────────────────");

        string categoryInput;
        string category;
        do
        {
            Console.Write("\n> ");
            categoryInput = Console.ReadLine();

            switch (categoryInput)
            {
                case "1":
                    category = "Appetizers & Snacks";
                    break;
                case "2":
                    category = "Main Dishes";
                    break;
                case "3":
                    category = "Side Dishes";
                    break;
                case "4":
                    category = "Desserts";
                    break;
                case "5":
                    category = "Breakfast & Brunch";
                    break;
                case "6":
                    category = "Beverages";
                    break;
                case "7":
                    category = "Soups & Salads";
                    break;
                default:
                    category = "Unknown";
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        } while (!categoryInput.Equals("1") && !categoryInput.Equals("2") && !categoryInput.Equals("3") &&
                 !categoryInput.Equals("4") && !categoryInput.Equals("5") && !categoryInput.Equals("6") &&
                 !categoryInput.Equals("7"));

        // Create a new Recipe object
        Recipe newRecipe = new Recipe(name, ingredients, instructions, cookingTime, category);

        Console.Clear();
        newRecipe.DisplayDetails();

        // Confirm adding the recipe
        Console.Write("\nWould you like to add this recipe? (Y/N): ");
        string confirmInput = Console.ReadLine();
        if (confirmInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            // Add the new recipe to the list
            recipes.Add(newRecipe);
            Console.WriteLine("\nRecipe added successfully!");
        }
        else
        {
            Console.WriteLine("\nRecipe not added.");
        }

        // Return to the main menu
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }


    public void UpdateRecipe()
{
    Console.Clear();
    Console.WriteLine("[2] Update Recipe\n");

    if (recipes.Count == 0)
    {
        Console.WriteLine("There are no recipes to update.");
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
        return;
    }

    Console.WriteLine("Please enter the name of the recipe you want to update:");
    string recipeName = Console.ReadLine();

    Recipe recipeToUpdate = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

    if (recipeToUpdate == null)
    {
            Console.Clear();
            Console.WriteLine("────────────────────────────────────────────────────");
            Console.WriteLine("                  Recipe Not Found                   ");
            Console.WriteLine("────────────────────────────────────────────────────");
            Console.WriteLine("[1] » Try again");
            Console.WriteLine("[2] » List recipes");
            Console.WriteLine("[3] » Search recipes");
            Console.WriteLine("[4] » Cancel");
            Console.WriteLine("────────────────────────────────────────────────────");
            Console.Write("\n> ");
        string option = Console.ReadLine();

            bool validOption = false;

            while (!validOption)
            {
                Console.WriteLine("\nPlease enter the option number corresponding to the information you want to update: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        UpdateRecipe();
                        validOption = true;
                        break;
                    case "2":
                        ViewRecipe();
                        validOption = true;
                        break;
                    case "3":
                        SearchRecipe();
                        validOption = true;
                        break;
                    case "4":
                        MainMenu();
                        validOption = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                        break;
                }
            }


        }
        else
        {
            Console.Clear();
            Console.WriteLine("Recipe found. What would you like to update?\n");

        bool updated = false;
        while (!updated)
        {
            recipeToUpdate.DisplayDetails();

                Console.WriteLine("────────────────────────────────────────────────────");
                Console.WriteLine("            What would you like to update           ");
                Console.WriteLine("────────────────────────────────────────────────────");
                Console.WriteLine("[1] » Recipe Name");
                Console.WriteLine("[2] » Ingredients");
                Console.WriteLine("[3] » Cooking Instructions");
                Console.WriteLine("[4] » Cooking Time");
                Console.WriteLine("[5] » Confirm");
                Console.WriteLine("[6] » Cancel\n");
                Console.WriteLine("────────────────────────────────────────────────────");
                Console.Write("\n> ");

                string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter the new recipe name: ");
                    string newName = Console.ReadLine();
                    recipeToUpdate.Name = newName;
                    Console.Clear();
                    Console.WriteLine("\nName updated!");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Enter the new list of ingredients (one ingredient per line, press Enter twice when finished):");
                    List<string> newIngredients = new List<string>();
                    string ingredient;
                    while (!string.IsNullOrWhiteSpace(ingredient = Console.ReadLine()))
                    {
                        newIngredients.Add(ingredient);
                    }
                    recipeToUpdate.Ingredients = newIngredients;
                    Console.Clear();
                    Console.WriteLine("\nIngredients updated!");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Enter the new cooking instructions (press Enter twice to confirm):");
                    string newInstructions = "";
                    string line;
                    while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                    {
                        newInstructions += line + "\n";
                    }
                    recipeToUpdate.Instructions = newInstructions;
                    Console.Clear();
                    Console.WriteLine("\nCooking instructions updated!");
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Enter the new cooking time (in minutes): ");
                    int newCookingTime;
                    while (!int.TryParse(Console.ReadLine(), out newCookingTime) || newCookingTime <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid cooking time in minutes:");
                    }
                    recipeToUpdate.CookingTime = newCookingTime;
                    Console.Clear();
                    Console.WriteLine("\nCooking time updated!");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("\nDisplaying the updated recipe details:\n");
                    recipeToUpdate.DisplayDetails();
                    Console.WriteLine("\nWould you like to confirm the update? (Y/N): ");
                    string confirmUpdate = Console.ReadLine();
                    if (confirmUpdate.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        Console.WriteLine("\nUpdate confirmed!");
                        updated = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nUpdate cancelled.");
                    }
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("\nUpdate cancelled.");
                    updated = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    Console.WriteLine("\nPress any key to return to the main menu...");
    Console.ReadKey();
    MainMenu(); // Return to the main menu
}
    public void RemoveRecipe()
    {
        Console.Clear();
        Console.WriteLine("[3] Remove Recipe\n");

        if (recipes.Count == 0)
        {
            Console.WriteLine("There are no recipes to remove.");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return;
        }

        bool validOption = false;

        while (!validOption)
        {
            Console.WriteLine("Please enter the name of the recipe you want to remove:");
            string recipeName = Console.ReadLine();

            Recipe recipeToRemove = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (recipeToRemove == null)
            {
                Console.Clear();
                Console.WriteLine("────────────────────────────────────────────────────");
                Console.WriteLine("                  Recipe Not Found                   ");
                Console.WriteLine("────────────────────────────────────────────────────");
                Console.WriteLine("[1] » Try again");
                Console.WriteLine("[2] » List recipes");
                Console.WriteLine("[3] » Search recipes");
                Console.WriteLine("[4] » Cancel");
                Console.WriteLine("────────────────────────────────────────────────────");
                Console.Write("\n> ");

                Console.Write("Enter your choice: ");
                string option = Console.ReadLine();

                bool validOption1 = false;

                while (!validOption1)
                {
                    Console.WriteLine("\nInvalid choice. Please enter a valid option (1-4): ");
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            RemoveRecipe();
                            validOption1 = true;
                            break;
                        case "2":
                            ViewRecipe();
                            validOption1 = true;
                            break;
                        case "3":
                            SearchRecipe();
                            validOption1 = true;
                            break;
                        case "4":
                            MainMenu();
                            validOption1 = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                            break;
                    }
                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nRecipe found:\n");
                recipeToRemove.DisplayDetails();

                Console.Write($"\nAre you sure you want to remove '{recipeToRemove.Name}'? (Y/N): ");
                string confirmDelete = Console.ReadLine();

                if (confirmDelete.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    recipes.Remove(recipeToRemove);
                    Console.Clear();
                    Console.WriteLine($"\n[Success] The recipe '{recipeToRemove.Name}' has been removed successfully!");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nRemoval cancelled.");
                }

                validOption = true;
            }
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }
    public void ViewRecipe()
    {
        Console.Clear();
        Console.WriteLine("[2] View Recipe\n");

        if (recipes.Count == 0)
        {
            Console.WriteLine("There are no recipes to view.");
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return;
        }

        Console.Clear();
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("              Please Select an Option               ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("[1] » View All Recipes");
        Console.WriteLine("[2] » View Recipes by Category");
        Console.WriteLine("[3] » Cancel");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.Write("\n> ");


        bool validOption = false;

        while (!validOption)
        {
           

            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewAllRecipes();
                    validOption = true;
                    break;
                case "2":
                    ViewRecipesByCategory();
                    validOption = true;
                    break;
                case "3":
                    MainMenu();
                    validOption = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }


    private void ViewAllRecipes()
    {
        Console.Clear();
        Console.WriteLine("--- All Recipes ---\n");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {recipes[i].Name}");
        }

        Console.WriteLine("\nPlease enter the number of the recipe you want to view:");
        int recipeIndex;
        if (int.TryParse(Console.ReadLine(), out recipeIndex) && recipeIndex >= 1 && recipeIndex <= recipes.Count)
        {
            DisplayRecipe(recipes[recipeIndex - 1]);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.ReadKey();
            ViewAllRecipes();
        }
    }

    private void ViewRecipesByCategory()
    {
        Console.Clear();
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("              Please Select a Category              ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("[1] » Appetizers & Snacks");
        Console.WriteLine("[2] » Main Dishes");
        Console.WriteLine("[3] » Side Dishes");
        Console.WriteLine("[4] » Desserts");
        Console.WriteLine("[5] » Breakfast & Brunch");
        Console.WriteLine("[6] » Beverages");
        Console.WriteLine("[7] » Soups & Salads");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.Write("> ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 7)
        {
            string selectedCategory = "";
            switch (choice)
            {
                case 1:
                    selectedCategory = "Appetizers & Snacks";
                    break;
                case 2:
                    selectedCategory = "Main Dishes";
                    break;
                case 3:
                    selectedCategory = "Side Dishes";
                    break;
                case 4:
                    selectedCategory = "Desserts";
                    break;
                case 5:
                    selectedCategory = "Breakfast & Brunch";
                    break;
                case 6:
                    selectedCategory = "Beverages";
                    break;
                case 7:
                    selectedCategory = "Soups & Salads";
                    break;
            }

            Console.Clear();
            Console.WriteLine($"--- {selectedCategory} Recipes ---\n");
            int recipeCount = 0;
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes[i].Category == selectedCategory)
                {
                    Console.WriteLine($"[{recipeCount + 1}] {recipes[i].Name}");
                    recipeCount++;
                }
            }

            if (recipeCount == 0)
            {
                Console.WriteLine("No recipes found in this category.");
            }
            else
            {
                Console.WriteLine("\nPlease enter the number of the recipe you want to view:");
                int recipeIndex;
                if (int.TryParse(Console.ReadLine(), out recipeIndex) && recipeIndex >= 1 && recipeIndex <= recipeCount)
                {
                    recipeCount = 0;
                    for (int i = 0; i < recipes.Count; i++)
                    {
                        if (recipes[i].Category == selectedCategory)
                        {
                            recipeCount++;
                            if (recipeCount == recipeIndex)
                            {
                                DisplayRecipe(recipes[i]);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }

    private void DisplayRecipe(Recipe recipe)
    {
        Console.Clear();
        Console.WriteLine($"--- {recipe.Name} ---\n");
        recipe.DisplayDetails();

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu();
    }

    public void SearchRecipe()
    {
        Console.Clear();
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("            Please Select an Option                ");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.WriteLine("[1] » Search by Recipe Name");
        Console.WriteLine("[2] » Search by Ingredients");
        Console.WriteLine("[3] » Cancel");
        Console.WriteLine("────────────────────────────────────────────────────");
        Console.Write("\n> ");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("\nPlease enter the recipe name:");
                string recipeName = Console.ReadLine();
                List<Recipe> matchingRecipesByName = recipes.FindAll(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                if (matchingRecipesByName.Count > 0)
                {
                    Console.WriteLine("\nMatching Recipes:\n");
                    for (int i = 0; i < matchingRecipesByName.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {matchingRecipesByName[i].Name}");
                    }
                    Console.WriteLine("\nSelect a recipe number to view details:");
                    int selectedRecipeIndex;
                    if (int.TryParse(Console.ReadLine(), out selectedRecipeIndex) && selectedRecipeIndex > 0 && selectedRecipeIndex <= matchingRecipesByName.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Displaying Recipe Details:\n");
                        matchingRecipesByName[selectedRecipeIndex - 1].DisplayDetails();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid selection. Returning to main menu...");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo recipes found with that name.");
                }
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                MainMenu();
                break;
            case "2":
                Console.WriteLine("\nPlease enter ingredients to search for (separated by commas):");
                string inputIngredients = Console.ReadLine();
                string[] ingredientList = inputIngredients.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                          .Select(i => i.Trim())
                                                          .ToArray();
                List<Recipe> matchingRecipesByIngredients = recipes.FindAll(r => r.Ingredients.Any(i => ingredientList.Contains(i, StringComparer.OrdinalIgnoreCase)));
                if (matchingRecipesByIngredients.Count > 0)
                {
                    Console.WriteLine("\nMatching Recipes:\n");
                    for (int i = 0; i < matchingRecipesByIngredients.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {matchingRecipesByIngredients[i].Name}");
                    }
                    Console.WriteLine("\nSelect a recipe number to view details:");
                    int selectedRecipeIndex;
                    if (int.TryParse(Console.ReadLine(), out selectedRecipeIndex) && selectedRecipeIndex > 0 && selectedRecipeIndex <= matchingRecipesByIngredients.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Displaying Recipe Details:\n");
                        matchingRecipesByIngredients[selectedRecipeIndex - 1].DisplayDetails();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid selection. Returning to main menu...");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo recipes found with those ingredients.");
                }
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                MainMenu();
                break;
            case "3":
                MainMenu();
                break;
            default:
                Console.WriteLine("Invalid option.");
                SearchRecipe();
                break;
        }
    }



    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("                          Welcome to Cookbook Companion: Your Recipe Manager           ");
        Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("  [1] » Create a New Recipe                                                           ");
        Console.WriteLine("  [2] » Update an Existing Recipe                                                     ");
        Console.WriteLine("  [3] » Remove a Recipe                                                               ");
        Console.WriteLine("  [4] » View Recipes                                                                  ");
        Console.WriteLine("  [5] » Search Recipes                                                                ");
        Console.WriteLine("  [6] » Exit                                                                          ");
        Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
        Console.Write("\nEnter the number corresponding to your choice: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    AddRecipe();
                    break;
                case 2:
                    UpdateRecipe();
                    break;
                case 3:
                    RemoveRecipe();
                    break;
                case 4:
                    ViewRecipe();
                    break;
                case 5:
                    SearchRecipe();                    
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
        }
    }

}
