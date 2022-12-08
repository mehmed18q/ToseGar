using System.Collections.Generic;
using System.Linq;
using BE_ToseGar;

namespace DAL_ToseGar
{
    public class CRUD_Human_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        //CRUD : Create - Read - Update - Delete
        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public string Create(CRUD_human h)
        {
            if (!Read(h))
            {
                if (h.Code.Length == 10)
                {
                    db.crud.Add(h);
                    db.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "کد ملی نامعتبر است";
                }
            }
            else
            {
                return "اطلاعات وارد شده تکراری است.";
            }
        }

        public bool Read(CRUD_human h)
        {
            return db.crud.Any(i => i.Name == h.Name && i.Code == h.Code);
        }

        public List<CRUD_human> Read(string name)
        {
            return db.crud.Where(i => i.Name.Contains(name)).ToList();
        }

        public List<CRUD_human> Read()
        {
            return db.crud.ToList();
        }

        public CRUD_human Read(int id)
        {
            return db.crud.Where(i => i.id == id).Single();
        }

        public string Update(int id, CRUD_human hnew)
        {
            CRUD_human h = new CRUD_human();
            h = Read(id);
            h.Username = hnew.Username;
            h.Name = hnew.Name;
            h.Code = hnew.Code;
            h.Password = hnew.Password;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            CRUD_human h = Read(id);
            db.crud.Remove(h);
            db.SaveChanges();
            return "حذف اطلاعات با موفقیت انجام شد";
        }
    }
}
