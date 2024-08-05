using Kernel.Interfaces;
using Kernel;
using Moq;

namespace UnitTests.Kernel
{
    public class ServicesManagerTests
    {
        [Fact]
        public void Initialize_ShouldSetDatabase()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            var dalMock = new Mock<IDAL>();
            serviceProviderMock.Setup(sp => sp.GetService(typeof(IDAL))).Returns(dalMock.Object);

            // Act
            ServicesManager.Initialize(serviceProviderMock.Object);
            var result = ServicesManager.DataBase;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Mock<IDAL>>(dalMock);
        }
    }
}
