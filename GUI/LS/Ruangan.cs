using System;

namespace GUI.LS
{
	public class Ruangan
	{
        public Ruangan ()
        {
            namaRuangan = null;
        }
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
           
            
            //init bool[][]
            i = 0;
            int jumlahhari = getHariAvailable().Length;
            int jamAvail = getjamAkhir() - getjamMulai();
            terisi = new bool[jumlahhari,jamAvail];
            for(int x=0; x<jumlahhari; x++)
            {
                for(int y=0; y<jamAvail; y++)
                {
                    terisi[x,y] = new bool();
                    terisi[x,y] = false;
                }
            }

            Console.WriteLine ("{0}", namaRuangan);
			Console.WriteLine ("{0}", jamAvailable[0]);
			Console.WriteLine ("{0}", jamAvailable[1]);
			Console.WriteLine ("{0}", hariAvailable[0]);

		}

        public string getNamaRuangan()
        {
            return namaRuangan;
        }

        public int getjamMulai()
        {
            return jamAvailable[0];
        }

        public int getjamAkhir()
        {
            return jamAvailable[1];
        }

        public int[] getHariAvailable()
        {
            return hariAvailable;
        }

        public int getHariAVailable(int i)
        {
            return hariAvailable[i];
        }

		private string namaRuangan;
		private int[] jamAvailable; //jamAvailable[0] awal jamAvailable[1] akhir 
		private int[] hariAvailable;
        public bool[,] terisi;
		//notes: jam sama hari mau string atau mau int???
	}
}

