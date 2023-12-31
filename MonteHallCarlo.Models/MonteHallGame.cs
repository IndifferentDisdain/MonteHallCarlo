namespace MonteHallCarlo.Models;

/// <summary>
/// Classic Monte Hall game. User picks one of 3 doors, where one is worth money.
/// User is told one option which is incorrect, and then asked if they want to swap
/// their pick to the other potential option.
/// After that, the user is shown if their chosen option is the correct one.
/// </summary>
public class MonteHallGame
{
    private readonly List<GameOption> _gameOptions = new(3)
    {
        new GameOption { UserSelection = UserSelection.First },
        new GameOption { UserSelection = UserSelection.Second },
        new GameOption { UserSelection = UserSelection.Third }
    };

    public MonteHallGame()
    {
        var correctSelection = GetRandomCorrectAnswer();
        var correctOption = _gameOptions.Single(x => x.UserSelection == correctSelection);
        correctOption.IsCorrect = true;
    }

    /// <summary>
    /// Gets the currently-selected user option.
    /// </summary>
    public GameOption? SelectedOption => _gameOptions.SingleOrDefault(x => x.IsSelected);

    /// <summary>
    /// Gets the correct option.
    /// </summary>
    public GameOption CorrectOption => _gameOptions.Single(x => x.IsCorrect);

    /// <summary>
    /// Gets if the current selected option is the correct option.
    /// </summary>
    public bool IsUserCorrect => SelectedOption == CorrectOption;

    /// <summary>
    /// Sets the user's selected option
    /// </summary>
    /// <param name="selection"></param>
    public void SetUserSelection(UserSelection selection)
    {
        var selectedOption = _gameOptions.Single(x => x.UserSelection == selection);
        selectedOption.IsSelected = true;
    }

    /// <summary>
    /// Swaps the user selection. Called after the user sees an option that is incorrect
    /// and is asked if they'd like to change their selection.
    /// </summary>
    public void SwapUserSelection()
    {
        var eliminatedOption = _gameOptions.First(x => x is { IsCorrect: false, IsSelected: false });
        foreach (var option in _gameOptions.Where(option => option != eliminatedOption))
        {
            option.IsSelected = !option.IsSelected;
        }
    }

    /// <summary>
    /// Only used for overriding the correct option for testing purposes.
    /// </summary>
    /// <param name="newCorrectOption">The new correct option</param>
    protected void SetCorrectOption(UserSelection newCorrectOption)
    {
        foreach (var option in _gameOptions)
        {
            option.IsCorrect = false;
        }

        _gameOptions.Single(x => x.UserSelection == newCorrectOption).IsCorrect = true;
    }

    private static UserSelection GetRandomCorrectAnswer()
    {
        var values = Enum.GetValues(typeof(UserSelection));
        var random = new Random();
        return (UserSelection)(values.GetValue(random.Next(values.Length)) ?? UserSelection.Second);
    }
}