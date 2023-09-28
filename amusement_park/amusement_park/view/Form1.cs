using amusement_park.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amusement_park
{
    public partial class Form1 : Form
    {
        private bool flag = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (AppSession.IsLoggedIn == true)
            {
                if (AppSession.UserLogin == "admin")
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
                }                
            }
            else
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
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm formLoad = new LoadForm();
            formLoad.TopMost = true; // чтобы форма была верхней
            formLoad.ShowDialog();
            pictureBoxForGif.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxForGif.Image = amusement_park.Properties.Resources.weclomeGif;
        }

        private void buttonAttractions_Click(object sender, EventArgs e)
        {
            if (AppSession.attractionsViewForm == null || AppSession.attractionsViewForm.IsDisposed)
            {
                AppSession.attractionsViewForm = new AttractionsViewForm();
                AppSession.attractionsViewForm.TopMost = true;
                AppSession.attractionsViewForm.FormClosed += (s, args) => AppSession.attractionsViewForm = null;
                AppSession.attractionsViewForm.Show();
            }
            else
            {
                AppSession.attractionsViewForm.Activate();
            }
        }
    }
}
