using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

using System.IO;
using System.Media;

namespace SnakeGame
{
    internal class Sounds
    {
        public readonly static SoundPlayer GameOver = LoadSound("GameOver.wav");
        public readonly static SoundPlayer Eat = LoadSound("Eat.wav");
        public readonly static SoundPlayer BadEat = LoadSound("hit.wav");
        public readonly static SoundPlayer Fone = LoadSound("Fone.wav");


        private static SoundPlayer LoadSound(string fileName)
        {
            
           

            return new SoundPlayer($"{fileName}");
        }
    }
}
