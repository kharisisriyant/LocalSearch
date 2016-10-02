using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.LS;

namespace GUI
{
    public partial class SolutionForm : Form
    {
        public SolutionForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            this.listMK = new List<MataKuliah>();
            this.listR = new List<Ruangan>();

        }

        public SolutionForm(List<MataKuliah> listMK,List<Ruangan> listR,string jmlCon,string jmlEfk)
        {
            InitializeComponent();
            InitializeDataGridView();
            this.listMK = listMK;
            this.listR = listR;
            jmlConflict.Text = jmlCon;
            jmlEfektif.Text = jmlEfk;
            foreach (Ruangan item in listR)
            {
                string namaRuang = item.getNamaRuangan();
                optionRuang.Items.Add(namaRuang);
            }
        }

        private void InitializeDataGridView()
        {
            // Deklarasi Jumlah kolom dan baris
            tabel.ColumnCount = 5;
            tabel.RowCount = 11;
            tabel.ColumnHeadersVisible = true;
            tabel.RowHeadersVisible = true;

            // Set the kolom dan baris header style
            DataGridViewCellStyle HeaderStyle = new DataGridViewCellStyle();

            HeaderStyle.BackColor = Color.Beige;
            HeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            tabel.ColumnHeadersDefaultCellStyle = HeaderStyle;
            tabel.RowHeadersDefaultCellStyle = HeaderStyle;
            tabel.RowHeadersWidth = 80;

            // Set header kolom
            tabel.Columns[0].HeaderCell.Value = "Senin";
            tabel.Columns[1].HeaderCell.Value = "Selasa";
            tabel.Columns[2].HeaderCell.Value = "Rabu";
            tabel.Columns[3].HeaderCell.Value = "Kamis";
            tabel.Columns[4].HeaderCell.Value = "Jumat";

            //Set header baris
            tabel.Rows[0].HeaderCell.Value = "07.00";
            tabel.Rows[1].HeaderCell.Value = "08.00";
            tabel.Rows[2].HeaderCell.Value = "09.00";
            tabel.Rows[3].HeaderCell.Value = "10.00";
            tabel.Rows[4].HeaderCell.Value = "11.00";
            tabel.Rows[5].HeaderCell.Value = "12.00";
            tabel.Rows[6].HeaderCell.Value = "13.00";
            tabel.Rows[7].HeaderCell.Value = "14.00";
            tabel.Rows[8].HeaderCell.Value = "15.00";
            tabel.Rows[9].HeaderCell.Value = "16.00";
            tabel.Rows[10].HeaderCell.Value = "17.00";
            
        }

        //Return Index Column berdasarkan hari matkul
        public int HtoC(MataKuliah MK)
        {
            if(MK.getHariSol()>0)
            {
                return MK.getHariSol() - 1;
            }
            else
            {
                return 0;
            }
        }

        //Return Index Row berdasarkan jam matkul
        public int JtoR(MataKuliah MK)
        {
            if (MK.getJamSol() > 6)
            {
                return MK.getJamSol() - 7;
            }
            else
            {
                return 0;
            }
        }
        
        public void hideTabel()
        {
            for (int i = 0; i < tabel.RowCount; i++)
            {
                for (int j = 0; j < tabel.ColumnCount; j++)
                {
                    tabel.Rows[i].Cells[j].Value = null;
                    tabel.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        public void fillTabel(string ruang)
        {
            initColor();
            int c = 0;
            for (int k = 0; k < listMK.ToArray().Length; k++)
            {
                if (listMK[k].getRuanganSol() == ruang)
                {
                    int i = JtoR(listMK[k]);
                    int j = HtoC(listMK[k]);
                    int n = listMK[k].getSks();
                    for (int l = 0; l < n; l++)
                    {
                        if (this.tabel.Rows[i].Cells[j].Value==null)
                        { 
                            this.tabel.Rows[i].Cells[j].Value = listMK[k].getNamaMatKul();
                            if (c < listC.Length)
                            {
                                this.tabel.Rows[i].Cells[j].Style.ForeColor = listC[c];

                            }
                        }
                        else
                        {
                            this.tabel.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                            this.tabel.Rows[i].Cells[j].Value += ", "+listMK[k].getNamaMatKul();
                        }
                         i++;
                    }
                    c++;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void jmlConflict_Click(object sender, EventArgs e)
        {
            
        }

        private void jmlEfektif_Click(object sender, EventArgs e)
        {

        }

        private void optionRuang_SelectedIndexChanged(object sender, EventArgs e)
        {
            pilMatkul.SelectedItem = null;
            pilMatkul.Items.Clear();
            pilRuangan.SelectedItem = null;
            pilRuangan.Items.Clear();
            pilHari.SelectedItem = null;
            pilHari.Items.Clear();
            pilJam.SelectedItem = null;
            pilJam.Items.Clear();
            pilihanRuangan = (string)optionRuang.SelectedItem;
            int index = -1;
            index = optionRuang.FindStringExact(pilihanRuangan);
            if (index != -1)
            {
                hideTabel();
                initpilMatkul();
                fillTabel(optionRuang.Items[index].ToString());

            }
        }

        private void pilMatkul_SelectedIndexChanged(object sender, EventArgs e)
        {
            pilRuangan.SelectedItem = null;
            pilRuangan.Items.Clear();
            pilHari.SelectedItem = null;
            pilHari.Items.Clear();
            pilJam.SelectedItem = null;
            pilJam.Items.Clear();
            pilihanMatkul = (string)pilMatkul.SelectedItem;
            int index = -1;
            index = pilMatkul.FindStringExact(pilihanMatkul);
            if (index != -1)
            {
                initpilRuangan();
                //fillTabel(optionRuang.Items[index].ToString());
            }
        }

        private void pilRuangan_SelectedIndexChanged(object sender, EventArgs e)
        {
            pilHari.SelectedItem = null;
            pilHari.Items.Clear();
            pilJam.SelectedItem = null;
            pilJam.Items.Clear();
            pilihanRuanganAvail = (string)pilRuangan.SelectedItem;
            int index = -1;
            index = pilRuangan.FindStringExact(pilihanRuanganAvail);
            if (index != -1)
            {
                initpilHari();
            }
        }

        private void pilHari_SelectedIndexChanged(object sender, EventArgs e)
        {
            pilJam.SelectedItem = null;
            pilJam.Items.Clear();
            pilihanHari = (string)pilHari.SelectedItem;
            int index = -1;
            index = pilHari.FindStringExact(pilihanHari);
            if (index != -1)
            {
                initpilJam();
            }
        }

        private void pilJam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pilJam.SelectedItem!=null)
            pilihanJam = (int)pilJam.SelectedItem;
            
        }

        public void changeListMK()
        {
            foreach(MataKuliah MK in listMK)
            {
                if (MK.getNamaMatKul()==pilihanMatkul)
                {
                    MK.setRuanganSol(pilihanRuanganAvail);
                    MK.setHariSol(InttoDay(pilihanHari));
                    MK.setJamSol(pilihanJam);
                }
            }
        }

        private void submitPindah_Click(object sender, EventArgs e)
        {
            if (pilihanMatkul != null)
            {
                if (pilihanRuanganAvail != null)
                {
                    if (pilihanHari != null)
                    {
                        if (pilihanJam != null)
                        {
                            hideTabel();
                            changeListMK();
                            optionRuang.SelectedItem = pilihanRuanganAvail;
                            fillTabel(pilihanRuanganAvail);
                            pilMatkul.SelectedItem = null;
                            pilMatkul.Items.Clear();
                            pilRuangan.SelectedItem = null;
                            pilRuangan.Items.Clear();
                            pilHari.SelectedItem = null;
                            pilHari.Items.Clear();
                            pilJam.SelectedItem = null;
                            pilJam.Items.Clear();
                            initpilMatkul();

                        }
                        else
                        MessageBox.Show("Please choose starting hour to move the schedule!");
                    }
                    else
                        MessageBox.Show("Please choose day to move the schedule!");
                }
                else
                    MessageBox.Show("Please choose room to move the schedule!");
            }
            else
                MessageBox.Show("Please choose course to move the schedule!");
        }

        public void initpilMatkul()
        {
            
            foreach (MataKuliah item in listMK)
            {
                if (item.getRuanganSol() == pilihanRuangan)
                {
                    string namaMatkul = item.getNamaMatKul();
                    pilMatkul.Items.Add(namaMatkul);
                }
            }
        }

        public void initpilRuangan()
        {
            MataKuliah pilihan = new MataKuliah();
            foreach(MataKuliah item in listMK)
            {
                if (pilihanMatkul == item.getNamaMatKul())
                {
                    pilihan = item;
                }

            }
            if(pilihan.getRuanganDom() == "-")
            {
                foreach(Ruangan item in listR)
                {
                    string pilRuangDom = item.getNamaRuangan();
                    pilRuangan.Items.Add(pilRuangDom);
                }
            }
            else
            {
                string pilRuangDom = pilihan.getRuanganDom();
                pilRuangan.Items.Add(pilRuangDom);
            }
        }

        public void initpilHari()
        {
            MataKuliah pilihanMK = new MataKuliah();
            foreach (MataKuliah item in listMK)
            {
                if (pilihanMatkul == item.getNamaMatKul())
                {
                    pilihanMK = item;
                }

            }

            Ruangan pilihanR = new Ruangan();
            foreach (Ruangan item in listR)
            {
                if (pilihanRuanganAvail == item.getNamaRuangan())
                {
                    pilihanR = item;
                }
            }

            List<int> HariAvail = new List<int>();
            foreach (int hariM in pilihanMK.getHariDom())
            {
               foreach (int hariR in pilihanR.getHariAvailable())
               {
                  if (hariM == hariR)
                  {
                      HariAvail.Add(hariM);
                  }
               }
            }
            foreach (int item in HariAvail)
            {
               
                pilHari.Items.Add(tabel.Columns[item-1].HeaderCell.Value.ToString());
            }
        }
  
        public void initpilJam()
        {
            MataKuliah pilihanMK = new MataKuliah();
            foreach (MataKuliah item in listMK)
            {
                if (pilihanMatkul == item.getNamaMatKul())
                {
                    pilihanMK = item;
                }

            }

            Ruangan pilihanR = new Ruangan();
            foreach (Ruangan item in listR)
            {
                if (pilihanRuanganAvail == item.getNamaRuangan())
                {
                    pilihanR = item;
                }
            }

            int batasanA;
            int batasanB;
            if (pilihanMK.getJamDomAwal() > pilihanR.getjamMulai())
                batasanA = pilihanMK.getJamDomAwal();
            else
                batasanA = pilihanR.getjamMulai();
            if (pilihanMK.getJamDomAkhir() < pilihanR.getjamAkhir())
                batasanB = pilihanMK.getJamDomAkhir();
            else
                batasanB = pilihanR.getjamAkhir();

            batasanB = batasanB - pilihanMK.getSks();


            int count = batasanB - batasanA;
            for (int i = 0; i <= count; i++)
            {
                bool batasanAvail = true;
                int tes = batasanA;
                for(int j=0; j< pilihanMK.getSks(); j++)
                 {
                     foreach (MataKuliah MatKonflik in listMK)
                     {
                         if (MatKonflik.getRuanganSol() == pilihanRuanganAvail && DaytoInt(MatKonflik.getHariSol()) == pilihanHari && MatKonflik.getNamaMatKul()!=pilihanMatkul)
                         {
                             int JamKonflik = MatKonflik.getJamSol();
                             for (int k=0 ; k < MatKonflik.getSks(); k++)
                             {
                                 if (JamKonflik == tes)
                                     batasanAvail = false;
                                 JamKonflik++;
                             }
                         }
                     }
                     tes = tes + 1;
                 }
                if(batasanAvail)
                 {
                    if(batasanA>=10)
                     pilJam.Items.Add(batasanA);
                    else
                     pilJam.Items.Add(batasanA);
                }
                 batasanA = batasanA+1;
            }
           
        }

        public string DaytoInt(int day)
        {
          return tabel.Columns[day - 1].HeaderCell.Value.ToString();
        }

        public int InttoDay(string day)
        {
            if (day == "Senin")
                return 1;
            if (day == "Selasa")
                return 2;
            if (day == "Rabu")
                return 3;
            if (day == "Kamis")
                return 4;
            if (day == "Jumat")
                return 5;
            else return 0;
        }

        private void tabel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void initColor ()
        {
            Color [] listCol = { Color.Black , Color.Blue ,Color.Green,Color.Orange,Color.Yellow,Color.Aqua,Color.Olive,
                                 Color.DarkMagenta,Color.DarkSlateGray,Color.SteelBlue,Color.Navy,Color.Lime,Color.SeaGreen,Color.Chocolate,
                                 Color.SaddleBrown,Color.SkyBlue,Color.SpringGreen,Color.YellowGreen,Color.Turquoise};
            listC = listCol;
        }

        //Atribut
        public List<MataKuliah> listMK;
        public List<Ruangan> listR;
        public Color[] listC;
        public string pilihanRuangan ;
        public string pilihanMatkul;
        public string pilihanRuanganAvail;
        public string pilihanHari;
        public int pilihanJam;

    }
}
