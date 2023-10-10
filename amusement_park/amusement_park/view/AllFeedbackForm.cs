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
    public partial class AllFeedbackForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public AllFeedbackForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private DataTable LoadFeedbackData()
        {
            DataTable feedbackDataTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT p.name AS PersonName, a.name AS AttractionName, ar.rating AS Rating, ar.comment AS Comment " +
                               "FROM persons p " +
                               "INNER JOIN attraction_ratings ar ON p.id = ar.person_id " +
                               "INNER JOIN attractions a ON ar.attraction_id = a.id";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(feedbackDataTable);
                }
            }

            return feedbackDataTable;
        }

        private void CreateFeedbackLabels(DataTable feedbackDataTable)
        {
            int labelTop = 10;

            foreach (DataRow row in feedbackDataTable.Rows)
            {
                string personName = row["PersonName"].ToString();
                string attractionName = row["AttractionName"].ToString();
                string rating = row["Rating"].ToString();
                string comment = row["Comment"].ToString();

                Label feedbackLabel = new Label
                {
                    Text = $"Имя: {personName}\nАттракцион: {attractionName}\nОценка: {rating}\nКомментарий: {comment}",
                    AutoSize = true,
                    Location = new Point(10, labelTop)
                };

                labelTop += feedbackLabel.Height + 10;

                this.Controls.Add(feedbackLabel);
            }
        }

        private void AllFeedbackForm_Load(object sender, EventArgs e)
        {
            DataTable feedbackDataTable = LoadFeedbackData();
            CreateFeedbackLabels(feedbackDataTable);
        }


    }
}
