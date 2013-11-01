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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int charid;
            ConnectShadowrun connShad = new ConnectShadowrun();
            charid = connShad.InsertCharacterName(textBox1.Text, listBox1.Text);
            
            Form1 charUpdater = new Form1(charid);
            
            MessageBox.Show("Character created");
            charUpdater.ShowDialog();
            this.Hide();         
        }


    }
}
