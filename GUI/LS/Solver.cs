using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.LS
{
    class Solver
    {
        public Solver()
        {

        }

        public void Solve(string filepath, int AlgoChoosed)
        {
            int i = 0;
            int j = 0;
            VariasiRuangan[] variasiRuangan;
            FileParser fp = new FileParser(filepath);

            string[] jadwal = fp.getJadwal();

            //Isi listMK
            listMK = new List<MataKuliah>();
            for (int k = 0; k < fp.getBanyakJadwal(); k++)
            {
                MataKuliah mk = new MataKuliah(jadwal[k]);
                listMK.Add(mk);
            }

            string[] rrr = fp.getRuangan();

            //Isi ListR
            listR = new List<Ruangan>();
            for (int k = 0; k < fp.getBanyakRuangan(); k++)
            {
                Ruangan r = new Ruangan(rrr[k]);
                listR.Add(r);
            }
            listR = sortListRuangan(listR);
            variasiRuangan = new VariasiRuangan[fp.getBanyakRuangan()];
            while (i < fp.getBanyakRuangan())
            {
                variasiRuangan[j] = new VariasiRuangan();
                variasiRuangan[j].nama = listR[i].getNamaRuangan();
                variasiRuangan[j].variasi = 1;
                i++;
                if (i >= fp.getBanyakRuangan())
                {
                    break;
                }
                while (variasiRuangan[j].nama.Equals(listR[i].getNamaRuangan(), StringComparison.Ordinal))
                {
                    variasiRuangan[j].variasi++;
                    i++;
                    if (i >= fp.getBanyakRuangan())
                    {
                        break;
                    }
                }
                if (i >= fp.getBanyakRuangan())
                {
                    break;
                }
                j++;
            }

            //Cek Algo yang dipakai
            if (AlgoChoosed == 1)
            {
                RandomRestart rr = new RandomRestart();
                rr.randomRestart(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan(), variasiRuangan);
            }
            if (AlgoChoosed == 2)
            {
                SimulatedAnnealing sa = new SimulatedAnnealing();
                sa.simulatedAnnealing(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan(), variasiRuangan);
            }
            if (AlgoChoosed == 3)
            {
                GeneticAlgorithm ga = new GeneticAlgorithm();
                listMK = ga.geneticAlgorithm(500, listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan(), variasiRuangan);
            }

            //Menjalankan perhitungan konflik dan efektifitas
            Checker ch = new Checker();
            Others ot = new Others();
            ch.hitungKonflik(listMK);

            jmlK = ch.getJumlahKonflik();
            jmlO = ot.hitungEfektif(listMK, listR) * 100;
        }

        public List<Ruangan> sortListRuangan(List<Ruangan> LMK){
            List<Ruangan> tmp = LMK.OrderBy(o => o.getNamaRuangan()).ToList();
            tmp.ForEach(Console.WriteLine);
            return tmp;
        }

        public int jmlK;
        public double jmlO;
        public List<MataKuliah> listMK;
        public List<Ruangan> listR;


    }
}
