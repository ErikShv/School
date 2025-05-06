using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Models
{
    public class Score
    {
        public int id { get; set; } = 1;// המספר המזהה של המשתמש
        public string name { get; set; } = string.Empty; //שם המשתמש
        public int souls { get; set; } = 0; //כמות הנשמות שיש לו
        
    }
}
