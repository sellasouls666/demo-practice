using DemoLib.Pickup;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    [TestClass]
    public class TPickupService
    {
        private Mock<IPickupRepository> _mockRepository;
        private PickupService _pickupService;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IPickupRepository>();
            _pickupService = new PickupService(_mockRepository.Object);
        }

        [TestMethod]
        public void GetPickupAddress_ValidId_ReturnsAddress()
        {
            // Arrange
            int pickupId = 5;
            string expectedAddress = "ул. Ленина, д. 10";

            _mockRepository.Setup(repo => repo.GetPickupAddress(pickupId))
                          .Returns(expectedAddress);

            // Act
            string result = _pickupService.GetPickupAddress(pickupId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedAddress, result);
        }

        [TestMethod]
        public void GetPickupAddress_InvalidId_ReturnsNull()
        {
            // Arrange
            int pickupId = 999;

            _mockRepository.Setup(repo => repo.GetPickupAddress(pickupId))
                          .Returns((string)null);

            // Act
            string result = _pickupService.GetPickupAddress(pickupId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllPickups_ReturnsListOfPickups()
        {
            // Arrange
            var expectedPickups = new List<Pickup>
            {
                new Pickup { id_ = 1, address_ = "ул. Ленина, д. 10" },
                new Pickup { id_ = 2, address_ = "пр. Мира, д. 25" },
                new Pickup { id_ = 3, address_ = "ул. Гагарина, д. 5" }
            };

            _mockRepository.Setup(repo => repo.GetAllPickups()).Returns(expectedPickups);

            // Act
            var result = _pickupService.GetAllPickups();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(expectedPickups, result);
        }

        [TestMethod]
        public void GetAllPickups_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var expectedPickups = new List<Pickup>();

            _mockRepository.Setup(repo => repo.GetAllPickups()).Returns(expectedPickups);

            // Act
            var result = _pickupService.GetAllPickups();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetPickupId_ExistingAddress_ReturnsCorrectId()
        {
            // Arrange
            string searchAddress = "пр. Мира, д. 25";
            var pickups = new List<Pickup>
            {
                new Pickup { id_ = 1, address_ = "ул. Ленина, д. 10" },
                new Pickup { id_ = 2, address_ = "пр. Мира, д. 25" },
                new Pickup { id_ = 3, address_ = "ул. Гагарина, д. 5" }
            };

            _mockRepository.Setup(repo => repo.GetAllPickups()).Returns(pickups);

            // Act
            int result = _pickupService.GetPickupId(searchAddress);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetPickupId_NonExistingAddress_ReturnsZero()
        {
            // Arrange
            string searchAddress = "ул. Пушкина, д. 1";
            var pickups = new List<Pickup>
            {
                new Pickup { id_ = 1, address_ = "ул. Ленина, д. 10" },
                new Pickup { id_ = 2, address_ = "пр. Мира, д. 25" }
            };

            _mockRepository.Setup(repo => repo.GetAllPickups()).Returns(pickups);

            // Act
            int result = _pickupService.GetPickupId(searchAddress);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
