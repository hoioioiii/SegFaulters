﻿using System;
namespace Project1
{
	public class MoveUp : ICommand
    {
		public void Execute()
		{
			if (!Player.isAttacking)
			{
                PlayerMovement.up();
			}
		}
	}
}

