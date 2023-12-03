// See https://aka.ms/new-console-template for more information

using MonteHallCarlo.Models;

namespace MonteHallCarlo.Console;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Hello, World!");
        const int numberOfTestsToRun = 10000;

        System.Console.WriteLine($"Running {numberOfTestsToRun} tests where user does not change selection...");
        var numberFirstRunCorrect = 0;
        for(var i = 0; i < numberOfTestsToRun; i++)
        {
            if (RunGame(false))
            {
                numberFirstRunCorrect++;
            }
        }

        System.Console.WriteLine($"Running {numberOfTestsToRun} tests where user does change selection...");
        var numberSecondRunCorrect = 0;
        for(var i = 0; i < numberOfTestsToRun; i++)
        {
            if (RunGame(true))
            {
                numberSecondRunCorrect++;
            }
        }

        System.Console.WriteLine("Results:");
        System.Console.WriteLine($"Number of correct results without swapping: {numberFirstRunCorrect}");
        System.Console.WriteLine($"Number of correct results with swapping: {numberSecondRunCorrect}");
    }

    private static bool RunGame(bool swapChoice)
    {
        var game = new MonteHallGame();
        var randomUserSelection = GetRandomUserSelection();
        game.SetUserSelection(randomUserSelection);
        if (swapChoice)
        {
            game.SwapUserSelection();
        }

        return game.IsUserCorrect;
    }

    private static UserSelection GetRandomUserSelection()
    {
        var values = Enum.GetValues(typeof(UserSelection));
        var random = new Random();
        return (UserSelection)(values.GetValue(random.Next(values.Length)) ?? UserSelection.Second);
    }
    
}