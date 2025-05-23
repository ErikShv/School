﻿using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class PlayerSlash : GameMovingObject
    {
        public PlayerSlash(Scene scene, string fileName, double placeX, double placeY, bool Right) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 40;
            if (Right)
            {
                _dX = 5;
            }
            if (!Right)
            {
                _dX = -5;
            }
        }
        //אחראי על מה קורה עם התנגשויות עם אובייקטים שונים
        public override void Collide(List<GameObject> gameObject)
        {
            foreach (var otherobject in gameObject)
            {
                //אם מתנגש בו הוא נעלם ומוסר מהבמה ושולח למפלצת את עצמה
                if(otherobject is Reaper)
                {
                    Reaper Reaper = (Reaper)otherobject;
                    Reaper.Get_Self(Reaper);
                }
                //אם מתנגש בו הוא נעלם ומוסר מהבמה ושולח למפלצת את עצמה
                if (otherobject is MonsterA)
                {
                    MonsterA Mnstr = (MonsterA)otherobject;
                    Mnstr.Get_Self(Mnstr);
                }
                //אם מתנגש בו הוא נעלם ומוסר מהבמה ושולח למפלצת את עצמה
                if (otherobject is Skeleton)
                {
                    Skeleton Skltn = (Skeleton)otherobject;
                    Skltn.Get_Self(Skltn);
                }
            }
        }
    }
}
