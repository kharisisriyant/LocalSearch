using System;

namespace LocalSearch
{
	public class FileParser
	{
		public FileParser ()
		{
            //Baca file
            //string[] lines = System.IO.File.ReadAllLines(@"D:\IF\Semester 5\AI\Spesifikasi\Testcase.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Tubes 1 AI scheduling\LocalSearch\LocalSearch\Testcase.txt");
             string[] lines = System.IO.File.ReadAllLines(@"G:\Testcase1.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Albert\Desktop\ITB\Semester 5\AI\LocalSearch\LocalSearch\Testcase.txt");
            int i = 0;
			while(i < lines.Length){
				Console.WriteLine (lines [i]);
				i++;
			}


			//masukin semua ke listjadwal sama ke listruangan
			i = 0;
			while(lines[i] !="Ruangan"){
				i++;
			}
			i++;
		
			listRuangan = new string[10];
			int jumlahRuangan = 0;
			while(lines[i] != ""){
				listRuangan[jumlahRuangan] = lines[i];
				i++;
				jumlahRuangan++;
			}
            banyakRuangan = jumlahRuangan;

			while(lines[i] !="Jadwal"){
				i++;
			}
			i++;

			listJadwal = new string[50];
			int jumlahJadwal = 0;
			while(i < lines.Length && lines[i] != ""){
				listJadwal[jumlahJadwal] = lines[i];
				i++;
				jumlahJadwal++;
			}
            banyakJadwal = jumlahJadwal;



/* Buat nampilin jadwal sama ruangan
 * i = 0;
			while (i < jumlahjadwal) {
				Console.WriteLine ("{0}", listjadwal [i]);
				i++;
			}
			i = 0;
			while (i < jumlahruangan) {
				Console.WriteLine ("{0}", listruangan [i]);
				i++;
			}*/
		}

        public FileParser(string path)
        {
            //Baca file
            //string[] lines = System.IO.File.ReadAllLines(@"D:\IF\Semester 5\AI\Spesifikasi\Testcase.txt");
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Joshua\Desktop\Tubes 1 AI scheduling\LocalSearch\LocalSearch\Testcase.txt");
            // string[] lines = System.IO.File.ReadAllLines(@"G:\Testcase.txt");
            string[] lines = System.IO.File.ReadAllLines(@path);
            //string[] lines = System.IO.File.ReadAllLines(@"G:\Testcase.txt");
            int i = 0;
            while (i < lines.Length)
            {
                Console.WriteLine(lines[i]);
                i++;
            }


            //masukin semua ke listjadwal sama ke listruangan
            i = 0;
            while (lines[i] != "Ruangan")
            {
                i++;
            }
            i++;

            listRuangan = new string[10];
            int jumlahRuangan = 0;
            while (lines[i] != "")
            {
                listRuangan[jumlahRuangan] = lines[i];
                i++;
                jumlahRuangan++;
            }
            banyakRuangan = jumlahRuangan;

            while (lines[i] != "Jadwal")
            {
                i++;
            }
            i++;

            listJadwal = new string[50];
            int jumlahJadwal = 0;
            while (i < lines.Length && lines[i] != "")
            {
                listJadwal[jumlahJadwal] = lines[i];
                i++;
                jumlahJadwal++;
            }
            banyakJadwal = jumlahJadwal;



            /* Buat nampilin jadwal sama ruangan
             * i = 0;
                        while (i < jumlahjadwal) {
                            Console.WriteLine ("{0}", listjadwal [i]);
                            i++;
                        }
                        i = 0;
                        while (i < jumlahruangan) {
                            Console.WriteLine ("{0}", listruangan [i]);
                            i++;
                        }*/
        }

        public string[] getJadwal(){
			return listJadwal;
		}
		public string[] getRuangan(){
			return listRuangan;
		}

        public int getBanyakJadwal() {
            return banyakJadwal;
        }
        public int getBanyakRuangan() {
            return banyakRuangan;
        }

		private string[] listRuangan;
		private string[] listJadwal;
        private int banyakRuangan;
        private int banyakJadwal;
	}
}

