using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
namespace Project1
{
    public class Skeleton : IEntity
	{
       

        private ISprite sprite;
        public Rectangle BoundingBox => getPositionAndRectangle();

        /*
         * Initalize skeleton
         */
        public Skeleton((int, int) position, (String, int)[] items)
		{
            
            sprite = EnemySpriteFactory.Instance.CreateSkeletonSprite(position, items);
        }


        /*
         * Update Skelly
         */
        public void Update()
        {
            sprite.Update();
           
        }

        /*
         * Draw Skelly
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Add Heatth fot skeely
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Skelly sttack
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Skelly dead item
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }

        public Rectangle getPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;

        }

        public void setPosition(int x, int y)
        {
            sprite.setPos(x, y);

        }
    }
}
