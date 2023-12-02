using MonteHallCarlo.Models;

namespace MonteHallCarlo.Tests;

/// <summary>
/// Subclass of MonteHallGame to allow the test to specify
/// what the correct solution is, to aid in testing.
/// </summary>
public class MonteHallGameTestOverride : MonteHallGame
{
    /// <summary>
    /// Override the correct selection.
    /// </summary>
    /// <param name="selection">The correct selection.</param>
    public void SetCorrectOptionOverride(UserSelection selection)
    {
        SetCorrectOption(selection);
    }
}