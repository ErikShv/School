using GameEngine.GameServices;
using Path_To_Glory.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameServices
{
    public class GameManager : Manager
    {
        public GameManager(Scene scene) : base(scene)
        {
            Init();
        }
        //הפעולה תיצור את כל הדמויות
        private void Init()
        {
            Scene.AddObject(new Coin(Scene, "FloorItems/Coin.gif", 500, 730));
            Scene.AddObject(new Knight(Scene, "Characters/KnightIdleRight.gif", 800, Scene.ActualHeight-200));
            Scene.AddObject(new MonsterA(Scene, "Characters/GoblinIdleRight.gif", 1000, Scene.ActualHeight - 200));
        }
    }
}
