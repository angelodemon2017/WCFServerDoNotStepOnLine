using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class PlayerInfoStatistic
    {
        [Key]
        public long PlayerInfoStatisticId { get; set; }
        public Player LinkPlayer { get; set; }
        public int PlayedGames { get; set; }
        public int Coins { get; set; }
        public int Donat { get; set; }
        public int AllStep { get; set; }
        public int MaxCombo { get; set; }
        public int PerfectSteps { get; set; }
        public float Distance { get; set; }
        public int QuestComplete { get; set; }

    }
}
