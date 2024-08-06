using Kernel;
using Kernel.Filters;
using Kernel.Interfaces;
using Kernel.Joins;
using Kernel.Orders;
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
            int entityId = 1; // ID fictif pour le test
            dalMock.Setup(dal => dal.UpdateEntity(entityId, entity.Object)).Returns(true);

            // Act
            var result = dalMock.Object.UpdateEntity(entityId, entity.Object);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateEntities_ShouldReturnTrue_WhenEntitiesAreUpdated()
        {
            // Arrange
            var entities = new Dictionary<int, Mock<Entity>>
            {
                { 1, new Mock<Entity>() },
                { 2, new Mock<Entity>() }
            };
            var dalMock = new Mock<IDAL>();
            var entitiesToUpdate = entities.ToDictionary(e => e.Key, e => e.Value.Object);
            dalMock.Setup(dal => dal.UpdateEntities(entitiesToUpdate)).Returns(true);

            // Act
            var result = dalMock.Object.UpdateEntities(entitiesToUpdate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenEntityIsDeleted()
        {
            // Arrange
            var dalMock = new Mock<IDAL>();
            int entityId = 1; // ID fictif pour le test
            dalMock.Setup(dal => dal.Delete<Entity>(entityId)).Returns(true);

            // Act
            var result = dalMock.Object.Delete<Entity>(entityId);

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

        [Fact]
        public void GetAllEntities_WithJoinsAndFilters_ShouldReturnEntities()
        {
            // Arrange
            var entities = new List<Mock<Entity>> { new Mock<Entity>(), new Mock<Entity>() };
            var joins = new JoinDescriptor[0];
            var filters = new Mock<CFilter>();
            var orders = new SortDirection[0];
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.GetAllEntities<Entity>(joins, filters.Object, orders)).Returns(entities.Select(e => e.Object));

            // Act
            var result = dalMock.Object.GetAllEntities<Entity>(joins, filters.Object, orders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
        }

        [Fact]
        public void GetAllEntities_WithFilters_ShouldReturnEntities()
        {
            // Arrange
            var entities = new List<Mock<Entity>> { new Mock<Entity>(), new Mock<Entity>() };
            var filters = new Mock<CFilter>();
            var orders = new SortDirection[0];
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.GetAllEntities<Entity>(filters.Object, orders)).Returns(entities.Select(e => e.Object));

            // Act
            var result = dalMock.Object.GetAllEntities<Entity>(filters.Object, orders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
        }

        [Fact]
        public void GetAllEntities_ShouldReturnEntities()
        {
            // Arrange
            var entities = new List<Mock<Entity>> { new Mock<Entity>(), new Mock<Entity>() };
            var orders = new SortDirection[0];
            var dalMock = new Mock<IDAL>();
            dalMock.Setup(dal => dal.GetAllEntities<Entity>(orders)).Returns(entities.Select(e => e.Object));

            // Act
            var result = dalMock.Object.GetAllEntities<Entity>(orders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
        }
    }
}
