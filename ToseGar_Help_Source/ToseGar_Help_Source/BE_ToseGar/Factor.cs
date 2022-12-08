using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ToseGar
{
    public class Factor
    {
        // طراحی و تولید توسط تیم پشتیبانی آکادمی توسعه گر

        public int id { get; set; }
        public int FactorNum { get; set; }
        public DateTime Date { get; set; }
        public List<Kala> Kalas { get; set; } = new List<Kala>();
        public Moshtari Moshtari { get; set; }
    }
}
