using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class Achievement
    {
        [Key]
        public long AchieventId { get; set; }
        public Player LinkPlayer { get; set; }
        public string NameAchievement { get; set; }
        public string NumberRewards { get; set; }
    }
}
