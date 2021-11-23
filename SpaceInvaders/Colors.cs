using System;

namespace Helpers{
    class ColorsHelper{
        public static ConsoleColor randomColor(){
            ConsoleColor[] colors = {ConsoleColor.Red, 
                ConsoleColor.Yellow,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Magenta};

            return colors[(new Random()).Next(0, 4)];        
        }
    }
}
