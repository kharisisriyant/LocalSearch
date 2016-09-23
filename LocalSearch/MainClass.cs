using System;
using System.Collections.Generic;
namespace LocalSearch
{
	public class MainClass
	{
		public MainClass ()
		{
		}

		static void Main(string[] args){
			FileParser fp = new FileParser ();

			string[] jadwal = fp.getJadwal ();

			List<MataKuliah> listMK = new List<MataKuliah> ();
			for (int i = 0; i < jadwal.Length; i++) {
				MataKuliah mk = new MataKuliah (jadwal [i]);
				listMK.Add (mk);
			}
								

			string[] rrr= fp.getRuangan ();
			List<Ruangan> listR = new List<Ruangan>();
			for (int i = 0; i < jadwal.Length; i++) {
				Ruangan r = new Ruangan (rrr[i]);
				listR.Add (r);
			}
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