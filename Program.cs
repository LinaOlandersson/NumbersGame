namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The loop goes on as long as the player wants to play.
            bool play = true;
            while (play)
            {
                /* Declaring the needed variables for the method and producing
                 * a random number.*/
                int[] guesses = new int[5];
                Random rnd = new Random();
                int rndNumber = rnd.Next(1, 21);

                //Calling method "PlayGame".
                PlayGame(guesses, rndNumber);

                Console.WriteLine("Vill du spela igen? j/n:");
                string playAgain = Console.ReadLine();

                // Checking to see wheather the player wants to play again or not.
                if (playAgain.ToUpper() == "J")
                {
                    Console.Clear();
                }
                else if (playAgain.ToUpper() == "N")
                {
                    Console.WriteLine("\nTack för den här gången!");
                    play = false;
                }
                else
                {
                    Console.WriteLine("Okänt svarsalternativ. Programmet stängs ner.");
                    play = false;
                }
            }
        }

        /*                   --------------PLAY GAME----------------
        This method gives the user five tries on guessing a random number. The program directs
        the user with 'too high' or 'too low' ands prints the number if the user runs out of
        guesses. */ 


        static void PlayGame(int[] guesses, int rndNumber)
        {
            Console.WriteLine("Välkommen! Jag tänker på ett nummer mellan 1 och 20. " +
                "Kan du gissa vilket? Du får fem försök."); 
            int counter = 0;
            
            /* A for loop that saves each guess to an array. Each wrong guess adds one
             * to the counter. If the counter reaches 5 the game ends. */
            for (int i = 0; i < 5; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out guesses[i]))
                {
                    Console.WriteLine("Det var ingen siffra. Försök igen!");
                }
                if (guesses[i] == rndNumber)
                {
                    Console.WriteLine($"Wohoo! Du klarade det på {i + 1} försök!");
                    break;
                }
                else if (guesses[i] < rndNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt!");
                    counter++;
                }
                else
                {
                    Console.WriteLine("Tyvärr, du gissade för högt!");
                    counter++;
                }
            }
            if (counter == 5)
            {
                Console.WriteLine($"\nTyvärr lyckades du inte gissa talet på fem försök. Talet var {rndNumber}.");
            }
        }

    }
}
