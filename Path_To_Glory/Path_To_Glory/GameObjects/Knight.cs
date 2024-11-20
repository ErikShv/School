using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameObjects
{
    class Knight : GameMovingObject
    {
        public enum StateType
        {
            idelLeft, idelRight, movingLeft, movingRight, JumpLeft, JumpRight
        }   
        private DateTime _lastShotTime = DateTime.MinValue;
        private TimeSpan _shootCooldown = TimeSpan.FromMilliseconds(200);
        public StateType _state { get; set; }
        public Knight(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Manager.GameEvent.OnKeyDown += Go;
            Manager.GameEvent.OnKeyUp += Stop;
            Image.Height = 75;
            _state = StateType.idelRight;
            _ddY = 1;
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

          
            
        }
        public void Jump()
        {

            
            if (_state == StateType.movingLeft || _state == StateType.idelLeft)
            {
                _state = StateType.JumpLeft;
            }
            if (_state == StateType.movingRight || _state == StateType.idelRight)
            {
                _state = StateType.JumpRight;
            }
            _dY = -20;
        }
        private void Shoot()
        {

            if (DateTime.Now - _lastShotTime < _shootCooldown)
            {
                return;
            }


            _lastShotTime = DateTime.Now;


            if (_state == StateType.movingRight || _state == StateType.idelRight || _state == StateType.JumpRight)
            {
                _scene.AddObject(new Bullet(_scene, "FloorItems/bullet2.png", _X + 50, _Y + 10, true));
            }
            if (_state == StateType.movingLeft || _state == StateType.idelLeft || _state == StateType.JumpLeft)
            {
                _scene.AddObject(new Bullet(_scene, "FloorItems/BulletLeft2.png", _X - 50, _Y + 10, false));
            }
        }


        private void Go(VirtualKey key)
        {
            var state = _state;


            if (key == Keys.Shoot)
            {
                Shoot();
            }
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
                        SetImage("Characters/KnightRunRight2.gif");
                    }
                }
                else
                {

                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunRight2.gif");
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
                        SetImage("Characters/KnightRunLeft2.gif");
                    }
                }
                else
                {

                    if (state != _state)
                    {
                        SetImage("Characters/KnightRunLeft2.gif");
                    }
                    _state = StateType.JumpLeft;
                }
                _dX = -8;
            }

        }

        public override void Stop()
        {
            _dX = _dY = _ddX =0;
        }
        private void Stop(VirtualKey key)
        {


            if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
            {
                if (key != Keys.Upkey && key != Keys.Shoot)
                {
                    Stop();
                }
            }
            else
            {
                if (key != Keys.Upkey && key != Keys.Shoot)
                {
                    _dX = 0;
                }
            }


            if (_state == StateType.movingRight && _state != StateType.JumpRight && key != Keys.Shoot)
            {
                SetImage("Characters/KnightIdleRight2.gif");
                _state = StateType.idelRight;
            }

            if (_state == StateType.movingLeft && _state != StateType.JumpLeft && key != Keys.Shoot)
            {
                SetImage("Characters/KnightIdleLeft2.gif");
                _state = StateType.idelLeft;
            }
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject is Coin)
            {
                _scene.RemoveObject(gameObject);
            }
            else
            if (gameObject is Ground)
            {
                
                _dY = 0;
                _Y -= 1;
                if (_state == StateType.JumpLeft && _dX != 0)
                {
                    _state = StateType.movingLeft;
                }
                if (_state == StateType.JumpRight && _dX != 0)
                {
                    _state = StateType.movingRight;
                }
                if (_state == StateType.JumpLeft && _dX == 0)
                {
                    SetImage("Characters/KnightIdleLeft2.gif");
                    _state = StateType.idelLeft;
                }
                if (_state == StateType.JumpRight && _dX == 0)
                {
                    SetImage("Characters/KnightIdleRight2.gif");
                    _state = StateType.idelRight;
                }
            }

            if (gameObject is Platform platform)
            {
                var rect = RectHelper.Intersect(Rect, platform.Rect);
                if(rect.Width<=rect.Height) //מהצד
                {
                    if (_dX < 0)
                    {
                        _dX = 0;
                        _X +=2;
                    }
                    if (_dX > 0)
                    {
                        
                        _dX = 0;
                        _X -= 2;
                    }
                }
                if(rect.Width > rect.Height)  //מלמעלה או מלמטה
                {
                   
                    if(_dY>0)    //מלמעלה
                    {
                        
                        _dY = 0;
                        _Y -= 1;
                        if (_state == StateType.JumpLeft && _dX != 0)
                        {
                            _state = StateType.movingLeft;
                        }
                        if (_state == StateType.JumpRight && _dX != 0)
                        {
                            _state = StateType.movingRight;
                        }
                        if (_state == StateType.JumpLeft && _dX == 0)
                        {
                            SetImage("Characters/KnightIdleLeft2.gif");
                            _state = StateType.idelLeft;
                        }
                        if (_state == StateType.JumpRight && _dX == 0)
                        {
                            SetImage("Characters/KnightIdleRight2.gif");
                            _state = StateType.idelRight;
                        }
                    }
                    else          //מלמטה
                    {
                        _dY = -_dY;
                    }
                }
            }
        }
    }    
}







    

