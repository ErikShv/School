using GameEngine.GameObjects;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GameEngine.GameServices
{
    public abstract class Scene:Canvas
    {
        private List<GameObject> _gameobjects = new List<GameObject>();

        protected List<GameObject> _gameobjectsSnapshots => _gameobjects.ToList();

        public double Ground { get; set; } = 100;  //ריצפה

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
        public void CheckCollisional()
        {
            foreach (var gameObject in _gameobjectsSnapshots)
            {
                if (gameObject.collisional)
                {
                    // Collect all objects that collide with the current game object
                    var collidingObjects = _gameobjectsSnapshots
                        .Where(g =>
                            !ReferenceEquals(g, gameObject) && // Exclude itself
                            g.collisional &&                  // Ensure the object is collisional
                            !RectHelper.Intersect(g.Rect, gameObject.Rect).IsEmpty // Check intersection
                        ).ToList();

                    if (collidingObjects.Any()) // If there are any colliding objects
                    {
                        gameObject.Collide(collidingObjects);
                    }
                }
            }
        }
        public void AddObject(GameObject gameObject)   //הפעולה מוסיפה אובייקט לרשימה ולמסך
        {
            _gameobjects.Add(gameObject);      //האובייקט מתווסף לרשימה
            Children.Add(gameObject.Image);    //תמונת האובייקט מתווספת למסך
        }    
        public void RemoveObject(GameObject gameObject)   //הפעולה מוחקת אובייקט
        {
            if (_gameobjects.Contains(gameObject))        //אם האובייקט המבוקש נמצא ברשימה
            {
                _gameobjects.Remove(gameObject);          //מחיקתו מהרשימה
                Children.Remove(gameObject.Image);        //מחיקת המראה של האובייקט מהמסך
            }
        }
        public void RemoveAllObjects()
        {
            foreach(GameObject gameObject in _gameobjects)
            {
                RemoveObject(gameObject);
            }
        }
        public void Init()    //מחזירה את כל האובייקטים למיקומם ההתחלתי
        {
            foreach(GameObject obj in _gameobjects)
            {
                obj.Init();
            }
        }
    }
}
