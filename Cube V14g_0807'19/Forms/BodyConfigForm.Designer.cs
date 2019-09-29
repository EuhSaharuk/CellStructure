namespace Cube_V11
{
    partial class BodyConfigForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.bodyLenghtText = new System.Windows.Forms.TextBox();
            this.bodyHeightText = new System.Windows.Forms.TextBox();
            this.bodyWidthText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paralRadioButton = new System.Windows.Forms.RadioButton();
            this.cubeRadioButton = new System.Windows.Forms.RadioButton();
            this.deleteBody = new System.Windows.Forms.Button();
            this.buildBody = new System.Windows.Forms.Button();
            this.rebuildBody = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 51);
            this.label4.TabIndex = 17;
            this.label4.Text = "Примечание: Ширина и Длина - \r\nгабариты грани, на которой \r\nрисуются отверстия.";
            // 
            // bodyLenghtText
            // 
            this.bodyLenghtText.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.bodyLenghtText.Location = new System.Drawing.Point(16, 122);
            this.bodyLenghtText.Name = "bodyLenghtText";
            this.bodyLenghtText.Size = new System.Drawing.Size(100, 25);
            this.bodyLenghtText.TabIndex = 16;
            this.bodyLenghtText.Text = "15";
            // 
            // bodyHeightText
            // 
            this.bodyHeightText.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.bodyHeightText.Location = new System.Drawing.Point(18, 167);
            this.bodyHeightText.Name = "bodyHeightText";
            this.bodyHeightText.Size = new System.Drawing.Size(100, 25);
            this.bodyHeightText.TabIndex = 15;
            this.bodyHeightText.Text = "15";
            // 
            // bodyWidthText
            // 
            this.bodyWidthText.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.bodyWidthText.Location = new System.Drawing.Point(18, 68);
            this.bodyWidthText.Name = "bodyWidthText";
            this.bodyWidthText.Size = new System.Drawing.Size(100, 25);
            this.bodyWidthText.TabIndex = 14;
            this.bodyWidthText.Text = "15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label3.Location = new System.Drawing.Point(15, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Длина  (м)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label2.Location = new System.Drawing.Point(15, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Высота  (м)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ширина (м)";
            // 
            // paralRadioButton
            // 
            this.paralRadioButton.AutoSize = true;
            this.paralRadioButton.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.paralRadioButton.Location = new System.Drawing.Point(159, 12);
            this.paralRadioButton.Name = "paralRadioButton";
            this.paralRadioButton.Size = new System.Drawing.Size(122, 21);
            this.paralRadioButton.TabIndex = 10;
            this.paralRadioButton.TabStop = true;
            this.paralRadioButton.Text = "Паралелепипед";
            this.paralRadioButton.UseVisualStyleBackColor = true;
            this.paralRadioButton.CheckedChanged += new System.EventHandler(this.paralRadioButton_CheckedChanged);
            // 
            // cubeRadioButton
            // 
            this.cubeRadioButton.AutoSize = true;
            this.cubeRadioButton.Checked = true;
            this.cubeRadioButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cubeRadioButton.Location = new System.Drawing.Point(18, 12);
            this.cubeRadioButton.Name = "cubeRadioButton";
            this.cubeRadioButton.Size = new System.Drawing.Size(50, 21);
            this.cubeRadioButton.TabIndex = 9;
            this.cubeRadioButton.TabStop = true;
            this.cubeRadioButton.Text = "Куб";
            this.cubeRadioButton.UseVisualStyleBackColor = true;
            this.cubeRadioButton.CheckedChanged += new System.EventHandler(this.cubeRadioButton_CheckedChanged);
            // 
            // deleteBody
            // 
            this.deleteBody.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.deleteBody.Location = new System.Drawing.Point(159, 167);
            this.deleteBody.Name = "deleteBody";
            this.deleteBody.Size = new System.Drawing.Size(146, 33);
            this.deleteBody.TabIndex = 19;
            this.deleteBody.Text = "Удалить тело";
            this.deleteBody.UseVisualStyleBackColor = true;
            this.deleteBody.Click += new System.EventHandler(this.deleteBody_Click);
            // 
            // buildBody
            // 
            this.buildBody.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildBody.Location = new System.Drawing.Point(159, 63);
            this.buildBody.Name = "buildBody";
            this.buildBody.Size = new System.Drawing.Size(146, 33);
            this.buildBody.TabIndex = 18;
            this.buildBody.Text = "Построить тело";
            this.buildBody.UseVisualStyleBackColor = true;
            this.buildBody.Click += new System.EventHandler(this.buildBody_Click);
            // 
            // rebuildBody
            // 
            this.rebuildBody.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.rebuildBody.Location = new System.Drawing.Point(159, 114);
            this.rebuildBody.Name = "rebuildBody";
            this.rebuildBody.Size = new System.Drawing.Size(146, 33);
            this.rebuildBody.TabIndex = 20;
            this.rebuildBody.Text = "Перестроить тело";
            this.rebuildBody.UseVisualStyleBackColor = true;
            this.rebuildBody.Click += new System.EventHandler(this.rebuildBody_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(159, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "Задействовать Solid?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // BodyConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 279);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.rebuildBody);
            this.Controls.Add(this.deleteBody);
            this.Controls.Add(this.buildBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bodyLenghtText);
            this.Controls.Add(this.bodyHeightText);
            this.Controls.Add(this.bodyWidthText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paralRadioButton);
            this.Controls.Add(this.cubeRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BodyConfigForm";
            this.Text = "Настройки тела";
            this.Load += new System.EventHandler(this.BodyConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bodyLenghtText;
        private System.Windows.Forms.TextBox bodyHeightText;
        private System.Windows.Forms.TextBox bodyWidthText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton paralRadioButton;
        private System.Windows.Forms.RadioButton cubeRadioButton;
        private System.Windows.Forms.Button deleteBody;
        private System.Windows.Forms.Button buildBody;
        private System.Windows.Forms.Button rebuildBody;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}