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
    public partial class Insert2 : Form
    {
        private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        MySqlConnection con;
        string case_id;
        public Insert2(MySqlConnection con1, string CASE)
        {
            con = con1;
            case_id = CASE;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Insert2_Load(object sender, EventArgs e)
        {
            string zapr = "SELECT DISTINCT CONCAT(CONCAT(members.Фамилия,\" \"), members.Имя) FROM members, comm " +
          "WHERE CONCAT(comm.Фамилия, comm.Имя) = CONCAT(members.Фамилия, comm.Имя) AND comm.Дело = " + case_id;
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader[0].ToString());
            reader.Close();

            zapr = "SELECT Название_Статуса FROM partisipant_statuses";
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                listBox2.Items.Add(reader[0].ToString());
            reader.Close();

            datepicker.CustomFormat = "yyyy-MM-dd";
            datepicker.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertim =
           "INSERT INTO `partisipants` " +
           "(`ID_Допрашиваемого`, `ID_Дела`, `Фамилия`, `Имя`, `Адрес прописки`, `Статус`, " +
           "`Файл_протокола_допроса`, `Следователь`, `First_Interrog`) " +
           "VALUES (NULL, '"+case_id+"', '" +secondname.Text+ "', '" +name.Text+ "', '" +adress.Text+ "'," +
           " '" +(listBox1.SelectedIndex+1).ToString()+ "', '" +prot.Text+ "',(SELECT ID_Персонала FROM members WHERE CONCAT(CONCAT(Фамилия,\" \"),Имя)=\"" + listBox1.SelectedItem + "\"), '" + datepicker.Value.GetDateTimeFormats()[42].Substring(0, 10) + "');";
            //MessageBox.Show(datepicker.Value.GetDateTimeFormats()[42].Substring(0,10));

            MySqlCommand command = new MySqlCommand(insertim, con);
            command.ExecuteNonQuery();
            this.Close();
        }
    }
}
