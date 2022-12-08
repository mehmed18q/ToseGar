using System.Linq;
using BE_ToseGar;

namespace DAL_ToseGar
{
    public class Login_User_DAL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        DB_ToseGarSupport db = new DB_ToseGarSupport();

        public byte Login(string username, string password)
        {
            if (db.Users.Count() == 0)
            {
                return 0;
            }
            else
            {
                if (db.Users.Any(i => i.UserName == username && i.Password == password))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public void Register(User_Login u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }
    }
}
