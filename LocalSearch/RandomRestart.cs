using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class RandomRestart
    {
        public void randomRestart(List<MataKuliah> LMK)
        {
            MainClass mc = new MainClass();
            Checker ch = new Checker();
            while(ch.hitungKonflik(LMK) !=0 )
            {

            }
        }
    }

    

}
