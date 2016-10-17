using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kitchen.Console.Models
{
    public class Ingredient
    {
        [Required]
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
