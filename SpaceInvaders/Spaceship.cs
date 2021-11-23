using System;

namespace Models{
    class Spaceship{
        private int lives;
        private int score;

        public Spaceship(){
            this.lives = 3;
            this.score = 0;
        }

        public void shoot(){

        }

        public void moveLeft(){

        }

        public void moveRight(){

        }

        public void draw(int x, int y){
            Console.SetCursorPosition(x, y);
            Console.Write("▄█▄");
        }
    }
}
