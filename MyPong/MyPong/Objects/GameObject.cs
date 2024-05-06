using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace MyPong.Objects
{
    //המחלקה המופשטת מיועדת להיות בסיס לכל המחלקות הבאות היא תכיל את כל התכונות והפעולות המשותפות לכל העצמים בפרוייקט
    public abstract class GameObject
    {
        protected double _x;//המקום הרגעי של העצם
        protected double _y;

        protected double _startedX;//המיקום ההתחלתי של העצם, הוא לא ישתנה
        protected double _startedY;

        public Image image { get; set; }
        protected string _filename;//שם הקובץ של התמונה

        public virtual Rect Rect => new Rect(_x, _y, image.Width, image.Height);
        public bool Collision { get; set; } = true;

        /// <summary>
        /// הפעולה בונה עצם בסיסי 
        /// </summary>
        /// <param name="filename">שם הקובץ</param>
        /// <param name="size">גודל התמונה</param>
        /// <param name="x">מיקום אופקי</param>
        /// <param name="y">מיקום אנכי</param>
        protected GameObject( string filename,double size,double x,double y)
        {
            _x = x;
            _y = y;
            _startedX = x;
            _startedY = y;
            _filename = filename;
            image = new Image();

            image.Width = size;
            image.Height = size;
            Render();
            SetImage(filename);
        }
        /// <summary>
        /// מציבה את העצם במיקומו הנוכחי בתוך זירת המשחק
        /// </summary>
        public virtual void Render()
        {
            Canvas.SetLeft(image, _x);
            Canvas.SetTop(image, _y);
        }
        /// <summary>
        /// מאתחלת את האובייקט למיקומו ההתחלתי
        /// </summary>
            public virtual void Init()
            {
            _x = _startedX;
            _y = _startedY;
            
        }
        public virtual void Collide(GameObject gameobject)
        {
        }
        /// <summary>
        /// הפעולה קובעת את תמונת האובייקט
        /// תקבל את הנתיב ואת שם הקובץ מ-Assets והלאה
        /// </summary>
        /// <param name="filename">שם הקובץ</param>
        protected void SetImage(string filename)
        {
            image.Source = new BitmapImage(new Uri($"ms-appx:///Assets/{filename}"));
        }

    }
}
