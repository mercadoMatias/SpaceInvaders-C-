using System;
using Models;
using Helpers;
using System.Threading;
using System.Text.Json;
using System.Runtime;
using System.IO;

namespace SpaceInvaders{
    class Program{
        const char LEFT  = 'a';
        const char RIGHT = 'd';
        const char ACCEPT = 'l';
        const char CANCEL = 'm';

        //MAIN
        static void Main(string[] args){
            char playAgain = (char) 13;
            int? finalScore = null;
            while(playAgain == (char) 13){
                //Objects
                Spaceship myShip = new Spaceship();
                Bullet myBullet = new Bullet();
                Shield[] shields = {new Shield(), new Shield(), new Shield(), new Shield()};
                Enemy[] enemies = new Enemy[7];
                Enemy[,] troops = new Enemy[7,5];
                int enemyCount = 35;

                for(int i=0; i<5; i++)
                    enemies[i] = new Enemy();

                for(int i=0; i<7; i++)
                    for(int j=0; j<5; j++)
                        troops[i, j] = enemies[j].ShallowCopy();

                //SETUP
                setup();
                myShip.move(38, 18);
                int enemyX = 15;
                int enemyY = 0;
                int stepsTaken = 0;
                drawStage(myShip);

                //Draw enemies
                drawEnemies(troops, shields, enemyX, enemyY, 80, false);

                //PRESS START!
                Thread.Sleep(800);
                Texts.pressToStart();

                //START
                clearScreen();
                Texts.start();
                Thread.Sleep(1200);

                //START EXECUTION
                while(enemyCount>0 && enemyY<4 && myShip.getLives()>0){ 
                    drawStage(myShip);
                    myShip.draw();

                    drawEnemies(troops, shields, enemyX, enemyY);         

                    myShip.seePosition();
                    myBullet.seePosition();
                    troops[0, 0].seePosition();

                    if(Console.KeyAvailable)
                    switch(Console.ReadKey(true).KeyChar){
                        case LEFT:
                            myShip.moveLeft();
                            stepsTaken++;
                        break;
                        case RIGHT:
                            myShip.moveRight();
                            stepsTaken++;
                        break;
                        case ACCEPT:
                            if(!myBullet.isShooting())
                                if(myBullet.shoot(myShip.getX(), shields, troops)){
                                    myShip.setScore(myShip.getScore() + 10*(20-(enemyY*5))-(stepsTaken));    
                                    enemyCount--;
                                }else
                                    myShip.setLives(myShip.getLives()-1);       
                        break;
                    }else
                        Thread.Sleep(200);

                    if(enemyX>28){
                        enemyX = 0;
                        enemyY++;
                    }else
                        enemyX++;
                }
                //END EXECUTION
                setup();

                Console.SetCursorPosition(32, 8);

                if(1 == 2/*enemyY >= 4 || myShip.getLives()<1*/){
                    Console.SetCursorPosition(0, 0);
                    Texts.gameOver();
                }else /*if(enemyCount < 1)*/{
                    myShip.setScore(myShip.getScore() + (myShip.getLives() * 500));
                    Texts.congratulations(myShip.getScore());
                    finalScore = myShip.getScore();
                }
                
                playAgain = ' ';
                while(playAgain != (char) 13 &&  playAgain != (char) 27)
                    playAgain = Console.ReadKey(true).KeyChar;
            }

            if(finalScore != null){
                setup();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(25, 10);
                Console.Write("Let's save your score! [" + finalScore + "]");

                Console.SetCursorPosition(25, 11);
                Console.Write("3 Initials: ");

                char[] finalName = new char[3];
                for(int i=0; i<3; i++){
                    finalName[i] = char.ToUpper(Console.ReadKey().KeyChar);
                }

                Console.SetCursorPosition(25, 14);
                for(int i=0; i<3; i++){
                    Console.Write(finalName[i]);
                }                
            }

            
        }

        static void drawEnemies(Enemy[,] troops, Shield[] shields, int enemyX, int enemyY, int sleep = 0, bool showBar = true){
            for(int i=0; i<5; i++){
                for(int j=0; j<7; j++){
                    Console.SetCursorPosition(11 + j*4 + enemyX, 3 + i*2 + enemyY);
                    Console.Write("   ");
                    troops[j, i].setX(12 + j*4 + enemyX);
                    troops[j, i].setY(3+i*2 + enemyY);
                    troops[j, i].draw();
                    Thread.Sleep(sleep);
                }
                if(i<4)
                    shields[i].move(15+(14*i), 16); 
            } 

            if(showBar){
            Console.SetCursorPosition(26, enemyY+12);

            for(int i=0; i<29; i++)
                Console.Write("-");  
            }
        }

        static void clearScreen(){
            for(int i=0; i<12; i++)
                for(int j=0; j<56; j++){
                    Console.SetCursorPosition(12+j, 3+i);
                    Console.Write(" ");
                }
        }

        static void setup(){
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
            clearScreen();
            for(int y=0; y<23; y++)
                for(int x=10; x<70; x++){
                    Console.SetCursorPosition(x, y);
                    
                    //SCORE
                    if(y == 2 && x == 14){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("SCORE: " + ship.getScore());
                    }

                    //_
                    if(y == 19 && x > 13 && x < 66){
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("_");
                    }

                    //LIVES
                    if(y == 21 && x == 13){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("LIVES:            ");
                        Console.SetCursorPosition(x+6, y);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        for(int i=ship.getLives(); i>0; i--)
                            Console.Write(" ▄█▄");
                    }

                    //CREDITS
                    if(y == 21 && x == 57){
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("CREDITS: ");
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;

                    //BORDER
                    if(y == 0 || y == 22 || x == 10 || x == 69)
                        Console.Write(".");
                }
            Console.SetCursorPosition(0, 0);
        }
    }
}
