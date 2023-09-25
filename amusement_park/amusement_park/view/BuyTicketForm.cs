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
        private Dictionary<string, int> attractionPrices = new Dictionary<string, int>();

        public BuyTicketForm()
        {
            InitializeComponent();
            LoadAvailableAttractions();
            attractionPrices = GetAttractionPrices();
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
            int userId = GetUserIdByLogin(AppSession.UserLogin);

            if (userId == 0)
            {
                MessageBox.Show("Не удалось найти идентификатор пользователя.");
                return;
            }

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    string fullItemText = checkedListBox1.Items[i].ToString();
                    string[] parts = fullItemText.Split(new string[] { "   " }, StringSplitOptions.None);

                    if (parts.Length >= 2)
                    {
                        string attractionName = parts[0];

                        if (attractionPrices.ContainsKey(attractionName))
                        {
                            int attractionId = GetAttractionIdByName(attractionName);

                            if (attractionId != 0)
                            {
                                string insertQuery = "INSERT INTO tickets (person_id, attraction_id) VALUES (@personId, @attractionId);";

                                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                                {
                                    connection.Open();

                                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                                    {
                                        cmd.Parameters.AddWithValue("@personId", userId);
                                        cmd.Parameters.AddWithValue("@attractionId", attractionId);

                                        int rowsAffected = cmd.ExecuteNonQuery();

                                        if (rowsAffected > 0)
                                        {
                                            MessageBox.Show($"Куплен билет на аттракцион: {attractionName}");
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Не удалось купить билет на аттракцион: {attractionName}");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Не удалось найти аттракцион с именем: {attractionName}");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Не удалось найти цену для аттракциона: {attractionName}");
                        }
                    }
                }
            }
        }

        private int GetAttractionIdByName(string attractionName)
        {
            int attractionId = 0;

            string query = "SELECT id FROM attractions WHERE name = @name;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", attractionName);

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out attractionId))
                    {
                        return attractionId;
                    }
                }
            }

            return attractionId;
        }

        private int GetUserIdByLogin(string login)
        {
            int userId = 0;

            string query = "SELECT id FROM users WHERE login = @login;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out userId))
                    {
                        return userId;
                    }
                }
            }

            return userId;
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

            // Текущий год
            int currentYear = DateTime.Now.Year;

            // Возраст пользователя
            int userAge = currentYear - userBirthYear;

            // Получаем словарь с ценами на аттракционы
            Dictionary<string, int> attractionPrices = GetAttractionPrices();

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
                        if (reader.HasRows)
                        {
                            labelTitle.Text = (string.Format("{0,-60}{1}", "Название аттракциона", "Цена"));

                            while (reader.Read())
                            {
                                string attractionName = reader["name"].ToString();
                                int ticketPrice = attractionPrices.ContainsKey(attractionName) ? attractionPrices[attractionName] : 0;

                                string formattedLine = string.Format("{0,-60}{1} руб.", attractionName, ticketPrice);
                                checkedListBox1.Items.Add(formattedLine);
                            }
                        }
                        else
                        {
                            MessageBox.Show("К сожалению, нет доступных аттракционов для данного пользователя :(");
                        }
                    }
                }
            }
        }

        private Dictionary<string, int> GetAttractionPrices()
        {
            Dictionary<string, int> attractionPrices = new Dictionary<string, int>();

            string query = "SELECT name, ticket_price FROM attractions;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string attractionName = reader["name"].ToString();
                            int ticketPrice = Convert.ToInt32(reader["ticket_price"]);
                            attractionPrices[attractionName] = ticketPrice;
                        }
                    }
                }
            }

            return attractionPrices;
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalCost = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    string fullItemText = checkedListBox1.Items[i].ToString();

                    string[] parts = fullItemText.Split(new string[] { "   " }, StringSplitOptions.None);

                    if (parts.Length >= 2)
                    {
                        string attractionName = parts[0];

                        if (attractionPrices.ContainsKey(attractionName))
                        {
                            totalCost += attractionPrices[attractionName];
                        }
                    }
                }
            }
            labelSum.Text = $"Общая сумма: {totalCost} руб.";
        }
    }
}
