using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class GameLevel
    {
        public int LevelId { get; set; } = 0; //המספר המזהה של שלב
        public int LevelNum { get; set; } = 1;//מספר השלב
        public int SkeletonHp { get; set; } =1;//כמות החיים של שלד
        public int ReaprHp { get; set; } = 1; //כמות החיים של ריפר
        public int GolemHp { get; set; } = 3; //כמות חיים של גולם
        public int CountSkeleton { get; set; }// מספר של שלדים
        public int CountGolem { get; set; }//מספר של גולמים
        public int CountReaper { get; set; }//מספר של ריפרים
        public int CountBoss { get; set; }
        public int CountPlatform { get;set; }//מספר הפלטפורמות
        public int CountMonster { get; set; }//מספר המפלצות בחדר
    }
}
