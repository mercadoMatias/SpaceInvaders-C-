using System;
using Helpers;

namespace Models{
    class Enemy{
        private int x;
        private int y;
        private string shape;
        private ConsoleColor color;

        //Construct
        public Enemy(){
            shape = this.randomShape();
            color = ColorsHelper.randomColor();
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
        public string getShape(){
            return this.shape;
        }
        public void setShape(string shape){
            this.shape = shape;
        }

        public void moveLeft(){
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("   ");
            if(this.x>14)
                this.x--;
        }

        public void moveRight(){
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("   ");
            if(this.x<63)
                this.x++;
        }

        public void move(int x, int y){
            this.x = x;
            this.y = y;
            this.draw();
        }

        public void draw(){
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = this.color;
            Console.Write(this.shape);
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        public string randomShape(){
            string[] shapes = {"-w-",
                               "OwO",
                               "UwU",
                               ">w<",
                               "qwp",};

            return shapes[(new Random()).Next(0, 4)]; 
        }
    
        public Enemy ShallowCopy()  
        {  
            return (Enemy)this.MemberwiseClone();  
        } 
   
    }
}
