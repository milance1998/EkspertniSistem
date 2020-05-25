using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkspertniSistem
{
    public partial class FormaRezultat : Form
    {
        public FormaRezultat()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\milan\Documents\motorikatela.accdb";
        OleDbConnection dbConnect = new OleDbConnection();
        string ukupanRez,ocenaCucanj, ocenaRame, ocenaIskorak, ocenaPregibanje, ocenaSklek, ocenaTrup, ocenaPrepona;
        string tpovreda;
        

        private void info()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [Ime],[Prezime],[DatumRodjenja],[Visina],[Tezina] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                
                lbIme.Text = lbIme.Text + dbReader.GetValue(0).ToString();
                lbPrezime.Text =lbPrezime.Text + dbReader.GetValue(1).ToString();
                lbDatumR.Text =lbDatumR.Text + dbReader.GetValue(2).ToString();
                lbVisina.Text = lbVisina.Text +  dbReader.GetValue(3).ToString();
                lbTezina.Text = lbTezina.Text + dbReader.GetValue(4).ToString();
            }
            string datum = DateTime.Now.ToString("dd.MM.yyyy");
            lbDatumT.Text = lbDatumT.Text + datum;
            dbConnect.Close();
        }

        private void rezultat()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [UkupanRezultat] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ukupanRez = dbReader.GetValue(0).ToString();
                lbRezBr.Text = ukupanRez;
            }

            int rez = Convert.ToInt32(ukupanRez);
            if (rez >= 18)
            {
                pbRezultat.Image = pb3.Image;
                lbNapomena.Text = lbNapomena.Text + "Ukupan rezultat sportiste ukazuje na to da je sportista" +
                    " u odličnoj formi i ima minimalan rizik od povređivanja";
            }
            else if(rez<18 && rez >= 13) {
                pbRezultat.Image = pb2.Image;
                lbNapomena.Text = lbNapomena.Text + "Ukupan rezultat sportiste ukazuje na to da je sportista" +
                    " u ne tako dobroj formi i ima relativno povećan rizik od povređivanja";

            }
            else
            {
                pbRezultat.Image = pb1.Image;
                lbNapomena.Text = lbNapomena.Text + "Ukupan rezultat sportiste ukazuje na to da je sportista" +
                    " u lošoj formi i ima izraženo povećan rizik od povređivanja";
            }

            if(rez == 21)
            {
                lbrez.Text = "Preporučuje se nastavak dosadašnjeg rada istim intezitetom.";
            }
            dbConnect.Close();

        }


            private void cucanj()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaCucanj] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaCucanj = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaCucanj == "2")
            {
                string querryCucanj = "SELECT [OpisOceneCucanj] FROM CucanjSaUzrucenjem WHERE [CucanjSaUzrucenjem.IDOceneCucanj] IN (2)";
                dbConnect.Open();
                OleDbCommand cucanjcmd = new OleDbCommand(querryCucanj, dbConnect);
                OleDbDataReader cucanjReader = cucanjcmd.ExecuteReader();
                while (cucanjReader.Read())
                {
                    lbCucanj.Text = cucanjReader.GetValue(0).ToString();
                    
                }
                lbrez.Text = lbrez.Text + lbCucanj.Text + "\n";
                    pbCucanj.Image = pb2.Image;
            } else if (ocenaCucanj == "1")
            {
                string querryCucanj = "SELECT [OpisOceneCucanj] FROM CucanjSaUzrucenjem WHERE [CucanjSaUzrucenjem.IDOceneCucanj] IN (1)";
                dbConnect.Open();
                OleDbCommand cucanjcmd = new OleDbCommand(querryCucanj, dbConnect);
                OleDbDataReader cucanjReader = cucanjcmd.ExecuteReader();
                while (cucanjReader.Read())
                {
                    lbCucanj.Text = cucanjReader.GetValue(0).ToString();
                    
                }
                lbrez.Text = lbrez.Text + lbCucanj.Text + "\n";
                    pbCucanj.Image = pb1.Image;
            }else if(ocenaCucanj == "3")
            {
                pbCucanj.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }

        

        private void rame()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaRamena] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaRame = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaRame == "2")
            {
                string querryRamena = "SELECT [OpisOceneRamena] FROM Ramena WHERE [Ramena.IDOceneRamena] IN (2)";
                dbConnect.Open();
                OleDbCommand ramenacmd = new OleDbCommand(querryRamena, dbConnect);
                OleDbDataReader ramenaReader = ramenacmd.ExecuteReader();
                while (ramenaReader.Read())
                {
                    lbRamena.Text = ramenaReader.GetValue(0).ToString();
                    
                }pbRamena.Image = pb2.Image;
                    lbrez.Text = lbrez.Text + lbRamena.Text + "\n";
            } else if (ocenaRame== "1") 
            {
                string querryRamena = "SELECT [OpisOceneRamena] FROM Ramena WHERE [Ramena.IDOceneRamena] IN (1)";
                dbConnect.Open();
                OleDbCommand ramenacmd = new OleDbCommand(querryRamena, dbConnect);
                OleDbDataReader ramenaReader = ramenacmd.ExecuteReader();
                while (ramenaReader.Read())
                {
                    lbRamena.Text = ramenaReader.GetValue(0).ToString();
                    
                }pbRamena.Image = pb1.Image;
                    lbrez.Text = lbrez.Text + lbRamena.Text + "\n";
            }else if(ocenaRame == "3")
            {
                pbRamena.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }

       

        private void iskorak()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaIskorak] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaIskorak = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaIskorak == "2")
            {
                string querryIskorak = "SELECT [OpisOceneIskorak] FROM Iskorak WHERE [Iskorak.IDOceneIskorak] IN (2)";
                dbConnect.Open();
                OleDbCommand iskorakcmd = new OleDbCommand(querryIskorak, dbConnect);
                OleDbDataReader iskorakReader = iskorakcmd.ExecuteReader();
                while (iskorakReader.Read())
                {
                    lbIskorak.Text = iskorakReader.GetValue(0).ToString();
                }
                pbIskorak.Image = pb2.Image;
                lbrez.Text = lbrez.Text + lbIskorak.Text + "\n";
            }
            else if (ocenaIskorak == "1")
            {
                string querryIskorak = "SELECT [OpisOceneIskorak] FROM Iskorak WHERE [Iskorak.IDOceneIskorak] IN (1)";
                dbConnect.Open();
                OleDbCommand iskorakcmd = new OleDbCommand(querryIskorak, dbConnect);
                OleDbDataReader iskorakReader = iskorakcmd.ExecuteReader();
                while (iskorakReader.Read())
                {
                    lbIskorak.Text = iskorakReader.GetValue(0).ToString();
                }
                pbIskorak.Image = pb1.Image;
                lbrez.Text = lbrez.Text + lbIskorak.Text + "\n";
            }
            else if(ocenaIskorak == "3")
            {
                pbIskorak.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }

      /*  private void pregibanjeNoge()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaPregibanjeNoge] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaPregibanje = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaPregibanje == "2")
            {
                string querryPregibanjeNoge = "SELECT [OpisOcenePregibanjeNoge] FROM PregibanjeNoge WHERE [PregibanjeNoge.IDOcenePregibanjeNoge] IN (2)";
                dbConnect.Open();
                OleDbCommand pregibanjeNogecmd = new OleDbCommand(querryPregibanjeNoge, dbConnect);
                OleDbDataReader pregibanjeNogeReader = pregibanjeNogecmd.ExecuteReader();
                while (pregibanjeNogeReader.Read())
                {
                    lbPregibanje.Text = pregibanjeNogeReader.GetValue(0).ToString();
                }
            }
            else if (ocenaPregibanje == "1")
            {
                string querryPregibanjeNoge = "SELECT [OpisOcenePregibanjeNoge] FROM PregibanjeNoge WHERE [PregibanjeNoge.IDOcenePregibanjeNoge] IN (1)";
                dbConnect.Open();
                OleDbCommand pregibanjeNogecmd = new OleDbCommand(querryPregibanjeNoge, dbConnect);
                OleDbDataReader pregibanjeNogeReader = pregibanjeNogecmd.ExecuteReader();
                while (pregibanjeNogeReader.Read())
                {
                    lbPregibanje.Text = pregibanjeNogeReader.GetValue(0).ToString();
                }
            }
            lbrez.Text = lbrez.Text + lbPregibanje.Text + "\n";
            dbConnect.Close();
        }*/


        private void sklek()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaSklek] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaSklek = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaSklek == "2")
            {
                string querrySklek = "SELECT [OpisOceneSklek] FROM Sklek WHERE [Sklek.IDOceneSklek] IN (2)";
                dbConnect.Open();
                OleDbCommand Sklekcmd = new OleDbCommand(querrySklek, dbConnect);
                OleDbDataReader SklekReader = Sklekcmd.ExecuteReader();
                while (SklekReader.Read())
                {
                    lbSklek.Text = SklekReader.GetValue(0).ToString();
                }
                pbSklek.Image = pb2.Image;
                lbrez.Text = lbrez.Text + lbSklek.Text + "\n";
            }
            else if (ocenaSklek == "1")
            {
                string querrySklek = "SELECT [OpisOceneSklek] FROM Sklek WHERE [Sklek.IDOceneSklek] IN (1)";
                dbConnect.Open();
                OleDbCommand Sklekcmd = new OleDbCommand(querrySklek, dbConnect);
                OleDbDataReader SklekReader = Sklekcmd.ExecuteReader();
                while (SklekReader.Read())
                {
                    lbSklek.Text = SklekReader.GetValue(0).ToString();
                }
                pbSklek.Image = pb1.Image;
                lbrez.Text = lbrez.Text + lbSklek.Text + "\n";
            }
            else if(ocenaSklek == "3")
            {
                pbSklek.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }

        private void FormaRezultat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void pregibanje()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaPregibanjeNoge] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaPregibanje = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaPregibanje == "2")
            {
                string querrypregibanje = "SELECT [OpisOcenePregibanje] FROM Pregibanje WHERE [Pregibanje.IDOcenePregibanje] IN (2)";
                dbConnect.Open();
                OleDbCommand pregibanjecmd = new OleDbCommand(querrypregibanje, dbConnect);
                OleDbDataReader pregibanjeReader = pregibanjecmd.ExecuteReader();
                while (pregibanjeReader.Read())
                {
                    lbPregibanje.Text = pregibanjeReader.GetValue(0).ToString();
                }
                pbPregibanje.Image = pb2.Image;
                lbrez.Text = lbrez.Text + lbPregibanje.Text + "\n";
            }
            else if (ocenaPregibanje == "1")
            {
                string querrypregibanje = "SELECT [OpisOcenePregibanje] FROM Pregibanje WHERE [Pregibanje.IDOcenePregibanje] IN (1)";
                dbConnect.Open();
                OleDbCommand pregibanjecmd = new OleDbCommand(querrypregibanje, dbConnect);
                OleDbDataReader pregibanjeReader = pregibanjecmd.ExecuteReader();
                while (pregibanjeReader.Read())
                {
                    lbPregibanje.Text = pregibanjeReader.GetValue(0).ToString();
                }
                pbPregibanje.Image = pb1.Image;
                lbrez.Text = lbrez.Text + lbPregibanje.Text + "\n";
            }
            else if(ocenaPregibanje == "3")
            {
                pbPregibanje.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }


        private void trup()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaRotacijaTrupa] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaTrup = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaTrup == "2")
            {
                string querrytrup = "SELECT [OpisOceneRotacijaTrupa] FROM RotacijaTrupa WHERE [RotacijaTrupa.IDOceneRotacijaTrupa] IN (2)";
                dbConnect.Open();
                OleDbCommand trupcmd = new OleDbCommand(querrytrup, dbConnect);
                OleDbDataReader trupReader = trupcmd.ExecuteReader();
                while (trupReader.Read())
                {
                    lbTrup.Text = trupReader.GetValue(0).ToString();
                }
                pbTrup.Image = pb2.Image;
                lbrez.Text = lbrez.Text + lbTrup.Text + "\n";
            }
            else if (ocenaTrup == "1")
            {
                string querrytrup = "SELECT [OpisOceneRotacijaTrupa] FROM RotacijaTrupa WHERE [RotacijaTrupa.IDOceneRotacijaTrupa] IN (1)";
                dbConnect.Open();
                OleDbCommand trupcmd = new OleDbCommand(querrytrup, dbConnect);
                OleDbDataReader trupReader = trupcmd.ExecuteReader();
                while (trupReader.Read())
                {
                    lbTrup.Text = trupReader.GetValue(0).ToString();
                }
                pbTrup.Image = pb1.Image;
                lbrez.Text = lbrez.Text + lbTrup.Text + "\n";
            }
            else if(ocenaTrup == "3")
            {
                pbTrup.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }


        private void prepona()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [OcenaPrepona] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                ocenaPrepona = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (ocenaPrepona == "2")
            {
                string querryPrepona = "SELECT [OpisOcenePrepona] FROM Prepona WHERE [Prepona.IDOcenePrepona] IN (2)";
                dbConnect.Open();
                OleDbCommand Preponacmd = new OleDbCommand(querryPrepona, dbConnect);
                OleDbDataReader PreponaReader = Preponacmd.ExecuteReader();
                while (PreponaReader.Read())
                {
                    lbPrepona.Text = PreponaReader.GetValue(0).ToString();
                }
                pbPrepona.Image = pb2.Image;
                lbrez.Text = lbrez.Text + lbPrepona.Text + "\n";
            }
            else if (ocenaPrepona == "1")
            {
                string querryPrepona = "SELECT [OpisOcenePrepona] FROM Prepona WHERE [Prepona.IDOcenePrepona] IN (1)";
                dbConnect.Open();
                OleDbCommand Preponacmd = new OleDbCommand(querryPrepona, dbConnect);
                OleDbDataReader PreponaReader = Preponacmd.ExecuteReader();
                while (PreponaReader.Read())
                {
                    lbPrepona.Text = PreponaReader.GetValue(0).ToString();
                }
                pbPrepona.Image = pb1.Image;
                lbrez.Text = lbrez.Text + lbPrepona.Text + "\n";
            }
            else if(ocenaPrepona == "3")
            {
                pbPrepona.Image = pb3.Image;
            }
            
            dbConnect.Close();
        }


        

        private void povredjen()
        {
            dbConnect.ConnectionString = conn;
            string mySelect2 = "SELECT OcenaCucanj, OcenaIskorak, OcenaPregibanjeNoge, OcenaPrepona, OcenaRamena, OcenaRotacijaTrupa, OcenaSklek FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";
            dbConnect.Open();
            OleDbCommand cmd = new OleDbCommand(mySelect2, dbConnect);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ocenaCucanj = reader.GetValue(0).ToString();
                ocenaIskorak = reader.GetValue(1).ToString();
                ocenaPregibanje = reader.GetValue(2).ToString();
                ocenaPrepona = reader.GetValue(3).ToString();
                ocenaRame = reader.GetValue(4).ToString();
                ocenaTrup = reader.GetValue(5).ToString();
                ocenaSklek = reader.GetValue(6).ToString();
            }
            dbConnect.Close();

            int tkoleno = Int32.Parse(ocenaCucanj) + Int32.Parse(ocenaPrepona);
            int trame = Int32.Parse(ocenaRame) + Int32.Parse(ocenaSklek);
            int tkukikarlica = int.Parse(ocenaTrup) + Int32.Parse(ocenaCucanj);
            int tzglob = Int32.Parse(ocenaPrepona) + Int32.Parse(ocenaIskorak);
            int tloza= Int32.Parse(ocenaPregibanje);
            int tkicma = Int32.Parse(ocenaCucanj) + Int32.Parse(ocenaSklek);

            
            string mySelect = "SELECT [Povredjen] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                tpovreda = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (tpovreda == "1")
            {
                if (tloza == 1)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }else if(tloza >= 2)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (1)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }

            }else if(tpovreda == "2")
            {
                if (tkukikarlica < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkukikarlica >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (2)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "3")
            {
                if (tkoleno < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkoleno >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (3)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "4")
            {
                if (tzglob < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tzglob >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (4)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "5")
            {
                if (tkicma < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkicma >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (5)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "6")
            {
                if (trame < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (trame >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovrede] FROM TBPovredjen WHERE [TBPovredjen.IDPovrede] IN (6)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
        }

        private void povredjivan()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [Povredjivan] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";
            string mySelect2 = "SELECT OcenaCucanj, OcenaIskorak, OcenaPregibanjeNoge, OcenaPrepona, OcenaRamena, OcenaRotacijaTrupa, OcenaSklek FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";
            dbConnect.Open();
            OleDbCommand cmd = new OleDbCommand(mySelect2, dbConnect);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ocenaCucanj = reader.GetValue(0).ToString();
                ocenaIskorak = reader.GetValue(1).ToString();
                ocenaPregibanje = reader.GetValue(2).ToString();
                ocenaPrepona = reader.GetValue(3).ToString();
                ocenaRame = reader.GetValue(4).ToString();
                ocenaTrup = reader.GetValue(5).ToString();
                ocenaSklek = reader.GetValue(6).ToString();
            }
            dbConnect.Close();


            int tkoleno = Int32.Parse(ocenaCucanj) + Int32.Parse(ocenaPrepona);
            int trame = Int32.Parse(ocenaRame) + Int32.Parse(ocenaSklek);
            int tkukikarlica = int.Parse(ocenaTrup) + Int32.Parse(ocenaCucanj);
            int tzglob = Int32.Parse(ocenaPrepona) + Int32.Parse(ocenaIskorak);
            int tloza = Int32.Parse(ocenaPregibanje);
            int tkicma = Int32.Parse(ocenaCucanj) + Int32.Parse(ocenaSklek);

      
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                tpovreda = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();

            if (tpovreda == "1")
            {
                if (tloza == 1)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (7)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tloza >= 2)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (1)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }

            }
            else if (tpovreda == "2")
            {
                if (tkukikarlica < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (8)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkukikarlica >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (2)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "3")
            {
                if (tkoleno < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (9)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkoleno >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (3)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "4")
            {
                if (tzglob < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (10)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tzglob >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (4)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "5")
            {
                if (tkicma < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (11)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (tkicma >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (5)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
            else if (tpovreda == "6")
            {
                if (trame < 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (12)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
                else if (trame >= 4)
                {
                    dbConnect.ConnectionString = conn;
                    string qloza = "SELECT [OpisPovredjivan] FROM TBPovredjivan WHERE [TBPovredjivan.IDPovredjivan] IN (6)";

                    dbConnect.Open();
                    OleDbCommand lcmd = new OleDbCommand(qloza, dbConnect);

                    OleDbDataReader lReader = lcmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lbPovreda.Text = lReader.GetValue(0).ToString();
                    }
                    dbConnect.Close();
                }
            }
        }
        private void pozivanje()
        {
            dbConnect.ConnectionString = conn;
            string mySelect = "SELECT [Povredjivan] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";
            string povredjivan1="";
            string povredjen1="";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);

            OleDbDataReader dbReader = dbCmd.ExecuteReader();
            while (dbReader.Read())
            {
                povredjivan1 = dbReader.GetValue(0).ToString();
            }
            dbConnect.Close();
            dbConnect.Open();
            string mySelect1 = "SELECT [Povredjen] FROM Rezultat WHERE [Rezultat.IDKandidata] = (SELECT max([IDKandidata]) FROM Rezultat)";

            OleDbCommand dbCmd1 = new OleDbCommand(mySelect1, dbConnect);

            OleDbDataReader dbReader1 = dbCmd1.ExecuteReader();
            while (dbReader1.Read())
            {
                povredjen1 = dbReader1.GetValue(0).ToString();
            }
            dbConnect.Close();

            if(string.IsNullOrEmpty(povredjivan1)) 
            {
                povredjen();
            }
            if(string.IsNullOrEmpty(povredjen1))
            {
                povredjivan();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;

        private void btnStampaj_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
            btnStampaj.Visible = false;
        }

        private void FormaRezultat_Load(object sender, EventArgs e)
        {
            info();
            cucanj();
            iskorak();
            pregibanje();
            prepona();
            rame();
            trup();
            sklek();
            pozivanje();
            rezultat();
            
        }
            


        }
    }

