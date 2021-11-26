using System;

namespace Helpers{
    class Colors{
        public static ConsoleColor randomColor(){
            ConsoleColor[] colors = {ConsoleColor.Red, 
                ConsoleColor.Yellow,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Magenta,
                ConsoleColor.Gray,
                ConsoleColor.White};

            return colors[(new Random()).Next(0, 4)];        
        }
    }
}
