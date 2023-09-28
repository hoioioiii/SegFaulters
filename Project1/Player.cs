using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Player
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        Vector2 position;

        private int positionX = 300;
        private int positionY = 300;

        private bool isMoving = false;

        private int playerSpeed = 5;

        // scales the size of the sprite on screen
        private int spriteScale = 4;

        // cardinal direction player is facing, starts with up on 1 and progresses clockwise (e.g. 4 is left-facing)
        private int linkDirection = 2;

        // frames used for still and animation
        public Texture2D linkRight1;
        public Texture2D linkLeft1;
        public Texture2D linkUp1;
        public Texture2D linkDown1;

        // frames used for animation only
        public Texture2D linkRight2;
        public Texture2D linkLeft2;
        public Texture2D linkUp2;
        public Texture2D linkDown2;

        // frames used for attacking
        public Texture2D linkAttackRight;
        public Texture2D linkAttackLeft;
        public Texture2D linkAttackUp;
        public Texture2D linkAttackDown;

        // attacking
        private bool isAttacking = false;
        // play attack frame for ATTACK_SECONDS seconds
        private float AttackTimer;
        const float ATTACK_SECONDS = 0.5f;

        // for sprite animation
        private float FrameTimer;
        // how many animation frames per second, not the framerate of the game
        const float FRAMES_PER_SECOND = 10;
        const float FRAMETIME = 1 / FRAMES_PER_SECOND;
        // link only has two frames of animation
        private bool isSecondFrame = false;

        private Game1 game1;

        public Player()
        {
            Game1 game1 = new Game1();
            _graphics = new GraphicsDeviceManager(game1);
        }

        void Initialize()
        {
            //ContentManager Content = new ContentManager();
            FrameTimer = FRAMETIME;
            AttackTimer = ATTACK_SECONDS;

            //base.Initialize();
        }

        void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // still and movement
            linkRight1 = Content.Load<Texture2D>("linkRight1");
            linkLeft1 = Content.Load<Texture2D>("linkLeft1");
            linkUp1 = Content.Load<Texture2D>("linkUp1");
            linkDown1 = Content.Load<Texture2D>("linkDown1");

            // movement only
            linkRight2 = Content.Load<Texture2D>("linkRight2");
            linkLeft2 = Content.Load<Texture2D>("linkLeft2");
            linkUp2 = Content.Load<Texture2D>("linkUp2");
            linkDown2 = Content.Load<Texture2D>("linkDown2");

            // Attack using weapon or item
            linkAttackRight = Content.Load<Texture2D>("linkAttackRight");
            linkAttackLeft = Content.Load<Texture2D>("linkAttackLeft");
            linkAttackUp = Content.Load<Texture2D>("linkAttackUp");
            linkAttackDown = Content.Load<Texture2D>("linkAttackDown");
        }

        //change the current frame to the next frame
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            

        }
        

        /*
         * Responsible for loading the sprite image
         */
        public Texture2D Load(ContentManager Content, string texName)
        {
            return Content.Load<Texture2D>(assetName: texName);
        }

        public void Move()
        {

            
        }

        public void Health()
        {
            // Check health
            // doesn't need to be implemented in sprint 2
        }

        public void Attack()
        {
            // Attacks

            // render attack texture to sprite

            // call method of attack used (e.g. sword or arrow)
            // the sword should be a seperate object so it can have its own bounding box

        }
    }
}
