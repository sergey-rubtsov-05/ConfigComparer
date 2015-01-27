namespace ConfigComparer
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewSettings1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewRepeatedSettings1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectFirstSettingsButton = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewSettings2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewRepeatedSettings2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectSecondSettingsButton = new System.Windows.Forms.Button();
            this.fromOneToTwoFileButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshSettings1 = new System.Windows.Forms.Button();
            this.refreshSettings2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.highlightDifferentSettingsButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepeatedSettings1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepeatedSettings2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 33);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 680);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewSettings1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 654);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Основ. настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSettings1
            // 
            this.dataGridViewSettings1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSettings1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewSettings1.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSettings1.Name = "dataGridViewSettings1";
            this.dataGridViewSettings1.Size = new System.Drawing.Size(580, 642);
            this.dataGridViewSettings1.TabIndex = 1;
            this.dataGridViewSettings1.DefaultCellStyle = dataGridViewCellStyle1;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Key";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 49;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 61;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewRepeatedSettings1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Повторные настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRepeatedSettings1
            // 
            this.dataGridViewRepeatedSettings1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRepeatedSettings1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewRepeatedSettings1.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRepeatedSettings1.Name = "dataGridViewRepeatedSettings1";
            this.dataGridViewRepeatedSettings1.Size = new System.Drawing.Size(580, 642);
            this.dataGridViewRepeatedSettings1.TabIndex = 2;
            this.dataGridViewRepeatedSettings1.DefaultCellStyle = dataGridViewCellStyle1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Key";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 49;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 61;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "config files (*.config)|*.config|All files (*.*)|*.*";
            // 
            // selectFirstSettingsButton
            // 
            this.selectFirstSettingsButton.Location = new System.Drawing.Point(12, 4);
            this.selectFirstSettingsButton.Name = "selectFirstSettingsButton";
            this.selectFirstSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.selectFirstSettingsButton.TabIndex = 3;
            this.selectFirstSettingsButton.Text = "Выбрать...";
            this.selectFirstSettingsButton.UseVisualStyleBackColor = true;
            this.selectFirstSettingsButton.Click += new System.EventHandler(this.selectFirstSettingsButton_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(665, 33);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(600, 680);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewSettings2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(592, 654);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Основ. настройки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSettings2
            // 
            this.dataGridViewSettings2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSettings2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSettings2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSettings2.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewSettings2.Name = "dataGridViewSettings2";
            this.dataGridViewSettings2.Size = new System.Drawing.Size(580, 642);
            this.dataGridViewSettings2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 49;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 61;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewRepeatedSettings2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(592, 654);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Повторные настройки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRepeatedSettings2
            // 
            this.dataGridViewRepeatedSettings2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRepeatedSettings2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridViewRepeatedSettings2.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewRepeatedSettings2.Name = "dataGridViewRepeatedSettings2";
            this.dataGridViewRepeatedSettings2.Size = new System.Drawing.Size(580, 642);
            this.dataGridViewRepeatedSettings2.TabIndex = 2;
            this.dataGridViewRepeatedSettings2.DefaultCellStyle = dataGridViewCellStyle1;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Key";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 49;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 61;
            // 
            // selectSecondSettingsButton
            // 
            this.selectSecondSettingsButton.Location = new System.Drawing.Point(665, 4);
            this.selectSecondSettingsButton.Name = "selectSecondSettingsButton";
            this.selectSecondSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.selectSecondSettingsButton.TabIndex = 5;
            this.selectSecondSettingsButton.Text = "Выбрать...";
            this.selectSecondSettingsButton.UseVisualStyleBackColor = true;
            this.selectSecondSettingsButton.Click += new System.EventHandler(this.selectSecondSettingsButton_Click);
            // 
            // fromOneToTwoFileButton
            // 
            this.fromOneToTwoFileButton.Location = new System.Drawing.Point(618, 196);
            this.fromOneToTwoFileButton.Name = "fromOneToTwoFileButton";
            this.fromOneToTwoFileButton.Size = new System.Drawing.Size(41, 23);
            this.fromOneToTwoFileButton.TabIndex = 6;
            this.fromOneToTwoFileButton.Text = ">>";
            this.fromOneToTwoFileButton.UseVisualStyleBackColor = true;
            this.fromOneToTwoFileButton.Click += new System.EventHandler(this.fromOneToTwoFileButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(1284, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(175, 199);
            this.listBox1.TabIndex = 8;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1284, 260);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1281, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Неиспользуемые настройки:";
            // 
            // refreshSettings1
            // 
            this.refreshSettings1.Image = ((System.Drawing.Image)(resources.GetObject("refreshSettings1.Image")));
            this.refreshSettings1.Location = new System.Drawing.Point(93, 4);
            this.refreshSettings1.Name = "refreshSettings1";
            this.refreshSettings1.Size = new System.Drawing.Size(24, 24);
            this.refreshSettings1.TabIndex = 11;
            this.refreshSettings1.UseVisualStyleBackColor = true;
            this.refreshSettings1.Click += new System.EventHandler(this.refreshSettings1_Click);
            // 
            // refreshSettings2
            // 
            this.refreshSettings2.Image = ((System.Drawing.Image)(resources.GetObject("refreshSettings2.Image")));
            this.refreshSettings2.Location = new System.Drawing.Point(746, 4);
            this.refreshSettings2.Name = "refreshSettings2";
            this.refreshSettings2.Size = new System.Drawing.Size(24, 24);
            this.refreshSettings2.TabIndex = 12;
            this.refreshSettings2.UseVisualStyleBackColor = true;
            this.refreshSettings2.Click += new System.EventHandler(this.refreshSettings2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 13;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(776, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 14;
            // 
            // highlightDifferentSettingsButton
            // 
            this.highlightDifferentSettingsButton.Location = new System.Drawing.Point(618, 167);
            this.highlightDifferentSettingsButton.Name = "highlightDifferentSettingsButton";
            this.highlightDifferentSettingsButton.Size = new System.Drawing.Size(41, 23);
            this.highlightDifferentSettingsButton.TabIndex = 15;
            this.highlightDifferentSettingsButton.Text = "=";
            this.highlightDifferentSettingsButton.UseVisualStyleBackColor = true;
            this.highlightDifferentSettingsButton.Click += new System.EventHandler(this.highlightDifferentSettingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 721);
            this.Controls.Add(this.highlightDifferentSettingsButton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshSettings2);
            this.Controls.Add(this.refreshSettings1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fromOneToTwoFileButton);
            this.Controls.Add(this.selectSecondSettingsButton);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.selectFirstSettingsButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ConfigComparer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepeatedSettings1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSettings2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRepeatedSettings2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewSettings1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewRepeatedSettings1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectFirstSettingsButton;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewSettings2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewRepeatedSettings2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Button selectSecondSettingsButton;
        private System.Windows.Forms.Button fromOneToTwoFileButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshSettings1;
        private System.Windows.Forms.Button refreshSettings2;
        private System.Windows.Forms.LinkLabel label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button highlightDifferentSettingsButton;


    }
}

