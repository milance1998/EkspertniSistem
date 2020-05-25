using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EkspertniSistem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            if (rbDa.Checked == true)
            {
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();

            }
            else if (rbNe.Checked == true)
            {//////////////////////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Form6 f6 = new Form6();
                this.Hide();
                f6.Show();

            }
        }
    }
}
