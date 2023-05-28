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
    public partial class Registr : Form
    {
        MySqlConnection con;
        public Registr(MySqlConnection con1)
        {
            //CREATE USER 'Имя'@'%' IDENTIFIED WITH mysql_native_password AS '***';GRANT SELECT, INSERT ON `caseprocess`.* TO 'Имя'@'%';
            con = con1;
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //CREATE USER '" + name.Text + "'@'%' IDENTIFIED WITH mysql_native_password AS '" + password.Text + "';
        //GRANT SELECT, INSERT ON *.* TO '" + name.Text + "'@'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;
        //GRANT SELECT, INSERT ON `caseprocess`.* TO '" + name.Text + "'@'%';
        private void Create_Click(object sender, EventArgs e)
        {
            String newuser = "CREATE USER '" + name.Text + "'@'%' IDENTIFIED BY '" + password.Text + "';" +
                "GRANT SELECT, INSERT ON *.* TO '" + name.Text + "'@'%' REQUIRE NONE WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;" +
                "GRANT SELECT, INSERT ON `caseprocess`.* TO '" + name.Text + "'@'%';";
           /* String commandstring = "CREATE USER '" + name.Text +
                "'@'%' IDENTIFIED BY '" + password.Text +
                "';GRANT SELECT, INSERT ON `caseprocess`.* TO '" + name.Text + "'@'%';";*/
            try 
            {
                MySqlCommand comm = new MySqlCommand(newuser, con);
                comm.ExecuteNonQuery();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            this.Close();
        }
    }
}
