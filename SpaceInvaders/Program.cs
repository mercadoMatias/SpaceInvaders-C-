using System;
using Models;
using System.Threading;

namespace SpaceInvaders{
    class Program{
        const char LEFT  = 'a';
        const char RIGHT = 'd';
        const char SHOOT = 'l';

        //MAIN
        static void Main(string[] args){
            //Objects
            Spaceship myShip = new Spaceship();
            Bullet myBullet = new Bullet();
            Shield[] shields = {new Shield(), new Shield(), new Shield(), new Shield()};
            Enemy[] enemies = new Enemy[7];
            Enemy[,] troops = new Enemy[7,4];
            int enemyCount = 28;

            for(int i=0; i<4; i++)
                enemies[i] = new Enemy();

            for(int i=0; i<7; i++)
                for(int j=0; j<4; j++)
                    troops[i, j] = enemies[j].ShallowCopy();

            setup();

            myShip.move(38, 18);
            int enemyX = 15;
            int enemyY = 0;
            int stepsTaken = 0;

            //Game execution
            while(enemyCount > 0){ 
                drawStage(myShip);
                myShip.draw();

                for(int i=0; i<4; i++){
                    for(int j=0; j<7; j++){
                        Console.SetCursorPosition(11 + j*4 + enemyX, 3+i*2);
                        Console.Write("   ");
                        troops[j, i].setX(12 + j*4 + enemyX);
                        troops[j, i].setY(3+i*2 + enemyY);
                        troops[j, i].draw();
                    }
                    shields[i].move(15+(14*i), 16);
                }

                myShip.seePosition();
                myBullet.seePosition();

                switch(Console.ReadKey(true).KeyChar){
                    case LEFT:
                        myShip.moveLeft();
                        stepsTaken++;
                    break;
                    case RIGHT:
                        myShip.moveRight();
                        stepsTaken++;
                    break;
                    case SHOOT:
                        if(!myBullet.isShooting() && myBullet.shoot(myShip.getX(), shields, troops)){
                            myShip.setScore(myShip.getScore() + 10*(20-(enemyY*5))-(stepsTaken));    
                            enemyCount--;
                        }                        
                    break;
                }

                if(enemyX>28){
                    enemyX = 0;
                    enemyY++;
                }else
                    enemyX++;
                clearScreen();
            }

            Console.SetCursorPosition(0, 24);
        }

        static void clearScreen(){
            for(int i=0; i<12; i++)
                for(int j=0; j<56; j++){
                    Console.SetCursorPosition(12+j, 3+i);
                    Console.Write(" ");
                }
        }

        static void setup(){
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorVisible = false;
            Console.SetBufferSize(800, 800);
            Console.Clear();
            
            for(int y=0; y<23; y++)
                for(int x=10; x<70; x++){
                    Console.SetCursorPosition(x, y);

                    if(y == 0 || y == 22 || x == 10 || x == 69)
                        Console.Write(".");
                }
        }

        static void drawStage(Spaceship ship){
            for(int y=0; y<23; y++)
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
                    if(y == 0 || y == 22 || x == 10 || x == 69)
                        Console.Write(".");
                }
            Console.SetCursorPosition(0, 0);
        }
    }
}
