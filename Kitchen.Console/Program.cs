using System.Data.Entity;
using Castle.Core.Internal;
using Castle.Windsor;
using Kitchen.Console.DAL;
using Kitchen.Console.Views;

namespace Kitchen.Console
{
    using System;
    public class Program
    {
        private static bool _kitchenIsOpen;
        private static IKitchen _kitchen;
        private static IView _view;

        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            Database.SetInitializer<KitchenContext>(new DatabaseInitializer());
            var container = new WindsorContainer().Install(new WindsorInstaller());
            _kitchen = container.Resolve<IKitchen>();
            _view = container.Resolve<IView>();

            _kitchenIsOpen = OpenKitchen();

            while (_kitchenIsOpen)
            {
                var input = Console.ReadLine();
                Process(input);
            }

            container.Dispose();
            Environment.Exit(0);
        }

        public static bool OpenKitchen()
        {
            _kitchen.Open();
            _view.OpenKitchen();
            return true;
        }

        private static void Process(string input)
        {
            switch (input)
            {
                case "get recipes":
                    _view.ShowRecipes(_kitchen.GetAvailableRecipes());
                    break;
                case "get ingredients":
                    _view.ShowIngredients(_kitchen.GetAvailableIngredients());
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
                    _kitchenIsOpen = false;
                    break;
            }
        }
    }
}
