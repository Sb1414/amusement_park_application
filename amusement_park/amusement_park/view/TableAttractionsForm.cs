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

            DataGridViewColumn loginColumn = new DataGridViewTextBoxColumn();
            loginColumn.DataPropertyName = "name";
            loginColumn.HeaderText = "Название";
            dataGridViewAttractions.Columns.Add(loginColumn);

            DataGridViewColumn passwordColumn = new DataGridViewTextBoxColumn();
            passwordColumn.DataPropertyName = "description";
            passwordColumn.HeaderText = "Описание";
            dataGridViewAttractions.Columns.Add(passwordColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "capacity";
            nameColumn.HeaderText = "Вместимость";
            dataGridViewAttractions.Columns.Add(nameColumn);

            DataGridViewColumn surnameColumn = new DataGridViewTextBoxColumn();
            surnameColumn.DataPropertyName = "ticket_price";
            surnameColumn.HeaderText = "Цена";
            dataGridViewAttractions.Columns.Add(surnameColumn);

            DataGridViewColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "time_work";
            dateColumn.HeaderText = "Время работы";
            dataGridViewAttractions.Columns.Add(dateColumn);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT name, description, capacity, ticket_price, time_work FROM attractions";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            dataGridViewAttractions.DataSource = dt;
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewAttractions.CurrentRow;
            if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value != "")
            {
                int attractionId = Convert.ToInt32(currentRow.Cells["id"].Value);

                // Удаление рейтингов аттракциона из таблицы attraction_ratings
                string deleteRatingsQuery = "DELETE FROM attraction_ratings WHERE attraction_id = @attractionId";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteRatingsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionId", attractionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление билетов на аттракцион из таблицы tickets
                string deleteTicketsQuery = "DELETE FROM tickets WHERE attraction_id = @attractionId";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteTicketsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionId", attractionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление лимитов аттракциона из таблицы limitations
                string deleteLimitsQuery = "DELETE FROM limitations WHERE attraction_id = @attractionId";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteLimitsQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionId", attractionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Удаление самого аттракциона из таблицы attractions
                string deleteAttractionQuery = "DELETE FROM attractions WHERE id = @attractionId";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteAttractionQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@attractionId", attractionId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // После удаления обновляем таблицу attractions
                LoadAttractionsData();
            }
            else
            {
                MessageBox.Show("Выберите аттракцион для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
