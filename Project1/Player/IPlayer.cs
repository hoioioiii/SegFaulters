using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using static Project1.Constants;
namespace Project1
{
    public interface IPlayer
    {
        public void Update();
        public void SetPosition(Vector2 position);
        public Vector2 GetPosition();

        //handles bounding box
        public Rectangle BoundingBox();
        //weapons
        public bool GetPlayerAttackingState();

        //needs user direction
        public DIRECTION GetDirection();
        public void Attack();
        public void PickUpItem(ITEMS itemToAdd);
        public bool UseItem(ITEMS itemToDelete);

    }
}
