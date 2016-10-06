using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.LS
{
    class Initializer
    {
        public void Initialize(List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan, VariasiRuangan[] varR)
        {
            //Random and Variables
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            int minTime = 100;
            int maxTime = 0;
            IEnumerable<int> possibleDay;

            //Do assignment for every lecture
            for (int i = 0; i < banyakJadwal; i++)
            {
                int temp = 0;
                int varTemp = 0;
                int randomNumber;
                bool found = false;
                //Console.WriteLine("Jadwal " + listMK[i].getNamaMatKul() + " (" + (i + 1) + ")");

                //If no room restriction
                if (!listMK[i].getRuanganDom().Equals("-", StringComparison.Ordinal))
                {
                    listMK[i].setRuanganSol(listMK[i].getRuanganDom());
                    //Console.WriteLine("Assigned to room " + listMK[i].getRuanganSol());
                    while (!found)
                    {
                        if (listMK[i].getRuanganSol().Equals(listR[temp].getNamaRuangan(), StringComparison.Ordinal))
                        {
                            found = true;
                        }
                        else {
                            temp++;
                        }
                    }

                    //Pertimbangkan variasi kemungkinan
                    found = false;
                    while (!found)
                    {
                        if (varR[varTemp].nama.Equals(listR[temp].getNamaRuangan(), StringComparison.Ordinal))
                        {
                            found = true;
                        }
                        else
                        {
                            varTemp++;
                        }
                    }

                    //Generate offset index dari akses ruangan karena adanya variasi
                    randomNumber = rng.Next(0, varR[varTemp].variasi);

                    //Calculate Possible Day
                    possibleDay = listMK[i].getHariDom().Intersect(listR[temp+randomNumber].getHariAvailable());

                    //Ulangi kalkulasi bila tidak memungkinkan
                    while ((possibleDay.Count() < 1) && ((maxTime - minTime) < listMK[i].getSks()))
                    {
                        randomNumber = rng.Next(0, varR[varTemp].variasi);
                        possibleDay = listMK[i].getHariDom().Intersect(listR[temp + randomNumber].getHariAvailable());
                        //Calculate Possible Time
                        if (listR[temp + randomNumber].getjamMulai() > listMK[i].getJamDomAwal())
                        {
                            minTime = listR[temp + randomNumber].getjamMulai();
                        }
                        else {
                            minTime = listMK[i].getJamDomAwal();
                        }
                        if (listR[temp + randomNumber].getjamAkhir() < listMK[i].getJamDomAkhir())
                        {
                            maxTime = listR[temp + randomNumber].getjamAkhir();
                        }
                        else {
                            maxTime = listMK[i].getJamDomAkhir();
                        }
                    }

                    //Calculate Possible Time (untuk tidak terjadi reassign)
                    if (listR[temp + randomNumber].getjamMulai() > listMK[i].getJamDomAwal())
                    {
                        minTime = listR[temp + randomNumber].getjamMulai();
                    }
                    else {
                        minTime = listMK[i].getJamDomAwal();
                    }
                    if (listR[temp + randomNumber].getjamAkhir() < listMK[i].getJamDomAkhir())
                    {
                        maxTime = listR[temp + randomNumber].getjamAkhir();
                    }
                    else {
                        maxTime = listMK[i].getJamDomAkhir();
                    }
                }
                //If there's room restriction
                else {
                    temp = rng.Next(0, banyakRuangan);
                    listMK[i].setRuanganSol(listR[temp].getNamaRuangan());
                    //Console.WriteLine("Assigned to room " + listMK[i].getRuanganSol());
                    //Calculate Possible Day
                    possibleDay = listMK[i].getHariDom().Intersect(listR[temp].getHariAvailable());

                    //Calculate Possible Time
                    if (listR[temp].getjamMulai() > listMK[i].getJamDomAwal())
                    {
                        minTime = listR[temp].getjamMulai();
                    }
                    else {
                        minTime = listMK[i].getJamDomAwal();
                    }
                    if (listR[temp].getjamAkhir() < listMK[i].getJamDomAkhir())
                    {
                        maxTime = listR[temp].getjamAkhir();
                    }
                    else {
                        maxTime = listMK[i].getJamDomAkhir();
                    }

                    //If assignment is not possible, do reassignment to room
                    while ((possibleDay.ToArray().Length == 0) || ((minTime + listMK[i].getSks()) > maxTime))
                    {
                        temp = rng.Next(0, banyakRuangan);
                        listMK[i].setRuanganSol(listR[temp].getNamaRuangan());
                        //Console.WriteLine("Reassigned to room " + listMK[i].getRuanganSol());
                        possibleDay = listMK[i].getHariDom().Intersect(listR[temp].getHariAvailable());
                        if (listR[temp].getjamMulai() > listMK[i].getJamDomAwal())
                        {
                            minTime = listR[temp].getjamMulai();
                        }
                        else {
                            minTime = listMK[i].getJamDomAwal();
                        }
                        if (listR[temp].getjamAkhir() < listMK[i].getJamDomAkhir())
                        {
                            maxTime = listR[temp].getjamAkhir();
                        }
                        else {
                            maxTime = listMK[i].getJamDomAkhir();
                        }
                    }
                }
                temp = rng.Next(0, possibleDay.ToArray().Length);
                listMK[i].setHariSol(possibleDay.ElementAt(temp));
                temp = rng.Next(minTime, (maxTime + 1 - listMK[i].getSks()));
                listMK[i].setJamSol(temp);
                //Console.WriteLine("Jam Mulai " + listMK[i].getJamSol());
                //Console.WriteLine("Jam Akhir " + (listMK[i].getSks() + listMK[i].getJamSol()));
                //Console.WriteLine("Hari " + listMK[i].getHariSol());
            }
        }
    }
}
