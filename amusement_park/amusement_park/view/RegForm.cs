using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amusement_park
{
    public partial class RegForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public RegForm()
        {
            InitializeComponent();
            textBoxLogin.Text = "Логин";
            textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxPass.Text = "Пароль";
            textBoxPass.PasswordChar = '\0';
            textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxName.Text = "Имя";
            textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxSurname.Text = "Фамилия";
            textBoxSurname.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxEmail.Text = "Email";
            textBoxEmail.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxDate.Text = "Дата рождения";
            textBoxDate.ForeColor = Color.FromArgb(127, 128, 132);
            labelInfo.Text = "";

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

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(230, 179, 51);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(127, 128, 132);
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Логин")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backLogClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "Пароль")
            {
                textBoxPass.Text = "";
                textBoxPass.PasswordChar = '●';
                textBoxPass.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel3.BackgroundImage = Properties.Resources.backPassClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "")
            {
                textBoxPass.Text = "Пароль";
                textBoxPass.PasswordChar = '\0';
                textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логин";
                textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Имя")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backLogClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Имя";
                textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Фамилия")
            {
                textBoxSurname.Text = "";
                textBoxSurname.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backPassClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Фамилия";
                textBoxSurname.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Email")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backLogClick;
            labelInfo.Text = "";
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Email";
                textBoxEmail.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxDate_Enter(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "Дата рождения")
            {
                textBoxDate.Text = "";
                textBoxDate.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backPassClick;
            labelInfo.Text = "";
        }

        private void textBoxDate_Leave(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "")
            {
                textBoxDate.Text = "Дата рождения";
                textBoxDate.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }
        private void label2_Click_1(object sender, EventArgs e)
        {
            if (AppSession.loginForm == null || AppSession.loginForm.IsDisposed)
            {
                AppSession.loginForm = new LoginForm();
                AppSession.loginForm.TopMost = true;
                AppSession.loginForm.FormClosed += (s, args) => AppSession.loginForm = null;
                AppSession.loginForm.Show();
            }
            else
            {
                AppSession.loginForm.Activate();
            }
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxLogin.Text == "" || textBoxLogin.Text == "Логин") || (textBoxPass.Text == "" || textBoxPass.Text == "Пароль") || (textBoxName.Text == "" || textBoxName.Text == "Имя") || (textBoxSurname.Text == "" || textBoxSurname.Text == "Фамилия") || (textBoxDate.Text == "" || textBoxDate.Text == "Дата") || (textBoxEmail.Text == "" || textBoxEmail.Text == "Email"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            }
            else if (checkUser(textBoxLogin.Text))
            {
                labelInfo.Text = "Такой логин уже существует";
                labelInfo.ForeColor = Color.Red;
            }
            else if (!IsValidEmail(textBoxEmail.Text))
            {
                labelInfo.Text = "Введите корректный Email адрес";
                labelInfo.ForeColor = Color.Red;
            }
            else if (!IsValidDateFormat(textBoxDate.Text))
            {
                labelInfo.Text = "Введите дату в формате 'гггг-мм-дд'";
                labelInfo.ForeColor = Color.Red;
            }
            else
            {
                User newUser = new User
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPass.Text
                };

                Person newPerson = new Person()
                {
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Date = textBoxDate.Text,
                    Email = textBoxEmail.Text
                };


                string queryUsers = "INSERT INTO users (login, password) VALUES (@login, @password)";
                string queryPersons = "INSERT INTO persons (user_id, name, surname, date, email) VALUES ((SELECT last_insert_rowid()), @name, @surname, @date, @email)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            using (SQLiteCommand cmdUsers = new SQLiteCommand(queryUsers, connection))
                            {
                                cmdUsers.Parameters.AddWithValue("@login", newUser.Login);
                                cmdUsers.Parameters.AddWithValue("@password", newUser.Password);
                                cmdUsers.ExecuteNonQuery();
                            }

                            using (SQLiteCommand cmdPersons = new SQLiteCommand(queryPersons, connection))
                            {
                                cmdPersons.Parameters.AddWithValue("@name", newPerson.Name);
                                cmdPersons.Parameters.AddWithValue("@surname", newPerson.Surname);
                                cmdPersons.Parameters.AddWithValue("@date", newPerson.Date);
                                cmdPersons.Parameters.AddWithValue("@email", newPerson.Email);
                                cmdPersons.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            labelInfo.Text = "Регистрация успешно завершена!";
                            labelInfo.ForeColor = Color.Green;

                            if (AppSession.loginForm == null || AppSession.loginForm.IsDisposed)
                            {
                                AppSession.loginForm = new LoginForm();
                                AppSession.loginForm.TopMost = true;
                                AppSession.loginForm.FormClosed += (s, args) => AppSession.loginForm = null;
                                AppSession.loginForm.Show();
                            }
                            else
                            {
                                AppSession.loginForm.Activate();
                            }
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            labelInfo.Text = "Ошибка при регистрации: " + ex.Message;
                            labelInfo.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private bool checkUser(string login)
        {
            // Проверка на уникальность логина
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM users WHERE login = @login";
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                    return userCount > 0;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                // уникальность email адреса
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM persons WHERE email = @email";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int emailCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (emailCount > 0)
                        {
                            throw new Exception("Email адрес уже существует.");
                        }
                    }
                }

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidDateFormat(string date)
        {
            // Проверка на корректный формат даты
            DateTime parsedDate;
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
        }

    }
}
