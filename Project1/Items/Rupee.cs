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
using System.Diagnostics;

namespace Project1
{
    public class Rupee : IItem
    {
        private IItemSprite sprite;

        public Rupee()
        {
            sprite = ItemSpriteFactory.Instance.CreateRupeeSprite();
        }

        public void Update()
        {
            sprite.Update();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, int spriteScale)
        {
            sprite.Draw(spriteBatch, location, spriteScale);
        }
    }
}


