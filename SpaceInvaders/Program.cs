using System;
using Models;
using System.Threading;

namespace SpaceInvaders{
    class Program{
        //MAIN
        static void Main(string[] args){
            setup();
            Console.Clear();

            Spaceship myShip = new Spaceship();
            while(true){
                drawStage(myShip);
                myShip.draw(38, 18);

            }
        }

        static void setup(){
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.SetBufferSize(800, 800);
        }

        static void drawStage(Spaceship ship){
            for(int y=0; y<23; y++){
                for(int x=10; x<70; x++){
                    Console.SetCursorPosition(x, y);
                    
                    //SCORE
                    if(y == 2 && x == 14){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("SCORE: " + ship.getScore());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    //_
                    if(y == 19 && x > 13 && x < 66){
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("_");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    //LIVES
                    if(y == 21 && x == 13){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("LIVES: " + ship.getLives());
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    //CREDITS
                    if(y == 21 && x == 57){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("CREDITS: ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    //BORDER
                    if(y == 0 || y == 22 || x == 10 || x == 69){
                        Console.Write(".");
                    }
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        static ConsoleColor randomColor(){
            ConsoleColor[] colors = {ConsoleColor.Red, 
                ConsoleColor.Yellow,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Magenta};

            return colors[(new Random()).Next(0, 4)];        
        }

    }
}
