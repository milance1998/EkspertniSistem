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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnDalje_Click(object sender, EventArgs e)
        {
            if(rbPovredjen.Checked == true)
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
               
            }
            else if(rbNePovredjen.Checked == true)
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
               
            }
        }
    }
}
