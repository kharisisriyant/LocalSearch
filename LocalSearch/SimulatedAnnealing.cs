using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class SimulatedAnnealing
    {
        private int thresholdMax = 10000; //threshold step sampai terminate

        private double thresholdTemperature = 0.1; //threshold temperature untuk hill climbing

        private double ratio = 0.9;

        private double initTemperature = 100.0; //temperatur awal

        public void simulatedAnnealing(ref List<MataKuliah> LMK, List<Ruangan> LR, int banyakjadwal, int banyakruangan)
        {
            
            Checker ch = new Checker();
            Initializer init = new Initializer();
            init.Initialize(LMK, LR, banyakjadwal, banyakruangan); //inisialisasi
            ch.hitungKonflik(LMK);
            List<MataKuliah> tempLMK = new List<MataKuliah>();
            double temperatur = initTemperature;
            int konflikLama = 0;
            int konflikBaru = 0;
            int deltaKonflik = 0;
            double chance = 0.0;
            int idxMax = 0;
            int step = 1;

            while (step < thresholdMax && ch.getJumlahKonflik() > 0)
            {
                ch.hitungKonflik(LMK);
                konflikLama = ch.getJumlahKonflik();
                idxMax = ch.getIndexMaxMKKonflik();
                tempLMK = cloneListMK(LMK);
                newAssign(idxMax, LMK, LR, banyakjadwal, banyakruangan); //randomize value dari variabel konflik
                ch.hitungKonflik(LMK);
                konflikBaru = ch.getJumlahKonflik();
                deltaKonflik = konflikBaru - konflikLama;
                if (deltaKonflik > 0) //Bad Move
                {
                    chance = countProbability(temperatur, deltaKonflik, LMK);
                    if (!isAccept(chance, temperatur)) //not accept change
                    {
                        LMK = tempLMK;
                    }
                }
                temperatur = temperatur * ratio;
                Console.WriteLine("Konflik: " + ch.getJumlahKonflik() + "\n");
                ++step;
            }
        }
        
        public double countProbability(double temp, int deltaKonf, List<MataKuliah> LM)
        {
            Checker ch = new Checker();
            int maxKonflik = ch.countMaxPossibleKonflik(LM);
            double prob = Math.Exp(-Convert.ToDouble(maxKonflik - deltaKonf) / temp);
            return prob;
        }
        
        public Boolean isAccept(double prob, double temp)//accept bad move or not
        {
            if(temp < thresholdTemperature)
            {
                return false;
            }
            Random rnd = new Random();
            double r = rnd.Next(0, 100);
            if ((prob - r) > 0)
            {
                return true; 
            }
            else
            {
                return false;
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
