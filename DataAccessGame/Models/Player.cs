using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class Player
    {
        [Key]
        public long PlayerId { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Password { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime DateLastAction { get; set; }
        public int EveryDayMark { get; set; }
        public string DeviceId { get; set; }
        public string GoogleId { get; set; }
        public List<Boot> Boots { get; set; }
    }
}
