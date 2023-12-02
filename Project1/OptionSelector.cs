using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Project1.Constants;

namespace Project1
{
    public class OptionSelector : ISelection
    {

        public  OPTION selected;
        private OPTION[] options;
        private int pointer;
        private Dictionary<OPTION, Vector2> OptionPositionMap;
        
        public OptionSelector() {
            CreateArrayOfOptions();
            CreateOptionMap();
            selected = options[0];
            pointer = 0;
        }
        private void CreateOptionMap()
        {
            OptionPositionMap = new Dictionary<OPTION, Vector2>
            {
                { options[0], RETRY_POSITION },
                { options[1], QUIT_POSITION }
            };
        }

        private void CreateArrayOfOptions()
        {
            options = new OPTION[OPTION_ARRAY_SIZE];
            options[0] = OPTION.RETRY;
            options[1] = OPTION.QUIT;
        }
        public void PrevOption () {


            pointer--;
            if (pointer < 0)
            {
                pointer +=1;
            }
            
        }
        public void NextOption()
        {


            pointer++;
            if (pointer >= options.Length)
            {
                pointer -= 1;
            }
           
        }

        public void SelectOption()
        {
            selected = options[pointer];
            
        }

        public void DrawHeartSelector(SpriteBatch spriteBatch)
        {
            // ItemSpriteFactory.heartSpriteStorage[1];

            int optionPosition = (int) OptionPositionMap.GetValueOrDefault(options[pointer]).Y;
            int width = ItemSpriteFactory.heartSpriteStorage[1].Width;
            int height = ItemSpriteFactory.heartSpriteStorage[1].Height;
            Rectangle source = new Rectangle(0, 0, width, height);
            Rectangle currentLocation = new Rectangle(SELECTION_OFFSET, optionPosition, width * LARGER_SIZE, height * LARGER_SIZE);
            spriteBatch.Draw(ItemSpriteFactory.heartSpriteStorage[1], currentLocation, source,Color.White);

        }
       




    }
}
