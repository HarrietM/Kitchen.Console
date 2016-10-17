using System.Data.Entity;
using Castle.Core.Internal;
using Castle.Windsor;
using Kitchen.Console.DAL;

namespace Kitchen.Console
{
    using System;
    public class Program
    {
        private static bool kitchenIsOpen;
        private static IKitchen _kitchen;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            Database.SetInitializer<KitchenContext>(new DatabaseInitializer());
            var container = new WindsorContainer().Install(new WindsorInstaller());
            _kitchen = container.Resolve<IKitchen>();

            kitchenIsOpen = OpenKitchen();

            while (kitchenIsOpen)
            {
                var input = Console.ReadLine();
                Process(container, input);
            }

            container.Dispose();
            Environment.Exit(0);
        }

        public static bool OpenKitchen()
        {
            _kitchen.Open();
            Console.WriteLine("Your kitchen is open. Please enter a command.");
            return true;
        }

        private static void Process(IWindsorContainer container, string input)
        {
            switch (input)
            {
                case "get recipes":
                    _kitchen.GetAvailableRecipes().ForEach(x => Console.WriteLine(x.Name));
                    break;
                case "get ingredients":
                    _kitchen.GetAvailableIngredients().ForEach(x => Console.WriteLine(x.Name + "," +  x.Quantity));
                    break;
                case "get delivery":
                    _kitchen.GetDelivery();
                    break;
                case "calculate":
                    _kitchen.CalculateRecipesFromAvailableIngredients();
                    break;
                case "get order":
                    _kitchen.GetOrder();
                    break;
                case "cook order":
                    _kitchen.CookCurrentOrder();
                    break;
                case "get omelettes cooked":
                    _kitchen.GetOmelettesCooked();
                    break;
                case "close":
                    kitchenIsOpen = false;
                    break;
            }
        }
    }
}
