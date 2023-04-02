using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OrderManagementTests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            int a = 1; int d = 200; string b = "13700k"; string c = "Intel";
            Order test = new Order(1, "13700k", "Intel", 200);
            Order.OrderService.Add(a, d, c, b);
            Assert.AreEqual(Order.OrderService.orders[0], test);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Order.OrderService.orders.Add(new Order(2, "13600k", "Intel", 150));
            Order.OrderService.Remove(2);
            Assert.IsNull(Order.OrderService.orders[0]);
        }

        [TestMethod()]
        public void AlterTest()
        {
            Order.OrderService.orders.Add(new Order(3, "13900k", "Intel", 300));
            Order.OrderService.Alter(3, 4, "13490f", "Intel", 125);
            Order test = new Order(4, "13490f", "Intel", 125);
            Assert.AreEqual(Order.OrderService.orders[0], test);
        }

        [TestMethod()]
        public void QueryTest()
        {
            Order.OrderService.orders.Add(new Order(5, "13790f", "Intel", 250));
            List<Order> orders = Order.OrderService.Query(1, 5, "13790f", "Intel", 250);
            Assert.IsNotNull(orders);
        }
    }
}