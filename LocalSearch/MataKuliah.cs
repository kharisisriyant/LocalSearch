using System;

namespace LocalSearch
{
	public class MataKuliah
	{
		public MataKuliah (string matKul)
		{
			string[] line = matKul.Split(';');
			namaMatKul = line [0];
			ruanganDom = line [1];
			jamDom = new int[2];
			string[] jam = line [2].Split('.');
			jamDom [0] = Int32.Parse(jam[0]);
			jam = line [3].Split ('.');
			jamDom [1] = Int32.Parse(jam[0]);
			sks = Int32.Parse(line [4]);
			int i = 0;
			string[] hari = line [5].Split (',');
			hariDom = new int[hari.Length];
			while (i < hari.Length) {
				hariDom [i] = Int32.Parse (hari [i]);
				i++;
			}

			Console.WriteLine ("{0}", namaMatKul);
			Console.WriteLine ("{0}", ruanganDom);
			Console.WriteLine ("{0}", jamDom[0]);
			Console.WriteLine ("{0}", jamDom[1]);
			Console.WriteLine ("{0}", sks);
			Console.WriteLine ("{0}", hariDom[0]);
		}

        public MataKuliah()
        {
        }

        public string getNamaMatKul() { return namaMatKul; }
        public string getRuanganDom() { return ruanganDom; }
        public string getRuanganSol() { return ruanganSol; }
        public int getJamDomAwal() { return jamDom[0]; }
        public int getJamDomAkhir() { return jamDom[1]; }
        public int getJamSol() { return jamSol; }
        public int[] getHariDom() { return hariDom; }
        public int getHariSol() { return hariSol; }
        public int getSks() { return sks; }

        public void setRuanganSol(String s) { ruanganSol = s; }
        public void setJamSol(int i) { jamSol = i; }
        public void setHariSol(int i) { hariSol = i; }

        private string namaMatKul;
		private string ruanganDom;
		private string ruanganSol;
		private int[] jamDom;
		private int jamSol;
		private int[] hariDom;
		private int hariSol;
		private int sks;
        


        //notes: jam sama hari mau string atau mau int???
    }
}

/*
Ruangan
7602;07.00;14.00;1,2,3,4,5
7603;07.00;14.00;1,3,5
7610;09.00;12.00;1,2,3,4,5
Labdas2;10.00;14.00;2,4

Jadwal
IF2110;7602;07.00;12.00;4;1,2,3,4,5
IF2130;-;10.00;16.00;3;3,4
IF2150;-;09.00;13.00;2;1,3,5
IF2170;7610;07.00;12.00;3;1,2,3,4,5
*/