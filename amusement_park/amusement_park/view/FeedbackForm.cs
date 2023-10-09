using amusement_park.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public FeedbackForm()
        {
            InitializeComponent();
            star1.SizeMode = PictureBoxSizeMode.StretchImage;
            star2.SizeMode = PictureBoxSizeMode.StretchImage;
            star3.SizeMode = PictureBoxSizeMode.StretchImage;
            star4.SizeMode = PictureBoxSizeMode.StretchImage;
            star5.SizeMode = PictureBoxSizeMode.StretchImage;
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
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star1_MouseLeave(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__2_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star2_MouseEnter(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star2_MouseLeave(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__2_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star3_MouseEnter(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star3_MouseLeave(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__2_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star4_MouseEnter(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__3_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star4_MouseLeave(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__2_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }

        private void star5_MouseEnter(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__3_;
            star2.Image = Resources.icons8_star_30__3_;
            star3.Image = Resources.icons8_star_30__3_;
            star4.Image = Resources.icons8_star_30__3_;
            star5.Image = Resources.icons8_star_30__3_;
        }

        private void star5_MouseLeave(object sender, EventArgs e)
        {
            star1.Image = Resources.icons8_star_30__2_;
            star2.Image = Resources.icons8_star_30__2_;
            star3.Image = Resources.icons8_star_30__2_;
            star4.Image = Resources.icons8_star_30__2_;
            star5.Image = Resources.icons8_star_30__2_;
        }
    }
}
