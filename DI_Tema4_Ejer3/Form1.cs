using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DI_Tema4_Ejer3
{
    public partial class Form1 : Form
    {
        string path = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = "Visor de Imagenes";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "JPG (.jpg) |*.jpg|PNG (.png)|*.png|Todo |*.*";
           
            oFD.ShowDialog();

            path = oFD.FileName;

            if (File.Exists(path))
            {
                try
                {
                    Image i = Image.FromFile(path);
                
                Form f2 = new Form();
                f2.BackgroundImage = i;
                f2.SetBounds(0,0,i.Width,i.Height);
                f2.BackgroundImageLayout = ImageLayout.Stretch;
                f2.Activate();
                FileInfo fi = new FileInfo(path);
                f2.Text =  fi.Name;
                if (checkBox1.Checked)
                {
                    f2.ShowDialog();
                }
                else
                {
                    f2.Show();
                }
                }
                catch(OutOfMemoryException err)
                {
                    MessageBox.Show("Archivo Corrupto", "Pues eso, archivo corrupto", MessageBoxButtons.OK);
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show("Eso no es una imagen", "Pues eso, no es una imagen", MessageBoxButtons.OK);
                }


            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           if( MessageBox.Show("Te piras?", "De que vas pavo?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            
        }
    }
}
