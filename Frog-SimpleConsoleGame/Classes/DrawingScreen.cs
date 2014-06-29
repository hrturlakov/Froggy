using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frog_SimpleConsoleGame
{
    public class DrawingScreen
    {
        static bool playSound = true;
        private static List<KeyValuePair<long, string>> playersScores = new List<KeyValuePair<long, string>>();
        private const string scoreBoardPath = @"..\..\ScoreBoard.txt";

        public static void DrawMainScreen()
        {
            Console.Clear();

            string[] froggyPicture = new string[]
            {
                @"            _____________________                     ",
                @"            |###################|                     ",
                @"            |###################|                     ",
                @"            |###################|                     ",
                @"((-----------------------------------------           ",
                @"| \         /  /@@ \      /@@ \  \                    ",
                @" \ \,      /  (     )    (     )  \            _____  ",
                @"  \ \      |   \___/      \___/   |           /  __ \ ",
                @"   \   *-__/                      \           | |  | |",
                @"      *-_                          -_         | |     ",
                @"         \    -.  _________   .-   __ -.__.-((  ))    ",
                @"          \,    \^    U    ^/     /   -___--((  ))    ",
                @"            \,   \         /    /'            | |     ",
                @"             |    \       /   /'              | |     ",
                @"             |      -----     \               | |     ",
                @"            /                   *-._          | |     ",
                @"           /   /\          /*-._    \         | |     ",
                @"          /   /   \______/      /   /         | |     ",
                @"         /   /                 /   /          | |     ",
                @"        /. ./                  |. .|                  ",
                @"       /  | |                  / | \                  ",
                @"      /   |  \                /  |  \                 ",
                @"     /.-./.-.|               /.-.|.-.\                "
            };

            string[] froggerText = new string[]
            {
                @"  .----------------------------------------------------------------.  ",
                @" /  .-.    ______ _____   ____   _____  _____ ______ _____     .-.  \ ",
                @"|  /   \  |  ____|  __ \ / __ \ / ____|/ ____|  ____|  __ \   /   \  |",
                @"| |\_.  | | |__  | |__) | |  | | |  __| |  __| |__  | |__) | |    /| |",
                @"|\|  | /| |  __| |  _  /| |  | | | |_ | | |_ |  __| |  _  /  |\  | |/|",
                @"| `---' | | |    | | \ \| |__| | |__| | |__| | |____| | \ \  | `---' |",
                @"|       | |_|    |_|  \_\\____/ \_____|\_____|______|_|  \_\ |       |",
                @"|       |----------------------------------------------------|       |",
                @"\       |                                                    |       /",
                @" \     /                                                      \     / ",
                @"  `---'                                                        `---'  ",  
            };

            string[] navigationInstructions = new string[]
            {
                "PRESS ENTER TO START THE GAME",
                "",
                "PRESS F1 FOR INSTRUCTIONS",
                "PRESS F2 FOR SCOREBOARD",
                "PRESS Q TO QUIT"
            };

            Console.SetCursorPosition(0, (MainProgram.MaxHeight - froggyPicture.Length - froggerText.Length - navigationInstructions.Length) / 2);

            Console.ForegroundColor = ConsoleColor.Green;
            PrintStringArray(froggyPicture);
            PrintStringArray(froggerText);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintStringArray(navigationInstructions);
            if (playSound)
            {
                Sounds.MainMenuSound(false);
            }

            Navigation();
        }

        private static void Navigation()
        {
            Console.CursorVisible = false;

            ConsoleKeyInfo cki;
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                {
                    Sounds.MainMenuSound(true);
                    Sounds.OverTheGameSound();
                    break;
                }
                else if (cki.Key == ConsoleKey.F1)
                {
                    DrawInfoScreen();
                    return;
                }
                else if (cki.Key == ConsoleKey.F2)
                {
                    DrawScoreBoard();
                    return;
                }
                else if (cki.Key == ConsoleKey.Escape)
                {
                    playSound = false;
                    DrawMainScreen();
                    return;
                }
                else if (cki.Key == ConsoleKey.Q)
                {
                    Console.Clear();
                    Environment.Exit(1);
                }
            }
        }

        public static void DrawInfoScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            string[] instructions = new string[]
            {
	            "GAME INSTRUCTIONS",
	            "```````````````````````",
	            "THE GOAL OF THE GAME IS TO PLACE SAFELY A FROG IN EVERY FROG HOUSE",
                " ",
	            "THE JOURNEY START FROM THE BOTTOM OF THE SCREEN ",
                " ",
                "ALL THE WAY TO TOP OF THE SCREEN TO THE FROG HOUSES",
                " ",
                "BUT WATCH OUT THERE ARE MANY DANGERS OUT THERE ON THE WAY TO HOME",
                " ",
                " ",
                " "
            };
            
            string[] gameControls = new string[]
            {
	            "GAME CONTROLS",
	            "```````````````````",
	            "LEFT ARROW TO MOVE LEFT",
                " ",
	            "RIGHT ARROW TO MOVE RIGHT",
                " ",
	            "UP ARROW TO MOVE UP",
                " ",
	            "DOWN ARROW TO MOVE DOWN",
                " ",
	            "SPACEBAR TO PAUSE THE GAME",
                " ",
	            "ESCAPE TO EXIT THE GAME",
                " ",
                " ",
                " "
            };

            string[] scoringTable = new string[]
            {
	            "SCORING TABLE",
	            "```````````````````",
	            "10 PTS FOR EACH STEP",
                " ",
	            "50 PTS FOR EVERY SAFELY ARRIVED FROG",
                " ",
	            "1000 PTS FOR SAVING ALL THE FIVE FROGS",
                " ",
                "10 PTS FOR EVERY REMAINING SECOND",
                " ",
                " ",
                " ",
                "PRESS ESCAPE TO GO BACK"
            };

            Console.SetCursorPosition(0, (MainProgram.MaxHeight - instructions.Length - gameControls.Length - scoringTable.Length) / 2);

            PrintStringArray(instructions);
            PrintStringArray(gameControls);
            PrintStringArray(scoringTable);

            Navigation();
        }

        public static void LevelComplete(int points)
        {
            string[] levelComplete = new string[]
            {
            @"             .__                         .__                ",
            @"             |  |    ____ ___  __  ____  |  |               ",
            @"             |  |  _/ __ \\  \/ /_/ __ \ |  |               ",
            @"             |  |__\  ___/ \   / \  ___/ |  |__             ",
            @"             |____/ \___  > \_/   \___  >|____/             ",
            @"                        \/            \/                    ",
            @"                                .__            __           ",
            @"  ____   ____    _____  ______  |  |    ____ _/  |_   ____  ",
            @"_/ ___\ /  _ \  /     \ \____ \ |  |  _/ __ \\   __\_/ __ \ ",
            @"\  \___(  <_> )|  Y Y  \|  |_> >|  |__\  ___/ |  |  \  ___/ ",
            @" \___  >\____/ |__|_|  /|   __/ |____/ \___  >|__|   \___  >",
            @"     \/              \/ |__|               \/            \/ "
            };

            Console.Clear();
            PrintStringArray(levelComplete);
            Console.WriteLine("\n\n\n");
            Console.WriteLine("You got {0} points.", points);
            Sounds.LevelClear();
        }

        public static void GameOver(int points)
        {           
            string[] gameOver = new string[]
            {
            @"   _________    _____   ____     _______  __ ___________ ",
            @"  / ___\__  \  /     \_/ __ \   /  _ \  \/ // __ \_  __ \",
            @" / /_/  > __ \|  Y Y  \  ___/  (  <_> )   /\  ___/|  | \/",
            @" \___  (____  /__|_|  /\___  >  \____/ \_/  \___  >__|   ",
            @"/_____/     \/      \/     \/                   \/       "
            };

            Console.Clear();
            PrintStringArray(gameOver);
            Console.WriteLine("\n\n\n");
            Console.WriteLine("You got {0} points.", points);
            Sounds.GameOverSound();
        }

        public static void DrawScoreBoard()
        {
            ReadFromTxt();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(0, 0);
            string[] scoreBoardPicture = new string[]
                {
                    @"                                                                      ",
                    @"  _____  _____ ____  _____  ______ ____   ____          _____  _____  ",
                    @" / ____|/ ____/ __ \|  __ \|  ____|  _ \ / __ \   /\   |  __ \|  __ \ ",
                    @"| (___ | |   | |  | | |__) | |__  | |_) | |  | | /  \  | |__) | |  | |",
                    @" \___ \| |   | |  | |  _  /|  __| |  _ <| |  | |/ /\ \ |  _  /| |  | |",
                    @" ____) | |___| |__| | | \ \| |____| |_) | |__| / ____ \| | \ \| |__| |",
                    @"|_____/ \_____\____/|_|  \_\______|____/ \____/_/    \_\_|  \_\_____/ ",
                    @"                                                                      ",
                    @"  .----------------------------------------------------------------.  ",
                    @" /  .-.                                                        .-.  \ ",
                    @"|  /   \                                                      /   \  |",
                    @"| |\_.  |       ,----,----------------,--------------,       |    /| |",
                    @"|\|  | /|       |RANK| Nickname       |    POINTS    |       |\  | |/|",
                    @"| `---' |       |----|----------------|--------------|       | `---' |",
                    @"|       |       |  1 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  2 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  3 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  4 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  5 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  6 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  7 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  8 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       |  9 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       |----|----------------|--------------|       |       |",
                    @"|       |       | 10 | aaaaaaaaaaaaaa | aaaaaaaaaaaa |       |       |",
                    @"|       |       `----`----------------`--------------`       |       |",
                    @"|       |                                                    |       |",
                    @"|       |----------------------------------------------------|       |",
                    @"\       |                                                    |       /",
                    @" \     /                                                      \     / ",
                    @"  `---'                                                        `---'  ",
                    @"PRESS ENTER TO START THE GAME",
                    @" ",
                    @"PRESS F1 FOR INSTRUCTIONS",
                    @"PRESS F2 FOR SCOREBOARD",
                    @"PRESS Q TO QUIT"
                };
            int index = 0;
            for (int i = 0; i < scoreBoardPicture.Length; i++)
            {
                if (scoreBoardPicture[i].Contains("aaaaaaaaaaaa"))
                {
                    string key = playersScores[index].Key.ToString();
                    string value = playersScores[index].Value;
                    scoreBoardPicture[i] = scoreBoardPicture[i].Remove(23, 14);
                    scoreBoardPicture[i] = scoreBoardPicture[i].Insert(23, value.PadLeft(14, ' '));

                    scoreBoardPicture[i] = scoreBoardPicture[i].Remove(40, 12);
                    scoreBoardPicture[i] = scoreBoardPicture[i].Insert(40, key.PadLeft(12, ' '));
                    index++;
                }
            }
            PrintStringArray(scoreBoardPicture);

            Navigation();
        }

        private static void PrintStringArray(string[] stringArray)
        {
            foreach (var text in stringArray)
            {
                int whiteSpaces = (MainProgram.MaxWidth + text.Length) / 2;
                Console.WriteLine(text.PadLeft(whiteSpaces), 'a');
            }
        }

        public static void ReadFromTxt()
        {
            //create txt if the doesn't exist
            if (!File.Exists(scoreBoardPath))
            {
                CreateTxt();
            }
            //read from txt to dictionary
            playersScores.Clear();
            StreamReader reader = new StreamReader(scoreBoardPath);
            using (reader)
            {
                for (int i = 0; i < 10; i++)
                {
                    string line = reader.ReadLine();
                    string[] temp = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    playersScores.Add(new KeyValuePair<long, string>(long.Parse(temp[0]), temp[1]));
                }
            }
        }

        public static void WritePointsToTxt(long score)
        {
            Console.SetCursorPosition(25, 25);
            Console.Write("Enter your nickname: ");
            string nickname = Console.ReadLine();
            if (nickname == "")
            {
                nickname = "no name";
            }
            if (nickname.Length > 14)
            {
                nickname.Remove(14, nickname.Length - 14);
            }
            
            //read to dictionary
            ReadFromTxt();

            //add the score to dictionary
            playersScores.Add(new KeyValuePair<long, string>(score, nickname));

            //sort the list
            playersScores.Sort((x, y) => y.Key.CompareTo(x.Key));

            //remove last score from dictionary
            playersScores.Remove(playersScores.Last());

            //write to txt
            using (StreamWriter sw = new StreamWriter(scoreBoardPath))
            {
                foreach (var item in playersScores)
                {
                    sw.Write(item.Key.ToString());
                    sw.Write(",");
                    sw.Write(item.Value);
                    sw.WriteLine();
                }
            }

        }

        public static void CreateTxt()
        {
            TextWriter tw = File.CreateText(scoreBoardPath);
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.WriteLine("0,aaaaaaaaaaaaaa");
            tw.Close();
        }

        public static void Information(int lives, Stopwatch time , int points)
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Time : {0}            Lives : {1}          Points : {2}", time.Elapsed, lives, points);
        }
    }
}
