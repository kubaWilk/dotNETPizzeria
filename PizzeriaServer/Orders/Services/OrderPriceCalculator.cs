using PizzeriaServer.Meals.Models;
using PizzeriaServer.Meals.Services;

namespace PizzeriaServer.Orders.Services
{
    internal class OrderPriceCalculator
    {

        private readonly MealPriceService _mealPriceService;

        public OrderPriceCalculator()
        {
            _mealPriceService = new MealPriceService();
            _mealPriceService.RegisterPriceCalculator(new PizzaPriceCalculator(), typeof(Pizza));
        }

        /// <summary>
        /// Calculates actual price of <see cref="Order"/>.
        /// updates <see cref="SavedPizzaOrder.ActualPrice"/> field.
        /// </summary>
        public void UpdateActualPrice(ref SavedPizzaOrder pizzaOrder)
        {
            IEnumerable<decimal> itemsPrice = pizzaOrder.Items.Select(item =>
            {
                Pizza pizza = item.Pizza;
                _mealPriceService.UpdateActualPrice(ref pizza);

                decimal itemPrice = pizza.ActualPrice.GetValueOrDefault();
                itemPrice += item.Size.BasePrice;
                itemPrice += item.Crust.BasePrice;

                if (item.ExtraToppings != null && item.ExtraToppings.Any())
                {
                    decimal extraToppingsPrice = item.ExtraToppings.Aggregate(0.0m, (acc, topping) => acc + topping.BasePrice);
                    itemPrice += extraToppingsPrice;
                }

                item.ActualPrice = itemPrice;
                return itemPrice;
            });

            decimal total = itemsPrice.Aggregate(0.0m, (acc, itemPrice) => acc + itemPrice);

            pizzaOrder.ActualPrice = total;
        }
    }
}
