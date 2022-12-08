using System.Collections.Generic;
using System.Linq;
using BE_ToseGar;

namespace DAL_ToseGar
{
    public class Chart_Sell_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public void Create(Chart_Sell_BE sell)
        {
            db.Chart_Sell_BEs.Add(sell);
            db.SaveChanges();
        }

        public List<double> Read()
        {
            return (from i in db.Chart_Sell_BEs select i.Sell).ToList();
        }
    }
}
