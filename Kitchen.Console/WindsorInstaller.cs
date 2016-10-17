using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Kitchen.Console.DAL;
using Kitchen.Console.DAL.Readers;
using Kitchen.Console.DAL.Writers;

namespace Kitchen.Console
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IOmeletteReader>().ImplementedBy(typeof(OmeletteReader)),
                               Component.For<IOmeletteWriter>().ImplementedBy(typeof(OmeletteWriter)),
                               Component.For<IIngredientWriter>().ImplementedBy(typeof(IngredientWriter)),
                               Component.For<IIngredientReader>().ImplementedBy(typeof(IngredientReader)),
                               Component.For<IRecipeReader>().ImplementedBy(typeof(RecipeReader)),
                               Component.For<IKitchen>().ImplementedBy(typeof(Kitchen)));
        }
    }
}
