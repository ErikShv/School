using MyPong.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyPong.GameServices
{
    /// <summary>
    /// המחלקה מנהלת את המשחק הכללי(טניס)ף
    /// </summary>
    public abstract class Manager
    {
        //זאת רשימת כל האובייקטים שישתתפו במשחק היא תכיל את כל סוגי האובייקטים 
        protected List<GameObject> _gameObjects = new List<GameObject>();
        protected Canvas _scnene;
        public static Events Events = new Events();
        public static DispatcherTimer _distapchertimer = new DispatcherTimer();
        public Manager(Canvas scene)
        {
            _scnene = scene;
            _distapchertimer.Interval = TimeSpan.FromMilliseconds(1);
            _distapchertimer.Start();
            _distapchertimer.Tick += _dispatcherTimer_Tick;
            Events.OnRun = Run;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
        }
        // הפעולה תתבצע באופן אוטומטי כאשר המשתמש ישחרר את כלשהו
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if(Events.OnKeyRelease != null)
            {
                Events.OnKeyRelease(args.VirtualKey);//כאן אנו מפעילים אירוע OnKeyRelease
            }
        }
        //הפעולה תתבצע באופן אוטומטי כאשר המשתמש ילחץ על מקש כלשהו
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            if(Events.OnKeyPress != null)
            {
                Events.OnKeyPress(args.VirtualKey);//כאן אנו מפעילים אירוע OnKeyPress
            }
        }

        private void _dispatcherTimer_Tick(object sender, object e)
        {
            if (Events.OnRun != null)
            {
                Events.OnRun();
            }
        }

        public void Run()
        {
            foreach(GameObject gameObject in _gameObjects)
            {
                if(gameObject is GameMovingObject obj)
                {
                    obj.Render();
                }
            }
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
