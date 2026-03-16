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
    public class TProductService
    {
        private Mock<IProductRepository> _mockRepository;
        private ProductService _productService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [TestMethod]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product("ART001", "Туфли мужские", "пара", 5000, "ООО Поставщик1", "Фабрика1", "Мужская обувь", 0, 10, "Описание1", "pic1.jpg"),
                new Product("ART002", "Сапоги женские", "пара", 7500, "ООО Поставщик2", "Фабрика2", "Женская обувь", 15, 5, "Описание2", "pic2.jpg"),
                new Product("ART003", "Кроссовки", "пара", 3500, "ООО Поставщик1", "Фабрика3", "Спортивная обувь", 10, 20, "Описание3", "pic3.jpg")
            };

            _mockRepository.Setup(repo => repo.GetAllProducts()).Returns(expectedProducts);

            // Act
            var result = _productService.GetAllProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(expectedProducts, result);
        }

        [TestMethod]
        public void GetAllProducts_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var expectedProducts = new List<Product>();

            _mockRepository.Setup(repo => repo.GetAllProducts()).Returns(expectedProducts);

            // Act
            var result = _productService.GetAllProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetAllSuppliers_WithProducts_ReturnsUniqueSuppliersWithAllSupplierOption()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("ART001", "Туфли мужские", "пара", 5000, "ООО Поставщик1", "Фабрика1", "Мужская обувь", 0, 10, "Описание1", "pic1.jpg"),
                new Product("ART002", "Сапоги женские", "пара", 7500, "ООО Поставщик2", "Фабрика2", "Женская обувь", 15, 5, "Описание2", "pic2.jpg"),
                new Product("ART003", "Кроссовки", "пара", 3500, "ООО Поставщик1", "Фабрика3", "Спортивная обувь", 10, 20, "Описание3", "pic3.jpg"),
                new Product("ART004", "Ботинки", "пара", 4500, "ООО Поставщик3", "Фабрика1", "Мужская обувь", 5, 8, "Описание4", "pic4.jpg")
            };

            _mockRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

            // Act
            var result = _productService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count); // "Все поставщики" + 3 уникальных поставщика
            Assert.AreEqual("Все поставщики", result[0]);
            Assert.IsTrue(result.Contains("ООО Поставщик1"));
            Assert.IsTrue(result.Contains("ООО Поставщик2"));
            Assert.IsTrue(result.Contains("ООО Поставщик3"));
            Assert.IsFalse(result.Contains("ООО Поставщик4")); // Несуществующий поставщик
        }

        [TestMethod]
        public void GetAllSuppliers_WithDuplicateSuppliers_ReturnsUniqueList()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product("ART001", "Туфли мужские", "пара", 5000, "ООО Поставщик1", "Фабрика1", "Мужская обувь", 0, 10, "Описание1", "pic1.jpg"),
                new Product("ART002", "Сапоги женские", "пара", 7500, "ООО Поставщик1", "Фабрика2", "Женская обувь", 15, 5, "Описание2", "pic2.jpg"),
                new Product("ART003", "Кроссовки", "пара", 3500, "ООО Поставщик2", "Фабрика3", "Спортивная обувь", 10, 20, "Описание3", "pic3.jpg"),
                new Product("ART004", "Ботинки", "пара", 4500, "ООО Поставщик1", "Фабрика1", "Мужская обувь", 5, 8, "Описание4", "pic4.jpg")
            };

            _mockRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

            // Act
            var result = _productService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); // "Все поставщики" + 2 уникальных поставщика
            Assert.AreEqual("Все поставщики", result[0]);

            // Подсчет количества вхождений каждого поставщика
            int countSupplier1 = 0;
            int countSupplier2 = 0;

            foreach (var supplier in result)
            {
                if (supplier == "ООО Поставщик1") countSupplier1++;
                if (supplier == "ООО Поставщик2") countSupplier2++;
            }

            Assert.AreEqual(1, countSupplier1); // Поставщик1 должен встречаться только один раз
            Assert.AreEqual(1, countSupplier2); // Поставщик2 должен встречаться только один раз
        }

        [TestMethod]
        public void GetAllSuppliers_EmptyProductList_ReturnsOnlyAllSupplierOption()
        {
            // Arrange
            var products = new List<Product>();

            _mockRepository.Setup(repo => repo.GetAllProducts()).Returns(products);

            // Act
            var result = _productService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Все поставщики", result[0]);
        }

        [TestMethod]
        public void AddProduct_CallsRepositoryAddProduct()
        {
            // Arrange
            var product = new Product("ART005", "Новый товар", "шт", 1000, "Новый поставщик",
                                     "Новый производитель", "Категория", 0, 15, "Описание", "pic.jpg");

            // Act
            _productService.AddProduct(product);

            // Assert
            _mockRepository.Verify(repo => repo.AddProduct(product), Times.Once);
        }

        [TestMethod]
        public void EditProduct_CallsRepositoryEditProduct()
        {
            // Arrange
            var product = new Product("ART001", "Обновленный товар", "шт", 1500, "Обновленный поставщик",
                                     "Обновленный производитель", "Обновленная категория", 10, 20, "Обновленное описание", "newpic.jpg");

            // Act
            _productService.EditProduct(product);

            // Assert
            _mockRepository.Verify(repo => repo.EditProduct(product), Times.Once);
        }

        [TestMethod]
        public void DeleteProduct_CallsRepositoryDeleteProduct()
        {
            // Arrange
            var product = new Product("ART001", "Товар для удаления", "шт", 1000, "Поставщик",
                                     "Производитель", "Категория", 0, 5, "Описание", "pic.jpg");

            // Act
            _productService.DeleteProduct(product);

            // Assert
            _mockRepository.Verify(repo => repo.DeleteProduct(product), Times.Once);
        }
    }
}
