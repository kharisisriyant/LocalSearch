using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class SimulatedAnnealing
    {

        public void simulatedAnnealing(ref List<MataKuliah> LMK, List<Ruangan> LR, int banyakjadwal, int banyakruangan)
        {
            
            Checker ch = new Checker();
            Initializer init = new Initializer();
            ch.hitungKonflik(LMK);
            double temperatur = 100.00;
            int konfliklama = 0;
            int konflikbaru = 0;
            double chance = 0;
            double rumus = 0;
            List<MataKuliah> HLMK = cloneListMK(LMK); //variabel temp LMK
            Checker ch2 = new Checker(); //checker temp LMK
            while (ch.getJumlahKonflik() > 0 && temperatur > 0.1 )
            {
                //isi variabel di awal secara random
                init.Initialize(LMK, LR, banyakjadwal, banyakruangan);
                ch.hitungKonflik(LMK);
                konfliklama = ch.getJumlahKonflik();
                int i = ch.getIndexMaxMKKonflik();
                HLMK = cloneListMK(LMK);
                newAssign(i, HLMK, LR, banyakjadwal, banyakruangan);
                ch2.hitungKonflik(LMK);
                konflikbaru = ch2.getJumlahKonflik();
                if (konflikbaru <= konfliklama) //diambil
                {
                    LMK = cloneListMK(HLMK);
                }
                else //itung chance apakah diambil dan kurangin temperatur
                {
                    rumus = (-1 * (konfliklama - konflikbaru) / temperatur);
                    chance = Math.Exp(rumus);
                    temperatur = temperatur * 0.95;
                    if(chance >= 0.1)
                    {
                        LMK = cloneListMK(HLMK);
                    }
                }
            }
        }



        public List<MataKuliah> cloneListMK(List<MataKuliah> LM)
        {
            List<MataKuliah> temp = new List<MataKuliah>();
            foreach (MataKuliah s in LM)
            {
                MataKuliah n = new MataKuliah(s);
                temp.Add(n);
            }
            return temp;
        }


        public void newAssign(int index, List<MataKuliah> listMK, List<Ruangan> listR, int banyakjadwal, int banyakRuangan)
        {
            Random rng = new Random();
            int minTime = 0;
            int maxTime = 0;
            IEnumerable<int> possibleDay;

            int temp = 0;
            bool found = false;
            Console.WriteLine("Ubah Jadwal " + listMK[index].getNamaMatKul());

            //If no room restriction
            if (!listMK[index].getRuanganDom().Equals("-", StringComparison.Ordinal))
            {
                listMK[index].setRuanganSol(listMK[index].getRuanganDom());
                Console.WriteLine("Assigned to room " + listMK[index].getRuanganSol());
                while (!found)
                {
                    if (listMK[index].getRuanganSol().Equals(listR[temp].getNamaRuangan(), StringComparison.Ordinal))
                    {
                        found = true;
                    }
                    else {
                        temp++;
                    }
                }

                //Calculate Possible Day
                possibleDay = listMK[index].getHariDom().Intersect(listR[temp].getHariAvailable());

                //Calculate Possible Time
                if (listR[temp].getjamMulai() > listMK[index].getJamDomAwal())
                {
                    minTime = listR[temp].getjamMulai();
                }
                else {
                    minTime = listMK[index].getJamDomAwal();
                }
                if (listR[temp].getjamAkhir() < listMK[index].getJamDomAkhir())
                {
                    maxTime = listR[temp].getjamAkhir();
                }
                else {
                    maxTime = listMK[index].getJamDomAkhir();
                }
            }
            //If there's room restriction
            else {
                temp = rng.Next(0, banyakRuangan);
                listMK[index].setRuanganSol(listR[temp].getNamaRuangan());
                Console.WriteLine("Assigned to room " + listMK[index].getRuanganSol());
                //Calculate Possible Day
                possibleDay = listMK[index].getHariDom().Intersect(listR[temp].getHariAvailable());

                //Calculate Possible Time
                if (listR[temp].getjamMulai() > listMK[index].getJamDomAwal())
                {
                    minTime = listR[temp].getjamMulai();
                }
                else {
                    minTime = listMK[index].getJamDomAwal();
                }
                if (listR[temp].getjamAkhir() < listMK[index].getJamDomAkhir())
                {
                    maxTime = listR[temp].getjamAkhir();
                }
                else {
                    maxTime = listMK[index].getJamDomAkhir();
                }

                //If assignment is not possible, do reassignment to room
                while ((possibleDay.ToArray().Length == 0) || ((minTime + listMK[index].getSks()) > maxTime))
                {
                    temp = rng.Next(0, banyakRuangan);
                    listMK[index].setRuanganSol(listR[temp].getNamaRuangan());
                    possibleDay = listMK[index].getHariDom().Intersect(listR[temp].getHariAvailable());
                    if (listR[temp].getjamMulai() > listMK[index].getJamDomAwal())
                    {
                        minTime = listR[temp].getjamMulai();
                    }
                    else {
                        minTime = listMK[index].getJamDomAwal();
                    }
                    if (listR[temp].getjamAkhir() < listMK[index].getJamDomAkhir())
                    {
                        maxTime = listR[temp].getjamAkhir();
                    }
                    else {
                        maxTime = listMK[index].getJamDomAkhir();
                    }
                }
            }
            temp = rng.Next(0, possibleDay.ToArray().Length);
            listMK[index].setHariSol(possibleDay.ElementAt(temp));
            temp = rng.Next(minTime, (maxTime + 1 - listMK[index].getSks()));
            listMK[index].setJamSol(temp);
            Console.WriteLine("Jam Mulai " + listMK[index].getJamSol());
            Console.WriteLine("Jam Akhir " + (listMK[index].getSks() + listMK[index].getJamSol()));
            Console.WriteLine("Hari " + listMK[index].getHariSol());

        }
    }
}
