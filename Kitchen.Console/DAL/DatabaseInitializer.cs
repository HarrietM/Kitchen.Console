using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<KitchenContext>
    {
        protected override void Seed(KitchenContext context)
        {
            var ingredients = new List<Ingredient>()
                {
                    new Ingredient() { IngredientId = 1, Name = "Egg", Quantity = 10 },
                    new Ingredient() { IngredientId = 2, Name = "Tomato", Quantity = 10 },
                    new Ingredient() { IngredientId = 3, Name = "Courgette", Quantity = 10 },
                    new Ingredient() { IngredientId = 4, Name = "Pork", Quantity = 10 },
                    new Ingredient() { IngredientId = 6, Name = "Chilli", Quantity = 10 }
                };

            context.Recipes.AddOrUpdate(x => x.RecipeId,
                new Recipe()
                {
                    RecipeId = 1,
                    Name = "Veggie Tomato",
                    Ingredients = (ICollection<Ingredient>) ingredients.Where(x => x.Name == "Egg" || x.Name == "Tomato").ToList()
                },
                new Recipe()
                {
                    RecipeId = 2,
                    Name = "Veggie Courgette",
                    Ingredients = (ICollection<Ingredient>)ingredients.Where(x => x.Name == "Egg" || x.Name == "Courgette").ToList()
                },
                new Recipe()
                {
                    RecipeId = 3,
                    Name = "Meaty",
                    Ingredients = (ICollection<Ingredient>)ingredients.Where(x => x.Name == "Egg" || x.Name == "Tomato" || x.Name == "Pork").ToList()
                },
                new Recipe()
                {
                    RecipeId = 4,
                    Name = "Meaty Spicy",
                    Ingredients = (ICollection<Ingredient>)ingredients.Where(x => x.Name == "Egg" || x.Name == "Tomato" || x.Name == "Chilli" || x.Name == "Pork").ToList()
                }
            );

            context.SaveChanges();
        }
    }
}
