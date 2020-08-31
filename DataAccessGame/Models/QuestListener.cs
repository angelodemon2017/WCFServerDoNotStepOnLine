using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class QuestListener
    {
        [Key]
        public long QuestListenerId { get; set; }
        public Player LinkPlayer { get; set; }
        public string QuestTypeId { get; set; }
        public int CurrentValue { get; set; }
        public bool GetReward { get; set; }
        public DateTime DateBurnQuest { get; set; }
    }
}
