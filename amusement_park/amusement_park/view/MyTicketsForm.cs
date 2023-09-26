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
    public partial class MyTicketsForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public MyTicketsForm()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelUp_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyTicketsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dataGridViewTickets.AutoGenerateColumns = false;

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.HeaderText = "Название аттракциона";
            dataGridViewTickets.Columns.Add(nameColumn);

            DataGridViewColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "ticket_price";
            priceColumn.HeaderText = "Цена";
            dataGridViewTickets.Columns.Add(priceColumn);

            string userLogin = AppSession.UserLogin;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT at.name, at.ticket_price " +
                               "FROM attractions at " +
                               "INNER JOIN tickets t ON at.id = t.attraction_id " +
                               "INNER JOIN persons p ON t.person_id = p.id " +
                               "INNER JOIN users u ON p.user_id = u.id " +
                               "WHERE u.login = @userLogin";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@userLogin", userLogin);
                    adapter.Fill(dt);
                }
            }

            dataGridViewTickets.DataSource = dt;
        }

    }
}
