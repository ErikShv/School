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
        public override void Collide(GameObject gameObject)
        {

            if (gameObject is Knight && !_done)
            {

                SetImage("Interactables/ChestOpening2.gif");


                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);


                timer.Tick += (sender, e) =>
                {

                    SetImage("Interactables/ChestOpen2.png");

                    _done = true;
                    timer.Stop();
                };


                timer.Start();
            }


        }
    }
}
