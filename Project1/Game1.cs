using System.Collections;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
=======
>>>>>>> state-transition-character-interface-2.0
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;
        public static ContentManager contentLoader;
<<<<<<< HEAD
        //public static SpriteBatch _spriteBatch;

        // not used because I made the methods in player public static
        //public Player player
=======
>>>>>>> state-transition-character-interface-2.0

        private IHealth HealthBarSprite;


        public static ContentManager ContentManager1;
        public static Game1 Game;

        public static IEnemy ENEMY;

        private Texture2D _texture;
        private ArrayList ControllerList;
<<<<<<< HEAD
=======

        public Player player;
>>>>>>> state-transition-character-interface-2.0

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            contentLoader = Content;
            IsMouseVisible = true;
<<<<<<< HEAD

            //remove this later
            ContentManager1 = Content;
            Game = this;
            


        }
        

        void Quit() => Exit();
=======
>>>>>>> state-transition-character-interface-2.0

            //remove this later
            ContentManager1 = Content;
            Game = this;

           

        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            HealthBarSprite = new HealthSystem();
            ControllerList = new ArrayList();
            ControllerList.Add(new KeyBoardController(this));
<<<<<<< HEAD
            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            //Player player = new Player();
            Player.Initialize();
=======
>>>>>>> state-transition-character-interface-2.0

            player = new Player();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            /**
             * 
             * Replace all sprites with proper sprites.
             */
            IListIterate EntityList = new EnemyIterator(this);

            
            //ENEMY = new Bat();
            //ENEMY = new BossAquaDragon();
            //ENEMY = new BossDino();
            //ENEMY = new BossFireDragon();
            //ENEMY = new DogMonster();
            //ENEMY = new Flame();
            //ENEMY = new Jelly();
            //ENEMY = new Merchant();
            //ENEMY = new OldMan();
            //ENEMY = new Skeleton();
            //ENEMY = new Snake();
            //ENEMY = new SpikeCross();




<<<<<<< HEAD
            // TODO: use this.Content to load your game content here
            //Content content = this.Content;
            Player.LoadContent(Content);
=======
            /**
             * 
             * Replace all sprites with proper sprites.
             */
            IListIterate EntityList = new EnemyIterator(this);

            
            //ENEMY = new Bat();
            //ENEMY = new BossAquaDragon();
            //ENEMY = new BossDino();
            //ENEMY = new BossFireDragon();
            //ENEMY = new DogMonster();
            //ENEMY = new Flame();
            //ENEMY = new Jelly();
            //ENEMY = new Merchant();
            //ENEMY = new OldMan();
            //ENEMY = new Skeleton();
            //ENEMY = new Snake();
            //ENEMY = new SpikeCross();



>>>>>>> state-transition-character-interface-2.0
        }

        protected override void Update(GameTime gameTime)
        {
<<<<<<< HEAD
=======
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



>>>>>>> state-transition-character-interface-2.0
            // TODO: Add your update logic here
            Player.Update(gameTime);

            foreach (IController controller in ControllerList)
            {
                controller.Update();
            }


            HealthBarSprite.Update();
            HealthBarSprite.HealthDamage(1);

            HealthBarSprite.Update();

            ENEMY.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            HealthBarSprite.Draw();

           
         
<<<<<<< HEAD
           

            Player.Draw(gameTime, _spriteBatch);

            
=======
>>>>>>> state-transition-character-interface-2.0


            ENEMY.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);



           
        }
    }
}