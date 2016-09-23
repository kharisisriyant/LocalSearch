using System;

namespace LocalSearch
{
	public class Ruangan
	{
		public Ruangan (string ruangan)
		{
			string[] line = ruangan.Split (';');
			namaRuangan = line [0];

			jamAvailable = new int[2];
			string[] jam = line [1].Split ('.');
			jamAvailable [0] = Int32.Parse(jam[0]);
			jam = line [2].Split ('.');
			jamAvailable [1] = Int32.Parse(jam[0]);

			string[] hari = line [3].Split (',');
			hariAvailable = new int[hari.Length];
			int i = 0;
			while (i < hari.Length) {
				hariAvailable [i] = Int32.Parse (hari [i]);
				i++;
			}

			Console.WriteLine ("{0}", namaRuangan);
			Console.WriteLine ("{0}", jamAvailable[0]);
			Console.WriteLine ("{0}", jamAvailable[1]);
			Console.WriteLine ("{0}", hariAvailable[0]);

		}

		private string namaRuangan;
		private int[] jamAvailable; //jamAvailable[0] awal jamAvailable[1] akhir 
		private int[] hariAvailable;


		//notes: jam sama hari mau string atau mau int???
	}
}

