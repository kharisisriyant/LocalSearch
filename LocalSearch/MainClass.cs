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
        
		static void Main(string[] args){
            
			FileParser fp = new FileParser ("D:/IF/Semester 5/AI/Spesifikasi/Testcase.txt");

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


            //Random Restart
            //RandomRestart rr = new RandomRestart();
            //rr.randomRestart(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());

            //Simmulated Annealing
            //SimulatedAnnealing sa = new SimulatedAnnealing();
            //sa.simulatedAnnealing(ref listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());

            //Genetic Algorithm
            GeneticAlgorithm ga = new GeneticAlgorithm();
            listMK = ga.geneticAlgorithm(1000,listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());

            //Initializer init = new Initializer();
            //init.Initialize(listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            /* test checker
            Checker ch = new Checker();
            listMK[0].setHariSol(3);
            listMK[0].setJamSol(11);
            listMK[0].setRuanganSol("7602");
            Console.WriteLine(ch.checkAvail(listMK[0], listR));
            */

            Checker ch = new Checker();
            ch.hitungKonflik(listMK);
            for (int i = 0; i < listMK.ToArray().Length; i++)
            {
                Console.WriteLine("Nama " + listMK[i].getNamaMatKul());
                Console.WriteLine("Ruangan " + listMK[i].getRuanganSol());
                Console.WriteLine("Jam Mulai " + listMK[i].getJamSol());
                Console.WriteLine("Jam Akhir " + (listMK[i].getSks() + listMK[i].getJamSol()));
                Console.WriteLine("Hari " + listMK[i].getHariSol());

            }
            Console.WriteLine("Konflik ada " + ch.getJumlahKonflik());
            Others ot = new Others();
            Console.WriteLine("Efektif = " + (ot.hitungEfektif(listMK, listR)*100) + " %");
            Console.Read();
        }
	}
}

