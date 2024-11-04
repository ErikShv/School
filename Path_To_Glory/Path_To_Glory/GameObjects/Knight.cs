using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace Path_To_Glory.GameObjects
{
    class Knight : GameMovingObject
    {
        public enum StateType
        {
            idelLeft, idelRight, movingLeft, movingRight
        }
        bool jump = false;
        public StateType state { get; set; }
        public Knight(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Manager.GameEvent.OnKeyDown += Go;
            Manager.GameEvent.OnKeyUp += Stop;
            Image.Height = 129;
            state = StateType.idelRight;
        }

        private void Go(VirtualKey key)
        {
            if (key == Keys.Upkey)
            {
                _dY = -8;
            }

            if (key == Keys.Downkey)
            {

                _dY = 8;
            }

            if (key == Keys.Rightkey)
            {

                if (state != StateType.movingRight)
                {
                    state = StateType.movingRight;
                    SetImage("Characters/KnightRunRight.gif");
                }
                _dX = 8;
            }

            if (key == Keys.Leftkey)
            {
                if (state != StateType.movingLeft)
                {
                    state = StateType.movingLeft;
                    SetImage("Characters/KnightRunLeft.gif");
                }
                _dX = -8;
            }
            
        }
        private void Stop(VirtualKey key)
        {
            base.Stop();
            if (state == StateType.movingRight)
            {
                SetImage("Characters/KnightIdleRight.gif");
                state = StateType.idelRight;
            }
             if (state == StateType.movingLeft)
            {
                SetImage("Characters/KnightIdleLeft.gif");
                state = StateType.idelLeft;
            }
        }
    }



}



    

