using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessGame.Models
{
    public class Boot
    {
        [Key]
        public long BootId { get; set; }
        public string BootName { get; set; }
        public int Price { get; set; }
        public int PremiumPrice { get; set; }
        public DateTime ActualDate { get; set; }
        public DateTime BurnDate { get; set; }
        public List<Player> Players { get; set; }
    }
}
