using System;
using System.Media;

namespace Frog_SimpleConsoleGame
{
    public class Sounds
    {
        public static void GameOverSound()
        {
            SoundPlayer player = new SoundPlayer(@"..\..\music\16-game-over.wav");
            player.Play();
            SoundPlayer a = new SoundPlayer();
        }
        public static void OverTheGameSound()
        {
            SoundPlayer player = new SoundPlayer(@"..\..\music\02-wild-plains.wav");
            player.PlayLooping();
        }
        public static void MainMenuSound(bool isOn)
        {
            SoundPlayer player = new SoundPlayer(@"..\..\music\02-overworld.wav");
            if (isOn)
            {
                player.Stop();
            }
            else
            {
                player.PlayLooping();   
            }         
        }
        public static void LevelClear()
        {
            SoundPlayer player = new SoundPlayer(@"..\..\music\08-round-clear-.wav");
            player.Play();
        }
        public static void JumpSound()
        {
            Console.Beep(700, 10);
        }
        public static void End()
        {
            SoundPlayer player = new SoundPlayer(@"..\..\music\End.wav");
            player.Play();
            System.Threading.Thread.Sleep(700);
        }
    }
}
