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
    public partial class AddAttractionForm : Form
    {
        public AddAttractionForm()
        {
            InitializeComponent();
            buttonSave.DialogResult = DialogResult.OK;
            this.AcceptButton = buttonSave;

            textBoxName.Text = "Название аттракциона";
            textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxDescription.Text = "Описание";
            textBoxDescription.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxCapacity.Text = "Вместимость (человек)";
            textBoxCapacity.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxTicketPrice.Text = "Цена с человека";
            textBoxTicketPrice.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxTimeWork.Text = "Время одного проката";
            textBoxTimeWork.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxLimit.Text = "Ограничение в возрасте";
            textBoxLimit.ForeColor = Color.FromArgb(127, 128, 132);
        }

        public string NameAttraction
        {
            get { return textBoxName.Text; }
        }

        public string Description
        {
            get { return textBoxDescription.Text; }
        }

        public string Capacity
        {
            get { return textBoxCapacity.Text; }
        }

        public string TicketPrice
        {
            get { return textBoxTicketPrice.Text; }
        }

        public string TimeWork
        {
            get { return textBoxTimeWork.Text; }
        }

        public string Limit
        {
            get { return textBoxLimit.Text; }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }
    }
}
