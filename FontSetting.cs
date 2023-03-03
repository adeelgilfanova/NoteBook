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
    public partial class FontSetting : Form
    {
        public int fontSize = 0;
        public System.Drawing.FontStyle fs=FontStyle.Regular;
        public FontSetting()
        {
            InitializeComponent();
            fontBox.SelectedItem = fontBox.Items[0];
            styleBox.SelectedItem = styleBox.Items[0];
        }


        public void fontBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExampleText.Font = new Font(ExampleText.Font.FontFamily,int.Parse(fontBox.SelectedItem.ToString()),ExampleText.Font.Style);
            fontSize = int.Parse(fontBox.SelectedItem.ToString());
        }

        public void styleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (styleBox.SelectedItem.ToString())
            {
                case "обычный":
                    ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Regular);
                    break;
                case "курсив":
                    ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Italic);
                    break;
                case "полужирный":
                    ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), FontStyle.Bold);
                    break;

            }
            fs = ExampleText.Font.Style;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FontSetting_Load(object sender, EventArgs e)
        {

        }
    }
}
