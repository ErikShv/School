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
            var leftgoal = new Goal("Goals/LeftGoal.png", 300, 5, _scnene.ActualHeight / 2-150);
            AddObject(leftgoal);
            var rightgoal = new Goal("Goals/RightGoal.png", 300, _scnene.ActualWidth-55, _scnene.ActualHeight / 2 - 150);
            AddObject(rightgoal);
        }
    }
}
