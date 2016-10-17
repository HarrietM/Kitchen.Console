using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Console.Models
{
    public class Omelette
    {
        public int OmeletteId { get; set; }
        public int RecipeId { get; set; }
        public DateTime DateCooked { get; set; }
    }
}
