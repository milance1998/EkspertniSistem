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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //iskorak1.Checked = false;
        }

        private void clear()
        {
            tbIme.Text = "";
            tbPrezime.Text = "";
            tbVisina.Text = "";
            tbTezina.Text = "";
            mtbDatumRodjenja.Text = "";
            

        }

        private void snimi_Click(object sender, EventArgs e)
        {

            //Pisanje sql naredbe
            string sqlQuery = "INSERT INTO Rezultat (`Ime`,`Prezime`,`DatumRodjenja`,`Visina`,`Tezina`) " + "values (?,?,?,?,?)";

            //Uspostavljanje konekcije sa bazom
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\milan\Documents\motorikatela.accdb"))

            //Zadavanje sql naredbe i konekcije
            using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
            {
                //Otvaramo konekciju
                conn.Open();
                if (tbIme.Text != "" && tbPrezime.Text != "" && tbTezina.Text != "" && tbVisina.Text != "" && mtbDatumRodjenja.Text != "")
                {
                    cmd.Parameters.AddWithValue("@Ime", this.tbIme.Text);
                    cmd.Parameters.AddWithValue("@Prezime", this.tbPrezime.Text);
                    cmd.Parameters.AddWithValue("@DatumRodjenja", this.mtbDatumRodjenja.Text);
                    cmd.Parameters.AddWithValue("@Visina", this.tbVisina.Text);
                    cmd.Parameters.AddWithValue("@Tezina", this.tbTezina.Text);
                    MessageBox.Show("Podaci sportiste su uspešno uneti.", "Obaveštenje");
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                else { MessageBox.Show("Molimo Vas unesite sve podatke o sportisti.", "Obaveštenje"); }
                                                                                    
            }
            Form5 f5 = new Form5();

            this.Hide();
            f5.Show();
            clear();
            //button1.Visible = true;
        }

        private void tbDatumRodjenja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       



        private void tbVisina_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbTezina_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
    }
}
