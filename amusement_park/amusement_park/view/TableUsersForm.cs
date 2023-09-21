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
        public TableUsersForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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


            string connectionString = "Data Source=sb.db;Version=3;";

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

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли какая-либо строка в DataGridView
            DataGridViewRow currentRow = dataGridViewUsers.CurrentRow;
            if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value != "")
            {
                // Получаем ID выбранного пользователя
                int userId = Convert.ToInt32(currentRow.Cells[0].Value);
                string userLogin = currentRow.Cells[1].Value.ToString();

                // Проверяем, что выбранный пользователь не админ с логином "admin"
                if (userLogin == "admin")
                {
                    MessageBox.Show("Нельзя удалить пользователя 'admin'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Не выполняем удаление
                }

                if (DeleteUser(userId))
                {
                    loadTable();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeleteUser(int userId)
        {
            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        // Удаление пользователя из таблицы users
                        string deleteUserQuery = "DELETE FROM users WHERE id = @userId";
                        using (SQLiteCommand cmdDeleteUser = new SQLiteCommand(deleteUserQuery, connection, transaction))
                        {
                            cmdDeleteUser.Parameters.AddWithValue("@userId", userId);
                            cmdDeleteUser.ExecuteNonQuery();
                        }

                        // Обновление ID всех остальных пользователей
                        string updateIdQuery = "UPDATE users SET id = id - 1 WHERE id > @userId";
                        using (SQLiteCommand cmdUpdateId = new SQLiteCommand(updateIdQuery, connection, transaction))
                        {
                            cmdUpdateId.Parameters.AddWithValue("@userId", userId);
                            cmdUpdateId.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                return true; // Успешно удален пользователь и обновлены ID
            }
            catch
            {
                return false; // Ошибка при удалении пользователя или обновлении ID
            }
        }


        private void toolStripChange_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли какая-либо строка в DataGridView
            DataGridViewRow currentRow = dataGridViewUsers.CurrentRow;
            if (currentRow.Cells[0].Value != null && currentRow.Cells[0].Value != "")
            {
                // Получаем ID выбранного пользователя
                int userId = Convert.ToInt32(currentRow.Cells[0].Value);
                // Создайте и отобразите форму для изменения пароля
                ChangePasswordForm changePasswordForm = new ChangePasswordForm();
                changePasswordForm.TopMost = true;

                if (changePasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // Получите новый пароль из формы изменения пароля
                    string newPassword = changePasswordForm.NewPassword;

                    // Обновите пароль пользователя в базе данных
                    if (UpdatePassword(newPassword, userId))
                    {
                        // Обновление успешно завершено, теперь обновляем данные в DataGridView
                        dataGridViewUsers.Rows[currentRow.Index].Cells[2].Value = newPassword;

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

        private bool UpdatePassword(string newPassword, int id)
        {

            if (id == -1)
            {
                return false; // Невозможно определить текущего пользователя
            }

            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для обновления пароля пользователя
                    string query = "UPDATE users SET password = @newPassword WHERE id = @userId";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@userId", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true; // Успешно обновлен пароль
            }
            catch
            {
                return false; // Ошибка при обновлении пароля
            }
        }


    }
}
