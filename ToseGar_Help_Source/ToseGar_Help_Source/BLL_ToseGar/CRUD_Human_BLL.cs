using System.Collections.Generic;
using BE_ToseGar;
using DAL_ToseGar;

namespace BLL_ToseGar
{
    public class CRUD_Human_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        CRUD_Human_DAL dal = new CRUD_Human_DAL();

        public string Create(CRUD_human h)
        {
            return dal.Create(h);
        }

        public List<CRUD_human> Read(string name)
        {
            return dal.Read(name);
        }

        public List<CRUD_human> Read()
        {
            return dal.Read();
        }

        public CRUD_human Read(int id)
        {
            return dal.Read(id);
        }

        public string Update(int id, CRUD_human hnew)
        {
            return dal.Update(id, hnew);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
