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
    public class Skeleton : IEnemy
	{

       

        private ISprite sprite;


        /*
         * Initalize skeleton
         */
        public Skeleton()
		{
          

            sprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();
        }

        /*
         * Update Skeleton
         */
        public void Update()
        {
            sprite.Update();
            
        }

        /*
         * Draw Skeleton
         */
        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);
        }

        /*
         * Skeleton health ->later
         */
        public void Health()
        {
            throw new NotImplementedException();
        }

        /*
         * Skeleton Attack -> Later
         */
        public void Attack()
        {
            throw new NotImplementedException();
        }

        /*
         * Skeleton Item Drop
         */
        public void ItemDrop()
        {
            throw new NotImplementedException();
        }
    }
}
