using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    /*
     * This is to test the Icommands
     */
    internal interface ICommand
    {
        public void Execute();
        //interface methods
        
        //player commands
        public class MoveDown : ICommand
        {
            public MoveDown()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class MoveUp : ICommand
        {
            public MoveUp()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class MoveLeft : ICommand
        {
            public MoveLeft()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class MoveRight : ICommand
        {
            public MoveRight()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class TakeDamage : ICommand
        {
            public TakeDamage()
            {
                // constructor
            }
            public void Execute()
            {

            }

        }
        public class QuitGame : ICommand
        {
            public QuitGame()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        
        public class Item0 : ICommand
        {
            public Item0()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item1 : ICommand
        {
            public Item1()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item2 : ICommand
        {
            public Item2()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item3 : ICommand
        {
            public Item3()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item4 : ICommand
        {
            public Item4()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item5 : ICommand
        {
            public Item5()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item6 : ICommand
        {
            public Item6()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item7  : ICommand
        {
            public Item7()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item8 : ICommand
        {
            public Item8()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class Item9 : ICommand
        {
            public Item9()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }

        //block commands


        //item commands

        public class ItemNext : ICommand
        {
            public ItemNext()
            {
                //constructor, nothing
            }

            public void Execute()
            {

            }
        }
        public class ItemPrevious : ICommand
        {
            public ItemPrevious()
            {
                //constructor, nothing
            }

            public void Execute()
            {

    }
}
    }
}
