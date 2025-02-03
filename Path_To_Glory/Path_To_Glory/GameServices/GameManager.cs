using DatabaseProject.Models;
using GameEngine.GameServices;
using Path_To_Glory.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameServices
{
    public class GameManager : Manager
    {
        public static GameUser GameUser { get; set; } = new GameUser();
        public static MyGameEvents Events = new MyGameEvents();
        public GameManager(Scene scene) : base(scene)
        {
            Init();
            
        }
        //הפעולה תיצור את כל הדמויות
        private void Init()
        {
            if (GameUser.CurrentLevel.LevelId == 1)
            {
                Scene.AddObject(new Coin(Scene, "FloorItems/Coin.gif", 500, 730));
                Scene.AddObject(new Spectre(Scene, "Characters/IdleRight.gif", 800, Scene.ActualHeight - Scene.Ground));
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 0, Scene.ActualHeight - 30));
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 1001, Scene.ActualHeight - 30));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 400, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 300));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight.gif", 200, Scene.ActualHeight - Scene.Ground - 300));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight.gif", 1200, Scene.ActualHeight - Scene.Ground - 300));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 600, Scene.ActualHeight - Scene.Ground - 500));
                Scene.AddObject(new Reaper(Scene, "Characters/ReaperIdleLeft.gif", 1200, Scene.ActualHeight - Scene.Ground, false));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 400, Scene.ActualHeight - Scene.Ground + 45));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 200, Scene.ActualHeight - Scene.Ground - 130));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 1300, Scene.ActualHeight - Scene.Ground - 130));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 600, Scene.ActualHeight - Scene.Ground - 230));
                Scene.AddObject(new FloorHp(Scene, "FloorItems/HpHeart.png", 200, Scene.ActualHeight - 45));
            }
            if (GameUser.CurrentLevel.LevelId == 2)
            {
                
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 0, Scene.ActualHeight - 30));
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 1001, Scene.ActualHeight - 30));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth-390, Scene.ActualHeight-75));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 125));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 770, Scene.ActualHeight - 75));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 600, Scene.ActualHeight - Scene.Ground - 500));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 300));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 400));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 500));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 500));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", Scene.ActualWidth - 350, Scene.ActualHeight - 200));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 0, Scene.ActualHeight - Scene.Ground - 400));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 850, Scene.ActualHeight - Scene.Ground - 150));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 850, Scene.ActualHeight - Scene.Ground-5));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth / 2 - 100, Scene.ActualHeight - Scene.Ground - 230));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth -350, Scene.ActualHeight - Scene.Ground -430));
                Scene.AddObject(new Reaper(Scene, "Characters/ReaperIdleLeft.gif", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - Scene.Ground-300, true));
                Scene.AddObject(new Spectre(Scene, "Characters/IdleRight.gif", 0, Scene.ActualHeight - Scene.Ground));

            }
            if (GameUser.CurrentLevel.LevelId == 3)
            {
                
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 0, Scene.ActualHeight - 30));
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 1001, Scene.ActualHeight - 30));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 400));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 600));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 400));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 600));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 300));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 500));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 700));
                Scene.AddObject(new Wall(Scene, "Tiles/BigWall.png", Scene.ActualWidth / 2-20, Scene.ActualHeight - 425));
                Scene.AddObject(new Wall(Scene, "Tiles/TwoWall.png", Scene.ActualWidth / 2 - 20, Scene.ActualHeight - 550));
                Scene.AddObject(new Wall(Scene, "Tiles/TwoWall.png", Scene.ActualWidth / 2 - 20, Scene.ActualHeight - 650));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 0, Scene.ActualHeight -250));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight",0, Scene.ActualHeight - 550));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 0, Scene.ActualHeight - 750));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", Scene.ActualWidth-200, Scene.ActualHeight - 250));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", Scene.ActualWidth - 200, Scene.ActualHeight - 550));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", Scene.ActualWidth - 200, Scene.ActualHeight - 750));
                Scene.AddObject(new Spectre(Scene, "Characters/IdleRight.gif", 0, Scene.ActualHeight - Scene.Ground));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth / 2 - 100, Scene.ActualHeight - Scene.Ground - 230));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 100, Scene.ActualHeight - Scene.Ground - 130));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth - 200, Scene.ActualHeight - Scene.Ground - 130));
            }
            if (GameUser.CurrentLevel.LevelId == 4)
            {
                
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 0, Scene.ActualHeight - 30));
                Scene.AddObject(new Ground(Scene, "Tiles/FloorTutorial2.png", 1001, Scene.ActualHeight - 30));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 400));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", 0, Scene.ActualHeight - 600));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 200));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 400));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth - 390, Scene.ActualHeight - 600));
                Scene.AddObject(new Platform(Scene, "Tiles/Platform.png", Scene.ActualWidth / 2 - 200, Scene.ActualHeight - 300));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 0, Scene.ActualHeight - 250));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", 0, Scene.ActualHeight - 550));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", 0, Scene.ActualHeight - 750));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", Scene.ActualWidth - 200, Scene.ActualHeight - 250));
                Scene.AddObject(new MonsterA(Scene, "Characters/GolemWalkingRight", Scene.ActualWidth - 200, Scene.ActualHeight - 550));
                Scene.AddObject(new Skeleton(Scene, "Characters/SkeletonWalkRight.gif", Scene.ActualWidth - 200, Scene.ActualHeight - 750));
                Scene.AddObject(new Spectre(Scene, "Characters/IdleRight.gif", 0, Scene.ActualHeight - Scene.Ground));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth / 2 - 100, Scene.ActualHeight - Scene.Ground - 230));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", 100, Scene.ActualHeight - Scene.Ground - 130));
                Scene.AddObject(new Chest(Scene, "Interactables/ChestClosed.png", Scene.ActualWidth - 200, Scene.ActualHeight - Scene.Ground - 130));
            }
        }
    }
}
