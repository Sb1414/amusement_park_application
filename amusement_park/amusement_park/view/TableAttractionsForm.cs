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

namespace amusement_park.view
{
    public partial class TableAttractionsForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public TableAttractionsForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TableAttractionsForm_Load(object sender, EventArgs e)
        {
            LoadAttractionsData();
        }

        private void LoadAttractionsData()
        {
            DataTable dt = new DataTable();

            dataGridViewAttractions.AutoGenerateColumns = false;

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.HeaderText = "Название";
            dataGridViewAttractions.Columns.Add(nameColumn);

            DataGridViewColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "description";
            descriptionColumn.HeaderText = "Описание";
            dataGridViewAttractions.Columns.Add(descriptionColumn);

            DataGridViewColumn capacityColumn = new DataGridViewTextBoxColumn();
            capacityColumn.DataPropertyName = "capacity";
            capacityColumn.HeaderText = "Вместимость";
            dataGridViewAttractions.Columns.Add(capacityColumn);

            DataGridViewColumn ticketPriceColumn = new DataGridViewTextBoxColumn();
            ticketPriceColumn.DataPropertyName = "ticket_price";
            ticketPriceColumn.HeaderText = "Цена";
            dataGridViewAttractions.Columns.Add(ticketPriceColumn);

            DataGridViewColumn timeWorkColumn = new DataGridViewTextBoxColumn();
            timeWorkColumn.DataPropertyName = "time_work";
            timeWorkColumn.HeaderText = "Время работы";
            dataGridViewAttractions.Columns.Add(timeWorkColumn);

            DataGridViewColumn limitationsColumn = new DataGridViewTextBoxColumn();
            limitationsColumn.DataPropertyName = "limitations";
            limitationsColumn.HeaderText = "Ограничения";
            dataGridViewAttractions.Columns.Add(limitationsColumn); // Добавляем столбец для ограничений

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Выполняем SQL-запрос для объединения данных из таблиц "attractions" и "limitations"
                string query = "SELECT a.name, a.description, a.capacity, a.ticket_price, a.time_work, GROUP_CONCAT(l.age_person) as limitations " +
                               "FROM attractions a " +
                               "LEFT JOIN limitations l ON a.id = l.attraction_id " +
                               "GROUP BY a.id";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            dataGridViewAttractions.DataSource = dt;
        }

        private void toolStripDeleteAtr_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewAttractions.CurrentRow;
            if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value != "")
            {
                string attractionName = currentRow.Cells[0].Value.ToString();

                // Удаление рейтингов аттракциона из таблицы attraction_ratings
                string deleteRatingsQuery = "DELETE FROM attraction_ratings WHERE attraction_id = (SELECT id FROM attractions WHERE name = @attractionName)";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteRatingsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionName", attractionName);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление билетов на аттракцион из таблицы tickets
                string deleteTicketsQuery = "DELETE FROM tickets WHERE attraction_id = (SELECT id FROM attractions WHERE name = @attractionName)";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteTicketsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionName", attractionName);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление лимитов аттракциона из таблицы limitations
                string deleteLimitsQuery = "DELETE FROM limitations WHERE attraction_id = (SELECT id FROM attractions WHERE name = @attractionName)";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteLimitsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionName", attractionName);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление самого аттракциона из таблицы attractions
                string deleteAttractionQuery = "DELETE FROM attractions WHERE name = @attractionName";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteAttractionQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionName", attractionName);
                        cmd.ExecuteNonQuery();
                    }
                }

                // После удаления обновляем таблицу attractions
                dataGridViewAttractions.Columns.Clear();
                LoadAttractionsData();
            }
            else
            {
                MessageBox.Show("Выберите аттракцион для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripAddAtr_Click(object sender, EventArgs e)
        {
            AddAttractionForm addAttraction = new AddAttractionForm();
            addAttraction.TopMost = true;

            if (addAttraction.ShowDialog() == DialogResult.OK)
            {
                dataGridViewAttractions.Columns.Clear();
                LoadAttractionsData();
            }
        }
    }
}
