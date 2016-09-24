using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class GeneticAlgorithm
    {
        void geneticAlgorithm(List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan) {
            Initializer init = new Initializer();
            string[] sample = new string[32];
            int[] fitness = new int[32];
            int[,,] conditionMatrix = new int[5, 24, banyakJadwal];
            for (int i = 0; i < 32; i++) {
                init.Initialize(listMK, listR, banyakJadwal, banyakRuangan);
                sample[i] = "";
                for (int j = 0; j < banyakJadwal; j++) {
                    sample[i] = sample[i] + listMK[j].getNamaMatKul() + listMK[j].getRuanganSol() + listMK[j].getHariSol() + listMK[j].getJamSol() + listMK[j].getSks() + "/";
                }
            }
        }

        int fitnessFunction (string sample, int banyakJadwal) {
            return 1; 
        }
    }
}
