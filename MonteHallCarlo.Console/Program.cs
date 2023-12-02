﻿// See https://aka.ms/new-console-template for more information

using MonteHallCarlo.Models;

namespace MonteHallCarlo.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Hello, World!");
        const int numberOfTestsToRun = 10000;

        System.Console.WriteLine($"Running {numberOfTestsToRun} tests where user does not change selection...");
        var numberFirstRunCorrect = 0;
        for(var i = 0; i < 10000; i++)
        {
            if (RunGame(false))
            {
                numberFirstRunCorrect++;
            }
        }

        System.Console.WriteLine("Running 10,0000 tests where user does change selection...");
        var numberSecondRunCorrect = 0;
        for(var i = 0; i < 10000; i++)
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
        var randomUserSelection = UserSelection.First;
        game.MakeUserSelection(randomUserSelection);
        if (swapChoice)
        {
            game.SwapUserSelection();
        }

        return game.IsUserCorrect;
    }
}