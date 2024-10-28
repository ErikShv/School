using GameEngine.GameObjects;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace GameEngine.GameServices
{
    public abstract class Scene:Canvas
    {
        private List<GameObject> _gameobjects = new List<GameObject>();

        protected List<GameObject> _gameobjectsSnapshots => _gameobjects.ToList();

        public double Ground { get; set; }  //ריצפה

        public Scene()
        {
            Manager.GameEvent.OnRun += Run;
            Manager.GameEvent.OnRun += CheckCollisional;

        }

        private void Run()
        {
            foreach(var GameObject in _gameobjects)
            {
                if(GameObject is GameMovingObject obj)
                {
                    obj.Render();
                }
            }
        }
    }
}
