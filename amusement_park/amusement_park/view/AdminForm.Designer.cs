using System.ComponentModel;

namespace amusement_park
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAttractions = new System.Windows.Forms.Label();
            this.labelUsers = new System.Windows.Forms.Label();
            this.panelUp = new System.Windows.Forms.Panel();
            this.buttonMaximiz = new System.Windows.Forms.Button();
            this.buttonMinimiz = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allTickets = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.allTickets);
            this.panel1.Controls.Add(this.labelAttractions);
            this.panel1.Controls.Add(this.labelUsers);
            this.panel1.Controls.Add(this.panelUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1088, 662);
            this.panel1.TabIndex = 2;
            // 
            // labelAttractions
            // 
            this.labelAttractions.AutoSize = true;
            this.labelAttractions.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAttractions.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelAttractions.Location = new System.Drawing.Point(647, 307);
            this.labelAttractions.Name = "labelAttractions";
            this.labelAttractions.Size = new System.Drawing.Size(157, 28);
            this.labelAttractions.TabIndex = 2;
            this.labelAttractions.Text = "аттракционы";
            this.labelAttractions.Click += new System.EventHandler(this.labelAttractions_Click);
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelUsers.Location = new System.Drawing.Point(647, 192);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(167, 28);
            this.labelUsers.TabIndex = 1;
            this.labelUsers.Text = "пользователи";
            this.labelUsers.Click += new System.EventHandler(this.labelUsers_Click);
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelUp.Controls.Add(this.buttonMaximiz);
            this.panelUp.Controls.Add(this.buttonMinimiz);
            this.panelUp.Controls.Add(this.buttonClose);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(1088, 28);
            this.panelUp.TabIndex = 0;
            this.panelUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseDown);
            this.panelUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseMove);
            // 
            // buttonMaximiz
            // 
            this.buttonMaximiz.BackColor = System.Drawing.Color.Transparent;
            this.buttonMaximiz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMaximiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMaximiz.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMaximiz.FlatAppearance.BorderSize = 0;
            this.buttonMaximiz.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMaximiz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMaximiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximiz.Image = global::amusement_park.Properties.Resources.icons8_macos_полный_экран_20__1_;
            this.buttonMaximiz.Location = new System.Drawing.Point(56, 0);
            this.buttonMaximiz.Name = "buttonMaximiz";
            this.buttonMaximiz.Size = new System.Drawing.Size(28, 28);
            this.buttonMaximiz.TabIndex = 4;
            this.buttonMaximiz.UseVisualStyleBackColor = false;
            this.buttonMaximiz.Click += new System.EventHandler(this.buttonMaximiz_Click);
            // 
            // buttonMinimiz
            // 
            this.buttonMinimiz.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimiz.BackgroundImage = global::amusement_park.Properties.Resources.icons8_macos_свернуть_20__1_;
            this.buttonMinimiz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMinimiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimiz.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonMinimiz.FlatAppearance.BorderSize = 0;
            this.buttonMinimiz.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimiz.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMinimiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimiz.Location = new System.Drawing.Point(28, 0);
            this.buttonMinimiz.Name = "buttonMinimiz";
            this.buttonMinimiz.Size = new System.Drawing.Size(28, 28);
            this.buttonMinimiz.TabIndex = 3;
            this.buttonMinimiz.UseVisualStyleBackColor = false;
            this.buttonMinimiz.Click += new System.EventHandler(this.buttonMinimiz_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::amusement_park.Properties.Resources.icons8_macos_закрыть_20__1_;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(0, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 28);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelBorder.Controls.Add(this.panel1);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(1088, 662);
            this.panelBorder.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Автор";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Тип издания";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дата выдачи/возврата";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Год издания";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 50;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Цена";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Количество";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Название";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // allTickets
            // 
            this.allTickets.AutoSize = true;
            this.allTickets.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allTickets.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.allTickets.Location = new System.Drawing.Point(647, 422);
            this.allTickets.Name = "allTickets";
            this.allTickets.Size = new System.Drawing.Size(94, 28);
            this.allTickets.TabIndex = 3;
            this.allTickets.Text = "билеты";
            this.allTickets.Click += new System.EventHandler(this.allTickets_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 662);
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelUp.ResumeLayout(false);
            this.panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Button buttonMaximiz;
        private System.Windows.Forms.Button buttonMinimiz;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Label labelAttractions;
        private System.Windows.Forms.Label allTickets;
    }
}