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
            FileParser fp = new FileParser(filepath);

            string[] jadwal = fp.getJadwal();

            //Isi listMK
            listMK = new List<MataKuliah>();
            for (int i = 0; i < fp.getBanyakJadwal(); i++)
            {
                MataKuliah mk = new MataKuliah(jadwal[i]);
                listMK.Add(mk);
            }

            string[] rrr = fp.getRuangan();

            //Isi ListR
            listR = new List<Ruangan>();
            for (int i = 0; i < fp.getBanyakRuangan(); i++)
            {
                Ruangan r = new Ruangan(rrr[i]);
                listR.Add(r);
            }

            //Cek Algo yang dipakai
            if (AlgoChoosed == 1)
            { 
            RandomRestart rr = new RandomRestart();
            rr.randomRestart(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            }
            if (AlgoChoosed == 2)
            {
                SimulatedAnnealing sa = new SimulatedAnnealing();
                sa.simulatedAnnealing(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            }
            if (AlgoChoosed == 3)
            {
                GeneticAlgorithm ga = new GeneticAlgorithm();
                listMK = ga.geneticAlgorithm(500,listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            }

            //Menjalankan perhitungan konflik dan efektifitas
            Checker ch = new Checker();
            Others ot = new Others();
            ch.hitungKonflik(listMK);

            jmlK = ch.getJumlahKonflik();
            jmlO = ot.hitungEfektif(listMK, listR)*100;
        }
        public int jmlK;
        public double jmlO;
        public List<MataKuliah> listMK;
        public List<Ruangan> listR;


    }
}
