using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project1.Constants;
using Project1.Enemies.SpikeAdditonalFiles;
namespace Project1
{
    public class EntityLoader
    {
        private static IActiveObjects GameOBJ;
        private static IEntity currEntity;
        private static Dictionary<string, IEntity> mapToCreate;
        public static void LoadEntities(IActiveObjects activeObjects, String name, (int,int) position, (String, int)[] items)
        {

            GameOBJ = activeObjects;
            InitalizeEntity(name,position,items);
            GameOBJ.addNewEntity(currEntity);
        }

        private static void InitalizeEntity(String name,(int,int) position, (String, int)[] items)
        {
            
            switch (name)
            {
                case "Keese":

                    currEntity = new Bat(position, items);
                    break;

                case "AquaDragon":
                    currEntity = new BossAquaDragon(position, items);
                    break;

                case "Dino":
                    currEntity = new BossDino(position, items);
                    break;

                case "Stalfo":
                    currEntity = new Skeleton(position, items);
                    break;

                case "Gel":
                    currEntity = new Jelly(position, items);
                    break;

                case "Goriya":
                    currEntity = new DogMonster(position, items);
                    break;

                case "BladeTrap":


                    SPIKE_ID id = AxisBoundaryMaps.GetSpikeID(position);
                    currEntity = new SpikeCross(position, items, id);
                    break;

                case "Wallmaster":
                    currEntity = new Hand(position, items);
                    break;

                case "Aquamentus":
                    currEntity = new BossFireDragon(position, items);
                    break;
                case "Snake":
                    currEntity = new Snake(position, items);
                    break;
                case "OldMan":
                    currEntity = new OldMan(position, items);
                    break;
                case "Merchant":
                    currEntity = new Merchant(position, items);
                    break;
                case "Flame":
                    currEntity = new Flame(position, items);
                    break;
                default:
                    currEntity = new Flame(position, items);
                    break;
            }
        }
      





        
    }
}
