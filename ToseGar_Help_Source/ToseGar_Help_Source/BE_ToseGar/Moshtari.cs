using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ToseGar
{
    public class Moshtari
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public int id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Factor> Factors { get; set; } = new List<Factor>();
    }
}
