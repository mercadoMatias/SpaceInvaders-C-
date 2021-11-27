using System;
using System.Threading;
using System.Linq;

namespace Helpers{
    class Texts{
        public static void pressToStart(){
            string[] text = new string[2];
            text[0] = "Hello humans!, I hope you are prepared to be invaded!";
            
            pinkuSpeak(text, 15);

            text = new string[3];
            text[0] = " ";
            text[1] = "Press ENTER to stand your ground!";

            Thread.Sleep(1000);

            pinkuSpeak(text, 0, 13, 13);
            
            while(Console.ReadKey(true).KeyChar != (char) 13);
            Thread.Sleep(200);
        }

        public static void start(){
            string[] text = new string[6];
            text[0] = "▄████ ████ ▄████▄ ████▄ ████  ▄██▄";
            text[1] = "██  ▀ ████ ██  ██ █  ▄█ ████  ████";
            text[2] = "████▄  ██  ██ ▄██ ████▀  ██   ▀██▀";
            text[3] = "  ▀██  ██  ██████ ███▄   ██    ██ ";
            text[4] = "▄  ██  ██  ██  ██ ██ █▄  ██       ";
            text[5] = "████▀  ██  ██  ██ ██ ██  ██    ██ ";

            for(int i=0; i<6; i++){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(24, 5+i);
                Console.Write(text[i]);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }

        public static void gameOver(){
            string[] text = new string[6];
            text[0] = " ▄████▄ ▄████▄ ▄█████▄ █████   ▄████▄ ██  ██ █████ ████▄";
            text[1] = "██      ██  ██ ██▀█▀██ ██      ██  ██ ██  ██ ██    █  ▄█";
            text[2] = "██      ██ ▄██ ██ █ ██ █████   ██  ██ ██  ██ █████ ████▀";
            text[3] = "██ ▀▀██ ██████ ██ ▀ ██ ██      ██  ██ ██  ██ ██    ███▄ ";
            text[4] = "██  ▄██ ██  ██ ██   ██ ██      ██ ▄██ ██ ▄██ ██    ██ █▄";
            text[5] = " ▀████▀ ██  ██ ██   ██ █████   ▀████▀ ▀████▀ █████ ██ ██";

            for(int i=0; i<6; i++){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(11, 4+i);
                Console.Write(text[i]);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }

            text = new string[8];

            text[0] = "Well, that was easy!. Now we gonna dominate";
            text[1] = "this planet and make every human alive";
            text[2] = "our slave!";
            text[3] = " ";
            text[4] = " ";
            text[5] = "Do you want to try again?!";
            text[6] = "YES: ENTER  |  NO: ESC";
            
            pinkuSpeak(text);
        }

        public static void congratulations(int score){
            string[] text = new string[6];
            
            text[0] = "██  ██ ▄████▄ ██  ██    ██   ██ ██ ██  ██  ▄██▄";
            text[1] = "██  ██ ██  ██ ██  ██    ██   ██ ██ ██▄ ██  ████";
            text[2] = " ▀██▀  ██  ██ ██  ██    ██   ██ ██ ██████  ▀██▀";
            text[3] = "  ██   ██  ██ ██  ██    ██ █ ██ ██ ██ ▀██   ██ ";
            text[4] = "  ██   ██ ▄██ ██  ██    ██ █ ██ ██ ██  ██      ";
            text[5] = "  ██   ▀████▀ ▀████▀    ▀█████▀ ██ ██  ██   ██ ";

            for(int i=0; i<6; i++){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(16, 4+i);
                Console.Write(text[i]);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }

            Console.SetCursorPosition(13, 20);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Your final score is: [" + score + "]");

            text = new string[4];

            text[0] = "Nooo!, I can't believe such weak race could do";
            text[1] = "something against our superior troops!.";
            text[2] = "This won't end here!, we'll be back!";

            pinkuSpeak(text);

            text = new string[3];

            text[0] = "You're a hero!, wanna beat 'em again?";
            text[1] = "YES: ENTER  |  NO: ESC";

            Thread.Sleep(400);

            pinkuSpeak(text, 0, 13, 16);
        }

        public static void pinkuSpeak(string[] text, int speed = 17, int x = 13, int y = 12){
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.SetCursorPosition(55, 13);
            Console.Write("^   ^   King");
            Console.SetCursorPosition(55, 14);
            Console.Write(">OwO< - Pinku");

            Console.ForegroundColor = ConsoleColor.White;
            for(int i=0; i<text.Count()-1; i++){
                Console.SetCursorPosition(x, y+i);
                foreach(char letter in text[i]){
                    Console.Write(letter);
                    Thread.Sleep(speed);
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}