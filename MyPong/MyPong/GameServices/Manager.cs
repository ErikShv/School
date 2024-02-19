using MyPong.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPong.GameServices
{

    public abstract class Manager
    {
        //זאת רשימת כל האובייקטים שישתתפו במשחק היא תכיל את כל סוגי האובייקטים 
        protected List<GameObject> gameObjects = new List<GameObject>();
    }
}
