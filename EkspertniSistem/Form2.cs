using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EkspertniSistem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            int a = 1, b = 2, c = 3, d = 4, ee = 5, f = 6;
            //Pisanje sql naredbe
            string sqlQuery = "UPDATE Rezultat SET Povredjen = @povredjen  WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            //Uspostavljanje konekcije sa bazom
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\milan\Documents\motorikatela.accdb"))

            //Zadavanje sql naredbe i konekcije
            using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
            {
                //Otvaramo konekciju   
                conn.Open();
                if (comboPovreda.Text == "Povreda zadnje lože")
                {
                    cmd.Parameters.AddWithValue("@povredjen", a);

                }
                else if (comboPovreda.Text == "Povreda kuka i karlice")
                {
                    cmd.Parameters.AddWithValue("@povredjen", b);

                }
                else if (comboPovreda.Text == "Povreda kolena")
                {
                    cmd.Parameters.AddWithValue("@povredjen", c);

                }
                else if (comboPovreda.Text == "Povreda skočnog zgloba")
                {
                    cmd.Parameters.AddWithValue("@povredjen", d);

                }
                else if (comboPovreda.Text == "Povreda kičmenog dela")
                {
                    cmd.Parameters.AddWithValue("@povredjen", ee);

                }
                else if (comboPovreda.Text == "Povreda ramena")
                {
                    cmd.Parameters.AddWithValue("@povredjen", f);

                }
                else
                {
                    MessageBox.Show("Popunite sva polja!!!.", "Obaveštenje");
                }
                //Izvrsava komandu od koje ne ocekujemo da kao povratne vrednosti daje podatke
                cmd.ExecuteNonQuery();

                //Izvrseni zahtevi i naredbe, zatvaramo konekciju
                conn.Close();
                Form6 f6 = new Form6();
                this.Hide();
                f6.Show();
            }
        }
    }
}
