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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
            buttonSave.DialogResult = DialogResult.OK;
            this.AcceptButton = buttonSave;
        }

        public string NewPassword
        {
            get { return textBoxNewPass.Text; }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNewPassAgain_TextChanged(object sender, EventArgs e)
        {
            // Вызываем метод для проверки соответствия паролей при изменении текста в textBoxNewPassAgain
            CheckPasswordsMatch();
        }

        private void CheckPasswordsMatch()
        {
            string newPassword = textBoxNewPass.Text;
            string newPasswordAgain = textBoxNewPassAgain.Text;

            // Проверяем, что пароли совпадают
            if (newPassword != newPasswordAgain)
            {
                labelInfo.Text = "Пароли не совпадают";
                labelInfo.ForeColor = Color.Red;
                buttonSave.Enabled = false; // Отключаем кнопку сохранения
            }
            else
            {
                labelInfo.Text = "";
                buttonSave.Enabled = true; // Включаем кнопку сохранения
            }
        }
    }

}
