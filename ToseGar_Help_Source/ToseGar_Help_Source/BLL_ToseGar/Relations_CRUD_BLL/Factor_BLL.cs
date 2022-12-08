using System.Collections.Generic;
using System.Data;
using BE_ToseGar;
using DAL_ToseGar.Relations_CRUD_DAL;

namespace BLL_ToseGar.Relations_CRUD_BLL
{
    public class Factor_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        Factor_DAL dal = new Factor_DAL();

        public string Create(Factor f, int mid, List<int> kid)
        {
            if (mid != 0)
            {
                return dal.Create(f, mid, kid);
            }
            else
            {
                return "لطفا مشتری مربوط به فاکتور را انتخاب کنید";
            }
        }

        public DataTable Read()
        {
            return dal.Read();
        }
    }
}
