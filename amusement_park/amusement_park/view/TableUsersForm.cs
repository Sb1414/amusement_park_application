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
    public partial class TableUsersForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public TableUsersForm()
        {
            InitializeComponent();
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

        private void TableUsersForm_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void loadTable()
        {
            // для хранения данных
            DataTable dt = new DataTable();

            dataGridViewUsers.AutoGenerateColumns = false;

            // столбцы для DataGridView

            DataGridViewColumn loginColumn = new DataGridViewTextBoxColumn();
            loginColumn.DataPropertyName = "login";
            loginColumn.HeaderText = "Login";
            dataGridViewUsers.Columns.Add(loginColumn);

            DataGridViewColumn passwordColumn = new DataGridViewTextBoxColumn();
            passwordColumn.DataPropertyName = "password";
            passwordColumn.HeaderText = "Password";
            dataGridViewUsers.Columns.Add(passwordColumn);

            DataGridViewColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.HeaderText = "Name";
            dataGridViewUsers.Columns.Add(nameColumn);

            DataGridViewColumn surnameColumn = new DataGridViewTextBoxColumn();
            surnameColumn.DataPropertyName = "surname";
            surnameColumn.HeaderText = "Surname";
            dataGridViewUsers.Columns.Add(surnameColumn);

            DataGridViewColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "date";
            dateColumn.HeaderText = "Date";
            dataGridViewUsers.Columns.Add(dateColumn);

            DataGridViewColumn emailColumn = new DataGridViewTextBoxColumn();
            emailColumn.DataPropertyName = "email";
            emailColumn.HeaderText = "Email";
            dataGridViewUsers.Columns.Add(emailColumn);


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для получения данных из таблицы User и Person
                string query = "SELECT u.login, u.password, p.name, p.surname, p.date, p.email " +
                    "FROM users u INNER JOIN persons p ON u.id = p.user_id";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }

            dataGridViewUsers.DataSource = dt;
        }

        private bool DeleteUser(string login)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        string getUserIdQuery = "SELECT id FROM users WHERE login = @login";
                        int userId;
                        using (SQLiteCommand cmdGetUserId = new SQLiteCommand(getUserIdQuery, connection, transaction))
                        {
                            cmdGetUserId.Parameters.AddWithValue("@login", login);
                            userId = Convert.ToInt32(cmdGetUserId.ExecuteScalar());
                        }

                        string deleteUserQuery = "DELETE FROM users WHERE login = @login";
                        using (SQLiteCommand cmdDeleteUser = new SQLiteCommand(deleteUserQuery, connection, transaction))
                        {
                            cmdDeleteUser.Parameters.AddWithValue("@login", login);
                            cmdDeleteUser.ExecuteNonQuery();
                        }

                        string deletePersonQuery = "DELETE FROM persons WHERE user_id = @userId";
                        using (SQLiteCommand cmdDeletePerson = new SQLiteCommand(deletePersonQuery, connection, transaction))
                        {
                            cmdDeletePerson.Parameters.AddWithValue("@userId", userId);
                            cmdDeletePerson.ExecuteNonQuery();
                        }

                        string updateIdQuery = "UPDATE users SET id = id - 1 WHERE id > @userId";
                        using (SQLiteCommand cmdUpdateId = new SQLiteCommand(updateIdQuery, connection, transaction))
                        {
                            cmdUpdateId.Parameters.AddWithValue("@userId", userId);
                            cmdUpdateId.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdatePassword(string newPassword, string login)
        {
            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // обновления пароля пользователя по логину
                    string query = "UPDATE users SET password = @newPassword WHERE login = @userLogin";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@userLogin", login);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool DeleteAllRecords()
        {
            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        string deletePersonsQuery = "DELETE FROM persons";
                        using (SQLiteCommand cmdDeletePersons = new SQLiteCommand(deletePersonsQuery, connection, transaction))
                        {
                            cmdDeletePersons.ExecuteNonQuery();
                        }

                        string deleteUsersQuery = "DELETE FROM users";
                        using (SQLiteCommand cmdDeleteUsers = new SQLiteCommand(deleteUsersQuery, connection, transaction))
                        {
                            cmdDeleteUsers.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
                this.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void toolStripButtonDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить все записи из таблицы?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (DeleteAllRecords())
                {
                    dataGridViewUsers.Columns.Clear();
                    loadTable();
                }
            }
        }

        private void toolStripButtonChange_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridViewUsers.CurrentRow;
            if (currentRow.Cells[1].Value != null && !string.IsNullOrEmpty(currentRow.Cells[1].Value.ToString()))
            {
                string userLogin = currentRow.Cells[1].Value.ToString();

                ChangePasswordForm changePasswordForm = new ChangePasswordForm();
                changePasswordForm.TopMost = true;

                if (changePasswordForm.ShowDialog() == DialogResult.OK)
                {
                    string newPassword = changePasswordForm.NewPassword;

                    if (UpdatePassword(newPassword, userLogin))
                    {
                        currentRow.Cells[1].Value = newPassword;

                        MessageBox.Show("Пароль успешно изменен.", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при изменении пароля.", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для изменения пароля.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            // выбрана ли какая-либо строка в DataGridView
            DataGridViewRow currentRow = dataGridViewUsers.CurrentRow;
            if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value != "")
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string userLogin = currentRow.Cells[1].Value.ToString();

                    // проверка что это не админ с логином "admin"
                    if (userLogin == "admin")
                    {
                        MessageBox.Show("Нельзя удалить пользователя 'admin'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (DeleteUser(userLogin))
                    {
                        loadTable();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
