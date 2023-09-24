using amusement_park.view;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            textBoxLogin.Text = "Логин";
            textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132); 
            textBoxPass.Text = "Пароль";
            textBoxPass.PasswordChar = '\0';
            textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
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

        private void label2_Click(object sender, EventArgs e)
        {
            if (AppSession.regForm == null || AppSession.regForm.IsDisposed)
            {
                AppSession.regForm = new RegForm();
                AppSession.regForm.TopMost = true;
                AppSession.regForm.FormClosed += (s, args) => AppSession.regForm = null;
                AppSession.regForm.Show();
            }
            else
            {
                AppSession.regForm.Activate();
            }
            this.Close();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(230, 179, 51);
            labelInfo.Text = "";
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(127, 128, 132);
            labelInfo.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxLogin.Text == "" | textBoxLogin.Text == "Логин") | (textBoxPass.Text == "" | textBoxPass.Text == "Пароль"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            }
            else
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                string loginUser = textBoxLogin.Text;
                string passUser = textBoxPass.Text;
                string query = "SELECT id FROM users WHERE login = @login AND password = @password";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", loginUser);
                        cmd.Parameters.AddWithValue("@password", passUser);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            AppSession.IsLoggedIn = true;
                            AppSession.UserLogin = loginUser;
                            if (loginUser == "admin")
                            {
                                if (AppSession.adminForm == null || AppSession.adminForm.IsDisposed)
                                {
                                    AppSession.adminForm = new AdminForm();
                                    AppSession.adminForm.TopMost = true;
                                    AppSession.adminForm.FormClosed += (s, args) => AppSession.adminForm = null;
                                    AppSession.adminForm.Show();
                                }
                                else
                                {
                                    AppSession.adminForm.Activate();
                                }
                                this.Close();
                            } else
                            {
                                if (AppSession.userForm == null || AppSession.userForm.IsDisposed)
                                {
                                    AppSession.userForm = new UserForm();
                                    AppSession.userForm.TopMost = true;
                                    AppSession.userForm.FormClosed += (s, args) => AppSession.userForm = null;
                                    AppSession.userForm.Show();
                                }
                                else
                                {
                                    AppSession.userForm.Activate();
                                }
                                this.Close();
                            }
                            int userId = Convert.ToInt32(result);
                        }
                        else
                        {
                            labelInfo.Text = "Неправильный логин или пароль";
                            labelInfo.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Логин")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backLogClick;
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
            panel2.BackgroundImage = Properties.Resources.backPassClick;
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
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логин";
                textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }
    }
}
