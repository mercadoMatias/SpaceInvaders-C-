using System;
using Models;
using Helpers;
using System.Threading;

namespace SpaceInvaders{
    class Program{
        const char LEFT = 'a';
        const char RIGHT = 'd';
        const char SHOOT = 'l';

        //MAIN
        static void Main(string[] args){
            setup();

            //Objects
            Spaceship myShip = new Spaceship();
            Bullet myBullet = new Bullet();
            Shield[] shields = {new Shield(), new Shield(), new Shield(), new Shield()};

            myShip.move(38, 18);

            while(true){  
                drawStage(myShip);
                myShip.draw();
                shields[0].move(15, 16);
                shields[1].move(29, 16);
                shields[2].move(43, 16);
                shields[3].move(57, 16);

                myShip.seePosition();
                myBullet.seePosition();

                switch(Console.ReadKey(true).KeyChar){
                    case LEFT:
                        myShip.moveLeft();
                    break;
                    case RIGHT:
                        myShip.moveRight();
                    break;
                    case SHOOT:
                        if(!myBullet.isShooting())
                            if(myBullet.shoot(myShip.getX(), shields))
                                myShip.setScore(myShip.getScore() + 100);                            
                    break;
                }
            }
        }

        static void setup(){
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.SetBufferSize(800, 800);
            Console.Clear();
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

    }
}
