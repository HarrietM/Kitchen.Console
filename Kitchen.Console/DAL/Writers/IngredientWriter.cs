namespace Kitchen.Console.DAL.Writers
{
    public interface IIngredientWriter
    {
        void UpdateQuantity(KitchenContext context, int ingredientId, int amount);
    }

    public class IngredientWriter : IIngredientWriter
    {
        public void UpdateQuantity(KitchenContext context, int ingredientId, int amount)
        {
            var ingredient = context.Ingredients.Find(ingredientId);
            ingredient.Quantity = ingredient.Quantity + amount;
            context.SaveChanges();
        }
    }
}
