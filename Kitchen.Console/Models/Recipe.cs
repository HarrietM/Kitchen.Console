using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Console.Models
{
    public class Recipe
    {
        [Required]
        public int RecipeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
