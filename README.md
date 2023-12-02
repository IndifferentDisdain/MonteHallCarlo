# MonteHallCarlo
A Monte Carlo simulation to prove that swapping your answer in a Monte Hall-type game is the optimal choice.

In the classic Monte Hall game show, a contestant chooses among doors 1, 2, or 3, and behind one is a valuable prize, and garbage or perhaps a goat is behind the others.
Once the user makes their selection, the host shows them one of the options they didn't choose and was incorrect.
For example, if the contestant chooses door 1, and door 2 is correct, then the host shows you that door 3 is incorrect.
At that point, the host asks if you'd like to swap your choice, and then you're told if you're correct.

Hypothetically, a user would be more likely to be successful if they always swap the pick. 
The theory is that the user's first selection had a 1 in 3 chance of being correct.
When the user is told the incorrect option, that information is meaningless.
So, by swapping picks, the user is now choosing between two options and therefore has a higher chance of being correct.

To prove this, I first created a MonteHallGame class via TDD to model the game show.
Then, I created a Monte Carlo simulation to run 10,000 iterations of the game without swapping picks, and 10,000 iterations while swapping picks.

As of now, the theory is proving correct, but I may have a bug as my successful results are quite high, so I'm still looking into that.
Currently, the user is correct about a third of the time without swapping picks, but 2/3 of the time when swapping picks; I'd expect that second value to be closer to 50%.
So, either my code logic is incorrect, or my understanding of the problem is.
