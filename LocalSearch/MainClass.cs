using System;
using System.Collections.Generic;
namespace LocalSearch
{
	public class MainClass
	{
		public MainClass ()
		{
		}

        void GeneticAlgorithm(string[] jadwal, string[] ruangan, int banyakJadwal){
            Boolean[,,] conditionMatrix = new Boolean[5, 24, banyakJadwal];
            string[] sample = new string[8];

            for (int i = 0; i < 8; i++) {
                
            }
        }

		static void Main(string[] args){
			FileParser fp = new FileParser ();

			string[] jadwal = fp.getJadwal ();

            Console.WriteLine("Jumlah jadwal : " + fp.getBanyakJadwal());

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

            //Console.Read();
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