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
    public partial class AddAttractionForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
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
            // Получаем данные из формы
            string name = textBoxName.Text;
            string description = textBoxDescription.Text;
            int capacity = Convert.ToInt32(textBoxCapacity.Text);
            int ticketPrice = Convert.ToInt32(textBoxTicketPrice.Text);
            int timeWork = Convert.ToInt32(textBoxTimeWork.Text);
            string limit = textBoxLimit.Text;

            // в таблицу attractions
            string insertAttractionQuery = "INSERT INTO attractions (name, description, capacity, ticket_price, time_work) " +
                                           "VALUES (@name, @description, @capacity, @ticketPrice, @timeWork)";

            // в таблицу limitations
            string insertLimitationQuery = "INSERT INTO limitations (attraction_id, age_person) " +
                                          "VALUES (@attractionId, @limit)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand cmdAttraction = new SQLiteCommand(insertAttractionQuery, connection))
                    {
                        cmdAttraction.Parameters.AddWithValue("@name", name);
                        cmdAttraction.Parameters.AddWithValue("@description", description);
                        cmdAttraction.Parameters.AddWithValue("@capacity", capacity);
                        cmdAttraction.Parameters.AddWithValue("@ticketPrice", ticketPrice);
                        cmdAttraction.Parameters.AddWithValue("@timeWork", timeWork);
                        cmdAttraction.ExecuteNonQuery();
                    }

                    // id только что добавленного аттракциона
                    long lastRowId = connection.LastInsertRowId;

                    // Если ограничение было введено, вставляем его
                    if (!string.IsNullOrWhiteSpace(limit))
                    {
                        using (SQLiteCommand cmdLimit = new SQLiteCommand(insertLimitationQuery, connection))
                        {
                            cmdLimit.Parameters.AddWithValue("@attractionId", lastRowId);
                            cmdLimit.Parameters.AddWithValue("@limit", limit);
                            cmdLimit.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Проверяем, является ли символ буквой английской или русской раскладки,
            // пробелом или клавишей Backspace (для удаления символов)
            if (!char.IsLetter(inputChar) && !char.IsWhiteSpace(inputChar) &&
                (inputChar < 'А' || inputChar > 'я') && (inputChar < 'A' || inputChar > 'z') &&
                inputChar != '\b')
            {
                // Если символ не соответствует разрешенным символам, отменяем ввод
                e.Handled = true;
            }
        }


        private void textBoxCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            // Проверяем, является ли символ цифрой или клавишей Backspace (для удаления символов)
            if (!char.IsDigit(inputChar) && inputChar != '\b')
            {
                e.Handled = true;
            }
        }

        private bool plusEntered = false; // Флаг для отслеживания ввода символа '+'

        private void textBoxLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            if (!char.IsDigit(inputChar) && (inputChar != '+' || plusEntered) && inputChar != '\b')
            {
                // Если символ не соответствует маске или символ '+' уже присутствует, отменяем ввод
                e.Handled = true;
            }

            if (inputChar == '+')
            {
                plusEntered = true;
            }
        }


        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Название аттракциона")
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
                textBoxName.Text = "Название аттракциона";
                textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxDescription_Enter(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "Описание")
            {
                textBoxDescription.Text = "";
                textBoxDescription.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backPassClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "")
            {
                textBoxDescription.Text = "Описание";
                textBoxDescription.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxCapacity_Enter(object sender, EventArgs e)
        {
            if (textBoxCapacity.Text == "Вместимость (человек)")
            {
                textBoxCapacity.Text = "";
                textBoxCapacity.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backLogClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxCapacity_Leave(object sender, EventArgs e)
        {
            if (textBoxCapacity.Text == "")
            {
                textBoxCapacity.Text = "Вместимость (человек)";
                textBoxCapacity.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxTicketPrice_Enter(object sender, EventArgs e)
        {
            if (textBoxTicketPrice.Text == "Цена с человека")
            {
                textBoxTicketPrice.Text = "";
                textBoxTicketPrice.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backPassClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxTicketPrice_Leave(object sender, EventArgs e)
        {
            if (textBoxTicketPrice.Text == "")
            {
                textBoxTicketPrice.Text = "Цена с человека";
                textBoxTicketPrice.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxTimeWork_Enter(object sender, EventArgs e)
        {
            if (textBoxTimeWork.Text == "Время одного проката")
            {
                textBoxTimeWork.Text = "";
                textBoxTimeWork.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backLogClick;
            labelInfo.Text = "";
        }

        private void textBoxTimeWork_Leave(object sender, EventArgs e)
        {
            if (textBoxTimeWork.Text == "")
            {
                textBoxTimeWork.Text = "Время одного проката";
                textBoxTimeWork.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxLimit_Enter(object sender, EventArgs e)
        {
            if (textBoxLimit.Text == "Ограничение в возрасте")
            {
                textBoxLimit.Text = "";
                textBoxLimit.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backLogClick;
            labelInfo.Text = "";
        }

        private void textBoxLimit_Leave(object sender, EventArgs e)
        {
            if (textBoxLimit.Text == "")
            {
                textBoxLimit.Text = "Ограничение в возрасте";
                textBoxLimit.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel5.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }
    }
}
