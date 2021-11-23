using System;
using System.Text;
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

        public bool shoot(int x, Shield[] shields){
            this.shooting = true;
            this.x = x+1;
            bool collisioned = false;

            while(this.y>1 && !collisioned){
                this.y--;
                this.seePosition();
                Console.SetCursorPosition(this.x, this.y);
                Console.Write("^");
                Thread.Sleep(50);
                Console.SetCursorPosition(this.x, this.y);
                Console.Write(" ");
                collisioned = this.collision(this, shields);               
            }

            this.y = 18;
            this.shooting = false;
            return collisioned;
        }
    
        public void seePosition(){
            Console.SetCursorPosition(71, 1);
            Console.Write("Bullet [X:" + this.x + " Y:" + this.y + "]");
        }

        public bool collision(Bullet bullet, Shield[] shields){
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

    }
}
