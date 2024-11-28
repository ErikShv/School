using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameObjects
{
    class MonsterA : GameMovingObject
    {
        
        public MonsterA(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 50;
            _ddY = 1;
            _dX = 2;
        }
        private bool _LookRight = true;
        private bool _Hit = false;
        private bool _HitWall = false;
        private bool _HitEndPlatform = false;
        public int GolemHp { get; set; } = 3;
        public override void Render()
        {
            base.Render();
            if (Rect.Left <= 0 && !_HitWall)
            {
                _HitWall = true;
                _X = 0;
                _dX = 0;
                SetImage("Characters/GolemIdleLeft.gif");
                
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += (sender, e) =>
                {
                    
                    _dX = 2;
                    _LookRight = true;
                    SetImage("Characters/GolemWalkingRight.gif");
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
            if (Rect.Right >= _scene?.ActualWidth)
            {
                _HitWall = true;
                _X = _scene.ActualWidth - Image.Height-5;
                _dX = 0;
                SetImage("Characters/GolemIdleRight.gif");
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(1000);
                timer.Tick += (sender, e) =>
                {

                    _dX = -2;
                    _LookRight = false;
                    SetImage("Characters/GolemWalkingLeft.gif");
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
        public override void Collide(List <GameObject> gameObject)
        {
            foreach (var otherobject in gameObject)
            {
                var spctr = otherobject;
                if(otherobject is Spectre)
                {
                    Spectre spectre = (Spectre)spctr;   
                    if(spectre.InAnimation == true && !_Hit)
                    {
                        _Hit = true;
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(500);
                        if (_LookRight)
                        {
                            SetImage("Characters/GolemHitRight.gif");
                        }
                        if (!_LookRight)
                        {
                            SetImage("Characters/GolemHitLeft.gif");
                        }
                        timer.Tick += (sender, e) =>
                        {

                            if (_LookRight && _dX == 0)
                            {
                                SetImage("Characters/GolemIdleRight.gif");
                            }
                            if (!_LookRight && _dX == 0)
                            {
                                SetImage("Characters/GolemIdleLeft.gif");
                            }
                            if (_LookRight )
                            {
                                SetImage("Characters/GolemWalkingRight.gif");
                            }
                            if (!_LookRight )
                            {
                                SetImage("Characters/GolemWalkingLeft.gif");
                            }
                            _Hit = false;


                            timer.Stop();
                        };
                        GolemHp --;
                        timer.Start();


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
                    if (rect.Width <= rect.Height+20) //מהצד
                    {
                        if (_dX < 0)
                        {
                            

                            _X += 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/GolemIdleLeft.gif");

                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = 2;
                                _LookRight = true;
                                SetImage("Characters/GolemWalkingRight.gif");
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
                        if (_dX > 0)
                        {

                            
                            _X -= 2;
                            _HitEndPlatform = true;
                            _dX = 0;
                            SetImage("Characters/GolemIdleRight.gif");
                            DispatcherTimer timer = new DispatcherTimer();
                            timer.Interval = TimeSpan.FromMilliseconds(1000);
                            timer.Tick += (sender, e) =>
                            {

                                _dX = -2;
                                _LookRight = false;
                                SetImage("Characters/GolemWalkingLeft.gif");
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
