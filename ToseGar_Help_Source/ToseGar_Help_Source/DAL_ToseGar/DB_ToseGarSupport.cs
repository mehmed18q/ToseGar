using System.Data.Entity;
using BE_ToseGar;

namespace DAL_ToseGar
{
    public class DB_ToseGarSupport : DbContext
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public DB_ToseGarSupport() : base("name=ToseGarSupport") { }
        public DbSet<Chart_Sell_BE> Chart_Sell_BEs { get; set; }
        public DbSet<Human_Picture> Humen { get; set; }
        public DbSet<User_Login> Users { get; set; }
        public DbSet<CRUD_human> crud { get; set; }
        public DbSet<Kala> Kalas { get; set; }
        public DbSet<Moshtari> Moshtaris { get; set; }
        public DbSet<Factor> Factors { get; set; }
    }
}
