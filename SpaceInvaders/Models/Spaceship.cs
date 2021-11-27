using System;
using Helpers;

namespace Models{
    class Spaceship{
        private int lives;
        private int score;
        private int x;
        private int y;

        //Construct
        public Spaceship(){
            this.lives = 3;
            this.score = 0;
            this.x = 0;
            this.y = 0;
        }

        //GET/SET
        public int getLives(){
            return this.lives;
        }
        public void setLives(int lives){
            this.lives = lives;
        }
        public int getScore(){
            return this.score;
        }
        public void setScore(int score){
            this.score = score;
        }
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

        public void moveLeft(){
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("   ");
            if(this.x>15)
                this.x-=2;
        }

        public void moveRight(){
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("   ");
            if(this.x<62)
                this.x+=2;
        }

        public void move(int x, int y){
            this.x = x;
            this.y = y;
            this.draw();
        }

        public void draw(){
            Console.SetCursorPosition(this.x, this.y);
            Console.Write("▄█▄");
        }
    
        public void seePosition(){
            Console.SetCursorPosition(71, 1);
            Console.Write("Ship [X:" + this.x + " Y:" + this.y + "]");
        }
    
    }
}
