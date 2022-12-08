using BE_ToseGar;
using DAL_ToseGar;

namespace BLL_ToseGar
{
    public class Login_User_BLL
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        Login_User_DAL dal = new Login_User_DAL();

        public byte Login(string username, string password)
        {
            return dal.Login(username, password);
        }

        public void Register(User_Login u)
        {
            dal.Register(u);
        }
    }
}
