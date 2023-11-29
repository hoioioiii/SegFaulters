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
       

        public DrawManager()
        {
            
        }

        private void DrawPlayer()
        {

            //TODO:Fix later
            // Player.Draw(, Game1._spriteBatch);

        }
        private void DrawIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getWeaponList();
            for (int i = 0; i < weapons.Count; i++)
            {
               
                weapons[i].Draw();
            }
        }


        private void DrawPlayerIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getPlayerWeaponList();
            for (int i = 0; i < weapons.Count; i++)
            {
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

                DrawIWeapons();
                DrawEnemies();
                DrawItems();
                DrawPlayerIWeapons();
               // DrawPlayer();
        }



    }
}
