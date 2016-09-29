using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    class Others
    {
        public void ubahMataKuliah(ref List<MataKuliah> LMK, MataKuliah MK, int hari, int jam, String namaRuangan)
        {
            if (LMK != null)
            {
                int i = 0;
                while (i < LMK.Count())
                {
                    if(LMK[i].getNamaMatKul() == MK.getNamaMatKul())
                    {
                        break;
                    }
                    else
                    {
                        ++i;
                    }
                }
                LMK[i].setHariSol(hari);
                LMK[i].setJamSol(jam) ;
                LMK[i].setRuanganSol(namaRuangan);
            }
        }

        public double hitungEfektif(List<MataKuliah> LMK, List<Ruangan> R)
        {
            int nfalse = 0; //jumlah kelas false
            int ntrue = 0; //jumlah kelas true
            if (R != null && LMK!=null)
            {
                int a = 0;
                //iterasi untuk membuat true kelas yang sudah terisi setiap matakuliah
                while (a < LMK.Count)
                {
                    int b = 0;
                    while(b < R.Count) //iterasi untuk mencari ruangan matakuliah di dalam list ruangan 
                    {
                        if (LMK[a].getRuanganSol() == R[b].getNamaRuangan())
                        {
                            break;
                        }
                        else
                        {
                            ++b;
                        }
                    }
                    for(int x = 0; x < LMK[a].getSks(); ++x) //iterasi untuk mengisi jam sesuai sks
                    {
                        R[b].terisi[LMK[a].getHariSol(), (LMK[a].getJamSol())+ x] = true;
                    }
                    ++a;
                }
                int i = 0;
                while (i < R.Count) // menghitung jumlah yang false dan yang true
                {
                    int jumlahhari = R[i].getHariAvailable().Length;
                    int jamAvail = R[i].getjamAkhir() - R[i].getjamMulai();
                    for (int x = 0; x < jumlahhari; x++)
                    {
                        for (int y = 0; y < jamAvail; y++)
                        {
                            if(R[i].terisi[x, y] == false)
                            {
                                ++nfalse;
                            }
                            else
                            {
                                ++ntrue;
                            }
                        }
                    }
                }
            }
            double efektif = (double) ntrue / (double) (ntrue + nfalse);
            return efektif;
        }
        
    }
}
