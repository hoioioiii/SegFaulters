using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static Project1.Constants;

namespace Project1
{
    public class DrawManager : IDraw
    {
        public bool DrawState { get; private set; }

        public DrawManager()
        {
            DrawState = false;
        }

        private void DrawPlayer()
        {

            //TODO:Fix later
            // link.Draw(, Game1._spriteBatch);

        }
        private void DrawIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getWeaponList();
            for (int i = 0; i < weapons.Count; i++)
            {
                //this is needed for bomb(the attack)
                //weapons[i].Attack();
                weapons[i].Draw();
            }
        }

        private void DrawEnemies()
        {
            List<IEntity> entities = Game1.GameObjManager.getEntityList();
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Draw(Game1._spriteBatch);
            }
        }

        private void DrawItems()
        {
            List<IItem> items = Game1.GameObjManager.getItemList();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].drawState)
                {
                    items[i].Draw(Game1._spriteBatch);
                }
            }
        }

        public void Draw()
        {

            if (!Game1.UpdateManager.UpdateState)
            {
                DrawState = true;
                DrawIWeapons();
                DrawEnemies();
                DrawItems();

            }
            DrawState = false;
            // DrawPlayer();
        }



    }
}
