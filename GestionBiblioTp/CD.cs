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
using System.Data.SqlClient;

namespace GestionBibiotheque
{
    public partial class CD : Form
    {
        MySqlConnection connection;
        private DataTable dataTable;
        private String id;
        public CD()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            remplirdatagridview();
        }


        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "")
            {
                connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =;");
                connection.Open();
                MySqlCommand commande = new MySqlCommand("insert into bibliotheque.cd(titre,auteur,date) values(@a,@b,@c);", connection);
                commande.Parameters.AddWithValue("@a", textBox1.Text);
                commande.Parameters.AddWithValue("@b", textBox2.Text);
                commande.Parameters.AddWithValue("@c", dateTimePicker1.Text);
                commande.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Text = "";
                connection.Close();
                remplirdatagridview();
                MessageBox.Show("Enregistrement bien ajouté!", "Ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Veuillez vérifier les informations !", "Saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void remplirdatagridview()
        {
            connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =;");
            connection.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from bibliotheque.cd;",connection);
            dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "")
            {
                connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =;");
                connection.Open();
                MySqlCommand commande = new MySqlCommand("update bibliotheque.cd set titre=@a,auteur=@b,date=@c where id=@d;", connection);
                commande.Parameters.AddWithValue("@a", textBox1.Text);
                commande.Parameters.AddWithValue("@b", textBox2.Text);
                commande.Parameters.AddWithValue("@c", dateTimePicker1.Text);
                commande.Parameters.AddWithValue("@d", id);
                commande.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Text = "";
                connection.Close();
                remplirdatagridview();
                MessageBox.Show("Enregistrement bien modifié!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Veuillez vérifier les informations !", "Saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex]; 
               id = dataGridView1.SelectedCells[0].Value.ToString();
               textBox1.Text = selectedRow.Cells[1].Value.ToString();
               textBox2.Text = selectedRow.Cells[2].Value.ToString();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "")
            {
                connection = new MySqlConnection("datasource = localhost; port = 3306; username = root; password =;");
                connection.Open();
                MySqlCommand commande = new MySqlCommand("delete  from bibliotheque.cd where id=@d;", connection);
                commande.Parameters.AddWithValue("@d", id);
                commande.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Text = "";
                connection.Close();
                remplirdatagridview();
                MessageBox.Show("Enregistrement bien supprimé!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Veuillez clicker sur un enregistrement !", "suppression", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            livre a = new livre();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            periodique a = new periodique();
            a.Show();
        }
    }
}
