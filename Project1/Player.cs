using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private KeyboardController KeyboardCtrlr;

    public Player()
	{
		// this is the player controller

		void PlayerControllerInitialize()
        {
            KeyboardCtrlr = new KeyboardController();
        }
        
        void PlayerControllerUpdate()
		{           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // keyboard inputs
            var kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.D0)) { Exit(); }
            else if (kState.IsKeyDown(Keys.D1)) { option = 1; }
            else if (kState.IsKeyDown(Keys.D2)) { option = 2; }
            else if (kState.IsKeyDown(Keys.D3)) { option = 3; }
            else if (kState.IsKeyDown(Keys.D4)) { option = 4; }
        }
	}
}
