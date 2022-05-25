using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Exceptions;
using PizzeriaServer.Meals.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaServerTests
{
    [TestClass]
    public class PizzeriaServerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ToppingNotFoundException))]
        public void getWrongTopicID()
        {
            PizzaService pizzaService = new PizzaService( new PizzaQueryDaoMock());

            pizzaService.GetToppingById(2); 
        }

   
    }

}
