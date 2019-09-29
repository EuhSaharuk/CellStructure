namespace Cube_V11
{
    partial class ResearchNAngleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clearLog = new System.Windows.Forms.Button();
            this.clearAllActions = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.deleteResearch4 = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.startResearch4 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.acceptButton4 = new System.Windows.Forms.Button();
            this.strenghtRadioButton4 = new System.Windows.Forms.RadioButton();
            this.fixRadioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bodyPartsComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.clearLog);
            this.groupBox1.Controls.Add(this.clearAllActions);
            this.groupBox1.Controls.Add(this.logTextBox);
            this.groupBox1.Controls.Add(this.deleteResearch4);
            this.groupBox1.Controls.Add(this.cancel);
            this.groupBox1.Controls.Add(this.startResearch4);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.bodyPartsComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1045, 275);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(375, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(664, 144);
            this.dataGridView1.TabIndex = 39;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Количество ячеек";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Напряжение";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Деформация";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Разность Напряжения";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "% Напряжения";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Разность Деформации";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "% Деформации";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(375, 16);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(399, 21);
            this.clearLog.TabIndex = 38;
            this.clearLog.Text = "Очистить";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.clearLog_Click);
            // 
            // clearAllActions
            // 
            this.clearAllActions.Location = new System.Drawing.Point(190, 192);
            this.clearAllActions.Name = "clearAllActions";
            this.clearAllActions.Size = new System.Drawing.Size(180, 39);
            this.clearAllActions.TabIndex = 37;
            this.clearAllActions.Text = "Отменить все";
            this.clearAllActions.UseVisualStyleBackColor = true;
            this.clearAllActions.Click += new System.EventHandler(this.clearAllActions_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(375, 43);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(399, 76);
            this.logTextBox.TabIndex = 33;
            // 
            // deleteResearch4
            // 
            this.deleteResearch4.Location = new System.Drawing.Point(190, 236);
            this.deleteResearch4.Name = "deleteResearch4";
            this.deleteResearch4.Size = new System.Drawing.Size(179, 33);
            this.deleteResearch4.TabIndex = 36;
            this.deleteResearch4.Text = "Удалить исследование";
            this.deleteResearch4.UseVisualStyleBackColor = true;
            this.deleteResearch4.Click += new System.EventHandler(this.deleteResearch4_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(190, 146);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(180, 42);
            this.cancel.TabIndex = 35;
            this.cancel.Text = "Отменить действие";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // startResearch4
            // 
            this.startResearch4.Location = new System.Drawing.Point(6, 236);
            this.startResearch4.Name = "startResearch4";
            this.startResearch4.Size = new System.Drawing.Size(178, 33);
            this.startResearch4.TabIndex = 34;
            this.startResearch4.Text = "Запустить исследование";
            this.startResearch4.UseVisualStyleBackColor = true;
            this.startResearch4.Click += new System.EventHandler(this.startResearch4_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.acceptButton4);
            this.groupBox7.Controls.Add(this.strenghtRadioButton4);
            this.groupBox7.Controls.Add(this.fixRadioButton4);
            this.groupBox7.Controls.Add(this.textBox13);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Location = new System.Drawing.Point(9, 64);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(345, 79);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Действия";
            // 
            // acceptButton4
            // 
            this.acceptButton4.Location = new System.Drawing.Point(168, 16);
            this.acceptButton4.Name = "acceptButton4";
            this.acceptButton4.Size = new System.Drawing.Size(163, 27);
            this.acceptButton4.TabIndex = 10;
            this.acceptButton4.Text = "Приложить силу";
            this.acceptButton4.UseVisualStyleBackColor = true;
            this.acceptButton4.Click += new System.EventHandler(this.acceptButton4_Click);
            // 
            // strenghtRadioButton4
            // 
            this.strenghtRadioButton4.AutoSize = true;
            this.strenghtRadioButton4.Location = new System.Drawing.Point(10, 46);
            this.strenghtRadioButton4.Name = "strenghtRadioButton4";
            this.strenghtRadioButton4.Size = new System.Drawing.Size(128, 21);
            this.strenghtRadioButton4.TabIndex = 9;
            this.strenghtRadioButton4.Text = "Приложить силу";
            this.strenghtRadioButton4.UseVisualStyleBackColor = true;
            this.strenghtRadioButton4.CheckedChanged += new System.EventHandler(this.strenghtRadioButton4_CheckedChanged);
            // 
            // fixRadioButton4
            // 
            this.fixRadioButton4.AutoSize = true;
            this.fixRadioButton4.Checked = true;
            this.fixRadioButton4.Location = new System.Drawing.Point(10, 22);
            this.fixRadioButton4.Name = "fixRadioButton4";
            this.fixRadioButton4.Size = new System.Drawing.Size(120, 21);
            this.fixRadioButton4.TabIndex = 8;
            this.fixRadioButton4.TabStop = true;
            this.fixRadioButton4.Text = "Зафиксировать";
            this.fixRadioButton4.UseVisualStyleBackColor = true;
            this.fixRadioButton4.CheckedChanged += new System.EventHandler(this.fixRadioButton4_CheckedChanged);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(231, 48);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(100, 25);
            this.textBox13.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(165, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 17);
            this.label19.TabIndex = 5;
            this.label19.Text = "Сила";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 17);
            this.label16.TabIndex = 24;
            this.label16.Text = "Стороны";
            // 
            // bodyPartsComboBox
            // 
            this.bodyPartsComboBox.FormattingEnabled = true;
            this.bodyPartsComboBox.Location = new System.Drawing.Point(80, 24);
            this.bodyPartsComboBox.Name = "bodyPartsComboBox";
            this.bodyPartsComboBox.Size = new System.Drawing.Size(163, 25);
            this.bodyPartsComboBox.TabIndex = 23;
            this.bodyPartsComboBox.SelectedIndexChanged += new System.EventHandler(this.bodyPartsComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Создать исследование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Плотность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(782, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "tl";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(863, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 25);
            this.textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(863, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 25);
            this.textBox2.TabIndex = 43;
            // 
            // ResearchNAngleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 339);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ResearchNAngleForm";
            this.Text = "ResearchNAngel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button clearLog;
        private System.Windows.Forms.Button clearAllActions;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button deleteResearch4;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button startResearch4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button acceptButton4;
        private System.Windows.Forms.RadioButton strenghtRadioButton4;
        private System.Windows.Forms.RadioButton fixRadioButton4;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox bodyPartsComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}