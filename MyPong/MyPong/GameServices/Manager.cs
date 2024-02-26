using MyPong.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.GameServices
{

    public abstract class Manager
    {
        //זאת רשימת כל האובייקטים שישתתפו במשחק היא תכיל את כל סוגי האובייקטים 
        protected List<GameObject> _gameObjects = new List<GameObject>();
            private Canvas _scnene;
        public Manager(Canvas scene)
        {
            _scnene = scene;
        }

        public void AddObject(GameObject gameobject)
        {
            _gameObjects.Add(gameobject);//הוספת עצם אל הרשימה
            _scnene.Children.Add(gameobject.image);//הוספת עצם על הבמה

        }
        public void RemoveObject(GameObject gameobject)
        {
            _gameObjects.Remove(gameobject);//הסרת עצם מהרשימה
            _scnene.Children.Remove(gameobject.image);//הורדה של עצם מהבמה
        }
        public void RemoveAllObjects()
        {
            foreach(GameObject gameObject in _gameObjects)
            {
                RemoveObject(gameObject);
            }

        }
    }
}
