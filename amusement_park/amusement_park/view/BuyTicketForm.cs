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
    public partial class BuyTicketForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public BuyTicketForm()
        {
            InitializeComponent();
            LoadAvailableAttractions();
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

        private void BuyButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadAvailableAttractions()
        {
            string userLogin = AppSession.UserLogin;
            int userBirthYear = GetUserBirthYear(userLogin);

            if (userBirthYear == 0)
            {
                MessageBox.Show("Год рождения пользователя не найден.");
                return;
            }

            // текущий год
            int currentYear = DateTime.Now.Year;

            // для возраста пользователя
            int userAge = currentYear - userBirthYear;

            string query = "SELECT a.name FROM attractions a " +
                           "INNER JOIN limitations l ON a.id = l.attraction_id " +
                           "WHERE l.age_person <= @userAge";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userAge", userAge);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string attractionName = reader["name"].ToString();
                            checkedListBox1.Items.Add(attractionName);
                        }
                    }
                }
            }
        }

        private int GetUserBirthYear(string userLogin)
        {
            int userBirthYear = 0;

            // получение года рождения залогиненного
            string query = "SELECT date FROM persons " +
                           "INNER JOIN users ON persons.user_id = users.id " +
                           "WHERE users.login = @userLogin";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userLogin", userLogin);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        DateTime userBirthDate = Convert.ToDateTime(result);
                        userBirthYear = userBirthDate.Year;
                    }
                }
            }
            return userBirthYear;
        }
    }
}
