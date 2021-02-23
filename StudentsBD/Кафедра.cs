using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace StudentsBD
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(
            @"Provider=Microsoft.ACE.OLEDB.12.0;" + 
            @"Data Source=""C:\Users\danim\Desktop\remote\BD\laba3.accdb"""
        );

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private List<String> Get_Employees_FIO()
        {
            List<String> res = new List<String>();
            cn.Open(); // установка соединения
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                // установка связи между объектом отправки SQL-запросов и
                // соединением
                cmd.Connection = cn;
                // создание запроса на выбору с параметром (@Templ)
                cmd.CommandText =
                "SELECT * FROM Студент WHERE [Фамилия Имя Отчество] LIKE @Templ";
                // установка значения параметра
                cmd.Parameters.AddWithValue("@Templ", "%в");
                // попытка выполнить запрос,
                // доступ к его результату будет осуществляться
                // при помощи объекта rd
                OleDbDataReader rd = cmd.ExecuteReader();
                // если запрос вернул результат
                if (rd.HasRows)
                {
                    // получаем строки одну за другой, и для каждой строки...
                    while (rd.Read())
                    {
                        // ... добавляем в res содержимое столбца [Фамилия Имя Отчество]
                        res.Add(rd.GetValue(rd.GetOrdinal("[Фамилия Имя Отчество]"))
                        .ToString());
                    }
                }
                return res;
            }
            finally
            {
                cn.Close(); // закрытие соединения с БД
            }
        }
        /*private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // переносим список [Фамилия Имя Отчество] в listBox1
            foreach (String i in Get_Employees_Families())
                listBox1.Items.Add(i);
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
