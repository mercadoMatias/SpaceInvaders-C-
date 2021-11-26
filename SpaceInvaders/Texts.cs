using System;
using System.Threading;

namespace Helpers{
    class Texts{
        public static void pressToStart(){
            string[] text = new string[4];
            text[0] = "Hello humans!, I hope you are prepared to be invaded!";
            text[1] = " ";
            text[2] = "Press 'L' to start and stand your ground!";

            Console.SetCursorPosition(55, 13);
            Console.Write("^   ^");
            Console.SetCursorPosition(55, 14);
            Console.Write(">OwO< - Pinku");

            Console.ForegroundColor = ConsoleColor.Red;

            for(int i=0; i<3; i++){
                Console.SetCursorPosition(13, 12+i);
                foreach(char letter in text[i]){
                    Console.Write(letter);
                    Thread.Sleep(25);
                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
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
            text[0] = " ▄████▄ ▄████▄ ▄█████▄ █████   ▄████▄  ██  ██ █████ ████▄";
            text[1] = "██      ██  ██ ██▀█▀██ ██      ██  ██  ██  ██ ██    █  ▄█";
            text[2] = "██      ██ ▄██ ██ █ ██ █████   ██  ██  ██  ██ █████ ████▀";
            text[3] = "██ ▀▀██ ██████ ██ ▀ ██ ██      ██  ██  ██  ██ ██    ███▄ ";
            text[4] = "██  ▄██ ██  ██ ██   ██ ██      ██ ▄██  ██ ▄██ ██    ██ █▄";
            text[5] = " ▀████▀ ██  ██ ██   ██ █████   ▀████▀  ▀████▀ █████ ██ ██";

            for(int i=0; i<6; i++){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(11, 4+i);
                Console.Write(text[i]);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }
}