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
    public partial class UserForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public UserForm()
        {
            InitializeComponent();
            LoadUserInfo();
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


        private void BuyTicket_Click(object sender, EventArgs e)
        {
            if (AppSession.ticketForm == null || AppSession.ticketForm.IsDisposed)
            {
                AppSession.ticketForm = new BuyTicketForm();
                AppSession.ticketForm.TopMost = true;
                AppSession.ticketForm.FormClosed += (s, args) => AppSession.ticketForm = null;
                AppSession.ticketForm.Show();
            }
            else
            {
                AppSession.ticketForm.Activate();
            }
        }

        private void LoadUserInfo()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id, name, surname FROM persons WHERE user_id = (SELECT id FROM users WHERE login = @login)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", AppSession.UserLogin);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string surname = reader.GetString(2);

                            infoUser.Text = "Добро пожаловать, " + name + " " + surname + "!";
                        }
                    }
                }
            }
        }

        private void logoutAccount_Click(object sender, EventArgs e)
        {
            AppSession.IsLoggedIn = false;
            AppSession.UserLogin = "";
            this.Close();
        }

        private void MyTickets_Click(object sender, EventArgs e)
        {
            if (AppSession.myTicketsForm == null || AppSession.myTicketsForm.IsDisposed)
            {
                AppSession.myTicketsForm = new MyTicketsForm(false);
                AppSession.myTicketsForm.TopMost = true;
                AppSession.myTicketsForm.FormClosed += (s, args) => AppSession.myTicketsForm = null;
                AppSession.myTicketsForm.Show();
            }
            else
            {
                AppSession.myTicketsForm.Activate();
            }
        }
    }
}
