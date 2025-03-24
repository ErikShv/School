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
    class Chest : GameObject
    {
        private bool _done = false;
        
        public Chest(Scene scene, string filename, double placeX, double placeY) : base(scene, filename, placeX, placeY)
        {
            Image.Height = 30;
            
        }
        /// <summary>
        /// מה קורה אם מתנגש בדברים מסויימים
        /// </summary>
        public override void Collide(List<GameObject> gameObject)
        {
            foreach (var otherobject in gameObject)
            {
                if (otherobject is Spectre && !_done ) //אם זה הדמות שלי
                {
                    if (!_done)
                    {
                        _done = true;
                        
                        SetImage("Interactables/ChestOpening2.gif");
                    }

                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);

                    //מוציא מטבעות ולב
                    timer.Tick += (sender, e) =>
                    {

                        SetImage("Interactables/ChestOpen2.png");
                        _scene.AddObject(new FloorHp(_scene, "FloorItems/HpHeart.png", _placeX + 30, _placeY));
                        _scene.AddObject(new Coin(_scene, "FloorItems/Coin.gif", _placeX-30, _placeY));
                        _scene.AddObject(new Coin(_scene, "FloorItems/Coin.gif", _placeX , _placeY));
                        _scene.AddObject(new Coin(_scene, "FloorItems/Coin.gif", _placeX - 10, _placeY));
                        _scene.AddObject(new Coin(_scene, "FloorItems/Coin.gif", _placeX +20, _placeY));
                        _done = true;
                        timer.Stop();
                    };


                    timer.Start();
                    Image.Height = 35;
                  
                }


            }
        }
    }
}
