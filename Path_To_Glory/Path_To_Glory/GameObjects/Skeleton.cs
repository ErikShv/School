using GameEngine.GameObjects;
using GameEngine.GameServices;
using Path_To_Glory.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameObjects
{
    class Skeleton : GameMovingObject
    {
        public Skeleton(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 50;
            _ddY = 1;
            if (Alive)
            {
                _dX = 2;
            }
        }
        public bool _LookRight { get; set; } = true;
        public bool Alive { get; set; } = true;
        private bool _Hit = false;
        private bool _HitWall = false;
        private bool _HitEndPlatform = false;
        private bool _Atk = false;
        public int SkeletonHp { get; set; } = GameManager.GameUser.CurrentLevel.SkeletonHp;
        private Skeleton _self;
        public void Get_Self(Skeleton Self)
        {
            _self = Self;
        }
        public override void Render()
        {
            base.Render();
            if (Rect.Left <= 0 && !_HitWall && Alive)
            {
                _HitWall = true;
                _X = 0;
                _dX = 0;
                SetImage("Characters/SkeletonIdleLeft.gif");

                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += (sender, e) =>
                {

                    _dX = 2;
                    _LookRight = true;
                    SetImage("Characters/SkeletonWalkRight.gif");
                    DispatcherTimer timer2 = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(1000);
                    timer.Tick += (sender2, e2) =>
                    {

                        _HitWall = false;
                        timer2.Stop();
                    };
                    timer2.Start();
                    timer.Stop();
                };
                timer.Start();

            }
            if (Rect.Right >= _scene?.ActualWidth && Alive)
            {
                _HitWall = true;
                _X = _scene.ActualWidth - Image.Height - 5;
                _dX = 0;
                SetImage("Characters/SkeletonIdleRight.gif");
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += (sender, e) =>
                {

                    _dX = -2;
                    _LookRight = false;
                    SetImage("Characters/SkeletonWalkLeft.gif");
                    DispatcherTimer timer2 = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(1000);
                    timer.Tick += (sender2, e2) =>
                    {

                        _HitWall = false;
                        timer2.Stop();
                    };
                    timer2.Start();
                    timer.Stop();
                };
                timer.Start();
            }




        }
        public override void Collide(List<GameObject> gameObject)
        {
            foreach (var otherobject in gameObject)
            {
                var spctr = otherobject;
                if (otherobject is Spectre)
                {
                    Spectre spectre = (Spectre)spctr;

                    if (Alive)
                    {
                        if (SkeletonHp <= 0)
                        {
                            Alive = false;
                            if (_LookRight)
                            {
                                SetImage("Characters/SkeletonDeathRight.gif");
                            }
                            if (!_LookRight)
                            {
                                SetImage("Characters/SkeletonDeathLeft.gif");
                            }
                            _dX = 0;

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1100);
                            timer.Tick += (sender, e) =>
                            {
                                _scene.RemoveObject(_self);
                                GameManager.GameUser.CurrentLevel.CountSkeleton--;
                                GameManager.GameUser.CurrentLevel.CountMonster--;
                                timer.Stop();
                            };
                            timer.Start();

                        }
                    }
                    if (spectre.InAnimation == true && !_Hit && Alive)
                    {
                        _Hit = true;
                        _dX = 0;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(500);
                        
                        timer.Tick += (sender, e) =>
                        {
                            if (Alive)
                            {
                                if (_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleRight.gif");
                                }
                                if (!_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleLeft.gif");
                                }
                                if (_LookRight)
                                {
                                    _dX = 2;
                                    SetImage("Characters/SkeletonWalkRight.gif");
                                }
                                if (!_LookRight)
                                {
                                    _dX = -2;
                                    SetImage("Characters/SkeletonWalkLeft.gif");
                                }
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        SkeletonHp--;
                        timer.Start();


                    }
                    if (!spectre.InAnimation && Alive)
                    {
                        if (!_Atk)
                        {
                            _Atk = true;
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            


                            if (_LookRight)
                            {
                                SetImage("Characters/SkeletonAtkRight.gif");
                            }
                            if (!_LookRight)
                            {
                                SetImage("Characters/SkeletonAtkLeft.gif");
                            }
                            timer.Tick += (sender, e) =>
                            {

                                if (_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleRight.gif");
                                }
                                if (!_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleLeft.gif");
                                }
                                if (_LookRight)
                                {
                                    SetImage("Characters/SkeletonWalkRight.gif");
                                }
                                if (!_LookRight)
                                {
                                    SetImage("Characters/SkeletonWalkLeft.gif");
                                }
                                _Atk = false;
                               
                                timer.Stop();
                            };
                            timer.Start();
                        }
                    }

                }
                if (otherobject is PlayerSlash)
                {
                    PlayerSlash slash =(PlayerSlash)otherobject;

                    if (Alive)
                    {
                        if (SkeletonHp <= 0)
                        {
                            Alive = false;
                            if (_LookRight)
                            {
                                SetImage("Characters/SkeletonDeathRight.gif");
                            }
                            if (!_LookRight)
                            {
                                SetImage("Characters/SkeletonDeathLeft.gif");
                            }
                            _dX = 0;

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1100);
                            timer.Tick += (sender, e) =>
                            {
                                _scene.RemoveObject(_self);
                                GameManager.GameUser.CurrentLevel.CountSkeleton--;
                                GameManager.GameUser.CurrentLevel.CountMonster--;
                                timer.Stop();
                            };
                            timer.Start();

                        }
                    }
                    if (!_Hit && Alive)
                    {
                        _Hit = true;
                        _dX = 0;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(500);

                        timer.Tick += (sender, e) =>
                        {
                            if (Alive)
                            {
                                if (_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleRight.gif");
                                }
                                if (!_LookRight && _dX == 0)
                                {
                                    SetImage("Characters/SkeletonIdleLeft.gif");
                                }
                                if (_LookRight)
                                {
                                    _dX = 2;
                                    SetImage("Characters/SkeletonWalkRight.gif");
                                }
                                if (!_LookRight)
                                {
                                    _dX = -2;
                                    SetImage("Characters/SkeletonWalkLeft.gif");
                                }
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        SkeletonHp--;
                        timer.Start();

                        _scene.RemoveObject(slash);
                    }
                    
                    
                }

                if (otherobject is Ground)
                {

                    _dY = 0;
                    _Y -= 1;
                }

                if (otherobject is Platform platform)
                {
                    var rect = RectHelper.Intersect(Rect, platform.Rect);
                    if (rect.Width <= rect.Height + 20 && Alive) //מהצד
                    {
                        if (_dX < 0)
                        {


                            _X += 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/SkeletonIdleLeft.gif");

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = 2;
                                _LookRight = true;
                                SetImage("Characters/SkeletonWalkRight.gif");
                                DispatcherTimer timer2 = new DispatcherTimer();
                                timer.Interval = TimeSpan.FromMilliseconds(1000);
                                timer.Tick += (sender2, e2) =>
                                {

                                    _HitEndPlatform = false;
                                    timer2.Stop();
                                };
                                timer2.Start();
                                timer.Stop();
                            };
                            timer.Start();

                        }
                        if (_dX > 0 && Alive)
                        {


                            _X -= 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/SkeletonIdleRight.gif");
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = -2;
                                _LookRight = false;
                                SetImage("Characters/SkeletonWalkLeft.gif");
                                DispatcherTimer timer2 = new DispatcherTimer();
                                timer.Interval = TimeSpan.FromMilliseconds(1000);
                                timer.Tick += (sender2, e2) =>
                                {

                                    _HitEndPlatform = false;
                                    timer2.Stop();
                                };
                                timer2.Start();
                                timer.Stop();
                            };
                            timer.Start();
                        }
                    }
                    if (rect.Width > rect.Height)  //מלמעלה או מלמטה
                    {

                        if (_dY > 0)    //מלמעלה
                        {

                            _dY = 0;
                            _Y -= 1;

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
                    if (rect.Width <= rect.Height + 20 && Alive) //מהצד
                    {
                        if (_dX < 0)
                        {


                            _X += 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/SkeletonIdleLeft.gif");

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = 2;
                                _LookRight = true;
                                SetImage("Characters/SkeletonWalkRight.gif");
                                DispatcherTimer timer2 = new DispatcherTimer();
                                timer.Interval = TimeSpan.FromMilliseconds(1000);
                                timer.Tick += (sender2, e2) =>
                                {

                                    _HitEndPlatform = false;
                                    timer2.Stop();
                                };
                                timer2.Start();
                                timer.Stop();
                            };
                            timer.Start();

                        }
                        if (_dX > 0 && Alive)
                        {


                            _X -= 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/SkeletonIdleRight.gif");
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = -2;
                                _LookRight = false;
                                SetImage("Characters/SkeletonWalkLeft.gif");
                                DispatcherTimer timer2 = new DispatcherTimer();
                                timer.Interval = TimeSpan.FromMilliseconds(1000);
                                timer.Tick += (sender2, e2) =>
                                {

                                    _HitEndPlatform = false;
                                    timer2.Stop();
                                };
                                timer2.Start();
                                timer.Stop();
                            };
                            timer.Start();
                        }
                    }
                    if (rect.Width > rect.Height)  //מלמעלה או מלמטה
                    {

                        if (_dY > 0)    //מלמעלה
                        {

                            _dY = 0;
                            _Y -= 1;

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
