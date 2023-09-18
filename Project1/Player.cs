using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private KeyboardController KeyboardCtrlr;

    public Player()
	{
		// this is the player controller

        // not finished code

		public void PlayerControllerInitialize()
        {
            KeyboardCtrlr = new KeyboardController();
        } 
        
        public void Update()
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
