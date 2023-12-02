namespace MonteHallCarlo.Models;

/// <summary>
/// Classic Monte Hall game. User picks one of 3 doors, where one is worth money.
/// User is told which option is incorrect, and then asked if they want to swap
/// their pick to the other potential option.
/// After that, the user is shown if their chosen option is the correct one.
/// </summary>
public class MonteHallGame
{
    private readonly List<GameOption> _gameOptions = new(3)
    {
        new GameOption { UserSelection = UserSelection.First},
        new GameOption {UserSelection = UserSelection.Second},
        new GameOption {UserSelection = UserSelection.Third}
    };

    public MonteHallGame()
    {
        var correctSelection = GetRandomCorrectAnswer();
        var correctOption = _gameOptions.Single(x => x.UserSelection == correctSelection);
        correctOption.IsCorrect = true;
    }

    public GameOption? SelectedOption => _gameOptions.SingleOrDefault(x => x.IsSelected);

    public GameOption CorrectOption => _gameOptions.Single(x => x.IsCorrect);

    public bool IsUserCorrect => SelectedOption == CorrectOption;

    public void MakeUserSelection(UserSelection selection)
    {
        var selectedOption = _gameOptions.Single(x => x.UserSelection == selection);
        selectedOption.IsSelected = true;
    }

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

    private UserSelection GetRandomCorrectAnswer()
    {
        var values = Enum.GetValues(typeof(UserSelection));
        var random = new Random();
        return (UserSelection)(values.GetValue(random.Next(values.Length)) ?? UserSelection.Second);
    }
    
}