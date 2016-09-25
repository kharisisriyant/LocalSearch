using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class GeneticAlgorithm
    {
        public List<MataKuliah> geneticAlgorithm(List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan)
        {
            List<List<MataKuliah>> sample = new List<List<MataKuliah>>();
            List<List<MataKuliah>> temp = new List<List<MataKuliah>>();
            MataKuliah[] listTemp = new MataKuliah[banyakJadwal+1];
            Random rng = new Random();
            Initializer init = new Initializer();
            int[] fitness = new int[32];
            float[] chanceThreshold = new float[32];
            int maxFitness = (banyakJadwal - 1) * (banyakJadwal) / 2;
            int totalFitness;
            float randomNumber;
            int randomNumberI;
            int index = 0;
            Checker check = new Checker();
            Boolean found = false;
            int minTime = 0;
            int maxTime = 0;
            IEnumerable<int> possibleDay;

            //Initial generation
            for (int i = 0; i < 32; i++)
            {
                init.Initialize(listMK, listR, banyakJadwal, banyakRuangan);
                sample.Add(listMK.ToList()); //ToList() is used to ensure new list is created
            }

            //Series of Genetic Algorithm process
            for (int step = 0; step < 100; step++)
            {
                Console.WriteLine();
                Console.WriteLine("Process : " + step);
                //Calculate fitness function
                totalFitness = 0;
                for (int i = 0; i < 32; i++)
                {
                    check.hitungKonflik(sample[i]);
                    fitness[i] = maxFitness - check.getJumlahKonflik();
                    totalFitness = totalFitness + fitness[i];
                }
                Console.WriteLine("Fitness function done");

                //Selection chance
                chanceThreshold[0] = ((float)fitness[0]) / ((float)totalFitness);
                for (int i = 1; i < 32; i++)
                {
                    chanceThreshold[i] = chanceThreshold[i - 1] + ((float)fitness[i]) / ((float)totalFitness);
                }
                Console.WriteLine("Selection chance done");

                //Selection
                for (int i = 0; i < 32; i++)
                {
                    randomNumber = ((float)rng.Next(0, 1001)) / 1000f;
                    while ((index < 32) && (randomNumber > chanceThreshold[index]))
                    {
                        index++;
                    }
                    if (index == 32)
                    {
                        index = 31;
                    }
                    temp.Add(sample[index].ToList());
                }

                sample = temp;
                Console.WriteLine("Selection done");

                //Crossover
                for (int i = 0; i < 32; i = i + 2)
                {
                    randomNumberI = rng.Next(0, banyakJadwal);
                    if (randomNumberI != (banyakJadwal-1))
                    {
                        index = (randomNumberI+1);
                        sample[i].CopyTo((index),listTemp,0,(banyakJadwal-index));
                        for (int j = 0; j < (banyakJadwal - index) ; j++)
                        {
                            sample[i][index] = sample[i + 1].GetRange(index, 1)[0];
                            sample[i + 1][index] = listTemp[j];
                        }
                    }
                }
                Console.WriteLine("Crossover done");

                //Mutation
                for (int i = 0; i < 32; i++)
                {
                    index = 0;
                    randomNumberI = rng.Next(0, (banyakJadwal+1));
                    if (randomNumberI != banyakJadwal)
                    {
                        if (!sample[i][randomNumberI].getRuanganDom().Equals("-", StringComparison.Ordinal))
                        {
                            sample[i][randomNumberI].setRuanganSol(sample[i][randomNumberI].getRuanganDom());
                            while (!found)
                            {
                                if (sample[i][randomNumberI].getRuanganSol().Equals(listR[index].getNamaRuangan(), StringComparison.Ordinal))
                                {
                                    found = true;
                                }
                                else {
                                    index++;
                                }
                            }

                            //Calculate Possible Day
                            possibleDay = sample[i][randomNumberI].getHariDom().Intersect(listR[index].getHariAvailable());

                            //Calculate Possible Time
                            if (listR[index].getjamMulai() > sample[i][randomNumberI].getJamDomAwal())
                            {
                                minTime = listR[index].getjamMulai();
                            }
                            else {
                                minTime = sample[i][randomNumberI].getJamDomAwal();
                            }
                            if (listR[index].getjamAkhir() < sample[i][randomNumberI].getJamDomAkhir())
                            {
                                maxTime = listR[index].getjamAkhir();
                            }
                            else {
                                maxTime = sample[i][randomNumberI].getJamDomAkhir();
                            }
                        }
                        //If there's room restriction
                        else {
                            index = rng.Next(0, banyakRuangan);
                            sample[i][randomNumberI].setRuanganSol(listR[index].getNamaRuangan());
                            //Calculate Possible Day
                            possibleDay = sample[i][randomNumberI].getHariDom().Intersect(listR[index].getHariAvailable());

                            //Calculate Possible Time
                            if (listR[index].getjamMulai() > sample[i][randomNumberI].getJamDomAwal())
                            {
                                minTime = listR[index].getjamMulai();
                            }
                            else {
                                minTime = sample[i][randomNumberI].getJamDomAwal();
                            }
                            if (listR[index].getjamAkhir() < sample[i][randomNumberI].getJamDomAkhir())
                            {
                                maxTime = listR[index].getjamAkhir();
                            }
                            else {
                                maxTime = sample[i][randomNumberI].getJamDomAkhir();
                            }

                            //If assignment is not possible, do reassignment to room
                            while ((possibleDay.ToArray().Length == 0) || ((minTime + sample[i][randomNumberI].getSks()) > maxTime))
                            {
                                index = rng.Next(0, banyakRuangan);
                                sample[i][randomNumberI].setRuanganSol(listR[index].getNamaRuangan());
                                possibleDay = sample[i][randomNumberI].getHariDom().Intersect(listR[index].getHariAvailable());
                                if (listR[index].getjamMulai() > sample[i][randomNumberI].getJamDomAwal())
                                {
                                    minTime = listR[index].getjamMulai();
                                }
                                else {
                                    minTime = sample[i][randomNumberI].getJamDomAwal();
                                }
                                if (listR[index].getjamAkhir() < sample[i][randomNumberI].getJamDomAkhir())
                                {
                                    maxTime = listR[index].getjamAkhir();
                                }
                                else {
                                    maxTime = sample[i][randomNumberI].getJamDomAkhir();
                                }
                            }
                        }
                        index = rng.Next(0, possibleDay.ToArray().Length);
                        sample[i][randomNumberI].setHariSol(possibleDay.ElementAt(index));
                        index = rng.Next(minTime, (maxTime + 1 - sample[i][randomNumberI].getSks()));
                        sample[i][randomNumberI].setJamSol(index);
                    }
                }
            }
            Console.WriteLine("Mutation Done");
            for (int i = 0; i < 32; i++)
            {
                check.hitungKonflik(sample[i]);
                fitness[i] = maxFitness - check.getJumlahKonflik();
            }
            return (sample[Array.IndexOf(fitness, fitness.Max())]);
        }
    }
}
