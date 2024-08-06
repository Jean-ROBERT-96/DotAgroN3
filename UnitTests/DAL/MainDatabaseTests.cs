using DAL;
using Kernel.Filters;
using Kernel.Joins;
using Kernel.Orders;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.DAL
{


    public class TestDataContext : DataContext
    {
        public TestDataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TestEntity>().ToTable("test_entity");
        }
    }

    public class MainDatabaseTests
    {
        private DbContextOptions<DataContext> _options;
        private TestDataContext _context;
        private MainDatabase _mainDatabase;

        public MainDatabaseTests()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private void Init()
        {
            _context = new TestDataContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _mainDatabase = new MainDatabase(_context);
        }

        [Fact]
        public void Create_ShouldReturnTrue_WhenEntityIsCreated()
        {
            // Arrange
            this.Init();
            var entity = new TestEntity
            {
                Data = "Test Data"
            };

            // Act
            var result = _mainDatabase.Create(entity);

            // Assert
            Assert.True(result);
            Assert.NotNull(_context.Set<TestEntity>().Find(entity.Id));
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenEntityIsDeleted()
        {
            // Arrange
            this.Init();
            var entity = new TestEntity
            {
                Data = "Test Data"
            };
            _context.Set<TestEntity>().Add(entity);
            _context.SaveChanges();

            // Act
            var result = _mainDatabase.Delete<TestEntity>(entity.Id);

            // Assert
            Assert.True(result);
            Assert.Null(_context.Set<TestEntity>().Find(entity.Id));
        }

        [Fact]
        public void UpdateEntity_ShouldReturnTrue_WhenEntityIsUpdated()
        {
            // Arrange
            this.Init();
            var entity = new TestEntity
            {
                Data = "Test Data"
            };
            _context.Set<TestEntity>().Add(entity);
            _context.SaveChanges();
            entity = _context.Set<TestEntity>().First();

            // Act
            entity.Data = "Updated Data";
            var result = _mainDatabase.UpdateEntity<TestEntity>(entity.Id, entity);

            // Assert
            Assert.True(result);
            var updatedEntity = _context.Set<TestEntity>().Find(entity.Id);
            Assert.NotNull(updatedEntity);
            Assert.Equal("Updated Data", updatedEntity.Data);
        }

        [Fact]
        public void UpdateEntities_ShouldReturnTrue_WhenEntitiesAreUpdated()
        {
            // Arrange
            this.Init();
            var entities = new Dictionary<int, TestEntity>
            {
                { 1, new TestEntity { Data = "Data 1" } },
                { 2, new TestEntity { Data = "Data 2" } }
            };
            foreach (var entity in entities.Values)
            {
                _context.Set<TestEntity>().Add(entity);
            }
            _context.SaveChanges();

            // Act
            entities[1].Data = "Updated Data 1";
            entities[2].Data = "Updated Data 2";
            var result = _mainDatabase.UpdateEntities(entities);

            // Assert
            Assert.True(result);
            Assert.Equal("Updated Data 1", _context.Set<TestEntity>().Find(1).Data);
            Assert.Equal("Updated Data 2", _context.Set<TestEntity>().Find(2).Data);
        }

        [Fact]
        public void GetFirstEntity_ShouldReturnEntity_WhenEntityExists()
        {
            // Arrange
            this.Init();
            var entity = new TestEntity
            {
                Data = "Test Data"
            };
            _context.Set<TestEntity>().Add(entity);
            _context.SaveChanges();

            var filter = TestEntity._Id.Equal(1);

            // Act
            var result = _mainDatabase.GetFirstEntity<TestEntity>();
            var result2 = _mainDatabase.GetFirstEntity<TestEntity>(filter);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result2);
            Assert.Equal(entity, result);
            Assert.Equal(entity, result2);
        }

        [Fact]
        public void GetAllEntities_WithJoinsAndFilters_ShouldReturnEntities()
        {
            // Arrange
            this.Init();
            var entities = new List<TestEntity>
            {
                new TestEntity { Data = "Data 1" },
                new TestEntity { Data = "Data 2" }
            };
            _context.Set<TestEntity>().AddRange(entities);
            _context.SaveChanges();

            var joins = new JoinDescriptor[0];
            var filters = TestEntity._Id.Equal(1);
            var orders = new SortDirection[0];

            // Act
            var result = _mainDatabase.GetAllEntities<TestEntity>(joins, filters, orders);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetAllEntities_WithFilters_ShouldReturnEntities()
        {
            // Arrange
            this.Init();
            var entities = new List<TestEntity>
            {
                new TestEntity { Data = "Data 1" },
                new TestEntity { Data = "Data 2" }
            };
            _context.Set<TestEntity>().AddRange(entities);
            _context.SaveChanges();

            var filters = TestEntity._Id.Equal(1);
            var orders = new SortDirection[0];

            // Act
            var result = _mainDatabase.GetAllEntities<TestEntity>(filters, orders);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void GetAllEntities_ShouldReturnEntities()
        {
            // Arrange
            this.Init();
            var entities = new List<TestEntity>
            {
                new TestEntity { Data = "Data 1" },
                new TestEntity { Data = "Data 2" }
            };
            _context.Set<TestEntity>().AddRange(entities);
            _context.SaveChanges();

            var orders = new SortDirection[0];

            // Act
            var result = _mainDatabase.GetAllEntities<TestEntity>(orders);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities.Count, result.Count());
        }
    }
}
