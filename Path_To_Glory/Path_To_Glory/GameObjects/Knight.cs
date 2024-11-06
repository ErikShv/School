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
            idelLeft, idelRight, movingLeft, movingRight,JumpLeft,JumpRight,Jump
        }
        
        public StateType state { get; set; }
        public Knight(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Manager.GameEvent.OnKeyDown += Go;
            Manager.GameEvent.OnKeyUp += Stop;
            Image.Height = 200;
            state = StateType.idelRight;
        }

        public override void Render()
        {
            base.Render();
            if(Rect.Left <= 0)
            {
                _X = 0;
            }
            if(Rect.Right >= _scene?.ActualWidth)
            {
                _X = _scene.ActualWidth - Image.Height;
            }
            if(Rect.Bottom >= _scene?.ActualHeight )
            {
                _Y = _scene.ActualHeight -Image.ActualHeight;
                _ddY = 0;
                _dY = 0;
            }
        }
        public void Jump()
        {
            _dY = -20;
            _ddY = 1;
        }
        

        private void Go(VirtualKey key)
        {
            if (state != StateType.Jump )
            {
                if (key == Keys.Upkey)
                {
                    state = StateType.Jump; ;
                    Jump();
                }
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
            if (key != Keys.Upkey)
            {
                base.Stop();
            }
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



    

