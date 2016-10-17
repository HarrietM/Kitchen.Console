using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
