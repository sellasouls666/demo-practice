using DemoLib.Order;
using DemoLib.Product;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    [TestClass]
    public class TOrderService
    {
        private Mock<IOrderRepository> _mockRepository;
        private OrderService _orderService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IOrderRepository>();
            _orderService = new OrderService(_mockRepository.Object);
        }

        [TestMethod]
        public void CheckArticul_ProductNotInAnyOrder_ReturnsFalse()
        {
            // Arrange
            var product = new Product("TEST123", "Test Product", "шт", 100, "TestSupplier",
                                     "TestManufacturer", "Category", 0, 10, "Description", "pic.jpg");

            var orders = new List<Order>
            {
                new Order
                {
                    id_ = 1,
                    orderProducts = new List<OrderProductRecord>
                    {
                        new OrderProductRecord { articul_ = "OTHER456", quantity_ = 2 }
                    }
                },
                new Order
                {
                    id_ = 2,
                    orderProducts = new List<OrderProductRecord>
                    {
                        new OrderProductRecord { articul_ = "OTHER789", quantity_ = 1 }
                    }
                }
            };

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            bool result = _orderService.CheckArticul(product);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckArticul_ProductExistsInOrder_ReturnsTrue()
        {
            // Arrange
            var product = new Product("TEST123", "Test Product", "шт", 100, "TestSupplier",
                                     "TestManufacturer", "Category", 0, 10, "Description", "pic.jpg");

            var orders = new List<Order>
            {
                new Order
                {
                    id_ = 1,
                    orderProducts = new List<OrderProductRecord>
                    {
                        new OrderProductRecord { articul_ = "OTHER456", quantity_ = 2 }
                    }
                },
                new Order
                {
                    id_ = 2,
                    orderProducts = new List<OrderProductRecord>
                    {
                        new OrderProductRecord { articul_ = "TEST123", quantity_ = 3 },
                        new OrderProductRecord { articul_ = "OTHER789", quantity_ = 1 }
                    }
                }
            };

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            bool result = _orderService.CheckArticul(product);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckArticul_EmptyOrderList_ReturnsFalse()
        {
            // Arrange
            var product = new Product("TEST123", "Test Product", "шт", 100, "TestSupplier",
                                     "TestManufacturer", "Category", 0, 10, "Description", "pic.jpg");

            var orders = new List<Order>();

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            bool result = _orderService.CheckArticul(product);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAllOrders_ReturnsListOfOrders()
        {
            // Arrange
            var expectedOrders = new List<Order>
            {
                new Order { id_ = 1, status_ = "Новый" },
                new Order { id_ = 2, status_ = "Завершен" },
                new Order { id_ = 3, status_ = "Новый" }
            };

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(expectedOrders);

            // Act
            var result = _orderService.GetAllOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(expectedOrders, result);
        }

        [TestMethod]
        public void GenerateNextId_WithExistingOrders_ReturnsMaxIdPlusOne()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { id_ = 5 },
                new Order { id_ = 3 },
                new Order { id_ = 10 },
                new Order { id_ = 7 }
            };

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            int result = _orderService.GenerateNextId();

            // Assert
            Assert.AreEqual(11, result); // Max id = 10, so 10 + 1 = 11
        }

        [TestMethod]
        public void GenerateNextId_WithEmptyOrderList_ReturnsOne()
        {
            // Arrange
            var orders = new List<Order>();

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            int result = _orderService.GenerateNextId();

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GenerateNextId_WithSingleOrder_ReturnsIdPlusOne()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { id_ = 42 }
            };

            _mockRepository.Setup(repo => repo.GetAllOrders()).Returns(orders);

            // Act
            int result = _orderService.GenerateNextId();

            // Assert
            Assert.AreEqual(43, result);
        }
    }
}
