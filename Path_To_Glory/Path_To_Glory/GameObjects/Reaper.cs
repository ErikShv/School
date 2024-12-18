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
    class Reaper : GameMovingObject
    {
        public int ReaperHp { get; set; } = 1;
        public bool _LookRight { get; set; }
        private bool _Hit = false;
        private bool _Atk = false;
        public bool Alive { get; set; } = true;
        private Reaper _self;

        public Reaper(Scene scene, string fileName, double placeX, double placeY, bool LookRight) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 80;
            _LookRight = LookRight;
            _ddY = 1;
        }
        public void Get_Self(Reaper Self)
        {
            _self = Self;
        }
        public override void Render()
        {
            base.Render();
            if (!_Atk && Alive)
            {
                _Atk = true;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(400);
                timer.Tick += (sender, e) =>
                {
                    if (Alive)
                    {
                        if (_LookRight)
                        {
                            SetImage("Characters/ReaperIdleRight.gif");
                        }
                        if (!_LookRight)
                        {
                            SetImage("Characters/ReaperIdleLeft.gif");
                        }
                    }
                    DispatcherTimer timer2 = new DispatcherTimer();
                    timer2.Interval = TimeSpan.FromMilliseconds(3000);
                    timer2.Tick += (sender2, e2) =>
                    {
                        if (Alive)
                        {
                            if (_LookRight)
                            {
                                SetImage("Characters/ReaperAtkRight.gif");
                            }
                            if (!_LookRight)
                            {
                                SetImage("Characters/ReaperAtkLeft.gif");
                            }
                        }
                        
                        DispatcherTimer timer3 = new DispatcherTimer();
                        timer3.Interval = TimeSpan.FromMilliseconds(100);
                        timer3.Tick += (sender3, e3) =>
                        {
                            if (Alive)
                            {
                                if (_LookRight)
                                {
                                    _scene.AddObject(new ReaperSlash(_scene, "Projectiles/ReaperSlashRight.gif", _X + 40, _Y + 20, true));
                                }
                                if (!_LookRight)
                                {
                                    _scene.AddObject(new ReaperSlash(_scene, "Projectiles/ReaperSlashLeft.gif", _X, _Y + 20, false));
                                }
                            }
                            _Atk = false;
                            timer3.Stop();
                        };
                        timer3.Start();
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
                if (otherobject is Ground)
                {

                    _dY = 0;
                    _Y -= 1;
                }
                if (otherobject is Platform platform)
                {
                    var rect = RectHelper.Intersect(Rect, platform.Rect);

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
                if (otherobject is Spectre)
                {
                    Spectre spectre = (Spectre)spctr;

                    if (Alive)
                    {
                        if (ReaperHp <= 0)
                        {
                            Alive = false;
                            if (_LookRight)
                            {
                                SetImage("Characters/ReaperDeathRight.gif");
                            }
                            if (!_LookRight)
                            {
                                SetImage("Characters/ReaperDeathLeft.gif");
                            }
                           

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(800);
                            timer.Tick += (sender, e) =>
                            {
                                _scene.RemoveObject(_self);
                                GameManager.GameUser.CurrentLevel.CountReaper--;
                                GameManager.GameUser.CurrentLevel.CountMonster--;
                                timer.Stop();
                            };
                            timer.Start();

                        }
                    }
                    if (spectre.InAnimation == true && !_Hit && Alive)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(500);
                        if (_LookRight)
                        {
                            SetImage("Characters/ReaperHitRight.gif");
                        }
                        if (!_LookRight)
                        {
                            SetImage("Characters/ReaperHitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {
                            if (Alive)
                            {
                                if (_LookRight)
                                {
                                    SetImage("Characters/ReaperIdleRight.gif");
                                }
                                if (!_LookRight)
                                {
                                    SetImage("Characters/ReaperIdleLeft.gif");
                                }
                                
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        ReaperHp--;
                        timer.Start();


                    }
                    
                }
            }

        }
    }
}

