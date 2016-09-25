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
            int[] b = new int[3];
            b[0] = 99;
            b[1] = 55;
            b[2] = 11;
            int[] a = new int[b.Length];
            for (int c = 0; c < b.Length; c++)
            {
                a[c] = b[c];
                Console.WriteLine(Object.ReferenceEquals(a, b));
                Console.WriteLine(Object.ReferenceEquals(a[c], b[c]));
            }

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

            //Random Restart
            //RandomRestart rr = new RandomRestart();
            //rr.randomRestart(listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
            
            //Genetic Algorithm
            GeneticAlgorithm ga = new GeneticAlgorithm();
            listMK = ga.geneticAlgorithm(200000,listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());

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
            Console.Read();
		}
	}
}

