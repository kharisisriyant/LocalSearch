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
            Random rng = new Random();
            Initializer init = new Initializer();
            string[] sample = new string[32];
            string[] temp = new string[32];
            string strtmp;
            int[] fitness = new int[32];
            float[] chanceThreshold = new float[32];
            int maxFitness = (banyakJadwal-1) * (banyakJadwal) / 2;
            int totalFitness = 0;
            float randomNumber;
            int index = 0;
            int count;
            Checker check = new Checker();

            for (int i = 0; i < 32; i++) {
                init.Initialize(listMK, listR, banyakJadwal, banyakRuangan);
                check.hitungKonflik(listMK);
                fitness[i] = maxFitness - check.getJumlahKonflik();
                totalFitness = totalFitness + fitness[i];
                sample[i] = "";
                for (int j = 0; j < banyakJadwal; j++) {
                    sample[i] = sample[i] + listMK[j].getNamaMatKul() + listMK[j].getRuanganSol() + listMK[j].getHariSol() + listMK[j].getJamSol() + listMK[j].getSks() + "/";
                }
            }
            chanceThreshold[0] = ((float)fitness[0]) / ((float)totalFitness);
            for (int i = 1; i < 32; i++) {
                chanceThreshold[i] = chanceThreshold[i - 1] + ((float)fitness[i]) / ((float)totalFitness);
            }

            //Selection
            for (int i = 0; i < 32; i++) {
                randomNumber = ((float)rng.Next(0, 1001)) / 1000f;
                while (index < 32)
                {
                    if (randomNumber > chanceThreshold[index])
                    {
                        index++;
                    }
                }
                if (index == 32)
                {
                    index = 31;
                }
                temp[i] = String.Copy(sample[index]);
            }

            sample = temp;

            //Crossover
            for (int i = 0; i < 32; i = i + 2){
                randomNumber = rng.Next(0, 32);
                int j = 0;
                int k = 0;
                count = 0;
                while (count < randomNumber) {
                    if (sample[i][j] == '/') {
                        count++;
                    }
                    j++;
                }
                count = 0;
                while (count < randomNumber) {
                    if (sample[i+1][k] == '/') {
                        count++;
                    }
                    k++;
                }
                if (j > 0) {
                    j = j - 1;
                }
                if (k > 0) {
                    k = k - 1;
                }
                strtmp = String.Copy(sample[i]);
                sample[i] = sample[i].Substring(0, j) + sample[i + 1].Substring(k);
                sample[i + 1] = sample[i + 1].Substring(0, k) + strtmp.Substring(j);
            }

            //Mutation
            randomNumber = rng.Next(0,33);
            if (randomNumber != 32) {

            }
        }

        int fitnessFunction (string sample, int banyakJadwal) {
            return 1; 
        }
    }
}
