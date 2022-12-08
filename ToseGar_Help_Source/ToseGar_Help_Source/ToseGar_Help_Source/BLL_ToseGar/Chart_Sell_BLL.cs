using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ToseGar;
using BE_ToseGar;

namespace BLL_ToseGar
{
    public class Chart_Sell_BLL
    {
        Chart_Sell_DAL DAL = new Chart_Sell_DAL();

        public void Create(Chart_Sell_BE sell)
        {
            DAL.Create(sell);
        }

        public List<double> Read()
        {
            return DAL.Read();
        }
    }
}
