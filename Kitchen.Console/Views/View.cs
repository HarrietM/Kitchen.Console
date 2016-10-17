using System.Collections.Generic;
using Castle.Core.Internal;
using Kitchen.Console.Models;

namespace Kitchen.Console.Views
{
    public interface IView
    {
        void OpenKitchen();
        void ShowRecipes(IEnumerable<Recipe> recipes);
        void ShowIngredients(IEnumerable<Ingredient> ingredients);
        void AcceptDelivery();
        void ShowRecipesAbleToCreate(IEnumerable<Recipe> recipes);
        void ShowOrder(Recipe recipe);
        void ShowCookedOrder(Recipe recipe);
        void ShowOmelettesCooked(Dictionary<string, int> omelettes);
    }

    public class View : IView
    {
        public void OpenKitchen()
        {
            System.Console.WriteLine("Your kitchen is open. Please enter a command.");
        }

        public void ShowRecipes(IEnumerable<Recipe> recipes)
        {
            recipes.ForEach(x => System.Console.WriteLine(x.Name));
        }

        public void ShowIngredients(IEnumerable<Ingredient> ingredients)
        {
            ingredients.ForEach(x => System.Console.WriteLine(x.Name + "," + x.Quantity));
        }

        public void AcceptDelivery()
        {
            System.Console.WriteLine("You have recieved a delivery of ingredients. Type 'get ingredients' to check your current stocks.");
        }

        public void ShowRecipesAbleToCreate(IEnumerable<Recipe> recipes)
        {
            System.Console.WriteLine("You can make the following recipes from the available ingredients.");
            ShowRecipes(recipes);
        }

        public void ShowOrder(Recipe recipe)
        {
            System.Console.WriteLine("An order has been placed for an omelette: " + recipe.Name);
        }

        public void ShowCookedOrder(Recipe recipe)
        {
            System.Console.WriteLine("You have cooked one " + recipe.Name + " omelette.");
        }

        public void ShowOmelettesCooked(Dictionary<string, int> omelettes)
        {
            System.Console.WriteLine("You have made the following omelettes:");
            omelettes.ForEach(x => System.Console.WriteLine(x.Key + ", " + x.Value));
        }
    }
}
