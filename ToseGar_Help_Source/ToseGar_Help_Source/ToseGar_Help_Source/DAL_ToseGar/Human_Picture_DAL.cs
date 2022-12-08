using BE_ToseGar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ToseGar
{
    public class Human_Picture_DAL
    {
        DB_ToseGarSupport db = new DB_ToseGarSupport();
        public void create(Human_Picture h)
        {
            db.Humen.Add(h);
            db.SaveChanges();
        }
        public List<Human_Picture> Read()
        {
            return db.Humen.ToList();
        }

        public Human_Picture Read(int id)
        {
            return db.Humen.Where(i => i.id == id).SingleOrDefault();
        }
    }
}
