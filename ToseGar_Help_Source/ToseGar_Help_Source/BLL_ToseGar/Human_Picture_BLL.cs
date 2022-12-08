using System.Collections.Generic;
using BE_ToseGar;
using DAL_ToseGar;

namespace BLL_ToseGar
{
    public class Human_Picture_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        Human_Picture_DAL DAL = new Human_Picture_DAL();

        public void Create(Human_Picture h)
        {
            DAL.create(h);
        }

        public List<Human_Picture> Read()
        {
            return DAL.Read();
        }

        public Human_Picture Read(int id)
        {
            return DAL.Read(id);
        }
    }
}
