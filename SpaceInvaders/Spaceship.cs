using System;

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


        public void shoot(){

        }

        public void moveLeft(){
            
        }

        public void moveRight(){

        }

        public void draw(int x, int y){
            this.x = x;
            this.y = y;
            Console.SetCursorPosition(x, y);
            Console.Write("▄█▄");
        }
    
        public void seePosition(){
            Console.SetCursorPosition(0, 0);
            Console.Write("[X= " + this.x + " Y= " + this.y + "]");
        }
    
    }
}
