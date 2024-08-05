using DAL;
using Kernel.Filters;
using Kernel;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.DAL
{
    public class MainDatabaseTests
    {
        //private readonly DataContext _context;
        //private readonly MainDatabase _mainDatabase;

        //public MainDatabaseTests()
        //{
        //    var options = new DbContextOptionsBuilder<DataContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDatabase")
        //        .Options;
        //    _context = new DataContext(options);
        //    _mainDatabase = new MainDatabase(_context);
        //}

        //[Fact]
        //public void Create_ShouldReturnTrue_WhenEntityIsCreated()
        //{
        //    // Arrange
        //    var entity = new Entity();

        //    // Act
        //    var result = _mainDatabase.Create(entity);

        //    // Assert
        //    Assert.True(result);
        //    Assert.Contains(entity, _context.Set<Entity>());
        //}

        //[Fact]
        //public void Delete_ShouldReturnTrue_WhenEntityIsDeleted()
        //{
        //    // Arrange
        //    var entity = new Entity();
        //    _context.Set<Entity>().Add(entity);
        //    _context.SaveChanges();

        //    // Act
        //    var result = _mainDatabase.Delete(entity);

        //    // Assert
        //    Assert.True(result);
        //    Assert.DoesNotContain(entity, _context.Set<Entity>());
        //}

        //[Fact]
        //public void UpdateEntity_ShouldReturnTrue_WhenEntityIsUpdated()
        //{
        //    // Arrange
        //    var entity = new Entity();
        //    _context.Set<Entity>().Add(entity);
        //    _context.SaveChanges();

        //    // Act
        //    var result = _mainDatabase.UpdateEntity(entity);

        //    // Assert
        //    Assert.True(result);
        //    Assert.Contains(entity, _context.Set<Entity>());
        //}

        //[Fact]
        //public void GetFirstEntity_ShouldReturnEntity_WhenEntityExists()
        //{
        //    // Arrange
        //    var entity = new Entity();
        //    _context.Set<Entity>().Add(entity);
        //    _context.SaveChanges();
        //    var filter = new CFilter();

        //    // Act
        //    var result = _mainDatabase.GetFirstEntity<Entity>(filter);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(entity, result);
        //}
    }
}
