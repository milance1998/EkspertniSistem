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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnSnimiOcene_Click(object sender, EventArgs e)
        {
            int a = 1, b = 2, c = 3;
            int rez = 0;

            //Pisanje sql naredbe
            string sqlQuery =
"UPDATE Rezultat SET [OcenaCucanj] = @ocenacucanj, [OcenaIskorak] = @ocenaiskorak, [OcenaPregibanjeNoge] = @ocenapregibanjenoge, [OcenaPrepona] = @ocenaprepona, [OcenaRamena] = @ocenaramena, [OcenaRotacijaTrupa] = @ocenarotacijatrupa, [OcenaSklek] = @ocenasklek, [UkupanRezultat] = @ukupanrezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            //Uspostavljanje konekcije sa bazom
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\milan\Documents\motorikatela.accdb"))

            //Zadavanje sql naredbe i konekcije
            using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
            {
                //Otvaramo konekciju
                conn.Open();

                //************cucanj
                if (cucanj1.Checked == true)
                {
                    cucanj1.BackColor = Color.Crimson;
                    cmd.Parameters.AddWithValue("@ocenacucanj", a);
                    rez += a;

                }
                else if (cucanj2.Checked == true)
                {

                    cmd.Parameters.AddWithValue("@ocenacucanj", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenacucanj", c);
                    rez += c;
                }

                //************iskorak
                if (iskorak.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaiskorak", a);
                    rez += a;

                }
                else if (iskorak2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaiskorak", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenaiskorak", c);
                    rez += c;
                }
                //***********pregibanje
                if (pregibanje.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenapregibanjenoge", a);
                    rez += a;

                }
                else if (pregibanje2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenapregibanjenoge", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenapregibanjenoge", c);
                    rez += c;

                }
                //*********prepona
                if (prepona1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaprepona", a);
                    rez += a;

                }
                else if (prepona2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaprepona", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenaprepona", c);
                    rez += c;

                }
                //**************rame
                if (rame1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaramena", a);
                    rez += a;

                }
                else if (rame2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenaramena", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenaramena", c);
                    rez += c;
                }
                //**************trup
                if (trup1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenarotacijatrupa", a);
                    rez += a;

                }
                else if (trup2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenarotacijatrupa", b);
                    rez += b;


                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenarotacijatrupa", c);
                    rez += c;
                }
                //**************sklek
                if (sklek1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenasklek", a);
                    rez += a;

                }
                else if (sklek2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@ocenasklek", b);
                    rez += b;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ocenasklek", c);
                    rez += c;
                }

                cmd.Parameters.AddWithValue("@ukupanrezultat", rez);

                MessageBox.Show("Podaci sportiste su uspešno uneti.", "Obaveštenje");



                //Izvrsava komandu od koje ne ocekujemo da kao povratne vrednosti daje podatke
                cmd.ExecuteNonQuery();

                //Izvrseni zahtevi i naredbe, zatvaramo konekciju
                conn.Close();
                FormaRezultat fr = new FormaRezultat();
                this.Hide();
                fr.Show();

            }

           
        }

        private void cucanj1_CheckedChanged(object sender, EventArgs e)
        {
            if (cucanj1.Checked == true)
            {
                cucanj2.BackColor = Color.FromKnownColor(KnownColor.Control);
                cucanj1.BackColor = Color.IndianRed;
                cucanj3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void cucanj2_CheckedChanged(object sender, EventArgs e)
        {
            if (cucanj2.Checked == true)
            {
                cucanj1.BackColor = Color.FromKnownColor(KnownColor.Control);
                cucanj2.BackColor = Color.Orange;
                cucanj3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void cucanj3_CheckedChanged(object sender, EventArgs e)
        {
            if (cucanj3.Checked == true)
            {
                cucanj1.BackColor = Color.FromKnownColor(KnownColor.Control);
                cucanj2.BackColor = Color.FromKnownColor(KnownColor.Control);
                cucanj3.BackColor = Color.LightGreen;
            }
        }

        private void iskorak_CheckedChanged(object sender, EventArgs e)
        {
            if (iskorak.Checked == true)
            {
                iskorak2.BackColor = Color.FromKnownColor(KnownColor.Control);
                iskorak.BackColor = Color.IndianRed;
                iskorak3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void iskorak2_CheckedChanged(object sender, EventArgs e)
        {
            if (iskorak2.Checked == true)
            {
                iskorak.BackColor = Color.FromKnownColor(KnownColor.Control);
                iskorak2.BackColor = Color.Orange;
                iskorak3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void iskorak3_CheckedChanged(object sender, EventArgs e)
        {
            if (iskorak3.Checked == true)
            {
                iskorak.BackColor = Color.FromKnownColor(KnownColor.Control);
                iskorak2.BackColor = Color.FromKnownColor(KnownColor.Control);
                iskorak3.BackColor = Color.LightGreen;
            }
        }

        private void pregibanje_CheckedChanged(object sender, EventArgs e)
        {
            if (pregibanje.Checked == true)
            {
                pregibanje2.BackColor = Color.FromKnownColor(KnownColor.Control);
                pregibanje.BackColor = Color.IndianRed;
                pregibanje3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void pregibanje2_CheckedChanged(object sender, EventArgs e)
        {
            if (pregibanje2.Checked == true)
            {
                pregibanje.BackColor = Color.FromKnownColor(KnownColor.Control);
                pregibanje2.BackColor = Color.Orange;
                pregibanje3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void pregibanje3_CheckedChanged(object sender, EventArgs e)
        {
            if (pregibanje3.Checked == true)
            {
                pregibanje.BackColor = Color.FromKnownColor(KnownColor.Control);
                pregibanje2.BackColor = Color.FromKnownColor(KnownColor.Control);
                pregibanje3.BackColor = Color.LightGreen;
            }
        }

        private void prepona1_CheckedChanged(object sender, EventArgs e)
        {
            if (prepona1.Checked == true)
            {
                prepona2.BackColor = Color.FromKnownColor(KnownColor.Control);
                prepona1.BackColor = Color.IndianRed;
                prepona3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void prepona2_CheckedChanged(object sender, EventArgs e)
        {
            if (prepona2.Checked == true)
            {
                prepona1.BackColor = Color.FromKnownColor(KnownColor.Control);
                prepona2.BackColor = Color.Orange;
                prepona3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void prepona3_CheckedChanged(object sender, EventArgs e)
        {
            if (prepona3.Checked == true)
            {
                prepona1.BackColor = Color.FromKnownColor(KnownColor.Control);
                prepona2.BackColor = Color.FromKnownColor(KnownColor.Control);
                prepona3.BackColor = Color.LightGreen;
            }
        }

        private void rame1_CheckedChanged(object sender, EventArgs e)
        {
            if (rame1.Checked == true)
            {
                rame2.BackColor = Color.FromKnownColor(KnownColor.Control);
                rame1.BackColor = Color.IndianRed;
                rame3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void rame2_CheckedChanged(object sender, EventArgs e)
        {
            if (rame2.Checked == true)
            {
                rame1.BackColor = Color.FromKnownColor(KnownColor.Control);
                rame2.BackColor = Color.Orange;
                rame3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void rame3_CheckedChanged(object sender, EventArgs e)
        {
            if (rame3.Checked == true)
            {
                rame1.BackColor = Color.FromKnownColor(KnownColor.Control);
                rame2.BackColor = Color.FromKnownColor(KnownColor.Control);
                rame3.BackColor = Color.LightGreen;
            }
        }

        private void trup1_CheckedChanged(object sender, EventArgs e)
        {
            if (trup1.Checked == true)
            {
                trup2.BackColor = Color.FromKnownColor(KnownColor.Control);
                trup1.BackColor = Color.IndianRed;
                trup3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void trup2_CheckedChanged(object sender, EventArgs e)
        {
            if (trup2.Checked == true)
            {
                trup1.BackColor = Color.FromKnownColor(KnownColor.Control);
                trup2.BackColor = Color.Orange;
                trup3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void trup3_CheckedChanged(object sender, EventArgs e)
        {
            if (trup3.Checked == true)
            {
                trup1.BackColor = Color.FromKnownColor(KnownColor.Control);
                trup2.BackColor = Color.FromKnownColor(KnownColor.Control);
                trup3.BackColor = Color.LightGreen;
            }
        }

        private void sklek1_CheckedChanged(object sender, EventArgs e)
        {
            if (sklek1.Checked == true)
            {
                sklek2.BackColor = Color.FromKnownColor(KnownColor.Control);
                sklek1.BackColor = Color.IndianRed;
                sklek3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void sklek2_CheckedChanged(object sender, EventArgs e)
        {
            if (sklek2.Checked == true)
            {
                sklek1.BackColor = Color.FromKnownColor(KnownColor.Control);
                sklek2.BackColor = Color.Orange;
                sklek3.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
        }

        private void sklek3_CheckedChanged(object sender, EventArgs e)
        {
            if (sklek3.Checked == true)
            {
                sklek1.BackColor = Color.FromKnownColor(KnownColor.Control);
                sklek2.BackColor = Color.FromKnownColor(KnownColor.Control);
                sklek3.BackColor = Color.LightGreen;
            }
        }
    }
}
