using System.Collections.Generic;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL.Readers
{
    public interface IRecipeReader
    {
        IEnumerable<Recipe> GetRecipes(KitchenContext context);
    }

    public class RecipeReader : IRecipeReader
    {
        public IEnumerable<Recipe> GetRecipes(KitchenContext context)
        {
            return context.Recipes;
        }
    }
}
