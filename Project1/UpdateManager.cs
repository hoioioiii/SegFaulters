using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;

namespace Project1
{
    public class UpdateManager : IUpdate
    {
     

        public void Update()
        {

            
            Game1.GameObjManager.setAllObjects();
            Game1.GameObjManager.ClearAddingLists();

            
             UpdateItems();
             UpdateEnemies();
             UpdateIWeapons();
             UpdatePlayerIWeapons();


            AllCollisionDetection.DetectCollision(Game1.GameObjManager);
            Game1.GameObjManager.RemoveDead();
            Game1.GameObjManager.ClearRemovingLists();

          

            //UpdatePlayer();
           
        }





        private void UpdatePlayer()
        {
           
        }

        private void UpdateIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getWeaponList();
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Update();
            }
        }

        private void UpdatePlayerIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getPlayerWeaponList();
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].Update();
            }
        }

        private void UpdateEnemies()
        {
            List<IEntity> entities = Game1.GameObjManager.getEntityList();
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Update();
            }
        }

        private void UpdateItems()
        {
            List<IItem> items = Game1.GameObjManager.getItemList();
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Update();
            }
        }






    }
}
