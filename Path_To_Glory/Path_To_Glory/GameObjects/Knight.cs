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
            idelLeft, idelRight, movingLeft, movingRight, JumpLeft, JumpRight
        }

        public StateType _state { get; set; }
        public Knight(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Manager.GameEvent.OnKeyDown += Go;
            Manager.GameEvent.OnKeyUp += Stop;
            Image.Height = 200;
            _state = StateType.idelRight;
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
                if(_state == StateType.JumpLeft && _dX != 0)
                {
                    _state = StateType.movingLeft;
                }
                if (_state == StateType.JumpRight && _dX != 0)
                {
                    _state = StateType.movingRight;
                }
                if (_state == StateType.JumpLeft && _dX == 0)
                {
                    SetImage("Characters/KnightIdleLeft.gif");
                    _state = StateType.idelLeft;
                }
                if (_state == StateType.JumpRight && _dX == 0)
                {
                    SetImage("Characters/KnightIdleRight.gif");
                    _state = StateType.idelRight;
                }
                _Y = _scene.ActualHeight -Image.ActualHeight;
                _ddY = 0;
                _dY = 0;
            }
        }
        public void Jump()
        {
            if(_state == StateType.movingLeft || _state == StateType.idelLeft)
            {
                _state = StateType.JumpLeft;
            }
            if (_state == StateType.movingRight || _state == StateType.idelRight)
            {
                _state = StateType.JumpRight;
            }
            _dY = -20;
            _ddY = 1;
        }
        private void Shoot()
        {
            _scene.AddObject()
        }


        private void Go(VirtualKey key)
        {
            var state = _state;
            if (key == Keys.Upkey)
            {
                if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
                {
                    Jump();
                }
            }
            if (key == Keys.Rightkey)
            {
                if (_state != StateType.JumpRight && _state != StateType.JumpLeft)
                {
                    _state = StateType.movingRight;
                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunRight.gif");
                    }
                }
                else
                {
                    
                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunRight.gif");
                    }
                    _state = StateType.JumpRight;
                }
                _dX = 8;
            }

            if (key == Keys.Leftkey)
            {
                if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
                {
                    _state = StateType.movingLeft;
                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunLeft.gif");
                    }
                }
                else
                {
                   
                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunLeft.gif");
                    }
                    _state = StateType.JumpLeft;
                }
                _dX = -8;
            }

        }

        private void Stop(VirtualKey key)
        {


            if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
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


            if (_state == StateType.movingRight && _state != StateType.JumpRight)
            {
                SetImage("Characters/KnightIdleRight.gif");
                _state = StateType.idelRight;
            }

            if (_state == StateType.movingLeft && _state != StateType.JumpLeft)
            {
                SetImage("Characters/KnightIdleLeft.gif");
                _state = StateType.idelLeft;
            }
        }
        public override void Collide(GameObject gameObject)
        {
           if(gameObject is Coin)
            {
                _scene.RemoveObject(gameObject);
            }

        }
    }
}



    

