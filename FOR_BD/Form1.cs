using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace FOR_BD
{
    public partial class Enter : Form
    {
        
        public Enter()
        {      
            InitializeComponent();
        }

        private void auth1_Click(object sender, EventArgs e)
        {
            MySqlConnection con=null;
            try
            {
                string ConnectionString =
                                        "server=localhost;userid="+
                                         nickname.Text+";password="+password.Text+
                                        ";database=caseprocess;port=8889;";
                con = new MySqlConnection(ConnectionString);
                con.Open();           
            }
            catch (Exception ex)
            {
                MessageBox.Show("В доступе отказано.");
                return;
            }
            //q(qb9@R79lw5k-L!
            if (nickname.Text!="admin") { Inter2 workerinter = new Inter2(con,nickname.Text); this.Visible = false; workerinter.ShowDialog(); this.Visible = true; con.Close(); return; }
          Inter  inter1 = new Inter(con);
            this.Visible = false;
            inter1.ShowDialog();
            this.Visible = true;
            con.Close();
        }

        private void EnGuest_Click(object sender, EventArgs e)
        {
            MySqlConnection con = null;
            string ConnectionString =
                                        "server=localhost;userid=" +
                                         "Сидоров Максим" + ";password=" + "Chuvyrla312" +
                                        ";database=caseprocess;port=8889;";
            con = new MySqlConnection(ConnectionString);
            con.Open();
            Inter2 workerinter = new Inter2(con, "Сидоров Максим"); 
            this.Visible = false; 
            workerinter.ShowDialog(); 
            this.Visible = true; 
            con.Close();
        }
    }
}
