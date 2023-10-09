using System.Drawing;
using System;
using System.Windows.Forms;
using amusement_park.view;

namespace amusement_park
{
    public partial class AdminForm : Form
    {

        private bool flag = false;
        public AdminForm()
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

        private void buttonMinimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMaximiz_Click(object sender, EventArgs e)
        {
            if (!flag)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
            flag = !flag;
        }

        private void labelUsers_Click(object sender, EventArgs e)
        {
            if (AppSession.tableUsersForm == null || AppSession.tableUsersForm.IsDisposed)
            {
                AppSession.tableUsersForm = new TableUsersForm();
                AppSession.tableUsersForm.TopMost = true;
                AppSession.tableUsersForm.FormClosed += (s, args) => AppSession.tableUsersForm = null;
                AppSession.tableUsersForm.Show();
            }
            else
            {
                AppSession.tableUsersForm.Activate();
            }
        }

        private void labelAttractions_Click(object sender, EventArgs e)
        {
            if (AppSession.AttractionsForm == null || AppSession.AttractionsForm.IsDisposed)
            {
                AppSession.AttractionsForm = new TableAttractionsForm();
                AppSession.AttractionsForm.TopMost = true;
                AppSession.AttractionsForm.FormClosed += (s, args) => AppSession.AttractionsForm = null;
                AppSession.AttractionsForm.Show();
            }
            else
            {
                AppSession.AttractionsForm.Activate();
            }
        }

        private void allTickets_Click(object sender, EventArgs e)
        {
            if (AppSession.myTicketsForm == null || AppSession.myTicketsForm.IsDisposed)
            {
                AppSession.myTicketsForm = new MyTicketsForm(true);
                AppSession.myTicketsForm.TopMost = true;
                AppSession.myTicketsForm.FormClosed += (s, args) => AppSession.myTicketsForm = null;
                AppSession.myTicketsForm.Show();
            }
            else
            {
                AppSession.myTicketsForm.Activate();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            AppSession.IsLoggedIn = false;
            AppSession.UserLogin = "";
            this.Close();
        }
    }

}