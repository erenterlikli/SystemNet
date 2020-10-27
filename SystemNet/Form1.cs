using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //IP işlemlerinde kullanılan bir kütüphane. 

namespace SystemNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text =  Dns.GetHostName(); //Bilgisayarın adı.
            foreach (IPAddress adres in Dns.GetHostAddresses(Dns.GetHostName()))  //IP Adresini arıyor.
            {
                label4.Text = adres.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry siteadi = Dns.GetHostEntry(textBox1.Text); //girilen web sitesinin adresini getir.
                IPAddress[] ip = siteadi.AddressList; //adresi bellekte tut.
                label7.Text = ip[0].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = textBox1.Text.ToString();
                ekle.SubItems.Add(label7.Text.ToString());


                listView1.Items.Add(ekle);
                label7.Text = " ";
                textBox1.Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Böyle bir siteye erişilemedi ya da site mevcut değil!");
                textBox1.Clear();
            }
            
        }
    }
}
