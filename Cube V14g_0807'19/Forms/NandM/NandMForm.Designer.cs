namespace Cube_V11
{
    partial class NandMForm
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
            this.calculateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FreeRadioButton = new System.Windows.Forms.RadioButton();
            this.SquareMatrixRadioButton = new System.Windows.Forms.RadioButton();
            this.TwoInNRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.loopBuildRadioButton = new System.Windows.Forms.RadioButton();
            this.singleBuildRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.calculateButton.Location = new System.Drawing.Point(221, 22);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(174, 29);
            this.calculateButton.TabIndex = 0;
            this.calculateButton.Text = "Высчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label1.Location = new System.Drawing.Point(158, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество столбцов";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox1.Location = new System.Drawing.Point(306, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(59, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "3";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox2.Location = new System.Drawing.Point(306, 55);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 25);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label2.Location = new System.Drawing.Point(158, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество строк";
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.resultBox.Location = new System.Drawing.Point(401, 66);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(247, 221);
            this.resultBox.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox3.Location = new System.Drawing.Point(173, 328);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "60";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label3.Location = new System.Drawing.Point(12, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Часть от объёма (%)";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox4.Location = new System.Drawing.Point(548, 26);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 25);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label4.Location = new System.Drawing.Point(400, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Знаков после запятой";
            // 
            // drawButton
            // 
            this.drawButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.drawButton.Location = new System.Drawing.Point(221, 63);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(174, 29);
            this.drawButton.TabIndex = 10;
            this.drawButton.Text = "Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.deleteButton.Location = new System.Drawing.Point(221, 101);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(174, 29);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FreeRadioButton);
            this.groupBox1.Controls.Add(this.SquareMatrixRadioButton);
            this.groupBox1.Controls.Add(this.TwoInNRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 118);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид ячеистой структуры";
            // 
            // FreeRadioButton
            // 
            this.FreeRadioButton.AutoSize = true;
            this.FreeRadioButton.Checked = true;
            this.FreeRadioButton.Location = new System.Drawing.Point(14, 78);
            this.FreeRadioButton.Name = "FreeRadioButton";
            this.FreeRadioButton.Size = new System.Drawing.Size(147, 21);
            this.FreeRadioButton.TabIndex = 2;
            this.FreeRadioButton.TabStop = true;
            this.FreeRadioButton.Text = "Свободное задание";
            this.FreeRadioButton.UseVisualStyleBackColor = true;
            this.FreeRadioButton.CheckedChanged += new System.EventHandler(this.FreeRadioButton_CheckedChanged);
            // 
            // SquareMatrixRadioButton
            // 
            this.SquareMatrixRadioButton.AutoSize = true;
            this.SquareMatrixRadioButton.Location = new System.Drawing.Point(14, 51);
            this.SquareMatrixRadioButton.Name = "SquareMatrixRadioButton";
            this.SquareMatrixRadioButton.Size = new System.Drawing.Size(156, 21);
            this.SquareMatrixRadioButton.TabIndex = 1;
            this.SquareMatrixRadioButton.Text = "Квадратная матрица";
            this.SquareMatrixRadioButton.UseVisualStyleBackColor = true;
            this.SquareMatrixRadioButton.CheckedChanged += new System.EventHandler(this.SquareMatrixRadioButton_CheckedChanged);
            // 
            // TwoInNRadioButton
            // 
            this.TwoInNRadioButton.AutoSize = true;
            this.TwoInNRadioButton.Location = new System.Drawing.Point(14, 24);
            this.TwoInNRadioButton.Name = "TwoInNRadioButton";
            this.TwoInNRadioButton.Size = new System.Drawing.Size(46, 21);
            this.TwoInNRadioButton.TabIndex = 0;
            this.TwoInNRadioButton.Text = "2^n";
            this.TwoInNRadioButton.UseVisualStyleBackColor = true;
            this.TwoInNRadioButton.CheckedChanged += new System.EventHandler(this.TwoInNRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.stepTextBox);
            this.groupBox2.Controls.Add(this.loopBuildRadioButton);
            this.groupBox2.Controls.Add(this.singleBuildRadioButton);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.groupBox2.Location = new System.Drawing.Point(12, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 186);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки ячеистой структуры";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label6.Location = new System.Drawing.Point(158, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Конечный столбец";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox5.Location = new System.Drawing.Point(306, 86);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(59, 25);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label5.Location = new System.Drawing.Point(158, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Шаг";
            // 
            // stepTextBox
            // 
            this.stepTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.stepTextBox.Location = new System.Drawing.Point(306, 117);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(59, 25);
            this.stepTextBox.TabIndex = 8;
            this.stepTextBox.Text = "1";
            // 
            // loopBuildRadioButton
            // 
            this.loopBuildRadioButton.AutoSize = true;
            this.loopBuildRadioButton.Location = new System.Drawing.Point(14, 60);
            this.loopBuildRadioButton.Name = "loopBuildRadioButton";
            this.loopBuildRadioButton.Size = new System.Drawing.Size(107, 38);
            this.loopBuildRadioButton.TabIndex = 6;
            this.loopBuildRadioButton.Text = "Циклическое\r\nпостроение";
            this.loopBuildRadioButton.UseVisualStyleBackColor = true;
            this.loopBuildRadioButton.CheckedChanged += new System.EventHandler(this.loopRadioButton_CheckedChanged);
            // 
            // singleBuildRadioButton
            // 
            this.singleBuildRadioButton.AutoSize = true;
            this.singleBuildRadioButton.Checked = true;
            this.singleBuildRadioButton.Location = new System.Drawing.Point(14, 16);
            this.singleBuildRadioButton.Name = "singleBuildRadioButton";
            this.singleBuildRadioButton.Size = new System.Drawing.Size(97, 38);
            this.singleBuildRadioButton.TabIndex = 5;
            this.singleBuildRadioButton.TabStop = true;
            this.singleBuildRadioButton.Text = "Единичное \r\nпостроение";
            this.singleBuildRadioButton.UseVisualStyleBackColor = true;
            this.singleBuildRadioButton.CheckedChanged += new System.EventHandler(this.singleRadioBurron_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button1.Location = new System.Drawing.Point(401, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "Исследование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(338, 34);
            this.label7.TabIndex = 11;
            this.label7.Text = "Внимание: Циклическое построение работает только\r\nпри циклическом вычислении и пр" +
    "и исследовании";
            this.label7.Visible = false;
            // 
            // NandMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 364);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.calculateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NandMForm";
            this.Text = "NandMForm";
            this.Load += new System.EventHandler(this.NandMForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton FreeRadioButton;
        private System.Windows.Forms.RadioButton SquareMatrixRadioButton;
        private System.Windows.Forms.RadioButton TwoInNRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton loopBuildRadioButton;
        private System.Windows.Forms.RadioButton singleBuildRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}