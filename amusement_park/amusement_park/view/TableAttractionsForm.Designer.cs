namespace amusement_park.view
{
    partial class TableAttractionsForm
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
            this.dataGridViewAttractions = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttractions)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAttractions
            // 
            this.dataGridViewAttractions.BackgroundColor = System.Drawing.Color.Azure;
            this.dataGridViewAttractions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttractions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAttractions.Location = new System.Drawing.Point(0, 61);
            this.dataGridViewAttractions.Name = "dataGridViewAttractions";
            this.dataGridViewAttractions.RowHeadersWidth = 51;
            this.dataGridViewAttractions.RowTemplate.Height = 24;
            this.dataGridViewAttractions.Size = new System.Drawing.Size(1018, 530);
            this.dataGridViewAttractions.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 30);
            this.panel1.TabIndex = 5;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Teal;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDelete,
            this.toolStripAdd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1018, 31);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDelete.Image = global::amusement_park.Properties.Resources.icons8_trash_30__1_;
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(29, 24);
            this.toolStripDelete.Text = "toolStripButton1";
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAdd.Image = global::amusement_park.Properties.Resources.icons8_add_30;
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(29, 28);
            this.toolStripAdd.Text = "add info";
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
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
            this.buttonClose.Size = new System.Drawing.Size(28, 30);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // TableAttractionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 591);
            this.Controls.Add(this.dataGridViewAttractions);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableAttractionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableAttractions";
            this.Load += new System.EventHandler(this.TableAttractionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttractions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAttractions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
    }
}