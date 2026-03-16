using DemoLib.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    [TestClass]
    public class TUserService
    {
        private Mock<IUserRepository> _mockRepository;
        private UserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();

            // Используем рефлексию для внедрения mock-репозитория
            _userService = new UserService();
            var fieldInfo = typeof(UserService).GetField("repository_",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            fieldInfo.SetValue(_userService, _mockRepository.Object);
        }

        [TestMethod]
        public void GetUserByLogin_ExistingLogin_ReturnsUser()
        {
            // Arrange
            string login = "ivanov";
            var expectedUser = new User("Менеджер", "Иванов Иван", login, "password123");

            _mockRepository.Setup(repo => repo.GetUserByLogin(login))
                          .Returns(expectedUser);

            // Act
            var result = _userService.GetUserByLogin(login);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, result);
            Assert.AreEqual("ivanov", result.login_);
            Assert.AreEqual("Иванов Иван", result.fio_);
            Assert.AreEqual("Менеджер", result.role_);
        }

        [TestMethod]
        public void GetUserByLogin_NonExistingLogin_ReturnsNull()
        {
            // Arrange
            string login = "nonexistent";

            _mockRepository.Setup(repo => repo.GetUserByLogin(login))
                          .Returns((User)null);

            // Act
            var result = _userService.GetUserByLogin(login);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserByLogin_EmptyLogin_ReturnsNull()
        {
            // Arrange
            string login = "";

            _mockRepository.Setup(repo => repo.GetUserByLogin(login))
                          .Returns((User)null);

            // Act
            var result = _userService.GetUserByLogin(login);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUsersLogins_WithMultipleUsers_ReturnsListOfLogins()
        {
            // Arrange
            var users = new List<User>
            {
                new User("Администратор", "Петров Петр", "petrov", "pass1"),
                new User("Менеджер", "Иванов Иван", "ivanov", "pass2"),
                new User("Клиент", "Сидорова Анна", "sidorova", "pass3"),
                new User("Клиент", "Козлов Алексей", "kozlov", "pass4")
            };

            _mockRepository.Setup(repo => repo.GetAllUsers()).Returns(users);

            // Act
            var result = _userService.GetUsersLogins();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("petrov", result[0]);
            Assert.AreEqual("ivanov", result[1]);
            Assert.AreEqual("sidorova", result[2]);
            Assert.AreEqual("kozlov", result[3]);
        }

        [TestMethod]
        public void GetUsersLogins_EmptyUserList_ReturnsEmptyList()
        {
            // Arrange
            var users = new List<User>();

            _mockRepository.Setup(repo => repo.GetAllUsers()).Returns(users);

            // Act
            var result = _userService.GetUsersLogins();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetUsersLogins_WithDuplicateLogins_ReturnsAllIncludingDuplicates()
        {
            // Arrange
            var users = new List<User>
            {
                new User("Администратор", "Петров Петр", "petrov", "pass1"),
                new User("Менеджер", "Иванов Иван", "ivanov", "pass2"),
                new User("Клиент", "Сидорова Анна", "sidorova", "pass3"),
                new User("Клиент", "Петров Петр", "petrov", "pass4") // Дубликат логина
            };

            _mockRepository.Setup(repo => repo.GetAllUsers()).Returns(users);

            // Act
            var result = _userService.GetUsersLogins();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count); // Должны быть все, включая дубликаты
            Assert.AreEqual("petrov", result[0]);
            Assert.AreEqual("ivanov", result[1]);
            Assert.AreEqual("sidorova", result[2]);
            Assert.AreEqual("petrov", result[3]); // Дубликат сохраняется
        }
    }
}
