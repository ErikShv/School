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
            idelLeft, idelRight, movingLeft, movingRight, JumpLeft, JumpRight, Jump
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
            if (Rect.Left <= 0)
            {
                _X = 0;
            }
            if (Rect.Right >= _scene?.ActualWidth)
            {
                _X = _scene.ActualWidth - Image.Height;
            }
            if (Rect.Bottom >= _scene?.ActualHeight)
            {
                _Y = _scene.ActualHeight - Image.ActualHeight;
                _ddY = 0;
                _dY = 0;
                if (state == StateType.JumpRight)
                {
                    state = StateType.movingRight;
                }
                if (state == StateType.JumpLeft)
                {
                    state = StateType.movingLeft;
                }
                
            }
        }
        public void Jump()
        {
            if (state == StateType.movingRight)
            {
                state = StateType.JumpRight;
                SetImage("Characters/KnightRunRight.gif");
            }
            if (state == StateType.movingLeft)
            {

                state = StateType.JumpLeft;
                SetImage("Characters/KnightRunLeft.gif");
            }
            else
            {
                state = StateType.Jump;
            }
            _dY = -20;
            _ddY = 1;
        }


        private void Go(VirtualKey key)
        {
            if (state != StateType.JumpLeft && state != StateType.JumpRight && state != StateType.Jump)
            {
                if (key == Keys.Upkey)
                {

                    Jump();
                }
            }
            if (key == Keys.Rightkey)
            {

                if (state != StateType.movingRight && state != StateType.Jump && state != StateType.JumpRight && state != StateType.JumpLeft)
                {
                    state = StateType.movingRight;
                    SetImage("Characters/KnightRunRight.gif");
                }
                if (state == StateType.Jump)
                {
                    state = StateType.JumpRight;
                    SetImage("Characters/KnightRunRight.gif");
                }

                _dX = 8;
            }

            if (key == Keys.Leftkey)
            {
                if (state != StateType.movingLeft && state != StateType.Jump && state != StateType.JumpRight && state != StateType.JumpLeft)
                {
                    state = StateType.movingLeft;
                    SetImage("Characters/KnightRunLeft.gif");
                }
                if (state == StateType.Jump)
                {
                    state = StateType.JumpLeft;
                    SetImage("Characters/KnightRunLeft.gif");
                }

                _dX = -8;
            }

        }

        private void Stop(VirtualKey key)
        {

            if (state != StateType.JumpLeft && state != StateType.JumpRight && state != StateType.Jump)
            {
                if (key != Keys.Upkey)
                {
                    base.Stop();
                }
            }
            else
            {
                if (key != Keys.Upkey)
                {
                    _dX = 0;
                }
            }
           
            
                if (state == StateType.movingRight && state != StateType.JumpRight || state != StateType.movingRight && state == StateType.JumpRight)
                {
                    SetImage("Characters/KnightIdleRight.gif");
                    state = StateType.idelRight;
                }
                if (state == StateType.movingLeft && state != StateType.JumpLeft || state != StateType.movingLeft && state == StateType.JumpLeft)
                {
                    SetImage("Characters/KnightIdleLeft.gif");
                    state = StateType.idelLeft;
                }
            
          

        }



    }
}



    

