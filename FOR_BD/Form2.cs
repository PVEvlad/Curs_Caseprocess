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
    public partial class Inter : Form
    {
        private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        MySqlConnection con;

        Point Place_Reestr, Place_Persons;
        public Inter(MySqlConnection con1)
        {
            con = con1;
            InitializeComponent();            
        }

        private void Inter_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Place_Reestr.X = reestr.Location.X;
            Place_Persons.X = persons.Location.X;
            Place_Reestr.Y = Place_Persons.Y = this.Height - 100;
            reestr.Location = Place_Reestr;
            persons.Location = Place_Persons;
            bdel.Location =new Point(bdel.Location.X, this.Height - 100);
            Tables.Size = new Size(this.Width,this.Height-140);
            NewAccess.Location =new Point(NewAccess.Location.X, Place_Reestr.Y) ;
            string zapr = "SHOW TABLES";
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader[0].ToString());
            reader.Close();
        }

        private void reestr_Click(object sender, EventArgs e)
        {
            if (persons.Text == "Назад")
            {
                Registr registr1 = new Registr(con);
                registr1.ShowDialog();
                bdel.Visible = false;
                persons.Text = "Пользователи";
                persons_Click(sender, e);
                return;
            }
            listBox1.Visible = true;
            Tables.Visible = false;
            bdel.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zaproc= "SELECT * FROM "+ listBox1.SelectedItem.ToString();
            DataTable table = new DataTable();
            mydtadp.SelectCommand = new MySqlCommand(zaproc, con);
            mydtadp.Fill(table);
            bindingSource1.DataSource = table;
            Tables.DataSource = bindingSource1;
            Tables.Visible = true;
            listBox1.Visible = false;
            bdel.Visible = true;
            MySqlCommandBuilder cmbl = new MySqlCommandBuilder(mydtadp);
            NewAccess.Visible = true;
            NewAccess.Text = "Перезаписать";
        }

        private void NewAccess_Click(object sender, EventArgs e)
        {
            
            if (NewAccess.Text == "Перезаписать") 
            {
                try
                {
                    mydtadp.Update((DataTable)bindingSource1.DataSource);                                     
                    MessageBox.Show("Update successful");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                return;
            }
            AddAcc AddAcc1 = new AddAcc(con);
            AddAcc1.ShowDialog();
            return;
        }

        private void bdel_Click(object sender, EventArgs e)
        {
            try 
            {
                if (persons.Text == "Назад") 
                {
                    string sql = "DELETE FROM mysql.`user` WHERE `user`.`Host` = '%' AND `user`.`User` = '" + Tables.CurrentCell.Value.ToString()+"'";
                    MySqlCommand comand = new MySqlCommand(sql, con);
                    // MessageBox.Show(sql);
                    persons.Text = "Пользователи";
                    persons_Click(sender, e);
                    comand.ExecuteNonQuery();
                    return;
                }
                this.Tables.Rows.Remove(this.Tables.CurrentRow);
                mydtadp.Update((DataTable)bindingSource1.DataSource);
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void persons_Click(object sender, EventArgs e)
        {
            if (persons.Text == "Назад") 
            { Tables.Visible = false; persons.Text = "Пользователи";this.Size=new Size(330,330);
                reestr.Text = "Реестр";
                NewAccess.Visible = false;
                bdel.Visible = false;
                return; }
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();
            persons.Text = "Назад";
            reestr.Text = "Добавить";
            string zaproc = "SELECT User FROM mysql.user;";//SELECT User, Host FROM mysql.user;
            da.SelectCommand = new MySqlCommand(zaproc, con);
            da.Fill(ds);
            Tables.DataSource = ds.Tables[0];
            Tables.Visible = true;
            NewAccess.Visible = true;
            listBox1.Visible = false;
            NewAccess.Text = "Открыть доступ";
            bdel.Visible = true;
            DataTable table = new DataTable();
            mydtadp.SelectCommand = new MySqlCommand(zaproc, con);
            mydtadp.Fill(table);
            bindingSource1.DataSource = table;
            Tables.DataSource = bindingSource1;
        }

    }
}
