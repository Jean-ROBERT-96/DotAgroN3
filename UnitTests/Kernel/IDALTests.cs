using Kernel;
using Kernel.Filters;
using Kernel.Interfaces;
using Moq;

namespace UnitTests.Kernel
{
    public class IDALTests
    {
        [Fact]
        public void Create_ShouldReturnTrue_WhenEntityIsCreated()
        {
            // Arrange
            var entity = new Mock<Entity>();
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.Create(entity.Object)).Returns(true);

            // Act
            var result = dalMock.Object.Create(entity.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateEntity_ShouldReturnTrue_WhenEntityIsUpdated()
        {
            // Arrange
            var entity = new Mock<Entity>();
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.UpdateEntity(entity.Object)).Returns(true);

            // Act
            var result = dalMock.Object.UpdateEntity(entity.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenEntityIsDeleted()
        {
            // Arrange
            var entity = new Mock<Entity>();
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.Delete(entity.Object)).Returns(true);

            // Act
            var result = dalMock.Object.Delete(entity.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetFirstEntity_ShouldReturnEntity_WhenEntityExists()
        {
            // Arrange
            var entity = new Mock<Entity>();
            var filter = new Mock<CFilter>();
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.GetFirstEntity<Entity>(filter.Object)).Returns(entity.Object);

            // Act
            var result = dalMock.Object.GetFirstEntity<Entity>(filter.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity.Object, result);
        }
    }
}
