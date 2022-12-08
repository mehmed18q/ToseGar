using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE_ToseGar;

namespace DAL_ToseGar
{
    public class DB_ToseGarSupport : DbContext
    {
        public DB_ToseGarSupport() : base("name=ToseGarSupport") { }

        public DbSet<Chart_Sell_BE> Chart_Sell_BEs { get; set; }
        public DbSet<Human_Picture> Humen { get; set; }

        public DbSet<User_Login> Users { get; set; }
    }
}
