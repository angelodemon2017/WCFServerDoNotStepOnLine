using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class Record
    {
        [Key]
        public long RecordId { get; set; }
        public Player LinkPlayer { get; set; }
        public int Mode { get; set; }
        public int Score { get; set; }
        public int MaxSpeed { get; set; }
        public int Steps { get; set; }
        public float MaxTime { get; set; }

        public Record()
        {
            Score = 0;
            MaxSpeed = 0;
            Steps = 0;
            MaxTime = 0f;
        }
    }
}