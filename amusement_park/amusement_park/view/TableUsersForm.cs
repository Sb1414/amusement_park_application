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
                // Получаем логин выбранного пользователя
                string userLogin = currentRow.Cells[1].Value.ToString();

                // Проверяем, что выбранный пользователь не админ с логином "admin"
                if (userLogin == "admin")
                {
                    MessageBox.Show("Нельзя удалить пользователя 'admin'.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Не выполняем удаление
                }

                if (DeleteUser(userLogin))
                {
                    loadTable();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeleteUser(string login)
        {
            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        // Получаем ID пользователя по логину
                        string getUserIdQuery = "SELECT id FROM users WHERE login = @login";
                        int userId;
                        using (SQLiteCommand cmdGetUserId = new SQLiteCommand(getUserIdQuery, connection, transaction))
                        {
                            cmdGetUserId.Parameters.AddWithValue("@login", login);
                            userId = Convert.ToInt32(cmdGetUserId.ExecuteScalar());
                        }

                        // Удаление пользователя из таблицы users
                        string deleteUserQuery = "DELETE FROM users WHERE login = @login";
                        using (SQLiteCommand cmdDeleteUser = new SQLiteCommand(deleteUserQuery, connection, transaction))
                        {
                            cmdDeleteUser.Parameters.AddWithValue("@login", login);
                            cmdDeleteUser.ExecuteNonQuery();
                        }

                        // Удаление записей пользователя из таблицы persons по user_id
                        string deletePersonQuery = "DELETE FROM persons WHERE user_id = @userId";
                        using (SQLiteCommand cmdDeletePerson = new SQLiteCommand(deletePersonQuery, connection, transaction))
                        {
                            cmdDeletePerson.Parameters.AddWithValue("@userId", userId);
                            cmdDeletePerson.ExecuteNonQuery();
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
            if (currentRow.Cells[1].Value != null && !string.IsNullOrEmpty(currentRow.Cells[1].Value.ToString()))
            {
                // Получаем логин выбранного пользователя
                string userLogin = currentRow.Cells[1].Value.ToString();

                // Создайте и отобразите форму для изменения пароля
                ChangePasswordForm changePasswordForm = new ChangePasswordForm();
                changePasswordForm.TopMost = true;

                if (changePasswordForm.ShowDialog() == DialogResult.OK)
                {
                    // Получите новый пароль из формы изменения пароля
                    string newPassword = changePasswordForm.NewPassword;

                    // Обновите пароль пользователя в базе данных
                    if (UpdatePassword(newPassword, userLogin))
                    {
                        // Обновление успешно завершено, теперь обновляем данные в DataGridView
                        currentRow.Cells[2].Value = newPassword;

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

        private bool UpdatePassword(string newPassword, string login)
        {
            try
            {
                string connectionString = "Data Source=sb.db;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // SQL-запрос для обновления пароля пользователя по логину
                    string query = "UPDATE users SET password = @newPassword WHERE login = @userLogin";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@userLogin", login);
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

        private void toolStripDeleteAll_Click(object sender, EventArgs e)
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

    }
}
