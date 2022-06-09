using Microsoft.VisualStudio.TestTools.UnitTesting;

using PizzeriaServer.Meals.Exceptions;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Meals.Services;
using System;
using System.Collections.Generic;

namespace PizzeriaServerTests
{
    [TestClass]
    public class PizzeriaServerTests
    {
        PizzaService pizzaService = new PizzaService(new PizzaQueryDaoMock());


        [TestMethod]
        public void get_pizza_by_choosing_correct_ID_should_pass()
        {

            var expected = pizzaService.GetPizzaById(1);
            Assert.AreEqual(1, expected.Id);


        }

        [TestMethod]
        [ExpectedException(typeof(PizzaNotFoundException))]
        public void get_pizza_by_choosing_correct_ID_should_throw_exception()
        {

            pizzaService.GetPizzaById(2);

        }
        [TestMethod]
        public void get_topping_by_choosing_correct_ID_should_pass()
        {

            var expected = pizzaService.GetToppingById(1);
            Assert.AreEqual(1, expected.Id);


        }

        [TestMethod]
        [ExpectedException(typeof(ToppingNotFoundException))]
        public void get_topping_by_choosing_wrong_ID_should_throw_exception()
        {
            pizzaService.GetToppingById(2);
        }

        [TestMethod]
        [ExpectedException(typeof(ToppingNotFoundException))]
        public void get_topping_by_choosing_NaN_ID_should_throw_exception()


        {
            pizzaService.GetToppingById('s');
        }
        [TestMethod]
        public void check_if_pizzas_are_list_should_be_list()
        {
            var expected = pizzaService.GetPizzas();
            Assert.IsInstanceOfType(expected, typeof(List<Pizza>));
        }


        [TestMethod]
        public void check_if_toppings_are_list_should_be_list()
        {
            var expected = pizzaService.GetToppingsForPizza(1);
            Assert.IsInstanceOfType(expected, typeof(List<Topping>));
        }
    }
}
