using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccessGame.Models;

namespace DataAccessGame
{
    public partial class DBGContext : DbContext
    {
        public DBGContext()
            : base("DbConnection")
        { }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<QuestListener> QuestListeners { get; set; }
        public virtual DbSet<PlayerInfoStatistic> PlayerInfoStatistics { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Boot> Boots { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasMany<Boot>(x => x.Boots).WithMany(x => x.Players);
        }
    }
}
