using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static System.Net.Mime.MediaTypeNames;
using static Project1.Constants;

namespace Project1.Stats
{
    /*
     * Clock: player speed
     * Fairy: player attack
     * Rupees: every 2 ruppes -> player defense is +2
     */
    public class PlayerStats : IPlayerStats
    {
        public static Dictionary<string, int> stats;
        public static float coolDown;
        public PlayerStats()
        {
            stats = new Dictionary<string, int>();
            InitializeStats();
        }

        public void InitializeStats()
        {
            //default stats metrics
            stats = new Dictionary<string, int>();
            stats.Add(ATTACK, DAMAGE_HALF_HEART);
            stats.Add(SPEED, Player.playerSpeed);
            stats.Add(DEFENSE, 0);
        }

        public static void UpdateStats(GameTime gameTime)
        {
            coolDown += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var item in stats)
            {
                if (item.Key == "SPD" && Player.playerSpeed != item.Value)
                {
                    stats["SPD"] = Player.playerSpeed;
                }
                else if (item.Key == "SPD" && coolDown >= 10)
                {
                    Player.playerSpeed = DEFAULT_SPEED;
                }

                //if (item.Key == "DEF" && 
                //    Inventory.itemsInventory[(int)ITEMS.Ruppee] % 2 == 0)
                //{
                //    stats["DEF"] += 1;
                //}

            }
        }
    }
}
