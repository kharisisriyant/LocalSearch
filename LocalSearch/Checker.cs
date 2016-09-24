﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class Checker
    {
        public Checker()
        {
            
        }

        public Boolean checkAvail(MataKuliah MK, List<Ruangan> LR)
        {
            Boolean avail = false;
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
                if (i != 0)
                {
                    --i;
                }
                if ((MK.getJamSol() >= LR[i].getjamMulai()) && (MK.getJamSol() + MK.getSks() <= LR[i].getjamAkhir()))
                {
                    foreach (int j in LR[i].getHariAvailable())
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

        public void hitungKonflik(List<MataKuliah> LM)
        {
            arrMKKonflik = new int[LM.Count];
            int konflik = 0;
            for (int i = 0; i < LM.Count(); ++i)
            {
                for (int j = i + 1; j < LM.Count(); ++j)
                {
                    if ((LM[i].getRuanganSol() == LM[j].getRuanganSol()) && (LM[i].getHariSol() == LM[j].getHariSol() &&
                       !(LM[i].getJamSol() + LM[i].getSks() <= LM[j].getJamSol() || LM[j].getJamSol() + LM[j].getSks() <= LM[i].getJamSol())))
                    {
                        arrMKKonflik[i]++;
                        arrMKKonflik[j]++;
                        ++konflik;
                    }
                }
            }
            jumlahKonflik = konflik;
        }

        public int getIndexMaxMKKonflik()
        {
            return arrMKKonflik.Max();
        }

        public int getJumlahKonflik()
        {
            return jumlahKonflik;
        }

        public int[] getArrMKKonflik()
        {
            return arrMKKonflik;
        }

        private int[] arrMKKonflik; //array jumlah konflik masing2 matkul

        private int jumlahKonflik ; //jumlah total konflik
        
    }
        
}
