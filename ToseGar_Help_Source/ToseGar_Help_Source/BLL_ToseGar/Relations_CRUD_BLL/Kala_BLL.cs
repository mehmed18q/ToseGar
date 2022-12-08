using System.Collections.Generic;
using BE_ToseGar;
using DAL_ToseGar.Relations_CRUD_DAL;

namespace BLL_ToseGar.Relations_CRUD_BLL
{
    public class Kala_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        Kala_DAL dal = new Kala_DAL();

        public string Create(Kala k)
        {
            return dal.Create(k);
        }

        public bool Read(Kala k)
        {
            return dal.Read(k);
        }

        public List<Kala> Read()
        {
            return dal.Read();
        }

        public Kala Read(int id)
        {
            return dal.Read(id);
        }

        public string Update(int id, Kala knew)
        {
            return dal.Update(id, knew);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
