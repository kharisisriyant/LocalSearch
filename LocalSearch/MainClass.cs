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

            Initializer init = new Initializer();
            init.Initialize(listMK, listR, fp.getBanyakJadwal(), fp.getBanyakRuangan());
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