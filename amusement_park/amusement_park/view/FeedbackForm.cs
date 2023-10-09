using amusement_park.Properties;
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
    public partial class FeedbackForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        int stars = 0;
        public FeedbackForm()
        {
            InitializeComponent();
            star1.SizeMode = PictureBoxSizeMode.StretchImage;
            star2.SizeMode = PictureBoxSizeMode.StretchImage;
            star3.SizeMode = PictureBoxSizeMode.StretchImage;
            star4.SizeMode = PictureBoxSizeMode.StretchImage;
            star5.SizeMode = PictureBoxSizeMode.StretchImage;
            LoadUserAttractions();
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

        private void star1_MouseEnter(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__3_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star1_MouseLeave(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__2_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star2_MouseEnter(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__3_;
                star2.Image = Resources.icons8_star_30__3_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star2_MouseLeave(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__2_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star3_MouseEnter(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__3_;
                star2.Image = Resources.icons8_star_30__3_;
                star3.Image = Resources.icons8_star_30__3_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star3_MouseLeave(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__2_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star4_MouseEnter(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__3_;
                star2.Image = Resources.icons8_star_30__3_;
                star3.Image = Resources.icons8_star_30__3_;
                star4.Image = Resources.icons8_star_30__3_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star4_MouseLeave(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__2_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void star5_MouseEnter(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__3_;
                star2.Image = Resources.icons8_star_30__3_;
                star3.Image = Resources.icons8_star_30__3_;
                star4.Image = Resources.icons8_star_30__3_;
                star5.Image = Resources.icons8_star_30__3_;
            }
        }

        private void star5_MouseLeave(object sender, EventArgs e)
        {
            if (stars == 0)
            {
                star1.Image = Resources.icons8_star_30__2_;
                star2.Image = Resources.icons8_star_30__2_;
                star3.Image = Resources.icons8_star_30__2_;
                star4.Image = Resources.icons8_star_30__2_;
                star5.Image = Resources.icons8_star_30__2_;
            }
        }

        private void LoadUserAttractions()
        {
            string userLogin = AppSession.UserLogin;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT a.name " +
                               "FROM attractions a " +
                               "INNER JOIN tickets t ON a.id = t.attraction_id " +
                               "INNER JOIN persons p ON t.person_id = p.id " +
                               "INNER JOIN users u ON p.user_id = u.id " +
                               "WHERE u.login = @userLogin";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userLogin", userLogin);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string attractionName = reader["name"].ToString();
                            domainUpDown1.Items.Add(attractionName);
                        }
                    }
                }
            }
        }

        private void star1_Click(object sender, EventArgs e)
        {
            stars = 1;
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star2_Click(object sender, EventArgs e)
        {
            stars = 2;
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star3_Click(object sender, EventArgs e)
        {
            stars = 3;
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star4_Click(object sender, EventArgs e)
        {
            stars = 4;
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__3_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star5_Click(object sender, EventArgs e)
        {
            stars = 5;
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__3_;
            star5.Image = Resources.icons8_star_30__3_;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {

        }
    }
}
