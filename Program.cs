using System;
using System.Collections.Generic;

namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                RunQuest();
                Console.WriteLine("Be ye brave enough to quest again?? (Y/N): ");
            } while (Console.ReadLine()?.ToUpper() == "Y");
        }

        static void RunQuest()
        {
            // Create a list of all available challenges
            List<Challenge> allChallenges = new List<Challenge>()
            {
                new Challenge("2 + 2?", 4, 10),
                new Challenge("What's the answer to life, the universe and everything?", 42, 25),
                new Challenge("What is the current second?", DateTime.Now.Second, 50),
                new Challenge("What number am I thinking of?", new Random().Next(1, 11), 25),
                new Challenge("Who's your favorite Beatle?\n1) John\n2) Paul\n3) George\n4) Ringo", 4, 20),
                new Challenge("Defeat the dragon", new Random().Next(1, 21), 30),
                new Challenge("What's your favorite color?", "any", 20)
            };

            // Randomly select five challenges for the quest
            List<Challenge> questChallenges = new List<Challenge>();
            Random random = new Random();
            while (questChallenges.Count < 5)
            {
                int randomIndex = random.Next(allChallenges.Count);
                Challenge selectedChallenge = allChallenges[randomIndex];
                if (!questChallenges.Contains(selectedChallenge))
                {
                    questChallenges.Add(selectedChallenge);
                }
            }

            // Set the range for Awesomeness
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Ask for the adventurer's name
            Console.WriteLine("Hail, Adventurer. What be yer moniker?:");
            string name = Console.ReadLine();

            // Create an Adventurer with a robe and hat
            Robe colorfulRobe = new Robe("Emerald Green", 58);
            Hat magicalHat = new Hat(7);
            Adventurer theAdventurer = new Adventurer(name, colorfulRobe, magicalHat);
            Console.WriteLine(theAdventurer.GetDescription());
            int successfulChallenges = 0;
            // Loop through all the challenges and subject the Adventurer to them
            foreach (Challenge challenge in questChallenges)
            {
                if (challenge.Text.Contains("Defeat the dragon"))
                {
                    Console.WriteLine(Utility.GetDragonAscii());
                    Console.WriteLine(challenge.Text);
                    Console.WriteLine("Type 'roll' to roll the dice and defeat the dragon:");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "roll")
                    {
                        int chances = 5;
                        bool defeatedDragon = false;
                        while (chances > 0)
                        {
                            int roll = random.Next(1, 21);
                            Console.WriteLine($"You rolled: {roll}");
                            if (roll.CompareTo(challenge.correctAnswer) > 0)
                            {
                                defeatedDragon = true;
                                break;
                            }

                            chances--;
                        }
                        if (defeatedDragon)
                        {
                            Console.WriteLine("Congratulations! You defeated the dragon!");
                            theAdventurer.Awesomeness += challenge.awesomenessChange;
                            successfulChallenges++;
                        }
                        else
                        {
                            Console.WriteLine("You failed to defeat the dragon...");
                            theAdventurer.Awesomeness -= challenge.awesomenessChange;
                        }
                    }
                }
                else
                {
                    challenge.RunChallenge(theAdventurer);
                     if (theAdventurer.Awesomeness > 0)
                        successfulChallenges++;
                }
            }

            // Display the prize for the adventurer
            Prize prize = new Prize("Holy Grail");
            prize.ShowPrize(theAdventurer);

            // Evaluate the awesomeness level of the Adventurer
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
        }
    }

    class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < adventurer.Awesomeness; i++)
                {
                    Console.WriteLine(_text);
                }
            }
            else
            {
                Console.WriteLine("Oh, what a pity. No prize for you.");
            }
        }
    }
}

static class Utility
{
    public static string GetDragonAscii()
    {
        return @"
               __====-_  _-====__
       _--^^^#####//      \\#####^^^--_
    _-^##########// (    ) \\##########^-_
   -############//  |\^^/|  \\############-
 _/############//   (@::@)   \\############\_
/#############((     \\//     ))#############\
-###############\\    (oo)    //###############-
-#################\\  / "" \  //#################-
-###################\\/  ^  \//###################-
_#/|##########/\######(  ()  )######/\##########|\#_
|/ |#/\#/\#/\/  \#/\##\  /\  /##/\#/\#/\#/\/\#/\| \|
   |/  V  /  \V   /  V  \/  \/  V  \  /  \V   \| 
             V";
    }
}