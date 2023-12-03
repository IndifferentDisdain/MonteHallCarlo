using MonteHallCarlo.Models;

namespace MonteHallCarlo.Tests;

public class MonteHallCarloTests
{
    [Theory]
    [InlineData(UserSelection.First, UserSelection.First, false, true)]
    [InlineData(UserSelection.First, UserSelection.First, true, false)]
    [InlineData(UserSelection.First, UserSelection.Second, false, false)]
    [InlineData(UserSelection.First, UserSelection.Third, true, true)]
    [InlineData(UserSelection.Second, UserSelection.Second, false, true)]
    [InlineData(UserSelection.Second, UserSelection.Second, true, false)]
    [InlineData(UserSelection.Second, UserSelection.Third, false, false)]
    [InlineData(UserSelection.Second, UserSelection.First, true, true)]
    [InlineData(UserSelection.Third, UserSelection.Third, false, true)]
    [InlineData(UserSelection.Third, UserSelection.Third, true, false)]
    [InlineData(UserSelection.Third, UserSelection.First, false, false)]
    [InlineData(UserSelection.Third, UserSelection.Second, true, true)]
    public void CorrectOption_HappyPath(UserSelection correctSelection, UserSelection userSelection, bool swapChoice, bool shouldBeCorrect)
    {
        // Arrange
        var game = new MonteHallGameTestOverride();
        
        // override for testing
        game.SetCorrectOptionOverride(correctSelection);

        // Act
        game.SetUserSelection(userSelection);
        if (swapChoice)
        {
            game.SwapUserSelection();
        }
        
        // Assert
        Assert.Equal(shouldBeCorrect, game.IsUserCorrect);
    }

    [Fact]
    public void SwapChoice()
    {
        // Arrange
        var game = new MonteHallGameTestOverride();
        game.SetCorrectOptionOverride(UserSelection.First);

        // Act
        game.SetUserSelection(UserSelection.First);
        game.SwapUserSelection();

        // Assert
        Assert.NotNull(game.SelectedOption);
        Assert.NotEqual(UserSelection.First, game.SelectedOption.UserSelection);
        Assert.Equal(UserSelection.First, game.CorrectOption.UserSelection);
        Assert.False(game.IsUserCorrect);
    }
}