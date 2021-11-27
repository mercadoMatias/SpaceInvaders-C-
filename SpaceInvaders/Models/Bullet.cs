using System;
using System.Text;
using Helpers;
using System.Threading;

namespace Models{
    class Bullet{
        private int x;
        private int y;
        private bool shooting;

        //Construct
        public Bullet(){
            this.x = 0;
            this.y = 18;
            this.shooting = false;
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
        public bool isShooting(){
            return this.shooting;
        }

        public bool shoot(int x, Shield[] shields, Enemy[,] troops){
            this.shooting = true;
            this.x = x+1;
            bool enemyCollisioned  = false;
            bool shieldCollisioned = false;

            while(this.y>1 && !enemyCollisioned && !shieldCollisioned){
                this.y--;
                this.seePosition();
                Console.SetCursorPosition(this.x, this.y);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("^");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Thread.Sleep(20);
                Console.SetCursorPosition(this.x, this.y);
                Console.Write(" ");
                enemyCollisioned  = this.enemyCollision(this, troops);
                shieldCollisioned = this.shieldCollision(this, shields);               
            }

            this.y = 18;
            this.shooting = false;
            return enemyCollisioned;
        }
    
        public void seePosition(){
            Console.SetCursorPosition(71, 2);
            Console.Write("Bullet [X:" + this.x + " Y:" + this.y + "]");
        }

        public bool shieldCollision(Bullet bullet, Shield[] shields){
            foreach(Shield shield in shields)
                if(bullet.getY() == shield.getY())
                    for(int i=shield.getX(); i<=shield.getX()+6; i++)
                        if(bullet.getX() == i){
                            StringBuilder newDisplay = new StringBuilder(shield.getDisplay());
                            if(newDisplay[i-shield.getX()] != ' '){
                                newDisplay[i-shield.getX()] = ' ';
                                shield.setDisplay(newDisplay.ToString());
                                return true;
                            }
                        }
            return false;  
        }

        public bool enemyCollision(Bullet bullet, Enemy[,] troops){
            for(int i=0; i<7; i++){
                for(int j=0; j<5; j++){
                    if(bullet.getY() == troops[i, j].getY()){
                        for(int x=troops[i, j].getX(); x<=troops[i, j].getX()+2; x++)
                            if(bullet.getX() == x && troops[i, j].getShape()[x-troops[i, j].getX()] != ' '){
                                troops[i, j].setShape("   ");
                                return true;
                            }
                    }
                }
            }
            return false;  
        }

    }
}
