using System.Collections.Generic;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL.Readers
{
    public interface IIngredientReader
    {
        IEnumerable<Ingredient> GetIngredients(KitchenContext context);
    }

    public class IngredientReader : IIngredientReader
    {
        public IEnumerable<Ingredient> GetIngredients(KitchenContext context)
        {
            return context.Ingredients;
        }
    }
}
