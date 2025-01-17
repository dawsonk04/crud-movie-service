﻿using DRK.DVDCentral.BL.Models;

namespace DRK.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(3, OrderManager.Load().Count);
        }

        [TestMethod]

        public void InsertTest1()
        {
            int id = 0;
            int results = OrderManager.Insert(1, DateTime.Now, 1, DateTime.Now, ref id, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]

        public void InsertTest2()
        {
            int result = 0;
            Order order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                UserId = 1,
                ShipDate = DateTime.Now,



            };
            int results = OrderManager.Insert(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void UpdateTest()
        {
            int result = 0;
            Order order = OrderManager.LoadById(3);
            order.CustomerId = 1;
            order.OrderDate = DateTime.Now;
            order.UserId = 1;
            order.ShipDate = DateTime.Now;

            int results = OrderManager.Update(order, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            int results = OrderManager.Delete(3, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void InsertOrderItemsTest()
        {
            Order order = new Order
            {
                CustomerId = 99,
                OrderDate = DateTime.Now,
                UserId = 99,
                ShipDate = DateTime.Now,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 99,
                        MovieId = 1,
                        Cost = 9.99,
                        Quantity = 9
                    },
                    new OrderItem
                    {
                        Id = 99,
                        MovieId = 2,
                        Cost = 8.88,
                        Quantity = 2
                    }
                }

            };
            int result = OrderManager.Insert(order, true);
            Assert.AreEqual(order.OrderItems[1].OrderId, order.Id);
            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void LoadByIdTest()
        {
            int id = OrderManager.Load().LastOrDefault().Id;
            Order order = OrderManager.LoadById(id);
            Assert.AreEqual(order.Id, id);
            Assert.IsTrue(order.OrderItems.Count > 0);
        }

        [TestMethod]

        public void LoadByIdCustomerIdTest()
        {
            int orderId = OrderItemManager.Load().FirstOrDefault().OrderId;
            //Assert.IsTrue(OrderItemManager.LoadbyOrderId(orderId).Count > 0);
        }



    }
}
