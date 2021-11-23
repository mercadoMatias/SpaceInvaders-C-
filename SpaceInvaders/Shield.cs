using System;
using Helpers;
using System.Threading;

namespace Models{
    class Shield{
        private int x;
        private int y;
        private string display = "█▀▀▀▀▀█";
        //private int lives;

        //Construct
        public Shield(){
            this.x = 0;
            this.y = 0;
        }

        //GET/SET
        public int getX(){
            return this.x;
        }
        public void setX(int x){
            this.x = x;
        }
        public int getY(){
            return this.y;
        }
        public void setY(int y){
            this.y = y;
        }
        public string getDisplay(){
            return this.display;
        }
        public void setDisplay(string display){
            this.display = display;
        }

        public void move(int x, int y){
            this.x = x;
            this.y = y;
            this.draw();
        }

        public void draw(){
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(display);
            Console.ForegroundColor = ConsoleColor.Magenta;
        }    
   
    }
}
