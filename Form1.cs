using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Блокнотик
{
    public partial class Form1 : Form
    {
        public int fontSize = 0;
        public System.Drawing.FontStyle fs = FontStyle.Regular;
        public string filename;
        public bool isFileChanged;
        public FontSetting fontSetts;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            filename = "";
            isFileChanged = false;

        }
        public void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            textBox1.Text = "";
            filename = "";
            
        }
        public void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;

                }
                catch
                {
                    MessageBox.Show("Не удалось открыть файл");
                }

            }
        }

        public void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename+  ".txt");
                sw.Write(textBox1.Text);
                sw.Close();
                filename = _filename;
                isFileChanged = false;
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл");
            }
        }
        public void сохранитьToolStripMenuItem_Click(object sender,EventArgs e)
        {
            SaveFile(filename);
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isFileChanged)
            {
                this.Text = this.Text.Replace('*', ' ');
                isFileChanged = true;
                this.Text = "*" + this.Text;
            }
        }
        public void SaveUnSavedFile()
        {
            if (isFileChanged)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Сохранения файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFile(filename);
                }
            }
        }

        public void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUnSavedFile();
        }
        public void CopyText()
        {
            Clipboard.SetText(textBox1.SelectedText);
        }
        public void CutText()
        {
            Clipboard.SetText(textBox1.SelectedText);
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, textBox1.SelectionLength);
        }
        public void PasteText()
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + Clipboard.GetText() + textBox1.Text.Substring(textBox1.SelectionStart, textBox1.Text.Length - textBox1.SelectionStart);
            Clipboard.GetText();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutText();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyText();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteText();
        }

        public void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fontSetts = new FontSetting();
            fontSetts.Show();

        }

        public void OnFocus(object sender, EventArgs e)
        {
            if (fontSetts != null)
            {
                fontSize = fontSetts.fontSize;
                fs = fontSetts.fs;
                textBox1.Font=new Font(textBox1.Font.FontFamily,fontSize, fs);
                fontSetts.Close();
            }
        }
    }
}
