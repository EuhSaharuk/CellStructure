namespace Cube_V11
{
    partial class NAngleEmprovedForm
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawButton = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.volumeStartTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.angleNumStartTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.difflectAngleStartTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.loopBuildRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.angleEndTextBox = new System.Windows.Forms.TextBox();
            this.difflectAngleEndTextBox = new System.Windows.Forms.TextBox();
            this.volumeEndTextBox = new System.Windows.Forms.TextBox();
            this.difflectionStepTextBox = new System.Windows.Forms.TextBox();
            this.angleStepTextBox = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.deleteButton.Location = new System.Drawing.Point(456, 91);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(149, 35);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawButton
            // 
            this.drawButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.drawButton.Location = new System.Drawing.Point(456, 51);
            this.drawButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(149, 35);
            this.drawButton.TabIndex = 18;
            this.drawButton.Text = "Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox4.Location = new System.Drawing.Point(786, 15);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 25);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label4.Location = new System.Drawing.Point(610, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Знаков после запятой";
            // 
            // volumeStartTextBox
            // 
            this.volumeStartTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.volumeStartTextBox.Location = new System.Drawing.Point(190, 129);
            this.volumeStartTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.volumeStartTextBox.Name = "volumeStartTextBox";
            this.volumeStartTextBox.Size = new System.Drawing.Size(62, 25);
            this.volumeStartTextBox.TabIndex = 15;
            this.volumeStartTextBox.Text = "40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label3.Location = new System.Drawing.Point(22, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Часть от объёма (%)";
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.resultBox.Location = new System.Drawing.Point(613, 51);
            this.resultBox.Margin = new System.Windows.Forms.Padding(4);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(305, 253);
            this.resultBox.TabIndex = 13;
            // 
            // calculateButton
            // 
            this.calculateButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.calculateButton.Location = new System.Drawing.Point(456, 13);
            this.calculateButton.Margin = new System.Windows.Forms.Padding(4);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(149, 35);
            this.calculateButton.TabIndex = 12;
            this.calculateButton.Text = "Высчитать";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox1.Location = new System.Drawing.Point(261, 55);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 25);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Степень";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label2.Location = new System.Drawing.Point(22, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Высота ячейки";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox2.Location = new System.Drawing.Point(175, 3);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 25);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "14,5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label5.Location = new System.Drawing.Point(22, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 24;
            this.label5.Text = "Количество углов";
            // 
            // angleNumStartTextBox
            // 
            this.angleNumStartTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.angleNumStartTextBox.Location = new System.Drawing.Point(175, 55);
            this.angleNumStartTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.angleNumStartTextBox.Name = "angleNumStartTextBox";
            this.angleNumStartTextBox.Size = new System.Drawing.Size(77, 25);
            this.angleNumStartTextBox.TabIndex = 25;
            this.angleNumStartTextBox.Text = "4";
            this.angleNumStartTextBox.TextChanged += new System.EventHandler(this.angleNumStartTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label6.Location = new System.Drawing.Point(22, 98);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "Угол поворота";
            // 
            // difflectAngleStartTextBox
            // 
            this.difflectAngleStartTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.difflectAngleStartTextBox.Location = new System.Drawing.Point(175, 96);
            this.difflectAngleStartTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.difflectAngleStartTextBox.Name = "difflectAngleStartTextBox";
            this.difflectAngleStartTextBox.Size = new System.Drawing.Size(77, 25);
            this.difflectAngleStartTextBox.TabIndex = 27;
            this.difflectAngleStartTextBox.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stepTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.loopBuildRadioButton);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 162);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(409, 160);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки построения";
            // 
            // stepTextBox
            // 
            this.stepTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.stepTextBox.Location = new System.Drawing.Point(261, 121);
            this.stepTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(77, 25);
            this.stepTextBox.TabIndex = 27;
            this.stepTextBox.Text = "1";
            this.stepTextBox.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label8.Location = new System.Drawing.Point(17, 124);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Шаг";
            this.label8.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox7.Location = new System.Drawing.Point(261, 88);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(77, 25);
            this.textBox7.TabIndex = 25;
            this.textBox7.Text = "2";
            this.textBox7.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label7.Location = new System.Drawing.Point(17, 91);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Конечная степень";
            this.label7.Visible = false;
            // 
            // loopBuildRadioButton
            // 
            this.loopBuildRadioButton.AutoSize = true;
            this.loopBuildRadioButton.Location = new System.Drawing.Point(207, 26);
            this.loopBuildRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.loopBuildRadioButton.Name = "loopBuildRadioButton";
            this.loopBuildRadioButton.Size = new System.Drawing.Size(181, 21);
            this.loopBuildRadioButton.TabIndex = 23;
            this.loopBuildRadioButton.Text = "Циклическое построение";
            this.loopBuildRadioButton.UseVisualStyleBackColor = true;
            this.loopBuildRadioButton.CheckedChanged += new System.EventHandler(this.loopBuildRadioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 25);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(167, 21);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Единичное построение";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(613, 312);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 25);
            this.button1.TabIndex = 29;
            this.button1.Text = "Исследование";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // angleEndTextBox
            // 
            this.angleEndTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.angleEndTextBox.Location = new System.Drawing.Point(274, 54);
            this.angleEndTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.angleEndTextBox.Name = "angleEndTextBox";
            this.angleEndTextBox.Size = new System.Drawing.Size(77, 25);
            this.angleEndTextBox.TabIndex = 30;
            this.angleEndTextBox.Text = "4";
            this.angleEndTextBox.TextChanged += new System.EventHandler(this.angleEndTextBox_TextChanged);
            // 
            // difflectAngleEndTextBox
            // 
            this.difflectAngleEndTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.difflectAngleEndTextBox.Location = new System.Drawing.Point(274, 95);
            this.difflectAngleEndTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.difflectAngleEndTextBox.Name = "difflectAngleEndTextBox";
            this.difflectAngleEndTextBox.Size = new System.Drawing.Size(77, 25);
            this.difflectAngleEndTextBox.TabIndex = 31;
            this.difflectAngleEndTextBox.Text = "0";
            // 
            // volumeEndTextBox
            // 
            this.volumeEndTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.volumeEndTextBox.Location = new System.Drawing.Point(289, 129);
            this.volumeEndTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.volumeEndTextBox.Name = "volumeEndTextBox";
            this.volumeEndTextBox.Size = new System.Drawing.Size(62, 25);
            this.volumeEndTextBox.TabIndex = 32;
            this.volumeEndTextBox.Text = "40";
            // 
            // difflectionStepTextBox
            // 
            this.difflectionStepTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.difflectionStepTextBox.Location = new System.Drawing.Point(372, 95);
            this.difflectionStepTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.difflectionStepTextBox.Name = "difflectionStepTextBox";
            this.difflectionStepTextBox.Size = new System.Drawing.Size(77, 25);
            this.difflectionStepTextBox.TabIndex = 34;
            this.difflectionStepTextBox.Text = "1";
            // 
            // angleStepTextBox
            // 
            this.angleStepTextBox.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.angleStepTextBox.Location = new System.Drawing.Point(372, 54);
            this.angleStepTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.angleStepTextBox.Name = "angleStepTextBox";
            this.angleStepTextBox.Size = new System.Drawing.Size(77, 25);
            this.angleStepTextBox.TabIndex = 33;
            this.angleStepTextBox.Text = "1";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.textBox6.Location = new System.Drawing.Point(387, 129);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(62, 25);
            this.textBox6.TabIndex = 35;
            this.textBox6.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label9.Location = new System.Drawing.Point(187, 34);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Начало";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label10.Location = new System.Drawing.Point(291, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Конец";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label11.Location = new System.Drawing.Point(386, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Шаг";
            // 
            // NAngleEmprovedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 350);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.difflectionStepTextBox);
            this.Controls.Add(this.angleStepTextBox);
            this.Controls.Add(this.volumeEndTextBox);
            this.Controls.Add(this.difflectAngleEndTextBox);
            this.Controls.Add(this.angleEndTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.difflectAngleStartTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.angleNumStartTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.volumeStartTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.calculateButton);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NAngleEmprovedForm";
            this.Text = "N угольник";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox volumeStartTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox angleNumStartTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox difflectAngleStartTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton loopBuildRadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox angleEndTextBox;
        private System.Windows.Forms.TextBox difflectAngleEndTextBox;
        private System.Windows.Forms.TextBox volumeEndTextBox;
        private System.Windows.Forms.TextBox difflectionStepTextBox;
        private System.Windows.Forms.TextBox angleStepTextBox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}