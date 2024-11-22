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
            Scene.AddObject(new Knight(Scene, "Characters/KnightIdleRight2.gif", 800, Scene.ActualHeight-Scene.Ground));
            Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 0, Scene.ActualHeight-30));
            Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 600, Scene.ActualHeight - 30));
            Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 200));
            Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth-400, Scene.ActualHeight - 200));
            Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth/2-200, Scene.ActualHeight - 300));
            Scene.AddObject(new MonsterA(Scene, "Characters/GoblinIdleLeft2.gif", 200, Scene.ActualHeight - Scene.Ground-300));
            Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 400, Scene.ActualHeight - Scene.Ground +45));
        }
    }
}
