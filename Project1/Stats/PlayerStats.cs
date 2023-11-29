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
            stats = new Dictionary<string, int>();
            stats.Add(ATTACK, 0);
            stats.Add(SPEED, Player.playerSpeed);
            stats.Add(CRITICAL_HIT, 0);
            stats.Add(DAMAGE, 0);
            stats.Add(STAMINA, 0);
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
                    Player.playerSpeed = 5;
                }
            }
        }
    }
}
