namespace amusement_park
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonClose = new Button();
            panelUp = new Panel();
            panelUp.SuspendLayout();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.BackgroundImage = Properties.Resources.icons8_close_20;
            buttonClose.BackgroundImageLayout = ImageLayout.Stretch;
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(441, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(30, 30);
            buttonClose.TabIndex = 0;
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // panelUp
            // 
            panelUp.Controls.Add(buttonClose);
            panelUp.Dock = DockStyle.Top;
            panelUp.Location = new Point(0, 0);
            panelUp.Name = "panelUp";
            panelUp.Size = new Size(471, 30);
            panelUp.TabIndex = 1;
            panelUp.MouseDown += panelUp_MouseDown;
            panelUp.MouseMove += panelUp_MouseMove;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 494);
            Controls.Add(panelUp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            panelUp.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonClose;
        private Panel panelUp;
    }
}