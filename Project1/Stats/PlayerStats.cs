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
            stats.Add(SPEED, PlayerMovement.getPlayerSpeed());
            stats.Add(DEFENSE, 0);
        }

        public static void UpdateStats(GameTime gameTime)
        {
            coolDown += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (KeyValuePair<string, int> item in stats)
            {
                SetStats(item.Key);
            }
        }

        public static void SetStats(string currStats)
        {
            if (currStats == "SPD" && PlayerMovement.getPlayerSpeed() != stats[currStats])
            {
                stats["SPD"] = PlayerMovement.getPlayerSpeed();
            }
            else if (currStats == "SPD" && coolDown >= COOL_DOWN+0.5)
            {
                stats["SPD"] = DEFAULT_SPEED;
                PlayerMovement.setPlayerSpeed(DEFAULT_SPEED);
            }
        }
    }
}
