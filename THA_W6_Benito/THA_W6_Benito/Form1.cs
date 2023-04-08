using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Benito
{
    public partial class Form1 : Form
    {
        static public int userinput;
        public Form1()
        {
            InitializeComponent();
        }

        private void playbutton_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if (isNumeric)
            {
                userinput = Convert.ToInt32(textBox1.Text);
                if (userinput <= 3)
                {
                    MessageBox.Show("Input a number more than 3 ! ");
                }
                else
                {

                    Form2 worldy = new Form2();
                    worldy.Show();
                }
            }
            else
            {
                MessageBox.Show("Input should be an Integer !");
            }
       
          
        }
    }
}
