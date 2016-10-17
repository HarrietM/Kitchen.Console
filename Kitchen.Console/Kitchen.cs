using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Kitchen.Console.DAL;
using Kitchen.Console.DAL.Readers;
using Kitchen.Console.DAL.Writers;
using Kitchen.Console.Models;

namespace Kitchen.Console
{
    public interface IKitchen
    {
        void Open();
        IEnumerable<Ingredient> GetAvailableIngredients();
        IEnumerable<Recipe> GetAvailableRecipes();
        IEnumerable<Recipe> CalculateRecipesFromAvailableIngredients();
        Recipe GetOrder();
        void CookCurrentOrder();
        IEnumerable<Omelette> GetOmelettesCooked();
        IEnumerable<Omelette> GetOmelettesCookedToday();
        void GetDelivery();
    }

    public class Kitchen : IKitchen
    {
        private readonly IRecipeReader _recipeReader;
        private readonly IIngredientReader _ingredientReader;
        private readonly IIngredientWriter _ingredientWriter;
        private readonly IOmeletteWriter _omeletteWriter;
        private readonly IOmeletteReader _omeletteReader;
        public IEnumerable<Recipe> AvailableRecipes { get; set; }
        public IEnumerable<Ingredient> AvailableIngredients { get; set; }
        public Recipe CurrentOrder { get; set; }

        public Kitchen(IRecipeReader recipeReader, IIngredientReader ingredientReader, 
            IOmeletteWriter omeletteWriter, IIngredientWriter ingredientWriter, 
            IOmeletteReader omeletteReader)
        {
            _recipeReader = recipeReader;
            _ingredientReader = ingredientReader;
            _omeletteWriter = omeletteWriter;
            _ingredientWriter = ingredientWriter;
            _omeletteReader = omeletteReader;
        }

        public void Open()
        {
            using (var context = new KitchenContext())
            {
                AvailableRecipes = _recipeReader.GetRecipes(context).ToList();
                AvailableIngredients = _ingredientReader.GetIngredients(context).Where(x => x.Quantity > 0).ToList();
            }
        }

        public IEnumerable<Recipe> GetAvailableRecipes()
        {
            return AvailableRecipes;
        }

        public IEnumerable<Ingredient> GetAvailableIngredients()
        {
            using (var context = new KitchenContext())
            {
                return _ingredientReader.GetIngredients(context).Where(x => x.Quantity > 0).ToList();
            }
        }

        public void GetDelivery()
        {
            using (var context = new KitchenContext())
            {
                var allIngredientsIds = _ingredientReader.GetIngredients(context).Select(x => x.IngredientId).ToList();
                foreach (var id in allIngredientsIds)
                {
                    _ingredientWriter.UpdateQuantity(context, id, new Random().Next(1, 10));
                }
            }
        }

        public Recipe GetOrder()
        {
            using (var context = new KitchenContext())
            {
                CurrentOrder = _recipeReader.GetRecipes(context).OrderBy(x => x.RecipeId).Take(1).First();
                return CurrentOrder;
            }
        }

        public void CookCurrentOrder()
        {
            using (var context = new KitchenContext())
            {
                var currentOrderId = CurrentOrder.RecipeId;
                _omeletteWriter.Save(context, currentOrderId);

                foreach (var ingredient in CurrentOrder.Ingredients)
                {
                    _ingredientWriter.UpdateQuantity(context, ingredient.IngredientId, -1);
                }
            }
        }

        public IEnumerable<Omelette> GetOmelettesCookedToday()
        {
            using (var context = new KitchenContext())
            {
                return _omeletteReader.GetOmelettesCookedByDay(context, DateTime.Today).ToList();
            }
        }

        public IEnumerable<Omelette> GetOmelettesCooked()
        {
            using (var context = new KitchenContext())
            {
                return _omeletteReader.GetAllOmelettesCooked(context).OrderBy(x => x.DateCooked).ToList();
            }
        }

        public IEnumerable<Recipe> CalculateRecipesFromAvailableIngredients()
        {
            using (var context = new KitchenContext())
            {
                var recipes = _recipeReader.GetRecipes(context).ToList();
                var availableIngredients = _ingredientReader.GetIngredients(context).Where(x => x.Quantity > 0).ToList();

                foreach (var recipe in recipes)
                {
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        if (!availableIngredients.Contains(ingredient))
                        {
                            recipes.Remove(recipe);
                        }
                    }
                }

                return recipes;
            }
        }
    }
}
