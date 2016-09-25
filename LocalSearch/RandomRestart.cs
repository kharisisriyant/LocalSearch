using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class RandomRestart
    {
        private int thresholdMax = 100;
        private int thresholdRestart = 10;
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
        public void randomRestart(ref List<MataKuliah> LMK, List<Ruangan> LR, int banyakjadwal, int banyakruangan)
        {
            int step = 0;
            int konfliklama = 0;
            Checker ch = new Checker();
            Initializer init = new Initializer();
            init.Initialize(LMK, LR, banyakjadwal, banyakruangan);
            ch.hitungKonflik(LMK);
            //history best konflik yang ada
            List<MataKuliah> HLMK = cloneListMK(LMK); // history awal saat inisialisasi awal 
            Checker ch2 = new Checker();
            while (step < thresholdMax && ch.getJumlahKonflik() > 0)
            {
                init.Initialize(LMK, LR, banyakjadwal, banyakruangan);
                ch.hitungKonflik(LMK);
                ++step;
                while (ch.getJumlahKonflik() > 0 && (step % thresholdRestart > 0))
                {
                    konfliklama = ch.getJumlahKonflik();
                    int i = ch.getIndexMaxMKKonflik();
                    newAssign(i, LMK, LR, banyakjadwal, banyakruangan);
                    ch.hitungKonflik(LMK);
                    Console.WriteLine("Konflik: " + ch.getJumlahKonflik());
                    while (ch.getJumlahKonflik() > konfliklama && (step % thresholdRestart > 0))
                    {
                        ch.hitungKonflik(LMK);
                        newAssign(i, LMK, LR, banyakjadwal, banyakruangan);
                        ++step;
                    }
                }
                System.Console.WriteLine("selesai\n");
                ch.hitungKonflik(LMK);
                ch2.hitungKonflik(HLMK);
                if (ch.getJumlahKonflik() <= ch2.getJumlahKonflik())
                {
                    HLMK = cloneListMK(LMK);
                }
            }
            //jika hasil akhir lebih jelek dr history terbaik maka di ganti
            ch2.hitungKonflik(HLMK);
            ch.hitungKonflik(LMK);
            if (ch.getJumlahKonflik() > ch2.getJumlahKonflik())
            {
                LMK = HLMK;
            }
            /*
            ch2.hitungKonflik(HLMK);
            ch.hitungKonflik(LMK);
            Console.WriteLine("HLMK: " + ch2.getJumlahKonflik());
            Console.WriteLine("LMK: " + ch.getJumlahKonflik());
            */        
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
