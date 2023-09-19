using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amusement_park
{
    public partial class TableUsersForm : Form
    {
        public TableUsersForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TableUsersForm_Load(object sender, EventArgs e)
        {
            // Создаем DataTable для хранения данных
            DataTable dt = new DataTable();

            // Строка подключения к базе данных SQLite
            string connectionString = "Data Source=sb.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Выполняем SQL-запрос для получения данных из таблицы User и Person
                string query = "SELECT u.id, u.login, u.password, p.name, p.surname, p.date, p.email FROM users u INNER JOIN persons p ON u.id = p.user_id";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            // Устанавливаем источник данных для DataGridView
            dataGridViewUsers.DataSource = dt;
        }
    }
}
