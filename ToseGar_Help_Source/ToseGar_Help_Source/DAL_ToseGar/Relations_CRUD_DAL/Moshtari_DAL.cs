using System.Collections.Generic;
using System.Linq;
using BE_ToseGar;

namespace DAL_ToseGar.Relations_CRUD_DAL
{
    public class Moshtari_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public string Create(Moshtari m)
        {
            if (!Read(m))
            {
                if (m.Phone.Length == 11)
                {
                    db.Moshtaris.Add(m);
                    db.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "شماره تماس نامعتبر است";
                }

            }
            else
            {
                return "اطلاعات وارد شده تکراری است.";
            }
        }

        public bool Read(Moshtari m)
        {
            return db.Moshtaris.Any(i => i.Name == m.Name && i.Phone == m.Phone);
        }

        public List<Moshtari> Read()
        {
            return db.Moshtaris.ToList();
        }

        public Moshtari Read(int id)
        {
            return db.Moshtaris.Where(i => i.id == id).Single();
        }

        public string Update(int id, Moshtari mnew)
        {
            Moshtari m = new Moshtari();
            m = Read(id);

            m.Name = mnew.Name;
            m.Phone = mnew.Phone;

            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            Moshtari m = Read(id);
            db.Moshtaris.Remove(m);
            db.SaveChanges();
            return "حذف اطلاعات با موفقیت انجام شد";
        }
    }
}
