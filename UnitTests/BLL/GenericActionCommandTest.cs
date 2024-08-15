using BLL;
using DAL;

namespace UnitTests.BLL
{
    public class TestCommand : GenericActionCommand<TestEntity>
    {
        public TestCommand(GenericViewModel<TestEntity> viewModel) : base(viewModel) { }

        public override bool CanExecute() => true;

        public override bool Execute()
        {
            return true;
        }
    }

    public class GenericActionCommandTest
    {
        [Fact]
        public void Execute_ShouldUpdateDataContext()
        {
            // Arrange
            var viewModel = new TestViewModel
            {
                DataContext = new TestEntity { Id = 1, Data = "Test" }
            };
            var command = new TestCommand(viewModel);

            // Act
            var result = command.Execute();

            // Assert
            Assert.True(result);
            Assert.NotNull(viewModel.DataContext);
            Assert.Equal(1, viewModel.DataContext.Id);
            Assert.Equal("Test", viewModel.DataContext.Data);
        }
    }
}
