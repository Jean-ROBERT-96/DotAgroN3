using BLL;
using Moq;

namespace UnitTests.BLL
{
    public class TestViewModel : GenericViewModel<TestEntity>
    {
        public override bool IsModified(TestEntity oldValue) => !DataContext.Equals(oldValue);
    }

    public class GenericViewModelTest
    {
        [Fact]
        public void ExecuteCommand_ShouldReturnTrue_WhenCommandCanExecute()
        {
            // Arrange
            var viewModel = new TestViewModel();
            viewModel.DataContext = new TestEntity { Id = 1, Data = "Test" };
            var mockCommand = new Mock<TestCommand>(viewModel);
            mockCommand.Setup(c => c.CanExecute()).Returns(true);
            mockCommand.Setup(c => c.Execute()).Returns(true);

            // Act
            var result = viewModel.ExecuteCommand(mockCommand.Object);

            // Assert
            Assert.True(result);
            mockCommand.Verify(c => c.Execute(), Times.Once);
        }

        [Fact]
        public void ExecuteCommand_ShouldReturnFalse_WhenCommandCannotExecute()
        {
            // Arrange
            var viewModel = new TestViewModel();
            viewModel.DataContext = new TestEntity { Id = 1, Data = "Test" };
            var mockCommand = new Mock<TestCommand>(viewModel);
            mockCommand.Setup(c => c.CanExecute()).Returns(false);

            // Act
            var result = viewModel.ExecuteCommand(mockCommand.Object);

            // Assert
            Assert.False(result);
            mockCommand.Verify(c => c.Execute(), Times.Never);
        }
    }
}
