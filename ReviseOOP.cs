using System;
using System.Collections.Generic;

// Abstract class representing a food item
abstract class FoodItem
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
    public int CookingTime { get; set; }
    public string Category { get; set; }

    // Constructor
    public FoodItem(string name, List<string> ingredients, string instructions, int cookingTime, string category)
    {
        Name = name;
        Ingredients = ingredients;
        Instructions = instructions;
        CookingTime = cookingTime;
        Category = category;
    }

    // Abstract method for displaying details
    public abstract void DisplayDetails();
}

// Derived class representing a recipe, inheriting from FoodItem
class Recipe : FoodItem
{
    // Constructor
    public Recipe(string name, List<string> ingredients, string instructions, int cookingTime, string category)
        : base(name, ingredients, instructions, cookingTime, category)
    {
    }

    // Override method to display recipe details
    public override void DisplayDetails()
    {
        Console.WriteLine("============================================");
        Console.WriteLine($"            {Name.ToUpper()}               ");
        Console.WriteLine("============================================\n");
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Cooking Time: {CookingTime} minutes");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Ingredients:");
        foreach (string ingr in Ingredients)
        {
            Console.WriteLine($"- {ingr}");
        }
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("Instructions:");
        Console.WriteLine(Instructions);
        Console.WriteLine("\n============================================");
    }
}

// Interface for managing recipes
interface IManageRecipe
{
    void AddRecipe();
    void UpdateRecipe();
    void RemoveRecipe();
    void ViewRecipe();
    void SearchRecipe();
    void MainMenu();
}


// Class representing a recipe manager and Inherit the Recipe class nad ImanageRecipe Interface
class RecipeManager : Recipe, IManageRecipe
{
    private List<Recipe> recipes = new List<Recipe>();

    public RecipeManager(string name, List<string> ingredients, string instructions, int cookingTime, string category)
        : base(name, ingredients, instructions, cookingTime, category)
    {
    }

    public void AddRecipe()
    {
        Console.Clear();
        Console.WriteLine("[1] Add Recipe\n");

        Console.WriteLine("Please enter the name of the recipe:");
        string name = Console.ReadLine();

        // Check if the recipe with the same name already exists
        Recipe existingRecipe = recipes.Find(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (existingRecipe != null)
        {
            Console.WriteLine("\nRecipe with the same name already exists:");
            existingRecipe.DisplayDetails();
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
            MainMenu();
            return; // Exit the method
        }

        Console.WriteLine("\nPlease enter the list of ingredients for the recipe (one ingredient per line, press Enter twice when finished):");
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

        Console.Clear();
        Console.WriteLine("[1] Add Recipe\n");

        Console.WriteLine("\nRecipe Ingredients:");
        foreach (var item in ingredients)
        {
            Console.WriteLine($"- {item}");
        }

        Console.WriteLine("\nPlease enter the cooking instructions for the recipe (press Enter twice to confirm):");
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

        Console.Clear();
        Console.WriteLine("[1] Add Recipe\n");

        Console.WriteLine("\nRecipe Ingredients:");
        foreach (var item in ingredients)
        {
            Console.WriteLine($"- {item}");
        }

        Console.WriteLine("\nRecipe Instructions:");
        Console.WriteLine(instructions);

        Console.WriteLine("\nPlease enter the cooking time for the recipe (in minutes):");
        int cookingTime;
        while (!int.TryParse(Console.ReadLine(), out cookingTime) || cookingTime <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid cooking time in minutes:");
        }

        Console.WriteLine("\nPlease select a category for the recipe:");
        Console.WriteLine("[1] Appetizers & Snacks");
        Console.WriteLine("[2] Main Dishes");
        Console.WriteLine("[3] Side Dishes");
        Console.WriteLine("[4] Desserts");
        Console.WriteLine("[5] Breakfast & Brunch");
        Console.WriteLine("[6] Beverages");
        Console.WriteLine("[7] Soups & Salads");

        string categoryInput;
        string category;
        do
        {
            Console.Write("Enter your choice: ");
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

        Console.Clear();
        Console.WriteLine("[1] Add Recipe\n");

        // Creating a new Recipe object
        Recipe newRecipe = new Recipe(name, ingredients, instructions, cookingTime, category);

        // Displaying recipe details using polymorphism
        newRecipe.DisplayDetails();

        // Confirming and adding the recipe...
        Console.Write("\nWould you like to add this recipe? (Y/N): ");
        string confirmInput = Console.ReadLine();
        if (confirmInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            // Adding the new recipe to the list
            recipes.Add(newRecipe);
            Console.WriteLine("\nRecipe added successfully!");
        }
        else
        {
            Console.WriteLine("\nRecipe not added.");
        }

        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
        MainMenu(); // Return to the main menu
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
        Console.WriteLine("\nRecipe not found.");
        Console.WriteLine("Would you like to:");
        Console.WriteLine("[1] Try again");
        Console.WriteLine("[2] List recipes");
        Console.WriteLine("[3] Search recipes");
        Console.WriteLine("[4] Cancel");

        Console.Write("Enter your choice: ");
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
        Console.WriteLine("Recipe found. What would you like to update?\n");

        bool updated = false;
        while (!updated)
        {
            recipeToUpdate.DisplayDetails();

            Console.WriteLine("\n[1] Recipe Name");
            Console.WriteLine("[2] Ingredients");
            Console.WriteLine("[3] Cooking Instructions");
            Console.WriteLine("[4] Cooking Time");
            Console.WriteLine("[5] Confirm");
            Console.WriteLine("[6] Cancel\n");

            Console.Write("Please enter the option number corresponding to the information you want to update: ");
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
                Console.WriteLine("\nRecipe not found.");
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1] Try again");
                Console.WriteLine("[2] List recipes");
                Console.WriteLine("[3] Search recipes");
                Console.WriteLine("[4] Cancel");

                string option;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("Enter your choice: ");
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            validInput = true;
                            break;
                        case "2":
                            ViewRecipe();
                            validInput = true;
                            break;
                        case "3":
                            SearchRecipe();
                            validInput = true;
                            break;
                        case "4":
                            MainMenu();
                            validInput = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                            break;
                    }
                }
            }
            else
            {
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
        Console.WriteLine("Please select an option:");
        Console.WriteLine("[1] View All Recipes");
        Console.WriteLine("[2] View Recipes by Category");
        Console.Write("> ");
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    ViewAllRecipes();
                    break;
                case 2:
                    ViewRecipesByCategory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter either 1 or 2.");
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
        Console.WriteLine("Please select a category:");
        Console.WriteLine("[1] Appetizers & Snacks");
        Console.WriteLine("[2] Main Dishes");
        Console.WriteLine("[3] Side Dishes");
        Console.WriteLine("[4] Desserts");
        Console.WriteLine("[5] Breakfast & Brunch");
        Console.WriteLine("[6] Beverages");
        Console.WriteLine("[7] Soups & Salads");
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
    }


    public void SearchRecipe()
    {
        Console.Clear();
        Console.WriteLine("[5] Search Recipe\n");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("[1] Search by Recipe Name");
        Console.WriteLine("[2] Search by Ingredients");
        Console.Write("> ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Please enter the name of the recipe you want to search for: ");
                string recipeName = Console.ReadLine();
                SearchRecipesByName(recipeName);
                break;
            case "2":
                Console.Write("Please enter the ingredient you want to search for: ");
                string ingredient = Console.ReadLine();
                SearchRecipesByIngredient(ingredient);
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                MainMenu();
                break;
        }
    }

    private void SearchRecipesByName(string recipeName)
    {
        var results = recipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower())).ToList();
        DisplaySearchResults(results);
    }

    private void SearchRecipesByIngredient(string ingredient)
    {
        var results = recipes.Where(r => r.Ingredients.Any(i => i.ToLower().Contains(ingredient.ToLower()))).ToList();
        DisplaySearchResults(results);
    }

    private void DisplaySearchResults(List<Recipe> results)
    {
        if (results.Count == 0)
        {
            Console.WriteLine("No recipes found.");
            Console.ReadKey();
            MainMenu();
            return;
        }

        Console.WriteLine("\n[Search Results]\n");

        for (int i = 0; i < results.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {results[i].Name}");
        }

        Console.Write("\nPlease enter the number of the recipe you want to view: ");
        int selection;
        if (int.TryParse(Console.ReadLine(), out selection) && selection > 0 && selection <= results.Count)
        {
            results[selection - 1].DisplayDetails();
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
            Console.ReadKey();
            SearchRecipe();
        }
    }


    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("===================================================");
        Console.WriteLine("\t\tRECIPE MANAGEMENT SYSTEM");
        Console.WriteLine("===================================================\n");
        Console.WriteLine("[1] Add Recipe");
        Console.WriteLine("[2] Update Recipe");
        Console.WriteLine("[3] Remove Recipe");
        Console.WriteLine("[4] View Recipe");
        Console.WriteLine("[5] Search Recipe");
        Console.WriteLine("[6] Exit");
        Console.WriteLine("\n===================================================\n");

        Console.Write("Please enter your choice: ");
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

    static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager("", new List<string>(), "", 0, "");
        recipeManager.MainMenu();
    }
}
