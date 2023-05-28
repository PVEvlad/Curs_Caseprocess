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
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing.Layout;

namespace FOR_BD
{
    public partial class Inter2 : Form
    {
        private MySqlDataAdapter mydtadp = new MySqlDataAdapter();
        private BindingSource bindingSource1 = new BindingSource();
        MySqlConnection con;
        string worker_id;
        string worker;
        string case_id;
        int selecteditem = 0;
        public Inter2(MySqlConnection con1, string FI)
        {
            worker = FI;
            con = con1;
            string zapr = "SELECT * from members where (CONCAT(members.Фамилия,CONCAT(\" \",members.Имя))=\"" + worker+"\")";
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            worker_id = reader[0].ToString();
            reader.Close();
            InitializeComponent();
        }

        private void Inter2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            string zapr = "SELECT ID_Дела, Дата_открытия, Дата_завершения FROM cases, comm "+
                            "WHERE CONCAT(comm.Фамилия,CONCAT(\" \",comm.Имя))= \"" + worker+"\""+
                            " AND comm.Дело = cases.ID_Дела";
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            listBox1.Items.Add(reader[0].ToString()+")  "+reader[1].ToString()+ " — " + reader[2].ToString());
            reader.Close();
            listBox1.Height = (listBox1.Items.Count) * 20;
            listBox1.Visible = true;
            button1.Location = new Point(button1.Location.X, this.Height-100);
            button3.Location = new Point(button3.Location.X, this.Height - 100);
            button4.Location = new Point(button4.Location.X, this.Height - 100);
            button5.Location = new Point(button5.Location.X, this.Height - 100);
            button2.Location = new Point(button2.Location.X, this.Height - 100);
            button6.Location = new Point(button5.Location.X+116, this.Height - 100);
            //  firstpdf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Выберите дело:";
            button2.Visible = button3.Visible = button4.Visible = false;
            listBox1.Visible = true;
            button1.Visible = false;
            button5.Visible = false;
            table1.Visible = false;
            button6.Text = "Документ по работнику";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            char a = ')';
           case_id= new string(listBox1.SelectedItem.ToString().TakeWhile(c => c != a).ToArray());
            string zapr = "SELECT * FROM cases " +
                           "WHERE ID_Дела= "+case_id;
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            listBox1.Visible = false;
            reader.Read();
            label1.Text = "Текущее дело:"+reader[0]+") Продолжительность дела:"+reader[1]+ " — " + reader[2]+"; Дело завершено:"+reader[3];
            reader.Close();
            label1.Visible = true;
            button1.Visible = button2.Visible = button3.Visible = button4.Visible = true;
            button6.Text = "Документ по делу";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zaproc = "SELECT distinct ID_Улики AS Улика, \n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
    "FROM members, evidences\n" +
    "where ID_Дела = "+ case_id + " AND evidences.ID_Следователя = ID_Персонала AND ID_Улики = Улика\n" +
") AS Следователь,\n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
    "FROM members, evidences\n" +
    "where ID_Дела = " + case_id + " AND evidences.ID_Эксперта = ID_Персонала AND ID_Улики = Улика\n" +
") AS Эксперт,\n" +
"`Адрес\\коордианты` AS Место,\n" +
"название AS Предмет,\n" +
"evidence_type.Название_типа AS Тип,\n" +
"Дата_получения\n" +
"From members, evidences, crime_places, evidence_type\n" +
"WHERE evidences.ID_Дела = " + case_id + " AND crime_places.ID_Дела = " + case_id + " AND evidences.Тип_улики = evidence_type.ID_Типа_улик AND ID_Места_нахождения=ID_Места\n";
            DataTable table = new DataTable();
            mydtadp.SelectCommand = new MySqlCommand(zaproc, con);
            mydtadp.Fill(table);
            bindingSource1.DataSource = table;
            table1.DataSource = bindingSource1;
            table1.Visible = true;
            DataGridViewElementStates states = DataGridViewElementStates.None;
            table1.Height = table1.Rows.GetRowsHeight(states)+table1.ColumnHeadersHeight;
            table1.Width = table1.Columns.GetColumnsWidth(states)+20;
            selecteditem = 2;
            button5.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zaproc =
 "SELECT distinct CONCAT(CONCAT(partisipants.Фамилия,\" \"),partisipants.Имя) AS Допрашиваемый,\n" +
"CONCAT(CONCAT(members.Фамилия, \" \"), members.Имя) AS Допрашивающий,\n" +
  "Файл_протокола_допроса AS Протокол,\n" +
  "`Адрес прописки` AS Прописка,\n" +
  "First_interrog AS `Дата первого допроса`,\n" +
"Название_Статуса AS Статус\n" +
"FROM partisipants, members, partisipant_statuses\n" +
"WHERE partisipants.Следователь = members.ID_Персонала AND ID_Дела = " + case_id + " AND partisipant_statuses.ID_Статуса = partisipants.Статус";
            DataTable table = new DataTable();
            mydtadp.SelectCommand = new MySqlCommand(zaproc, con);
            mydtadp.Fill(table);
            bindingSource1.DataSource = table;
            table1.DataSource = bindingSource1;
            table1.Visible = true;
            DataGridViewElementStates states = DataGridViewElementStates.None;
            table1.Height = table1.Rows.GetRowsHeight(states) + table1.ColumnHeadersHeight;
            table1.Width = table1.Columns.GetColumnsWidth(states) + 20;
            selecteditem = 3;
            button5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string zaproc = "SELECT distinct crime_places.ID_Места AS Номер,\n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
"    FROM members, crime_places\n" +
"    where ID_Дела = " + case_id + " AND crime_places.ID_Следователя = ID_Персонала\n" +
"AND ID_Места=Номер) AS Следователь,\n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
"    FROM members, crime_places\n" +
"    where ID_Дела = " + case_id + " AND crime_places.ID_Эксперта = ID_Персонала\n" +
"AND ID_Места=Номер) AS Эксперт,\n" +
"`Адрес\\коордианты` AS Место\n" +
"From members, crime_places\n" +
"WHERE crime_places.ID_Дела = " + case_id + "\n";
            DataTable table = new DataTable();
            mydtadp.SelectCommand = new MySqlCommand(zaproc, con);
            mydtadp.Fill(table);
            bindingSource1.DataSource = table;
            table1.DataSource = bindingSource1;
            table1.Visible = true;
            DataGridViewElementStates states = DataGridViewElementStates.None;
            table1.Height = table1.Rows.GetRowsHeight(states) + table1.ColumnHeadersHeight;
            table1.Width = table1.Columns.GetColumnsWidth(states) + 20;
            selecteditem = 4;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                switch (selecteditem)
                {
                    case 2: Insert1 newEv = new Insert1(con, case_id); newEv.ShowDialog(); break;
                    case 3: Insert2 newPar = new Insert2(con, case_id); newPar.ShowDialog(); break;
                    case 4: Insert3 newPl = new Insert3(con, case_id); newPl.ShowDialog(); break;
                    default: break;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка заполнения"); }

        }
        string getEvstring() { return ""; }
        string getCase() { return ""; }
        string getMem() 
        {
        string zapr = "SELECT Название_должности, department.Отдел FROM members, department,posts " +
                            " WHERE ID_Персонала= '"+worker_id+"' AND\n ID_Отдела=members.Отдел\n AND ID_Должности=Должность";
         string for_ret = worker_id + ") " + worker+". ",dop= "\n" + "Список дел:\n";
            MySqlCommand command = new MySqlCommand(zapr, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            for_ret = for_ret + reader[0].ToString() +". "+ reader[1].ToString()+".";
            reader.Close();
            for_ret += dop;
            zapr = "SELECT ID_Дела, Дата_открытия, Дата_завершения,  Причина_закрытия, Отдел FROM cases, comm,department " +
                            "WHERE CONCAT(comm.Фамилия,CONCAT(\" \",comm.Имя))= \"" + worker + "\"" +
                            " AND comm.Дело = cases.ID_Дела AND ID_Отдела=Категория_преступления";
             command = new MySqlCommand(zapr, con);
             reader = command.ExecuteReader();
            while (reader.Read())
                for_ret=for_ret+reader[0].ToString() + ". " + reader[1].ToString().Substring(0,10) + " — " + reader[2].ToString().Substring(0, 10) +"; \""+ reader[3].ToString()+"\". "+reader[4].ToString()+".\n";
            reader.Close();
            for_ret = for_ret+"\nДопрошенные:\n";
            zapr = "SELECT distinct CONCAT(CONCAT(partisipants.Фамилия,\" \"),partisipants.Имя) AS Допрашиваемый, \n" +
   "Файл_протокола_допроса AS Протокол, \n" +
   "`Адрес прописки` AS Прописка, \n" +
   "First_interrog AS `Дата первого допроса`,\n" +
 "Название_Статуса AS Статус, ID_Допрашиваемого, ID_Дела \n" +
 "FROM partisipants, members, partisipant_statuses \n" +
 "WHERE partisipants.Следователь ="+ worker_id+ " \n" +
" AND partisipant_statuses.ID_Статуса = partisipants.Статус";
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                for_ret = for_ret +reader[5].ToString()+". "+ reader[0].ToString()+"; Дело №"+reader[6]+"; " + reader[1].ToString() +"; "+ reader[3].ToString().Substring(0,10)+"; " + reader[4].ToString()+ ";\n     Адрес:" + reader[2].ToString() + ".\n";
            reader.Close();
            for_ret = for_ret + "\nУчаствовал в осмотре: \n";
            zapr = "SELECT distinct crime_places.ID_Места AS Номер, \n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя) \n" +
"    FROM members, crime_places \n" +
"    where crime_places.ID_Следователя = ID_Персонала \n" +
"AND ID_Места=Номер) AS Следователь, \n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя) \n" +
"    FROM members, crime_places \n" +
"    where ID_Эксперта = ID_Персонала \n" +
"AND ID_Места=Номер) AS Эксперт, \n" +
"`Адрес\\коордианты` AS Место \n" +
"From members, crime_places \n" +
"WHERE ID_Следователя="+worker_id+" OR ID_Эксперта="+worker_id;
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                for_ret = for_ret + reader[0].ToString()+". " + reader[3].ToString() + "; \n     В качестве следователя выступил(а):" + reader[1].ToString() + "; \n     В качестве эксперта выступил(а):" + reader[2].ToString()+".\n";
            reader.Close();

            for_ret = for_ret + "\nУчаствовал получении улики\\заключения по улике: \n";
            zapr = "SELECT distinct ID_Улики AS Улика, \n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
    "FROM members, evidences\n" +
    "where evidences.ID_Следователя = ID_Персонала AND ID_Улики = Улика\n" +
") AS Следователь,\n" +
"(SELECT CONCAT(CONCAT(Фамилия, \" \"), Имя)\n" +
    "FROM members, evidences\n" +
    "where evidences.ID_Эксперта = ID_Персонала AND ID_Улики = Улика\n" +
") AS Эксперт,\n" +
"`Адрес\\коордианты` AS Место,\n" +
"название AS Предмет,\n" +
"evidence_type.Название_типа AS Тип,\n" +
"Дата_получения\n" +
"From members, evidences, crime_places, evidence_type\n" +
"WHERE evidences.Тип_улики = evidence_type.ID_Типа_улик AND ID_Места_нахождения=ID_Места AND(evidences.ID_Следователя="+worker_id+ "  OR evidences.ID_Эксперта=" + worker_id + ")\n";        
            command = new MySqlCommand(zapr, con);
            reader = command.ExecuteReader();
            while (reader.Read())
                for_ret = for_ret + reader[0].ToString() + ". \""+ reader[4].ToString() + "\". Тип:"+ reader[5].ToString() + ". Дата получения:"+ reader[6].ToString().Substring(0, 10) + "\n     В качестве следователя выступил(а):" + reader[1].ToString() + ";\n     В качестве эксперта выступил(а):" + reader[2].ToString() + ".\n ";
            reader.Close();
            return for_ret; }

        private void button6_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);
            string filename;
            switch (button6.Text) 
            {
                case "Документ по улике":
                    tf.DrawString("Справка по улике", font, XBrushes.Black,new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
                    filename = "EvidDocument.pdf";
                    break;
                case "Документ по делу":
                    tf.DrawString("Отчёт по делу", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
                    filename = "CaseDocument.pdf";
                    break;
                default:
                    tf.DrawString(getMem()+"\n\n"+"Подпись руководителя отдела:_______________        Реквезиты:"+DateTime.Now.ToString().Replace(".","").Replace(" ","\\")+"\n Справку получил: "+worker, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
                    filename = "MemberDocument.pdf";
                    break;
            }
            try
            {
                document.Save(filename);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка Записи."); }
        }

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selecteditem==2) { button6.Text = "Документ по улике"; }
            else button6.Text = "Документ по улике!";
        }
    }
}
