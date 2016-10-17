using System.Collections.Generic;
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

        public void ShowDelivery()
        {
        }
    }
}
