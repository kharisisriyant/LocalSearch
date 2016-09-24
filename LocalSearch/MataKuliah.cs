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

        //Copy Constructor
        public MataKuliah(MataKuliah n)
        {
            setNamaMatKul(n.getNamaMatKul());
            setRuanganDom(n.getRuanganDom());
            setRuanganSol(n.getRuanganSol());
            jamDom = new int[2];
            setJamDomAwal(n.getJamDomAwal());
            setJamDomAkhir(n.getJamDomAkhir());
            setJamSol(n.getJamSol());
            hariDom = new int[n.getHariDom().Length];
            setHariDom(n.getHariDom());
            setHariSol(n.getHariSol());
            setSks(n.getSks());
        }

        //getter
        public string getNamaMatKul() { return namaMatKul; }
        public string getRuanganDom() { return ruanganDom; }
        public string getRuanganSol() { return ruanganSol; }
        public int getJamDomAwal() { return jamDom[0]; }
        public int getJamDomAkhir() { return jamDom[1]; }
        public int getJamSol() { return jamSol; }
        public int[] getHariDom() { return hariDom; }
        public int getHariSol() { return hariSol; }
        public int getSks() { return sks; }

        //setter
        public void setNamaMatKul(string s) { namaMatKul = s; }
        public void setRuanganDom(string s) { ruanganDom = s; }
        public void setRuanganSol(string s) { ruanganSol = s; }
        public void setJamSol(int i) { jamSol = i; }
        public void setHariSol(int i) { hariSol = i; }
        public void setJamDomAwal(int jD) { jamDom[0] = jD; }
        public void setJamDomAkhir(int jD) { jamDom[1] = jD; }
        public void setSks(int s) { sks = s; }
        public void setHariDom(int[] h) { hariDom = new int[h.Length]; for(int i = 0;i<h.Length; ++i) { hariDom[i] = h[i]; } }

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