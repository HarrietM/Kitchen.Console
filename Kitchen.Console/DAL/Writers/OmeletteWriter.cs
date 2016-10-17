using System;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL.Writers
{
    public interface IOmeletteWriter
    {
        void Save(KitchenContext context, Recipe currentOrder);
    }
    public class OmeletteWriter : IOmeletteWriter
    {
        public void Save(KitchenContext context, Recipe currentOrder)
        {
            context.Omelettes.Add(new Omelette {Recipe = currentOrder, DateCooked = DateTime.Today});
            context.SaveChanges();
        }
    }
}
