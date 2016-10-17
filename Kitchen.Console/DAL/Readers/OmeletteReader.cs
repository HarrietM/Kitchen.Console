using System;
using System.Collections.Generic;
using System.Linq;
using Kitchen.Console.Models;

namespace Kitchen.Console.DAL.Readers
{
    public interface IOmeletteReader
    {
        IEnumerable<Omelette> GetOmelettesCookedByDay(KitchenContext context, DateTime date);
        IEnumerable<Omelette> GetAllOmelettesCooked(KitchenContext context);
    }

    public class OmeletteReader : IOmeletteReader
    {
        public IEnumerable<Omelette> GetOmelettesCookedByDay(KitchenContext context, DateTime date)
        {
            return context.Omelettes.Where(x => x.DateCooked == date);
        }

        public IEnumerable<Omelette> GetAllOmelettesCooked(KitchenContext context)
        {
            return context.Omelettes;
        }
    }
}
