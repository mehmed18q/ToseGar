using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_ToseGar;
using DAL_ToseGar;

namespace BLL_ToseGar
{
    public class Login_User_BLL
    {
        Login_User_DAL dal = new Login_User_DAL();

        public byte Login(string username,string password)
        {
           return dal.Login(username,password);
        }

        public void Register(User_Login u)
        {
            dal.Register(u);
        }
    }
}
