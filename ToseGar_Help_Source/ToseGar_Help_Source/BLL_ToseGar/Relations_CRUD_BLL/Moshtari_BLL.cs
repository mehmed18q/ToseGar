using System.Collections.Generic;
using BE_ToseGar;
using DAL_ToseGar.Relations_CRUD_DAL;

namespace BLL_ToseGar.Relations_CRUD_BLL
{
    public class Moshtari_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        Moshtari_DAL dal = new Moshtari_DAL();

        public string Create(Moshtari m)
        {
            return dal.Create(m);
        }

        public bool Read(Moshtari m)
        {
            return dal.Read(m);
        }

        public List<Moshtari> Read()
        {
            return dal.Read();
        }

        public Moshtari Read(int id)
        {
            return dal.Read(id);
        }

        public string Update(int id, Moshtari mnew)
        {
            return dal.Update(id, mnew);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
