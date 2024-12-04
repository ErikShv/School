using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class GameLevel
    {
        public int LevelId { get; set; } = 0;
        public int LevelNum { get; set; } = 1;
        public int SkeletonHp { get; set; } =1;
        public int ReaprHp { get; set; } = 1;
        public int GolemHp { get; set; } = 3;
        public int CountSkeleton { get; set; }
        public int CountGolem { get; set; }
        public int CountReaper { get; set; }
        public int CountBoss { get; set; }
        public int CountPlatform { get;set; }
        public int CountMonster { get; set; }
    }
}
