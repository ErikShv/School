using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
   public class GameUser
    {
        public int UserId { get; set; } = 1;

        public string UserName { get; set; } = "Anonymous";

        public string UserEmail { get; set; } = string.Empty;

        public string UserPassword { get; set; } = string.Empty;

        public int Souls { get; set; } = 0;

        public int Coins { get; set; } = 0;
        

        public int MaxLevel { get; set; } = 1;//השלב  המתקדם ביותר שהמשתמש הגיע אליו

        public int CurrentPowerUp { get; set; } = 1;

        public GameLevel CurrentLevel = new GameLevel();//אם המשתמש לא יזדהה הוא ישחק בשלב בררת מחדל


    }
}
