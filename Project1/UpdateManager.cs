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
        public bool UpdateState { get; private set; }
        


        public UpdateManager() {

            UpdateState = true;
        }

        public void Update()
        {

            if (!Game1.DrawManager.DrawState)
            {
                Game1.GameObjManager.setAllObjects();
                Game1.GameObjManager.ClearAddingLists();

                UpdateState = true;
                UpdateItems();
                UpdateEnemies();
                UpdateIWeapons();
            }

            Game1.GameObjManager.RemoveDead();
            Game1.GameObjManager.ClearRemovingLists();

            UpdateState = false;

            //UpdatePlayer();
            //AllCollisionDetection.DetectCollision(this);
        }





        private void UpdatePlayer()
        {
            //link.Update();
        }

        private void UpdateIWeapons()
        {
            List<IWeapon> weapons = Game1.GameObjManager.getWeaponList();
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
