﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amusement_park
{
    public partial class RegForm : Form
    {
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
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxLogin.Text == "" | textBoxLogin.Text == "Логин") | (textBoxPass.Text == "" | textBoxPass.Text == "Пароль") | (textBoxName.Text == "" | textBoxName.Text == "Имя") | (textBoxSurname.Text == "" | textBoxSurname.Text == "Фамилия"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            }
            else if (checkUser())
            {
                labelInfo.Text = "Такой логин уже существует";
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


                string connectionString = "Data Source=sb.db;Version=3;";

                string queryUsers = "INSERT INTO users (login, password) VALUES (@login, @password)";
                string queryPersons = "INSERT INTO persons (user_id, name, surname, date, email) VALUES ((SELECT last_insert_rowid()), @name, @surname, @date, @email)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
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
                    }
                }


                /*
                if (command.ExecuteNonQuery() == 1)
                {
                    labelInfo.Text = "Аккаунт создан, войдите!";
                    labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                    DataBank.loginUser = textBoxLogin.Text;
                    DataBank.passwordUser = textBoxPass.Text;

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();

                }
                else
                {
                    labelInfo.Text = "Аккаунт не был создан";
                    labelInfo.ForeColor = Color.Red;
                }*/
                
            }
        }



        public Boolean checkUser()
        {
            return false;
        }

    }
}
