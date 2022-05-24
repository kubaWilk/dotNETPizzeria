using PizzeriaServer.Meals.Models;
using PizzeriaServer.Meals.Services;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Services
{
    internal class OrderPriceService
    {

        private readonly MealPriceService _mealPriceService;

        /// <summary>
        /// No args constructor.
        /// </summary>
        public OrderPriceService()
        {
            _mealPriceService = new MealPriceService();
            _mealPriceService.RegisterPriceCalculator(new PizzaPriceCalculator(), typeof(Pizza));
        }

        /// <summary>
        /// Calculates actual price of <see cref="Order"/>.
        /// updates <see cref="PizzaOrder.ActualPrice"/> field.
        /// </summary>
        public void UpdateActualPrice(ref PizzaOrder pizzaOrder)
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
