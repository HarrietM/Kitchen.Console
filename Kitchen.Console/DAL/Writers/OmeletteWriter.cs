using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL.Writers
{
    public interface IOmeletteWriter
    {
        void Save(KitchenContext context, int recipeId);
    }
    public class OmeletteWriter : IOmeletteWriter
    {
        public void Save(KitchenContext context, int recipeId)
        {
            context.Omelettes.Add(new Omelette {RecipeId = recipeId, DateCooked = DateTime.Today});
            context.SaveChanges();
        }
    }
}
