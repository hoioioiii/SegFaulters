﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.HUD;

namespace Project1
{
    public class AttackSelectedWeapon : ICommand
    {
        public void Execute()
        {
            ICommand[] usableItemArray = { new attackBoomerang(), new atttackBomb(), new keyCommand(), new attackBow() };
            //{ boomerang = 0, bomb = 1, key = 2, sword = 3}
            usableItemArray[(int)InventoryDisplay.getSelectedItem()].Execute();
        }
    }
}