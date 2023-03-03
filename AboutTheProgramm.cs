using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Блокнотик
{
    public partial class AboutTheProgramm : Form
    {
        public AboutTheProgramm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AboutTheProgramm_Load(object sender, EventArgs e)
        {
            buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
