using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Projet_1_Mode_Deconnecte
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=Clients;Integrated Security=True");
       
        BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            //charger les donnee 
            SqlDataAdapter da = new SqlDataAdapter("select * from client", cnx);
            da.Fill(ds, "Liste_Clients");
            dt = ds.Tables["Liste_Clients"];
            bindingSource.DataSource = dt;

            //charger dataGridView et la mettere en relation avec BindingSource
            dataGridView1.DataSource = bindingSource;
           
           // relation entre les TextBox et bindingSource
            textBox1.DataBindings.Add("Text", bindingSource, "CIN");
            textBox2.DataBindings.Add("Text", bindingSource, "NOM");
            textBox3.DataBindings.Add("Text", bindingSource, "PRENOM");
            textBox4.DataBindings.Add("Text", bindingSource, "TEL");
            textBox5.DataBindings.Add("Text", bindingSource, "VILLE");
           
            bindingSource.MoveFirst();
            //Affichage d'ordre du client  chargé.
            label6.Text = bindingSource.Count + "/" + (bindingSource.Position + 1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            bindingSource.MoveFirst();
            label6.Text = bindingSource.Count + "/" + (bindingSource.Position + 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            bindingSource.MovePrevious();
            label6.Text = bindingSource.Count + "/" + (bindingSource.Position + 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            bindingSource.MoveNext();
            label6.Text = bindingSource.Count + "/" + (bindingSource.Position + 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindingSource.MoveLast();
            label6.Text = bindingSource.Count + "/" + (bindingSource.Position + 1);
           
        }

      
    }
}
