using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class Checker
    {
        public Boolean checkAvail(MataKuliah MK, List<Ruangan> LR)
        {
            Boolean avail=false;
            int i = 0;
            while (i < LR.Count())
            {
                if (MK.getRuanganSol() == LR[i].getNamaRuangan())
                {
                    break;
                }
                i++;
            }

            if (i < LR.Count())
            {
                --i;
                if(MK.getJamSol()>=LR[i].getjamMulai() && MK.getJamSol() + MK.getSks() <= LR[i].getjamAkhir() )
                {
                    foreach(int j in LR[i].getHariAvailable())
                    {
                        if (MK.getHariSol() == j)
                        {
                            avail = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                avail = false;
                return avail;
            }
            return avail;
        }

        public int hitungKonflik(List<MataKuliah> LM)
        {
            int konflik = 0;
            for(int i = 0; i < LM.Count; ++i)
            {
                foreach (MataKuliah m in LM)
                {
                    if (LM[i].getNamaMatKul() != m.getNamaMatKul())
                    {
                        if((LM[i].getRuanganSol() == m.getRuanganSol()) && (LM[i].getHariSol() == m.getHariSol() /*hasil sol masih bingung */ && 
                            (LM[i].getJamSol() +LM[i].getSks() <= m.getJamSol() || m.getJamSol() + m.getSks() <= LM[i].getJamSol())))
                        {
                            ++konflik;
                        }
                    }
                }
            }
            return konflik;
        }
    }
}
