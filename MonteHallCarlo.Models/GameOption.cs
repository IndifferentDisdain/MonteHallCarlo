namespace MonteHallCarlo.Models;

public class GameOption
{
    public bool IsSelected {
        get;
        set;
    }

    public bool IsCorrect { get; set; }
    
    public UserSelection UserSelection {
        get;
        set;
    }
}