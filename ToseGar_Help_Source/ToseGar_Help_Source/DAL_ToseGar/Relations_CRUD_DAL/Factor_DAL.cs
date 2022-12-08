using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BE_ToseGar;
namespace DAL_ToseGar.Relations_CRUD_DAL
{
    public class Factor_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public string Create(Factor f, int mid, List<int> kid)
        {
            f.Date = DateTime.Today;
            f.FactorNum = SetFactorNum();

            #region اختصاص دادن مشتری
            Moshtari m = db.Moshtaris.Where(i => i.id == mid).Single();
            f.Moshtari = m;
            #endregion

            #region اختصاص دادن کالا ها
            foreach (var item in kid)
            {
                Kala k = db.Kalas.Where(i => i.id == item).Single();
                f.Kalas.Add(k);
            }
            #endregion

            db.Factors.Add(f);
            db.SaveChanges();
            return "ثبت فاکتور با موفقیت انجام شد";
        }

        public bool Read(Factor f)
        {
            return db.Factors.Any(i => i.FactorNum == f.FactorNum);
        }

        public int SetFactorNum()
        {
            if (db.Factors.Count() == 0)
            {
                return 1000;
            }
            else
            {
                return 1000 + db.Factors.Count();
            }
        }

        public DataTable Read()
        {
            var select = "SELECT dbo.Factors.FactorNum, dbo.Factors.Date, dbo.Moshtaris.Name, SUM(dbo.Kalas.Price) AS [جمع کل] FROM dbo.Factors INNER JOIN dbo.KalaFactors ON dbo.Factors.id = dbo.KalaFactors.Factor_id INNER JOIN dbo.Kalas ON dbo.KalaFactors.Kala_id = dbo.Kalas.id INNER JOIN dbo.Moshtaris ON dbo.Factors.Moshtari_id = dbo.Moshtaris.id GROUP BY dbo.Factors.FactorNum, dbo.Factors.Date, dbo.Moshtaris.Name";
            var c = new SqlConnection("Data Source=(local);Initial Catalog=ToseGar1;Integrated Security=true");
            var dataAdapter = new SqlDataAdapter(select, c);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
