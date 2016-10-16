using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<KitchenContext>
    {
        protected override void Seed(KitchenContext context)
        {
            context.Ingredients.AddOrUpdate(x => x.IngredientId,
                 new Ingredient() { IngredientId = 1, Name = "Egg" },
                 new Ingredient() { IngredientId = 2, Name = "Tomato" },
                 new Ingredient() { IngredientId = 3, Name = "Courgette" },
                 new Ingredient() { IngredientId = 4, Name = "Pork" },
                 new Ingredient() { IngredientId = 5, Name = "Tomcat" },
                 new Ingredient() { IngredientId = 6, Name = "Chilli" }
             );

            var ingredients = new List<Ingredient>()
                {
                    new Ingredient() { IngredientId = 1, Name = "Egg" },
                    new Ingredient() { IngredientId = 2, Name = "Tomato" },
                    new Ingredient() { IngredientId = 3, Name = "Courgette" },
                    new Ingredient() { IngredientId = 4, Name = "Pork" },
                    new Ingredient() { IngredientId = 5, Name = "Tomcat" },
                    new Ingredient() { IngredientId = 6, Name = "Chilli" }
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
                    Ingredients = (ICollection<Ingredient>)ingredients.Where(x => x.Name == "Egg" || x.Name == "Tomcat" || x.Name == "Chilli" || x.Name == "Pork").ToList()
                }
            );

            context.SaveChanges();
        }
    }
}
