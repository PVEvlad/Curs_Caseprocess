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
    public partial class AddAcc : Form
    {
        MySqlConnection con;
        TreeNode prednode=null, prednode1 = null;       
        public AddAcc(MySqlConnection con1)
        {
            con = con1;
            InitializeComponent();

            string zaproc = "Select User FROM mysql.user";
            MySqlCommand command = new MySqlCommand(zaproc, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                UsersTree.Nodes.Add(reader[0].ToString());

            reader.Close();

            zaproc = "SELECT ID_Дела FROM caseprocess.cases ORDER BY ID_Дела";
            command = new MySqlCommand(zaproc, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                CasesTree.Nodes.Add(reader[0].ToString());
            reader.Close();

            CasesTree.Select();
            UsersTree.Select();
        }

        private void yes_Click(object sender, EventArgs e)
        {            
            if (CasesTree.SelectedNode!= null && UsersTree.SelectedNode != null) 
            {
                string nameic = UsersTree.SelectedNode.Text;
                string SecondName = new string(nameic.TakeWhile(c => c != ' ').ToArray());
                string Name = nameic.Substring(nameic.IndexOf(' ')+1);
                string newcomm =
                                "INSERT INTO comm (Фамилия, Имя,Дело) Values(\""
                                 + SecondName + "\",\"" + Name + "\","
                                 + CasesTree.SelectedNode.Text + ");", 
                zaproc = "Select Фамилия, Имя, Дело FROM comm WHERE CONCAT(Фамилия,Имя)=\"" + SecondName+Name + 
                         "\" AND Дело=" + CasesTree.SelectedNode.Text + ";";
                MySqlCommand command = new MySqlCommand(zaproc, con);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) { reader.Close(); this.Close(); return; }
                reader.Close();
                command = new MySqlCommand(newcomm, con);
               // MessageBox.Show(newcomm);
                command.ExecuteNonQuery();
            }
            this.Close();
        }

        private void UsersTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UsersTree.SelectedNode.BackColor = Color.Red;
            if (prednode != null) prednode.BackColor = Color.White;
            prednode = UsersTree.SelectedNode;           
        }

        private void CasesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (CasesTree.SelectedNode != null) CasesTree.SelectedNode.BackColor = Color.Red;
            if (prednode1 != null) prednode1.BackColor = Color.White;
            prednode1 = CasesTree.SelectedNode;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
