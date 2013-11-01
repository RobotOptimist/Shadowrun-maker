using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShadowrunCharacterMaker
{
    public partial class ShadowrunCharacterMaker : Form
    {
        public ShadowrunCharacterMaker()
        {
            InitializeComponent();
        }

        private void ShadowrunCharacterMaker_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 creater = new Form3();
            creater.ShowDialog();
            ShadowrunCharacterMaker launcher = new ShadowrunCharacterMaker();
            launcher.Dispose();
            launcher.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object charID;
            ConnectShadowrun connShad = new ConnectShadowrun();
            charID = connShad.FindCharacterName(textBox1.Text);
            if (charID != null)
            {
                Form1 load = new Form1((int)charID);
                load.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Character Does Not Exist");
            }
        }
    }
}
