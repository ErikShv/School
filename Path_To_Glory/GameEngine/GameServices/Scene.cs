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
            foreach(var gameObject in _gameobjectsSnapshots)//עוברים על כל רשימת האובייקטים
            {
                if (gameObject.collisional) // אם האובייקט לא שקוף
                {
                    //מחפשים מופע ראשון של האובייקט, אשר הוא לא אותו אובייקט, הוא לא שקוף והוא נגע באובייקט הנוכחי
                    var otherobject = _gameobjectsSnapshots.FirstOrDefault(g => !ReferenceEquals(g, gameObject) && g.collisional && !RectHelper.Intersect(g.Rect, gameObject.Rect).IsEmpty);
                    if(otherobject != null)//אם קיים אובייקט כזה
                    {
                        //Collide של אותו אובייקט,כלומר,אם הפעולה נקראת,זה אומר שבוודאות קרתה התנגשות,אם האובייקט מתנגש באובייקט אחר,נקראת הפעולה
                        // כדי שיוכל להגיב באופן מיוחד ,כל אובייקט משכתב את הפעולה Collide.
                        gameObject.Collide(otherobject);
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
