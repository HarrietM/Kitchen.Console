using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Console.DAL;
using Kitchen.Console.Models;

namespace Kitchen.Console
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<KitchenContext>(new DatabaseInitializer());

            using (var context = new KitchenContext())
            {
                var firstOrDefault = context.Recipes.FirstOrDefault();
                Console.WriteLine(firstOrDefault.Name);
            }
        }
    }
}
