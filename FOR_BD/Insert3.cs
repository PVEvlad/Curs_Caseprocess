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
    public partial class Insert3 : Form
    {
        private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        MySqlConnection con;
        string case_id;
        public Insert3(MySqlConnection con1, string CASE)
        {
            con = con1;
            case_id = CASE;
            InitializeComponent();
        }

        private void Insert3_Load(object sender, EventArgs e)
        {
            string zapr = "SELECT DISTINCT CONCAT(CONCAT(members.Фамилия,\" \"), members.Имя) FROM members, comm " +
           "WHERE Должность = 1 AND CONCAT(comm.Фамилия, comm.Имя) = CONCAT(members.Фамилия, comm.Имя) AND comm.Дело = " + case_id;
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader[0].ToString());
            reader.Close();

            zapr = "SELECT DISTINCT CONCAT(CONCAT(members.Фамилия,\" \"), members.Имя) FROM members, comm " +
           "WHERE Должность = 2 AND CONCAT(comm.Фамилия, comm.Имя) = CONCAT(members.Фамилия, comm.Имя) AND comm.Дело = " + case_id;
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                listBox2.Items.Add(reader[0].ToString());
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertim = "INSERT INTO `crime_places` (`ID_Места`, `ID_Дела`, `ID_Следователя`, `ID_Эксперта`, `Адрес\\коордианты`) VALUES (NULL, "+case_id+", " +
                "(SELECT ID_Персонала FROM members WHERE CONCAT(CONCAT(Фамилия,\" \"),Имя)=\"" + listBox1.SelectedItem + "\"), " +
                "(SELECT ID_Персонала FROM members WHERE CONCAT(CONCAT(Фамилия,\" \"),Имя)=\"" + listBox2.SelectedItem + "\"), " +
                "'"+textBox1.Text+"');";
            //MessageBox.Show(datepicker.Value.GetDateTimeFormats()[42].Substring(0,10));

            MySqlCommand command = new MySqlCommand(insertim, con);
            command.ExecuteNonQuery();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
