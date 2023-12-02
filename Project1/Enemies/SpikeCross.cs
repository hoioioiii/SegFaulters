using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using static Project1.Constants;
using Project1.Enemies;
using Project1.Enemies.SpikeAdditonalFiles;
using Project1.Enemies.SpikeAdditonalFiles.SpikeMovementFolder;

namespace Project1
{
    public class SpikeCross : UniversalClassEntity
    {
        public override Rectangle BoundingBox => GetPositionAndRectangle();

        
        private ISprite sprite;
        private SPIKE_ID id;
        public override Rectangle DetectionFieldX => GetAxisX();
        public override Rectangle DetectionFieldY => GetAxisY();

        public override (bool, bool) detected { get; set; }

        /*
         * Initalize Spike
         */
        public SpikeCross((int, int) position, (String, int)[] items, SPIKE_ID id) : base(position, items)
        {

            this.id = id;
            sprite = EnemySpriteFactory.Instance.CreateSpikeCrossSprite(animation_manager, movement_manager, direction_state_manager, state_manager, time_manager);
            Game1.GameObjManager.addNewDetectionEntity(this);
        }

        public override Rectangle GetPositionAndRectangle()
        {
            return sprite.GetRectangle().Item2;
        }


        private Rectangle GetAxisX()
        {
            return AxisBoundaryMaps.GetSpikeAxisBoxes(id)[SPIKE_AXIS_X];
        }

        private Rectangle GetAxisY()
        {
            return AxisBoundaryMaps.GetSpikeAxisBoxes(id)[SPIKE_AXIS_Y];
        }


        public override void SetDetected(bool x, bool y)
        {
           
            if (!x && !y)
            {
               
                ResetCompletely();
            }


            detected = (x, y);
        }

        private void ResetCompletely()
        {
            int x = AxisBoundaryMaps.GetSpikeLocalPosition(id).Item1;
            int y = AxisBoundaryMaps.GetSpikeLocalPosition(id).Item2;
            movement_manager.setPosition(x, y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

        public override void MovementType()
        {
            if (detected.Item1 || detected.Item2)
            {
                DetermineMovement();
                
            }
            else
            {
                ReturnToOrigin();
            }
        }

        private void ReturnToOrigin()
        {
            (int,int) pos = AxisBoundaryMaps.GetSpikeLocalPosition(id);
            int x = movement_manager.getPosition().Item1;
            int y = movement_manager.getPosition().Item2;
            if (Math.Abs(x - pos.Item1) > 0)
            {
                MovementController.Move(id, true, movement_manager, true);
            }
            else if (Math.Abs(y - pos.Item2) > 0)
            {
                MovementController.Move(id, false, movement_manager, true);
            }


        }

        private void DetermineMovement()
        {
           
                if (detected.Item1 && (movement_manager.getPosition().Item2 == AxisBoundaryMaps.GetSpikeLocalPosition(id).Item2))
                {
                    MovementController.Move(id, true, movement_manager, false);
                }
                else if (movement_manager.getPosition().Item1== AxisBoundaryMaps.GetSpikeLocalPosition(id).Item1)
                {
                    
                    MovementController.Move(id, false, movement_manager, false);
                }
                else
                {
                    ReturnToOrigin() ;
                }

            
            
            
        }



    }
}

