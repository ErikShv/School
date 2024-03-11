using MyPong.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.GameServices
{
    /// <summary>
    /// המחלקה מנהלת את המשחק הספציפי (טניס )ף
    /// </summary>
    public class GameManager : Manager
    {
        public GameManager(Canvas scene) : base(scene)
        {
            CreateObjects();
        }

        private void CreateObjects()
        {
            int x = 0;
            int y = x + 50;
            int z = y + 50;
            Random rnd = new Random();


            string name1 = "";
            string name2 = "";
            string name3 = "";
            for (int i = 0; i < 8; i++)
            {
                int num = rnd.Next(1, 4);
                if (num == 1)
                {
                    name1 = "Fans/Jelly (1).png";
                    name2 = "Fans/Jelly (2).png";
                    name3 = "Fans/Jelly (3).png";
                }
                if (num == 2)
                {
                    name1 = "Fans/Jelly (2).png";
                    name2 = "Fans/Jelly (3).png";
                    name3 = "Fans/Jelly (1).png";
                }
                if (num == 3)
                {
                    name1 = "Fans/Jelly (3).png";
                    name2 = "Fans/Jelly (1).png";
                    name3 = "Fans/Jelly (2).png";
                }
                var fan1 = new Fan(name1, 50, x, 0);
                AddObject(fan1);
                var fan1down = new Fan(name1, 50, x, _scnene.ActualHeight - 100);
                AddObject(fan1down);
                var fan2 = new Fan(name2, 50, y, 0);
                AddObject(fan2);
                var fan2down = new Fan(name2, 50, y, _scnene.ActualHeight - 100);
                AddObject(fan2down);
                var fan3 = new Fan(name3, 50, z, 0);
                AddObject(fan3);
                var fan3down = new Fan(name3, 50, z, _scnene.ActualHeight - 100);
                AddObject(fan3down);
                x = x + 150;
                y = y + 150;
                z = z + 150;
            }
                var leftgoal = new Goal("Goals/LeftGoal.png", 300, 5, _scnene.ActualHeight / 2 - 150);
                AddObject(leftgoal);
                var rightgoal = new Goal("Goals/RightGoal.png", 300, _scnene.ActualWidth - 55, _scnene.ActualHeight / 2 - 150);
                AddObject(rightgoal);
                var bat = new LeftBat(_scnene,"Bars/BlueBar.png", 150, 100, _scnene.ActualHeight / 2 - 75);
                AddObject(bat);
                var bat2 = new RightBat(_scnene,"Bars/RedBar.png", 150, _scnene.ActualWidth - 130, _scnene.ActualHeight / 2 - 75);
                AddObject(bat2);

        }
    }
}

