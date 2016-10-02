using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.LS
{
    class GeneticAlgorithm
    {
        static private List<MataKuliah> deepClone(List<MataKuliah> listMK, int banyakJadwal)
        {
            List<MataKuliah> ltemp = new List<MataKuliah>();
            for(int i = 0; i < banyakJadwal; i++)
            {
                MataKuliah temp = new MataKuliah();
                temp.setNamaMatkul(listMK[i].getNamaMatKul());
                temp.setRuanganDom(listMK[i].getRuanganDom());
                temp.setRuanganSol(listMK[i].getRuanganSol());
                temp.setJamDomAwal(listMK[i].getJamDomAwal());
                temp.setJamDomAkhir(listMK[i].getJamDomAkhir());
                temp.setJamSol(listMK[i].getJamSol());
                temp.setHariDom(listMK[i].getHariDom());
                temp.setHariSol(listMK[i].getHariSol());
                temp.setSks(listMK[i].getSks());
                ltemp.Add(temp);
            }
            return ltemp;
        }

        public List<MataKuliah> geneticAlgorithm(int stepCount, List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan)
        {
            List<List<MataKuliah>> sample = new List<List<MataKuliah>>();
            List<List<MataKuliah>> temp = new List<List<MataKuliah>>();
            MataKuliah[] listTemp = new MataKuliah[banyakJadwal+1];
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            Initializer init = new Initializer();
            int size = 1024;
            int[] fitness = new int[size];
            float[] chanceThreshold = new float[size];
            int maxFitness = (banyakJadwal - 1) * (banyakJadwal) / 2;
            int totalFitness;
            float randomNumber;
            int randomNumberI;
            int index = 0;
            Checker check = new Checker();
            Boolean found = false;
            Boolean loopOut = false;
            int minTime = 0;
            int maxTime = 0;
            IEnumerable<int> possibleDay;

            //Initial generation
            for (int i = 0; i < size; i++)
            {
                init.Initialize(listMK, listR, banyakJadwal, banyakRuangan);
                sample.Add(deepClone(listMK, banyakJadwal));
            }

            //Series of Genetic Algorithm process
            for (int step = 0; step < stepCount; step++)
            {
                index = 0;
                //Console.WriteLine();
                //if (step % 25000 == 0)
                //{
                    //Console.WriteLine("Process : " + step);
                //}
                
                //Calculate fitness function
                totalFitness = 0;
                for (int i = 0; i < size; i++)
                {
                    check.hitungKonflik(sample[i]);
                    fitness[i] = maxFitness - check.getJumlahKonflik();
                    totalFitness = totalFitness + fitness[i];
                }
                //Console.WriteLine("Fitness function done");

                //Selection chance
                chanceThreshold[0] = ((float)fitness[0]) / ((float)totalFitness);
                for (int i = 1; i < size; i++)
                {
                    chanceThreshold[i] = chanceThreshold[i - 1] + ((float)fitness[i]) / ((float)totalFitness);
                }
                //Console.WriteLine("Selection chance done");

                //Selection
                temp = new List<List<MataKuliah>>();
                for (int i = 0; i < size; i++)
                {
                    randomNumber = ((float)rng.Next(0, 1001)) / 1000f;
                    while ((index < size) && (randomNumber > chanceThreshold[index]))
                    {
                        index++;
                    }
                    if (index == size)
                    {
                        index = (size - 1);
                    }
                    temp.Add(deepClone(sample[index],banyakJadwal));
                }

                sample = temp;
                //Console.WriteLine("Selection done");

                //Crossover
                for (int i = 0; i < size; i = i + 2)
                {
                    randomNumberI = rng.Next(0, banyakJadwal);
                    if (randomNumberI != (banyakJadwal-1))
                    {
                        index = (randomNumberI+1);
                        int length = (banyakJadwal - index);
                        sample[i].CopyTo((index),listTemp,0,(banyakJadwal-index));
                        for (int j = 0; j < length ; j++)
                        {
                            sample[i][index] = sample[i + 1].GetRange(index, 1)[0];
                            sample[i + 1][index] = listTemp[j];
                            index++;
                        }
                    }
                }
                //Console.WriteLine("Crossover done");

                //Mutation
                for (int i = 0; i < size; i++)
                {
                    index = 0;
                    found = false;
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
                for (int i = 0; i < size; i++)
                {
                    check.hitungKonflik(sample[i]);
                    if (check.getJumlahKonflik() < 8)
                    {
                        loopOut = true;
                    }
                }
                if (loopOut)
                {
                    break;
                }
            }
            //Console.WriteLine("Mutation Done");
            for (int i = 0; i < size; i++)
            {
                check.hitungKonflik(sample[i]);
                fitness[i] = maxFitness - check.getJumlahKonflik();
            }
            return (sample[Array.IndexOf(fitness, fitness.Max())]);
        }
    }
}
