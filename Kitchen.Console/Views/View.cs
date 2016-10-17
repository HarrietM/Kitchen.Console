using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Kitchen.Console.Models;

namespace Kitchen.Console.Views
{
    using System;
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
            Console.WriteLine("Your kitchen is open. Please enter a command.");
        }

        public void ShowRecipes(IEnumerable<Recipe> recipes)
        {
            recipes.ForEach(x => Console.WriteLine(x.Name));
        }

        public void ShowIngredients(IEnumerable<Ingredient> ingredients)
        {
            ingredients.ForEach(x => Console.WriteLine(x.Name + "," + x.Quantity));
        }

        public void AcceptDelivery()
        {
            Console.WriteLine("You have recieved a delivery of ingredients. Type 'get ingredients' to check your current stocks.");
        }

        public void ShowRecipesAbleToCreate(IEnumerable<Recipe> recipes)
        {
            Console.WriteLine("You can make the following recipes from the available ingredients.");
            ShowRecipes(recipes);
        }

        public void ShowOrder(Recipe recipe)
        {
            Console.WriteLine("An order has been placed for an omelette: " + recipe.Name);
        }

        public void ShowCookedOrder(Recipe recipe)
        {
            Console.WriteLine("You have cooked one " + recipe.Name + " omelette.");
        }

        public void ShowOmelettesCooked(Dictionary<string, int> omelettes)
        {
            Console.WriteLine("You have made the following omelettes:");
            omelettes.ForEach(x => Console.WriteLine(x.Key + ", " + x.Value));
        }
    }
}
