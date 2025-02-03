using GameEngine.GameObjects;
using GameEngine.GameServices;
using Path_To_Glory.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameObjects
{
    class Spectre : GameMovingObject
    {
        public enum StateType
        {
            idelLeft, idelRight, movingLeft, movingRight, JumpLeft, JumpRight, DashR, DashL,Death
        }

        public bool InAnimation { get; set; } = false;
        private bool _DashAnimation = false;
        private bool _dashinair = false;
        private bool _Hit = false;
        private bool _OnPlatform = false;
        
        public StateType _state { get; set; }
        private static int Hp = GameManager.GameUser.Hp;
        private static int Coins = GameManager.GameUser.Coins;
        private bool touchingrightwall = false;
        public Spectre(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
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
            if (Rect.Right >= _scene?.ActualWidth && !touchingrightwall  && _state != StateType.Death)
            {
                touchingrightwall = true;
                _X = _scene.ActualWidth - Image.Height;
                GameManager.Events.OnNextRoom();
                

            }

            


        }
        public void Dash()
        {
            if (_state == StateType.idelLeft || _state == StateType.movingLeft || _state == StateType.JumpLeft)
            {
                if(_state == StateType.JumpLeft)
                {
                    _dashinair = true;
                }
                _DashAnimation = true;
                _ddX = -1;
                SetImage("Characters/DashLeft.gif");
                _state = StateType.DashL;
            }
            if (_state == StateType.idelRight || _state == StateType.movingRight || _state == StateType.JumpRight)
            {
                if (_state == StateType.JumpRight)
                {
                    _dashinair = true;
                }
                _DashAnimation = true;
                _ddX = 1;
                SetImage("Characters/DashRight.gif");
                _state = StateType.DashR;
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(400);
            timer.Tick += (sender, e) =>
            {
                _ddX = 0;
                if(_state == StateType.DashR)
                {
                    _DashAnimation = false;
                    _dX = 5;
                    SetImage("Characters/RunRight.gif");
                    if (_dashinair)
                    {
                        _state = StateType.JumpRight;
                    }
                    else
                    {
                        _state = StateType.movingRight;
                    }
                }
                if (_state == StateType.DashL)
                {
                    _DashAnimation = false;
                    _dX = -5;
                    SetImage("Characters/RunLeft.gif");
                    if (_dashinair)
                    {
                        _state = StateType.JumpLeft;
                    }
                    else
                    {
                        _state = StateType.movingLeft;
                    }
                }
                timer.Stop();
            };
            timer.Start();
        }
        public void Jump()
        {

            if (_dX == 0)
            {
                if (_state == StateType.idelRight)
                {
                    SetImage("Characters/JumpRight.gif");
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(650);
                    timer.Tick += (sender, e) =>
                    {
                        SetImage("Characters/JumpLastFrameR.png");
                        timer.Stop();
                    };
                    timer.Start();
                    _state = StateType.JumpRight;
                }
                if (_state == StateType.idelLeft)
                {
                    SetImage("Characters/JumpLeft.gif");
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(650);
                    timer.Tick += (sender, e) =>
                    {
                        SetImage("Characters/JumpLastFrameL.png");
                        timer.Stop();
                    };
                    timer.Start();
                    _state = StateType.JumpLeft;
                }
            }

            if (_dX > 0)
            {
                SetImage("Characters/JumpRight.gif");
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(650);
                timer.Tick += (sender, e) =>
                {
                    SetImage("Characters/JumpLastFrameR.png");
                    timer.Stop();
                };
                timer.Start();
                _state = StateType.JumpRight;
            }

            if (_dX < 0)
            {
                SetImage("Characters/JumpLeft.gif");
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(650);
                timer.Tick += (sender, e) =>
                {
                    SetImage("Characters/JumpLastFrameL.png");
                    timer.Stop();
                };
                timer.Start();
                _state = StateType.JumpLeft;
            }
            _dY = -20;
        }
        private void Slash()
        {
            
            InAnimation = true;
            if (_state == StateType.idelLeft || _state == StateType.movingLeft || _state == StateType.JumpLeft)
            {
                _X -= 70;
                SetImage("Characters/AtkTst.gif");
            }
            if (_state == StateType.idelRight || _state == StateType.movingRight || _state == StateType.JumpRight)
            {
                
                SetImage("Characters/AtkTstR.gif");
            }
            Image.Height += 7;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += (sender, e) =>
            {
                if (_dX == 0)
                {
                    if (_state == StateType.idelRight)
                    {
                        SetImage("Characters/IdleRight.gif");
                        _state = StateType.idelRight;
                        
                    }
                    if (_state == StateType.idelLeft)
                    {
                        SetImage("Characters/IdleLeft.gif");
                        _state = StateType.idelLeft;
                       
                    }
                    
                }
                if (_dX > 0)
                {
                    _state = StateType.movingRight;                   
                    SetImage("Characters/RunRight.gif");
                    
                    
                }
                if (_dX < 0)
                {
                    _state = StateType.movingLeft;
                    SetImage("Characters/RunLeft.gif");


                }
                if(_state == StateType.idelLeft || _state == StateType.movingLeft || _state == StateType.JumpLeft)
                {
                    _X += 70;
                }
               
                Image.Height -= 7;
                InAnimation = false;
                timer.Stop();
            };
            timer.Start();
           

        }


        private void Go(VirtualKey key)
        {
            var state = _state;
            if( _state != StateType.Death && !InAnimation) { 
            if (key == Keys.Interact && _dX !=0)
            {
                Dash();
            }
            if (key == Keys.Slash && InAnimation == false && _state != StateType.JumpRight && _state != StateType.JumpLeft)
            {
                Slash();
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
                if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
                {
                    _state = StateType.movingRight;
                    if (state != _state)
                    {
                        SetImage("Characters/RunRight.gif");
                    }
                }
                if(_state == StateType.JumpRight || _state == StateType.JumpLeft)
                {


                    SetImage("Characters/JumpLastFrameR.png");
                    _state = StateType.JumpRight;
                    
                }
                _dX = 5;
                
            }

                if (key == Keys.Leftkey)
                {
                    if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
                    {
                        _state = StateType.movingLeft;
                        if (state != _state)
                        {
                            SetImage("Characters/RunLeft.gif");
                        }
                    }
                    if (_state == StateType.JumpRight || _state == StateType.JumpLeft)
                    {


                        SetImage("Characters/JumpLastFrameL.png");
                        _state = StateType.JumpLeft;

                    }
                    _dX = -5;
                }
            }

        }

        public override void Stop()
        {
            _dX = _dY = _ddX = 0;
        }
        private void Stop(VirtualKey key)
        {


            if (_state != StateType.JumpLeft && _state != StateType.JumpRight)
            {
                if (key != Keys.Upkey && key != Keys.Slash && key != Keys.Interact)
                {
                    Stop();
                }
            }
            else
            {
                if (key != Keys.Upkey && key != Keys.Slash && key != Keys.Interact)
                {
                    _dX = 0;
                }
            }


            if (_state == StateType.movingRight && _state != StateType.JumpRight && key != Keys.Slash && key != Keys.Interact)
            {
                if (!InAnimation)
                {
                    SetImage("Characters/IdleRight.gif");
                }
                _state = StateType.idelRight;
            }

            if (_state == StateType.movingLeft && _state != StateType.JumpLeft && key != Keys.Slash && key != Keys.Interact)
            {
                if (!InAnimation)
                {
                    SetImage("Characters/IdleLeft.gif");
                }
                _state = StateType.idelLeft;
            }
        }
        public override void Collide(List<GameObject> gameObject)
        {
            var state = _state;
            foreach (var otherobject in gameObject)
            {
                
                if (otherobject is Coin)
                {
                    Coins++;
                    GameManager.GameUser.Coins++;
                    Manager.GameEvent.OnGetCoin(Coins);
                    _scene.RemoveObject(otherobject);
                }
                else
                if (otherobject is Ground)
                {
                    
                    _Y = _scene.ActualHeight - 100;
                    _dY = 0;
                    _Y -= 1;
                    _OnPlatform = false;
                    if(_dX == 0)
                    {
                        if(_state == StateType.JumpRight)
                        {
                            SetImage("Characters/IdleRight.gif");
                            _state = StateType.idelRight;
                        }
                        if (_state == StateType.JumpLeft)
                        {
                            SetImage("Characters/IdleLeft.gif");
                            _state = StateType.idelLeft;
                        }
                    }
                    if (_dX > 0 && _DashAnimation == false)
                    {
                        _state = StateType.movingRight;
                        if (state != _state)
                        {
                            SetImage("Characters/RunRight.gif");
                        }
                       
                    }
                    if (_dX < 0 && _DashAnimation == false)
                    {
                        _state = StateType.movingLeft;
                        if (state != _state)
                        {
                            SetImage("Characters/RunLeft.gif");
                        }
                        
                    }

                }
                if(otherobject is ReaperSlash && !_Hit)
                {
                    ReaperSlash ReaperSlash = (ReaperSlash)otherobject;
                    if (!InAnimation && _state != StateType.Death)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1000);
                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/HitRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/HitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {

                            if (_state == StateType.JumpRight)
                            {
                                SetImage("Characters/JumpLastFrameR.png");
                            }
                            if (_state == StateType.idelRight)
                            {
                                SetImage("Characters/IdleRight.gif");
                            }
                            if (_state == StateType.movingRight)
                            {
                                SetImage("Characters/RunRight.gif");
                            }
                            if (_state == StateType.JumpLeft)
                            {
                                SetImage("Characters/JumpLastFrameL.png");
                            }
                            if (_state == StateType.idelLeft)
                            {
                                SetImage("Characters/IdleLeft.gif");
                            }
                            if (_state == StateType.movingLeft)
                            {
                                SetImage("Characters/RunLeft.gif");
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        Manager.GameEvent.OnRemoveLife(Hp);
                        GameManager.GameUser.Hp--;
                        Hp--;
                        timer.Start();

                    }
                    else
                    {
                        _scene.RemoveObject(ReaperSlash);
                    }
                    if (Hp <= 0 && _state != StateType.Death)
                    {

                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/DeathRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/DeathLeft.gif");
                        }
                        _state = StateType.Death;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1500);
                        timer.Tick += (sender, e) =>
                        {
                            Manager.GameEvent.OnGameOver();
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
                if(otherobject is Reaper && !_Hit)
                {
                    Reaper Reaper = (Reaper)otherobject;
                    if (!InAnimation && _state != StateType.Death && Reaper.Alive)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1000);
                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/HitRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/HitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {

                            if (_state == StateType.JumpRight)
                            {
                                SetImage("Characters/JumpLastFrameR.png");
                            }
                            if (_state == StateType.idelRight)
                            {
                                SetImage("Characters/IdleRight.gif");
                            }
                            if (_state == StateType.movingRight)
                            {
                                SetImage("Characters/RunRight.gif");
                            }
                            if (_state == StateType.JumpLeft)
                            {
                                SetImage("Characters/JumpLastFrameL.png");
                            }
                            if (_state == StateType.idelLeft)
                            {
                                SetImage("Characters/IdleLeft.gif");
                            }
                            if (_state == StateType.movingLeft)
                            {
                                SetImage("Characters/RunLeft.gif");
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        Manager.GameEvent.OnRemoveLife(Hp);
                        GameManager.GameUser.Hp--;
                        Hp--;
                        timer.Start();

                    }
                    else
                    {
                        Reaper.Get_Self(Reaper);
                    }
                    if (Hp <= 0 && _state != StateType.Death)
                    {

                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/DeathRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/DeathLeft.gif");
                        }
                        _state = StateType.Death;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1500);
                        timer.Tick += (sender, e) =>
                        {
                            Manager.GameEvent.OnGameOver();
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
                if (otherobject is MonsterA && !_Hit)
                {
                    MonsterA Golem = (MonsterA)otherobject;
                    if (!InAnimation && _state != StateType.Death && Golem.Alive)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1000);
                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/HitRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/HitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {

                            if (_state == StateType.JumpRight)
                            {
                                SetImage("Characters/JumpLastFrameR.png");
                            }
                            if (_state == StateType.idelRight)
                            {
                                SetImage("Characters/IdleRight.gif");
                            }
                            if (_state == StateType.movingRight)
                            {
                                SetImage("Characters/RunRight.gif");
                            }
                            if (_state == StateType.JumpLeft)
                            {
                                SetImage("Characters/JumpLastFrameL.png");
                            }
                            if (_state == StateType.idelLeft)
                            {
                                SetImage("Characters/IdleLeft.gif");
                            }
                            if (_state == StateType.movingLeft)
                            {
                                SetImage("Characters/RunLeft.gif");
                            }
                            _Hit = false;

                            
                            timer.Stop();
                        };
                        Manager.GameEvent.OnRemoveLife(Hp);
                        GameManager.GameUser.Hp--;
                        Hp--;
                        timer.Start();

                    }
                    else
                    {
                        
                        Golem.Get_Self(Golem);
                        
                    }
                    if(Hp <= 0 && _state != StateType.Death)
                    {
                       
                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/DeathRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/DeathLeft.gif");
                        }
                        _state = StateType.Death;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1500);
                        timer.Tick += (sender, e) =>
                        {
                            Manager.GameEvent.OnGameOver();
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
                if (otherobject is Skeleton && !_Hit)
                {
                    Skeleton Skeleton = (Skeleton)otherobject;
                    if (!InAnimation && _state != StateType.Death && Skeleton.Alive)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1000);
                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/HitRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/HitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {

                            if (_state == StateType.JumpRight)
                            {
                                SetImage("Characters/JumpLastFrameR.png");
                            }
                            if (_state == StateType.idelRight)
                            {
                                SetImage("Characters/IdleRight.gif");
                            }
                            if (_state == StateType.movingRight)
                            {
                                SetImage("Characters/RunRight.gif");
                            }
                            if (_state == StateType.JumpLeft)
                            {
                                SetImage("Characters/JumpLastFrameL.png");
                            }
                            if (_state == StateType.idelLeft)
                            {
                                SetImage("Characters/IdleLeft.gif");
                            }
                            if (_state == StateType.movingLeft)
                            {
                                SetImage("Characters/RunLeft.gif");
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        Manager.GameEvent.OnRemoveLife(Hp);
                        GameManager.GameUser.Hp--;
                        Hp--;
                        timer.Start();

                    }
                    else
                    {

                        Skeleton.Get_Self(Skeleton);

                    }
                    if (Hp <= 0 && _state != StateType.Death)
                    {

                        if (_state == StateType.JumpRight || _state == StateType.idelRight || _state == StateType.movingRight)
                        {
                            SetImage("Characters/DeathRight.gif");
                        }
                        if (_state == StateType.JumpLeft || _state == StateType.idelLeft || _state == StateType.movingLeft)
                        {
                            SetImage("Characters/DeathLeft.gif");
                        }
                        _state = StateType.Death;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(1500);
                        timer.Tick += (sender, e) =>
                        {
                            _scene.RemoveAllObjects();
                            Manager.GameEvent.OnGameOver();
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
                if (otherobject is FloorHp && Hp < 3)
                {
                    Manager.GameEvent.OnGetLife(Hp);
                    GameManager.GameUser.Hp++;
                    Hp++;
                    _scene.RemoveObject(otherobject);
                }





                if (otherobject is Platform platform)
                {
                    var rect = RectHelper.Intersect(Rect, platform.Rect);
                    if (rect.Width <= rect.Height) //מהצד
                    {
                        if (_dX < 0 )
                        {
                            if (!_OnPlatform)
                            {
                                _X += 9;
                            }
                            else
                            {
                                _X += 1;
                            }
                        }
                        if (_dX > 0 )
                        {

                            if (!_OnPlatform)
                            {
                                _X -= 9;
                            }
                            else
                            {
                                _X -= 1;
                            }
                        }
                    }
                    if (rect.Width > rect.Height)  //מלמעלה או מלמטה
                    {

                        if (_dY > 0 )    //מלמעלה
                        {


                            
                                _dY = 0;
                                _Y -= 1;
                                _OnPlatform = true;
                            
                            if (_dX == 0)
                            {
                                if (_state == StateType.JumpRight)
                                {
                                    SetImage("Characters/IdleRight.gif");
                                    _state = StateType.idelRight;
                                }
                                if (_state == StateType.JumpLeft)
                                {
                                    SetImage("Characters/IdleLeft.gif");
                                    _state = StateType.idelLeft;
                                }
                            }
                            if (_dX > 0 && _DashAnimation == false)
                            {
                                _state = StateType.movingRight;
                                if (state != _state)
                                {
                                    SetImage("Characters/RunRight.gif");
                                }

                            }
                            if (_dX < 0 && _DashAnimation == false)
                            {
                                _state = StateType.movingLeft;
                                if (state != _state)
                                {
                                    SetImage("Characters/RunLeft.gif");
                                }

                            }

                        }
                            else          //מלמטה
                            {
                                _dY = -_dY;
                            }
                        }
                    }
                if (otherobject is Wall wall)
                {
                    var rect = RectHelper.Intersect(Rect, wall.Rect);
                    if (rect.Width <= rect.Height) //מהצד
                    {
                        if (_dX < 0)
                        {
                           
                            _X += 9;
                        }
                        if (_dX > 0)
                        {

                            
                            _X -= 9;
                        }
                    }
                    if (rect.Width > rect.Height)  //מלמעלה או מלמטה
                    {

                        if (_dY > 0)    //מלמעלה
                        {



                            _dY = 0;
                            _Y -= 1;
                            if (_dX == 0)
                            {
                                if (_state == StateType.JumpRight)
                                {
                                    SetImage("Characters/IdleRight.gif");
                                    _state = StateType.idelRight;
                                }
                                if (_state == StateType.JumpLeft)
                                {
                                    SetImage("Characters/IdleLeft.gif");
                                    _state = StateType.idelLeft;
                                }
                            }
                            if (_dX > 0 && _DashAnimation == false)
                            {
                                _state = StateType.movingRight;
                                if (state != _state)
                                {
                                    SetImage("Characters/RunRight.gif");
                                }

                            }
                            if (_dX < 0 && _DashAnimation == false)
                            {
                                _state = StateType.movingLeft;
                                if (state != _state)
                                {
                                    SetImage("Characters/RunLeft.gif");
                                }

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
    }








    

