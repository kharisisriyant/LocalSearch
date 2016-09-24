using System;
using System.Collections.Generic;
using System.Linq;
namespace LocalSearch
{
	public class MainClass
	{
		public MainClass ()
		{
		}

        void GeneticAlgorithm(List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan){
            Boolean[,,] conditionMatrix = new Boolean[5, 24, banyakJadwal];
            string[] sample = new string[256];
        }

        static void Initialize(List<MataKuliah> listMK, List<Ruangan> listR, int banyakJadwal, int banyakRuangan) {
            //Random and Variables
            Random rng = new Random();
            int minTime = 0;
            int maxTime = 0;
            IEnumerable<int> possibleDay;

            //Do assignment for every lecture
            for (int i = 0; i < banyakJadwal; i++) {
                int temp = 0;
                bool found= false;
                Console.WriteLine("Jadwal " + listMK[i].getNamaMatKul() + " (" + (i+1) + ")");

                //If no room restriction
                if (!listMK[i].getRuanganDom().Equals("-", StringComparison.Ordinal)) {
                    listMK[i].setRuanganSol(listMK[i].getRuanganDom());
                    Console.WriteLine("Assigned to room " + listMK[i].getRuanganSol());
                    while (!found) {
                        if (listMK[i].getRuanganSol().Equals(listR[temp].getNamaRuangan(), StringComparison.Ordinal)) {
                            found = true;
                        }
                        else {
                            temp++;
                        }
                    }

                    //Calculate Possible Day
                    possibleDay = listMK[i].getHariDom().Intersect(listR[temp].getHariAvailable());

                    //Calculate Possible Time
                    if (listR[temp].getjamMulai() > listMK[i].getJamDomAwal()) {
                        minTime = listR[temp].getjamMulai();
                    }
                    else {
                        minTime = listMK[i].getJamDomAwal();
                    }
                    if (listR[temp].getjamAkhir() < listMK[i].getJamDomAkhir()) {
                        maxTime = listR[temp].getjamAkhir();
                    }
                    else {
                        maxTime = listMK[i].getJamDomAkhir();
                    }
                }
                //If there's room restriction
                else {
                    temp = rng.Next(0, banyakRuangan);
                    listMK[i].setRuanganSol(listR[temp].getNamaRuangan());
                    Console.WriteLine("Assigned to room " + listMK[i].getRuanganSol());
                    //Calculate Possible Day
                    possibleDay = listMK[i].getHariDom().Intersect(listR[temp].getHariAvailable());

                    //Calculate Possible Time
                    if (listR[temp].getjamMulai() > listMK[i].getJamDomAwal()) {
                        minTime = listR[temp].getjamMulai();
                    }
                    else {
                        minTime = listMK[i].getJamDomAwal();
                    }
                    if (listR[temp].getjamAkhir() < listMK[i].getJamDomAkhir()) {
                        maxTime = listR[temp].getjamAkhir();
                    }
                    else {
                        maxTime = listMK[i].getJamDomAkhir();
                    }

                    //If assignment is not possible, do reassignment to room
                    while ((possibleDay.ToArray().Length == 0) || ((minTime + listMK[i].getSks()) > maxTime)) {
                        temp = rng.Next(0, banyakRuangan);
                        listMK[i].setRuanganSol(listR[temp].getNamaRuangan());
                        possibleDay = listMK[i].getHariDom().Intersect(listR[temp].getHariAvailable());
                        if (listR[temp].getjamMulai() > listMK[i].getJamDomAwal()) {
                            minTime = listR[temp].getjamMulai();
                        }
                        else {
                            minTime = listMK[i].getJamDomAwal();
                        }
                        if (listR[temp].getjamAkhir() < listMK[i].getJamDomAkhir()) {
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
                Console.WriteLine("Jam Mulai " + listMK[i].getJamSol());
                Console.WriteLine("Jam Akhir " + (listMK[i].getSks() + listMK[i].getJamSol()));
                Console.WriteLine("Hari " + listMK[i].getHariSol());
            }
        }

		static void Main(string[] args){
			FileParser fp = new FileParser ();

			string[] jadwal = fp.getJadwal ();

            Console.WriteLine("Jumlah jadwal : " + fp.getBanyakJadwal());
            Console.WriteLine("Jumlah ruangan : " + fp.getBanyakRuangan());

			List<MataKuliah> listMK = new List<MataKuliah> ();
			for (int i = 0; i < fp.getBanyakJadwal(); i++) {
				MataKuliah mk = new MataKuliah (jadwal [i]);
				listMK.Add (mk);
			}
								

			string[] rrr= fp.getRuangan ();
			List<Ruangan> listR = new List<Ruangan>();
			for (int i = 0; i < fp.getBanyakRuangan(); i++) {
				Ruangan r = new Ruangan (rrr[i]);
				listR.Add (r);
			}

            Initialize(listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            /* test checker
            Checker ch = new Checker();
            listMK[0].setHariSol(3);
            listMK[0].setJamSol(11);
            listMK[0].setRuanganSol("7602");
            Console.WriteLine(ch.checkAvail(listMK[0], listR));
            */
            Checker ch = new Checker();
            Console.WriteLine("Konflik ada " + ch.hitungKonflik(listMK));
            Console.Read();
		}
	}
}


/*Console.WriteLine ("\n\n");
			MataKuliah mk1 = new MataKuliah (jadwal [1]);
			Console.WriteLine ("\n\n");
			MataKuliah mk2 = new MataKuliah (jadwal [2]);
			Console.WriteLine ("\n\n");
			Console.WriteLine ("Ruangan");
*/