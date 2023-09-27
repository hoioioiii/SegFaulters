using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Weapon
    {
        protected Player Character; // WE DONT WANNA TOUCH THE CHARACTER
        public Vector2 direction;
        public Vector2 offSet;
        public Vector2 CharacterPosition()
        {
            return this.Character.CharacterPosition;
        }
        public Weapon(Player character) 
        {
            this.Character = character;
            Vector2 characterPosition = this.CharacterPosition();
            this.offSet = new Vector2(characterPosition.X, characterPosition.Y); // NEEDS TO MODIFY POSITION ACCORDING TO HANDS/OFFSET, OR SPECIFIC SPOT
            this.direction = new Vector2(0, -1); //MODIFY TO HANDLE COLLISION
        }

        //MODIFY ACCESS ACCORDING TO BEST PRACTICES
        //VIRTUAL BECAUSE WE NEED WEAPONS TO OVERRIDE THIS
        public virtual void WeaponStartFire()
        {
            //this.Character.FireAction(this.direction, this.CharacterPosition);
        }

        public virtual void WeaponStopFire() 
        {

        }
    }
}
