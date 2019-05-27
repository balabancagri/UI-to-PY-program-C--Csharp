using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui_to_py_program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            donustur.Enabled = false;
            richTextBox1.Text = "Lütfet UI dosyanızı Seçininiz\nLütfen Dosyanızı seçmeden önce PY dosyanızın adını belirleyiniz";
            
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
        }

        string dosyaadi;
        string dosyayolu;
        string yeniad;
        string[] yol;
        string yeniyol = "";
        string cmdkomutu;
        string dosya;
        
        private void dosya_sec_Click(object sender, EventArgs e)
        {
        
            OpenFileDialog dosya = new OpenFileDialog();
            
            dosya.Filter = "Ui Dosyası |*.ui";
            dosya.RestoreDirectory = true;
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                
                dosyaadi = dosya.SafeFileName;
                dosyayolu = dosya.FileName;
            }
            if ((dosyaadi == "" || dosyaadi == null) || (dosyayolu == "" || dosyayolu == null))
            {
                MessageBox.Show("Dosya Seçmediniz\nLütfen Dosyanızı Tekrar Seçiniz");
                              

            }
            else
            {
                                               
                yeniad = textBox1.Text;
                if (yeniad == "")
                {
                    MessageBox.Show("Çıkarılacak Dosya Adını belirleyiniz Ve Dosyanızı Baştan Seçiniz");
                    
                }
                else
                {
                    yeniyol = "";
                    yol = dosyayolu.Split('\\');
                    Array.Resize(ref yol, yol.Length - 1);

                    for (int i = 0; i < yol.Length; i++)
                    {
                        yeniyol += yol[i].ToString() + "/";
                    }
                    richTextBox1.Text = "Dosya Adı:" + dosyaadi + "\n" + "Dosya Yolu:" + yeniyol + "\n" + "Çıkacak Dosya Adı:" + yeniad;

                    donustur.Enabled = true;
                }
            }
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void donustur_Click(object sender, EventArgs e)
        {
            if ((yeniyol == "" || yeniyol == null) || (yeniad == "" || yeniad == null))
            {
                
                MessageBox.Show("Dosya Seçilmedi" +"\n"+ "Lütfen Dosyayı Seçip Tekrar Deneyiniz");
                return;

             }
            else
            {
                cmdkomutu = "/C pyuic5 " + dosyaadi + " -o " + yeniad + ".py";
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                System.Environment.CurrentDirectory = @yeniyol;
                System.Diagnostics.Process.Start("cmd.exe", cmdkomutu);
                System.Diagnostics.Process.Start(@yeniyol);
                donustur.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
