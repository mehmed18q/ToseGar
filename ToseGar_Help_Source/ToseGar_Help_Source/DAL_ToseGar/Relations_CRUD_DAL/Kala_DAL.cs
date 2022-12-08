using System.Collections.Generic;
using System.Linq;
using BE_ToseGar;


namespace DAL_ToseGar.Relations_CRUD_DAL
{
    public class Kala_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public string Create(Kala k)
        {
            if (!Read(k))
            {
                if (k.Barcode.Length > 8)
                {
                    db.Kalas.Add(k);
                    db.SaveChanges();
                    return "ثبت اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "بارکد نامعتبر است";
                }

            }
            else
            {
                return "اطلاعات وارد شده تکراری است.";
            }
        }
        public bool Read(Kala k)
        {
            return db.Kalas.Any(i => i.Name == k.Name && i.Barcode == k.Barcode);
        }

        public List<Kala> Read()
        {
            return db.Kalas.ToList();
        }

        public Kala Read(int id)
        {
            return db.Kalas.Where(i => i.id == id).Single();
        }

        public string Update(int id, Kala knew)
        {
            Kala k = new Kala();
            k = Read(id);

            k.Name = knew.Name;
            k.Barcode = knew.Barcode;
            k.Price = knew.Price;

            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public string Delete(int id)
        {
            Kala k = Read(id);
            db.Kalas.Remove(k);
            db.SaveChanges();
            return "حذف اطلاعات با موفقیت انجام شد";
        }
    }
}
