using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL
{
    public class KitchenContext : DbContext
    {
        public KitchenContext()
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Omelette> Omelettes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                        .HasKey(e => e.RecipeId)
                        .HasMany<Ingredient>(s => s.Ingredients)
                        .WithMany(c => c.Recipes)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("RecipeRefId");
                            cs.MapRightKey("IngredientRefId");
                            cs.ToTable("RecipeIngredient");
                        });

            modelBuilder.Entity<Omelette>()
                        .HasRequired(s => s.Recipe);
        }
    }
}
