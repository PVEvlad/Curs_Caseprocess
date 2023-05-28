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
    public partial class Insert1 : Form
    {
        private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        MySqlConnection con;
        string case_id;
        public Insert1(MySqlConnection con1, string CASE)
        {
            con = con1;
            case_id = CASE;
            InitializeComponent();
        }

        private void Insert1_Load(object sender, EventArgs e)
        {
            string zapr = "SELECT DISTINCT CONCAT(CONCAT(members.Фамилия,\" \"), members.Имя) FROM members, comm "+
           "WHERE Должность = 1 AND CONCAT(comm.Фамилия, comm.Имя) = CONCAT(members.Фамилия, comm.Имя) AND comm.Дело = "+case_id;
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader[0].ToString());
            reader.Close();

            zapr= "SELECT DISTINCT CONCAT(CONCAT(members.Фамилия,\" \"), members.Имя) FROM members, comm " +
           "WHERE Должность = 2 AND CONCAT(comm.Фамилия, comm.Имя) = CONCAT(members.Фамилия, comm.Имя) AND comm.Дело = " + case_id;
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
            listBox2.Items.Add(reader[0].ToString());
            reader.Close();

            zapr = "SELECT DISTINCT `Адрес\\коордианты` FROM crime_places WHERE crime_places.ID_Дела=" + case_id;
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                listBox3.Items.Add(reader[0].ToString());
            reader.Close();

            zapr = "SELECT название_типа FROM evidence_type";
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                listBox5.Items.Add(reader[0].ToString());
            reader.Close();
            datepicker.CustomFormat = "yyyy-MM-dd";
            datepicker.Format = DateTimePickerFormat.Custom;             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertim =
           "INSERT INTO `evidences` (`ID_Улики`, `ID_Следователя`, `ID_Эксперта`, `ID_Места_нахождения`, `ID_Дела`, `Название`, \n" +
           "`Тип_улики`, `Дата_получения`) VALUES(NULL, \n" +
           "(SELECT ID_Персонала FROM members WHERE CONCAT(CONCAT(Фамилия,\" \"),Имя)=\""+listBox1.SelectedItem+ "\"), \n" +
           "(SELECT ID_Персонала FROM members WHERE CONCAT(CONCAT(Фамилия,\" \"),Имя)=\"" + listBox2.SelectedItem + "\"),\n" +
           "(SELECT crime_places.ID_Места FROM crime_places WHERE crime_places.`Адрес\\коордианты`=\""+listBox3.SelectedItem+ "\"),\n" +
           case_id+", \""+textBox1.Text + "\", (SELECT evidence_type.ID_Типа_улик from evidence_type WHERE evidence_type.Название_типа=\""+listBox5.SelectedItem+ "\"), \n\"" +
             datepicker.Value.GetDateTimeFormats()[42].Substring(0, 10) + "\")";
           //MessageBox.Show(datepicker.Value.GetDateTimeFormats()[42].Substring(0,10));
            
            MySqlCommand command = new MySqlCommand(insertim, con);
            command.ExecuteNonQuery();
            this.Close();
        }

    }
}
