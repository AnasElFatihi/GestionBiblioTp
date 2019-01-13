using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionBibiotheque
{
    public partial class Form1 : Form
    {
        MySqlConnection connection;
        public Form1()
        {
           
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "")
            {
                MessageBox.Show("Veuillez renseigner votre login !");
            }
            else 
                if (textBox2.Text == "")
            {
                MessageBox.Show("Veuillez renseigner votre mot de passe ! ");
            }
            else
                   if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =;");
                        try
                        {
                            connection.Open();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                      
                        MySqlCommand commande = new MySqlCommand("select * from bibliotheque.users where login=@a and motdepasse=@b",connection);
                        commande.Parameters.AddWithValue("@a", textBox1.Text);
                        commande.Parameters.AddWithValue("@b", textBox2.Text);

                        MySqlDataReader reader = commande.ExecuteReader();
                        
                            int cmp = 0;
                            while (reader.Read())
                                cmp++;
                            if (cmp == 1 )
                            {
                                
                               
                                CD a = new CD();
                                this.Hide();
                                a.Show();
                            }
                            else
                                MessageBox.Show("Veuillez vérifier vos informations de connexion !","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
           

        }
    }
}
